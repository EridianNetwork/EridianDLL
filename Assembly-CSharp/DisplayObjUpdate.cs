using System;
using ns0;
using UnityEngine;

// Token: 0x020005A1 RID: 1441
public class DisplayObjUpdate : MonoBehaviour
{
	// Token: 0x0600249F RID: 9375 RVA: 0x000AF390 File Offset: 0x000AD590
	private void Start()
	{
		this.mNeedShaderModify = false;
		Shader shader = Shader.Find("Custom/BOL_Charactor_BRDF");
		this.m_render = (Renderer)base.gameObject.GetComponent(typeof(Renderer));
		if (this.m_render)
		{
			Material material = this.m_render.material;
			if (shader == material.shader)
			{
				this.mNeedShaderModify = true;
				this.mBrdfPara = material.GetFloat("_BRDF_PARA");
			}
		}
		if (MonoSingleton<VisibilityManager>.Instance)
		{
			MonoSingleton<VisibilityManager>.Instance.method_0(this.m_render);
		}
	}

	// Token: 0x060024A0 RID: 9376 RVA: 0x00018F2E File Offset: 0x0001712E
	private void OnDestroy()
	{
		if (MonoSingleton<VisibilityManager>.Instance)
		{
			MonoSingleton<VisibilityManager>.Instance.method_2(this.m_render);
		}
	}

	// Token: 0x060024A1 RID: 9377 RVA: 0x00018F4C File Offset: 0x0001714C
	private void OnWillRenderObject()
	{
		if (this.mNeedShaderModify && MonoSingleton<GraphicsMgr>.Instance)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_15(base.gameObject, this.mBrdfPara);
		}
	}

	// Token: 0x040019CB RID: 6603
	private bool mNeedShaderModify;

	// Token: 0x040019CC RID: 6604
	private float mBrdfPara;

	// Token: 0x040019CD RID: 6605
	private Renderer m_render;
}
