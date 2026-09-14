using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

// Token: 0x02000831 RID: 2097
public class uniHUDScoreView : HUDScoreView
{
	// Token: 0x060038BE RID: 14526 RVA: 0x00108314 File Offset: 0x00106514
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PVP_HUD.swf", "ScoreBoard", new FuncLoad(this.method_5));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PVP_HUD.swf", "RankBoard", new FuncLoad(this.method_6));
	}

	// Token: 0x060038BF RID: 14527 RVA: 0x0010837C File Offset: 0x0010657C
	private void method_5(MovieClip movieClip_0)
	{
		this.m_ScoreBoard = new uniHUDScoreView.ScoreBoard();
		this.m_ScoreBoard.method_4(movieClip_0, "normal", null);
		this.m_ScoreBoard.method_4(movieClip_0, "fadeout", null);
		movieClip_0.visible = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_ScoreBoard);
	}

	// Token: 0x060038C0 RID: 14528 RVA: 0x001083DC File Offset: 0x001065DC
	private void method_6(MovieClip movieClip_0)
	{
		this.m_SummaryBoard = new uniHUDScoreView.SummaryBoard();
		this.m_SummaryBoard.method_4(movieClip_0, "fadein", null);
		this.m_SummaryBoard.method_4(movieClip_0, "normal", null);
		this.m_SummaryBoard.method_4(movieClip_0, "fadeout", null);
		this.m_SummaryBoard.method_7(new uniHUDScoreView.Delegate_ReturnLobby(base.method_4));
		movieClip_0.visible = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_SummaryBoard);
	}

	// Token: 0x060038C1 RID: 14529 RVA: 0x00025C60 File Offset: 0x00023E60
	public override void vmethod_6(StatisticsManager.StatSheet[] statSheet_0)
	{
		base.vmethod_6(statSheet_0);
		this.method_7();
	}

	// Token: 0x060038C2 RID: 14530 RVA: 0x00108468 File Offset: 0x00106668
	public override void vmethod_7(StatisticsManager.StatSheet[] statSheet_0)
	{
		base.vmethod_7(statSheet_0);
		List<StatisticsManager.StatSheet> list = new List<StatisticsManager.StatSheet>();
		for (int i = 0; i < statSheet_0.Length; i++)
		{
			if (statSheet_0[i].m_name != null)
			{
				list.Add(statSheet_0[i]);
			}
		}
		list.Sort(new Comparison<StatisticsManager.StatSheet>(base.method_3));
		MovieClip movieClip = this.m_SummaryBoard.DisplayObjectContainer_0 as MovieClip;
		movieClip.visible = true;
		movieClip.gotoAndPlay("fadein");
		this.m_SummaryBoard.method_5(list);
	}

	// Token: 0x060038C3 RID: 14531 RVA: 0x001084E4 File Offset: 0x001066E4
	public override void vmethod_5(bool bool_0)
	{
		if (this.m_bScoreBoardVisible == bool_0)
		{
			return;
		}
		this.m_bScoreBoardVisible = bool_0;
		MovieClip movieClip = this.m_ScoreBoard.DisplayObjectContainer_0 as MovieClip;
		if (bool_0)
		{
			movieClip.gotoAndPlay("normal");
			movieClip.visible = true;
		}
		else
		{
			movieClip.gotoAndPlay("fadeout");
		}
	}

	// Token: 0x060038C4 RID: 14532 RVA: 0x00025C6F File Offset: 0x00023E6F
	protected void method_7()
	{
		this.m_ScoreBoard.method_5(this.m_scoreCardList);
	}

	// Token: 0x060038C5 RID: 14533 RVA: 0x00108538 File Offset: 0x00106738
	public override void vmethod_3()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_ScoreBoard);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_SummaryBoard);
		this.m_ScoreBoard = null;
		this.m_SummaryBoard = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("PVP_HUD.swf");
	}

	// Token: 0x040027BA RID: 10170
	protected uniHUDScoreView.ScoreBoard m_ScoreBoard;

	// Token: 0x040027BB RID: 10171
	protected uniHUDScoreView.SummaryBoard m_SummaryBoard;

	// Token: 0x02000832 RID: 2098
	public class ScoreBoard : GClass51
	{
		// Token: 0x060038C7 RID: 14535 RVA: 0x001085A0 File Offset: 0x001067A0
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains(this.m_strLinePrefix))
			{
				string[] array = movieClip.name.Split(new char[] { '_' });
				string text = array[array.Length - 1];
				int num = Convert.ToInt32(text);
				if (num < 1 || num > this.m_ScoreItemArray.Length)
				{
					DebugUtils.LogError(LogCategory.GUI, "PVP_HUD.swf:ScoreBoard   Wrong MovieClip index : " + movieClip.name);
					return flag;
				}
				this.m_ScoreItemArray[num - 1] = new uniHUDScoreView.ScoreItem();
				this.m_ScoreItemArray[num - 1].method_0(movieClip);
				movieClip.visible = false;
				flag = true;
			}
			return flag;
		}

		// Token: 0x060038C8 RID: 14536 RVA: 0x00108640 File Offset: 0x00106840
		public void method_5(List<StatisticsManager.StatSheet> list_1)
		{
			int count = list_1.Count;
			for (int i = 0; i < this.m_ScoreItemArray.Length; i++)
			{
				if (i < count)
				{
					this.m_ScoreItemArray[i].method_7(list_1[i], i + 1);
					this.m_ScoreItemArray[i].method_5(true);
					this.m_ScoreItemArray[i].method_6(list_1[i].m_name == MonoSingleton<Session>.Instance.GetLocalPlayer().m_name);
				}
				else
				{
					this.m_ScoreItemArray[i].method_5(false);
				}
			}
		}

		// Token: 0x040027BC RID: 10172
		protected uniHUDScoreView.ScoreItem[] m_ScoreItemArray = new uniHUDScoreView.ScoreItem[12];

		// Token: 0x040027BD RID: 10173
		protected string m_strLinePrefix = "mcLine_";
	}

	// Token: 0x02000833 RID: 2099
	public class ScoreItem : GClass51
	{
		// Token: 0x060038CA RID: 14538 RVA: 0x00025CA2 File Offset: 0x00023EA2
		public void method_5(bool bool_0)
		{
			this.displayObjectContainer_0.visible = bool_0;
		}

		// Token: 0x060038CB RID: 14539 RVA: 0x001086D0 File Offset: 0x001068D0
		public void method_6(bool bool_0)
		{
			if (this.m_bIsLocalPlayer != bool_0)
			{
				if (bool_0)
				{
					(this.displayObjectContainer_0 as MovieClip).gotoAndPlay("myline");
				}
				else
				{
					(this.displayObjectContainer_0 as MovieClip).gotoAndPlay("normal");
				}
				this.m_bIsLocalPlayer = bool_0;
			}
		}

		// Token: 0x060038CC RID: 14540 RVA: 0x0010871C File Offset: 0x0010691C
		public void method_7(StatisticsManager.StatSheet statSheet_0, int int_0)
		{
			this.m_PlayerName.getChildByName<TextField>("textField").text = statSheet_0.m_name;
			this.m_Score.getChildByName<TextField>("textField").text = Convert.ToString(statSheet_0.m_score);
			this.m_KillCount.getChildByName<TextField>("textField").text = Convert.ToString(statSheet_0.m_killCount);
			this.m_DeathCount.getChildByName<TextField>("textField").text = Convert.ToString(statSheet_0.m_deathcount);
			if (statSheet_0.m_ping == StatisticsManager.PingQuality.Low)
			{
				this.m_NetworkStatus.gotoAndStop("red");
			}
			else if (statSheet_0.m_ping == StatisticsManager.PingQuality.Medium)
			{
				this.m_NetworkStatus.gotoAndStop("orange");
			}
			else if (statSheet_0.m_ping == StatisticsManager.PingQuality.High)
			{
				this.m_NetworkStatus.gotoAndStop("green");
			}
			if (int_0 == 1)
			{
				this.m_Rank.getChildByName<TextField>("textField").text = "1st";
			}
			else if (int_0 == 2)
			{
				this.m_Rank.getChildByName<TextField>("textField").text = "2nd";
			}
			else if (int_0 == 3)
			{
				this.m_Rank.getChildByName<TextField>("textField").text = "3rd";
			}
			else
			{
				this.m_Rank.getChildByName<TextField>("textField").text = Convert.ToString(int_0);
			}
		}

		// Token: 0x060038CD RID: 14541 RVA: 0x00108870 File Offset: 0x00106A70
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			string name = movieClip.name;
			switch (name)
			{
			case "mcRank":
				this.m_Rank = movieClip;
				return true;
			case "mcPlayerName":
				this.m_PlayerName = movieClip;
				return true;
			case "mcScore":
				this.m_Score = movieClip;
				return true;
			case "mcKillCount":
				this.m_KillCount = movieClip;
				return true;
			case "mcDeathCount":
				this.m_DeathCount = movieClip;
				return true;
			case "mcNetworkStatus":
				this.m_NetworkStatus = movieClip;
				return true;
			}
			return true;
		}

		// Token: 0x040027BE RID: 10174
		protected MovieClip m_NetworkStatus;

		// Token: 0x040027BF RID: 10175
		protected MovieClip m_Rank;

		// Token: 0x040027C0 RID: 10176
		protected MovieClip m_PlayerName;

		// Token: 0x040027C1 RID: 10177
		protected MovieClip m_Score;

		// Token: 0x040027C2 RID: 10178
		protected MovieClip m_KillCount;

		// Token: 0x040027C3 RID: 10179
		protected MovieClip m_DeathCount;

		// Token: 0x040027C4 RID: 10180
		protected bool m_bIsLocalPlayer;
	}

	// Token: 0x02000834 RID: 2100
	public class SummaryBoard : GClass51
	{
		// Token: 0x060038CF RID: 14543 RVA: 0x00108964 File Offset: 0x00106B64
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains(this.m_strLinePrefix))
			{
				string[] array = movieClip.name.Split(new char[] { '_' });
				string text = array[array.Length - 1];
				int num = Convert.ToInt32(text);
				if (num < 1 || num > this.m_SummaryItemArray.Length)
				{
					DebugUtils.LogError(LogCategory.GUI, "PVP_HUD.swf:ScoreBoard   Wrong MovieClip index : " + movieClip.name);
					return flag;
				}
				this.m_SummaryItemArray[num - 1] = new uniHUDScoreView.SummaryItem();
				this.m_SummaryItemArray[num - 1].method_4(movieClip, "normal", null);
				this.m_SummaryItemArray[num - 1].method_4(movieClip, "myline", null);
				movieClip.visible = false;
				flag = true;
			}
			else if (movieClip.name == "mcReturnLobby")
			{
				this.m_btnReturnLobby = new GClass25();
				this.m_btnReturnLobby.method_0(movieClip);
				this.m_btnReturnLobby.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			}
			return flag;
		}

		// Token: 0x060038D0 RID: 14544 RVA: 0x00108A70 File Offset: 0x00106C70
		public void method_5(List<StatisticsManager.StatSheet> list_1)
		{
			int count = list_1.Count;
			string text = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9();
			for (int i = 0; i < this.m_SummaryItemArray.Length; i++)
			{
				if (i < count)
				{
					this.m_SummaryItemArray[i].method_7(list_1[i], i + 1);
					this.m_SummaryItemArray[i].method_6(list_1[i].m_name == text);
					this.m_SummaryItemArray[i].method_5(true);
				}
				else
				{
					this.m_SummaryItemArray[i].method_5(false);
				}
			}
		}

		// Token: 0x060038D1 RID: 14545 RVA: 0x00108AFC File Offset: 0x00106CFC
		public void method_6(bool bool_0)
		{
			MovieClip movieClip = this.displayObjectContainer_0 as MovieClip;
			if (bool_0)
			{
				movieClip.gotoAndPlay("fadein");
				movieClip.visible = true;
			}
			else
			{
				movieClip.visible = false;
			}
		}

		// Token: 0x060038D2 RID: 14546 RVA: 0x00025CD0 File Offset: 0x00023ED0
		public void method_7(uniHUDScoreView.Delegate_ReturnLobby delegate_ReturnLobby_0)
		{
			this.m_returnLobby = delegate_ReturnLobby_0;
		}

		// Token: 0x060038D3 RID: 14547 RVA: 0x00025CD9 File Offset: 0x00023ED9
		protected void method_8(CEvent cevent_0)
		{
			this.m_returnLobby();
		}

		// Token: 0x040027C6 RID: 10182
		protected uniHUDScoreView.SummaryItem[] m_SummaryItemArray = new uniHUDScoreView.SummaryItem[12];

		// Token: 0x040027C7 RID: 10183
		protected string m_strLinePrefix = "mcRank_";

		// Token: 0x040027C8 RID: 10184
		protected uniHUDScoreView.Delegate_ReturnLobby m_returnLobby;

		// Token: 0x040027C9 RID: 10185
		protected GClass25 m_btnReturnLobby;
	}

	// Token: 0x02000835 RID: 2101
	public class SummaryItem : GClass51
	{
		// Token: 0x060038D5 RID: 14549 RVA: 0x00025CE6 File Offset: 0x00023EE6
		public void method_5(bool bool_0)
		{
			(this.displayObjectContainer_0 as MovieClip).visible = bool_0;
		}

		// Token: 0x060038D6 RID: 14550 RVA: 0x00108B34 File Offset: 0x00106D34
		public void method_6(bool bool_0)
		{
			if (this.m_bIsLocalPlayer != bool_0)
			{
				if (bool_0)
				{
					(this.displayObjectContainer_0 as MovieClip).gotoAndPlay("myline");
				}
				else
				{
					(this.displayObjectContainer_0 as MovieClip).gotoAndPlay("normal");
				}
				this.m_bIsLocalPlayer = bool_0;
			}
		}

		// Token: 0x060038D7 RID: 14551 RVA: 0x00108B80 File Offset: 0x00106D80
		public void method_7(StatisticsManager.StatSheet statSheet_0, int int_0)
		{
			MovieClip movieClip = this.displayObjectContainer_0 as MovieClip;
			movieClip.visible = true;
			movieClip.getChildByName<TextField>("text_playername").text = statSheet_0.m_name;
			movieClip.getChildByName<TextField>("text_score").text = Convert.ToString(statSheet_0.m_score);
			movieClip.getChildByName<TextField>("text_killcount").text = Convert.ToString(statSheet_0.m_killCount);
			movieClip.getChildByName<TextField>("text_deathcount").text = Convert.ToString(statSheet_0.m_deathcount);
			movieClip.getChildByName<TextField>("text_exp").text = Convert.ToString(statSheet_0.m_score);
			if (int_0 == 1)
			{
				movieClip.getChildByName<TextField>("text_ranklist").text = "1st";
			}
			else if (int_0 == 2)
			{
				movieClip.getChildByName<TextField>("text_ranklist").text = "2nd";
			}
			else if (int_0 == 3)
			{
				movieClip.getChildByName<TextField>("text_ranklist").text = "3rd";
			}
			else
			{
				movieClip.getChildByName<TextField>("text_ranklist").text = Convert.ToString(int_0) + "th";
			}
		}

		// Token: 0x040027CA RID: 10186
		protected bool m_bIsLocalPlayer;
	}

	// Token: 0x02000836 RID: 2102
	// (Invoke) Token: 0x060038D9 RID: 14553
	public delegate void Delegate_ReturnLobby();
}
