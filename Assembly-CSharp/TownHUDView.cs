using System;
using ns0;
using UnityEngine;

// Token: 0x02000759 RID: 1881
public class TownHUDView : BaseView
{
	// Token: 0x060031C5 RID: 12741 RVA: 0x000E203C File Offset: 0x000E023C
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
		Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		if (camera_ != null)
		{
			this._screenPosition.Set(camera_.pixelWidth / 2f, camera_.pixelHeight / 2f, 0f);
		}
	}

	// Token: 0x060031C6 RID: 12742 RVA: 0x00020675 File Offset: 0x0001E875
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
		this._screenPosition = Vector3.zero;
	}

	// Token: 0x060031C7 RID: 12743 RVA: 0x00020698 File Offset: 0x0001E898
	public virtual void vmethod_5(E_USE_TYPE e_USE_TYPE_0)
	{
		this._curType = e_USE_TYPE_0;
	}

	// Token: 0x04002268 RID: 8808
	protected E_USE_TYPE _curType;

	// Token: 0x04002269 RID: 8809
	protected Vector3 _screenPosition = Vector3.zero;
}
