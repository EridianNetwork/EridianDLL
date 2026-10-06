using System;
using ns0;

// Token: 0x020006F4 RID: 1780
public class FriendView : BaseView
{
	// Token: 0x06002F12 RID: 12050 RVA: 0x000D9674 File Offset: 0x000D7874
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "Friend");
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		FriendManager.smethod_0().method_12();
	}

	// Token: 0x06002F13 RID: 12051 RVA: 0x0001F028 File Offset: 0x0001D228
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
	}

	// Token: 0x06002F14 RID: 12052 RVA: 0x0001F050 File Offset: 0x0001D250
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
			this.Boolean_1 = false;
			FriendManager.smethod_0().method_25();
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002F15 RID: 12053 RVA: 0x0001F083 File Offset: 0x0001D283
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			FriendManager.smethod_0().method_12(); // getting friendlist on each view open
		}
		FriendManager.smethod_0().method_25();
	}

	// Token: 0x06002F16 RID: 12054 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(bool bool_0 = false)
	{
	}
}
