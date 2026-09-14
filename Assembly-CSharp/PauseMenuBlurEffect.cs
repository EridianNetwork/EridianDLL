using System;
using UnityEngine;

// Token: 0x020005B7 RID: 1463
[AddComponentMenu("Image Effects/Pause Menu Blur Effect")]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PauseMenuBlurEffect : MonoBehaviour
{
	// Token: 0x0600252C RID: 9516 RVA: 0x000B2C38 File Offset: 0x000B0E38
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		if (this.BlurShader == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_blurMaterial = new Material(this.BlurShader);
		if (this.m_blurMaterial == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_blurMaterial.hideFlags = HideFlags.HideAndDontSave;
		this.m_bSupported = true;
	}

	// Token: 0x0600252D RID: 9517 RVA: 0x00019476 File Offset: 0x00017676
	private void method_0()
	{
		global::UnityEngine.Object.DestroyImmediate(this.m_blurMaterial);
		this.m_blurMaterial = null;
	}

	// Token: 0x0600252E RID: 9518 RVA: 0x0001948A File Offset: 0x0001768A
	private void OnDestroy()
	{
		this.method_0();
	}

	// Token: 0x0600252F RID: 9519 RVA: 0x000B2CBC File Offset: 0x000B0EBC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_bSupported && this.BlurShader.isSupported)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0);
			RenderTexture temporary2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			RenderTexture temporary3 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			RenderTexture temporary4 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			float num = 1f * (float)source.width / (1f * (float)source.height);
			float num2 = 0.001953125f;
			Graphics.Blit(source, temporary, this.m_blurMaterial, 5);
			Graphics.Blit(temporary, temporary3, this.m_blurMaterial, 5);
			Graphics.Blit(temporary3, temporary2, this.m_blurMaterial, 6);
			this.BlurIterations = Mathf.Clamp(this.BlurIterations, 1, 10);
			this.BlurPass = Mathf.Clamp(this.BlurPass, 0, 4);
			for (int i = 0; i < this.BlurIterations; i++)
			{
				float num3 = (1f + (float)i * 0.25f) * this.SepBlurSpread;
				this.m_blurMaterial.SetVector("_Offsets", new Vector4(0f, num3 * num2, 0f, 0f));
				Graphics.Blit(temporary3, temporary4, this.m_blurMaterial, this.BlurPass);
				this.m_blurMaterial.SetVector("_Offsets", new Vector4(num3 / num * num2, 0f, 0f, 0f));
				Graphics.Blit(temporary4, temporary3, this.m_blurMaterial, this.BlurPass);
				if (i == 0)
				{
					Graphics.Blit(temporary3, temporary2);
				}
				else
				{
					Graphics.Blit(temporary3, temporary2, this.m_blurMaterial, 7);
				}
			}
			Graphics.Blit(temporary3, temporary);
			Graphics.Blit(temporary, destination, this.m_blurMaterial, 7);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary3);
			RenderTexture.ReleaseTemporary(temporary4);
			return;
		}
		base.enabled = false;
	}

	// Token: 0x04001A8C RID: 6796
	public Shader BlurShader;

	// Token: 0x04001A8D RID: 6797
	public float SepBlurSpread = 2.5f;

	// Token: 0x04001A8E RID: 6798
	public int BlurIterations = 2;

	// Token: 0x04001A8F RID: 6799
	public int BlurPass = 5;

	// Token: 0x04001A90 RID: 6800
	private Material m_blurMaterial;

	// Token: 0x04001A91 RID: 6801
	private bool m_bSupported;
}
