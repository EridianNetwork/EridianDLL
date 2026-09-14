using System;
using ns0;

// Token: 0x02000704 RID: 1796
public class HUDTeamMatePortraitView : BaseView
{
	// Token: 0x06002F68 RID: 12136 RVA: 0x0001DC48 File Offset: 0x0001BE48
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
	}

	// Token: 0x06002F69 RID: 12137 RVA: 0x0001DC60 File Offset: 0x0001BE60
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
	}

	// Token: 0x06002F6A RID: 12138 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(PlayerInfoSync playerInfoSync_0, int int_0, int int_1)
	{
	}

	// Token: 0x06002F6B RID: 12139 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(PlayerInfoSync playerInfoSync_0, int int_0, int int_1)
	{
	}

	// Token: 0x06002F6C RID: 12140 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7(Presence presence_0, int int_0, int int_1)
	{
	}

	// Token: 0x06002F6D RID: 12141 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_8()
	{
	}

	// Token: 0x06002F6E RID: 12142 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_9()
	{
	}

	// Token: 0x06002F6F RID: 12143 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_10()
	{
	}
}
