using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x02000530 RID: 1328
public class InstanceMapSelectControl
{
	// Token: 0x06002221 RID: 8737 RVA: 0x00017827 File Offset: 0x00015A27
	public static void smethod_0()
	{
		InstanceMapSelectControl.m_nCurrentTown = MonoSingleton<AppManager>.Instance.m_playlistId;
	}

	// Token: 0x06002222 RID: 8738 RVA: 0x00017838 File Offset: 0x00015A38
	public static void smethod_1(int int_0)
	{
		InstanceMapSelectControl.m_nCurrentTown = int_0;
	}

	// Token: 0x06002223 RID: 8739 RVA: 0x00017840 File Offset: 0x00015A40
	public static int smethod_2()
	{
		return InstanceMapSelectControl.m_nCurrentTown;
	}

	// Token: 0x06002224 RID: 8740 RVA: 0x000A28B4 File Offset: 0x000A0AB4
	public static bool smethod_3(int int_0)
	{
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(int_0);
		if (playlist == null)
		{
			DebugUtils.Log(LogCategory.Network, "Trying to enter Playlist [" + int_0.ToString() + "]");
			return false;
		}
		return playlist.m_bossName != string.Empty;
	}

	// Token: 0x06002225 RID: 8741 RVA: 0x000A2900 File Offset: 0x000A0B00
	public static string smethod_4(int int_0)
	{
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(int_0);
		if (playlist == null)
		{
			DebugUtils.Log(LogCategory.Network, "Trying to enter Playlist [" + int_0.ToString() + "]");
			return string.Empty;
		}
		return playlist.m_bossName;
	}

	// Token: 0x06002226 RID: 8742 RVA: 0x000A2948 File Offset: 0x000A0B48
	public static void smethod_5(int int_0, int int_1)
	{
		if (InstanceMapSelectControl.m_TownInstanceMap.ContainsKey(int_0))
		{
			if (!InstanceMapSelectControl.m_TownInstanceMap[int_0].Contains(int_1))
			{
				InstanceMapSelectControl.m_TownInstanceMap[int_0].Add(int_1);
			}
		}
		else
		{
			List<int> list = new List<int>();
			list.Clear();
			list.Add(int_1);
			InstanceMapSelectControl.m_TownInstanceMap.Add(int_0, list);
		}
	}

	// Token: 0x06002227 RID: 8743 RVA: 0x000A29A8 File Offset: 0x000A0BA8
	public static bool smethod_6(int int_0)
	{
		bool flag = false;
		List<int> list = InstanceMapSelectControl.smethod_7(int_0);
		Dictionary<int, QuestProgress> dictionary = QuestUIDataManager.smethod_0().method_7();
		foreach (QuestProgress questProgress in dictionary.Values)
		{
			if (questProgress.mStatus == QuestState.InProgress)
			{
				Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(questProgress.mQuestId);
				if (quest != null)
				{
					if (quest.mIsBoundInstance)
					{
						if (list != null)
						{
							foreach (int num in quest.mBoundInstanceList)
							{
								if (list.Contains(num))
								{
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							continue;
						}
					}
					else
					{
						flag = true;
					}
					break;
				}
			}
		}
		return flag;
	}

	// Token: 0x06002228 RID: 8744 RVA: 0x00017847 File Offset: 0x00015A47
	public static List<int> smethod_7(int int_0)
	{
		if (InstanceMapSelectControl.m_TownInstanceMap.ContainsKey(int_0))
		{
			return InstanceMapSelectControl.m_TownInstanceMap[int_0];
		}
		return null;
	}

	// Token: 0x040016C9 RID: 5833
	protected static int m_nCurrentTown = 3;

	// Token: 0x040016CA RID: 5834
	protected static Dictionary<int, List<int>> m_TownInstanceMap = new Dictionary<int, List<int>>();
}
