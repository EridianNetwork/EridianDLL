using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x020007CF RID: 1999
public class uniAchievementBoardView : AchievementBoardView
{
	// Token: 0x06003584 RID: 13700 RVA: 0x00023214 File Offset: 0x00021414
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2015_Achievement_VHP.swf", "Mc_Achievement_animation", new FuncLoad(this.method_3));
	}

	// Token: 0x06003585 RID: 13701 RVA: 0x000F48B8 File Offset: 0x000F2AB8
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this._boardPanel != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._boardPanel);
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2015_Achievement_VHP.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2015_Achievement_VHP_icon.swf");
	}

	// Token: 0x06003586 RID: 13702 RVA: 0x000F4920 File Offset: 0x000F2B20
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			if (this._boardPanel != null)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._boardPanel);
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			}
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		}
		if (this._boardPanel != null)
		{
			this._boardPanel.Boolean_0 = this._bVisible;
		}
	}

	// Token: 0x06003587 RID: 13703 RVA: 0x00023246 File Offset: 0x00021446
	private void method_3(MovieClip movieClip_0)
	{
		this._boardPanel = new uniAchievementBoardView.AchievementPanel();
		this._boardPanel.method_0(movieClip_0);
		(this._boardPanel.DisplayObjectContainer_0 as MovieClip).visible = false;
	}

	// Token: 0x06003588 RID: 13704 RVA: 0x00023276 File Offset: 0x00021476
	public override void vmethod_5()
	{
		base.vmethod_5();
		if (this._boardPanel != null)
		{
			this._boardPanel.method_6();
		}
	}

	// Token: 0x04002515 RID: 9493
	private uniAchievementBoardView.AchievementPanel _boardPanel;

	// Token: 0x020007D0 RID: 2000
	private class AchievementPanel : GClass51
	{
		// Token: 0x06003589 RID: 13705 RVA: 0x00023291 File Offset: 0x00021491
		public AchievementPanel()
		{
			this._items = new uniAchievementBoardView.AchievementItem[this.ITEM_PAGE_COUNT];
		}

		// Token: 0x0600358A RID: 13706 RVA: 0x000F49B0 File Offset: 0x000F2BB0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcRoot = this.displayObjectContainer_0 as MovieClip;
			if (this.mcRoot == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "Warning!AchievementPanel:onInit(),mcRoot is null!");
				return;
			}
			this.mcRoot.visible = false;
			if (this._sb != null)
			{
				this._sb.Int32_1 = 0;
			}
			if (this._mcLevelInfo == null)
			{
				this._mcLevelInfo = this.mcRoot.getChildByName<MovieClip>("mcBoardPanel").getChildByName<MovieClip>("mcLevelInfo");
			}
			if (this._mcLevelInfo != null)
			{
				this._txtLevelTitle = this._mcLevelInfo.getChildByName<UnityTextField>("tfLevelTitle");
				this._txtPoint = this._mcLevelInfo.getChildByName<UnityTextField>("tfPoint");
				this._mcProgressBar = this._mcLevelInfo.getChildByName<BadAssMovieClip>("mcProgressBar");
				this._progressBarOriginWidth = this._mcProgressBar.width;
				this.UIAchievementLevelData_0 = AchievementManager.AchievementManager_0.method_8();
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x0600358B RID: 13707 RVA: 0x000232BC File Offset: 0x000214BC
		// (set) Token: 0x0600358C RID: 13708 RVA: 0x000F4A9C File Offset: 0x000F2C9C
		public UIAchievementLevelData UIAchievementLevelData_0
		{
			get
			{
				return this._levelData;
			}
			set
			{
				if (this._levelData == value)
				{
					return;
				}
				if (this._levelData != null)
				{
					this._levelData.Event_0 -= this.method_5;
				}
				this._levelData = value;
				if (this._levelData != null)
				{
					this._levelData.Event_0 += this.method_5;
					this.method_5();
				}
			}
		}

		// Token: 0x0600358D RID: 13709 RVA: 0x000F4B00 File Offset: 0x000F2D00
		private void method_5()
		{
			if (this._levelData.Int32_0 < 0)
			{
				this._mcLevelInfo.visible = false;
				return;
			}
			this._mcLevelInfo.visible = true;
			this._txtLevelTitle.text = LocalizedString.smethod_0(new LocalizedString(this._levelData.data.m_levelTitle));
			int levelMinPoint = this._levelData.nextLevelData.m_levelMinPoint;
			this._txtPoint.text = Utility.smethod_6(Utility.smethod_8(this._levelData.Int32_0), "/", Utility.smethod_8(levelMinPoint));
			if (this._levelData.data == this._levelData.nextLevelData)
			{
				this._mcProgressBar.Single_0 = this._progressBarOriginWidth;
			}
			else
			{
				float num = Mathf.Clamp01((float)(this._levelData.Int32_0 - this._levelData.data.m_levelMinPoint) / (float)(this._levelData.nextLevelData.m_levelMinPoint - this._levelData.data.m_levelMinPoint));
				if (this._levelData.Int32_0 <= 0)
				{
					this._mcProgressBar.Single_0 = 0f;
				}
				else
				{
					this._mcProgressBar.Single_0 = this._progressBarOriginWidth * num;
				}
			}
		}

		// Token: 0x0600358E RID: 13710 RVA: 0x000F4C3C File Offset: 0x000F2E3C
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			string name = movieClip.name;
			switch (name)
			{
			case "mcBtnClose":
				this._btnClose = new GClass25();
				this._btnClose.method_0(movieClip);
				this._btnClose.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_10));
				return true;
			case "mcScrollBar":
			{
				this._sb = new GClass46();
				this._sb.method_0(movieClip);
				this._sb.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_11));
				GClass45 sb = this._sb;
				this._sb.int_1 = 0;
				sb.int_0 = 0;
				this._sb.method_10(this.ITEM_PAGE_COUNT, 0, this.method_9() - this.ITEM_PAGE_COUNT, 1);
				(base.DisplayObjectContainer_0 as MovieClip).addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this._sb.method_12), false);
				return true;
			}
			case "mcLevelInfo":
				this._mcLevelInfo = movieClip;
				this._txtLevelTitle = this._mcLevelInfo.getChildByName<UnityTextField>("tfLevelTitle");
				this._txtLevelTitle.text = "TestTest";
				this._txtPoint = this._mcLevelInfo.getChildByName<UnityTextField>("tfPoint");
				return true;
			case "mcBoardPanel":
				this._mcPanel = movieClip;
				return true;
			}
			if (movieClip.name.StartsWith(this.ITEM_NAME_PREFIX))
			{
				int num2;
				int.TryParse(movieClip.name.Substring(this.ITEM_NAME_PREFIX.Length), out num2);
				if (num2 >= this._items.Length || num2 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, "achievement item name out of range!");
					return true;
				}
				uniAchievementBoardView.AchievementItem achievementItem = new uniAchievementBoardView.AchievementItem();
				achievementItem.method_0(movieClip);
				achievementItem.Boolean_1 = false;
				this._items[num2] = achievementItem;
			}
			return true;
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x0600358F RID: 13711 RVA: 0x000232C4 File Offset: 0x000214C4
		// (set) Token: 0x06003590 RID: 13712 RVA: 0x000232DB File Offset: 0x000214DB
		public virtual bool Boolean_0
		{
			get
			{
				return this.mcRoot != null && this.mcRoot.visible;
			}
			set
			{
				if (this.mcRoot != null)
				{
					if (value)
					{
						this.method_6();
						this.method_7();
					}
					else
					{
						this.method_8();
					}
				}
			}
		}

		// Token: 0x06003591 RID: 13713 RVA: 0x000F4E64 File Offset: 0x000F3064
		public void method_6()
		{
			List<UIAchievementItemData> list = AchievementManager.AchievementManager_0.method_6();
			this._sb.Boolean_1 = list.Count > this.ITEM_PAGE_COUNT;
			this._sb.method_10(this.ITEM_PAGE_COUNT, 0, list.Count - this.ITEM_PAGE_COUNT, 1);
			int num = ((list.Count <= this.ITEM_PAGE_COUNT) ? list.Count : this.ITEM_PAGE_COUNT);
			for (int i = 0; i < num; i++)
			{
				uniAchievementBoardView.AchievementItem achievementItem = this._items[i];
				if (achievementItem != null)
				{
					achievementItem.UIAchievementItemData_0 = list[i + this._sb.Int32_1];
					achievementItem.Boolean_1 = true;
				}
			}
			for (int j = num; j < this.ITEM_PAGE_COUNT; j++)
			{
				if (this._items[j] != null)
				{
					this._items[j].Boolean_1 = false;
				}
			}
		}

		// Token: 0x06003592 RID: 13714 RVA: 0x000232FC File Offset: 0x000214FC
		protected void method_7()
		{
			this.mcRoot.visible = true;
			this.mcRoot.gotoAndPlay("Open");
		}

		// Token: 0x06003593 RID: 13715 RVA: 0x000F4F3C File Offset: 0x000F313C
		protected void method_8()
		{
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
			this.mcRoot.gotoAndPlay("Close");
			this.mcRoot.addFrameScript("End", new EventDispatcher.EventCallback(this.method_12));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_21();
		}

		// Token: 0x06003594 RID: 13716 RVA: 0x0002331A File Offset: 0x0002151A
		protected int method_9()
		{
			return AchievementManager.AchievementManager_0.method_6().Count;
		}

		// Token: 0x06003595 RID: 13717 RVA: 0x0002332B File Offset: 0x0002152B
		protected void method_10(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementBoardView>().vmethod_4();
		}

		// Token: 0x06003596 RID: 13718 RVA: 0x00023342 File Offset: 0x00021542
		protected void method_11(CEvent cevent_0)
		{
			if (this.mcRoot.visible)
			{
				this.method_6();
			}
		}

		// Token: 0x06003597 RID: 13719 RVA: 0x000F4F9C File Offset: 0x000F319C
		protected void method_12(CEvent cevent_0)
		{
			this.mcRoot.removeEventListener("End", new EventDispatcher.EventCallback(this.method_12));
			this.mcRoot.visible = false;
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		// Token: 0x06003598 RID: 13720 RVA: 0x000F4FF8 File Offset: 0x000F31F8
		protected MovieClip method_13(MovieClip movieClip_0, string string_1)
		{
			MovieClip childByName = movieClip_0.getChildByName<MovieClip>(string_1);
			if (childByName != null)
			{
				return childByName;
			}
			int i = 0;
			int numChildren = movieClip_0.numChildren;
			while (i < numChildren)
			{
				if (movieClip_0.getChildAt<MovieClip>(i) != null)
				{
					return this.method_13(movieClip_0.getChildAt<MovieClip>(i), string_1);
				}
				i++;
			}
			return null;
		}

		// Token: 0x04002516 RID: 9494
		public MovieClip mcRoot;

		// Token: 0x04002517 RID: 9495
		private int ITEM_PAGE_COUNT = 5;

		// Token: 0x04002518 RID: 9496
		private string ITEM_NAME_PREFIX = "item";

		// Token: 0x04002519 RID: 9497
		protected uniAchievementBoardView.AchievementItem[] _items;

		// Token: 0x0400251A RID: 9498
		private GClass25 _btnClose;

		// Token: 0x0400251B RID: 9499
		protected GClass46 _sb;

		// Token: 0x0400251C RID: 9500
		protected MovieClip _mcPanel;

		// Token: 0x0400251D RID: 9501
		protected MovieClip _mcLevelInfo;

		// Token: 0x0400251E RID: 9502
		protected UnityTextField _txtLevelTitle;

		// Token: 0x0400251F RID: 9503
		protected UnityTextField _txtPoint;

		// Token: 0x04002520 RID: 9504
		protected BadAssMovieClip _mcProgressBar;

		// Token: 0x04002521 RID: 9505
		private UIAchievementLevelData _levelData;

		// Token: 0x04002522 RID: 9506
		private float _progressBarOriginWidth;
	}

	// Token: 0x020007D1 RID: 2001
	private class AchievementItem : GClass25
	{
		// Token: 0x0600359A RID: 13722 RVA: 0x000F5040 File Offset: 0x000F3240
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = false;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this._mcIcon = movieClip.getChildByName<MovieClip>("mcIcon");
			this._mcIconBG = movieClip.getChildByName<MovieClip>("mcIconBG");
			this._mcProgress = movieClip.getChildByName<MovieClip>("mcProgress");
			this._mcInProgress = movieClip.getChildByName<BadAssMovieClip>("mcInProgress");
			if (this._mcProgress != null)
			{
				this._mcProgressBar = this._mcProgress.getChildByName<BadAssMovieClip>("mcProgressBar");
				this._progressBarOriginWidth = this._mcProgressBar.width;
				this._txtProgress = this._mcProgress.getChildByName<UnityTextField>("tfProgress");
			}
			this._txtTitle = movieClip.getChildByName<UnityTextField>("tfTitle");
			this._txtGoal = movieClip.getChildByName<UnityTextField>("tfGoal");
			this._txtRewardPoint = movieClip.getChildByName<UnityTextField>("tfRewardPoint");
			this.Boolean_6 = false;
			movieClip.stopAll();
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x0600359B RID: 13723 RVA: 0x0002335F File Offset: 0x0002155F
		// (set) Token: 0x0600359C RID: 13724 RVA: 0x000F5134 File Offset: 0x000F3334
		public bool Boolean_0
		{
			get
			{
				return this._bEarned;
			}
			set
			{
				this._mcProgress.visible = !value;
				if (this._bEarned == value)
				{
					return;
				}
				this._bEarned = value;
				if (this._bEarned)
				{
					(base.DisplayObjectContainer_0 as MovieClip).gotoAndStop("complete");
				}
				else
				{
					(base.DisplayObjectContainer_0 as MovieClip).gotoAndStop("inprogress");
				}
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x0600359D RID: 13725 RVA: 0x00023367 File Offset: 0x00021567
		// (set) Token: 0x0600359E RID: 13726 RVA: 0x000F5198 File Offset: 0x000F3398
		public UIAchievementItemData UIAchievementItemData_0
		{
			get
			{
				return this._itemData;
			}
			set
			{
				if (this._itemData == value)
				{
					return;
				}
				if (this._itemData != null)
				{
					this._itemData.Event_0 -= this.method_19;
				}
				this._itemData = value;
				if (this._itemData != null)
				{
					this._itemData.Event_0 += this.method_19;
					this.method_19();
				}
			}
		}

		// Token: 0x0600359F RID: 13727 RVA: 0x000F51FC File Offset: 0x000F33FC
		private void method_19()
		{
			MovieClip childByName = this._mcIcon.getChildByName<MovieClip>("icon");
			if (childByName != null)
			{
				this._mcIcon.removeChild(childByName);
			}
			MovieClip movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>() as uniAchievementPopUpView).method_6(this.UIAchievementItemData_0.iconName).newInstance();
			if (movieClip == null)
			{
				movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>() as uniAchievementPopUpView).method_6(AchievementManager.AchievementManager_0.ICON_NAME_FIX_NULL).newInstance();
			}
			movieClip.name = "icon";
			movieClip.stopAll();
			this._mcIcon.addChild(movieClip);
			MovieClip movieClip2 = this._mcIconBG.getChildByName<MovieClip>("iconBG");
			if (movieClip2 == null)
			{
				movieClip2 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>() as uniAchievementPopUpView).method_6(this.UIAchievementItemData_0.iconBGName).newInstance();
				movieClip2.name = "iconBG";
				movieClip2.stopAll();
				this._mcIconBG.addChild(movieClip2);
			}
			movieClip2.gotoAndStop(this.UIAchievementItemData_0.AchievementStageData_0.m_stageFrame);
			this._txtTitle.text = LocalizedString.smethod_0(new LocalizedString(this._itemData.AchievementStageData_0.m_stageName));
			this._txtGoal.text = LocalizedString.smethod_0(new LocalizedString(this._itemData.AchievementStageData_0.m_stageDescription));
			this._txtRewardPoint.text = Utility.smethod_8(this._itemData.AchievementStageData_0.m_stageRewardPoint);
			this.Boolean_0 = this._itemData.isAccomplished;
			if (!this.Boolean_0)
			{
				bool flag = this._itemData.goalType == UIAchievementItemData.GoalType.NUMBER;
				this._mcInProgress.visible = !flag;
				this._mcProgressBar.visible = flag;
				this._txtProgress.visible = flag;
				if (flag)
				{
					int goalNumber = this._itemData.goalNumber;
					int progress = this._itemData.progress;
					if (progress == 0)
					{
						this._mcProgressBar.Single_0 = 0f;
					}
					else
					{
						this._mcProgressBar.Single_0 = Mathf.Clamp01((float)progress / (float)goalNumber) * this._progressBarOriginWidth;
					}
					this._txtProgress.text = Utility.smethod_6(Utility.smethod_8(progress), "/", Utility.smethod_8(goalNumber));
				}
			}
		}

		// Token: 0x060035A0 RID: 13728 RVA: 0x00021F71 File Offset: 0x00020171
		protected override void vmethod_11()
		{
			base.vmethod_11();
		}

		// Token: 0x04002524 RID: 9508
		protected MovieClip _mcIcon;

		// Token: 0x04002525 RID: 9509
		protected MovieClip _mcIconBG;

		// Token: 0x04002526 RID: 9510
		protected MovieClip _mcProgress;

		// Token: 0x04002527 RID: 9511
		protected BadAssMovieClip _mcProgressBar;

		// Token: 0x04002528 RID: 9512
		protected float _progressBarOriginWidth;

		// Token: 0x04002529 RID: 9513
		protected UnityTextField _txtTitle;

		// Token: 0x0400252A RID: 9514
		protected UnityTextField _txtGoal;

		// Token: 0x0400252B RID: 9515
		protected UnityTextField _txtRewardPoint;

		// Token: 0x0400252C RID: 9516
		protected BadAssMovieClip _mcInProgress;

		// Token: 0x0400252D RID: 9517
		protected UnityTextField _txtProgress;

		// Token: 0x0400252E RID: 9518
		private bool _bEarned;

		// Token: 0x0400252F RID: 9519
		private UIAchievementItemData _itemData;
	}
}
