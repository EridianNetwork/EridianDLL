using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x0200084F RID: 2127
public class uniInstanceInfoView : InstanceInfoView
{
	// Token: 0x060039B2 RID: 14770 RVA: 0x0010D57C File Offset: 0x0010B77C
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_InstanceIcon.Clear();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Instance_selection_3D_resource.swf", "Mc_Whole", new FuncLoad(this.method_5));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Instance_selection_Frame.swf", "Mc_whole", new FuncLoad(this.method_6));
	}

	// Token: 0x060039B3 RID: 14771 RVA: 0x0010D5F0 File Offset: 0x0010B7F0
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.m_InstanceIcon.Clear();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._instanceInfoPanel);
		this._instanceInfoPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Instance_selection_3D_resource.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Instance_selection_Frame.swf");
	}

	// Token: 0x060039B4 RID: 14772 RVA: 0x0010D664 File Offset: 0x0010B864
	private void method_5(MovieClip movieClip_0)
	{
		this.m_InstanceIcon.Clear();
		for (int i = 0; i < movieClip_0.numChildren; i++)
		{
			if (movieClip_0.getChildAt(i).name.StartsWith("mc_Instance_"))
			{
				this.m_InstanceIcon.Add(movieClip_0.getChildAt(i).name, movieClip_0.getChildAt(i) as MovieClip);
			}
		}
	}

	// Token: 0x060039B5 RID: 14773 RVA: 0x00026856 File Offset: 0x00024A56
	private void method_6(MovieClip movieClip_0)
	{
		this._instanceInfoPanel = new uniInstanceInfoView.InstanceInfoPanel();
		this._instanceInfoPanel.method_0(movieClip_0);
	}

	// Token: 0x060039B6 RID: 14774 RVA: 0x0010D6C8 File Offset: 0x0010B8C8
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._instanceInfoPanel != null)
		{
			if (bool_0)
			{
				this._instanceInfoPanel.Boolean_0 = true;
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._instanceInfoPanel);
				return;
			}
			this._instanceInfoPanel.Boolean_0 = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._instanceInfoPanel);
		}
	}

	// Token: 0x060039B7 RID: 14775 RVA: 0x0010D738 File Offset: 0x0010B938
	public MovieClip method_7(int int_0)
	{
		string text = "mc_Instance_" + int_0.ToString();
		if (this.m_InstanceIcon.ContainsKey(text))
		{
			return this.m_InstanceIcon[text];
		}
		return null;
	}

	// Token: 0x04002868 RID: 10344
	private uniInstanceInfoView.InstanceInfoPanel _instanceInfoPanel;

	// Token: 0x04002869 RID: 10345
	protected Dictionary<string, MovieClip> m_InstanceIcon = new Dictionary<string, MovieClip>();

	// Token: 0x02000850 RID: 2128
	private class InstanceInfoPanel : GClass51
	{
		// Token: 0x060039B9 RID: 14777 RVA: 0x0010D774 File Offset: 0x0010B974
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			this.mc_root.stopAll();
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: InstanceInfoPanel onInit() 'mc_root' is null! InstanceInfoPanel won't work!!!");
				return;
			}
			this.mc_total = this.mc_root.getChildByName<MovieClip>("mc_total");
			this.mc_Background = this.mc_total.getChildByName<MovieClip>("mc_background");
			this.mc_Background.mouseEnabled = true;
			this.m_QuestField = new List<TextField>();
			this.m_QuestField.Clear();
			this.mc_StartButton = new GClass25();
			this.mc_StartButton.method_0(this.mc_total.getChildByName<MovieClip>("mc_btnStart"));
			this.mc_StartButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_15));
			this.mc_CloseButton = new GClass25();
			this.mc_CloseButton.method_0(this.mc_total.getChildByName<MovieClip>("mcBtnClose"));
			this.mc_CloseButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_14));
			this.mc_NormalButton = new GClass40();
			this.mc_NormalButton.method_0(this.mc_total.getChildByName<MovieClip>("mc_normal_btn"));
			this.mc_NormalButton.String_2 = "Normal";
			this.mc_NormalButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_11));
			this.mc_NormalButton.String_1 = "Difficulty";
			this.mc_NormalButton.bool_5 = false;
			this.mc_HeroButton = new GClass40();
			this.mc_HeroButton.method_0(this.mc_total.getChildByName<MovieClip>("mc_hero_btn"));
			this.mc_HeroButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_12));
			this.mc_HeroButton.String_1 = "Difficulty";
			this.mc_HeroButton.bool_5 = false;
			this.mc_HellButton = new GClass40();
			this.mc_HellButton.method_0(this.mc_total.getChildByName<MovieClip>("mc_hell_btn"));
			this.mc_HellButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_13));
			this.mc_HellButton.String_1 = "Difficulty";
			this.mc_HellButton.bool_5 = false;
			this.mc_CommonQuest = this.mc_total.getChildByName<MovieClip>("mc_CommonQuestTrack");
			this.mc_HeroQuest = this.mc_total.getChildByName<MovieClip>("mc_HeroQuestTrack");
			this.mc_HellQuest = this.mc_total.getChildByName<MovieClip>("mc_HellQuestTrack");
			this.mc_BossIcon = this.mc_total.getChildByName<MovieClip>("mc_BossIcon");
			this.mc_RankIcon = this.mc_total.getChildByName<MovieClip>("mc_rank");
			this.mc_RankIcon.visible = false;
			this.mc_InstanceIcon = this.mc_total.getChildByName<MovieClip>("mc_instanceIcon");
			this.tf_Rank = this.mc_total.getChildByName<TextField>("tf_Rank");
			this.tf_Level = this.mc_total.getChildByName<TextField>("tf_level");
			this.tf_LevelTitle = this.mc_total.getChildByName<TextField>("tf_level_title");
			this.tf_DescriptionTitle = this.mc_total.getChildByName<TextField>("tf_description_title");
			this.tf_Description = this.mc_total.getChildByName<TextField>("textQuestDescription");
			this.tf_QuestTitle = this.mc_total.getChildByName<TextField>("tf_QuestTitle");
			this.tf_Rank.visible = false;
			this.tf_LevelTitle.text = LocalizedString.smethod_0(new LocalizedString("InstanceLevel_Rec"));
			this.tf_QuestTitle.text = LocalizedString.smethod_0(new LocalizedString("Quest_Ongoing"));
			this.tf_DescriptionTitle.text = LocalizedString.smethod_0(new LocalizedString("Level_Des"));
			TextField childByName = this.mc_total.getChildByName<TextField>("mcTitleBoard0");
			TextField childByName2 = this.mc_total.getChildByName<TextField>("mcTitleBoard1");
			TextField childByName3 = this.mc_total.getChildByName<TextField>("mcTitleBoard2");
			TextField childByName4 = this.mc_total.getChildByName<TextField>("mcTitleBoard3");
			TextField childByName5 = this.mc_total.getChildByName<TextField>("mcTitleBoard4");
			this.m_QuestField.Add(childByName);
			this.m_QuestField.Add(childByName2);
			this.m_QuestField.Add(childByName3);
			this.m_QuestField.Add(childByName4);
			this.m_QuestField.Add(childByName5);
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x060039BB RID: 14779 RVA: 0x00026870 File Offset: 0x00024A70
		// (set) Token: 0x060039BA RID: 14778 RVA: 0x0010DBC0 File Offset: 0x0010BDC0
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
					this.mc_root.visible = value;
					if (value)
					{
						this.mc_NormalButton.Boolean_3 = true;
						this.m_difficulty = ELevelDifficulty.Normal;
						this.mc_StartButton.Boolean_6 = true;
						this.method_5();
						this.method_6();
						this.method_8();
						this.mc_root.gotoAndPlay("fadein");
						return;
					}
					if (this.mc_InstanceIcon.contains(this.newIconMC))
					{
						this.mc_InstanceIcon.removeChild(this.newIconMC);
					}
				}
			}
		}

		// Token: 0x060039BC RID: 14780 RVA: 0x0010DC4C File Offset: 0x0010BE4C
		protected void method_5()
		{
			int num = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().method_4();
			switch (LevelLockingManager.smethod_0().method_13(num))
			{
			case 0:
				this.mc_NormalButton.Boolean_6 = true;
				this.mc_HeroButton.Boolean_6 = false;
				this.mc_HellButton.Boolean_6 = false;
				break;
			case 1:
				this.mc_NormalButton.Boolean_6 = true;
				this.mc_HeroButton.Boolean_6 = true;
				this.mc_HellButton.Boolean_6 = false;
				break;
			case 2:
			case 3:
				this.mc_NormalButton.Boolean_6 = true;
				this.mc_HeroButton.Boolean_6 = true;
				this.mc_HellButton.Boolean_6 = true;
				break;
			default:
				this.mc_NormalButton.Boolean_6 = false;
				this.mc_HeroButton.Boolean_6 = false;
				this.mc_HellButton.Boolean_6 = false;
				break;
			}
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = QuestUIDataManager.smethod_0().method_19(num, 0);
			if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this.mc_CommonQuest.visible = true;
				this.mc_CommonQuest.gotoAndStop("normal");
			}
			else if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this.mc_CommonQuest.visible = true;
				this.mc_CommonQuest.gotoAndStop("daily");
			}
			else
			{
				this.mc_CommonQuest.visible = false;
			}
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE2 = QuestUIDataManager.smethod_0().method_19(num, 1);
			if (npc_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this.mc_HeroQuest.visible = true;
				this.mc_HeroQuest.gotoAndStop("normal");
			}
			else if (npc_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this.mc_HeroQuest.visible = true;
				this.mc_HeroQuest.gotoAndStop("daily");
			}
			else
			{
				this.mc_HeroQuest.gotoAndStop("daily");
				this.mc_HeroQuest.visible = false;
			}
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE3 = QuestUIDataManager.smethod_0().method_19(num, 2);
			if (npc_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				this.mc_HellQuest.visible = true;
				this.mc_HellQuest.gotoAndStop("normal");
				return;
			}
			if (npc_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				this.mc_HellQuest.visible = true;
				this.mc_HellQuest.gotoAndStop("daily");
				return;
			}
			this.mc_HellQuest.visible = false;
		}

		// Token: 0x060039BD RID: 14781 RVA: 0x0010DE50 File Offset: 0x0010C050
		protected void method_6()
		{
			int num = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().method_4();
			this.tf_Description.text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_6("Instance_", Utility.smethod_8(num), "_des")));
			if (InstanceMapSelectControl.smethod_3(num))
			{
				this.mc_BossIcon.visible = true;
				this.mc_BossIcon.gotoAndStop(InstanceMapSelectControl.smethod_4(num));
			}
			else
			{
				this.mc_BossIcon.visible = false;
			}
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(num);
			int normal_LevelMin = playlist.m_normal_LevelMin;
			int hard_LevelMin = playlist.m_hard_LevelMin;
			int hell_LevelMin = playlist.m_hell_LevelMin;
			int num2 = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
			if (this.m_difficulty == ELevelDifficulty.Normal)
			{
				this.tf_Level.textFormat.color = this.method_7(num2, normal_LevelMin);
				this.tf_Level.text = Utility.smethod_5("Lv.", Utility.smethod_8(normal_LevelMin));
			}
			else if (this.m_difficulty == ELevelDifficulty.Hard)
			{
				this.tf_Level.textFormat.color = this.method_7(num2, hard_LevelMin);
				this.tf_Level.text = Utility.smethod_5("Lv.", Utility.smethod_8(hard_LevelMin));
			}
			else
			{
				this.tf_Level.textFormat.color = this.method_7(num2, hell_LevelMin);
				this.tf_Level.text = Utility.smethod_5("Lv.", Utility.smethod_8(hell_LevelMin));
			}
			List<Quest> list = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_22(num);
			for (int i = 0; i < list.Count; i++)
			{
				this.m_QuestField[i].text = LocalizedString.smethod_0(new LocalizedString(list[i].mTitle));
			}
			for (int j = list.Count; j < 5; j++)
			{
				this.m_QuestField[j].text = string.Empty;
			}
		}

		// Token: 0x060039BE RID: 14782 RVA: 0x0010E028 File Offset: 0x0010C228
		private Color method_7(int int_0, int int_1)
		{
			if (int_0 - int_1 >= 5)
			{
				return Color.grey;
			}
			if (int_0 - int_1 >= 2 && int_0 - int_1 <= 4)
			{
				return Color.green;
			}
			if (int_0 - int_1 >= -1 && int_0 - int_1 <= 1)
			{
				return Color.yellow;
			}
			if (int_0 - int_1 >= -4 && int_0 - int_1 <= -2)
			{
				return Color.Lerp(Color.red, Color.yellow, 0.5f);
			}
			return Color.red;
		}

		// Token: 0x060039BF RID: 14783 RVA: 0x0010E090 File Offset: 0x0010C290
		protected void method_8()
		{
			int num = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().method_4();
			uniInstanceInfoView uniInstanceInfoView = (uniInstanceInfoView)MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>();
			if (uniInstanceInfoView != null)
			{
				MovieClip movieClip = uniInstanceInfoView.method_7(num);
				if (movieClip == null)
				{
					return;
				}
				MovieClip childByName = this.mc_InstanceIcon.getChildByName<MovieClip>("mc_image");
				childByName.visible = false;
				this.newIconMC = movieClip.newInstance();
				this.newIconMC.name = movieClip.name;
				this.mc_InstanceIcon.addChildAt(this.newIconMC, this.mc_InstanceIcon.getChildIndex(childByName));
				this.newIconMC.x = childByName.x;
				this.newIconMC.y = childByName.y;
				this.mc_InstanceIcon.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
				this.mc_root.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_10));
			}
		}

		// Token: 0x060039C0 RID: 14784 RVA: 0x0010E188 File Offset: 0x0010C388
		private void method_9(CEvent cevent_0)
		{
			if (this.newIconMC != null && !this.mc_InstanceIcon.contains(this.newIconMC))
			{
				MovieClip childByName = this.mc_InstanceIcon.getChildByName<MovieClip>("mc_image");
				this.mc_InstanceIcon.addChildAt(this.newIconMC, this.mc_InstanceIcon.getChildIndex(childByName));
				this.newIconMC.x = childByName.x;
				this.newIconMC.y = childByName.y;
			}
		}

		// Token: 0x060039C1 RID: 14785 RVA: 0x00026887 File Offset: 0x00024A87
		protected void method_10(CEvent cevent_0)
		{
			this.mc_InstanceIcon.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
			this.mc_root.removeFrameScript("normal", new EventDispatcher.EventCallback(this.method_10));
		}

		// Token: 0x060039C2 RID: 14786 RVA: 0x0010E200 File Offset: 0x0010C400
		private void method_11(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3)
			{
				this.m_difficulty = ELevelDifficulty.Normal;
				this.method_6();
			}
		}

		// Token: 0x060039C3 RID: 14787 RVA: 0x0010E234 File Offset: 0x0010C434
		private void method_12(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3)
			{
				this.m_difficulty = ELevelDifficulty.Hard;
				this.method_6();
			}
		}

		// Token: 0x060039C4 RID: 14788 RVA: 0x0010E268 File Offset: 0x0010C468
		private void method_13(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3)
			{
				this.m_difficulty = ELevelDifficulty.Hell;
				this.method_6();
			}
		}

		// Token: 0x060039C5 RID: 14789 RVA: 0x000268C3 File Offset: 0x00024AC3
		private void method_14(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().Boolean_1 = false;
		}

		// Token: 0x060039C6 RID: 14790 RVA: 0x0010E29C File Offset: 0x0010C49C
		private void method_15(CEvent cevent_0)
		{
			if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_6() > 0)
			{
				this.method_17();
				return;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Energy_Confirmation")), new Delegate_EventProc(this.method_17), new Delegate_EventProc(this.method_16));
		}

		// Token: 0x060039C7 RID: 14791 RVA: 0x0000311B File Offset: 0x0000131B
		private void method_16()
		{
		}

		// Token: 0x060039C8 RID: 14792 RVA: 0x0010E2F8 File Offset: 0x0010C4F8
		private void method_17()
		{
			MonoSingleton<AppManager>.Instance.m_difficulty = this.m_difficulty;
			LobbyManager.smethod_0().method_9(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().method_4());
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().m_gameMode = GamemodeType.GamemodePvE;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = true;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().vmethod_6();
			this.mc_StartButton.Boolean_6 = false;
		}

		// Token: 0x0400286A RID: 10346
		public MovieClip mc_root;

		// Token: 0x0400286B RID: 10347
		public MovieClip mc_total;

		// Token: 0x0400286C RID: 10348
		protected GClass25 mc_StartButton;

		// Token: 0x0400286D RID: 10349
		protected GClass25 mc_CloseButton;

		// Token: 0x0400286E RID: 10350
		protected GClass40 mc_NormalButton;

		// Token: 0x0400286F RID: 10351
		protected GClass40 mc_HeroButton;

		// Token: 0x04002870 RID: 10352
		protected GClass40 mc_HellButton;

		// Token: 0x04002871 RID: 10353
		protected TextField tf_Rank;

		// Token: 0x04002872 RID: 10354
		protected TextField tf_Level;

		// Token: 0x04002873 RID: 10355
		protected TextField tf_LevelTitle;

		// Token: 0x04002874 RID: 10356
		protected TextField tf_DescriptionTitle;

		// Token: 0x04002875 RID: 10357
		protected TextField tf_Description;

		// Token: 0x04002876 RID: 10358
		protected TextField tf_QuestTitle;

		// Token: 0x04002877 RID: 10359
		protected List<TextField> m_QuestField;

		// Token: 0x04002878 RID: 10360
		protected MovieClip mc_BossIcon;

		// Token: 0x04002879 RID: 10361
		protected MovieClip mc_RankIcon;

		// Token: 0x0400287A RID: 10362
		protected MovieClip mc_InstanceIcon;

		// Token: 0x0400287B RID: 10363
		protected MovieClip mc_CommonQuest;

		// Token: 0x0400287C RID: 10364
		protected MovieClip mc_HeroQuest;

		// Token: 0x0400287D RID: 10365
		protected MovieClip mc_HellQuest;

		// Token: 0x0400287E RID: 10366
		private MovieClip newIconMC;

		// Token: 0x0400287F RID: 10367
		private MovieClip mc_Background;

		// Token: 0x04002880 RID: 10368
		private ELevelDifficulty m_difficulty;
	}
}
