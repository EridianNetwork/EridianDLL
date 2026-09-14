using System;
using UnityEngine;

// Token: 0x020005B5 RID: 1461
[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public class ImageEffectBase : MonoBehaviour
{
	// Token: 0x06002524 RID: 9508 RVA: 0x000193AF File Offset: 0x000175AF
	protected virtual void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (!this.shader || !this.shader.isSupported)
		{
			base.enabled = false;
		}
	}

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x06002525 RID: 9509 RVA: 0x000193E1 File Offset: 0x000175E1
	protected Material Material_0
	{
		get
		{
			if (this.m_Material == null)
			{
				this.m_Material = new Material(this.shader);
				this.m_Material.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_Material;
		}
	}

	// Token: 0x06002526 RID: 9510 RVA: 0x00019415 File Offset: 0x00017615
	protected virtual void OnDisable()
	{
		if (this.m_Material)
		{
			global::UnityEngine.Object.DestroyImmediate(this.m_Material);
		}
	}

	// Token: 0x04001A87 RID: 6791
	public Shader shader;

	// Token: 0x04001A88 RID: 6792
	private Material m_Material;
}
