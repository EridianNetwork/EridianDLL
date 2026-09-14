using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x020006FF RID: 1791
public class HUDPvPKillStampView : BaseView
{
	// Token: 0x06002F3F RID: 12095 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x06002F40 RID: 12096 RVA: 0x0001F157 File Offset: 0x0001D357
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.m_killstampInfoQueue.Clear();
		this.m_killstampInfoHistoryQueue.Clear();
		KillingStampManager.smethod_0().method_0();
	}

	// Token: 0x06002F41 RID: 12097 RVA: 0x000D9A24 File Offset: 0x000D7C24
	public void method_3(string string_0, List<ScoringActionType> list_0)
	{
		while (this.m_killstampInfoHistoryQueue.Count != 0 && this.m_killstampInfoHistoryQueue.Peek().bDisplayed)
		{
			this.m_killstampInfoHistoryQueue.Dequeue();
		}
		this.m_nNewStampCount = 0;
		if (string_0 == ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9())
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				if (list_0[i] != ScoringActionType.BasicKill)
				{
					this.m_nNewStampCount++;
					this.method_5(list_0[i]);
					this.method_6(list_0[i]);
					KillingStampManager.smethod_0().method_1(list_0[i]);
				}
			}
		}
		if (this.m_nNewStampCount > this.m_nMaxHistoryCount)
		{
			this.m_nNewStampCount = this.m_nMaxHistoryCount;
		}
		if (this.m_nNewStampCount > 0)
		{
			this.method_4();
		}
	}

	// Token: 0x06002F42 RID: 12098 RVA: 0x000D9AF4 File Offset: 0x000D7CF4
	public void method_4()
	{
		HUDPvPKillStampView.KillStampInfo[] array = this.m_killstampInfoHistoryQueue.ToArray();
		for (int i = 0; i < this.m_nMaxHistoryCount; i++)
		{
			if (i < array.Length)
			{
				bool flag = array[i].fTimeLeft <= 0f;
				bool flag2 = i >= array.Length - this.m_nNewStampCount;
				this.vmethod_5(i, array[i].ScoringType, flag2, flag, true);
			}
			else
			{
				this.vmethod_5(i, ScoringActionType.BasicKill, false, false, false);
			}
		}
	}

	// Token: 0x06002F43 RID: 12099 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(int int_0, ScoringActionType scoringActionType_0, bool bool_0, bool bool_1 = false, bool bool_2 = true)
	{
	}

	// Token: 0x06002F44 RID: 12100 RVA: 0x0001F17F File Offset: 0x0001D37F
	protected void method_5(ScoringActionType scoringActionType_0)
	{
		this.m_killstampInfoQueue.Enqueue(scoringActionType_0);
	}

	// Token: 0x06002F45 RID: 12101 RVA: 0x000D9B68 File Offset: 0x000D7D68
	protected void method_6(ScoringActionType scoringActionType_0)
	{
		if (this.m_killstampInfoHistoryQueue.Count >= this.m_nMaxHistoryCount)
		{
			this.m_killstampInfoHistoryQueue.Dequeue();
		}
		HUDPvPKillStampView.KillStampInfo killStampInfo = new HUDPvPKillStampView.KillStampInfo();
		killStampInfo.bDisplayed = false;
		killStampInfo.ScoringType = scoringActionType_0;
		killStampInfo.fTimeLeft = 5f;
		this.m_killstampInfoHistoryQueue.Enqueue(killStampInfo);
	}

	// Token: 0x06002F46 RID: 12102 RVA: 0x000D9BC0 File Offset: 0x000D7DC0
	public void method_7()
	{
		if (this.m_killstampInfoQueue.Count != 0)
		{
			ScoringActionType scoringActionType = this.m_killstampInfoQueue.Dequeue();
			MonoSingleton<AppManager>.Instance.method_0().imethod_0(Utility.smethod_5("UI_KillingStamp_", scoringActionType.ToString()));
			this.vmethod_6(scoringActionType);
		}
	}

	// Token: 0x06002F47 RID: 12103 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(ScoringActionType scoringActionType_0)
	{
	}

	// Token: 0x06002F48 RID: 12104 RVA: 0x000D9C14 File Offset: 0x000D7E14
	public virtual void Update(float fDeltaTime)
	{
		HUDPvPKillStampView.KillStampInfo[] array = this.m_killstampInfoHistoryQueue.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].fTimeLeft -= fDeltaTime;
			if (array[i].fTimeLeft < 0f)
			{
				array[i].fTimeLeft = 0f;
			}
		}
	}

	// Token: 0x06002F49 RID: 12105 RVA: 0x000D9C68 File Offset: 0x000D7E68
	public void method_8(int int_0)
	{
		HUDPvPKillStampView.KillStampInfo[] array = this.m_killstampInfoHistoryQueue.ToArray();
		if (int_0 < array.Length)
		{
			array[int_0].bDisplayed = true;
		}
	}

	// Token: 0x06002F4A RID: 12106 RVA: 0x000D9C90 File Offset: 0x000D7E90
	public bool method_9(int int_0)
	{
		HUDPvPKillStampView.KillStampInfo[] array = this.m_killstampInfoHistoryQueue.ToArray();
		return int_0 >= array.Length || array[int_0].bDisplayed;
	}

	// Token: 0x06002F4B RID: 12107 RVA: 0x000D9CBC File Offset: 0x000D7EBC
	public bool method_10(int int_0)
	{
		HUDPvPKillStampView.KillStampInfo[] array = this.m_killstampInfoHistoryQueue.ToArray();
		return int_0 < array.Length && array[int_0].fTimeLeft <= 0f;
	}

	// Token: 0x06002F4C RID: 12108 RVA: 0x000D9CF0 File Offset: 0x000D7EF0
	public bool method_11(int int_0)
	{
		HUDPvPKillStampView.KillStampInfo[] array = this.m_killstampInfoHistoryQueue.ToArray();
		return int_0 < array.Length;
	}

	// Token: 0x04002106 RID: 8454
	private const float m_KillStampDurationInSec = 5f;

	// Token: 0x04002107 RID: 8455
	public int m_nMaxHistoryCount = 4;

	// Token: 0x04002108 RID: 8456
	public int m_nNewStampCount;

	// Token: 0x04002109 RID: 8457
	public string[] m_KillingStampName = new string[]
	{
		"BasicSuicide", "BasicAssist", "BonusHeadShot", "BonusCritical", "BonusMelee", "BonusKillStreak", "BonusFirstBlood", "BonusLastKill", "BonusRevenge", "BonusTurretKill",
		"BonusFirebirdKill", "BonusPunchKill", "BonusMarkedKill", "BonusGrenadesKill", "BonusFirstBullet", "BonusFirstScore", "BonusNaturalbornKiller", "BonusOneManArmy", "BonusOneStoneTwoBird", "BonusTripleKilling",
		"BonusGenocide", "BonusPayback", "BonusAvenger", "BonusBucher", "BonusBushido", "BonusShotPutter", "BonusCatapult", "BonusSharpShooter", "BonusHeadHunter", "BonusRoadtoHell",
		"BonusShameless", "BonusGiveAndTake", "BonusResuscitation", "BonusAssassin", "BonusArchNemesis", "BonusEagleEye", "BonusLoveShot", "BonusCamper", "BonusAirBourne", "BonusLongevity",
		"BonusBackStabbing", "BonusAFK", "BonusBloodlessVictory", "BonusDeliveryMan", "BonusBigBang", "BonusWrongAddress", "BonusAssassination"
	};

	// Token: 0x0400210A RID: 8458
	protected Queue<HUDPvPKillStampView.KillStampInfo> m_killstampInfoHistoryQueue = new Queue<HUDPvPKillStampView.KillStampInfo>();

	// Token: 0x0400210B RID: 8459
	protected Queue<ScoringActionType> m_killstampInfoQueue = new Queue<ScoringActionType>();

	// Token: 0x02000700 RID: 1792
	public class KillStampInfo
	{
		// Token: 0x0400210C RID: 8460
		public bool bDisplayed;

		// Token: 0x0400210D RID: 8461
		public float fTimeLeft;

		// Token: 0x0400210E RID: 8462
		public ScoringActionType ScoringType;
	}
}
