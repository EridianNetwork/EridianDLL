using System;
using ns0;

// Token: 0x02000763 RID: 1891
public class WorldMapSelectView : BaseView
{
	// Token: 0x06003224 RID: 12836 RVA: 0x0001F345 File Offset: 0x0001D545
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x06003225 RID: 12837 RVA: 0x00020A81 File Offset: 0x0001EC81
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_4));
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x06003226 RID: 12838 RVA: 0x00020AB4 File Offset: 0x0001ECB4
	public void method_3()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_4));
	}

	// Token: 0x06003227 RID: 12839 RVA: 0x00020AD1 File Offset: 0x0001ECD1
	protected void method_4()
	{
		if (!this._bVisible)
		{
			return;
		}
		if (MonoSingleton<InputManager>.Instance.method_6("Escape"))
		{
			this.vmethod_1(false, false);
		}
	}

	// Token: 0x06003228 RID: 12840 RVA: 0x000E3068 File Offset: 0x000E1268
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = !this._bVisible;
		if (this._bVisible)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_4), false);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_9();
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_4));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_10();
		}
		WorldMapSelectionController.smethod_2();
	}

	// Token: 0x06003229 RID: 12841 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}
}
