using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using XsdSettings;

// Token: 0x02000873 RID: 2163
public class uniNewInstanceSelectView : NewInstanceSelectView
{
	// Token: 0x06003B08 RID: 15112 RVA: 0x000279E6 File Offset: 0x00025BE6
	public uniNewInstanceSelectView()
	{
		this.m_InstanceMap = new Dictionary<int, List<uniNewInstanceSelectView.NewInstanceButton>>();
		this.m_InstanceMap.Clear();
	}

	// Token: 0x06003B09 RID: 15113 RVA: 0x00027A04 File Offset: 0x00025C04
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Instance_selection_Frame.swf", "Movie_map", new FuncLoad(this.method_3));
	}

	// Token: 0x06003B0A RID: 15114 RVA: 0x00115254 File Offset: 0x00113454
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.m_InstanceMap.Clear();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._InstanceMapPanel);
		this._InstanceMapPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Instance_selection_Frame.swf");
	}

	// Token: 0x06003B0B RID: 15115 RVA: 0x001152AC File Offset: 0x001134AC
	private void method_3(MovieClip movieClip_0)
	{
		this._InstanceMapPanel = new uniNewInstanceSelectView.InstanceMapPanel();
		this._InstanceMapPanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._InstanceMapPanel);
		this._InstanceMapPanel.Boolean_0 = false;
	}

	// Token: 0x06003B0C RID: 15116 RVA: 0x001152F8 File Offset: 0x001134F8
	public void method_4(bool bool_0, int int_0, int int_1, float float_0, float float_1)
	{
		uniNewInstanceSelectView.NewInstanceButton newInstanceButton = new uniNewInstanceSelectView.NewInstanceButton(bool_0, int_0, int_1);
		if (bool_0)
		{
			newInstanceButton.method_0(new BadAssMovieClip("CommonLib.swf", "Button_town"));
		}
		else
		{
			newInstanceButton.method_0(new BadAssMovieClip("CommonLib.swf", "Button_sation"));
		}
		newInstanceButton.method_19(float_0, float_1);
		this.method_5(newInstanceButton);
	}

	// Token: 0x06003B0D RID: 15117 RVA: 0x00115350 File Offset: 0x00113550
	protected void method_5(uniNewInstanceSelectView.NewInstanceButton newInstanceButton_0)
	{
		if (this.m_InstanceMap.ContainsKey(newInstanceButton_0.m_nTownId))
		{
			List<uniNewInstanceSelectView.NewInstanceButton> list = this.m_InstanceMap[newInstanceButton_0.m_nTownId];
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].m_nInstanceId == newInstanceButton_0.m_nInstanceId)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				list.Add(newInstanceButton_0);
			}
		}
		else
		{
			List<uniNewInstanceSelectView.NewInstanceButton> list2 = new List<uniNewInstanceSelectView.NewInstanceButton>();
			list2.Clear();
			list2.Add(newInstanceButton_0);
			this.m_InstanceMap.Add(newInstanceButton_0.m_nTownId, list2);
		}
	}

	// Token: 0x06003B0E RID: 15118 RVA: 0x001153DC File Offset: 0x001135DC
	public void method_6(int int_0)
	{
		for (int i = 0; i < this.m_InstanceMap.Count; i++)
		{
			this._InstanceMapPanel.method_13(this.m_InstanceMap.ElementAt<KeyValuePair<int, List<uniNewInstanceSelectView.NewInstanceButton>>>(i).Value);
		}
		if (this.m_InstanceMap.ContainsKey(InstanceMapSelectControl.smethod_2()))
		{
			this._InstanceMapPanel.method_14(this.m_InstanceMap[InstanceMapSelectControl.smethod_2()]);
		}
	}

	// Token: 0x06003B0F RID: 15119 RVA: 0x0011544C File Offset: 0x0011364C
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		InstanceMapSelectControl.smethod_0();
		if (this._InstanceMapPanel != null)
		{
			if (bool_0)
			{
				TownInstanceSelectionControl.smethod_8(InstanceMapSelectControl.smethod_2());
				MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
				if (this.m_InstanceMap.ContainsKey(InstanceMapSelectControl.smethod_2()))
				{
					this._InstanceMapPanel.method_14(this.m_InstanceMap[InstanceMapSelectControl.smethod_2()]);
				}
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
				for (int i = 0; i < this.m_InstanceMap.Count; i++)
				{
					this._InstanceMapPanel.method_13(this.m_InstanceMap.ElementAt<KeyValuePair<int, List<uniNewInstanceSelectView.NewInstanceButton>>>(i).Value);
				}
			}
			this._InstanceMapPanel.Boolean_0 = bool_0;
		}
	}

	// Token: 0x04002961 RID: 10593
	protected Dictionary<int, List<uniNewInstanceSelectView.NewInstanceButton>> m_InstanceMap;

	// Token: 0x04002962 RID: 10594
	private uniNewInstanceSelectView.InstanceMapPanel _InstanceMapPanel;

	// Token: 0x02000874 RID: 2164
	public class NewInstanceButton : GClass25
	{
		// Token: 0x06003B10 RID: 15120 RVA: 0x00027A36 File Offset: 0x00025C36
		public NewInstanceButton(bool bool_8, int int_0, int int_1)
		{
			this.m_bIsTown = bool_8;
			this.m_nInstanceId = int_0;
			this.m_nTownId = int_1;
		}

		// Token: 0x06003B11 RID: 15121 RVA: 0x00115510 File Offset: 0x00113710
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_ButtonClip = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_ButtonClip == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: NewInstanceButton onInit() 'mc_ButtonClip' is null! NewInstanceButton won't work!!!");
				return;
			}
			if (this.m_bIsTown)
			{
				this.mc_QuestIcon = this.mc_ButtonClip.getChildByName<MovieClip>("mc_quest");
				this.mc_TaskIcon = this.mc_ButtonClip.getChildByName<MovieClip>("mc_task");
				this.mc_TaskIcon.visible = false;
			}
			else
			{
				this.mc_QuestIcon = this.mc_ButtonClip.getChildByName<MovieClip>("mc_questMark");
				this.mc_BossIcon = this.mc_ButtonClip.getChildByName<MovieClip>("mc_BossIcon");
			}
			this.String_2 = LocalizedString.smethod_0(new LocalizedString("Instance_" + this.m_nInstanceId.ToString()));
			this.mc_ButtonClip.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.Update));
			this.mc_ButtonClip.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
		}

		// Token: 0x06003B12 RID: 15122 RVA: 0x00027A53 File Offset: 0x00025C53
		public void method_19(float float_2, float float_3)
		{
			this.mc_ButtonClip.x = float_2 / GClass20.GClass20_0.Single_0;
			this.mc_ButtonClip.y = float_3 / GClass20.GClass20_0.Single_0;
		}

		// Token: 0x06003B13 RID: 15123 RVA: 0x00027A83 File Offset: 0x00025C83
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.method_20();
		}

		// Token: 0x06003B14 RID: 15124 RVA: 0x00115618 File Offset: 0x00113818
		protected void method_20()
		{
			if (this.mc_QuestIcon != null)
			{
				if (this.m_questStatus != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
				{
					if (this.m_questStatus != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
					{
						if (this.mc_QuestIcon.visible)
						{
							this.mc_QuestIcon.visible = false;
							goto IL_0050;
						}
						goto IL_0050;
					}
				}
				if (!this.mc_QuestIcon.visible)
				{
					this.mc_QuestIcon.visible = true;
				}
			}
			IL_0050:
			if (this.mc_BossIcon != null)
			{
				this.mc_BossIcon = this.mc_ButtonClip.getChildByName<MovieClip>("mc_BossIcon");
				if (this.mc_BossIcon.visible != this.m_bIsBossInstance)
				{
					this.mc_BossIcon.visible = this.m_bIsBossInstance;
				}
			}
			if (this.mc_TaskIcon != null)
			{
				this.mc_TaskIcon.visible = false;
			}
		}

		// Token: 0x06003B15 RID: 15125 RVA: 0x00027A91 File Offset: 0x00025C91
		protected void Update(CEvent btnEvent)
		{
			this.method_20();
		}

		// Token: 0x06003B16 RID: 15126 RVA: 0x001156CC File Offset: 0x001138CC
		protected void method_21(CEvent cevent_0)
		{
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(this.m_nInstanceId);
			if (playlist.m_gameMode == "GameModeTown")
			{
				if (this.m_nInstanceId == MonoSingleton<AppManager>.Instance.m_playlistId)
				{
					return;
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>().Boolean_1 = false;
				MonoSingleton<GameFlowManager>.Instance.method_8(this.m_nInstanceId);
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().method_3(this.m_nInstanceId);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().Boolean_1 = true;
			}
		}

		// Token: 0x06003B17 RID: 15127 RVA: 0x00115768 File Offset: 0x00113968
		public void method_22()
		{
			if (LevelLockingManager.smethod_0().method_12(this.m_nInstanceId))
			{
				this.Boolean_6 = false;
			}
			else if (MatchmakingService.smethod_0(MatchmakingService.MatchmakingService_0.method_1(this.m_nInstanceId).m_gameMode) == GamemodeType.GamemodeTown)
			{
				this.Boolean_6 = true;
			}
			else if (GroupManager.smethod_0().method_20())
			{
				this.Boolean_6 = true;
			}
			else
			{
				this.Boolean_6 = false;
			}
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = QuestUIDataManager.smethod_0().method_19(this.m_nInstanceId, 0);
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE2 = QuestUIDataManager.smethod_0().method_19(this.m_nInstanceId, 1);
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE3 = QuestUIDataManager.smethod_0().method_19(this.m_nInstanceId, 2);
			if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE && npc_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE && npc_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this.m_questStatus = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE;
			}
			if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE || npc_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE || npc_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this.m_questStatus = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE;
			}
			if (this.m_questStatus == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this.mc_QuestIcon.gotoAndStop("normal");
			}
			else if (this.m_questStatus == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this.mc_QuestIcon.gotoAndStop("daily");
			}
			if (this.mc_TaskIcon != null)
			{
				this.mc_TaskIcon.visible = false;
			}
			if (!this.m_bIsTown)
			{
				this.m_bIsBossInstance = InstanceMapSelectControl.smethod_3(this.m_nInstanceId);
			}
			else
			{
				this.m_bIsBossInstance = false;
			}
		}

		// Token: 0x04002963 RID: 10595
		private MovieClip mc_ButtonClip;

		// Token: 0x04002964 RID: 10596
		public bool m_bIsTown;

		// Token: 0x04002965 RID: 10597
		public int m_nInstanceId;

		// Token: 0x04002966 RID: 10598
		public int m_nTownId;

		// Token: 0x04002967 RID: 10599
		protected MovieClip mc_QuestIcon;

		// Token: 0x04002968 RID: 10600
		protected MovieClip mc_BossIcon;

		// Token: 0x04002969 RID: 10601
		protected MovieClip mc_TaskIcon;

		// Token: 0x0400296A RID: 10602
		private bool m_bIsBossInstance;

		// Token: 0x0400296B RID: 10603
		private NpcTitleMgr.NPC_ICON_TYPE m_questStatus;
	}

	// Token: 0x02000875 RID: 2165
	private class InstanceMapPanel : GClass51
	{
		// Token: 0x06003B19 RID: 15129 RVA: 0x00115898 File Offset: 0x00113A98
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			this.mc_root.stopAll();
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: InstanceMapPanel onInit() 'mc_root' is null! InstanceMapPanel won't work!!!");
				return;
			}
			this.mc_QuitButton = new GClass25();
			this.mc_QuitButton.method_0(this.mc_root.getChildByName<MovieClip>("mc_cover").getChildByName<MovieClip>("mc_Quit"));
			this.mc_QuitButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			this.tf_TownName = this.mc_root.getChildByName<MovieClip>("mc_cover").getChildByName<TextField>("Mc_name");
			this.tf_TownName.text = LocalizedString.smethod_0(new LocalizedString("Instance_" + MonoSingleton<AppManager>.Instance.m_playlistId.ToString()));
			MovieClip childByName = this.mc_root.getChildByName<MovieClip>("mc_target");
			childByName.mouseEnabled = true;
			MovieClip childByName2 = childByName.getChildByName<MovieClip>("mc_icon");
			childByName2.mouseEnabled = false;
			this.mc_UpIcon = childByName2.getChildByName<MovieClip>("mc_up");
			this.mc_DownIcon = childByName2.getChildByName<MovieClip>("mc_down");
			this.mc_UpIcon.mouseEnabled = false;
			this.mc_DownIcon.mouseEnabled = false;
			MovieClip childByName3 = childByName.getChildByName<MovieClip>("mc_direction");
			childByName3.mouseEnabled = true;
			this.m_UpButton = new GClass25();
			this.m_UpButton.method_0(childByName3.getChildByName<MovieClip>("mc_up"));
			this.m_UpButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_10));
			this.m_DownButton = new GClass25();
			this.m_DownButton.method_0(childByName3.getChildByName<MovieClip>("mc_down"));
			this.m_DownButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			this.tf_UpTip = childByName3.getChildByName<TextField>("tf_up");
			this.tf_DownTip = childByName3.getChildByName<TextField>("tf_down");
			this.tf_UpTip.text = string.Empty;
			this.tf_DownTip.text = string.Empty;
			this.m_Energy = this.mc_root.getChildByName<MovieClip>("mc_energy");
			this.tf_Energy = this.m_Energy.getChildByName<TextField>("tf_energy");
			this.m_Energy.addFrameScript("Full", new EventDispatcher.EventCallback(this.method_5));
			this.m_Energy.addFrameScript("Normal", new EventDispatcher.EventCallback(this.method_5));
			this.m_Energy.addFrameScript("empty", new EventDispatcher.EventCallback(this.method_5));
			this.m_PvPButton = new GClass25();
			this.m_PvPButton.method_0(this.mc_root.getChildByName<MovieClip>("mc_PvPBtn"));
			this.m_PvPButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
			this.m_PvPQuest = this.mc_root.getChildByName<MovieClip>("mc_pvpQuestMark");
			this.m_PvPQuest.visible = false;
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06003B1B RID: 15131 RVA: 0x00027ACD File Offset: 0x00025CCD
		// (set) Token: 0x06003B1A RID: 15130 RVA: 0x00027AA8 File Offset: 0x00025CA8
		public virtual bool Boolean_0
		{
			get
			{
				return this.mc_root != null && this.mc_root.visible;
			}
			set
			{
				if (this.mc_root != null)
				{
					if (value)
					{
						this.method_7();
						this.method_8();
					}
					this.mc_root.visible = value;
				}
			}
		}

		// Token: 0x06003B1C RID: 15132 RVA: 0x00115B98 File Offset: 0x00113D98
		private void method_5(CEvent cevent_0)
		{
			this.tf_Energy = this.m_Energy.getChildByName<TextField>("tf_energy");
			this.tf_Energy.text = Utility.smethod_8(ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_6());
			this.m_Energy.removeFrameScript("Full", new EventDispatcher.EventCallback(this.method_5));
			this.m_Energy.removeFrameScript("Normal", new EventDispatcher.EventCallback(this.method_5));
			this.m_Energy.removeFrameScript("empty", new EventDispatcher.EventCallback(this.method_5));
		}

		// Token: 0x06003B1D RID: 15133 RVA: 0x00115C2C File Offset: 0x00113E2C
		private void method_6(CEvent cevent_0)
		{
			if (!LobbyManager.smethod_0().method_0() && GroupManager.smethod_0().method_18() && !GroupManager.smethod_0().method_19())
			{
				return;
			}
			if (!LobbyManager.smethod_0().method_0() && !GroupManager.smethod_0().method_18() && ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8() < LevelingManager.PVP_UNLOCK_LEVEL)
			{
				return;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>().Boolean_1 = false;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = true;
		}

		// Token: 0x06003B1E RID: 15134 RVA: 0x00115CB4 File Offset: 0x00113EB4
		private void method_7()
		{
			int num = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_6();
			this.tf_Energy.text = Utility.smethod_8(num);
			if (num > this.m_nNormalEnergy)
			{
				this.m_Energy.gotoAndStop("Full");
			}
			else if (num <= 0)
			{
				this.m_Energy.gotoAndStop("empty");
			}
			else
			{
				this.m_Energy.gotoAndStop("Normal");
			}
			if (ServiceWrapperBase<QuestServiceWrapper>.Instance.method_21())
			{
				this.m_PvPQuest.visible = true;
			}
			else
			{
				this.m_PvPQuest.visible = false;
			}
		}

		// Token: 0x06003B1F RID: 15135 RVA: 0x00115D44 File Offset: 0x00113F44
		private void method_8()
		{
			int num = InstanceMapSelectControl.smethod_2();
			this.tf_TownName.text = LocalizedString.smethod_0(new LocalizedString("Instance_" + num.ToString()));
			int num2 = ((num != 5) ? (num + 1) : 3);
			int num3 = ((num != 3) ? (num - 1) : 5);
			if (!LevelLockingManager.smethod_0().method_12(num2))
			{
				this.m_UpButton.Boolean_1 = true;
				this.tf_UpTip.text = LocalizedString.smethod_0(new LocalizedString("Map_Go")) + LocalizedString.smethod_0(new LocalizedString("Instance_" + num2.ToString()));
				if (InstanceMapSelectControl.smethod_6(num2))
				{
					this.mc_UpIcon.visible = true;
					this.mc_UpIcon.gotoAndPlay(1);
				}
				else
				{
					this.mc_UpIcon.visible = false;
				}
			}
			else
			{
				this.m_UpButton.Boolean_1 = false;
				this.tf_UpTip.text = string.Empty;
				this.mc_UpIcon.visible = false;
			}
			if (!LevelLockingManager.smethod_0().method_12(num3))
			{
				this.m_DownButton.Boolean_1 = true;
				this.tf_DownTip.text = LocalizedString.smethod_0(new LocalizedString("Map_Go")) + LocalizedString.smethod_0(new LocalizedString("Instance_" + num3.ToString()));
				if (InstanceMapSelectControl.smethod_6(num3))
				{
					this.mc_DownIcon.visible = true;
					this.mc_DownIcon.gotoAndPlay(1);
				}
				else
				{
					this.mc_DownIcon.visible = false;
				}
			}
			else
			{
				this.m_DownButton.Boolean_1 = false;
				this.tf_DownTip.text = string.Empty;
				this.mc_DownIcon.visible = false;
			}
		}

		// Token: 0x06003B20 RID: 15136 RVA: 0x00027AE4 File Offset: 0x00025CE4
		private void method_9()
		{
			TownInstanceSelectionControl.smethod_8(InstanceMapSelectControl.smethod_2());
			(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>() as uniNewInstanceSelectView).method_6(InstanceMapSelectControl.smethod_2());
			this.method_8();
		}

		// Token: 0x06003B21 RID: 15137 RVA: 0x00115EF4 File Offset: 0x001140F4
		protected void method_10(CEvent cevent_0)
		{
			int num = InstanceMapSelectControl.smethod_2();
			int num2 = ((num != 5) ? (num + 1) : 3);
			InstanceMapSelectControl.smethod_1(num2);
			this.method_9();
		}

		// Token: 0x06003B22 RID: 15138 RVA: 0x00115F20 File Offset: 0x00114120
		protected void method_11(CEvent cevent_0)
		{
			int num = InstanceMapSelectControl.smethod_2();
			int num2 = ((num != 3) ? (num - 1) : 5);
			InstanceMapSelectControl.smethod_1(num2);
			this.method_9();
		}

		// Token: 0x06003B23 RID: 15139 RVA: 0x00027B14 File Offset: 0x00025D14
		protected void method_12(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>().Boolean_1 = false;
		}

		// Token: 0x06003B24 RID: 15140 RVA: 0x00115F4C File Offset: 0x0011414C
		public void method_13(List<uniNewInstanceSelectView.NewInstanceButton> list_1)
		{
			for (int i = 0; i < list_1.Count; i++)
			{
				if (this.mc_root.contains(list_1[i].DisplayObjectContainer_0))
				{
					this.mc_root.removeChild(list_1[i].DisplayObjectContainer_0);
				}
			}
		}

		// Token: 0x06003B25 RID: 15141 RVA: 0x00115F9C File Offset: 0x0011419C
		public void method_14(List<uniNewInstanceSelectView.NewInstanceButton> list_1)
		{
			for (int i = 0; i < list_1.Count; i++)
			{
				this.method_15(list_1[i]);
			}
		}

		// Token: 0x06003B26 RID: 15142 RVA: 0x00027B2B File Offset: 0x00025D2B
		public void method_15(uniNewInstanceSelectView.NewInstanceButton newInstanceButton_0)
		{
			if (!this.mc_root.contains(newInstanceButton_0.DisplayObjectContainer_0))
			{
				this.mc_root.addChild(newInstanceButton_0.DisplayObjectContainer_0);
				newInstanceButton_0.method_22();
			}
		}

		// Token: 0x0400296C RID: 10604
		public MovieClip mc_root;

		// Token: 0x0400296D RID: 10605
		protected GClass25 mc_QuitButton;

		// Token: 0x0400296E RID: 10606
		protected TextField tf_TownName;

		// Token: 0x0400296F RID: 10607
		protected GClass25 m_UpButton;

		// Token: 0x04002970 RID: 10608
		protected GClass25 m_DownButton;

		// Token: 0x04002971 RID: 10609
		protected TextField tf_UpTip;

		// Token: 0x04002972 RID: 10610
		protected TextField tf_DownTip;

		// Token: 0x04002973 RID: 10611
		protected MovieClip mc_UpIcon;

		// Token: 0x04002974 RID: 10612
		protected MovieClip mc_DownIcon;

		// Token: 0x04002975 RID: 10613
		protected GClass25 m_PvPButton;

		// Token: 0x04002976 RID: 10614
		protected MovieClip m_Energy;

		// Token: 0x04002977 RID: 10615
		protected TextField tf_Energy;

		// Token: 0x04002978 RID: 10616
		protected MovieClip m_PvPQuest;

		// Token: 0x04002979 RID: 10617
		private int m_nNormalEnergy = 2;
	}
}
