using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x02000898 RID: 2200
public class uniQuestTrackView : QuestTrackView
{
	// Token: 0x06003C5B RID: 15451 RVA: 0x00028B4A File Offset: 0x00026D4A
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("HUD.swf", "Panel_QuestTrack", new FuncLoad(this.method_10));
	}

	// Token: 0x06003C5C RID: 15452 RVA: 0x0011D20C File Offset: 0x0011B40C
	private void method_10(MovieClip movieClip_0)
	{
		this._root = new GClass51();
		movieClip_0.visible = true;
		this._rootMC = movieClip_0;
		this._root.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._root);
		for (int i = 1; i <= QuestTrackView.MAX_TRACKING_NUM; i++)
		{
			this._trackSlotPanelAry[i - 1] = new uniQuestTrackView.TrackSlotPanel();
			string text = this._strItemPrefix + i;
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>(text);
			if (childByName != null)
			{
				this._trackSlotPanelAry[i - 1].method_0(childByName);
				this._trackSlotPanelAry[i - 1].OnAnimationEnd_0 = new uniQuestTrackView.TrackSlotPanel.OnAnimationEnd(this.vmethod_5);
				this._trackSlotPanelAry[i - 1].index = i - 1;
				this._originalSlotPosition[i - 1] = new Vector2(childByName.x, childByName.y);
				childByName.visible = false;
			}
		}
		this._bActive = true;
		this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x06003C5D RID: 15453 RVA: 0x0011D324 File Offset: 0x0011B524
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this._root != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
		}
		this._bActive = false;
		this._root = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("HUD.swf");
	}

	// Token: 0x06003C5E RID: 15454 RVA: 0x00028B83 File Offset: 0x00026D83
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._rootMC != null)
		{
			this._rootMC.visible = bool_0;
		}
	}

	// Token: 0x06003C5F RID: 15455 RVA: 0x0011D380 File Offset: 0x0011B580
	protected override void vmethod_6()
	{
		base.vmethod_6();
		if (!this._bActive)
		{
			return;
		}
		int i = 0;
		int num = 0;
		while (i < QuestTrackView.MAX_TRACKING_NUM && num < this._onTrackingDataList.Count)
		{
			if (this._trackSlotPanelAry[i].TrackingSlotData_0 != null && this._trackSlotPanelAry[i].method_13())
			{
				if (this._trackSlotPanelAry[i].TrackingSlotData_0.TaskCategory == QuestTrackView.eTrackingCategory.eObjective && this._onTrackingDataList[num].TaskCategory != QuestTrackView.eTrackingCategory.eObjective)
				{
					this._trackSlotPanelAry[i].method_10(null);
				}
				else
				{
					this._trackSlotPanelAry[i].method_10(this._onTrackingDataList[num]);
					this._trackSlotPanelAry[i].method_12(true);
					num++;
				}
			}
			else
			{
				this._trackSlotPanelAry[i].method_10(this._onTrackingDataList[num]);
				this._trackSlotPanelAry[i].method_12(true);
				num++;
			}
			i++;
		}
		while (i < QuestTrackView.MAX_TRACKING_NUM)
		{
			this._trackSlotPanelAry[i].method_10(null);
			i++;
		}
	}

	// Token: 0x04002A6F RID: 10863
	protected GClass51 _root;

	// Token: 0x04002A70 RID: 10864
	protected MovieClip _rootMC;

	// Token: 0x04002A71 RID: 10865
	protected string _strItemPrefix = "mcQuest_";

	// Token: 0x04002A72 RID: 10866
	protected uniQuestTrackView.TrackSlotPanel[] _trackSlotPanelAry = new uniQuestTrackView.TrackSlotPanel[QuestTrackView.MAX_TRACKING_NUM];

	// Token: 0x04002A73 RID: 10867
	protected Vector2[] _originalSlotPosition = new Vector2[QuestTrackView.MAX_TRACKING_NUM];

	// Token: 0x02000899 RID: 2201
	protected class TrackSlotPanel : GClass51
	{
		// Token: 0x17000333 RID: 819
		// (set) Token: 0x06003C61 RID: 15457 RVA: 0x00028BD1 File Offset: 0x00026DD1
		public uniQuestTrackView.TrackSlotPanel.OnAnimationEnd OnAnimationEnd_0
		{
			set
			{
				this._onAnimationEnd = value;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06003C62 RID: 15458 RVA: 0x00028BDA File Offset: 0x00026DDA
		public QuestTrackView.TrackingSlotData TrackingSlotData_0
		{
			get
			{
				return this._slotData;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06003C63 RID: 15459 RVA: 0x00028BE2 File Offset: 0x00026DE2
		public bool Boolean_0
		{
			get
			{
				return this._bOnAnima;
			}
		}

		// Token: 0x06003C64 RID: 15460 RVA: 0x0011D490 File Offset: 0x0011B690
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._mcRoot = base.DisplayObjectContainer_0 as MovieClip;
			this._textQuestName = this._mcRoot.getChildByName<UnityTextField>("textQuestName");
			this._statusMC = this._mcRoot.getChildByName<MovieClip>("mcQuestStatus");
			this._slotDatas = new List<QuestTrackView.TrackingSlotData>();
			if (this._statusMC != null)
			{
				this._statusMC.addFrameScript("ComKey1", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("ComKey2", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("Complete", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TurnKey1", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TurnKey2", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TurnKey3", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TurnKey4", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TurnKey5", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TaskComKey1", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TaskComKey2", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TaskComKey3", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("TaskComKey4", new EventDispatcher.EventCallback(this.method_5));
				this._statusMC.addFrameScript("RevealAniEnd", new EventDispatcher.EventCallback(this.method_6));
				this._statusMC.addFrameScript("CompleteAniEnd", new EventDispatcher.EventCallback(this.method_6));
				this._statusMC.addFrameScript("RemoveAniEnd", new EventDispatcher.EventCallback(this.method_6));
				this._statusMC.addFrameScript("IncrementAniEnd", new EventDispatcher.EventCallback(this.method_6));
				this._statusMC.addFrameScript("TurnAniEnd", new EventDispatcher.EventCallback(this.method_6));
				this._statusMC.addFrameScript("TaskComAniEnd", new EventDispatcher.EventCallback(this.method_6));
			}
		}

		// Token: 0x06003C65 RID: 15461 RVA: 0x00028BEA File Offset: 0x00026DEA
		protected void method_5(CEvent cevent_0)
		{
			this.method_15();
		}

		// Token: 0x06003C66 RID: 15462 RVA: 0x00028BF2 File Offset: 0x00026DF2
		protected void method_6(CEvent cevent_0)
		{
			this._bOnAnima = false;
			this.method_8();
		}

		// Token: 0x06003C67 RID: 15463 RVA: 0x0011D700 File Offset: 0x0011B900
		private void method_7(QuestTrackView.TrackingSlotData trackingSlotData_0)
		{
			if (this._slotDatas.Count > 0)
			{
				if (this._slotDatas[this._slotDatas.Count - 1] != trackingSlotData_0)
				{
					this._slotDatas.Add(trackingSlotData_0);
				}
			}
			else if (trackingSlotData_0 != null)
			{
				this._slotDatas.Add(trackingSlotData_0);
			}
		}

		// Token: 0x06003C68 RID: 15464 RVA: 0x0011D754 File Offset: 0x0011B954
		private void method_8()
		{
			if (this._slotDatas.Count > 0 && this._slotDatas[this._slotDatas.Count - 1] != null)
			{
				if (this._slotDatas[this._slotDatas.Count - 1].iconState == this._iconState && this._slotDatas[this._slotDatas.Count - 1].strDesText == this._strDesText && this._slotDatas[this._slotDatas.Count - 1].strTitleText == this._strTitleText)
				{
					return;
				}
				this._slotData = this._slotDatas[this._slotDatas.Count - 1];
				this._slotDatas.Clear();
				this._strTitleText = this._slotData.strTitleText;
				this._strDesText = this._slotData.strDesText;
				this._iconState = this._slotData.iconState;
				this._textColor = this._slotData.textColor;
				this.method_15();
				if (this._slotData.TrackerAnimaList.Count > 0 && this._currentAnim != this._slotData.TrackerAnimaList[this._slotData.TrackerAnimaList.Count - 1])
				{
					this.method_11(this._slotData.TrackerAnimaList[this._slotData.TrackerAnimaList.Count - 1]);
					this._slotData.TrackerAnimaList.Clear();
				}
				else
				{
					this._statusMC.gotoAndStop("Off");
				}
			}
			else
			{
				this._slotData = null;
				this._strDesText = null;
				this._strTitleText = null;
				if (this._currentAnim == QuestTrackView.eTrackerAnimation.eRemove)
				{
					this.method_12(false);
				}
			}
		}

		// Token: 0x06003C69 RID: 15465 RVA: 0x00028C01 File Offset: 0x00026E01
		private void method_9(QuestTrackView.TrackingSlotData trackingSlotData_0)
		{
			if (trackingSlotData_0 != null)
			{
				this._iconState = trackingSlotData_0.iconState;
				this.method_14();
			}
		}

		// Token: 0x06003C6A RID: 15466 RVA: 0x0011D92C File Offset: 0x0011BB2C
		public void method_10(QuestTrackView.TrackingSlotData trackingSlotData_0)
		{
			this.method_7(trackingSlotData_0);
			if (this._slotData != null)
			{
				if (this._slotData.TrackerAnimaList.Count > 0 && this._slotData.TrackerAnimaList[this._slotData.TrackerAnimaList.Count - 1] != this._currentAnim)
				{
					this.method_11(this._slotData.TrackerAnimaList[this._slotData.TrackerAnimaList.Count - 1]);
					this.method_9(this._slotData);
				}
				else if (!this._bOnAnima)
				{
					this.method_8();
				}
			}
			else if (trackingSlotData_0 != null)
			{
				this.method_8();
			}
			if (!this._bOnAnima && trackingSlotData_0 == null)
			{
				this.method_12(false);
			}
		}

		// Token: 0x06003C6B RID: 15467 RVA: 0x0011D9EC File Offset: 0x0011BBEC
		public void method_11(QuestTrackView.eTrackerAnimation eTrackerAnimation_0)
		{
			this._currentAnim = eTrackerAnimation_0;
			this._bOnAnima = true;
			switch (eTrackerAnimation_0)
			{
			case QuestTrackView.eTrackerAnimation.eNewQuest:
				this._statusMC.gotoAndPlay("Reveal");
				break;
			case QuestTrackView.eTrackerAnimation.eTaskProgressUpdate:
				this._statusMC.gotoAndPlay("Increment");
				break;
			case QuestTrackView.eTrackerAnimation.eTaskComplete:
				this._statusMC.gotoAndPlay("TaskComplete");
				break;
			case QuestTrackView.eTrackerAnimation.eQuestComplete:
				this._statusMC.gotoAndPlay("Complete");
				break;
			case QuestTrackView.eTrackerAnimation.eQuestFail:
				this._statusMC.gotoAndPlay("Failure");
				break;
			case QuestTrackView.eTrackerAnimation.eRemove:
				this._statusMC.gotoAndPlay("Remove");
				break;
			}
		}

		// Token: 0x06003C6C RID: 15468 RVA: 0x00028C18 File Offset: 0x00026E18
		public void method_12(bool bool_0)
		{
			if (this._mcRoot != null)
			{
				this._mcRoot.visible = bool_0;
			}
		}

		// Token: 0x06003C6D RID: 15469 RVA: 0x00028C2E File Offset: 0x00026E2E
		public bool method_13()
		{
			return this._mcRoot != null && this._mcRoot.visible;
		}

		// Token: 0x06003C6E RID: 15470 RVA: 0x0011DA9C File Offset: 0x0011BC9C
		public void method_14()
		{
			MovieClip childByName = this._statusMC.getChildByName<MovieClip>("mcInnerQuestStatus");
			if (childByName != null)
			{
				childByName.gotoAndStop(this._iconState.ToString());
			}
		}

		// Token: 0x06003C6F RID: 15471 RVA: 0x0011DAD4 File Offset: 0x0011BCD4
		public void method_15()
		{
			if (this._textQuestName != null)
			{
				this._textQuestName.text = this._strTitleText;
				this._textQuestName.Color_0 = this._textColor;
			}
			MovieClip childByName = this._statusMC.getChildByName<MovieClip>("mcInnerQuestStatus");
			if (childByName != null)
			{
				UnityTextField childByName2 = childByName.getChildByName<UnityTextField>("textQuestTask");
				if (childByName2 != null)
				{
					childByName2.text = this._strDesText;
					childByName2.Color_0 = this._textColor;
				}
			}
			this.method_14();
		}

		// Token: 0x04002A74 RID: 10868
		protected MovieClip _mcRoot;

		// Token: 0x04002A75 RID: 10869
		protected MovieClip _statusMC;

		// Token: 0x04002A76 RID: 10870
		protected UnityTextField _textQuestName;

		// Token: 0x04002A77 RID: 10871
		protected QuestTrackView.TrackingSlotData _slotData;

		// Token: 0x04002A78 RID: 10872
		protected bool _bOnAnima;

		// Token: 0x04002A79 RID: 10873
		protected QuestTrackView.eTrackerAnimation _currentAnim;

		// Token: 0x04002A7A RID: 10874
		protected string _strTitleText = string.Empty;

		// Token: 0x04002A7B RID: 10875
		protected string _strDesText = string.Empty;

		// Token: 0x04002A7C RID: 10876
		public int index;

		// Token: 0x04002A7D RID: 10877
		protected QuestState _iconState = QuestState.Available;

		// Token: 0x04002A7E RID: 10878
		protected Color _textColor = Color.white;

		// Token: 0x04002A7F RID: 10879
		protected List<QuestTrackView.TrackingSlotData> _slotDatas;

		// Token: 0x04002A80 RID: 10880
		protected uniQuestTrackView.TrackSlotPanel.OnAnimationEnd _onAnimationEnd;

		// Token: 0x0200089A RID: 2202
		// (Invoke) Token: 0x06003C71 RID: 15473
		public delegate void OnAnimationEnd(QuestTrackView.TrackingSlotData slotData);
	}
}
