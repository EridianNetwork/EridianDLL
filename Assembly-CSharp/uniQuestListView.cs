using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x02000893 RID: 2195
public class uniQuestListView : QuestListView
{
	// Token: 0x06003C33 RID: 15411 RVA: 0x000288BC File Offset: 0x00026ABC
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Quest.swf", "whole", new FuncLoad(this.method_4));
	}

	// Token: 0x06003C34 RID: 15412 RVA: 0x0011C5E4 File Offset: 0x0011A7E4
	private void method_4(MovieClip movieClip_0)
	{
		movieClip_0.visible = false;
		this._root = new GClass51();
		this._root.method_0(movieClip_0);
		this._mcRoot = movieClip_0;
		this.currentFilter = uniQuestListView.EVT_FILTER_INPROGRESS;
		this._questList = new uniQuestListView.QuestListPanel();
		this._questList.addEventListener(uniQuestListView.EVT_CLICK_CLOSE_LIST, new EventDispatcher.EventCallback(this.method_9));
		this._questList.addEventListener(uniQuestListView.EVT_ONENTER_SLOT, new EventDispatcher.EventCallback(this.method_10));
		this._questList.addEventListener(uniQuestListView.EVT_FILTER_SUBMITED, new EventDispatcher.EventCallback(this.method_6));
		this._questList.addEventListener(uniQuestListView.EVT_FILTER_INPROGRESS, new EventDispatcher.EventCallback(this.method_7));
		this._questList.addEventListener(uniQuestListView.EVT_ONEMPTY_DATA, new EventDispatcher.EventCallback(this.method_11));
		MovieClip childByName = this._mcRoot.getChildByName<MovieClip>("mcQuestList");
		this._questList.method_0(childByName);
		this._questList.method_5(this.currentFilter);
		this._questDetail = new uniQuestDetailView.QuestDetail();
		this._questDetail.addEventListener(uniQuestDetailView.EVT_CLICK_ABANDON, new EventDispatcher.EventCallback(this.method_5));
		MovieClip childByName2 = this._mcRoot.getChildByName<MovieClip>("mcQuestDetail");
		if (childByName2 != null)
		{
			this._questDetail.method_0(childByName2);
			this._questDetail.Boolean_0 = false;
		}
		this._bActive = true;
	}

	// Token: 0x06003C35 RID: 15413 RVA: 0x000288F5 File Offset: 0x00026AF5
	private void method_5(CEvent cevent_0)
	{
		this.vmethod_5();
	}

	// Token: 0x06003C36 RID: 15414 RVA: 0x0011C74C File Offset: 0x0011A94C
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this._root != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
		}
		this._root = null;
		this._questList = null;
		this._questDetail = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Quest.swf");
	}

	// Token: 0x06003C37 RID: 15415 RVA: 0x000288FD File Offset: 0x00026AFD
	protected void method_6(CEvent cevent_0)
	{
		if (this.currentFilter == uniQuestListView.EVT_FILTER_SUBMITED)
		{
			return;
		}
		this.currentFilter = uniQuestListView.EVT_FILTER_SUBMITED;
		this._questList.method_5(this.currentFilter);
		this.vmethod_6();
	}

	// Token: 0x06003C38 RID: 15416 RVA: 0x00028934 File Offset: 0x00026B34
	protected void method_7(CEvent cevent_0)
	{
		if (this.currentFilter == uniQuestListView.EVT_FILTER_INPROGRESS)
		{
			return;
		}
		this.currentFilter = uniQuestListView.EVT_FILTER_INPROGRESS;
		this._questList.method_5(this.currentFilter);
		this.vmethod_6();
	}

	// Token: 0x06003C39 RID: 15417 RVA: 0x0011C7B0 File Offset: 0x0011A9B0
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._mcRoot == null)
		{
			return;
		}
		this._mcRoot.visible = bool_0;
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_31(this._root);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
			if (this._questList != null)
			{
				this._questList.method_13(this._questInfoByInstanceID);
			}
			if (this.method_8() && !(this.currentFilter == uniQuestListView.EVT_FILTER_SUBMITED))
			{
				this._mcRoot.gotoAndStop("pannelopen");
				this.vmethod_6();
			}
			else
			{
				this._mcRoot.gotoAndPlay("firstmove");
			}
		}
		else
		{
			if (this._questDetail != null)
			{
				this._questDetail.method_10(false);
			}
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_37(this._root);
		}
	}

	// Token: 0x06003C3A RID: 15418 RVA: 0x0011C8A8 File Offset: 0x0011AAA8
	protected bool method_8()
	{
		foreach (KeyValuePair<int, List<QuestListView.QuestListSlotData>> keyValuePair in this._questInfoByInstanceID)
		{
			int i = 0;
			while (i < keyValuePair.Value.Count)
			{
				if (keyValuePair.Value[i].questProgress.mStatus != QuestState.InProgress)
				{
					if (keyValuePair.Value[i].questProgress.mStatus != QuestState.Completed)
					{
						i++;
						continue;
					}
				}
				return false;
			}
		}
		return true;
	}

	// Token: 0x06003C3B RID: 15419 RVA: 0x0001E5A9 File Offset: 0x0001C7A9
	protected void method_9(CEvent cevent_0)
	{
		this.Boolean_1 = false;
	}

	// Token: 0x06003C3C RID: 15420 RVA: 0x0011C948 File Offset: 0x0011AB48
	protected void method_10(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null && gclass.object_0 != null)
		{
			this.currentFocusSlot = gclass.object_0 as QuestListView.QuestListSlotData;
			if (this.currentFocusSlot != null && this._questDetail != null)
			{
				this._questDetail.DisplayObjectContainer_0.visible = true;
				this._questDetail.method_11(this.currentFocusSlot.quest, this.currentFocusSlot.questProgress);
			}
		}
	}

	// Token: 0x06003C3D RID: 15421 RVA: 0x0002896B File Offset: 0x00026B6B
	protected void method_11(CEvent cevent_0)
	{
		if (this._questDetail != null)
		{
			this._questDetail.DisplayObjectContainer_0.visible = false;
		}
	}

	// Token: 0x06003C3E RID: 15422 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_12(CEvent cevent_0)
	{
	}

	// Token: 0x06003C3F RID: 15423 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_13(CEvent cevent_0)
	{
	}

	// Token: 0x06003C40 RID: 15424 RVA: 0x00028986 File Offset: 0x00026B86
	protected override void vmethod_6()
	{
		base.vmethod_6();
		if (this._questList != null)
		{
			this._questList.method_13(this._questInfoByInstanceID);
		}
	}

	// Token: 0x04002A4B RID: 10827
	protected GClass51 _root;

	// Token: 0x04002A4C RID: 10828
	protected MovieClip _mcRoot;

	// Token: 0x04002A4D RID: 10829
	protected uniQuestListView.QuestListPanel _questList = new uniQuestListView.QuestListPanel();

	// Token: 0x04002A4E RID: 10830
	protected uniQuestDetailView.QuestDetail _questDetail = new uniQuestDetailView.QuestDetail();

	// Token: 0x04002A4F RID: 10831
	protected static string EVT_ONENTER_SLOT = "EvtOnEnterSlot";

	// Token: 0x04002A50 RID: 10832
	protected static string EVT_ONLEAVE_SLOT = "EvtOnLeaveSlot";

	// Token: 0x04002A51 RID: 10833
	protected static string EVT_ONEMPTY_DATA = "EvtOnEmptyData";

	// Token: 0x04002A52 RID: 10834
	protected static string EVT_CLICK_CLOSE_LIST = "EvtOnClickCloseList";

	// Token: 0x04002A53 RID: 10835
	protected static string EVT_FILTER_SUBMITED = "EvtFilterSubmited";

	// Token: 0x04002A54 RID: 10836
	protected static string EVT_FILTER_INPROGRESS = "EvtFilterInPorgress";

	// Token: 0x04002A55 RID: 10837
	private string currentFilter;

	// Token: 0x02000894 RID: 2196
	public enum SlotStyle
	{
		// Token: 0x04002A57 RID: 10839
		TitleSlot,
		// Token: 0x04002A58 RID: 10840
		DarkSlot,
		// Token: 0x04002A59 RID: 10841
		LightSlot
	}

	// Token: 0x02000895 RID: 2197
	public class QuestListSlotInfo
	{
		// Token: 0x04002A5A RID: 10842
		public string strTitleString;

		// Token: 0x04002A5B RID: 10843
		public Color textColor = Color.white;

		// Token: 0x04002A5C RID: 10844
		public uniQuestListView.SlotStyle slotStyle;

		// Token: 0x04002A5D RID: 10845
		public QuestListView.QuestListSlotData slotData;
	}

	// Token: 0x02000896 RID: 2198
	public class QuestListPanel : GClass51
	{
		// Token: 0x06003C44 RID: 15428 RVA: 0x0011C9BC File Offset: 0x0011ABBC
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains("mcItem_"))
			{
				string[] array = movieClip.name.Split(new char[] { '_' });
				int num = Convert.ToInt32(array[1]);
				if (this._questSlotButtonAry[num - 1] == null)
				{
					this._questSlotButtonAry[num - 1] = new uniQuestListView.QuestListSlotButton();
					this._questSlotButtonAry[num - 1].addEventListener(uniQuestListView.EVT_ONENTER_SLOT, new EventDispatcher.EventCallback(this.method_11));
					this._questSlotButtonAry[num - 1].addEventListener(uniQuestListView.EVT_ONLEAVE_SLOT, new EventDispatcher.EventCallback(this.method_12));
				}
				this._questSlotButtonAry[num - 1].method_0(movieClip);
				this._questSlotButtonAry[num - 1].method_23(false);
				flag = true;
			}
			else if (movieClip.name == "mcListContainer")
			{
				this._listContainer = movieClip;
			}
			else if (movieClip.name == "mcBtnClose")
			{
				this._btnClose = new GClass25();
				this._btnClose.method_0(movieClip);
				this._btnClose.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
				flag = true;
			}
			else if (movieClip.name == "mcScrollingBar")
			{
				this._scrollBar = new GClass46();
				this._scrollBar.method_0(movieClip);
				this._scrollBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_10));
				GClass45 scrollBar = this._scrollBar;
				this._scrollBar.int_1 = 0;
				scrollBar.int_0 = 0;
				flag = true;
			}
			else if (movieClip.name == "mc_inprogress")
			{
				this._btnInProgress = new GClass25();
				this._btnInProgress.method_0(movieClip);
				this._btnInProgress.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			}
			else if (movieClip.name == "mc_submited")
			{
				this._btnSubmit = new GClass25();
				this._btnSubmit.method_0(movieClip);
				this._btnSubmit.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
			}
			return flag;
		}

		// Token: 0x06003C45 RID: 15429 RVA: 0x000289EC File Offset: 0x00026BEC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.method_6();
			this._listContainer.addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this._scrollBar.method_12), false);
		}

		// Token: 0x06003C46 RID: 15430 RVA: 0x00028A1D File Offset: 0x00026C1D
		public void method_5(string string_1)
		{
			this._filter = string_1;
			this.method_6();
		}

		// Token: 0x06003C47 RID: 15431 RVA: 0x0011CBF8 File Offset: 0x0011ADF8
		protected void method_6()
		{
			if (this._btnSubmit != null && this._btnInProgress != null)
			{
				if (this._filter == uniQuestListView.EVT_FILTER_SUBMITED)
				{
					this._btnSubmit.Boolean_3 = true;
					this._btnInProgress.Boolean_3 = false;
				}
				else
				{
					this._btnSubmit.Boolean_3 = false;
					this._btnInProgress.Boolean_3 = true;
				}
			}
		}

		// Token: 0x06003C48 RID: 15432 RVA: 0x00028A2C File Offset: 0x00026C2C
		protected void method_7(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniQuestListView.EVT_FILTER_SUBMITED));
		}

		// Token: 0x06003C49 RID: 15433 RVA: 0x00028A3F File Offset: 0x00026C3F
		protected void method_8(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniQuestListView.EVT_FILTER_INPROGRESS));
		}

		// Token: 0x06003C4A RID: 15434 RVA: 0x00028A52 File Offset: 0x00026C52
		protected void method_9(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniQuestListView.EVT_CLICK_CLOSE_LIST));
		}

		// Token: 0x06003C4B RID: 15435 RVA: 0x00028A65 File Offset: 0x00026C65
		protected void method_10(CEvent cevent_0)
		{
			this.method_14(this._scrollBar.Int32_1);
		}

		// Token: 0x06003C4C RID: 15436 RVA: 0x000216B0 File Offset: 0x0001F8B0
		protected void method_11(CEvent cevent_0)
		{
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x06003C4D RID: 15437 RVA: 0x000216B0 File Offset: 0x0001F8B0
		protected void method_12(CEvent cevent_0)
		{
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x06003C4E RID: 15438 RVA: 0x0011CC5C File Offset: 0x0011AE5C
		public void method_13(Dictionary<int, List<QuestListView.QuestListSlotData>> dictionary_0)
		{
			if (dictionary_0 == null)
			{
				return;
			}
			this._questSlotList.Clear();
			List<int> list = new List<int>(dictionary_0.Keys);
			list.Sort(new Comparison<int>(this.method_16));
			List<QuestListView.QuestListSlotData> list2 = null;
			foreach (int num in list)
			{
				if (num == -1)
				{
					list2 = dictionary_0[num];
				}
				else
				{
					List<QuestListView.QuestListSlotData> list3 = dictionary_0[num];
					if (list3 != null && list3.Count != 0 && this._filter == uniQuestListView.EVT_FILTER_INPROGRESS)
					{
						uniQuestListView.QuestListSlotInfo questListSlotInfo = new uniQuestListView.QuestListSlotInfo();
						questListSlotInfo.slotStyle = uniQuestListView.SlotStyle.TitleSlot;
						questListSlotInfo.strTitleString = MatchmakingService.MatchmakingService_0.method_1(num).m_name;
						this._questSlotList.Add(questListSlotInfo);
						this.method_15(list3);
					}
				}
			}
			if (list2 != null && this._filter == uniQuestListView.EVT_FILTER_SUBMITED)
			{
				uniQuestListView.QuestListSlotInfo questListSlotInfo2 = new uniQuestListView.QuestListSlotInfo();
				questListSlotInfo2.slotStyle = uniQuestListView.SlotStyle.TitleSlot;
				questListSlotInfo2.strTitleString = "Completed_Quest";
				this._questSlotList.Add(questListSlotInfo2);
				this.method_15(list2);
			}
			if (this._scrollBar != null)
			{
				bool flag = this._questSlotList.Count > uniQuestListView.QuestListPanel.QUESTLIST_SLOT_COUNT;
				this._scrollBar.DisplayObjectContainer_0.visible = flag;
				if (flag)
				{
					this._scrollBar.method_10(this._questSlotList.Count, 0, this._questSlotList.Count - uniQuestListView.QuestListPanel.QUESTLIST_SLOT_COUNT, 1);
				}
			}
			this.method_14(0);
			if (this._questSlotList.Count > 1)
			{
				base.dispatchEvent(new GClass55(uniQuestListView.EVT_ONENTER_SLOT, this._questSlotList[1].slotData, true, false));
			}
			else
			{
				base.dispatchEvent(new CEvent(uniQuestListView.EVT_ONEMPTY_DATA));
			}
		}

		// Token: 0x06003C4F RID: 15439 RVA: 0x0011CE30 File Offset: 0x0011B030
		protected void method_14(int int_0)
		{
			int i = 0;
			int num = int_0;
			while (num < this._questSlotList.Count && i < uniQuestListView.QuestListPanel.QUESTLIST_SLOT_COUNT)
			{
				if (this._questSlotButtonAry[i] != null)
				{
					this._questSlotButtonAry[i].method_21(this._questSlotList[num]);
					this._questSlotButtonAry[i].method_23(true);
				}
				num++;
				i++;
			}
			while (i < uniQuestListView.QuestListPanel.QUESTLIST_SLOT_COUNT)
			{
				if (this._questSlotButtonAry[i] != null)
				{
					this._questSlotButtonAry[i].method_23(false);
				}
				i++;
			}
		}

		// Token: 0x06003C50 RID: 15440 RVA: 0x0011CEB8 File Offset: 0x0011B0B8
		protected void method_15(List<QuestListView.QuestListSlotData> list_1)
		{
			if (list_1 != null && list_1.Count != 0)
			{
				int num = 0;
				foreach (QuestListView.QuestListSlotData questListSlotData in list_1)
				{
					uniQuestListView.QuestListSlotInfo questListSlotInfo = new uniQuestListView.QuestListSlotInfo();
					questListSlotInfo.slotStyle = ((num % 2 != 0) ? uniQuestListView.SlotStyle.LightSlot : uniQuestListView.SlotStyle.DarkSlot);
					questListSlotInfo.strTitleString = questListSlotData.quest.mTitle;
					questListSlotInfo.slotData = questListSlotData;
					num++;
					this._questSlotList.Add(questListSlotInfo);
				}
				return;
			}
		}

		// Token: 0x06003C51 RID: 15441 RVA: 0x00028A78 File Offset: 0x00026C78
		private int method_16(int int_0, int int_1)
		{
			return int_0 - int_1;
		}

		// Token: 0x04002A5E RID: 10846
		protected static int QUESTLIST_SLOT_COUNT = 15;

		// Token: 0x04002A5F RID: 10847
		protected uniQuestListView.QuestListSlotButton[] _questSlotButtonAry = new uniQuestListView.QuestListSlotButton[uniQuestListView.QuestListPanel.QUESTLIST_SLOT_COUNT];

		// Token: 0x04002A60 RID: 10848
		protected List<uniQuestListView.QuestListSlotInfo> _questSlotList = new List<uniQuestListView.QuestListSlotInfo>();

		// Token: 0x04002A61 RID: 10849
		protected MovieClip _listContainer;

		// Token: 0x04002A62 RID: 10850
		protected GClass25 _btnClose;

		// Token: 0x04002A63 RID: 10851
		protected GClass46 _scrollBar;

		// Token: 0x04002A64 RID: 10852
		protected GClass25 _btnSubmit;

		// Token: 0x04002A65 RID: 10853
		protected GClass25 _btnInProgress;

		// Token: 0x04002A66 RID: 10854
		protected string _filter;

		// Token: 0x04002A67 RID: 10855
		public static int _iFinishedQuestsIndex = -1;
	}

	// Token: 0x02000897 RID: 2199
	public class QuestListSlotButton : GClass25
	{
		// Token: 0x06003C53 RID: 15443 RVA: 0x0011CF4C File Offset: 0x0011B14C
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcTitleBoard":
				this._mcTitleBoard = movieClip;
				flag = true;
				break;
			case "mcSlotBG":
				this._mcSlotBG = movieClip;
				flag = true;
				break;
			case "mcTypeIcon":
				this._mcTypeIcon = movieClip;
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x06003C54 RID: 15444 RVA: 0x0011CFE4 File Offset: 0x0011B1E4
		protected override void vmethod_0()
		{
			this._mcRoot = this.displayObjectContainer_0 as MovieClip;
			if (this._mcRoot != null)
			{
				this._mcRoot.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_19));
				this._mcRoot.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_20));
			}
			this._dicQuestTextColor.Clear();
			this._dicQuestTextColor.Add(QuestState.Available, Color.yellow);
			this._dicQuestTextColor.Add(QuestState.Completed, Color.green);
			this._dicQuestTextColor.Add(QuestState.InProgress, Color.white);
			this._dicQuestTextColor.Add(QuestState.RewardClaimed, Color.grey);
		}

		// Token: 0x06003C55 RID: 15445 RVA: 0x00028A90 File Offset: 0x00026C90
		protected void method_19(CEvent cevent_0)
		{
			if (this._slotInfo != null && this._slotInfo.slotData != null)
			{
				base.dispatchEvent(new GClass55(uniQuestListView.EVT_ONENTER_SLOT, this._slotInfo.slotData, true, false));
			}
		}

		// Token: 0x06003C56 RID: 15446 RVA: 0x00028AC5 File Offset: 0x00026CC5
		protected void method_20(CEvent cevent_0)
		{
			if (this._slotInfo != null && this._slotInfo.slotData != null)
			{
				base.dispatchEvent(new GClass55(uniQuestListView.EVT_ONLEAVE_SLOT, this._slotInfo.slotData, true, false));
			}
		}

		// Token: 0x06003C57 RID: 15447 RVA: 0x00028AFA File Offset: 0x00026CFA
		public void method_21(uniQuestListView.QuestListSlotInfo questListSlotInfo_0)
		{
			this._slotInfo = questListSlotInfo_0;
			this.method_22();
		}

		// Token: 0x06003C58 RID: 15448 RVA: 0x0011D094 File Offset: 0x0011B294
		protected void method_22()
		{
			if (this._slotInfo == null)
			{
				return;
			}
			string text = null;
			Color color = Color.white;
			bool flag = false;
			switch (this._slotInfo.slotStyle)
			{
			case uniQuestListView.SlotStyle.TitleSlot:
				text = this._slotInfo.strTitleString;
				flag = false;
				break;
			case uniQuestListView.SlotStyle.DarkSlot:
			case uniQuestListView.SlotStyle.LightSlot:
				text = this._slotInfo.slotData.quest.mTitle;
				color = this._dicQuestTextColor[this._slotInfo.slotData.questProgress.mStatus];
				flag = true;
				break;
			}
			if (this._mcTitleBoard != null)
			{
				UnityTextField childByName = this._mcTitleBoard.getChildByName<UnityTextField>("infotitle");
				if (childByName != null)
				{
					childByName.text = LocalizedString.smethod_0(new LocalizedString(text));
					childByName.Color_0 = color;
				}
			}
			if (this._mcSlotBG != null)
			{
				this._mcSlotBG.gotoAndStop(this._slotInfo.slotStyle.ToString());
			}
			if (this._mcTypeIcon != null)
			{
				if (flag)
				{
					this._mcTypeIcon.visible = true;
					this._mcTypeIcon.gotoAndStop(this._slotInfo.slotData.quest.mCategory.ToString());
					MovieClip childByName2 = this._mcTypeIcon.getChildByName<MovieClip>("mcIconColor");
					if (childByName2 != null)
					{
						childByName2.gotoAndStop(this._slotInfo.slotData.questProgress.mStatus.ToString());
					}
				}
				else
				{
					this._mcTypeIcon.visible = false;
				}
			}
		}

		// Token: 0x06003C59 RID: 15449 RVA: 0x00028B09 File Offset: 0x00026D09
		public void method_23(bool bool_8)
		{
			this._mcRoot.visible = bool_8;
		}

		// Token: 0x04002A68 RID: 10856
		protected MovieClip _mcRoot;

		// Token: 0x04002A69 RID: 10857
		protected MovieClip _mcTitleBoard;

		// Token: 0x04002A6A RID: 10858
		protected MovieClip _mcSlotBG;

		// Token: 0x04002A6B RID: 10859
		protected MovieClip _mcTypeIcon;

		// Token: 0x04002A6C RID: 10860
		protected uniQuestListView.QuestListSlotInfo _slotInfo;

		// Token: 0x04002A6D RID: 10861
		protected Dictionary<QuestState, Color> _dicQuestTextColor = new Dictionary<QuestState, Color>();
	}
}
