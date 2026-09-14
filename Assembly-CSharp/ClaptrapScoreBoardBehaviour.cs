using System;
using ns0;
using UnityEngine;

// Token: 0x02000686 RID: 1670
public class ClaptrapScoreBoardBehaviour : MonoBehaviour
{
	// Token: 0x06002B30 RID: 11056 RVA: 0x000C9AD4 File Offset: 0x000C7CD4
	private void Update()
	{
		if (MonoSingleton<StatisticsManager>.Instance == null)
		{
			return;
		}
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		if (currentSession == null)
		{
			return;
		}
		StatisticsManager.StatSheet statSheet = currentSession.method_9((int)this.enemyTeamID);
		if (statSheet == null)
		{
			return;
		}
		this.method_0();
		if (this.unitDigits.Length == 10)
		{
			this.unitDigits[statSheet.m_score % 10].SetActive(true);
		}
		if (this.tensDigits.Length == 10)
		{
			this.tensDigits[statSheet.m_score / 10].SetActive(true);
		}
	}

	// Token: 0x06002B31 RID: 11057 RVA: 0x000C9B5C File Offset: 0x000C7D5C
	private void method_0()
	{
		for (int i = 0; i < this.unitDigits.Length; i++)
		{
			this.unitDigits[i].SetActive(false);
		}
		for (int j = 0; j < this.tensDigits.Length; j++)
		{
			this.tensDigits[j].SetActive(false);
		}
	}

	// Token: 0x04001E61 RID: 7777
	public GameObject[] unitDigits;

	// Token: 0x04001E62 RID: 7778
	public GameObject[] tensDigits;

	// Token: 0x04001E63 RID: 7779
	public ClaptrapScoreBoardBehaviour.TeamID enemyTeamID = ClaptrapScoreBoardBehaviour.TeamID.TeamA;

	// Token: 0x02000687 RID: 1671
	public enum TeamID
	{
		// Token: 0x04001E65 RID: 7781
		TeamA = 1,
		// Token: 0x04001E66 RID: 7782
		TeamB
	}
}
