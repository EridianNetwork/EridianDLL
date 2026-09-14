using System;

// Token: 0x020006E9 RID: 1769
public class AchievementPopUpView : BaseView
{
	// Token: 0x06002EAE RID: 11950 RVA: 0x0001ECEC File Offset: 0x0001CEEC
	public override void vmethod_2()
	{
		base.vmethod_2();
		AchievementManager.AchievementManager_0.method_4();
	}

	// Token: 0x06002EAF RID: 11951 RVA: 0x0001ECFE File Offset: 0x0001CEFE
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._bVisible = false;
	}

	// Token: 0x06002EB0 RID: 11952 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(UIAchievementItemData uiachievementItemData_0)
	{
	}
}
