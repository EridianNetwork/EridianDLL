using System;
using System.Collections.Generic;
using ns0;

// Token: 0x02000702 RID: 1794
public class HUDSkillStatusView : BaseView, ISkillTreeServiceNotificationListerner
{
	// Token: 0x06002F55 RID: 12117 RVA: 0x0001F1DD File Offset: 0x0001D3DD
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._curState = HUDSkillStatusView.eCurState.None;
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_1(this);
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
	}

	// Token: 0x06002F56 RID: 12118 RVA: 0x0001F207 File Offset: 0x0001D407
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._bInitialised = false;
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_2(this);
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
	}

	// Token: 0x06002F57 RID: 12119 RVA: 0x0001F231 File Offset: 0x0001D431
	public virtual void Update(SkillInfo curSkillInfo)
	{
		this._curSkillInfo = curSkillInfo;
		if (curSkillInfo != null)
		{
			this._curCharacterSkillID = curSkillInfo.m_current_skillID;
		}
		if (this._curCharacterSkillID == SkillID.Hunter)
		{
			this._hunterMarkInfo = MarkManager.MarkManager_0.method_1();
		}
	}

	// Token: 0x06002F58 RID: 12120 RVA: 0x000D9D6C File Offset: 0x000D7F6C
	public void OnSkillEvent(SkillEvent skillEvent)
	{
		if (!this._bFirstActionUnlocked)
		{
			return;
		}
		switch (skillEvent)
		{
		case SkillEvent.None:
			this._curState = HUDSkillStatusView.eCurState.None;
			break;
		case SkillEvent.FireBirdExplode:
		case SkillEvent.FireBirdAbsorb:
		case SkillEvent.BerserkCoolDownStart:
		case SkillEvent.TurretCooldownStart:
		case SkillEvent.HunterCooldownStart:
			this._curState = HUDSkillStatusView.eCurState.Cooldown;
			this.vmethod_9();
			break;
		case SkillEvent.FireBirdDive:
			this._curState = HUDSkillStatusView.eCurState.Collsion;
			this.vmethod_10();
			break;
		case SkillEvent.FireBirdAnimStart:
		case SkillEvent.BerserkDashStart:
		case SkillEvent.TurretThrowAnimStart:
		case SkillEvent.HunterReleaseAnimStart:
			this._curState = HUDSkillStatusView.eCurState.Prelude;
			this.vmethod_6();
			break;
		case SkillEvent.FireBirdSpawn:
		case SkillEvent.BerserkRageEffect:
		case SkillEvent.TurretSpawned:
		case SkillEvent.HunterDroidSpawned:
			this._curState = HUDSkillStatusView.eCurState.FirstAction;
			this.vmethod_7();
			break;
		case SkillEvent.FireBirdTurnStart:
		case SkillEvent.BerserkChargeStart:
			this._curState = HUDSkillStatusView.eCurState.SecondAction;
			this.vmethod_8();
			break;
		case SkillEvent.FireBirdCoolDownEnd:
		case SkillEvent.BerserkCoolDownEnd:
		case SkillEvent.TurretCooldownEnd:
		case SkillEvent.HunterCooldownEnd:
			this._curState = HUDSkillStatusView.eCurState.Normal;
			this.vmethod_12();
			break;
		}
	}

	// Token: 0x06002F59 RID: 12121 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5()
	{
	}

	// Token: 0x06002F5A RID: 12122 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x06002F5B RID: 12123 RVA: 0x0001F262 File Offset: 0x0001D462
	protected virtual void vmethod_7()
	{
		if (this._curCharacterSkillID == SkillID.Berserk)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_20().method_0(true);
		}
	}

	// Token: 0x06002F5C RID: 12124 RVA: 0x0001F27D File Offset: 0x0001D47D
	protected virtual void vmethod_8()
	{
		if (this._curCharacterSkillID == SkillID.Berserk)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_20().method_1(true);
		}
	}

	// Token: 0x06002F5D RID: 12125 RVA: 0x0001F298 File Offset: 0x0001D498
	protected virtual void vmethod_9()
	{
		if (this._curCharacterSkillID == SkillID.Berserk)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_20().method_0(false);
			MonoSingleton<GraphicsMgr>.Instance.method_20().method_1(false);
		}
	}

	// Token: 0x06002F5E RID: 12126 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_10()
	{
	}

	// Token: 0x06002F5F RID: 12127 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_11()
	{
	}

	// Token: 0x06002F60 RID: 12128 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_12()
	{
	}

	// Token: 0x06002F61 RID: 12129 RVA: 0x000D9E8C File Offset: 0x000D808C
	protected virtual void vmethod_13()
	{
		this._iUnSpentSkillPt = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_0;
		this._iEarnedSkillPt = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_1;
		this._bFirstActionUnlocked = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(1) > 0 || ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(51) > 0 || ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(101) > 0 || ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(151) > 0;
		this._bSecActionUnlocked = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(2) > 0 || ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(52) > 0 || ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(102) > 0 || ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_5(152) > 0;
	}

	// Token: 0x06002F62 RID: 12130 RVA: 0x0001F2C3 File Offset: 0x0001D4C3
	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
		this.vmethod_13();
	}

	// Token: 0x06002F63 RID: 12131 RVA: 0x0001F2C3 File Offset: 0x0001D4C3
	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		this.vmethod_13();
	}

	// Token: 0x06002F64 RID: 12132 RVA: 0x0001F2C3 File Offset: 0x0001D4C3
	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
		this.vmethod_13();
	}

	// Token: 0x06002F65 RID: 12133 RVA: 0x0001F2C3 File Offset: 0x0001D4C3
	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
		this.vmethod_13();
	}

	// Token: 0x06002F66 RID: 12134 RVA: 0x0001F2C3 File Offset: 0x0001D4C3
	public void OnSkillPtEarned(int characterId, int numEarned)
	{
		this.vmethod_13();
	}

	// Token: 0x04002111 RID: 8465
	protected bool _bInitialised;

	// Token: 0x04002112 RID: 8466
	protected bool _bFirstActionUnlocked;

	// Token: 0x04002113 RID: 8467
	protected bool _bSecActionUnlocked;

	// Token: 0x04002114 RID: 8468
	protected SkillInfo _curSkillInfo;

	// Token: 0x04002115 RID: 8469
	protected HUDSkillStatusView.eCurState _curState;

	// Token: 0x04002116 RID: 8470
	protected MarkManager.BroadcastMarkedInfo _hunterMarkInfo;

	// Token: 0x04002117 RID: 8471
	protected SkillID _curCharacterSkillID;

	// Token: 0x04002118 RID: 8472
	protected int _iUnSpentSkillPt;

	// Token: 0x04002119 RID: 8473
	protected int _iEarnedSkillPt;

	// Token: 0x02000703 RID: 1795
	public enum eCurState
	{
		// Token: 0x0400211B RID: 8475
		None,
		// Token: 0x0400211C RID: 8476
		Normal,
		// Token: 0x0400211D RID: 8477
		Prelude,
		// Token: 0x0400211E RID: 8478
		FirstAction,
		// Token: 0x0400211F RID: 8479
		SecondAction,
		// Token: 0x04002120 RID: 8480
		Collsion,
		// Token: 0x04002121 RID: 8481
		Explosion,
		// Token: 0x04002122 RID: 8482
		Cooldown
	}
}
