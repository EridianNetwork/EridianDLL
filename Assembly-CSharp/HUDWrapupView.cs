using System;
using Core;
using ns0;
using XsdSettings;

// Token: 0x02000708 RID: 1800
public class HUDWrapupView : BaseView
{
	// Token: 0x06002F86 RID: 12166 RVA: 0x0001F3AE File Offset: 0x0001D5AE
	public HUDWrapupView()
	{
		this.m_Name = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9();
	}

	// Token: 0x06002F87 RID: 12167 RVA: 0x0001D50E File Offset: 0x0001B70E
	public override bool vmethod_4()
	{
		return this._bVisible;
	}

	// Token: 0x06002F88 RID: 12168 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5()
	{
	}

	// Token: 0x06002F89 RID: 12169 RVA: 0x000D9FA0 File Offset: 0x000D81A0
	public virtual void vmethod_6()
	{
		IClientSession clientSession = MonoSingleton<Session>.Instance.method_25();
		if (clientSession != null)
		{
			clientSession.imethod_0();
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(true);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_10();
		StatisticsManager.SessionStats sessionStats = MonoSingleton<StatisticsManager>.Instance.method_5();
		StatisticsManager.StatSheet[] array = sessionStats.m_statsSheets.ToArray();
		this.m_Difficulty = sessionStats.m_difficulty;
		this.m_LevelName = LocalizedString.smethod_0(new LocalizedString(sessionStats.m_instanceName));
		this.m_Time = sessionStats.m_duration;
		DebugUtils.Log(LogCategory.GUI, string.Concat(new string[]
		{
			"WRAPUP DEBUG: my m_Name='",
			this.m_Name,
			"' sheets=",
			array.Length.ToString(),
			" duration=",
			sessionStats.m_duration.ToString()
		}));
		for (int i = 0; i < array.Length; i++)
		{
			DebugUtils.Log(LogCategory.GUI, string.Concat(new string[]
			{
				"WRAPUP DEBUG: sheet[",
				i.ToString(),
				"] name='",
				array[i].m_name,
				"' kills=",
				array[i].m_killCount.ToString(),
				" dmg=",
				array[i].m_totalDamage.ToString(),
				" matches=",
				(array[i].m_name == this.m_Name).ToString()
			}));
			if (array[i].m_name == this.m_Name)
			{
				this.m_Killed = array[i].m_badassKill + array[i].m_bossKill;
				if (array[i].m_hitNumber != 0)
				{
					this.m_Detail = (float)Math.Round((double)((float)array[i].m_criticalHitNumber / (float)array[i].m_hitNumber * 100f));
				}
				else
				{
					this.m_Detail = 0f;
				}
				this.m_Hurt = array[i].m_totalDamage;
				this.m_ExpGained = array[i].m_extraExp;
				this.m_instanceGrade = array[i].method_0(sessionStats);
				this.m_Money = array[i].m_extraMoney;
				this.m_GuildExp = array[i].m_guildExp;
				if (!GuildManager.smethod_0().method_7())
				{
					this.m_GuildExp = 0;
				}
			}
		}
	}

	// Token: 0x04002126 RID: 8486
	protected string m_LevelName = string.Empty;

	// Token: 0x04002127 RID: 8487
	protected string m_Name = string.Empty;

	// Token: 0x04002128 RID: 8488
	protected int m_Killed;

	// Token: 0x04002129 RID: 8489
	protected float m_Detail;

	// Token: 0x0400212A RID: 8490
	protected ELevelDifficulty m_Difficulty;

	// Token: 0x0400212B RID: 8491
	protected int m_Hurt;

	// Token: 0x0400212C RID: 8492
	protected int m_ExpGained;

	// Token: 0x0400212D RID: 8493
	protected int m_Money;

	// Token: 0x0400212E RID: 8494
	protected float m_Time;

	// Token: 0x0400212F RID: 8495
	protected int m_GuildExp;

	// Token: 0x04002130 RID: 8496
	public InstanceGrade m_instanceGrade = InstanceGrade.D;
}
