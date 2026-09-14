using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x02000890 RID: 2192
public class uniQuestDetailView : QuestDetailView
{
	// Token: 0x06003C08 RID: 15368 RVA: 0x0011B140 File Offset: 0x00119340
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Quest.swf", "Panel_DetailRoot", new FuncLoad(this.method_5));
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_4), false);
	}

	// Token: 0x06003C09 RID: 15369 RVA: 0x0011B1A0 File Offset: 0x001193A0
	protected void method_4()
	{
		if (!this._bVisible)
		{
			return;
		}
		if (MonoSingleton<InputManager>.Instance.method_9("Jump") && this._questDetail != null && this._containerMC != null && !this._containerMC.isPlaying)
		{
			if (this._questDetail.QuestState_0 == QuestState.Completed)
			{
				this.vmethod_9();
			}
			else if (this._questDetail.QuestState_0 == QuestState.Available)
			{
				this.vmethod_7();
			}
			else
			{
				this.vmethod_8();
			}
		}
	}

	// Token: 0x06003C0A RID: 15370 RVA: 0x0011B218 File Offset: 0x00119418
	protected void method_5(MovieClip movieClip_0)
	{
		this._questDetail = new uniQuestDetailView.QuestDetail();
		this._questDetail.addEventListener(uniQuestDetailView.EVT_CLICK_CANCEL, new EventDispatcher.EventCallback(this.method_9));
		this._questDetail.addEventListener(uniQuestDetailView.EVT_CLICK_ABANDON, new EventDispatcher.EventCallback(this.method_8));
		this._questDetail.addEventListener(uniQuestDetailView.EVT_CLICK_ACCEPT, new EventDispatcher.EventCallback(this.method_7));
		this._questDetail.addEventListener(uniQuestDetailView.EVT_CLICK_SUBMIT, new EventDispatcher.EventCallback(this.method_10));
		movieClip_0.visible = false;
		movieClip_0.addFrameScript("KeyFrame_3", new EventDispatcher.EventCallback(this.method_6));
		this._container = new GClass51();
		this._container.method_0(movieClip_0);
		this._containerMC = movieClip_0;
		MovieClip childByName = this._containerMC.getChildByName<MovieClip>("mcQuestDetail");
		if (childByName != null)
		{
			this._questDetail.method_0(childByName);
		}
		this._bActive = true;
	}

	// Token: 0x06003C0B RID: 15371 RVA: 0x0011B30C File Offset: 0x0011950C
	public override void vmethod_3()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._container);
		this._questDetail = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Quest.swf");
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_4));
	}

	// Token: 0x06003C0C RID: 15372 RVA: 0x00028656 File Offset: 0x00026856
	public override void vmethod_5(Quest quest_0, QuestProgress questProgress_0)
	{
		base.vmethod_5(quest_0, questProgress_0);
		this._questDetail.method_11(this._onShowQuest, this._onShowProgress);
	}

	// Token: 0x06003C0D RID: 15373 RVA: 0x00028677 File Offset: 0x00026877
	protected void method_6(CEvent cevent_0)
	{
		this._containerMC.visible = false;
		this._questDetail.method_10(false);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._container);
	}

	// Token: 0x06003C0E RID: 15374 RVA: 0x0011B370 File Offset: 0x00119570
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._container);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Bounty_Board_Open");
			this._containerMC.gotoAndPlay("DetailAppear");
			this._containerMC.visible = true;
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
			this._containerMC.gotoAndPlay("FadeOut");
		}
	}

	// Token: 0x06003C0F RID: 15375 RVA: 0x000286AB File Offset: 0x000268AB
	protected void method_7(CEvent cevent_0)
	{
		this.vmethod_7();
	}

	// Token: 0x06003C10 RID: 15376 RVA: 0x000286B3 File Offset: 0x000268B3
	protected void method_8(CEvent cevent_0)
	{
		base.vmethod_6();
	}

	// Token: 0x06003C11 RID: 15377 RVA: 0x000286BB File Offset: 0x000268BB
	protected override void vmethod_7()
	{
		base.vmethod_7();
		if (this._onShowProgress.mStatus == QuestState.Available)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Accept_Mission");
		}
	}

	// Token: 0x06003C12 RID: 15378 RVA: 0x000286EA File Offset: 0x000268EA
	protected void method_9(CEvent cevent_0)
	{
		this.vmethod_8();
	}

	// Token: 0x06003C13 RID: 15379 RVA: 0x000286F2 File Offset: 0x000268F2
	protected void method_10(CEvent cevent_0)
	{
		this.vmethod_9();
	}

	// Token: 0x06003C14 RID: 15380 RVA: 0x000286FA File Offset: 0x000268FA
	protected override void vmethod_9()
	{
		this._selectedReward = this._questDetail.method_19();
		base.vmethod_9();
		if (this._onShowProgress.mStatus == QuestState.Completed)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Mission_Reward");
		}
	}

	// Token: 0x04002A22 RID: 10786
	protected uniQuestDetailView.QuestDetail _questDetail = new uniQuestDetailView.QuestDetail();

	// Token: 0x04002A23 RID: 10787
	protected GClass51 _container = new GClass51();

	// Token: 0x04002A24 RID: 10788
	protected MovieClip _containerMC;

	// Token: 0x04002A25 RID: 10789
	public static string EVT_CLICK_ACCEPT = "EvtClickAccept";

	// Token: 0x04002A26 RID: 10790
	public static string EVT_CLICK_CANCEL = "EvtClickCancel";

	// Token: 0x04002A27 RID: 10791
	public static string EVT_CLICK_SUBMIT = "EvtClickSubmit";

	// Token: 0x04002A28 RID: 10792
	public static string EVT_CLICK_ABANDON = "EvtClickAbandon";

	// Token: 0x02000891 RID: 2193
	public class RewardSlot : GClass24
	{
		public GClass25 button;

		public MovieClip icons;

		private TextField qtyFld;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			switch (movieClip.name)
			{
			case "icons":
				icons = movieClip;
				icons.mouseEnabled = false;
				result = true;
				break;
			case "button":
				button = new GClass25();
				button.method_0(movieClip);
				result = true;
				break;
			}
			return result;
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			qtyFld = base.DisplayObjectContainer_0.getChildByName<TextField>("textNumber");
		}

		public void method_10(QuestRewardType questRewardType_0, int int_0)
		{
			icons.gotoAndStop(questRewardType_0.ToString());
			if (qtyFld != null)
			{
				qtyFld.text = int_0.ToString();
			}
		}
	}
	// Token: 0x02000892 RID: 2194
	public class QuestDetail : GClass51
	{
		// Token: 0x17000331 RID: 817
		// (set) Token: 0x06003C1A RID: 15386 RVA: 0x0002878A File Offset: 0x0002698A
		public bool Boolean_0
		{
			set
			{
				this._bBtnVisible = value;
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06003C1B RID: 15387 RVA: 0x00028793 File Offset: 0x00026993
		public QuestState QuestState_0
		{
			get
			{
				if (this._questProgress != null)
				{
					return this._questProgress.mStatus;
				}
				return QuestState.Unavailable;
			}
		}

		// Token: 0x06003C1C RID: 15388 RVA: 0x000287AA File Offset: 0x000269AA
		protected void method_5(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniQuestDetailView.EVT_CLICK_ABANDON));
		}

		// Token: 0x06003C1D RID: 15389 RVA: 0x000287BD File Offset: 0x000269BD
		protected void method_6(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniQuestDetailView.EVT_CLICK_CANCEL));
		}

		// Token: 0x06003C1E RID: 15390 RVA: 0x000287D0 File Offset: 0x000269D0
		protected void method_7(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniQuestDetailView.EVT_CLICK_ACCEPT));
		}

		// Token: 0x06003C1F RID: 15391 RVA: 0x000287E3 File Offset: 0x000269E3
		protected void method_8(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniQuestDetailView.EVT_CLICK_SUBMIT));
		}

		// Token: 0x06003C20 RID: 15392 RVA: 0x0011B54C File Offset: 0x0011974C
		protected override void vmethod_0()
		{
			this._rewardPriority = new Dictionary<QuestRewardType, int>();
			this._rewardPriority.Add(QuestRewardType.Experience, 1);
			this._rewardPriority.Add(QuestRewardType.BondCurrency, 2);
			this._rewardPriority.Add(QuestRewardType.ClassMode, 3);
			this._rewardPriority.Add(QuestRewardType.Item, 4);
			this._rewardPriority.Add(QuestRewardType.Shield, 5);
			this._rewardPriority.Add(QuestRewardType.Material, 6);
			this._rewardPriority.Add(QuestRewardType.Outfit, 7);
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			if (this._rootMC != null)
			{
				this._mcButtons = this._rootMC.getChildByName<MovieClip>("mcButtons");
				this._mcButtons.addFrameScript("Normal", new EventDispatcher.EventCallback(this.method_12));
				this._mcButtons.addFrameScript("Available", new EventDispatcher.EventCallback(this.method_12));
				this._mcButtons.addFrameScript("Completed", new EventDispatcher.EventCallback(this.method_12));
				this._mcButtons.addFrameScript("InProgress", new EventDispatcher.EventCallback(this.method_12));
				this._panelAccept = this._rootMC.getChildByName<MovieClip>("mcAccept");
				this._textQuestComplete = this._rootMC.getChildByName<TextField>("textQuestComplete");
				BadAssMovieClip childByName = this._panelAccept.getChildByName<BadAssMovieClip>("masker");
				this._scrollbar.method_0(this._rootMC.getChildByName<MovieClip>("mcScrollbar"));
				this._scrollView = new GClass47(new Rect(0f, 0f, childByName.srcWidth, childByName.srcHeight));
				this._scrollView.GClass46_0 = this._scrollbar;
				this._scrollView.vmethod_8(this._panelAccept);
				this.method_23(this._panelAccept);
			}
			this._weaponGenerateService = MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>();
			this._itemGenerateService = MonoSingleton<AppManager>.Instance.GetComponent<ItemGeneratorService>();
		}

		// Token: 0x06003C21 RID: 15393 RVA: 0x0011B734 File Offset: 0x00119934
		protected int method_9(QuestReward questReward_0, QuestReward questReward_1)
		{
			int num = 0;
			int num2 = 0;
			this._rewardPriority.TryGetValue(questReward_0.mType, out num);
			this._rewardPriority.TryGetValue(questReward_1.mType, out num2);
			return num - num2;
		}

		// Token: 0x06003C22 RID: 15394 RVA: 0x00027219 File Offset: 0x00025419
		public void method_10(bool bool_0)
		{
			base.DisplayObjectContainer_0.visible = bool_0;
		}

		// Token: 0x06003C23 RID: 15395 RVA: 0x0011B770 File Offset: 0x00119970
		public void method_11(Quest quest_0, QuestProgress questProgress_0)
		{
			this._quest = quest_0;
			this._questProgress = questProgress_0;
			this._maxOptionRewardCount = this._quest.mOptionalRewardsCount;
			this._selectIndex = new List<byte>();
			this._selectButtons = new List<GClass25>();
			this._rewardButtonMap = new Dictionary<GClass25, QuestReward>();
			if (this._quest != null && this._questProgress != null)
			{
				if (this._rootMC != null)
				{
					QuestState mStatus = this._questProgress.mStatus;
					this._mcButtons.gotoAndStop(mStatus.ToString());
					this.method_14();
					this.method_13();
				}
				return;
			}
		}

		// Token: 0x06003C24 RID: 15396 RVA: 0x000287F6 File Offset: 0x000269F6
		protected void method_12(CEvent cevent_0)
		{
			if (this._quest != null && this._questProgress != null)
			{
				this.method_14();
				return;
			}
		}

		// Token: 0x06003C25 RID: 15397 RVA: 0x0002880F File Offset: 0x00026A0F
		protected void method_13()
		{
			if (this._quest != null && this._questProgress != null)
			{
				this.method_15();
				this.method_16();
				this.method_24();
				return;
			}
		}

		// Token: 0x06003C26 RID: 15398 RVA: 0x0011B804 File Offset: 0x00119A04
		protected void method_14()
		{
			MovieClip movieClip = this._mcButtons.getChildByName<MovieClip>("btnAccept");
			if (movieClip != null)
			{
				movieClip.visible = this._bBtnVisible;
				this._btnAccept.removeAllEventListeners(MouseEvent.CLICK);
				this._btnAccept.method_0(movieClip);
				this._btnAccept.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
			}
			movieClip = this._mcButtons.getChildByName<MovieClip>("btnSubmit");
			if (movieClip != null)
			{
				movieClip.visible = this._bBtnVisible;
				this._btnSubmit.removeAllEventListeners(MouseEvent.CLICK);
				this._btnSubmit.method_0(movieClip);
				this._btnSubmit.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			}
			movieClip = this._mcButtons.getChildByName<MovieClip>("btnCancal");
			if (movieClip != null)
			{
				movieClip.visible = this._bBtnVisible;
				this._btnCancel.removeAllEventListeners(MouseEvent.CLICK);
				this._btnCancel.method_0(movieClip);
				this._btnCancel.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
			}
			movieClip = this._mcButtons.getChildByName<MovieClip>("btnAbandon");
			if (movieClip != null)
			{
				movieClip.visible = this._questProgress.mStatus == QuestState.InProgress;
				this._btnAbandon.removeAllEventListeners(MouseEvent.CLICK);
				this._btnAbandon.method_0(movieClip);
				this._btnAbandon.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
			}
		}

		// Token: 0x06003C27 RID: 15399 RVA: 0x0011B988 File Offset: 0x00119B88
		protected void method_15()
		{
			if (this._panelAccept != null)
			{
				this._currentPanel = this._panelAccept;
				this._panelAccept.visible = true;
			}
			this._textQuestComplete.visible = this._questProgress.mStatus == QuestState.Completed || this._questProgress.mStatus == QuestState.RewardClaimed;
		}

		// Token: 0x06003C28 RID: 15400 RVA: 0x0011B9E0 File Offset: 0x00119BE0
		protected void method_16()
		{
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcQuestIcon");
			childByName.gotoAndStop(this._quest.mCategory.ToString());
			TextField childByName2 = this._rootMC.getChildByName<TextField>("textQuestName");
			childByName2.text = LocalizedString.smethod_0(new LocalizedString(this._quest.mTitle));
			TextField childByName3 = this._rootMC.getChildByName<TextField>("textQuestTypeValue");
			childByName3.text = LocalizedString.smethod_0(new LocalizedString(this._quest.mCategory.ToString()));
			TextField childByName4 = this._rootMC.getChildByName<TextField>("textQuestRecommendValue");
			childByName4.text = "LV." + this._quest.mRecommendedlevel;
			TextField childByName5 = this._rootMC.getChildByName<TextField>("textQuestInstanceValue");
			StringBuilder stringBuilder = new StringBuilder();
			if (this._quest.mIsBoundInstance)
			{
				foreach (int num in this._quest.mBoundInstanceList)
				{
					Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(num);
					if (playlist != null)
					{
						stringBuilder.Append(LocalizedString.smethod_0(new LocalizedString(playlist.m_name))).Append(" ");
					}
				}
			}
			else
			{
				stringBuilder.Append(LocalizedString.smethod_0(new LocalizedString("Quest_AnyInstance")));
			}
			childByName5.text = stringBuilder.ToString();
			TextField childByName6 = this._rootMC.getChildByName<TextField>("textQuestDifficultValue");
			string text = "Difficulty_";
			int mRequiredDifficulty = this._quest.mRequiredDifficulty;
			if (mRequiredDifficulty == -1)
			{
				text += "NoL";
			}
			else
			{
				text += mRequiredDifficulty;
			}
			text = LocalizedString.smethod_0(new LocalizedString(text));
			childByName6.text = text;
			if (this._panelAccept != null)
			{
				TextField childByName7 = this._panelAccept.getChildByName<TextField>("textQuestDetailValue");
				childByName7.text = QuestUIDataManager.smethod_0().method_3(this._quest, this._questProgress);
				TextField childByName8 = this._panelAccept.getChildByName<TextField>("textQuestDescription");
				if (childByName8 != null)
				{
					childByName8.visible = true;
					childByName8.multiline = true;
					childByName8.text = LocalizedString.smethod_0(new LocalizedString(this._quest.mDescription));
				}
				TextField childByName9 = this._panelAccept.getChildByName<MovieClip>("mcOptionRewardItems").getChildByName<TextField>("textOptionRewardCount");
				if (childByName9 != null)
				{
					childByName9.visible = true;
					childByName9.text = this._maxOptionRewardCount.ToString();
				}
			}
		}

		// Token: 0x06003C29 RID: 15401 RVA: 0x00028834 File Offset: 0x00026A34
		private void method_17(GClass25 gclass25_0, QuestReward questReward_0)
		{
			if (this._rewardButtonMap.ContainsKey(gclass25_0))
			{
				this._rewardButtonMap[gclass25_0] = questReward_0;
			}
			else
			{
				this._rewardButtonMap.Add(gclass25_0, questReward_0);
			}
		}

		// Token: 0x06003C2A RID: 15402 RVA: 0x0011BC70 File Offset: 0x00119E70
		protected int method_18(uniQuestDetailView.RewardSlot[] rewardSlot_0, GClass44[] gclass44_0, List<QuestReward> list_1, bool bool_0 = false)
		{
			int num = 0;
			int i = 0;
			int j = 0;
			while (j < list_1.Count)
			{
				QuestReward questReward = list_1[j];
				if (questReward.mType == QuestRewardType.BondCurrency || questReward.mType == QuestRewardType.Experience || questReward.mType == QuestRewardType.GuildExp)
				{
					goto IL_0280;
				}
				if (questReward.mType == QuestRewardType.KimBoxkey)
				{
					goto IL_0280;
				}
				if (questReward.mType == QuestRewardType.Item || questReward.mType == QuestRewardType.Shield || questReward.mType == QuestRewardType.ClassMode || questReward.mType == QuestRewardType.Material || questReward.mType == QuestRewardType.Outfit)
				{
					ItemDNA itemDNA = null;
					bool flag = true;
					switch (questReward.mType)
					{
					case QuestRewardType.Item:
						if (this._weaponGenerateService != null)
						{
							itemDNA = ItemDNA.smethod_2(this._weaponGenerateService.method_10(questReward.mRewardID));
						}
						break;
					case QuestRewardType.Material:
						itemDNA = ItemDNA.smethod_3(questReward.mMaterialType, questReward.mCount);
						break;
					case QuestRewardType.Shield:
						if (this._itemGenerateService != null)
						{
							ShieldDNA shieldDNA = this._itemGenerateService.method_1(questReward.mRewardID);
							if (shieldDNA != null)
							{
								itemDNA = ItemDNA.smethod_7(shieldDNA);
							}
						}
						break;
					case QuestRewardType.ClassMode:
						if (this._itemGenerateService != null)
						{
							itemDNA = this._itemGenerateService.method_27(questReward.mRewardID);
						}
						flag = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13().m_type == itemDNA.method_8().method_3(itemDNA.method_8().m_cmType);
						break;
					case QuestRewardType.KimBoxkey:
						itemDNA = ItemDNA.smethod_3(questReward.mMaterialType, questReward.mCount);
						break;
					case QuestRewardType.Outfit:
						if (this._itemGenerateService != null)
						{
							itemDNA = this._itemGenerateService.method_28(questReward.mRewardID);
						}
						flag = itemDNA.method_9().m_avatarType == ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13().m_type;
						break;
					}
					if (num < gclass44_0.Length)
					{
						if (gclass44_0[num] != null)
						{
							gclass44_0[num].Boolean_1 = true;
							UIItemSlotData uiitemSlotData = new UIItemSlotData(itemDNA, "Quest_Detail", num, false);
							gclass44_0[num].Object_0 = uiitemSlotData;
							gclass44_0[num].Boolean_4 = !flag;
							gclass44_0[num].Boolean_6 = this._questProgress.mStatus == QuestState.Completed && flag;
							gclass44_0[num].MovieClip_0.mouseEnabled = true;
							gclass44_0[num].GInterface1_0 = new ItemTips(uiitemSlotData.item);
							if (bool_0)
							{
								this.method_17(gclass44_0[num].gclass25_0, list_1[j]);
							}
						}
						num++;
					}
				}
				IL_02AE:
				j++;
				continue;
				IL_0280:
				if (rewardSlot_0 != null && i < rewardSlot_0.Length)
				{
					rewardSlot_0[i].Boolean_1 = true;
					rewardSlot_0[i].method_10(questReward.mType, questReward.mCount);
					i++;
					num = i * 2;
					goto IL_02AE;
				}
				goto IL_02AE;
			}
			for (int k = 0; k < 8; k++)
			{
				if (k < 2 * i || k >= num)
				{
					gclass44_0[k].Boolean_1 = false;
					if (gclass44_0[k].gclass43_0 != null)
					{
						gclass44_0[k].GInterface1_0 = null;
					}
				}
			}
			while (i < 4)
			{
				if (rewardSlot_0 != null && rewardSlot_0[i] != null)
				{
					rewardSlot_0[i].Boolean_1 = false;
				}
				i++;
			}
			return num;
		}

		// Token: 0x06003C2B RID: 15403 RVA: 0x0011BF94 File Offset: 0x0011A194
		public List<byte> method_19()
		{
			this._selectIndex = new List<byte>();
			for (int i = 0; i < this._selectButtons.Count; i++)
			{
				if (this._rewardButtonMap.ContainsKey(this._selectButtons[i]))
				{
					this._selectIndex.Add(this.method_20(this._rewardButtonMap[this._selectButtons[i]]));
				}
			}
			return this._selectIndex;
		}

		// Token: 0x06003C2C RID: 15404 RVA: 0x0011C00C File Offset: 0x0011A20C
		protected byte method_20(QuestReward questReward_0)
		{
			if (this._quest == null)
			{
				return 0;
			}
			byte b = 0;
			while ((int)b < this._quest.mOptionalRewardList.Length)
			{
				if (questReward_0 == this._quest.mOptionalRewardList[(int)b])
				{
					return b;
				}
				b += 1;
			}
			return 0;
		}

		// Token: 0x06003C2D RID: 15405 RVA: 0x0011C054 File Offset: 0x0011A254
		protected void method_21(CEvent cevent_0)
		{
			if (this._questProgress.mStatus != QuestState.Completed)
			{
				return;
			}
			GClass25 gclass = cevent_0.currentTarget as GClass25;
			if (this._selectButtons.Contains(gclass))
			{
				gclass.Boolean_3 = false;
				this._selectButtons.Remove(gclass);
				return;
			}
			if (this._selectButtons.Count < this._maxOptionRewardCount)
			{
				gclass.Boolean_3 = true;
				this._selectButtons.Add(gclass);
			}
			else
			{
				if (this._selectButtons.Count > 0)
				{
					GClass25 gclass2 = this._selectButtons[0];
					this._selectButtons.RemoveAt(0);
					gclass2.Boolean_3 = false;
				}
				this._selectButtons.Add(gclass);
				gclass.Boolean_3 = true;
			}
		}

		// Token: 0x06003C2E RID: 15406 RVA: 0x0011C108 File Offset: 0x0011A308
		private GClass25 method_22()
		{
			for (int i = 0; i < this._optionRewardItemAry[this._currentPanel].Length; i++)
			{
				if (this._optionRewardItemAry[this._currentPanel][i].Boolean_1)
				{
					return this._optionRewardItemAry[this._currentPanel][i].gclass25_0;
				}
			}
			return null;
		}

		// Token: 0x06003C2F RID: 15407 RVA: 0x0011C168 File Offset: 0x0011A368
		protected void method_23(MovieClip movieClip_0)
		{
			this._rewardSlotAry.Add(movieClip_0, new uniQuestDetailView.RewardSlot[4]);
			this._rewardItemAry.Add(movieClip_0, new GClass44[8]);
			this._optionRewardItemAry.Add(movieClip_0, new GClass44[8]);
			for (int i = 0; i < 4; i++)
			{
				if (this._rewardSlotAry[movieClip_0][i] == null)
				{
					this._rewardSlotAry[movieClip_0][i] = new uniQuestDetailView.RewardSlot();
					this._rewardSlotAry[movieClip_0][i].method_0(movieClip_0.getChildByName<MovieClip>("mcRewardItems").getChildByName<MovieClip>("mcRewardSlot" + i));
				}
			}
			for (int j = 0; j < 8; j++)
			{
				if (this._rewardItemAry[movieClip_0][j] == null)
				{
					this._rewardItemAry[movieClip_0][j] = new GClass44();
					MovieClip childByName = movieClip_0.getChildByName<MovieClip>("mcRewardItems").getChildByName<MovieClip>("mcItemSlot" + j);
					this._rewardItemAry[movieClip_0][j].method_0(childByName);
					childByName.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
					this._rewardItemAry[movieClip_0][j].method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
					this._rewardItemAry[movieClip_0][j].Boolean_6 = false;
					this._rewardItemAry[movieClip_0][j].MovieClip_0.mouseEnabled = true;
				}
			}
			for (int k = 0; k < 8; k++)
			{
				if (this._optionRewardItemAry[movieClip_0][k] == null)
				{
					this._optionRewardItemAry[movieClip_0][k] = new GClass44();
					MovieClip childByName2 = movieClip_0.getChildByName<MovieClip>("mcOptionRewardItems").getChildByName<MovieClip>("mcItemSlot" + k);
					this._optionRewardItemAry[movieClip_0][k].method_0(childByName2);
					childByName2.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
					this._optionRewardItemAry[movieClip_0][k].method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
					this._optionRewardItemAry[movieClip_0][k].gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
				}
			}
		}

		// Token: 0x06003C30 RID: 15408 RVA: 0x0011C3CC File Offset: 0x0011A5CC
		protected void method_24()
		{
			if (this._currentPanel != null)
			{
				for (int i = 0; i < 8; i++)
				{
					this._optionRewardItemAry[this._currentPanel][i].Boolean_6 = QuestState.Completed == this._questProgress.mStatus;
					this._optionRewardItemAry[this._currentPanel][i].MovieClip_0.mouseEnabled = true;
					this._optionRewardItemAry[this._currentPanel][i].Boolean_3 = false;
				}
				this._currentPanel.getChildByName<MovieClip>("mcRewardItems").visible = true;
				this._currentPanel.getChildByName<MovieClip>("mcOptionRewardItems").visible = true;
			}
			List<QuestReward> list = new List<QuestReward>(this._quest.mRewards);
			list.Sort(new Comparison<QuestReward>(this.method_9));
			float num = this.sectionTitleHeight + this.descriptionHeight;
			int num2 = this.method_18(this._rewardSlotAry[this._currentPanel], this._rewardItemAry[this._currentPanel], list, false);
			MovieClip childByName = this._currentPanel.getChildByName<MovieClip>("mcOptionRewardItems");
			MovieClip childByName2 = this._currentPanel.getChildByName<MovieClip>("mcRewardItems");
			if (num2 == 0)
			{
				childByName2.visible = false;
			}
			else
			{
				childByName2.visible = true;
				int num3 = (int)Math.Ceiling((double)((float)num2 / 4f));
				num += this.sectionTitleHeight;
				num += (float)num3 * this.itemSlotHeight;
			}
			if (this._quest.mOptionalRewardList != null)
			{
				list = new List<QuestReward>(this._quest.mOptionalRewardList);
			}
			num2 = ((this._quest.mOptionalRewardList != null) ? this.method_18(null, this._optionRewardItemAry[this._currentPanel], list, true) : 0);
			if (num2 == 0)
			{
				childByName.visible = false;
			}
			else
			{
				if (num2 == 1)
				{
					GClass25 gclass = this.method_22();
					if (gclass != null)
					{
						gclass.Boolean_3 = true;
						this._selectButtons.Add(gclass);
					}
				}
				childByName.visible = true;
				childByName.y = num;
			}
			this._scrollView.method_15();
			this._scrollView.vmethod_11();
			this._rootMC.stopAll();
		}

		// Token: 0x04002A2D RID: 10797
		protected const int SLOTCOUNT = 4;

		// Token: 0x04002A2E RID: 10798
		protected const int OPTION_SLOTCOUNT = 8;

		// Token: 0x04002A2F RID: 10799
		protected MovieClip _rootMC;

		// Token: 0x04002A30 RID: 10800
		protected MovieClip _mcButtons;

		// Token: 0x04002A31 RID: 10801
		protected MovieClip _currentPanel;

		// Token: 0x04002A32 RID: 10802
		protected GClass25 _btnCancel = new GClass25();

		// Token: 0x04002A33 RID: 10803
		protected GClass25 _btnAccept = new GClass25();

		// Token: 0x04002A34 RID: 10804
		protected GClass25 _btnSubmit = new GClass25();

		// Token: 0x04002A35 RID: 10805
		protected GClass25 _btnAbandon = new GClass25();

		// Token: 0x04002A36 RID: 10806
		protected MovieClip _panelAccept;

		// Token: 0x04002A37 RID: 10807
		protected GClass46 _scrollbar = new GClass46();

		// Token: 0x04002A38 RID: 10808
		protected GClass47 _scrollView = new GClass47();

		// Token: 0x04002A39 RID: 10809
		protected bool _bBtnVisible = true;

		// Token: 0x04002A3A RID: 10810
		private TextField _textQuestComplete;

		// Token: 0x04002A3B RID: 10811
		protected List<GClass25> _selectButtons;

		// Token: 0x04002A3C RID: 10812
		protected List<byte> _selectIndex;

		// Token: 0x04002A3D RID: 10813
		protected int _maxOptionRewardCount;

		// Token: 0x04002A3E RID: 10814
		protected Dictionary<GClass25, QuestReward> _rewardButtonMap;

		// Token: 0x04002A3F RID: 10815
		protected Dictionary<MovieClip, uniQuestDetailView.RewardSlot[]> _rewardSlotAry = new Dictionary<MovieClip, uniQuestDetailView.RewardSlot[]>();

		// Token: 0x04002A40 RID: 10816
		protected Dictionary<MovieClip, GClass44[]> _rewardItemAry = new Dictionary<MovieClip, GClass44[]>();

		// Token: 0x04002A41 RID: 10817
		protected Dictionary<MovieClip, GClass44[]> _optionRewardItemAry = new Dictionary<MovieClip, GClass44[]>();

		// Token: 0x04002A42 RID: 10818
		protected WeaponGeneratorService _weaponGenerateService;

		// Token: 0x04002A43 RID: 10819
		protected ItemGeneratorService _itemGenerateService;

		// Token: 0x04002A44 RID: 10820
		protected Quest _quest;

		// Token: 0x04002A45 RID: 10821
		protected QuestProgress _questProgress;

		// Token: 0x04002A46 RID: 10822
		protected Dictionary<QuestRewardType, int> _rewardPriority = new Dictionary<QuestRewardType, int>();

		// Token: 0x04002A47 RID: 10823
		protected float sectionTitleHeight = 26f;

		// Token: 0x04002A48 RID: 10824
		protected float descriptionHeight = 151f;

		// Token: 0x04002A49 RID: 10825
		protected float itemSlotHeight = 62f;

		// Token: 0x04002A4A RID: 10826
		protected float itemSlotBottom = 12f;
	}
}
