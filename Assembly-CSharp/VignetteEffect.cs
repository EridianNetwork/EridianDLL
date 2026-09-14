using System;
using UnityEngine;

// Token: 0x020005C1 RID: 1473
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Vignette Effect")]
[ExecuteInEditMode]
public class VignetteEffect : MonoBehaviour
{
	// Token: 0x0600255C RID: 9564 RVA: 0x000B3D34 File Offset: 0x000B1F34
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		if (this.VignetteShader == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_vignetteMaterial = new Material(this.VignetteShader);
		if (this.m_vignetteMaterial == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_vignetteMaterial.hideFlags = HideFlags.HideAndDontSave;
		this.m_bSupported = true;
	}

	// Token: 0x0600255D RID: 9565 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x0600255E RID: 9566 RVA: 0x00019642 File Offset: 0x00017842
	private void method_0()
	{
		global::UnityEngine.Object.DestroyImmediate(this.m_vignetteMaterial);
		this.m_vignetteMaterial = null;
	}

	// Token: 0x0600255F RID: 9567 RVA: 0x00019656 File Offset: 0x00017856
	private void OnDestroy()
	{
		this.method_0();
	}

	// Token: 0x06002560 RID: 9568 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnEnable()
	{
	}

	// Token: 0x06002561 RID: 9569 RVA: 0x000B3DB8 File Offset: 0x000B1FB8
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_bSupported && this.VignetteShader.isSupported)
		{
			this.m_vignetteMaterial.SetFloat("_VignetteScale", this.VignetteScale);
			Graphics.Blit(source, destination, this.m_vignetteMaterial, 0);
			return;
		}
		base.enabled = false;
	}

	// Token: 0x04001AC0 RID: 6848
	public Shader VignetteShader;

	// Token: 0x04001AC1 RID: 6849
	public float VignetteScale = 1f;

	// Token: 0x04001AC2 RID: 6850
	private Material m_vignetteMaterial;

	// Token: 0x04001AC3 RID: 6851
	private bool m_bSupported;
}
