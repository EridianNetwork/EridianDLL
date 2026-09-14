using System;
using ns0;

// Token: 0x02000744 RID: 1860
public class PvPModeSelectView : BaseView
{
	// Token: 0x0600311D RID: 12573 RVA: 0x0001FEB1 File Offset: 0x0001E0B1
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "PVP");
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
	}

	// Token: 0x0600311E RID: 12574 RVA: 0x0001FEEE File Offset: 0x0001E0EE
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_17(this, "PVP");
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
	}

	// Token: 0x0600311F RID: 12575 RVA: 0x000DFD64 File Offset: 0x000DDF64
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (bool_0)
		{
			if (GroupManager.smethod_0().method_18())
			{
				if (GroupManager.smethod_0().method_19())
				{
					this.m_bCheckCondition = true;
				}
				else
				{
					this.m_bCheckCondition = false;
				}
			}
			else
			{
				this.m_bCheckCondition = true;
			}
			if (!this.m_bCheckCondition)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Teamate_PVP_Warning")), new Delegate_EventProc(this.method_3), null);
			}
		}
		else
		{
			this.m_bCheckCondition = true;
		}
		if (this.m_bCheckCondition)
		{
			base.vmethod_1(bool_0, bool_1);
		}
	}

	// Token: 0x06003120 RID: 12576 RVA: 0x0001FFA3 File Offset: 0x0001E1A3
	public override bool vmethod_4()
	{
		this.Boolean_1 = false;
		return base.vmethod_4();
	}

	// Token: 0x06003121 RID: 12577 RVA: 0x0001B43F File Offset: 0x0001963F
	protected void method_3()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(true);
	}

	// Token: 0x04002208 RID: 8712
	protected bool m_bCheckCondition = true;
}
