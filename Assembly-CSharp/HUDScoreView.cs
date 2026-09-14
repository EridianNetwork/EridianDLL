using System;
using System.Collections.Generic;
using ns0;

// Token: 0x02000701 RID: 1793
public class HUDScoreView : BaseView
{
	// Token: 0x06002F4F RID: 12111 RVA: 0x0001F1A0 File Offset: 0x0001D3A0
	public virtual void vmethod_5(bool bool_0)
	{
		this.m_bScoreBoardVisible = bool_0;
	}

	// Token: 0x06002F50 RID: 12112 RVA: 0x000D9D14 File Offset: 0x000D7F14
	public virtual void vmethod_6(StatisticsManager.StatSheet[] statSheet_0)
	{
		this.m_scoreCardList.Clear();
		foreach (StatisticsManager.StatSheet statSheet in statSheet_0)
		{
			if (statSheet.m_name != null)
			{
				this.m_scoreCardList.Add(statSheet);
			}
		}
		this.m_scoreCardList.Sort(new Comparison<StatisticsManager.StatSheet>(this.method_3));
	}

	// Token: 0x06002F51 RID: 12113 RVA: 0x0001F1A9 File Offset: 0x0001D3A9
	protected int method_3(StatisticsManager.StatSheet statSheet_0, StatisticsManager.StatSheet statSheet_1)
	{
		return -(statSheet_0.m_score - statSheet_1.m_score);
	}

	// Token: 0x06002F52 RID: 12114 RVA: 0x0001F1B9 File Offset: 0x0001D3B9
	public virtual void vmethod_7(StatisticsManager.StatSheet[] statSheet_0)
	{
		MonoSingleton<AppManager>.Instance.method_0().method_15(true, base.String_0);
	}

	// Token: 0x06002F53 RID: 12115 RVA: 0x0001F1D1 File Offset: 0x0001D3D1
	protected void method_4()
	{
		MonoSingleton<GameFlowManager>.Instance.method_11();
	}

	// Token: 0x0400210F RID: 8463
	protected bool m_bScoreBoardVisible;

	// Token: 0x04002110 RID: 8464
	protected List<StatisticsManager.StatSheet> m_scoreCardList = new List<StatisticsManager.StatSheet>();
}
