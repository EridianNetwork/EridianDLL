using System;
using ns0;

// Token: 0x020006F6 RID: 1782
public class GuildCreateView : BaseView
{
	// Token: 0x06002F1E RID: 12062 RVA: 0x0001F0AE File Offset: 0x0001D2AE
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		GuildManager.smethod_0().method_14();
	}

	// Token: 0x06002F1F RID: 12063 RVA: 0x0001F028 File Offset: 0x0001D228
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
	}

	// Token: 0x06002F20 RID: 12064 RVA: 0x0001F0E0 File Offset: 0x0001D2E0
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (!this.Boolean_1)
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
		}
	}

	// Token: 0x06002F21 RID: 12065 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
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
