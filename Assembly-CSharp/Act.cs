using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020004CB RID: 1227
public class Act : MonoBehaviour
{
	// Token: 0x06002122 RID: 8482 RVA: 0x000A07F8 File Offset: 0x0009E9F8
	private void Start()
	{
		MatchmakingService matchmakingService = ((!(MonoSingleton<AppManager>.Instance != null)) ? null : MonoSingleton<AppManager>.Instance.GetComponent<MatchmakingService>());
		if (matchmakingService != null)
		{
			ELevelDifficulty elevelDifficulty = MonoSingleton<AppManager>.Instance.m_difficulty;
			if (MonoSingleton<AppManager>.Instance.m_offlineMode)
			{
				elevelDifficulty = this.m_difficulty;
				MonoSingleton<AppManager>.Instance.m_difficulty = this.m_difficulty;
			}
			this.m_level = matchmakingService.method_0();
			switch (elevelDifficulty)
			{
			default:
				this.m_level_Min = this.m_level.m_normal_LevelMin;
				this.m_level_Max = this.m_level.m_normal_LevelMax;
				break;
			case ELevelDifficulty.Hard:
				this.m_level_Min = this.m_level.m_hard_LevelMin;
				this.m_level_Max = this.m_level.m_hard_LevelMax;
				break;
			case ELevelDifficulty.Hell:
				this.m_level_Min = this.m_level.m_hell_LevelMin;
				this.m_level_Max = this.m_level.m_hell_LevelMax;
				break;
			}
		}
		this.m_allScenes = base.gameObject.GetComponentsInChildren<Scene>(true);
		if (this.m_level_Min < 1)
		{
			this.m_level_Min = 1;
		}
		if (this.m_level_Max < this.m_level_Min)
		{
			this.m_level_Max = this.m_level_Min;
		}
	}

	// Token: 0x06002123 RID: 8483 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x000A0920 File Offset: 0x0009EB20
	private void OnDestroy()
	{
		List<ClusterAction> list = new List<ClusterAction>();
		List<ClusterCondition> list2 = new List<ClusterCondition>();
		for (int i = 0; i < this.m_allScenes.Length; i++)
		{
			list.AddRange(this.m_allScenes[i].m_completionActions);
			list.AddRange(this.m_allScenes[i].m_onActiveActions);
			list2.AddRange(this.m_allScenes[i].m_clusterConditions);
			try
			{
				global::UnityEngine.Object.DestroyImmediate(this.m_allScenes[i].gameObject);
			}
			catch (Exception ex)
			{
				DebugUtils.LogError(LogCategory.Gamelogic, "Act destory gameobject Excepetion:" + ex.Message);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			global::UnityEngine.Object.DestroyImmediate(list[j]);
		}
		for (int k = 0; k < list2.Count; k++)
		{
			global::UnityEngine.Object.DestroyImmediate(list2[k]);
		}
	}

	// Token: 0x040015A1 RID: 5537
	public string m_modeType = "GamemodePvE";

	// Token: 0x040015A2 RID: 5538
	public int m_level_Min = 1;

	// Token: 0x040015A3 RID: 5539
	public int m_level_Max = 1;

	// Token: 0x040015A4 RID: 5540
	protected bool m_bLevelSetuped;

	// Token: 0x040015A5 RID: 5541
	protected Playlist m_level;

	// Token: 0x040015A6 RID: 5542
	private Scene[] m_allScenes;

	// Token: 0x040015A7 RID: 5543
	public ELevelDifficulty m_difficulty;
}
