using System;
using System.Collections.Generic;
using ns0;

// Token: 0x020006B4 RID: 1716
public class HUDVictoryCondition : BaseView
{
	// Token: 0x06002D2F RID: 11567 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_0()
	{
		return true;
	}

	// Token: 0x06002D30 RID: 11568 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnTestGUI()
	{
	}

	// Token: 0x06002D31 RID: 11569 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(bool bool_0)
	{
	}

	// Token: 0x06002D32 RID: 11570 RVA: 0x000D44C0 File Offset: 0x000D26C0
	public virtual void vmethod_6(int int_0, StatisticsManager.StatSheet statSheet_0 = null)
	{
		int num = int_0 / 60;
		int num2 = int_0 % 60;
		this.m_bNewPhaseActived = false;
		if (this.m_currentStatus == HUDVictoryCondition.eTimeStatus.over && (num != 0 || num2 != 0))
		{
			this.m_bNewPhaseActived = true;
			this.m_currentStatus = HUDVictoryCondition.eTimeStatus.none;
		}
		if (num2 > 20 && this.m_currentStatus != HUDVictoryCondition.eTimeStatus.normal && this.m_currentStatus != HUDVictoryCondition.eTimeStatus.over)
		{
			this.m_currentStatus = HUDVictoryCondition.eTimeStatus.normal;
			this.m_bNewPhaseActived = true;
		}
		else if (num2 < 20 && num == 0 && this.m_currentStatus != HUDVictoryCondition.eTimeStatus.last20sec && this.m_currentStatus != HUDVictoryCondition.eTimeStatus.over)
		{
			this.m_currentStatus = HUDVictoryCondition.eTimeStatus.last20sec;
			this.m_bNewPhaseActived = true;
		}
		else if (num == 0 && num2 == 0 && this.m_currentStatus != HUDVictoryCondition.eTimeStatus.over)
		{
			this.m_currentStatus = HUDVictoryCondition.eTimeStatus.over;
			this.m_bNewPhaseActived = true;
		}
	}

	// Token: 0x06002D33 RID: 11571 RVA: 0x000D456C File Offset: 0x000D276C
	protected StatisticsManager.StatSheet method_3()
	{
		StatisticsManager.StatSheet statSheet = null;
		int num = 0;
		int num2 = MonoSingleton<ScoringManager>.Instance.method_8();
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(list[i]);
			if (personalStatSheet != null && personalStatSheet.m_score == num2)
			{
				statSheet = personalStatSheet;
				num++;
				if (num >= 2)
				{
					statSheet = null;
					return statSheet;
				}
			}
		}
		return statSheet;
	}

	// Token: 0x04001FBD RID: 8125
	protected HUDVictoryCondition.eTimeStatus m_currentStatus;

	// Token: 0x04001FBE RID: 8126
	protected bool m_bNewPhaseActived;

	// Token: 0x020006B5 RID: 1717
	public enum eTimeStatus
	{
		// Token: 0x04001FC0 RID: 8128
		none,
		// Token: 0x04001FC1 RID: 8129
		normal,
		// Token: 0x04001FC2 RID: 8130
		last20sec,
		// Token: 0x04001FC3 RID: 8131
		over
	}
}
