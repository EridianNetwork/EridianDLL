using System;
using ns0;
using XsdSettings;

// Token: 0x02000718 RID: 1816
public class MatchMakingView : BaseView
{
	// Token: 0x0600302A RID: 12330 RVA: 0x0001F345 File Offset: 0x0001D545
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x0600302B RID: 12331 RVA: 0x0001F35D File Offset: 0x0001D55D
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x0600302C RID: 12332 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5()
	{
	}

	// Token: 0x0600302D RID: 12333 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6()
	{
	}

	// Token: 0x04002175 RID: 8565
	public GamemodeType m_gameMode;
}
