using System;
using ns0;

// Token: 0x020006F8 RID: 1784
public class GuildSearchView : BaseView
{
	// Token: 0x06002F28 RID: 12072 RVA: 0x0001F0FD File Offset: 0x0001D2FD
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "Guild");
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
	}

	// Token: 0x06002F29 RID: 12073 RVA: 0x0001F028 File Offset: 0x0001D228
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
	}

	// Token: 0x06002F2A RID: 12074 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x06002F2B RID: 12075 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002F2C RID: 12076 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(GuildSearchView.GuildSearchPart guildSearchPart_0 = GuildSearchView.GuildSearchPart.e_None)
	{
	}

	// Token: 0x06002F2D RID: 12077 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(int int_0)
	{
	}

	// Token: 0x06002F2E RID: 12078 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_7()
	{
		return 0;
	}

	// Token: 0x020006F9 RID: 1785
	public enum GuildSearchPart
	{
		// Token: 0x040020EC RID: 8428
		e_None,
		// Token: 0x040020ED RID: 8429
		e_GuildMember,
		// Token: 0x040020EE RID: 8430
		e_GuildNews,
		// Token: 0x040020EF RID: 8431
		e_GuildSkill,
		// Token: 0x040020F0 RID: 8432
		e_GuildApplication
	}
}
