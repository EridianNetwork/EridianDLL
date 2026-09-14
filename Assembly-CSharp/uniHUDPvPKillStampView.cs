using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using XsdSettings;

// Token: 0x0200082D RID: 2093
public class uniHUDPvPKillStampView : HUDPvPKillStampView
{
	// Token: 0x060038A2 RID: 14498 RVA: 0x00107978 File Offset: 0x00105B78
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._KillingStampIcon.Clear();
		for (int i = 0; i < this.m_KillingStampName.Length; i++)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PVP_Stamp_icon.swf", this.m_KillingStampName[i], new FuncLoad(this.method_12));
		}
	}

	// Token: 0x060038A3 RID: 14499 RVA: 0x001079D8 File Offset: 0x00105BD8
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._KillStampPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._KillStampHistoryPanel);
		this._KillStampPanel = null;
		this._KillStampHistoryPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("PVP_stamp.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("PVP_Stamp_icon.swf");
	}

	// Token: 0x060038A4 RID: 14500 RVA: 0x00107A60 File Offset: 0x00105C60
	private void method_12(MovieClip movieClip_0)
	{
		if (movieClip_0 == null)
		{
			return;
		}
		movieClip_0.name = movieClip_0.getSymbolName();
		if (!this._KillingStampIcon.ContainsKey(movieClip_0.name))
		{
			this._KillingStampIcon.Add(movieClip_0.getSymbolName(), movieClip_0);
		}
		if (this._KillingStampIcon.Count == this.m_KillingStampName.Length)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PVP_stamp.swf", "Mc_history_line", new FuncLoad(this.method_14));
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PVP_stamp.swf", "Mc_bigstamp", new FuncLoad(this.method_13));
		}
	}

	// Token: 0x060038A5 RID: 14501 RVA: 0x00025AD0 File Offset: 0x00023CD0
	private void method_13(MovieClip movieClip_0)
	{
		this._KillStampPanel = new uniHUDPvPKillStampView.PvPKillStampPanel();
		this._KillStampPanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._KillStampPanel);
	}

	// Token: 0x060038A6 RID: 14502 RVA: 0x00025B05 File Offset: 0x00023D05
	private void method_14(MovieClip movieClip_0)
	{
		this._KillStampHistoryPanel = new uniHUDPvPKillStampView.PvPKillStampHistoryPanel();
		this._KillStampHistoryPanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._KillStampHistoryPanel);
	}

	// Token: 0x060038A7 RID: 14503 RVA: 0x00025B3A File Offset: 0x00023D3A
	public override void vmethod_6(ScoringActionType scoringActionType_0)
	{
		base.vmethod_6(scoringActionType_0);
		if (this._KillStampPanel != null)
		{
			this._KillStampPanel.method_7(scoringActionType_0);
		}
	}

	// Token: 0x060038A8 RID: 14504 RVA: 0x00025B57 File Offset: 0x00023D57
	public override void Update(float fDeltaTime)
	{
		base.Update(fDeltaTime);
		if (this._KillStampHistoryPanel != null)
		{
			this._KillStampHistoryPanel.Update();
		}
	}

	// Token: 0x060038A9 RID: 14505 RVA: 0x00025B73 File Offset: 0x00023D73
	public override void vmethod_5(int int_0, ScoringActionType scoringActionType_0, bool bool_0, bool bool_1 = false, bool bool_2 = true)
	{
		if (this._KillStampHistoryPanel != null)
		{
			this._KillStampHistoryPanel.method_5(int_0, scoringActionType_0, bool_0, bool_1, bool_2);
		}
	}

	// Token: 0x060038AA RID: 14506 RVA: 0x00107B0C File Offset: 0x00105D0C
	public MovieClip method_15(string string_0)
	{
		MovieClip movieClip = null;
		this._KillingStampIcon.TryGetValue(string_0, out movieClip);
		return movieClip;
	}

	// Token: 0x060038AB RID: 14507 RVA: 0x00107B2C File Offset: 0x00105D2C
	public void method_16(MovieClip movieClip_0, string string_0)
	{
		if (movieClip_0 == null || string_0.Length == 0)
		{
			return;
		}
		MovieClip childByName = movieClip_0.getChildByName<MovieClip>("mc_StampIcon");
		childByName.visible = false;
		MovieClip movieClip = null;
		this._KillingStampIcon.TryGetValue(string_0, out movieClip);
		if (movieClip == null)
		{
			return;
		}
		MovieClip movieClip2 = new BadAssMovieClip(Utility.smethod_5("PVP_Stamp_icon.swf:", movieClip.getSymbolName()));
		movieClip2.name = movieClip.name;
		movieClip_0.addChildAt(movieClip2, movieClip_0.getChildIndex(childByName));
		movieClip2.x = childByName.x;
		movieClip2.y = childByName.y;
	}

	// Token: 0x040027A9 RID: 10153
	private uniHUDPvPKillStampView.PvPKillStampPanel _KillStampPanel;

	// Token: 0x040027AA RID: 10154
	private uniHUDPvPKillStampView.PvPKillStampHistoryPanel _KillStampHistoryPanel;

	// Token: 0x040027AB RID: 10155
	protected Dictionary<string, MovieClip> _KillingStampIcon = new Dictionary<string, MovieClip>();

	// Token: 0x0200082E RID: 2094
	public class KillStampHistoryItem : GClass51
	{
		// Token: 0x060038AD RID: 14509 RVA: 0x00107BB8 File Offset: 0x00105DB8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_ItemInfo = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_ItemInfo == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: KillStampHistoryItem onInit() 'mc_ItemInfo' is null! KillStampHistoryItem won't work!!!");
				return;
			}
			this.mc_Total = this.mc_ItemInfo.getChildByName<MovieClip>("mc_total");
			this.mc_StampContent = this.mc_Total.getChildByName<MovieClip>("mc_stampIcon");
			this.mc_StampContent.visible = false;
			this.mc_ItemInfo.gotoAndStop("fadeoutEnd");
			this.tf_Title = this.mc_Total.getChildByName<TextField>("tf_Title");
			this.tf_Content = this.mc_Total.getChildByName<TextField>("tf_Content");
		}

		// Token: 0x060038AE RID: 14510 RVA: 0x00107C64 File Offset: 0x00105E64
		public void method_5(ScoringActionType scoringActionType_0, bool bool_0, bool bool_1, bool bool_2)
		{
			if (this.newIconMC != null)
			{
				this.mc_Total.removeChild(this.newIconMC);
			}
			if (!bool_2)
			{
				this.method_8();
				return;
			}
			uniHUDPvPKillStampView uniHUDPvPKillStampView = (uniHUDPvPKillStampView)MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>();
			if (uniHUDPvPKillStampView != null)
			{
				MovieClip movieClip = uniHUDPvPKillStampView.method_15(scoringActionType_0.ToString());
				if (movieClip != null)
				{
					this.mc_StampContent.visible = false;
					this.newIconMC = new BadAssMovieClip(Utility.smethod_5("PVP_Stamp_icon.swf:", movieClip.getSymbolName()));
					this.newIconMC.scaleX = 0.38f;
					this.newIconMC.scaleY = 0.38f;
					this.newIconMC.name = movieClip.name;
					this.mc_Total.addChildAt(this.newIconMC, this.mc_Total.getChildIndex(this.mc_StampContent));
					this.newIconMC.x = this.mc_StampContent.x;
					this.newIconMC.y = this.mc_StampContent.y;
				}
			}
			this.mc_ItemInfo.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
			this.tf_Title.text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5(scoringActionType_0.ToString(), "_Name")));
			this.tf_Content.text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5(scoringActionType_0.ToString(), "_Des")));
			if (bool_0)
			{
				this.mc_ItemInfo.gotoAndPlay("In");
			}
			else if (!bool_1)
			{
				this.mc_ItemInfo.gotoAndStop("normal");
			}
			else
			{
				this.method_8();
			}
			this.m_bPlayingFadeout = false;
		}

		// Token: 0x060038AF RID: 14511 RVA: 0x00107E18 File Offset: 0x00106018
		public void Update(int index)
		{
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().method_10(index) && !this.m_bPlayingFadeout && !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().method_9(index))
			{
				this.m_bPlayingFadeout = true;
				this.mc_ItemInfo.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_7));
				this.mc_ItemInfo.gotoAndPlay("fadeout");
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().method_8(index);
			}
		}

		// Token: 0x060038B0 RID: 14512 RVA: 0x00107EA4 File Offset: 0x001060A4
		protected void method_6(CEvent cevent_0)
		{
			if (this.newIconMC != null && !this.mc_Total.contains(this.newIconMC))
			{
				this.mc_StampContent.visible = false;
				this.newIconMC.scaleX = 0.38f;
				this.newIconMC.scaleY = 0.38f;
				this.mc_Total.addChildAt(this.newIconMC, this.mc_Total.getChildIndex(this.mc_StampContent));
				this.newIconMC.x = this.mc_StampContent.x;
				this.newIconMC.y = this.mc_StampContent.y;
			}
		}

		// Token: 0x060038B1 RID: 14513 RVA: 0x00107F4C File Offset: 0x0010614C
		protected void method_7(CEvent cevent_0)
		{
			this.mc_ItemInfo.removeFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_7));
			this.mc_ItemInfo.removeFrameScript(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
			this.mc_Total.removeChild(this.newIconMC);
			this.m_bPlayingFadeout = false;
		}

		// Token: 0x060038B2 RID: 14514 RVA: 0x00025B8F File Offset: 0x00023D8F
		public void method_8()
		{
			this.m_bPlayingFadeout = false;
			if (this.newIconMC != null)
			{
				this.mc_Total.removeChild(this.newIconMC);
			}
			if (this.mc_ItemInfo != null)
			{
				this.mc_ItemInfo.gotoAndStop("fadeoutEnd");
			}
		}

		// Token: 0x040027AC RID: 10156
		protected MovieClip mc_ItemInfo;

		// Token: 0x040027AD RID: 10157
		protected MovieClip mc_Total;

		// Token: 0x040027AE RID: 10158
		protected MovieClip mc_StampContent;

		// Token: 0x040027AF RID: 10159
		protected MovieClip newIconMC;

		// Token: 0x040027B0 RID: 10160
		protected TextField tf_Title;

		// Token: 0x040027B1 RID: 10161
		protected TextField tf_Content;

		// Token: 0x040027B2 RID: 10162
		private bool m_bPlayingFadeout;
	}

	// Token: 0x0200082F RID: 2095
	protected class PvPKillStampHistoryPanel : GClass51
	{
		// Token: 0x060038B4 RID: 14516 RVA: 0x00107FAC File Offset: 0x001061AC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PvPKillStampHistoryPanel onInit() 'mc_root' is null! PvPKillStampHistoryPanel won't work!!!");
				return;
			}
			this.m_HistoryItemList.Clear();
			uniHUDPvPKillStampView.KillStampHistoryItem killStampHistoryItem = new uniHUDPvPKillStampView.KillStampHistoryItem();
			killStampHistoryItem.method_0(this.mc_root.getChildByName<MovieClip>("line_1"));
			uniHUDPvPKillStampView.KillStampHistoryItem killStampHistoryItem2 = new uniHUDPvPKillStampView.KillStampHistoryItem();
			killStampHistoryItem2.method_0(this.mc_root.getChildByName<MovieClip>("line_2"));
			uniHUDPvPKillStampView.KillStampHistoryItem killStampHistoryItem3 = new uniHUDPvPKillStampView.KillStampHistoryItem();
			killStampHistoryItem3.method_0(this.mc_root.getChildByName<MovieClip>("line_3"));
			uniHUDPvPKillStampView.KillStampHistoryItem killStampHistoryItem4 = new uniHUDPvPKillStampView.KillStampHistoryItem();
			killStampHistoryItem4.method_0(this.mc_root.getChildByName<MovieClip>("line_4"));
			this.m_HistoryItemList.Add(killStampHistoryItem);
			this.m_HistoryItemList.Add(killStampHistoryItem2);
			this.m_HistoryItemList.Add(killStampHistoryItem3);
			this.m_HistoryItemList.Add(killStampHistoryItem4);
		}

		// Token: 0x060038B5 RID: 14517 RVA: 0x00108094 File Offset: 0x00106294
		public void Update()
		{
			for (int i = 0; i < this.m_HistoryItemList.Count; i++)
			{
				this.m_HistoryItemList[i].Update(i);
			}
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x00025BDC File Offset: 0x00023DDC
		public void method_5(int int_0, ScoringActionType scoringActionType_0, bool bool_0, bool bool_1 = false, bool bool_2 = true)
		{
			if (this.m_HistoryItemList[int_0] != null)
			{
				this.m_HistoryItemList[int_0].method_5(scoringActionType_0, bool_0, bool_1, bool_2);
			}
		}

		// Token: 0x040027B3 RID: 10163
		public MovieClip mc_root;

		// Token: 0x040027B4 RID: 10164
		protected List<uniHUDPvPKillStampView.KillStampHistoryItem> m_HistoryItemList = new List<uniHUDPvPKillStampView.KillStampHistoryItem>();
	}

	// Token: 0x02000830 RID: 2096
	protected class PvPKillStampPanel : GClass51
	{
		// Token: 0x060038B8 RID: 14520 RVA: 0x001080CC File Offset: 0x001062CC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PvPKillStampPanel onInit() 'mc_root' is null! PvPKillStampPanel won't work!!!");
				return;
			}
			this.mc_Content = this.mc_root.getChildByName<MovieClip>("mc_stampContent");
			this.mc_Content.stopAll();
			this.mc_StampIcon = this.mc_root.getChildByName<MovieClip>("mc_stampContent").getChildByName<MovieClip>("mc_StampIcon");
			this.mc_StampIcon.visible = false;
			this.mc_root.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
		}

		// Token: 0x060038B9 RID: 14521 RVA: 0x00025C03 File Offset: 0x00023E03
		protected void method_5(CEvent cevent_0)
		{
			if (!this.m_bShowingKillStamp)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().method_7();
			}
		}

		// Token: 0x060038BA RID: 14522 RVA: 0x00108170 File Offset: 0x00106370
		protected void method_6(CEvent cevent_0)
		{
			if (this.newIconMC != null && !this.mc_Content.contains(this.newIconMC))
			{
				this.mc_StampIcon.visible = false;
				this.mc_Content.addChildAt(this.newIconMC, this.mc_Content.getChildIndex(this.mc_StampIcon));
				this.newIconMC.x = this.mc_StampIcon.x;
				this.newIconMC.y = this.mc_StampIcon.y;
			}
		}

		// Token: 0x060038BB RID: 14523 RVA: 0x001081F4 File Offset: 0x001063F4
		public void method_7(ScoringActionType scoringActionType_0)
		{
			if (this.mc_Content != null)
			{
				this.mc_Content.visible = true;
				uniHUDPvPKillStampView uniHUDPvPKillStampView = (uniHUDPvPKillStampView)MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>();
				if (uniHUDPvPKillStampView != null)
				{
					this.mc_StampIcon.visible = false;
					MovieClip movieClip = uniHUDPvPKillStampView.method_15(scoringActionType_0.ToString());
					if (movieClip == null)
					{
						return;
					}
					this.newIconMC = movieClip.newInstance();
					this.newIconMC.name = movieClip.name;
					this.mc_Content.addChildAt(this.newIconMC, this.mc_Content.getChildIndex(this.mc_StampIcon));
					this.newIconMC.x = this.mc_StampIcon.x;
					this.newIconMC.y = this.mc_StampIcon.y;
				}
				this.mc_Content.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
				this.m_bShowingKillStamp = true;
				this.mc_Content.addFrameScript("end", new EventDispatcher.EventCallback(this.method_8));
				this.mc_Content.gotoAndPlay(1);
			}
		}

		// Token: 0x060038BC RID: 14524 RVA: 0x00025C21 File Offset: 0x00023E21
		protected void method_8(CEvent cevent_0)
		{
			this.mc_Content.removeChild(this.newIconMC);
			this.mc_Content.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
			this.m_bShowingKillStamp = false;
		}

		// Token: 0x040027B5 RID: 10165
		public MovieClip mc_root;

		// Token: 0x040027B6 RID: 10166
		private MovieClip mc_StampIcon;

		// Token: 0x040027B7 RID: 10167
		private MovieClip mc_Content;

		// Token: 0x040027B8 RID: 10168
		private bool m_bShowingKillStamp;

		// Token: 0x040027B9 RID: 10169
		private MovieClip newIconMC;
	}
}
