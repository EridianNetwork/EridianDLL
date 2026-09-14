using System;
using ns0;

// Token: 0x020006FC RID: 1788
public class HUDCountDownView : BaseView
{
	// Token: 0x06002F30 RID: 12080 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x06002F31 RID: 12081 RVA: 0x0001F13A File Offset: 0x0001D33A
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_4(this);
		}
	}

	// Token: 0x06002F32 RID: 12082 RVA: 0x0001DC60 File Offset: 0x0001BE60
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
	}

	// Token: 0x06002F33 RID: 12083 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(int int_0)
	{
	}

	// Token: 0x06002F34 RID: 12084 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6()
	{
	}

	// Token: 0x06002F35 RID: 12085 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7()
	{
	}

	// Token: 0x06002F36 RID: 12086 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_8(int int_0)
	{
	}
}
