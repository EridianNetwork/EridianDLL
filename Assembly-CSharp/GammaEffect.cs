using System;
using UnityEngine;

// Token: 0x020005B3 RID: 1459
[AddComponentMenu("Image Effects/Gamma")]
[RequireComponent(typeof(Camera))]
public class GammaEffect : MonoBehaviour
{
	// Token: 0x06002516 RID: 9494 RVA: 0x000192B6 File Offset: 0x000174B6
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (this.ShaderGamma == null)
		{
			base.enabled = false;
		}
		else if (!this.ShaderGamma.isSupported)
		{
			base.enabled = false;
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x06002517 RID: 9495 RVA: 0x000192F2 File Offset: 0x000174F2
	protected Material Material_0
	{
		get
		{
			if (this.m_matGamma == null)
			{
				this.m_matGamma = new Material(this.ShaderGamma);
				this.m_matGamma.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_matGamma;
		}
	}

	// Token: 0x06002518 RID: 9496 RVA: 0x00019326 File Offset: 0x00017526
	protected void OnDisable()
	{
		if (this.m_matGamma)
		{
			global::UnityEngine.Object.DestroyImmediate(this.m_matGamma);
		}
	}

	// Token: 0x06002519 RID: 9497 RVA: 0x00019340 File Offset: 0x00017540
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.Material_0.SetFloat("_GammaValue", this.GammaValue);
		Graphics.Blit(source, destination, this.Material_0);
	}

	// Token: 0x04001A70 RID: 6768
	public Shader ShaderGamma;

	// Token: 0x04001A71 RID: 6769
	public float GammaValue = 2f;

	// Token: 0x04001A72 RID: 6770
	private Material m_matGamma;
}
