using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;
using XsdSettings;

// Token: 0x020007D2 RID: 2002
public class uniAchievementPopUpView : AchievementPopUpView
{
	// Token: 0x060035A2 RID: 13730 RVA: 0x00023382 File Offset: 0x00021582
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PVP_stamp.swf", "Mc_history_animation", new FuncLoad(this.method_3));
		this.method_4();
	}

	// Token: 0x060035A3 RID: 13731 RVA: 0x000233BA File Offset: 0x000215BA
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("PVP_stamp.swf");
		this._dictIcons.Clear();
	}

	// Token: 0x060035A4 RID: 13732 RVA: 0x000F5440 File Offset: 0x000F3640
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible && this._popUpPanel != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._popUpPanel);
		}
		if (this._popUpPanel != null)
		{
			this._popUpPanel.Boolean_0 = this._bVisible;
		}
	}

	// Token: 0x060035A5 RID: 13733 RVA: 0x000233E6 File Offset: 0x000215E6
	public override void vmethod_5(UIAchievementItemData uiachievementItemData_0)
	{
		if (!this.Boolean_0)
		{
			return;
		}
		if (this._popUpPanel != null)
		{
			this._popUpPanel.method_5(uiachievementItemData_0);
		}
		if (!this.Boolean_1)
		{
			this.vmethod_1(true, false);
		}
	}

	// Token: 0x060035A6 RID: 13734 RVA: 0x00023415 File Offset: 0x00021615
	private void method_3(MovieClip movieClip_0)
	{
		this._popUpPanel = new uniAchievementPopUpView.AchievementPopUpPanel();
		this._popUpPanel.method_0(movieClip_0);
		this._popUpPanel.mcRoot.visible = false;
	}

	// Token: 0x060035A7 RID: 13735 RVA: 0x000F549C File Offset: 0x000F369C
	private void method_4()
	{
		int num = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementTable.Length;
		for (int i = 0; i < num; i++)
		{
			AchievementData achievementData = MonoSingleton<AchievementSetting>.Instance.m_Achievements.m_achievementTable[i];
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2015_Achievement_VHP_icon.swf", AchievementManager.AchievementManager_0.method_9(achievementData.m_achievementId), new FuncLoad(this.method_5));
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2015_Achievement_VHP_icon.swf", AchievementManager.AchievementManager_0.ICON_BG_NAME, new FuncLoad(this.method_5));
	}

	// Token: 0x060035A8 RID: 13736 RVA: 0x00023440 File Offset: 0x00021640
	private void method_5(MovieClip movieClip_0)
	{
		if (movieClip_0 == null)
		{
			return;
		}
		this._dictIcons[movieClip_0.getSymbolName()] = movieClip_0;
	}

	// Token: 0x060035A9 RID: 13737 RVA: 0x000F5540 File Offset: 0x000F3740
	public MovieClip method_6(string string_0)
	{
		MovieClip movieClip;
		if (this._dictIcons.TryGetValue(string_0, out movieClip) && movieClip != null)
		{
			movieClip.stopAll();
			return movieClip;
		}
		DebugUtils.LogWarning(LogCategory.GUI, "Icon movie can not find name: " + string_0);
		return null;
	}

	// Token: 0x04002530 RID: 9520
	private uniAchievementPopUpView.AchievementPopUpPanel _popUpPanel;

	// Token: 0x04002531 RID: 9521
	private Dictionary<string, MovieClip> _dictIcons = new Dictionary<string, MovieClip>();

	// Token: 0x020007D3 RID: 2003
	private class AchievementPopUpPanel : GClass51
	{
		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060035AB RID: 13739 RVA: 0x0002347D File Offset: 0x0002167D
		// (set) Token: 0x060035AC RID: 13740 RVA: 0x00023485 File Offset: 0x00021685
		public bool isShowing { get; private set; }

		// Token: 0x060035AD RID: 13741 RVA: 0x000F557C File Offset: 0x000F377C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._queueData.Clear();
			this.mcRoot = base.DisplayObjectContainer_0 as MovieClip;
			if (this.mcRoot == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning!!!uniAchievementPopUpView.onInit,mcRoot is null");
			}
			this._mcContent = this.mcRoot.getChildByName<MovieClip>("mc_total");
			this._mcContent.stopAll();
			this._mcIcon = this._mcContent.getChildByName<MovieClip>("mc_stampIcon");
			this._mcIcon.visible = false;
			this._txtTitle = this._mcContent.getChildByName<UnityTextField>("tf_Title");
			this._txtDesc = this._mcContent.getChildByName<UnityTextField>("tf_Content");
			this.mcRoot.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_11));
		}

		// Token: 0x060035AE RID: 13742 RVA: 0x000F564C File Offset: 0x000F384C
		public void method_5(UIAchievementItemData uiachievementItemData_0)
		{
			if (this.isShowing)
			{
				this._queueData.Enqueue(uiachievementItemData_0);
				return;
			}
			this.isShowing = true;
			this.Boolean_0 = true;
			MovieClip movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>() as uniAchievementPopUpView).method_6(uiachievementItemData_0.iconName).newInstance();
			if (movieClip == null)
			{
				movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>() as uniAchievementPopUpView).method_6(AchievementManager.AchievementManager_0.ICON_NAME_FIX_NULL).newInstance();
			}
			movieClip.name = this._mcIcon.name;
			movieClip.stopAll();
			this._mcContent.setChildIndex(this._mcIcon, this.ICON_INDEX);
			movieClip.x = this._mcIcon.x;
			movieClip.y = this._mcIcon.y;
			this._mcContent.addChildAt(movieClip, this.ICON_INDEX);
			this._mcIcon = movieClip;
			if (this._mcIconBG == null)
			{
				this._mcIconBG = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>() as uniAchievementPopUpView).method_6(uiachievementItemData_0.iconBGName).newInstance();
				if (this._mcIconBG != null)
				{
					this._mcIconBG.x = this._mcIcon.x;
					this._mcIconBG.y = this._mcIcon.y;
					this._mcContent.addChildAt(this._mcIconBG, this.ICON_BG_INDEX);
				}
			}
			this._txtTitle.text = LocalizedString.smethod_0(new LocalizedString(uiachievementItemData_0.AchievementStageData_0.m_stageName));
			this._txtTitle.x = this._mcIcon.x + this._mcIcon.width + 10f;
			this._txtDesc.text = LocalizedString.smethod_0(new LocalizedString(uiachievementItemData_0.AchievementStageData_0.m_stageDescription));
			this._txtDesc.x = this._mcIcon.x + this._mcIcon.width + 10f;
			this.method_7();
		}

		// Token: 0x060035AF RID: 13743 RVA: 0x0002348E File Offset: 0x0002168E
		public void method_6()
		{
			this.method_9();
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060035B0 RID: 13744 RVA: 0x00023496 File Offset: 0x00021696
		// (set) Token: 0x060035B1 RID: 13745 RVA: 0x000234AD File Offset: 0x000216AD
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
						this.method_8();
					}
					else
					{
						this.method_9();
					}
				}
			}
		}

		// Token: 0x060035B2 RID: 13746 RVA: 0x000F584C File Offset: 0x000F3A4C
		private void method_7()
		{
			this.mcRoot.x = ((float)(Screen.width - 200) - this._mcContent.width) * 0.5f / GClass20.GClass20_0.Single_0;
			this.mcRoot.y = ((float)Screen.height - this.mcRoot.height) * 0.5f / GClass20.GClass20_0.Single_0 - 200f;
		}

		// Token: 0x060035B3 RID: 13747 RVA: 0x000F58C4 File Offset: 0x000F3AC4
		protected void method_8()
		{
			this._timer.method_4();
			this._timer.Start(5f);
			this.mcRoot.stopAll();
			this.mcRoot.visible = true;
			this.mcRoot.gotoAndPlay("In");
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_VHP_Icon");
		}

		// Token: 0x060035B4 RID: 13748 RVA: 0x000234C8 File Offset: 0x000216C8
		protected void method_9()
		{
			this.mcRoot.gotoAndPlay("fadeout");
			this.mcRoot.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_10));
		}

		// Token: 0x060035B5 RID: 13749 RVA: 0x000F592C File Offset: 0x000F3B2C
		protected void method_10(CEvent cevent_0)
		{
			this.mcRoot.removeEventListener("fadeoutEnd", new EventDispatcher.EventCallback(this.method_10));
			this.mcRoot.visible = false;
			this.isShowing = false;
			if (this._queueData.Count > 0)
			{
				this.method_5(this._queueData.Dequeue());
				return;
			}
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementPopUpView>().Boolean_1 = false;
		}

		// Token: 0x060035B6 RID: 13750 RVA: 0x000234F7 File Offset: 0x000216F7
		private void method_11(CEvent cevent_0)
		{
			if (this._timer.method_6() && this._timer.method_7())
			{
				this.method_6();
			}
		}

		// Token: 0x04002532 RID: 9522
		public MovieClip mcRoot;

		// Token: 0x04002533 RID: 9523
		private MovieClip _mcIcon;

		// Token: 0x04002534 RID: 9524
		private MovieClip _mcContent;

		// Token: 0x04002535 RID: 9525
		private MovieClip _mcIconBG;

		// Token: 0x04002536 RID: 9526
		private UnityTextField _txtTitle;

		// Token: 0x04002537 RID: 9527
		private UnityTextField _txtDesc;

		// Token: 0x04002538 RID: 9528
		private Queue<UIAchievementItemData> _queueData = new Queue<UIAchievementItemData>();

		// Token: 0x04002539 RID: 9529
		private int ICON_INDEX = 1;

		// Token: 0x0400253A RID: 9530
		private int ICON_BG_INDEX;

		// Token: 0x0400253B RID: 9531
		private Utils.Timer _timer = new Utils.Timer();
	}
}
