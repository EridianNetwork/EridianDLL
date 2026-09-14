using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x02000851 RID: 2129
public class uniInstanceView : InstanceView
{
	// Token: 0x060039CA RID: 14794 RVA: 0x000268E2 File Offset: 0x00024AE2
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("instanceSelect_Jan2014.swf", "whole", new FuncLoad(this.method_5));
	}

	// Token: 0x060039CB RID: 14795 RVA: 0x0010E380 File Offset: 0x0010C580
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._instancePanel);
		this._instancePanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("instanceSelect_Jan2014.swf");
	}

	// Token: 0x060039CC RID: 14796 RVA: 0x00026914 File Offset: 0x00024B14
	private void method_5(MovieClip movieClip_0)
	{
		this._instancePanel = new uniInstanceView.InstancePanel();
		this._instancePanel.method_0(movieClip_0);
		this._instancePanel.Boolean_0 = false;
	}

	// Token: 0x060039CD RID: 14797 RVA: 0x0002693A File Offset: 0x00024B3A
	public override void vmethod_5()
	{
		base.vmethod_5();
		if (!this.m_bDifficultyShown)
		{
			this.m_bDifficultyShown = true;
			this._instancePanel.method_15();
		}
	}

	// Token: 0x060039CE RID: 14798 RVA: 0x0002695C File Offset: 0x00024B5C
	public override void vmethod_6()
	{
		base.vmethod_6();
		if (this._instancePanel != null)
		{
			this._instancePanel.method_19();
		}
		this.m_bDifficultyShown = false;
	}

	// Token: 0x060039CF RID: 14799 RVA: 0x0002697E File Offset: 0x00024B7E
	public override void vmethod_7()
	{
		base.vmethod_7();
		if (this._instancePanel != null)
		{
			this._instancePanel.method_18(this.m_bDifficultyShown);
		}
		this.m_bDifficultyShown = false;
	}

	// Token: 0x060039D0 RID: 14800 RVA: 0x0010E3D0 File Offset: 0x0010C5D0
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_31(this._instancePanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			this._instancePanel.method_5();
		}
		else
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_37(this._instancePanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		}
	}

	// Token: 0x04002881 RID: 10369
	private uniInstanceView.InstancePanel _instancePanel;

	// Token: 0x02000852 RID: 2130
	private class InstanceButton : GClass25
	{
		// Token: 0x060039D2 RID: 14802 RVA: 0x000269C4 File Offset: 0x00024BC4
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.Update();
		}

		// Token: 0x060039D3 RID: 14803 RVA: 0x0010E454 File Offset: 0x0010C654
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = base.DisplayObjectContainer_0 as MovieClip;
			this.mc_QuestTrack = this.mc_root.getChildByName<MovieClip>("mc_QuestTrack");
			this.tf_InstanceLevel = this.mc_root.getChildByName<TextField>("tf_DifficultyTips");
			this.mc_root.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
		}

		// Token: 0x060039D4 RID: 14804 RVA: 0x000269D2 File Offset: 0x00024BD2
		protected void method_19(CEvent cevent_0)
		{
			this.Update();
		}

		// Token: 0x060039D5 RID: 14805 RVA: 0x000269DA File Offset: 0x00024BDA
		public void method_20(string string_6)
		{
			this.mc_QuestTrack.gotoAndStop(string_6);
		}

		// Token: 0x060039D6 RID: 14806 RVA: 0x0010E4C4 File Offset: 0x0010C6C4
		private void Update()
		{
			if (!this.m_bShowQuestTrack && !this.m_bShowDailyQuestTrack)
			{
				this.mc_QuestTrack.visible = false;
			}
			else
			{
				this.mc_QuestTrack.visible = true;
			}
			this.tf_InstanceLevel.textFormat.color = this.m_color;
			this.tf_InstanceLevel.text = this.m_strContent;
		}

		// Token: 0x04002882 RID: 10370
		public MovieClip mc_root;

		// Token: 0x04002883 RID: 10371
		public MovieClip mc_QuestTrack;

		// Token: 0x04002884 RID: 10372
		public TextField tf_InstanceLevel;

		// Token: 0x04002885 RID: 10373
		public string m_strContent = string.Empty;

		// Token: 0x04002886 RID: 10374
		public Color m_color = Color.white;

		// Token: 0x04002887 RID: 10375
		public bool m_bShowQuestTrack;

		// Token: 0x04002888 RID: 10376
		public bool m_bShowDailyQuestTrack;
	}

	// Token: 0x02000853 RID: 2131
	private class InstancePanel : GClass51
	{
		// Token: 0x060039D8 RID: 14808 RVA: 0x0010E524 File Offset: 0x0010C724
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: InstancePanel onInit() 'mc_root' is null! InstancePanel won't work!!!");
				return;
			}
			this.mc_Top = this.mc_root.getChildByName<MovieClip>("mc_top");
			this.mc_Bottom = this.mc_root.getChildByName<MovieClip>("mcNPCDialog");
			this.mc_Top.visible = false;
			this.mc_Bottom.visible = false;
			this._CommonBtn = new uniInstanceView.InstanceButton();
			this._CommonBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_Common_Button"));
			this._CommonBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			this._CommonBtn.Boolean_1 = false;
			this._HeroBtn = new uniInstanceView.InstanceButton();
			this._HeroBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_Hero_Button"));
			this._HeroBtn.Boolean_6 = false;
			this._HeroBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			this._HeroBtn.Boolean_1 = false;
			this._HellBtn = new uniInstanceView.InstanceButton();
			this._HellBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_Hell_Button"));
			this._HellBtn.Boolean_6 = false;
			this._HellBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_13));
			this._HellBtn.Boolean_1 = false;
			this.mc_BossClip = this.mc_Bottom.getChildByName<MovieClip>("mc_speical");
			this.tf_Description = this.mc_Bottom.getChildByName<TextField>("textDescription");
			this.mc_BossClip.stopAll();
			this.mc_BossName = this.mc_BossClip.getChildByName<MovieClip>("mc_bossName");
			this.mc_BossNameEffect = this.mc_BossClip.getChildByName<MovieClip>("mc_bossnameEffect");
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x060039DA RID: 14810 RVA: 0x00026A13 File Offset: 0x00024C13
		// (set) Token: 0x060039D9 RID: 14809 RVA: 0x000269E8 File Offset: 0x00024BE8
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
					}
					this.mc_Top.visible = value;
					this.mc_root.visible = value;
				}
			}
		}

		// Token: 0x060039DB RID: 14811 RVA: 0x00026A2A File Offset: 0x00024C2A
		public void method_5()
		{
			this.mc_root.visible = true;
			this.mc_Top.visible = true;
			this.mc_root.gotoAndStop(1);
		}

		// Token: 0x060039DC RID: 14812 RVA: 0x00026A55 File Offset: 0x00024C55
		public void method_6()
		{
			this.mc_Top.visible = false;
			this.mc_root.visible = false;
		}

		// Token: 0x060039DD RID: 14813 RVA: 0x0010E70C File Offset: 0x0010C90C
		private void method_7()
		{
			this.method_9();
			switch (LevelLockingManager.smethod_0().method_13(InstanceBehaviour.smethod_0()))
			{
			case 0:
				this._CommonBtn.Boolean_6 = true;
				this._HeroBtn.Boolean_6 = false;
				this._HellBtn.Boolean_6 = false;
				break;
			case 1:
				this._CommonBtn.Boolean_6 = true;
				this._HeroBtn.Boolean_6 = true;
				this._HellBtn.Boolean_6 = false;
				break;
			case 2:
			case 3:
				this._CommonBtn.Boolean_6 = true;
				this._HeroBtn.Boolean_6 = true;
				this._HellBtn.Boolean_6 = true;
				break;
			default:
				this._CommonBtn.Boolean_6 = false;
				this._HeroBtn.Boolean_6 = false;
				this._HellBtn.Boolean_6 = false;
				break;
			}
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = QuestUIDataManager.smethod_0().method_19(InstanceBehaviour.smethod_0(), 0);
			if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this._CommonBtn.m_bShowQuestTrack = true;
				this._CommonBtn.m_bShowDailyQuestTrack = false;
				this._CommonBtn.method_20("normal");
			}
			else if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this._CommonBtn.m_bShowQuestTrack = false;
				this._CommonBtn.m_bShowDailyQuestTrack = true;
				this._CommonBtn.method_20("daily");
			}
			else
			{
				this._CommonBtn.m_bShowQuestTrack = false;
				this._CommonBtn.m_bShowDailyQuestTrack = false;
			}
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE2 = QuestUIDataManager.smethod_0().method_19(InstanceBehaviour.smethod_0(), 1);
			if (npc_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this._HeroBtn.m_bShowQuestTrack = true;
				this._HeroBtn.m_bShowDailyQuestTrack = true;
				this._HeroBtn.method_20("normal");
			}
			else if (npc_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this._HeroBtn.m_bShowQuestTrack = false;
				this._HeroBtn.m_bShowDailyQuestTrack = true;
				this._HeroBtn.method_20("daily");
			}
			else
			{
				this._HeroBtn.m_bShowQuestTrack = false;
				this._HeroBtn.m_bShowDailyQuestTrack = false;
			}
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE3 = QuestUIDataManager.smethod_0().method_19(InstanceBehaviour.smethod_0(), 2);
			if (npc_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this._HellBtn.m_bShowQuestTrack = true;
				this._HellBtn.m_bShowDailyQuestTrack = false;
				this._HellBtn.method_20("normal");
			}
			else if (npc_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this._HellBtn.m_bShowQuestTrack = false;
				this._HellBtn.m_bShowDailyQuestTrack = true;
				this._HellBtn.method_20("daily");
			}
			else
			{
				this._HellBtn.m_bShowQuestTrack = false;
				this._HellBtn.m_bShowDailyQuestTrack = false;
			}
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(InstanceBehaviour.smethod_0());
			int normal_LevelMin = playlist.m_normal_LevelMin;
			int hard_LevelMin = playlist.m_hard_LevelMin;
			int hell_LevelMin = playlist.m_hell_LevelMin;
			int num = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
			this.method_8(this._CommonBtn, num, normal_LevelMin);
			this.method_8(this._HeroBtn, num, hard_LevelMin);
			this.method_8(this._HellBtn, num, hell_LevelMin);
		}

		// Token: 0x060039DE RID: 14814 RVA: 0x0010E9D0 File Offset: 0x0010CBD0
		private void method_8(uniInstanceView.InstanceButton instanceButton_0, int int_0, int int_1)
		{
			if (int_0 - int_1 >= 5)
			{
				instanceButton_0.m_color = Color.grey;
			}
			else if (int_0 - int_1 >= 2 && int_0 - int_1 <= 4)
			{
				instanceButton_0.m_color = Color.green;
			}
			else if (int_0 - int_1 >= -1 && int_0 - int_1 <= 1)
			{
				instanceButton_0.m_color = Color.yellow;
			}
			else if (int_0 - int_1 >= -4 && int_0 - int_1 <= -2)
			{
				instanceButton_0.m_color = Color.Lerp(Color.red, Color.yellow, 0.5f);
			}
			else
			{
				instanceButton_0.m_color = Color.red;
			}
			instanceButton_0.m_strContent = Utility.smethod_5("Lv.", Utility.smethod_8(int_1));
		}

		// Token: 0x060039DF RID: 14815 RVA: 0x0010EA70 File Offset: 0x0010CC70
		private void method_9()
		{
			if (!this._CommonBtn.hasEventListener("onClickCommonButton"))
			{
				this._CommonBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			}
			if (!this._HeroBtn.hasEventListener("onClickHeroButton"))
			{
				this._HeroBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			}
			if (!this._HellBtn.hasEventListener("onClickHellButton"))
			{
				this._HellBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_13));
			}
		}

		// Token: 0x060039E0 RID: 14816 RVA: 0x0010EB0C File Offset: 0x0010CD0C
		private void method_10()
		{
			this._CommonBtn.removeEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			this._HeroBtn.removeEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			this._HellBtn.removeEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_13));
		}

		// Token: 0x060039E1 RID: 14817 RVA: 0x00026A6F File Offset: 0x00024C6F
		private void method_11(CEvent cevent_0)
		{
			this.method_14(InstanceBehaviour.smethod_0(), ELevelDifficulty.Normal);
		}

		// Token: 0x060039E2 RID: 14818 RVA: 0x00026A7D File Offset: 0x00024C7D
		private void method_12(CEvent cevent_0)
		{
			this.method_14(InstanceBehaviour.smethod_0(), ELevelDifficulty.Hard);
		}

		// Token: 0x060039E3 RID: 14819 RVA: 0x00026A8B File Offset: 0x00024C8B
		private void method_13(CEvent cevent_0)
		{
			this.method_14(InstanceBehaviour.smethod_0(), ELevelDifficulty.Hell);
		}

		// Token: 0x060039E4 RID: 14820 RVA: 0x00026A99 File Offset: 0x00024C99
		private void method_14(int int_0, ELevelDifficulty elevelDifficulty_0 = ELevelDifficulty.Normal)
		{
			if (int_0 != 0)
			{
				MonoSingleton<AppManager>.Instance.m_difficulty = elevelDifficulty_0;
				this.m_nSelectInstanceId = int_0;
				this.method_10();
				this.method_16();
			}
		}

		// Token: 0x060039E5 RID: 14821 RVA: 0x0010EB70 File Offset: 0x0010CD70
		public void method_15()
		{
			this.mc_Bottom.visible = true;
			this._CommonBtn.Boolean_1 = true;
			this._HeroBtn.Boolean_1 = true;
			this._HellBtn.Boolean_1 = true;
			this.method_7();
			this.mc_root.gotoAndPlay("fadein");
			this.tf_Description.text = LocalizedString.smethod_0(new LocalizedString("Instance_" + InstanceBehaviour.smethod_0() + "_des"));
			if (InstanceBehaviour.smethod_2())
			{
				this.mc_BossClip.gotoAndPlay(1);
				this.mc_BossName.gotoAndStop(InstanceBehaviour.smethod_3());
				this.mc_BossNameEffect.gotoAndStop(InstanceBehaviour.smethod_3());
			}
			else
			{
				this.mc_BossClip.gotoAndStop(1);
			}
		}

		// Token: 0x060039E6 RID: 14822 RVA: 0x00026ABC File Offset: 0x00024CBC
		public void method_16()
		{
			TownInstanceSelectionControl.smethod_3(false);
			this.mc_root.gotoAndPlay("fadeout");
			this.mc_root.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_17));
		}

		// Token: 0x060039E7 RID: 14823 RVA: 0x0010EC3C File Offset: 0x0010CE3C
		private void method_17(CEvent cevent_0)
		{
			this.mc_root.removeFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_17));
			this.mc_root.visible = false;
			InstanceBehaviour.smethod_4();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceView>().Boolean_1 = false;
			if (LobbyManager.smethod_0().Lobby_1 != null)
			{
				LobbyManager.smethod_0().method_24();
				LobbyManager.smethod_0().method_26();
			}
			LobbyManager.smethod_0().method_9(this.m_nSelectInstanceId);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().m_gameMode = GamemodeType.GamemodePvE;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = true;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().vmethod_6();
		}

		// Token: 0x060039E8 RID: 14824 RVA: 0x0010ECFC File Offset: 0x0010CEFC
		public void method_18(bool bool_0)
		{
			if (bool_0)
			{
				this.mc_root.gotoAndPlay("fadeout");
				this.mc_root.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_20));
			}
			else
			{
				this.mc_root.gotoAndPlay("ESC fadeout");
				InstanceBehaviour.smethod_4();
			}
		}

		// Token: 0x060039E9 RID: 14825 RVA: 0x00026AF1 File Offset: 0x00024CF1
		public void method_19()
		{
			this.mc_BossClip.gotoAndStop(1);
			this.mc_root.gotoAndPlay("btn_fadeout");
			InstanceBehaviour.smethod_4();
		}

		// Token: 0x060039EA RID: 14826 RVA: 0x00026B19 File Offset: 0x00024D19
		private void method_20(CEvent cevent_0)
		{
			this.mc_root.removeFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_20));
			this.mc_root.visible = false;
			InstanceBehaviour.smethod_4();
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_37(this);
		}

		// Token: 0x04002889 RID: 10377
		public MovieClip mc_root;

		// Token: 0x0400288A RID: 10378
		public MovieClip mc_Top;

		// Token: 0x0400288B RID: 10379
		public MovieClip mc_Bottom;

		// Token: 0x0400288C RID: 10380
		public uniInstanceView.InstanceButton _CommonBtn;

		// Token: 0x0400288D RID: 10381
		public uniInstanceView.InstanceButton _HeroBtn;

		// Token: 0x0400288E RID: 10382
		public uniInstanceView.InstanceButton _HellBtn;

		// Token: 0x0400288F RID: 10383
		public MovieClip mc_BossClip;

		// Token: 0x04002890 RID: 10384
		public MovieClip mc_BossName;

		// Token: 0x04002891 RID: 10385
		public MovieClip mc_BossNameEffect;

		// Token: 0x04002892 RID: 10386
		public TextField tf_Description;

		// Token: 0x04002893 RID: 10387
		private int m_nSelectInstanceId;
	}
}
