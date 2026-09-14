using System;
using UnityEngine;

// Token: 0x020006E2 RID: 1762
public class uniSWFFontOutline : FontOutline
{
	// Token: 0x06002E78 RID: 11896 RVA: 0x0001EB52 File Offset: 0x0001CD52
	private void OnDestroy()
	{
		global::UnityEngine.Object.Destroy(this.edgeDetectMaterial);
	}

	// Token: 0x06002E79 RID: 11897 RVA: 0x0001EB5F File Offset: 0x0001CD5F
	private void OnDisable()
	{
		if (this.edgeDetectMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.edgeDetectMaterial);
		}
	}

	// Token: 0x06002E7A RID: 11898 RVA: 0x000D8864 File Offset: 0x000D6A64
	private void Awake()
	{
		this.CheckResources();
		Camera component = base.gameObject.GetComponent<Camera>();
		if (component != null)
		{
			component.cullingMask = 1 << LayerMask.NameToLayer("UI");
		}
	}

	// Token: 0x06002E7B RID: 11899 RVA: 0x0001EB79 File Offset: 0x0001CD79
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.CheckResources();
	}

	// Token: 0x06002E7C RID: 11900 RVA: 0x0001EB82 File Offset: 0x0001CD82
	public void method_1(RenderTexture renderTexture_0, RenderTexture renderTexture_1)
	{
		if (this.CheckResources())
		{
			base.method_0(renderTexture_0, renderTexture_1);
		}
		else
		{
			Graphics.Blit(renderTexture_0, renderTexture_1);
		}
	}
}
