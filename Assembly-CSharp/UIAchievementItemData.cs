using System;
using System.Runtime.CompilerServices;
using ns0;
using XsdSettings;

// Token: 0x020006E6 RID: 1766
public class UIAchievementItemData
{
	// Token: 0x14000010 RID: 16
	// (add) Token: 0x06002E93 RID: 11923 RVA: 0x0001EC22 File Offset: 0x0001CE22
	// (remove) Token: 0x06002E94 RID: 11924 RVA: 0x0001EC3B File Offset: 0x0001CE3B
	public event UIAchievementItemData.UpdateData Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.OnDataUpdated = (UIAchievementItemData.UpdateData)Delegate.Combine(this.OnDataUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.OnDataUpdated = (UIAchievementItemData.UpdateData)Delegate.Remove(this.OnDataUpdated, value);
		}
	}

	// Token: 0x17000245 RID: 581
	// (get) Token: 0x06002E95 RID: 11925 RVA: 0x0001EC54 File Offset: 0x0001CE54
	// (set) Token: 0x06002E96 RID: 11926 RVA: 0x0001EC5C File Offset: 0x0001CE5C
	public int key { get; set; }

	// Token: 0x17000246 RID: 582
	// (get) Token: 0x06002E97 RID: 11927 RVA: 0x0001EC65 File Offset: 0x0001CE65
	// (set) Token: 0x06002E98 RID: 11928 RVA: 0x0001EC6D File Offset: 0x0001CE6D
	public int goalNumber { get; set; }

	// Token: 0x17000247 RID: 583
	// (get) Token: 0x06002E99 RID: 11929 RVA: 0x0001EC76 File Offset: 0x0001CE76
	// (set) Token: 0x06002E9A RID: 11930 RVA: 0x0001EC7E File Offset: 0x0001CE7E
	public string goalString { get; set; }

	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06002E9B RID: 11931 RVA: 0x0001EC87 File Offset: 0x0001CE87
	// (set) Token: 0x06002E9C RID: 11932 RVA: 0x0001EC8F File Offset: 0x0001CE8F
	public bool isAccomplished { get; private set; }

	// Token: 0x17000249 RID: 585
	// (get) Token: 0x06002E9D RID: 11933 RVA: 0x0001EC98 File Offset: 0x0001CE98
	// (set) Token: 0x06002E9E RID: 11934 RVA: 0x0001ECA0 File Offset: 0x0001CEA0
	public int rewardPoint { get; private set; }

	// Token: 0x1700024A RID: 586
	// (get) Token: 0x06002E9F RID: 11935 RVA: 0x0001ECA9 File Offset: 0x0001CEA9
	// (set) Token: 0x06002EA0 RID: 11936 RVA: 0x0001ECB1 File Offset: 0x0001CEB1
	public int progress { get; set; }

	// Token: 0x1700024B RID: 587
	// (get) Token: 0x06002EA1 RID: 11937 RVA: 0x0001ECBA File Offset: 0x0001CEBA
	// (set) Token: 0x06002EA2 RID: 11938 RVA: 0x0001ECC2 File Offset: 0x0001CEC2
	public string iconName { get; set; }

	// Token: 0x1700024C RID: 588
	// (get) Token: 0x06002EA3 RID: 11939 RVA: 0x0001ECCB File Offset: 0x0001CECB
	// (set) Token: 0x06002EA4 RID: 11940 RVA: 0x0001ECD3 File Offset: 0x0001CED3
	public string iconBGName { get; set; }

	// Token: 0x1700024D RID: 589
	// (get) Token: 0x06002EA5 RID: 11941 RVA: 0x0001ECDC File Offset: 0x0001CEDC
	// (set) Token: 0x06002EA6 RID: 11942 RVA: 0x000D8AB8 File Offset: 0x000D6CB8
	public Achievement Achievement_0
	{
		get
		{
			return this._achievementData;
		}
		set
		{
			if (this._achievementData == value)
			{
				return;
			}
			this._achievementData = value;
			if (this._achievementData != null)
			{
				this.AchievementStageData_0 = AchievementManager.AchievementManager_0.method_5(this._achievementData);
				if (this.AchievementStageData_0 == null)
				{
					return;
				}
				this.isAccomplished = this._achievementData.date > 0;
				this.rewardPoint = this.AchievementStageData_0.m_stageRewardPoint;
				this.progress = this._achievementData.progress;
				this.iconName = AchievementManager.AchievementManager_0.method_9(this._achievementData.type);
				this.iconBGName = AchievementManager.AchievementManager_0.ICON_BG_NAME;
				if (this.OnDataUpdated != null)
				{
					this.OnDataUpdated();
				}
			}
		}
	}

	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06002EA7 RID: 11943 RVA: 0x0001ECE4 File Offset: 0x0001CEE4
	// (set) Token: 0x06002EA8 RID: 11944 RVA: 0x000D8B74 File Offset: 0x000D6D74
	public AchievementStageData AchievementStageData_0
	{
		get
		{
			return this._stageData;
		}
		set
		{
			if (this._stageData == value)
			{
				return;
			}
			this._stageData = value;
			if (this._stageData == null)
			{
				return;
			}
			int num = 0;
			this.goalString = this._stageData.m_stageGoal;
			if (this.goalString == "MAX")
			{
				this.goalType = UIAchievementItemData.GoalType.NUMBER;
				this.goalNumber = MonoSingleton<LevelingManager>.Instance.method_2();
			}
			else if (int.TryParse(this.goalString, out num) && this.goalString != "1")
			{
				this.goalType = UIAchievementItemData.GoalType.NUMBER;
				this.goalNumber = num;
			}
			else
			{
				this.goalType = UIAchievementItemData.GoalType.BOOL;
				this.goalNumber = 1;
			}
		}
	}

	// Token: 0x040020B5 RID: 8373
	private Achievement _achievementData;

	// Token: 0x040020B6 RID: 8374
	private AchievementStageData _stageData;

	// Token: 0x040020B7 RID: 8375
	public UIAchievementItemData.GoalType goalType;

	// Token: 0x040020B8 RID: 8376
	private UIAchievementItemData.UpdateData OnDataUpdated;

	// Token: 0x020006E7 RID: 1767
	public enum GoalType
	{
		// Token: 0x040020C2 RID: 8386
		BOOL,
		// Token: 0x040020C3 RID: 8387
		NUMBER
	}

	// Token: 0x020006E8 RID: 1768
	// (Invoke) Token: 0x06002EAA RID: 11946
	public delegate void UpdateData();
}
