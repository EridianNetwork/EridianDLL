using System;
using ns0;
using UnityEngine;

// Token: 0x02000714 RID: 1812
internal class LoadingInGameView : BaseView
{
	// Token: 0x0600300D RID: 12301 RVA: 0x000DB87C File Offset: 0x000D9A7C
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._loadingIMGRoot = global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("UI_uniSWF/LoadingResource/BOL_LoadingImg")) as GameObject;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_4(this._loadingIMGRoot);
		this._loadingIMGRoot.transform.position = new Vector3(-1000f, -1000f, -1000f);
	}

	// Token: 0x0600300E RID: 12302 RVA: 0x000DB8E4 File Offset: 0x000D9AE4
	public void method_3(int int_0)
	{
		this._instanceID = int_0;
		LoadingImgController loadingImgController = (LoadingImgController)this._loadingIMGRoot.GetComponent("LoadingImgController");
		if (loadingImgController != null)
		{
			loadingImgController.method_2(int_0);
		}
	}

	// Token: 0x0600300F RID: 12303 RVA: 0x0001F7E1 File Offset: 0x0001D9E1
	public override void vmethod_3()
	{
		base.vmethod_3();
		global::UnityEngine.Object.Destroy(this._loadingIMGRoot);
	}

	// Token: 0x04002166 RID: 8550
	protected int _instanceID;

	// Token: 0x04002167 RID: 8551
	private GameObject _loadingIMGRoot;
}
