using System;
using ns0;

// Token: 0x020006C1 RID: 1729
public class MiniMapView : BaseView
{
	// Token: 0x06002D8F RID: 11663 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002D90 RID: 11664 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnTestGUI()
	{
	}

	// Token: 0x06002D91 RID: 11665 RVA: 0x0001DC48 File Offset: 0x0001BE48
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
	}

	// Token: 0x06002D92 RID: 11666 RVA: 0x0001DC60 File Offset: 0x0001BE60
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
	}
}
