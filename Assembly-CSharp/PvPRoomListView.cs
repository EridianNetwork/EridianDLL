using System;
using ns0;

// Token: 0x02000745 RID: 1861
public class PvPRoomListView : BaseView
{
	// Token: 0x06003123 RID: 12579 RVA: 0x0001F345 File Offset: 0x0001D545
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x06003124 RID: 12580 RVA: 0x0001F35D File Offset: 0x0001D55D
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x06003125 RID: 12581 RVA: 0x0001FFA3 File Offset: 0x0001E1A3
	public override bool vmethod_4()
	{
		this.Boolean_1 = false;
		return base.vmethod_4();
	}
}
