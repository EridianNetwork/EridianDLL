using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020003F7 RID: 1015
public abstract class GeneralScoringRule : ScoringRule
{
	// Token: 0x0600199C RID: 6556 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnDamagedPreStat(DamageContext context)
	{
	}

	// Token: 0x0600199D RID: 6557 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnDamagedPostStat(DamageContext context)
	{
	}

	// Token: 0x0600199E RID: 6558 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnEntityKillPreStat(KillContext context)
	{
	}

	// Token: 0x0600199F RID: 6559 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnEntityKillPostStat(KillContext context)
	{
	}

	// Token: 0x060019A0 RID: 6560 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPickedUp(EntityPlayer picker, EntityObject item)
	{
	}

	// Token: 0x060019A1 RID: 6561 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int imethod_1(ScoringActionType scoringActionType_0, Entity entity_0, Entity entity_1)
	{
		return 0;
	}

	// Token: 0x060019A2 RID: 6562 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void imethod_2(int int_0)
	{
	}

	// Token: 0x060019A3 RID: 6563 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void imethod_3(Entity entity_0)
	{
	}

	// Token: 0x060019A4 RID: 6564 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnUpdateMatch()
	{
	}

	// Token: 0x060019A5 RID: 6565 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnEndMatch()
	{
	}

	// Token: 0x060019A6 RID: 6566 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int imethod_5(EntityNpc.EntityNpcRank entityNpcRank_0)
	{
		return 0;
	}

	// Token: 0x060019A7 RID: 6567 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void imethod_6(StatisticsManager.SessionStats sessionStats_0)
	{
	}

	// Token: 0x060019A8 RID: 6568 RVA: 0x0001311F File Offset: 0x0001131F
	public virtual InstanceGrade imethod_4(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0)
	{
		return InstanceGrade.F;
	}

	// Token: 0x060019A9 RID: 6569 RVA: 0x00085BCC File Offset: 0x00083DCC
	public virtual void imethod_0()
	{
		if (this.m_scoringSettings.Length == 0)
		{
			return;
		}
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0(this.m_scoringSettings);
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScoringSetup));
			this.m_scoreSetup = xmlSerializer.Deserialize(stringReader) as ScoringSetup;
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x060019AA RID: 6570 RVA: 0x00085C48 File Offset: 0x00083E48
	protected void method_0(StatisticsManager.SessionStats sessionStats_0)
	{
		if (sessionStats_0 == null)
		{
			return;
		}
		ScoringBase scoringBase = this.m_scoreSetup.m_ScoringSetup as ScoringBase;
		if (scoringBase != null)
		{
			List<PlayerInfoSync> list;
			MonoSingleton<Session>.Instance.method_38(out list);
			float num = sessionStats_0.m_duration;
			if (num > 2700f)
			{
				num = 2700f;
			}
			int num2 = 1;
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(sessionStats_0.m_playlistId);
			switch (sessionStats_0.m_difficulty)
			{
			case ELevelDifficulty.Normal:
				num2 = playlist.m_normal_LevelMin;
				break;
			case ELevelDifficulty.Hard:
				num2 = playlist.m_hard_LevelMin;
				break;
			case ELevelDifficulty.Hell:
				num2 = playlist.m_hell_LevelMin;
				break;
			}
			for (int i = 0; i < list.Count; i++)
			{
				StatisticsManager.StatSheet personalStatSheet = sessionStats_0.GetPersonalStatSheet(list[i]);
				if (!personalStatSheet.m_isFail && !MonoSingleton<Session>.Instance.method_13())
				{
					float num3 = num * scoringBase.m_moneyStandardReward * this.method_1(Mathf.Min(personalStatSheet.m_level, num2), true) * scoringBase.m_modeModifierSoftCurrency * scoringBase.m_winBonusSoftCurrency * this.vmethod_0(sessionStats_0, personalStatSheet, true);
					personalStatSheet.m_extraMoney = (int)(num3 * AntiAddiction.smethod_0(list[i].m_antiAddictionLevel));
				}
			}
		}
	}

	// Token: 0x060019AB RID: 6571 RVA: 0x00013122 File Offset: 0x00011322
	protected virtual float vmethod_0(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0, bool bool_0)
	{
		return 1f;
	}

	// Token: 0x060019AC RID: 6572 RVA: 0x00085D74 File Offset: 0x00083F74
	protected float method_1(int int_0, bool bool_0)
	{
		ScoringBase scoringBase = this.m_scoreSetup.m_ScoringSetup as ScoringBase;
		if (scoringBase == null)
		{
			return 1f;
		}
		float[] array = ((!bool_0) ? scoringBase.m_expRewardRatePerLevel : scoringBase.m_moneyRewardRatePerLevel);
		if (int_0 >= 1 && int_0 <= array.Length)
		{
			return array[int_0 - 1];
		}
		return 1f;
	}

	// Token: 0x0400113F RID: 4415
	private const float maxScoringDuration = 2700f;

	// Token: 0x04001140 RID: 4416
	protected ScoringSetup m_scoreSetup;

	// Token: 0x04001141 RID: 4417
	protected string m_scoringSettings = string.Empty;
}
