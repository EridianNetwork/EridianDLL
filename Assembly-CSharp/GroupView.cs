using System;
using ns0;
using XsdSettings;

// Token: 0x020006F5 RID: 1781
public class GroupView : BaseView
{
	// Token: 0x06002F18 RID: 12056 RVA: 0x000D96C8 File Offset: 0x000D78C8
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, ControlAction.Group.ToString());
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		GroupManager.smethod_0().method_21();
	}

	// Token: 0x06002F19 RID: 12057 RVA: 0x0001F028 File Offset: 0x0001D228
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
	}

	// Token: 0x06002F1A RID: 12058 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002F1B RID: 12059 RVA: 0x0001F097 File Offset: 0x0001D297
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (!bool_0)
		{
			GroupManager.smethod_0().method_10();
		}
	}

	// Token: 0x06002F1C RID: 12060 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5()
	{
	}
}
