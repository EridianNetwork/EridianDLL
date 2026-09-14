using System;
using ns0;

// Token: 0x02000743 RID: 1859
public class PvPFlowView : BaseView
{
	// Token: 0x0600310F RID: 12559 RVA: 0x0001FEB1 File Offset: 0x0001E0B1
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "PVP");
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
	}

	// Token: 0x06003110 RID: 12560 RVA: 0x0001FEEE File Offset: 0x0001E0EE
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_17(this, "PVP");
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
	}

	// Token: 0x06003111 RID: 12561 RVA: 0x0001FF2B File Offset: 0x0001E12B
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (!bool_0)
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
		}
	}

	// Token: 0x06003112 RID: 12562 RVA: 0x0001FF43 File Offset: 0x0001E143
	public override bool OnShortCutCMD(string command)
	{
		if (this.Boolean_0 && this.Boolean_1)
		{
			this.method_3();
			return false;
		}
		return base.OnShortCutCMD(command);
	}

	// Token: 0x06003113 RID: 12563 RVA: 0x0001FF64 File Offset: 0x0001E164
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.method_3();
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06003114 RID: 12564 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(int int_0)
	{
	}

	// Token: 0x06003115 RID: 12565 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6()
	{
	}

	// Token: 0x06003116 RID: 12566 RVA: 0x000DFCBC File Offset: 0x000DDEBC
	protected void method_3()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().Boolean_1)
		{
			return;
		}
		if (LobbyManager.smethod_0().method_1())
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("PVP_MatchMaking_Dismiss")), new Delegate_EventProc(this.method_4), new Delegate_EventProc(this.method_5));
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("PVP_MatchMaking_Leave")), new Delegate_EventProc(this.method_6), new Delegate_EventProc(this.method_7));
		}
	}

	// Token: 0x06003117 RID: 12567 RVA: 0x0001FF7C File Offset: 0x0001E17C
	protected void method_4()
	{
		LobbyManager.smethod_0().method_26();
	}

	// Token: 0x06003118 RID: 12568 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_5()
	{
	}

	// Token: 0x06003119 RID: 12569 RVA: 0x0001FF88 File Offset: 0x0001E188
	protected void method_6()
	{
		LobbyManager.smethod_0().method_24();
	}

	// Token: 0x0600311A RID: 12570 RVA: 0x0001E5A9 File Offset: 0x0001C7A9
	protected void method_7()
	{
		this.Boolean_1 = false;
	}

	// Token: 0x0600311B RID: 12571 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7()
	{
	}
}
