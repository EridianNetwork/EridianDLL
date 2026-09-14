using System;
using ns0;

// Token: 0x02000736 RID: 1846
public class NewInstanceSelectView : BaseView
{
	// Token: 0x060030C6 RID: 12486 RVA: 0x0001F345 File Offset: 0x0001D545
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x060030C7 RID: 12487 RVA: 0x0001F35D File Offset: 0x0001D55D
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x060030C8 RID: 12488 RVA: 0x0001FCD1 File Offset: 0x0001DED1
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			TownInstanceSelectionControl.smethod_7();
		}
		else
		{
			TownInstanceSelectionControl.smethod_6();
		}
	}

	// Token: 0x060030C9 RID: 12489 RVA: 0x0001FCEF File Offset: 0x0001DEEF
	public override bool vmethod_4()
	{
		if (!MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().Boolean_1 && this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}
}
