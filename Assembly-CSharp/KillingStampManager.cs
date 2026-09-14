using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x0200067D RID: 1661
public class KillingStampManager
{
	// Token: 0x06002A8F RID: 10895 RVA: 0x0001C16F File Offset: 0x0001A36F
	private KillingStampManager()
	{
		this.m_KillingStampList = new List<ScoringActionType>();
		this.m_KillingStampList.Clear();
	}

	// Token: 0x06002A90 RID: 10896 RVA: 0x0001C18D File Offset: 0x0001A38D
	public static KillingStampManager smethod_0()
	{
		if (KillingStampManager._KillingStampManager == null)
		{
			KillingStampManager._KillingStampManager = new KillingStampManager();
		}
		return KillingStampManager._KillingStampManager;
	}

	// Token: 0x06002A91 RID: 10897 RVA: 0x0001C1A5 File Offset: 0x0001A3A5
	public void method_0()
	{
		this.m_KillingStampList.Clear();
	}

	// Token: 0x06002A92 RID: 10898 RVA: 0x0001C1B2 File Offset: 0x0001A3B2
	public void method_1(ScoringActionType scoringActionType_0)
	{
		if (!this.m_KillingStampList.Contains(scoringActionType_0))
		{
			this.m_KillingStampList.Add(scoringActionType_0);
		}
	}

	// Token: 0x06002A93 RID: 10899 RVA: 0x0001C1CE File Offset: 0x0001A3CE
	public int method_2()
	{
		return this.m_KillingStampList.Count;
	}

	// Token: 0x06002A94 RID: 10900 RVA: 0x0001C1DB File Offset: 0x0001A3DB
	public ScoringActionType method_3(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_KillingStampList.Count)
		{
			return this.m_KillingStampList[int_0];
		}
		return ScoringActionType.BasicKill;
	}

	// Token: 0x06002A95 RID: 10901 RVA: 0x000C7438 File Offset: 0x000C5638
	public void method_4()
	{
		this.m_KillingStampList.Clear();
		this.m_KillingStampList.Add(ScoringActionType.BasicAssist);
		this.m_KillingStampList.Add(ScoringActionType.BasicSuicide);
		this.m_KillingStampList.Add(ScoringActionType.BonusFirebirdKill);
		this.m_KillingStampList.Add(ScoringActionType.BonusHeadShot);
		this.m_KillingStampList.Add(ScoringActionType.BonusRevenge);
		this.m_KillingStampList.Add(ScoringActionType.BonusLastKill);
		this.m_KillingStampList.Add(ScoringActionType.BonusTurretKill);
		this.m_KillingStampList.Add(ScoringActionType.BonusBloodlessVictory);
		this.m_KillingStampList.Add(ScoringActionType.BonusAFK);
		this.m_KillingStampList.Add(ScoringActionType.BonusBackStabbing);
		this.m_KillingStampList.Add(ScoringActionType.BonusLongevity);
		this.m_KillingStampList.Add(ScoringActionType.BonusAirBourne);
		this.m_KillingStampList.Add(ScoringActionType.BonusCamper);
		this.m_KillingStampList.Add(ScoringActionType.BonusLoveShot);
		this.m_KillingStampList.Add(ScoringActionType.BonusEagleEye);
		this.m_KillingStampList.Add(ScoringActionType.BonusArchNemesis);
		this.m_KillingStampList.Add(ScoringActionType.BonusAssassin);
		this.m_KillingStampList.Add(ScoringActionType.BonusResuscitation);
		this.m_KillingStampList.Add(ScoringActionType.BonusGiveAndTake);
		this.m_KillingStampList.Add(ScoringActionType.BonusShameless);
		this.m_KillingStampList.Add(ScoringActionType.BonusRoadtoHell);
	}

	// Token: 0x04001E0D RID: 7693
	protected static KillingStampManager _KillingStampManager;

	// Token: 0x04001E0E RID: 7694
	private List<ScoringActionType> m_KillingStampList;
}
