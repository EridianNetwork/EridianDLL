using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000663 RID: 1635
public class AchievementManager : IAchievementServiceNotificationListerner
{
	// Token: 0x06002926 RID: 10534 RVA: 0x000C2348 File Offset: 0x000C0548
	private AchievementManager()
	{
	}

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x06002927 RID: 10535 RVA: 0x0001B00D File Offset: 0x0001920D
	public static AchievementManager AchievementManager_0
	{
		get
		{
			if (AchievementManager._instance == null)
			{
				AchievementManager._instance = new AchievementManager();
			}
			return AchievementManager._instance;
		}
	}

	// Token: 0x06002928 RID: 10536 RVA: 0x000C23A8 File Offset: 0x000C05A8
	public void method_0()
	{
		if (!this._bInited)
		{
			ServiceWrapperBase<AchievementServiceWrapper>.Instance.method_0(AchievementManager._instance);
			int num = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementTable.Length;
			for (int i = 0; i < num; i++)
			{
				AchievementData achievementData = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementTable[i];
				foreach (AchievementStageData achievementStageData in achievementData.m_achievementStages)
				{
					string text = this.method_1(achievementData.m_achievementId, achievementStageData.m_stageId);
					this._dictStageData[text] = achievementStageData;
				}
			}
		}
		this._bInited = true;
	}

	// Token: 0x06002929 RID: 10537 RVA: 0x000C244C File Offset: 0x000C064C
	private string method_1(int int_0, int int_1)
	{
		string text = ((int_0 >= 10) ? int_0.ToString() : ("0" + int_0));
		string text2 = ((int_1 >= 10) ? int_1.ToString() : ("0" + int_1));
		return text + text2;
	}

	// Token: 0x0600292A RID: 10538 RVA: 0x0001B025 File Offset: 0x00019225
	public void method_2()
	{
		ServiceWrapperBase<AchievementServiceWrapper>.Instance.method_1(AchievementManager._instance);
		this._bInited = false;
	}

	// Token: 0x0600292B RID: 10539 RVA: 0x000C24A0 File Offset: 0x000C06A0
	public void OnAchievementUpdated(Achievement newAchievement)
	{
		if (newAchievement != null)
		{
			int i = 0;
			int count = this._listItemData.Count;
			while (i < count)
			{
				UIAchievementItemData uiachievementItemData = this._listItemData[i];
				if (uiachievementItemData.Achievement_0.type == newAchievement.type && uiachievementItemData.Achievement_0.stage == newAchievement.stage)
				{
					bool isAccomplished = uiachievementItemData.isAccomplished;
					uiachievementItemData.Achievement_0 = newAchievement;
					if (uiachievementItemData.isAccomplished)
					{
						this._levelData.Int32_0 = this.method_3();
						if (!isAccomplished && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>().Boolean_0)
						{
							MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>().vmethod_5(uiachievementItemData);
						}
					}
					return;
				}
				i++;
			}
			UIAchievementItemData uiachievementItemData2 = new UIAchievementItemData();
			uiachievementItemData2.Achievement_0 = newAchievement;
			this._listItemData.Add(uiachievementItemData2);
			if (uiachievementItemData2.isAccomplished)
			{
				this._levelData.Int32_0 = this.method_3();
				if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>().Boolean_0)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>().vmethod_5(uiachievementItemData2);
				}
				else
				{
					AchievementManager.AchievementManager_0.method_10(uiachievementItemData2);
				}
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementBoardView>().Boolean_1)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementBoardView>().vmethod_5();
			}
			else if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_1)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_16();
			}
			else
			{
				AchievementManager.AchievementManager_0.bNewAchievementUnread = true;
			}
			this.method_7();
		}
	}

	// Token: 0x0600292C RID: 10540 RVA: 0x000C2634 File Offset: 0x000C0834
	protected void OnGetAchievements(int id, global::Achievements achievements)
	{
		this._achievements = achievements;
		this._listItemData.Clear();
		if (this._achievements == null)
		{
			return;
		}
		foreach (int num in this._achievements.Dictionary_0.Keys)
		{
			Achievement achievement = this._achievements.Dictionary_0[num];
			UIAchievementItemData uiachievementItemData = new UIAchievementItemData();
			uiachievementItemData.key = num;
			uiachievementItemData.Achievement_0 = achievement;
			if (uiachievementItemData.AchievementStageData_0 != null)
			{
				this._listItemData.Add(uiachievementItemData);
			}
		}
		this._levelData.Int32_0 = this.method_3();
		this.method_7();
	}

	// Token: 0x0600292D RID: 10541 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_0(Achievement achievement_0)
	{
	}

	// Token: 0x0600292E RID: 10542 RVA: 0x000C26F8 File Offset: 0x000C08F8
	protected int method_3()
	{
		int num = 0;
		int i = 0;
		int count = this._listItemData.Count;
		while (i < count)
		{
			if (this._listItemData[i].isAccomplished)
			{
				num += this._listItemData[i].rewardPoint;
			}
			i++;
		}
		return num;
	}

	// Token: 0x0600292F RID: 10543 RVA: 0x000C2748 File Offset: 0x000C0948
	public void method_4()
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			return;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		int characterId = localPlayer.m_characterId;
		if (ServiceWrapperBase<AchievementServiceWrapper>.Instance == null)
		{
			return;
		}
		ServiceWrapperBase<AchievementServiceWrapper>.Instance.method_2(new GetAchievementsCallback(this.OnGetAchievements), characterId);
	}

	// Token: 0x06002930 RID: 10544 RVA: 0x000C27A0 File Offset: 0x000C09A0
	public AchievementStageData method_5(Achievement achievement_0)
	{
		string text = this.method_1(achievement_0.type, achievement_0.stage);
		AchievementStageData achievementStageData = null;
		if (this._dictStageData.TryGetValue(text, out achievementStageData))
		{
			return achievementStageData;
		}
		return null;
	}

	// Token: 0x06002931 RID: 10545 RVA: 0x0001B03D File Offset: 0x0001923D
	public List<UIAchievementItemData> method_6()
	{
		return this._listItemData;
	}

	// Token: 0x06002932 RID: 10546 RVA: 0x000C27D8 File Offset: 0x000C09D8
	private void method_7()
	{
		IEnumerable<UIAchievementItemData> enumerable = this._listItemData.OrderBy<UIAchievementItemData, bool>(new Func<UIAchievementItemData, bool>(AchievementManager.smethod_0));
		this._listItemData = enumerable.ToList<UIAchievementItemData>();
	}

	// Token: 0x06002933 RID: 10547 RVA: 0x0001B045 File Offset: 0x00019245
	public UIAchievementLevelData method_8()
	{
		return this._levelData;
	}

	// Token: 0x06002934 RID: 10548 RVA: 0x0001B04D File Offset: 0x0001924D
	public string method_9(int int_0)
	{
		return Utility.smethod_5(this.ICON_NAME_PREFIX, Utility.smethod_8(int_0));
	}

	// Token: 0x06002935 RID: 10549 RVA: 0x0001B060 File Offset: 0x00019260
	public void method_10(UIAchievementItemData uiachievementItemData_0)
	{
		if (this._queueCachedAchievement.Contains(uiachievementItemData_0))
		{
			return;
		}
		this._queueCachedAchievement.Enqueue(uiachievementItemData_0);
	}

	// Token: 0x06002936 RID: 10550 RVA: 0x000C281C File Offset: 0x000C0A1C
	public void method_11()
	{
		while (this._queueCachedAchievement.Count > 0)
		{
			UIAchievementItemData uiachievementItemData = this._queueCachedAchievement.Dequeue();
			if (uiachievementItemData == null)
			{
				return;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>().vmethod_5(uiachievementItemData);
		}
	}

	// Token: 0x06002937 RID: 10551 RVA: 0x000C2860 File Offset: 0x000C0A60
	public List<UIAchievementItemData> method_12()
	{
		List<UIAchievementItemData> list = new List<UIAchievementItemData>();
		int num = 2;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			AchievementData achievementData = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementTable[i];
			foreach (AchievementStageData achievementStageData in achievementData.m_achievementStages)
			{
				UIAchievementItemData uiachievementItemData = new UIAchievementItemData();
				Hashtable hashtable = new Hashtable();
				hashtable[0] = achievementData.m_achievementId;
				hashtable[1] = global::UnityEngine.Random.Range(1, 4);
				hashtable[2] = 1;
				hashtable[3] = 0;
				uiachievementItemData.Achievement_0 = new Achievement(hashtable);
				uiachievementItemData.AchievementStageData_0 = achievementStageData;
				if (uiachievementItemData.isAccomplished)
				{
					num2 += uiachievementItemData.rewardPoint;
				}
				list.Add(uiachievementItemData);
			}
		}
		this._levelData.Int32_0 = num2;
		return list;
	}

	// Token: 0x06002938 RID: 10552 RVA: 0x000C296C File Offset: 0x000C0B6C
	public UIAchievementLevelData method_13()
	{
		UIAchievementLevelData uiachievementLevelData = new UIAchievementLevelData();
		uiachievementLevelData.data = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementLevelTable[0];
		uiachievementLevelData.nextLevelData = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementLevelTable[1];
		uiachievementLevelData.Int32_0 = uiachievementLevelData.data.m_levelMinPoint;
		return uiachievementLevelData;
	}

	// Token: 0x06002939 RID: 10553 RVA: 0x0001B07D File Offset: 0x0001927D
	[CompilerGenerated]
	private static bool smethod_0(UIAchievementItemData uiachievementItemData_0)
	{
		return uiachievementItemData_0.isAccomplished;
	}

	// Token: 0x04001D7A RID: 7546
	private static AchievementManager _instance;

	// Token: 0x04001D7B RID: 7547
	private global::Achievements _achievements;

	// Token: 0x04001D7C RID: 7548
	private Dictionary<string, AchievementStageData> _dictStageData = new Dictionary<string, AchievementStageData>();

	// Token: 0x04001D7D RID: 7549
	private bool _bInited;

	// Token: 0x04001D7E RID: 7550
	private List<UIAchievementItemData> _listItemData = new List<UIAchievementItemData>();

	// Token: 0x04001D7F RID: 7551
	private UIAchievementLevelData _levelData = new UIAchievementLevelData();

	// Token: 0x04001D80 RID: 7552
	private Queue<UIAchievementItemData> _queueCachedAchievement = new Queue<UIAchievementItemData>();

	// Token: 0x04001D81 RID: 7553
	public bool bNewAchievementUnread;

	// Token: 0x04001D82 RID: 7554
	public string ICON_NAME_PREFIX = "Type";

	// Token: 0x04001D83 RID: 7555
	public string ICON_NAME_FIX_NULL = "Type0";

	// Token: 0x04001D84 RID: 7556
	public string ICON_BG_NAME = "Mc_VHP_BG";
}
