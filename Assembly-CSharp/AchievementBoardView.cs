using System;
using ns0;
using XsdSettings;

// Token: 0x020006E3 RID: 1763
public class AchievementBoardView : BaseView
{
	// Token: 0x06002E7E RID: 11902 RVA: 0x000D88A4 File Offset: 0x000D6AA4
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, ControlAction.Achievement.ToString());
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		AchievementManager.AchievementManager_0.method_4();
	}

	// Token: 0x06002E7F RID: 11903 RVA: 0x000D8900 File Offset: 0x000D6B00
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._bVisible = false;
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_17(this, string.Empty);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
	}

	// Token: 0x06002E80 RID: 11904 RVA: 0x000D8950 File Offset: 0x000D6B50
	public override bool OnShortCutCMD(string command)
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			return false;
		}
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			return false;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return false;
		}
		Entity entity = localPlayer.GetEntity();
		if (entity == null)
		{
			return false;
		}
		PlayerController component = entity.GetComponent<PlayerController>();
		if (component == null)
		{
			return false;
		}
		if (!this.Boolean_0)
		{
			return false;
		}
		this.Boolean_1 = !this.Boolean_1;
		return true;
	}

	// Token: 0x06002E81 RID: 11905 RVA: 0x0001EB9D File Offset: 0x0001CD9D
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.vmethod_1(false, false);
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002E82 RID: 11906 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x06002E83 RID: 11907 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5()
	{
	}
}
