using System;
using ns0;

// Token: 0x0200070C RID: 1804
public class InstanceView : BaseView
{
	// Token: 0x06002FBF RID: 12223 RVA: 0x0001F345 File Offset: 0x0001D545
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x06002FC0 RID: 12224 RVA: 0x0001F519 File Offset: 0x0001D719
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_4));
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x06002FC1 RID: 12225 RVA: 0x0001F54C File Offset: 0x0001D74C
	public void method_3()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_4));
	}

	// Token: 0x06002FC2 RID: 12226 RVA: 0x000DA574 File Offset: 0x000D8774
	protected void method_4()
	{
		if (!this._bVisible)
		{
			return;
		}
		if (MonoSingleton<InputManager>.Instance.method_13(0, false) && !InstanceBehaviour.m_FocusedOnSelected)
		{
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_11())
			{
				return;
			}
			if (!InstanceBehaviour.smethod_1())
			{
				return;
			}
			InstanceBehaviour.smethod_5();
			this.vmethod_6();
		}
	}

	// Token: 0x06002FC3 RID: 12227 RVA: 0x000DA5C4 File Offset: 0x000D87C4
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = !this._bVisible;
		if (this._bVisible)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_4), false);
			TownInstanceSelectionControl.smethod_2();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_9();
		}
		else
		{
			TownInstanceSelectionControl.smethod_1();
			this.vmethod_7();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_10();
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().Boolean_1 = this._bVisible;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestTrackView>().Boolean_1 = !this._bVisible;
	}

	// Token: 0x06002FC4 RID: 12228 RVA: 0x0001F569 File Offset: 0x0001D769
	public virtual void vmethod_5()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_4), false);
	}

	// Token: 0x06002FC5 RID: 12229 RVA: 0x0001F587 File Offset: 0x0001D787
	public virtual void vmethod_6()
	{
		this.method_3();
	}

	// Token: 0x06002FC6 RID: 12230 RVA: 0x0001F587 File Offset: 0x0001D787
	public virtual void vmethod_7()
	{
		this.method_3();
	}

	// Token: 0x06002FC7 RID: 12231 RVA: 0x0001F58F File Offset: 0x0001D78F
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			InstanceBehaviour.m_bCanClick = false;
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x0400213B RID: 8507
	protected bool m_bDifficultyShown;
}
