using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.text;
using XsdSettings;

// Token: 0x02000843 RID: 2115
public class uniHUDVictoryCondition : HUDVictoryCondition
{
	// Token: 0x06003950 RID: 14672 RVA: 0x000262E7 File Offset: 0x000244E7
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PVP_HUD.swf", "ScoreBar", new FuncLoad(this.method_4));
	}

	// Token: 0x06003951 RID: 14673 RVA: 0x0010ACC4 File Offset: 0x00108EC4
	private void method_4(MovieClip movieClip_0)
	{
		this.m_RankInfo = new uniHUDVictoryCondition.RankInfo();
		this.m_RankInfo.method_0(movieClip_0);
		this.m_RankInfo.UniHUDVictoryCondition_0 = this;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_RankInfo);
		movieClip_0.visible = this._bVisible;
	}

	// Token: 0x06003952 RID: 14674 RVA: 0x00026319 File Offset: 0x00024519
	public override void vmethod_3()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_RankInfo);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_PVP_HUD.swf");
	}

	// Token: 0x06003953 RID: 14675 RVA: 0x0002634E File Offset: 0x0002454E
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this._bVisible != bool_0)
		{
			if (this.m_RankInfo == null)
			{
				return;
			}
			this.m_RankInfo.method_7(bool_0);
			base.vmethod_1(bool_0, bool_1);
		}
	}

	// Token: 0x06003954 RID: 14676 RVA: 0x00026376 File Offset: 0x00024576
	public override void vmethod_5(bool bool_0)
	{
		if (this.m_RankInfo != null)
		{
			this.m_RankInfo.method_7(bool_0);
		}
	}

	// Token: 0x06003955 RID: 14677 RVA: 0x0010AD1C File Offset: 0x00108F1C
	public override void vmethod_6(int int_0, StatisticsManager.StatSheet statSheet_0)
	{
		base.vmethod_6(int_0, null);
		if (this.m_RankInfo == null)
		{
			return;
		}
		this.m_playerStats = statSheet_0;
		if (this.m_bNewPhaseActived)
		{
			switch (this.m_currentStatus)
			{
			case HUDVictoryCondition.eTimeStatus.normal:
				this.m_RankInfo.method_11();
				break;
			case HUDVictoryCondition.eTimeStatus.over:
				this.m_RankInfo.method_10();
				break;
			}
		}
		int num = int_0 / 60;
		int num2 = int_0 % 60;
		if (this.m_currentStatus != HUDVictoryCondition.eTimeStatus.over)
		{
			this.m_RankInfo.method_9(num, num2, true);
		}
		else
		{
			this.m_RankInfo.method_9(0, 0, false);
		}
		if (int_0 > 0)
		{
			this.m_RankInfo.method_5();
		}
		this.m_RankInfo.method_6(base.method_3());
	}

	// Token: 0x0400280D RID: 10253
	protected uniHUDVictoryCondition.RankInfo m_RankInfo;

	// Token: 0x0400280E RID: 10254
	public StatisticsManager.StatSheet m_playerStats;

	// Token: 0x02000844 RID: 2116
	protected class RankInfo : GClass51
	{
		// Token: 0x1700030D RID: 781
		// (set) Token: 0x06003957 RID: 14679 RVA: 0x0002638C File Offset: 0x0002458C
		public uniHUDVictoryCondition UniHUDVictoryCondition_0
		{
			set
			{
				this.rootView = value;
			}
		}

		// Token: 0x06003958 RID: 14680 RVA: 0x0010ADD0 File Offset: 0x00108FD0
		public void method_5()
		{
			string text = MonoSingleton<Session>.Instance.method_6();
			if (MatchmakingService.smethod_0(text) == GamemodeType.GamemodeTeamDeathmatch || MatchmakingService.smethod_0(text) == GamemodeType.GamemodeClaptrapSoccer)
			{
				StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
				DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new string[]
				{
					"DIAGRI: sessionNull=",
					(currentSession == null).ToString(),
					" sheet1Null=",
					(currentSession != null && currentSession.method_9(1) == null).ToString(),
					" sheet2Null=",
					(currentSession != null && currentSession.method_9(2) == null).ToString()
				}));
				if (currentSession != null && currentSession.method_9(1) != null && currentSession.method_9(2) != null)
				{
					int num;
					int num2;
					if (MatchmakingService.smethod_0(text) == GamemodeType.GamemodeTeamDeathmatch)
					{
						num = currentSession.method_9(1).m_killCount;
						num2 = currentSession.method_9(2).m_killCount;
					}
					else
					{
						num = currentSession.method_9(1).m_score;
						num2 = currentSession.method_9(2).m_score;
					}
					DebugUtils.LogError(LogCategory.Gamelogic, "DIAGRI: num=" + num.ToString() + " num2=" + num2.ToString());
					this.method_8(this.m_homeTeamScoreContainer, Utility.smethod_8(num), true, num > 0);
					this.method_8(this.m_awayTeamScoreContainer, Utility.smethod_8(num2), true, num2 > 0);
				}
			}
			if (this.rootView.m_playerStats != null)
			{
				if (this.rootView.m_playerStats.m_score == 0 && this.rootView.m_playerStats.m_killCount == 0)
				{
					if (this.m_scoreInfoPanel.visible)
					{
						this.m_scoreInfoPanel.visible = false;
						return;
					}
				}
				else
				{
					if (!this.m_scoreInfoPanel.visible)
					{
						this.m_scoreInfoPanel.visible = true;
					}
					this.method_8(this.m_scoreInfoPanel.getChildByName<MovieClip>("mcScore"), Utility.smethod_8(this.rootView.m_playerStats.m_score), true, false);
					this.method_8(this.m_scoreInfoPanel.getChildByName<MovieClip>("mcKillInfo"), Utility.smethod_8(this.rootView.m_playerStats.m_killCount), true, false);
				}
			}
		}

		// Token: 0x06003959 RID: 14681 RVA: 0x0010AFEC File Offset: 0x001091EC
		public void method_6(StatisticsManager.StatSheet statSheet_0)
		{
			if (statSheet_0 != null)
			{
				this.method_8(this.m_playerInfo, Utility.smethod_6(Utility.smethod_5("LV ", Utility.smethod_8(statSheet_0.m_level)), " ", statSheet_0.m_name), true, false);
				this.method_8(this.m_scoreInfo, Utility.smethod_8(statSheet_0.m_score), true, false);
				this.method_8(this.m_killInfo, Utility.smethod_8(statSheet_0.m_killCount), true, false);
				this.m_topScorePanel.visible = true;
			}
			else
			{
				this.m_topScorePanel.visible = false;
			}
		}

		// Token: 0x0600395A RID: 14682 RVA: 0x0010B07C File Offset: 0x0010927C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: RankInfo onInit() 'mc_root' is null! RankInfo won't work!!!");
				return;
			}
			this.m_homeBar = this.mc_root.getChildByName<MovieClip>("mc_HomeBar");
			this.m_awayBar = this.mc_root.getChildByName<MovieClip>("mc_AwayBar");
		}

		// Token: 0x0600395B RID: 14683 RVA: 0x0010B0E0 File Offset: 0x001092E0
		protected override bool OnWidgetInitialized(ref MovieClip mc, Type widgetType)
		{
			string name = mc.name;
			switch (name)
			{
			case "mcTime":
				this.m_timePanel = new MovieClip();
				this.m_timePanel = mc;
				return true;
			case "mcAwayTeamScore":
				this.m_awayTeamScore = mc;
				this.m_awayTeamScoreContainer = this.m_awayTeamScore.getChildByName<MovieClip>("mcUpperScore");
				this.m_awayTeamScoreContainer = this.m_awayTeamScoreContainer.getChildByName<MovieClip>("mcTextContainer");
				this.method_8(this.m_awayTeamScoreContainer, "0", true, false);
				return true;
			case "mcHomeTeamScore":
				this.m_homeTeamScore = mc;
				this.m_homeTeamScoreContainer = this.m_homeTeamScore.getChildByName<MovieClip>("mcUpperScore");
				this.m_homeTeamScoreContainer = this.m_homeTeamScoreContainer.getChildByName<MovieClip>("mcTextContainer");
				this.method_8(this.m_homeTeamScoreContainer, "0", true, false);
				return true;
			case "mcTopScore":
				this.m_topScorePanel = mc;
				this.m_playerInfo = new MovieClip();
				this.m_playerInfo = this.m_topScorePanel.getChildByName<MovieClip>("mcPlayerInfoText");
				this.m_scoreInfo = new MovieClip();
				this.m_scoreInfo = this.m_topScorePanel.getChildByName<MovieClip>("mcScoreInfo");
				this.m_killInfo = new MovieClip();
				this.m_killInfo = this.m_topScorePanel.getChildByName<MovieClip>("mcKillingInfo");
				this.m_topScorePanel.visible = false;
				return true;
			case "mcMyScoreInfo":
				this.m_scoreInfoPanel = mc;
				this.m_scoreInfoPanel.visible = false;
				return true;
			case "mc_achievement":
				this.m_achievement = mc;
				if (MonoSingleton<Session>.Instance.method_14())
				{
					if (MonoSingleton<Session>.Instance.method_15())
					{
						this.method_8(this.m_achievement, LocalizedString.smethod_0(new LocalizedString("PVPMode_ClaptrapSoccer")), true, false);
					}
					else
					{
						this.method_8(this.m_achievement, LocalizedString.smethod_0(new LocalizedString("PVPMode_TeamDeathMatch")), true, false);
					}
				}
				else
				{
					this.method_8(this.m_achievement, LocalizedString.smethod_0(new LocalizedString("PVPMode_DeathMatch")), true, false);
				}
				return true;
			}
			return true;
		}

		// Token: 0x0600395C RID: 14684 RVA: 0x0010B360 File Offset: 0x00109560
		public void method_7(bool bool_0)
		{
			if (bool_0)
			{
				string text = MonoSingleton<Session>.Instance.method_6();
				if (text == "GameModePvP")
				{
					this.m_awayTeamScore.visible = false;
					this.m_homeTeamScore.visible = false;
					this.m_topScorePanel.visible = true;
					this.m_homeBar.visible = false;
					this.m_awayBar.visible = false;
				}
				else if (text == "GamemodeTeamDeathmatch" || text == "GamemodeClaptrapSoccer")
				{
					this.m_awayTeamScore.visible = true;
					this.m_homeTeamScore.visible = true;
					this.m_topScorePanel.visible = false;
					StatisticsManager.StatSheet statSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_21();
					if (statSheet != null)
					{
						if (statSheet.m_teamId == 1)
						{
							this.m_homeBar.visible = true;
							this.m_awayBar.visible = false;
						}
						else
						{
							this.m_homeBar.visible = false;
							this.m_awayBar.visible = true;
						}
					}
					else
					{
						this.m_homeBar.visible = false;
						this.m_awayBar.visible = false;
					}
				}
				this.displayObjectContainer_0.visible = true;
			}
			else
			{
				this.displayObjectContainer_0.visible = false;
			}
		}

		// Token: 0x0600395D RID: 14685 RVA: 0x0010B490 File Offset: 0x00109690
		private void method_8(MovieClip movieClip_0, string string_1, bool bool_0 = true, bool bool_1 = false)
		{
			TextField childByName = movieClip_0.getChildByName<TextField>("textField");
			if (childByName.text != string_1)
			{
				childByName.text = string_1;
				if ((movieClip_0 == this.m_awayTeamScoreContainer || movieClip_0 == this.m_homeTeamScoreContainer) && bool_1)
				{
					movieClip_0.gotoAndPlay("getscore");
				}
			}
			if (childByName.visible != bool_0)
			{
				childByName.visible = bool_0;
			}
		}

		// Token: 0x0600395E RID: 14686 RVA: 0x0010B4F0 File Offset: 0x001096F0
		public void method_9(int int_0, int int_1, bool bool_0 = true)
		{
			if (this.m_timePanel == null)
			{
				return;
			}
			string text = Utility.smethod_6(Utility.smethod_5(Utility.smethod_8(int_0), "'"), Utility.smethod_8(int_1), "''");
			this.method_8(this.m_timePanel, text, bool_0, false);
		}

		// Token: 0x0600395F RID: 14687 RVA: 0x00026395 File Offset: 0x00024595
		public void method_10()
		{
			this.method_8(this.m_timePanel, "0'00''", false, false);
			if (this.m_timePanel != null)
			{
				this.m_timePanel.gotoAndPlay("over");
			}
		}

		// Token: 0x06003960 RID: 14688 RVA: 0x000263C2 File Offset: 0x000245C2
		public void method_11()
		{
			if (this.m_timePanel != null)
			{
				this.m_timePanel.gotoAndPlay("normal");
			}
		}

		// Token: 0x0400280F RID: 10255
		protected MovieClip mc_root;

		// Token: 0x04002810 RID: 10256
		protected MovieClip m_achievement;

		// Token: 0x04002811 RID: 10257
		protected MovieClip m_homeTeamScore;

		// Token: 0x04002812 RID: 10258
		protected MovieClip m_awayTeamScore;

		// Token: 0x04002813 RID: 10259
		protected MovieClip m_homeTeamScoreContainer;

		// Token: 0x04002814 RID: 10260
		protected MovieClip m_awayTeamScoreContainer;

		// Token: 0x04002815 RID: 10261
		protected MovieClip m_homeBar;

		// Token: 0x04002816 RID: 10262
		protected MovieClip m_awayBar;

		// Token: 0x04002817 RID: 10263
		protected MovieClip m_topScorePanel;

		// Token: 0x04002818 RID: 10264
		protected MovieClip m_playerInfo;

		// Token: 0x04002819 RID: 10265
		protected MovieClip m_scoreInfo;

		// Token: 0x0400281A RID: 10266
		protected MovieClip m_killInfo;

		// Token: 0x0400281B RID: 10267
		protected MovieClip m_scoreInfoPanel;

		// Token: 0x0400281C RID: 10268
		protected int m_iLastUpperScore;

		// Token: 0x0400281D RID: 10269
		public MovieClip m_timePanel;

		// Token: 0x0400281E RID: 10270
		private uniHUDVictoryCondition rootView;
	}
}
