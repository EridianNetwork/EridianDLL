using System;
using System.Runtime.CompilerServices;
using ns0;
using XsdSettings;

// Token: 0x020006E4 RID: 1764
public class UIAchievementLevelData
{
	// Token: 0x1400000F RID: 15
	// (add) Token: 0x06002E85 RID: 11909 RVA: 0x0001EBC6 File Offset: 0x0001CDC6
	// (remove) Token: 0x06002E86 RID: 11910 RVA: 0x0001EBDF File Offset: 0x0001CDDF
	public event UIAchievementLevelData.UpdateLevelData Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.OnLevelDataUpdated = (UIAchievementLevelData.UpdateLevelData)Delegate.Combine(this.OnLevelDataUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.OnLevelDataUpdated = (UIAchievementLevelData.UpdateLevelData)Delegate.Remove(this.OnLevelDataUpdated, value);
		}
	}

	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06002E87 RID: 11911 RVA: 0x0001EBF8 File Offset: 0x0001CDF8
	// (set) Token: 0x06002E88 RID: 11912 RVA: 0x0001EC00 File Offset: 0x0001CE00
	public AchievementLevelData nextLevelData { get; set; }

	// Token: 0x17000243 RID: 579
	// (get) Token: 0x06002E89 RID: 11913 RVA: 0x0001EC09 File Offset: 0x0001CE09
	// (set) Token: 0x06002E8A RID: 11914 RVA: 0x0001EC11 File Offset: 0x0001CE11
	public AchievementLevelData data { get; set; }

	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06002E8B RID: 11915 RVA: 0x0001EC1A File Offset: 0x0001CE1A
	// (set) Token: 0x06002E8C RID: 11916 RVA: 0x000D89D0 File Offset: 0x000D6BD0
	public int Int32_0
	{
		get
		{
			return this._currentPoint;
		}
		set
		{
			if (this._currentPoint == value)
			{
				return;
			}
			this._currentPoint = value;
			if (this._currentPoint >= 0)
			{
				int num = this.method_0(this._currentPoint);
				this.data = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementLevelTable[num];
				if (num + 1 < MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementLevelTable.Length)
				{
					this.nextLevelData = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementLevelTable[num + 1];
				}
				else
				{
					this.nextLevelData = this.data;
				}
			}
			if (this.OnLevelDataUpdated != null)
			{
				this.OnLevelDataUpdated();
			}
		}
	}

	// Token: 0x06002E8D RID: 11917 RVA: 0x000D8A6C File Offset: 0x000D6C6C
	private int method_0(int int_0)
	{
		int i = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementLevelTable.Length - 1;
		int num = 0;
		while (i >= num)
		{
			if (int_0 >= MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementLevelTable[i].m_levelMinPoint)
			{
				return i;
			}
			i--;
		}
		return 0;
	}

	// Token: 0x040020B1 RID: 8369
	private int _currentPoint = -1;

	// Token: 0x040020B2 RID: 8370
	private UIAchievementLevelData.UpdateLevelData OnLevelDataUpdated;

	// Token: 0x020006E5 RID: 1765
	// (Invoke) Token: 0x06002E8F RID: 11919
	public delegate void UpdateLevelData();
}
