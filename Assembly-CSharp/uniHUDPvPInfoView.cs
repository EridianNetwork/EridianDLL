using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x0200081B RID: 2075
public class uniHUDPvPInfoView : HUDPvPInfoView
{
	// Token: 0x06003823 RID: 14371 RVA: 0x00103F58 File Offset: 0x00102158
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PVP_HUD.swf", "Panel_PVPHud", new FuncLoad(this.method_10));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PVP_HUD.swf", "Movie_Background", new FuncLoad(this.method_9));
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_0();
		if (playlist != null && MatchmakingService.smethod_0(playlist.m_gameMode) == GamemodeType.GamemodeClaptrapSoccer)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PVP_Claptrap.swf", "Mc_Mode_Claptrap", new FuncLoad(this.method_7));
		}
		BadAssMovieClip badAssMovieClip = new BadAssMovieClip("SightBead.swf", "Panel_pvp_score");
		this.method_11(badAssMovieClip);
	}

	// Token: 0x06003824 RID: 14372 RVA: 0x0010401C File Offset: 0x0010221C
	private void method_7(MovieClip movieClip_0)
	{
		this.m_claptrapPanel = new uniHUDPvPInfoView.PVPHudClaptrap();
		this.m_claptrapPanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this.m_claptrapPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PVP_Claptrap.swf", "Panel_IconsCollection", new FuncLoad(this.method_8));
	}

	// Token: 0x06003825 RID: 14373 RVA: 0x00025477 File Offset: 0x00023677
	private void method_8(MovieClip movieClip_0)
	{
		this.m_claptrapIcon = new uniHUDPvPInfoView.PVPHudClaptrapIcon();
		this.m_claptrapIcon.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this.m_claptrapIcon);
	}

	// Token: 0x06003826 RID: 14374 RVA: 0x000254AC File Offset: 0x000236AC
	private void method_9(MovieClip movieClip_0)
	{
		this.m_BackGround = new uniHUDPvPInfoView.BackGroundBoard();
		this.m_BackGround.method_0(movieClip_0);
	}

	// Token: 0x06003827 RID: 14375 RVA: 0x00104088 File Offset: 0x00102288
	private void method_10(MovieClip movieClip_0)
	{
		this.m_pvpHudScreen = new uniHUDPvPInfoView.PVPHudScreen();
		this.m_pvpHudScreen.m_rootView = this;
		this.m_pvpHudScreen.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this.m_pvpHudScreen);
	}

	// Token: 0x06003828 RID: 14376 RVA: 0x001040D4 File Offset: 0x001022D4
	private void method_11(MovieClip movieClip_0)
	{
		float num = 0f;
		float num2;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num2, out num);
		movieClip_0.x = num2;
		movieClip_0.y = num;
		movieClip_0.visible = true;
		this.m_ScoringItemContainer = new uniHUDPvPInfoView.ScoringInfoContainer();
		this.m_ScoringItemContainer.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_ScoringItemContainer);
	}

	// Token: 0x06003829 RID: 14377 RVA: 0x000254C6 File Offset: 0x000236C6
	public override void vmethod_9()
	{
		if (this.m_BackGround != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_BackGround);
		}
	}

	// Token: 0x0600382A RID: 14378 RVA: 0x000254EB File Offset: 0x000236EB
	public override void vmethod_11()
	{
		if (this.m_claptrapPanel != null)
		{
			this.m_claptrapPanel.method_7();
		}
	}

	// Token: 0x0600382B RID: 14379 RVA: 0x00025500 File Offset: 0x00023700
	public override void vmethod_12()
	{
		if (this.m_claptrapPanel != null)
		{
			this.m_claptrapPanel.method_8();
		}
		if (this.m_claptrapIcon != null)
		{
			this.m_claptrapIcon.method_6();
		}
		MonoSingleton<AppManager>.Instance.method_0().imethod_0("UI_CPSoccer_RoundStart");
	}

	// Token: 0x0600382C RID: 14380 RVA: 0x00104148 File Offset: 0x00102348
	public override void vmethod_13(int int_0)
	{
		if (this.m_claptrapPanel != null)
		{
			this.m_claptrapPanel.method_10(int_0);
		}
		if (this.m_claptrapIcon != null)
		{
			this.m_claptrapIcon.method_7(true);
		}
		if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() != null)
		{
			if ((MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer).m_claptrap != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().imethod_0("UI_CPSoccer_PickupClapTrap");
			}
			this.m_claptrapIcon.method_6();
		}
	}

	// Token: 0x0600382D RID: 14381 RVA: 0x0002553C File Offset: 0x0002373C
	public override void vmethod_14()
	{
		if (this.m_claptrapPanel != null)
		{
			this.m_claptrapPanel.method_11();
		}
		if (this.m_claptrapIcon != null)
		{
			this.m_claptrapIcon.method_6();
			this.m_claptrapIcon.method_7(false);
		}
	}

	// Token: 0x0600382E RID: 14382 RVA: 0x00025570 File Offset: 0x00023770
	public override void vmethod_10(bool bool_0)
	{
		if (this.m_claptrapPanel != null)
		{
			this.m_claptrapPanel.method_6(bool_0);
		}
		if (!bool_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().imethod_0("UI_CPSoccer_RoundStart");
		}
	}

	// Token: 0x0600382F RID: 14383 RVA: 0x0002559D File Offset: 0x0002379D
	public override void vmethod_15(Vector3 vector3_0, Vector3 vector3_1, bool bool_0, bool bool_1 = false, int int_0 = 0)
	{
		if (this.m_claptrapIcon != null)
		{
			this.m_claptrapIcon.method_8(vector3_0, vector3_1, bool_0, bool_1, int_0);
		}
	}

	// Token: 0x06003830 RID: 14384 RVA: 0x000255B9 File Offset: 0x000237B9
	public void method_12()
	{
		if (this.m_claptrapIcon != null)
		{
			this.m_claptrapIcon.method_5();
		}
		if (this.m_claptrapPanel != null)
		{
			this.m_claptrapPanel.method_5();
		}
	}

	// Token: 0x06003831 RID: 14385 RVA: 0x001041E8 File Offset: 0x001023E8
	protected override void vmethod_7(float float_0)
	{
		if (this.m_pvpHudScreen != null && this.m_pvpHudScreen.m_KillInfoItemContainer != null && !this.m_pvpHudScreen.m_KillInfoItemContainer.isLocked)
		{
			base.vmethod_7(float_0);
			if (this.m_killInfoVisible)
			{
				if (!this.m_pvpHudScreen.m_KillInfoItemContainer.Boolean_0)
				{
					this.m_pvpHudScreen.m_KillInfoItemContainer.method_5("fadein");
					this.m_pvpHudScreen.m_KillInfoItemContainer.Boolean_0 = true;
				}
			}
			else if (this.m_pvpHudScreen.m_KillInfoItemContainer.Boolean_0)
			{
				this.m_pvpHudScreen.m_KillInfoItemContainer.Boolean_0 = false;
				this.m_killingInfoQueue.Clear();
			}
			if (this.m_bKillInfoNeedUpdate)
			{
				this.m_pvpHudScreen.m_KillInfoItemContainer.DisplayObjectContainer_0.visible = true;
				this.m_pvpHudScreen.m_KillInfoItemContainer.method_7(this.m_killingInfoQueue);
				this.m_bKillInfoNeedUpdate = false;
			}
			return;
		}
	}

	// Token: 0x06003832 RID: 14386 RVA: 0x000255E1 File Offset: 0x000237E1
	public void method_13()
	{
		if (this.m_pvpHudScreen != null)
		{
			this.m_pvpHudScreen.method_5();
		}
	}

	// Token: 0x06003833 RID: 14387 RVA: 0x000255F6 File Offset: 0x000237F6
	public override bool vmethod_4()
	{
		return (this.m_pvpHudScreen != null && this.m_pvpHudScreen.HudState_0 == uniHUDPvPInfoView.PVPHudScreen.HudState.WrapUp) || base.vmethod_4();
	}

	// Token: 0x06003834 RID: 14388 RVA: 0x001042D8 File Offset: 0x001024D8
	protected override void vmethod_5()
	{
		base.vmethod_5();
		if (this.m_pvpHudScreen == null)
		{
			return;
		}
		if (MonoSingleton<InputManager>.Instance.method_9("ShowScore"))
		{
			this.m_pvpHudScreen.method_24(true);
		}
		if (MonoSingleton<InputManager>.Instance.method_6("ShowScore"))
		{
			this.m_pvpHudScreen.method_24(false);
		}
	}

	// Token: 0x06003835 RID: 14389 RVA: 0x00104330 File Offset: 0x00102530
	protected override void vmethod_8(float float_0)
	{
		base.vmethod_8(float_0);
		while (this.m_scoreInfoQueue.Count > 0)
		{
			HUDPvPInfoView.ScoreInfo scoreInfo = this.m_scoreInfoQueue.Dequeue();
			this.m_ScoringItemContainer.method_6(scoreInfo);
		}
		this.m_ScoringItemContainer.Update(float_0);
	}

	// Token: 0x06003836 RID: 14390 RVA: 0x00104378 File Offset: 0x00102578
	public override void vmethod_3()
	{
		if (this.m_pvpHudScreen != null)
		{
			if (this.m_claptrapPanel != null)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_claptrapPanel);
				this.m_claptrapPanel = null;
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_PVP_Claptrap.swf");
			}
			if (this.m_claptrapIcon != null)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_claptrapIcon);
				this.m_claptrapIcon = null;
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_PVP_Claptrap.swf");
			}
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_pvpHudScreen);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_ScoringItemContainer);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_BackGround);
			this.m_pvpHudScreen.isInited = false;
			this.m_pvpHudScreen = null;
			this.m_ScoringItemContainer = null;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_PVP_HUD.swf");
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("SightBead.swf");
		}
	}

	// Token: 0x06003837 RID: 14391 RVA: 0x00025616 File Offset: 0x00023816
	public override void vmethod_6()
	{
		base.vmethod_6();
		this.m_pvpHudScreen.method_12();
	}

	// Token: 0x06003838 RID: 14392 RVA: 0x001044B0 File Offset: 0x001026B0
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this.m_pvpHudScreen != null && this.m_pvpHudScreen.isInited)
		{
			if (this.m_pvpHudScreen.DisplayObjectContainer_0.visible != this._bVisible)
			{
				(this.m_pvpHudScreen.DisplayObjectContainer_0 as MovieClip).visible = this._bVisible;
				if (this._bVisible)
				{
					this.m_pvpHudScreen.method_20();
				}
				return;
			}
		}
	}

	// Token: 0x0400273B RID: 10043
	protected uniHUDPvPInfoView.ScoringInfoContainer m_ScoringItemContainer;

	// Token: 0x0400273C RID: 10044
	private uniHUDPvPInfoView.PVPHudScreen m_pvpHudScreen;

	// Token: 0x0400273D RID: 10045
	private uniHUDPvPInfoView.PVPHudClaptrap m_claptrapPanel;

	// Token: 0x0400273E RID: 10046
	private uniHUDPvPInfoView.PVPHudClaptrapIcon m_claptrapIcon;

	// Token: 0x0400273F RID: 10047
	private uniHUDPvPInfoView.BackGroundBoard m_BackGround;

	// Token: 0x04002740 RID: 10048
	protected int m_iLastFrameKillInfoCount;

	// Token: 0x04002741 RID: 10049
	protected bool m_bOnKillInfoFadeOutAnima;

	// Token: 0x0200081C RID: 2076
	protected class BackGroundBoard : GClass51
	{
		// Token: 0x17000301 RID: 769
		// (get) Token: 0x0600383B RID: 14395 RVA: 0x0002563F File Offset: 0x0002383F
		// (set) Token: 0x0600383A RID: 14394 RVA: 0x00025629 File Offset: 0x00023829
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
				}
			}
		}

		// Token: 0x0600383C RID: 14396 RVA: 0x00025656 File Offset: 0x00023856
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: BackGroundBoard onInit() 'mc_root' is null! BackGroundBoard won't work!!!");
				return;
			}
		}

		// Token: 0x04002742 RID: 10050
		public MovieClip mc_root;
	}

	// Token: 0x0200081D RID: 2077
	protected class ClaptrapBar : GClass51
	{
		// Token: 0x17000302 RID: 770
		// (get) Token: 0x0600383F RID: 14399 RVA: 0x00025699 File Offset: 0x00023899
		// (set) Token: 0x0600383E RID: 14398 RVA: 0x00025683 File Offset: 0x00023883
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
				}
			}
		}

		// Token: 0x06003840 RID: 14400 RVA: 0x00104524 File Offset: 0x00102724
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: ClaptrapBar onInit() 'mc_root' is null! ClaptrapBar won't work!!!");
				return;
			}
			this.mc_RedBar = this.mc_root.getChildByName<MovieClip>("mc_bar").getChildByName<BadAssMovieClip>("mc_red");
			this.mc_GreenBar = this.mc_root.getChildByName<MovieClip>("mc_bar").getChildByName<BadAssMovieClip>("mc_Green");
			this.mc_RedBar.visible = false;
			this.mc_GreenBar.visible = false;
			this.m_fDistanceLength = this.mc_RedBar.width;
			this.m_fStartPosition = this.mc_RedBar.x;
			this.mc_Claptrap = this.mc_root.getChildByName<MovieClip>("mc_clap").getChildByName<MovieClip>("mc_clapIcon");
			this.mc_LeftEdge = this.mc_root.getChildByName<MovieClip>("mc_clap").getChildByName<MovieClip>("mc_leftPosition");
			this.mc_RightEdge = this.mc_root.getChildByName<MovieClip>("mc_clap").getChildByName<MovieClip>("mc_rightPosition");
			this.mc_LeftHomeIcon = this.mc_root.getChildByName<MovieClip>("mc_leftIcon");
			this.mc_RightHomeIcon = this.mc_root.getChildByName<MovieClip>("mc_rightIcon");
			this.mc_LeftEdge.visible = false;
			this.mc_RightEdge.visible = false;
			this.mc_LeftHomeIcon.visible = true;
			this.mc_RightHomeIcon.visible = true;
			this.Reset();
		}

		// Token: 0x06003841 RID: 14401 RVA: 0x00104698 File Offset: 0x00102898
		public void Reset()
		{
			this.mc_RedBar.visible = false;
			this.mc_GreenBar.visible = false;
			this.mc_Claptrap.x = this.mc_LeftEdge.x + (this.mc_RightEdge.x - this.mc_LeftEdge.x) * 0.5f - this.mc_Claptrap.width / 2f;
			if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				if (MonoSingleton<Session>.Instance.GetLocalPlayer().m_teamID == 1)
				{
					this.mc_LeftHomeIcon.gotoAndStop("home");
					this.mc_RightHomeIcon.gotoAndStop("boom");
				}
				else
				{
					this.mc_LeftHomeIcon.gotoAndStop("boom");
					this.mc_RightHomeIcon.gotoAndStop("home");
				}
			}
		}

		// Token: 0x06003842 RID: 14402 RVA: 0x0010476C File Offset: 0x0010296C
		public void method_5(int int_0)
		{
			if (!this.mc_root.hasEventListener(CEvent.ENTER_FRAME))
			{
				this.m_nPickedTeamID = int_0;
				this.m_bNeedChangeBar = false;
				uniHUDPvPInfoView.ClaptrapBar.m_nCount = 0;
				StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
				float num;
				if (this.m_nPickedTeamID == 2)
				{
					num = currentSession.method_32(1);
				}
				else
				{
					num = currentSession.method_32(2);
				}
				this.m_fLastDistance = num;
				if (num <= 0.25f)
				{
					this.mc_CurrentBar = this.mc_RedBar;
				}
				else
				{
					this.mc_CurrentBar = this.mc_GreenBar;
				}
				this.mc_root.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_7));
			}
		}

		// Token: 0x06003843 RID: 14403 RVA: 0x00104814 File Offset: 0x00102A14
		public void method_6()
		{
			if (this.mc_root.hasEventListener(CEvent.ENTER_FRAME))
			{
				this.mc_root.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_7));
			}
			this.mc_RedBar.visible = false;
			this.mc_GreenBar.visible = false;
		}

		// Token: 0x06003844 RID: 14404 RVA: 0x00104868 File Offset: 0x00102A68
		protected void method_7(CEvent cevent_0)
		{
			StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
			if (this.m_bNeedChangeBar)
			{
				uniHUDPvPInfoView.ClaptrapBar.m_nCount++;
				if (uniHUDPvPInfoView.ClaptrapBar.m_nCount >= 30)
				{
					uniHUDPvPInfoView.ClaptrapBar.m_nCount = 0;
					this.m_bNeedChangeBar = false;
					float num;
					if (this.m_nPickedTeamID == 2)
					{
						num = currentSession.method_32(1);
					}
					else
					{
						num = currentSession.method_32(2);
					}
					if (this.mc_CurrentBar == this.mc_RedBar)
					{
						if (num > 0.25f)
						{
							this.mc_RedBar.visible = false;
							this.mc_CurrentBar = this.mc_GreenBar;
						}
					}
					else if (num <= 0.25f)
					{
						this.mc_GreenBar.visible = false;
						this.mc_CurrentBar = this.mc_RedBar;
					}
					this.mc_CurrentBar.visible = true;
				}
			}
			if (currentSession != null && currentSession.method_4())
			{
				if (this.m_nPickedTeamID == 2)
				{
					float num2 = currentSession.method_32(1);
					if ((num2 <= 0.25f && this.m_fLastDistance > 0.25f) || (num2 > 0.25f && this.m_fLastDistance <= 0.25f))
					{
						uniHUDPvPInfoView.ClaptrapBar.m_nCount = 0;
						this.m_bNeedChangeBar = true;
					}
					this.m_fLastDistance = num2;
					if (!this.mc_CurrentBar.visible)
					{
						this.mc_CurrentBar.visible = true;
					}
					this.mc_CurrentBar.Single_0 = (1f - num2) * this.m_fDistanceLength;
					this.mc_CurrentBar.x = this.m_fStartPosition + num2 * this.m_fDistanceLength;
					this.mc_Claptrap.x = this.mc_LeftEdge.x + (this.mc_RightEdge.x - this.mc_LeftEdge.x) * num2 - this.mc_Claptrap.width / 2f;
				}
				else if (this.m_nPickedTeamID == 1)
				{
					float num3 = currentSession.method_32(2);
					if ((num3 <= 0.25f && this.m_fLastDistance > 0.25f) || (num3 > 0.25f && this.m_fLastDistance <= 0.25f))
					{
						uniHUDPvPInfoView.ClaptrapBar.m_nCount = 0;
						this.m_bNeedChangeBar = true;
					}
					this.m_fLastDistance = num3;
					if (!this.mc_CurrentBar.visible)
					{
						this.mc_CurrentBar.visible = true;
					}
					this.mc_CurrentBar.x = this.m_fStartPosition;
					this.mc_CurrentBar.Single_0 = (1f - num3) * this.m_fDistanceLength;
					this.mc_Claptrap.x = this.mc_LeftEdge.x + (this.mc_RightEdge.x - this.mc_LeftEdge.x) * (1f - num3) - this.mc_Claptrap.width / 2f;
				}
			}
		}

		// Token: 0x04002743 RID: 10051
		public MovieClip mc_root;

		// Token: 0x04002744 RID: 10052
		protected BadAssMovieClip mc_RedBar;

		// Token: 0x04002745 RID: 10053
		protected BadAssMovieClip mc_GreenBar;

		// Token: 0x04002746 RID: 10054
		protected BadAssMovieClip mc_CurrentBar;

		// Token: 0x04002747 RID: 10055
		protected MovieClip mc_Claptrap;

		// Token: 0x04002748 RID: 10056
		protected MovieClip mc_LeftHomeIcon;

		// Token: 0x04002749 RID: 10057
		protected MovieClip mc_RightHomeIcon;

		// Token: 0x0400274A RID: 10058
		protected MovieClip mc_LeftEdge;

		// Token: 0x0400274B RID: 10059
		protected MovieClip mc_RightEdge;

		// Token: 0x0400274C RID: 10060
		protected float m_fDistanceLength;

		// Token: 0x0400274D RID: 10061
		protected float m_fStartPosition;

		// Token: 0x0400274E RID: 10062
		protected int m_nPickedTeamID;

		// Token: 0x0400274F RID: 10063
		protected bool m_bNeedChangeBar;

		// Token: 0x04002750 RID: 10064
		protected float m_fLastDistance;

		// Token: 0x04002751 RID: 10065
		private static int m_nCount;
	}

	// Token: 0x0200081E RID: 2078
	protected class ScoreInfoPanel : GClass51
	{
		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06003847 RID: 14407 RVA: 0x000256C6 File Offset: 0x000238C6
		// (set) Token: 0x06003846 RID: 14406 RVA: 0x000256B0 File Offset: 0x000238B0
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
				}
			}
		}

		// Token: 0x06003848 RID: 14408 RVA: 0x00104B00 File Offset: 0x00102D00
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: ScoreInfoPanel onInit() 'mc_root' is null! ScoreInfoPanel won't work!!!");
				return;
			}
			this.mc_root.stopAll();
			MovieClip childByName = this.mc_root.getChildByName<MovieClip>("mcContainer");
			this.tf_BlueScore = childByName.getChildByName<TextField>("tf_leftScore");
			this.tf_RedScore = childByName.getChildByName<TextField>("tf_rightScore");
			this.mc_BlueLine = childByName.getChildByName<MovieClip>("mc_leftLine");
			this.mc_RedLine = childByName.getChildByName<MovieClip>("mc_rightLine");
		}

		// Token: 0x06003849 RID: 14409 RVA: 0x00104B98 File Offset: 0x00102D98
		public void method_5(int int_0, int int_1, int int_2)
		{
			if (int_0 == 1)
			{
				this.tf_BlueScore.text = int_1.ToString();
				this.tf_RedScore.text = int_2.ToString();
				this.mc_BlueLine.visible = true;
				this.mc_RedLine.visible = false;
			}
			else
			{
				this.tf_BlueScore.text = int_2.ToString();
				this.tf_RedScore.text = int_1.ToString();
				this.mc_BlueLine.visible = false;
				this.mc_RedLine.visible = true;
			}
			this.mc_root.gotoAndPlay("fadein");
		}

		// Token: 0x0600384A RID: 14410 RVA: 0x000256DD File Offset: 0x000238DD
		public void method_6()
		{
			this.mc_root.gotoAndPlay("fadeout");
		}

		// Token: 0x04002752 RID: 10066
		public MovieClip mc_root;

		// Token: 0x04002753 RID: 10067
		protected TextField tf_BlueScore;

		// Token: 0x04002754 RID: 10068
		protected MovieClip mc_BlueLine;

		// Token: 0x04002755 RID: 10069
		protected TextField tf_RedScore;

		// Token: 0x04002756 RID: 10070
		protected MovieClip mc_RedLine;
	}

	// Token: 0x0200081F RID: 2079
	protected class PVPHudClaptrap : GClass51
	{
		// Token: 0x0600384C RID: 14412 RVA: 0x00104C34 File Offset: 0x00102E34
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PVPHudClaptrap onInit() 'mc_root' is null! PVPHudClaptrap won't work!!!");
				return;
			}
			this.mc_DownTips = this.mc_root.getChildByName<MovieClip>("mc_down");
			this.mc_DownTips.visible = true;
			this.mc_Score = new uniHUDPvPInfoView.ScoreInfoPanel();
			this.mc_Score.method_0(this.mc_root.getChildByName<MovieClip>("mc_Score"));
			this.mc_ClaptrapBar = new uniHUDPvPInfoView.ClaptrapBar();
			this.mc_ClaptrapBar.method_0(this.mc_root.getChildByName<MovieClip>("mc_TotalBar"));
		}

		// Token: 0x0600384D RID: 14413 RVA: 0x000256EF File Offset: 0x000238EF
		public void method_5()
		{
			this.mc_Score.Boolean_0 = false;
			this.mc_DownTips.visible = false;
			this.mc_ClaptrapBar.Boolean_0 = false;
		}

		// Token: 0x0600384E RID: 14414 RVA: 0x00025715 File Offset: 0x00023915
		public void method_6(bool bool_0)
		{
			this.mc_DownTips.visible = bool_0;
		}

		// Token: 0x0600384F RID: 14415 RVA: 0x00104CDC File Offset: 0x00102EDC
		public void method_7()
		{
			StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
			int teamId = currentSession.method_21().m_teamId;
			int num = currentSession.method_22(true);
			int num2 = currentSession.method_22(false);
			DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new string[]
			{
				"DIAG7: teamId=",
				teamId.ToString(),
				" myScore=",
				num.ToString(),
				" enemyScore=",
				num2.ToString()
			}));
			this.mc_Score.method_5(teamId, num, num2);
			if (currentSession.m_claptrapScore == MonoSingleton<ClaptrapZone>.Instance.m_score)
			{
				MonoSingleton<AppManager>.Instance.method_0().imethod_0("UI_CPSoccer_Score_BlowTerritory");
				return;
			}
			if (currentSession.m_claptrapScore == 3)
			{
				MonoSingleton<AppManager>.Instance.method_0().imethod_0("UI_CPSoccer_Score_BlowBase");
			}
		}

		// Token: 0x06003850 RID: 14416 RVA: 0x00025723 File Offset: 0x00023923
		public void method_8()
		{
			this.mc_Score.method_6();
			this.method_9();
		}

		// Token: 0x06003851 RID: 14417 RVA: 0x00025736 File Offset: 0x00023936
		public void method_9()
		{
			if (this.mc_ClaptrapBar != null)
			{
				this.mc_ClaptrapBar.Reset();
			}
		}

		// Token: 0x06003852 RID: 14418 RVA: 0x0002574B File Offset: 0x0002394B
		public void method_10(int int_0)
		{
			if (this.mc_ClaptrapBar != null)
			{
				this.mc_ClaptrapBar.method_5(int_0);
			}
		}

		// Token: 0x06003853 RID: 14419 RVA: 0x00025761 File Offset: 0x00023961
		public void method_11()
		{
			if (this.mc_ClaptrapBar != null)
			{
				this.mc_ClaptrapBar.method_6();
			}
		}

		// Token: 0x04002757 RID: 10071
		public MovieClip mc_root;

		// Token: 0x04002758 RID: 10072
		protected MovieClip mc_DownTips;

		// Token: 0x04002759 RID: 10073
		protected uniHUDPvPInfoView.ScoreInfoPanel mc_Score;

		// Token: 0x0400275A RID: 10074
		protected uniHUDPvPInfoView.ClaptrapBar mc_ClaptrapBar;
	}

	// Token: 0x02000820 RID: 2080
	protected class PVPHudClaptrapIcon : GClass51
	{
		// Token: 0x06003855 RID: 14421 RVA: 0x00104DAC File Offset: 0x00102FAC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PVPHudClaptrapIcon onInit() 'mc_root' is null! PVPHudClaptrapIcon won't work!!!");
				return;
			}
			this.mc_Icon = this.mc_root.getChildByName<MovieClip>("mcTarget_Trigger");
		}

		// Token: 0x06003856 RID: 14422 RVA: 0x00025776 File Offset: 0x00023976
		public void method_5()
		{
			this.mc_Icon.visible = false;
		}

		// Token: 0x06003857 RID: 14423 RVA: 0x00025784 File Offset: 0x00023984
		public void method_6()
		{
			this.mc_Icon.visible = true;
		}

		// Token: 0x06003858 RID: 14424 RVA: 0x00025792 File Offset: 0x00023992
		public void method_7(bool bool_0)
		{
			this.m_bClaptrapPicked = bool_0;
		}

		// Token: 0x06003859 RID: 14425 RVA: 0x00104DFC File Offset: 0x00102FFC
		public void method_8(Vector3 vector3_0, Vector3 vector3_1, bool bool_0, bool bool_1 = false, int int_0 = 0)
		{
			if (this.m_bClaptrapPicked)
			{
				bool flag = false;
				if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() != null && (MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer).m_claptrap != null)
				{
					flag = true;
				}
				if (flag)
				{
					if (!bool_1)
					{
						return;
					}
					if (bool_1 && int_0 == ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_10())
					{
						return;
					}
				}
				else if (bool_1)
				{
					return;
				}
			}
			else if (bool_1)
			{
				return;
			}
			if (!bool_0)
			{
				if (this.mc_Icon != null && this.mc_Icon.visible)
				{
					if (!this.mc_Icon.visible)
					{
						this.mc_Icon.visible = true;
					}
					this.mc_Icon.x = vector3_0.x / GClass20.GClass20_0.Single_0;
					this.mc_Icon.y = ((float)Screen.height - vector3_0.y) / GClass20.GClass20_0.Single_0;
				}
			}
			else
			{
				if (!this.mc_Icon.visible)
				{
					this.mc_Icon.visible = true;
				}
				if (vector3_0.z >= 0f)
				{
					if (vector3_0.x > (float)Screen.width)
					{
						vector3_0.x = (float)Screen.width;
					}
					else if (vector3_0.x < 0f)
					{
						vector3_0.x = 0f;
					}
					this.mc_Icon.x = vector3_0.x / GClass20.GClass20_0.Single_0;
					if (this.mc_Icon.x >= 1280f - this.mc_Icon.width)
					{
						this.mc_Icon.x = 1280f - this.mc_Icon.width;
					}
					if (vector3_0.y > (float)Screen.height)
					{
						this.mc_Icon.y = 0f;
					}
					else if (vector3_0.y < 0f)
					{
						this.mc_Icon.y = (float)Screen.height / GClass20.GClass20_0.Single_0;
					}
					else
					{
						this.mc_Icon.y = ((float)Screen.height - vector3_0.y) / GClass20.GClass20_0.Single_0;
					}
					if (this.mc_Icon.y >= 720f - this.mc_Icon.height)
					{
						this.mc_Icon.y = 720f - this.mc_Icon.height;
					}
				}
				else
				{
					if ((double)vector3_1.x >= 0.5)
					{
						if (vector3_0.x > (float)Screen.width)
						{
							this.mc_Icon.x = 0f;
						}
						else if (vector3_0.x < 0f)
						{
							this.mc_Icon.x = 0f;
						}
						else
						{
							this.mc_Icon.x = ((float)Screen.width - vector3_0.x) / GClass20.GClass20_0.Single_0;
						}
					}
					else if (vector3_0.x > (float)Screen.width)
					{
						this.mc_Icon.x = (float)Screen.width / GClass20.GClass20_0.Single_0;
					}
					else if (vector3_0.x < 0f)
					{
						this.mc_Icon.x = (float)Screen.width / GClass20.GClass20_0.Single_0;
					}
					else
					{
						this.mc_Icon.x = ((float)Screen.width - vector3_0.x) / GClass20.GClass20_0.Single_0;
					}
					if (this.mc_Icon.x >= 1280f - this.mc_Icon.width)
					{
						this.mc_Icon.x = 1280f - this.mc_Icon.width;
					}
					this.mc_Icon.y = (float)Screen.height / GClass20.GClass20_0.Single_0;
					if (this.mc_Icon.y >= 720f - this.mc_Icon.height)
					{
						this.mc_Icon.y = 720f - this.mc_Icon.height;
					}
				}
			}
		}

		// Token: 0x0400275B RID: 10075
		public MovieClip mc_root;

		// Token: 0x0400275C RID: 10076
		protected MovieClip mc_Icon;

		// Token: 0x0400275D RID: 10077
		private bool m_bClaptrapPicked;
	}

	// Token: 0x02000821 RID: 2081
	protected class KillingStampIcon : GClass51
	{
		// Token: 0x0600385B RID: 14427 RVA: 0x0002579B File Offset: 0x0002399B
		public void method_5(MovieClip movieClip_0)
		{
			if (movieClip_0 != null)
			{
				base.method_0(movieClip_0);
				this.mc_StampIcon = movieClip_0;
				this.mc_StampContent = this.mc_StampIcon.getChildByName<MovieClip>("mc_stampIcon");
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x0600385D RID: 14429 RVA: 0x000257DB File Offset: 0x000239DB
		// (set) Token: 0x0600385C RID: 14428 RVA: 0x000257C5 File Offset: 0x000239C5
		public virtual bool Boolean_0
		{
			get
			{
				return this.mc_StampContent != null && this.mc_StampContent.visible;
			}
			set
			{
				if (this.mc_StampContent != null)
				{
					this.mc_StampContent.visible = value;
				}
			}
		}

		// Token: 0x0600385E RID: 14430 RVA: 0x000257F2 File Offset: 0x000239F2
		public void method_6()
		{
			this.mc_StampContent.visible = false;
			if (this.newIconMC != null && this.mc_StampIcon.contains(this.newIconMC))
			{
				this.mc_StampIcon.removeChild(this.newIconMC);
			}
		}

		// Token: 0x0600385F RID: 14431 RVA: 0x001051FC File Offset: 0x001033FC
		public void method_7(ScoringActionType scoringActionType_0)
		{
			uniHUDPvPKillStampView uniHUDPvPKillStampView = (uniHUDPvPKillStampView)MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>();
			if (uniHUDPvPKillStampView != null)
			{
				MovieClip movieClip = uniHUDPvPKillStampView.method_15(scoringActionType_0.ToString());
				if (movieClip != null)
				{
					if (this.newIconMC != null && this.mc_StampIcon.contains(this.newIconMC))
					{
						this.mc_StampIcon.removeChild(this.newIconMC);
					}
					this.mc_StampContent.visible = false;
					this.newIconMC = movieClip.newInstance();
					this.newIconMC.scaleX = 0.25f;
					this.newIconMC.scaleY = 0.25f;
					this.newIconMC.name = movieClip.name;
					this.mc_StampIcon.addChildAt(this.newIconMC, this.mc_StampIcon.getChildIndex(this.mc_StampContent));
					this.newIconMC.x = this.mc_StampContent.x;
					this.newIconMC.y = this.mc_StampContent.y;
				}
			}
		}

		// Token: 0x0400275E RID: 10078
		public MovieClip mc_StampIcon;

		// Token: 0x0400275F RID: 10079
		public MovieClip mc_StampContent;

		// Token: 0x04002760 RID: 10080
		protected MovieClip newIconMC;
	}

	// Token: 0x02000822 RID: 2082
	protected class PVPHudScreen : GClass51
	{
		// Token: 0x06003861 RID: 14433 RVA: 0x00025867 File Offset: 0x00023A67
		protected override void vmethod_0()
		{
			base.vmethod_0();
			if (this.displayObjectContainer_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: HUDPVPInfo onInit() '_relatedMovieClip' is null! InstancePanel won't work!!!");
				return;
			}
			this.method_20();
			this.isInited = true;
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06003862 RID: 14434 RVA: 0x00025890 File Offset: 0x00023A90
		public uniHUDPvPInfoView.PVPHudScreen.HudState HudState_0
		{
			get
			{
				return this.m_state;
			}
		}

		// Token: 0x06003863 RID: 14435 RVA: 0x00105300 File Offset: 0x00103500
		protected override bool OnWidgetInitialized(ref MovieClip mc, Type widgetType)
		{
			bool flag = false;
			string name = mc.name;
			switch (name)
			{
			case "mcTargetInfo":
			{
				this.m_targetInfo = new MovieClip();
				this.m_targetInfo = mc;
				this.m_targetInfo.visible = false;
				this.m_targetInfo.addFrameScript("animEnd", new EventDispatcher.EventCallback(this.method_15));
				this.m_targetInfo.gotoAndStop(1);
				TextField childByName = this.m_targetInfo.getChildByName<MovieClip>("mc_root").getChildByName<TextField>("tf_Mode");
				TextField childByName2 = this.m_targetInfo.getChildByName<MovieClip>("mc_root").getChildByName<TextField>("tf_Rule");
				if (MonoSingleton<Session>.Instance.method_14())
				{
					if (MonoSingleton<Session>.Instance.method_15())
					{
						childByName.text = LocalizedString.smethod_0(new LocalizedString("PVP_ClaptrapSoccer"));
						childByName2.text = LocalizedString.smethod_0(new LocalizedString("PVPRule_ClaptrapSoccer"));
					}
					else
					{
						childByName.text = LocalizedString.smethod_0(new LocalizedString("PVP_TeamDeathMatch"));
						childByName2.text = LocalizedString.smethod_0(new LocalizedString("PVPRule_TeamDeathMatch"));
					}
				}
				else
				{
					childByName.text = LocalizedString.smethod_0(new LocalizedString("PVP_DeathMatch"));
					childByName2.text = LocalizedString.smethod_0(new LocalizedString("PVPRule_DeathMatch"));
				}
				flag = true;
				break;
			}
			case "mcKillingInfoContainer":
				this.m_KillInfoItemContainer = new uniHUDPvPInfoView.KillInfoItemContainer();
				this.m_KillInfoItemContainer.method_0(mc);
				flag = true;
				break;
			case "mcResultInfo":
				this.m_resultInfoPanel = new MovieClip();
				this.m_resultInfoPanel = mc;
				this.m_resultInfoPanel.stopAll();
				this.m_resultInfoPanel.visible = false;
				this.m_resultContainer = this.m_resultInfoPanel.getChildByName<MovieClip>("mcContainer");
				flag = true;
				break;
			case "mcWrapup":
			{
				this.m_wrapupPanel = new MovieClip();
				this.m_wrapupPanel = mc;
				this.m_wrapupPanel.visible = false;
				this.m_wrapupContainer = new MovieClip();
				this.m_wrapupContainer = mc.getChildByName<MovieClip>("mcContent");
				this.m_backToLobbyButton = new GClass25();
				this.m_backToLobbyButton.method_0(this.m_wrapupContainer.getChildByName<MovieClip>("mcToLobbyButton"));
				this.m_backToLobbyButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_10));
				this.m_backToLobbyButton.Boolean_6 = false;
				this.m_matchMakingButton = new GClass25();
				this.m_matchMakingButton.method_0(this.m_wrapupContainer.getChildByName<MovieClip>("mcStartingButton"));
				this.m_matchMakingButton.Boolean_6 = false;
				this.method_7();
				MovieClip childByName3 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1");
				childByName3.visible = false;
				MovieClip childByName4 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2");
				childByName4.visible = false;
				this.m_Box1 = new GClass24();
				this.m_Box1.method_0(childByName3);
				this.m_Box2 = new GClass24();
				this.m_Box2.method_0(childByName4);
				flag = true;
				break;
			}
			case "mcTab":
			{
				this.m_tabPanel = new MovieClip();
				this.m_tabPanel = mc;
				this.m_tabPanel.visible = false;
				MovieClip childByName5 = mc.getChildByName<MovieClip>("mcMiniMap");
				if (childByName5 != null)
				{
					this.m_mapRoot = new UIMapDisplayManager.UIMapRoot();
					this.m_mapRoot.MapCategoryTag_0 = UIMapDisplayManager.MapCategoryTag.PVPMap;
					this.m_mapRoot.Boolean_0 = true;
					this.m_mapRoot.Boolean_1 = true;
					this.m_mapRoot.method_0(childByName5);
					UIMapDisplayManager.smethod_0().method_3(this.m_mapRoot);
				}
				flag = true;
				break;
			}
			}
			return flag;
		}

		// Token: 0x06003864 RID: 14436 RVA: 0x00025898 File Offset: 0x00023A98
		public void method_5()
		{
			if (this.m_backToLobbyButton != null)
			{
				this.m_backToLobbyButton.Boolean_6 = true;
			}
			if (this.m_matchMakingButton != null)
			{
				this.m_matchMakingButton.Boolean_6 = true;
			}
			this.method_6();
		}

		// Token: 0x06003865 RID: 14437 RVA: 0x001056E4 File Offset: 0x001038E4
		protected void method_6()
		{
			if (LuckyBoxManager.smethod_0().method_4(false) != 0)
			{
				MovieClip childByName = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1");
				childByName.visible = true;
				ItemDNA itemDNA = LuckyBoxManager.smethod_0().method_7(0, false);
				if (itemDNA != null)
				{
					MovieClip childByName2 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("mc_loading");
					childByName2.visible = false;
					TextField childByName3 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<TextField>("textNumber");
					if (itemDNA.m_type == ItemType.Material)
					{
						MovieClip movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_23(itemDNA);
						movieClip.name = "icon";
						MovieClip childByName4 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons");
						childByName4.stopAll();
						childByName4.addChild(movieClip);
					}
					else if (itemDNA.m_type == ItemType.Money)
					{
						MovieClip movieClip2 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_22();
						movieClip2.name = "icon";
						MovieClip childByName5 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
						childByName5.stopAll();
						childByName5.addChild(movieClip2);
						childByName3.text = itemDNA.m_value.ToString();
					}
					else
					{
						Texture2D texture2D = MonoSingleton<DNAPortrait>.Instance.method_3(itemDNA, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
						GClass43 gclass = new GClass43();
						gclass.method_0(this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons"));
						gclass.vmethod_8(texture2D);
					}
					if (itemDNA.m_type != ItemType.Money)
					{
						this.m_Box1.GInterface1_0 = new ItemTips(itemDNA);
					}
				}
			}
			if (LuckyBoxManager.smethod_0().method_4(true) != 0)
			{
				MovieClip childByName6 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2");
				childByName6.visible = true;
				ItemDNA itemDNA2 = LuckyBoxManager.smethod_0().method_7(0, true);
				if (itemDNA2 != null)
				{
					MovieClip childByName7 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("mc_loading");
					childByName7.visible = false;
					TextField childByName8 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<TextField>("textNumber");
					if (itemDNA2.m_type == ItemType.Material)
					{
						MovieClip movieClip3 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_23(itemDNA2);
						movieClip3.name = "icon";
						MovieClip childByName9 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
						childByName9.stopAll();
						childByName9.addChild(movieClip3);
					}
					else if (itemDNA2.m_type == ItemType.Money)
					{
						MovieClip movieClip4 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_22();
						movieClip4.name = "icon";
						MovieClip childByName10 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
						childByName10.stopAll();
						childByName10.addChild(movieClip4);
						childByName8.text = itemDNA2.m_value.ToString();
					}
					else
					{
						Texture2D texture2D2 = MonoSingleton<DNAPortrait>.Instance.method_3(itemDNA2, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
						GClass43 gclass2 = new GClass43();
						gclass2.method_0(this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons"));
						gclass2.vmethod_8(texture2D2);
					}
					if (itemDNA2.m_type != ItemType.Money)
					{
						this.m_Box2.GInterface1_0 = new ItemTips(itemDNA2);
					}
				}
			}
		}

		// Token: 0x06003866 RID: 14438 RVA: 0x00105A54 File Offset: 0x00103C54
		protected void method_7()
		{
			this.m_StampIcons = new uniHUDPvPInfoView.KillingStampIcon[this.STAMP_TOTAL];
			for (int i = 0; i < this.STAMP_TOTAL; i++)
			{
				MovieClip childByName = this.m_wrapupContainer.getChildByName<MovieClip>("stamp" + i);
				if (childByName != null)
				{
					uniHUDPvPInfoView.KillingStampIcon killingStampIcon = new uniHUDPvPInfoView.KillingStampIcon();
					killingStampIcon.method_5(childByName);
					this.m_StampIcons[i] = killingStampIcon;
				}
			}
		}

		// Token: 0x06003867 RID: 14439 RVA: 0x00105AB8 File Offset: 0x00103CB8
		protected void method_8()
		{
			for (int i = 0; i < this.m_StampIcons.Length; i++)
			{
				this.m_StampIcons[i].Boolean_0 = false;
			}
		}

		// Token: 0x06003868 RID: 14440 RVA: 0x00105AE8 File Offset: 0x00103CE8
		protected void method_9()
		{
			MonoSingleton<AppManager>.Instance.method_0().method_15(false, "PvpWrapUpppp");
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1 = false;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(true);
			if (LobbyManager.smethod_0().method_0())
			{
				LobbyManager.smethod_0().method_24();
			}
			MonoSingleton<GameFlowManager>.Instance.method_7();
		}

		// Token: 0x06003869 RID: 14441 RVA: 0x000258C8 File Offset: 0x00023AC8
		private void method_10(CEvent cevent_0)
		{
			this.method_9();
		}

		// Token: 0x0600386A RID: 14442 RVA: 0x000258D0 File Offset: 0x00023AD0
		private void method_11(CEvent cevent_0)
		{
			if (!MonoSingleton<AppManager>.Instance.method_0().Boolean_0)
			{
				this.method_25();
			}
		}

		// Token: 0x0600386B RID: 14443 RVA: 0x000258E9 File Offset: 0x00023AE9
		public void method_12()
		{
			this.m_state = uniHUDPvPInfoView.PVPHudScreen.HudState.End;
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
			this.method_20();
		}

		// Token: 0x0600386C RID: 14444 RVA: 0x00105B6C File Offset: 0x00103D6C
		private void method_13(float float_0 = 5f)
		{
			if (this.displayObjectContainer_0 == null)
			{
				return;
			}
			if (this.displayObjectContainer_0.hasEventListener(CEvent.ENTER_FRAME))
			{
				this.displayObjectContainer_0.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_14));
			}
			this.m_startTime = Time.time;
			this.m_triggerTime = float_0;
			this.displayObjectContainer_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_14));
		}

		// Token: 0x0600386D RID: 14445 RVA: 0x00105BE0 File Offset: 0x00103DE0
		private void method_14(CEvent cevent_0)
		{
			if (Time.time - this.m_startTime > this.m_triggerTime)
			{
				this.displayObjectContainer_0.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_14));
				switch (this.m_state)
				{
				case uniHUDPvPInfoView.PVPHudScreen.HudState.Start:
					MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("Echo_PVP_PlayerLvScale");
					this.m_state = uniHUDPvPInfoView.PVPHudScreen.HudState.Game;
					this.method_20();
					break;
				case uniHUDPvPInfoView.PVPHudScreen.HudState.End:
					this.m_state = uniHUDPvPInfoView.PVPHudScreen.HudState.WrapUp;
					this.method_20();
					break;
				}
			}
		}

		// Token: 0x0600386E RID: 14446 RVA: 0x00025908 File Offset: 0x00023B08
		private void method_15(CEvent cevent_0)
		{
			this.m_state = uniHUDPvPInfoView.PVPHudScreen.HudState.Game;
			this.method_20();
		}

		// Token: 0x0600386F RID: 14447 RVA: 0x00105C70 File Offset: 0x00103E70
		private void method_16(MovieClip movieClip_0, StatisticsManager.SessionStats sessionStats_0)
		{
			if (sessionStats_0 == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			if (movieClip_0.getChildByName<MovieClip>("mc_goalPoint") != null)
			{
				if (MonoSingleton<Session>.Instance.method_15())
				{
					movieClip_0.getChildByName<MovieClip>("mc_goalPoint").visible = true;
				}
				else
				{
					movieClip_0.getChildByName<MovieClip>("mc_goalPoint").visible = false;
				}
			}
			StatisticsManager.StatSheet[] array = sessionStats_0.m_statsSheets.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].m_isTeam && MonoSingleton<Session>.Instance.method_14())
				{
					if (array[i].m_teamId == 1)
					{
						num++;
					}
					else
					{
						num2++;
					}
				}
			}
			MovieClip childByName = movieClip_0.getChildByName<MovieClip>("mc_redBG");
			MovieClip childByName2 = movieClip_0.getChildByName<MovieClip>("mc_greenBG");
			if (childByName != null)
			{
				if (!MonoSingleton<Session>.Instance.method_14())
				{
					childByName.visible = false;
				}
				else
				{
					childByName.visible = true;
				}
			}
			if (childByName2 != null)
			{
				if (!MonoSingleton<Session>.Instance.method_14())
				{
					childByName2.visible = false;
				}
				else
				{
					childByName2.visible = true;
				}
			}
			DebugUtils.Log(LogCategory.GUI, "Before sort:" + this.m_state.ToString());
			for (int j = 0; j < array.Length; j++)
			{
				DebugUtils.Log(LogCategory.GUI, string.Concat(new object[]
				{
					"Is team:",
					array[j].m_isTeam,
					" Name:",
					array[j].m_name,
					" level:",
					array[j].m_level,
					" team:",
					array[j].m_teamId,
					" score:",
					array[j].m_score
				}));
			}
			Array.Sort<StatisticsManager.StatSheet>(array, delegate(StatisticsManager.StatSheet a, StatisticsManager.StatSheet b)
			{
				if (a.m_teamId != b.m_teamId)
				{
					return a.m_teamId.CompareTo(b.m_teamId);
				}
				return b.m_score.CompareTo(a.m_score);
			});
			DebugUtils.Log(LogCategory.GUI, "After sort:");
			for (int k = 0; k < array.Length; k++)
			{
				DebugUtils.Log(LogCategory.GUI, string.Concat(new object[]
				{
					"Is team:",
					array[k].m_isTeam,
					" Name:",
					array[k].m_name,
					" level:",
					array[k].m_level,
					" team:",
					array[k].m_teamId,
					" score:",
					array[k].m_score
				}));
			}
			int num3 = 4;
			int l = 0;
			while (l < 8)
			{
				int num4 = l;
				string text = Utility.smethod_5("mcRow", Utility.smethod_8(l + 1));
				MovieClip movieClip = movieClip_0.getChildByName<MovieClip>(text);
				movieClip.visible = false;
				if (!MonoSingleton<Session>.Instance.method_14())
				{
					goto IL_02F1;
				}
				if (l <= num - 1 || l >= num3 || num >= num3)
				{
					if (l >= num3)
					{
						num4 = l - num3 + num;
						goto IL_02F1;
					}
					goto IL_02F1;
				}
				IL_02E6:
				l++;
				continue;
				IL_02F1:
				if (movieClip != null && num4 < array.Length)
				{
					if (array[num4].m_isTeam)
					{
						goto IL_02E6;
					}
					StatisticsManager.StatSheet statSheet = array[num4];
					int num5 = 0;
					if (this.m_state == uniHUDPvPInfoView.PVPHudScreen.HudState.Tab)
					{
						num5 = statSheet.m_teamId;
					}
					if ((this.m_state == uniHUDPvPInfoView.PVPHudScreen.HudState.WrapUp || this.m_state == uniHUDPvPInfoView.PVPHudScreen.HudState.End) && MonoSingleton<Session>.Instance.method_14() && HUDPvPInfoView.m_PlayerTeamMap.ContainsKey(statSheet.m_id))
					{
						num5 = HUDPvPInfoView.m_PlayerTeamMap[statSheet.m_id];
					}
					bool flag = statSheet.m_name == ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9();
					this.method_23(movieClip.getChildByName<MovieClip>("mcLevelnfo"), Utility.smethod_8(statSheet.m_level), num5, flag, true);
					this.method_23(movieClip.getChildByName<MovieClip>("mcNameInfo"), statSheet.m_name, num5, flag, true);
					this.method_23(movieClip.getChildByName<MovieClip>("mcDeathInfo"), Utility.smethod_6(Utility.smethod_8(statSheet.m_killCount), "/", Utility.smethod_8(statSheet.m_deathcount)), num5, flag, true);
					this.method_23(movieClip.getChildByName<MovieClip>("mcScoreInfo"), Utility.smethod_8(statSheet.m_score), num5, flag, true);
					if (MonoSingleton<Session>.Instance.method_15())
					{
						this.method_23(movieClip.getChildByName<MovieClip>("mc_goalPoint"), Utility.smethod_8(statSheet.m_goalPoint), num5, flag, true);
					}
					else
					{
						this.method_23(movieClip.getChildByName<MovieClip>("mc_goalPoint"), Utility.smethod_8(statSheet.m_goalPoint), num5, flag, false);
					}
					if (this.m_state == uniHUDPvPInfoView.PVPHudScreen.HudState.Tab)
					{
						if (!(MonoSingleton<Session>.Instance.method_36(statSheet.m_id) == null) && !(MonoSingleton<Session>.Instance.method_36(statSheet.m_id).GetEntity() == null) && !(MonoSingleton<Session>.Instance.method_36(statSheet.m_id).GetEntity().vmethod_19() == null))
						{
							if (MonoSingleton<Session>.Instance.method_36(statSheet.m_id).GetEntity().vmethod_19()
								.vmethod_4() == 0)
							{
								movieClip.getChildByName<MovieClip>("mcStatusInfo").gotoAndStop("died");
							}
							else
							{
								movieClip.getChildByName<MovieClip>("mcStatusInfo").gotoAndStop("live");
							}
						}
						else
						{
							movieClip.getChildByName<MovieClip>("mcStatusInfo").gotoAndStop("live");
						}
					}
					movieClip.visible = true;
				}
				movieClip = movieClip_0.getChildByName<MovieClip>("mcMapName");
				if (movieClip != null)
				{
					this.method_23(movieClip, LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("Instance_", Utility.smethod_8(MonoSingleton<AppManager>.Instance.m_playlistId)))), 0, false, true);
				}
				movieClip = movieClip_0.getChildByName<MovieClip>("mcMatchMode");
				if (movieClip == null)
				{
					goto IL_02E6;
				}
				string text2 = MonoSingleton<Session>.Instance.method_6();
				if (text2 == "GameModePvP")
				{
					this.method_23(movieClip, LocalizedString.smethod_0(new LocalizedString("PVP_DeathMatch")), 0, false, true);
					goto IL_02E6;
				}
				if (text2 == "GamemodeTeamDeathmatch")
				{
					this.method_23(movieClip, LocalizedString.smethod_0(new LocalizedString("PVP_TeamDeathMatch")), 0, false, true);
					goto IL_02E6;
				}
				if (text2 == "GamemodeClaptrapSoccer")
				{
					this.method_23(movieClip, LocalizedString.smethod_0(new LocalizedString("PVP_ClaptrapSoccer")), 0, false, true);
					goto IL_02E6;
				}
				goto IL_02E6;
			}
			MovieClip childByName3 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot1");
			DisplayObject childByName4 = this.m_wrapupContainer.getChildByName<MovieClip>("mc_slot2");
			childByName3.visible = false;
			childByName4.visible = false;
			this.tf_CountDown = this.m_wrapupContainer.getChildByName<TextField>("tf_CountDown");
			this.m_CountDownTime = 65f;
			this.m_nCurretnStamp = 0;
			this.m_StampCount = KillingStampManager.smethod_0().method_2();
			this.m_nAnchor = 0;
			this.m_wrapupPanel.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
			StatisticsManager.StatSheet statSheet2 = MonoSingleton<StatisticsManager>.Instance.method_5().method_21();
			int num6 = ((statSheet2 != null) ? statSheet2.m_killCount : 0);
			int num7 = ((statSheet2 != null) ? statSheet2.m_deathcount : 0);
			int num8 = ((statSheet2 != null) ? statSheet2.m_score : 0);
			int num9 = ((statSheet2 != null) ? statSheet2.m_headshotKillCount : 0);
			int num10 = ((statSheet2 != null) ? statSheet2.m_extraMoney : 0);
			int num11 = ((statSheet2 != null) ? statSheet2.m_extraExp : 0);
			int num12 = ((statSheet2 != null) ? statSheet2.m_guildExp : 0);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_killall"), Utility.smethod_8(num6), 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_death"), Utility.smethod_8(num7), 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_myscore"), Utility.smethod_8(num8), 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_headshot"), Utility.smethod_8(num9), 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("earnG_Smoney"), Utility.smethod_8(num10), 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("earnEXP"), Utility.smethod_8(num11), 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_stampcount"), Utility.smethod_8(this.m_StampCount), 0, false, true);
			string text3 = "0";
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_kills"), text3, 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_domination"), text3, 0, false, true);
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("mc_killedbyme"), string.Empty, 0, false, true);
			if (GuildManager.smethod_0().method_7())
			{
				this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("earnG_EXP"), Utility.smethod_8(num12), 0, false, true);
				return;
			}
			this.method_23(this.m_wrapupContainer.getChildByName<MovieClip>("earnG_EXP"), text3, 0, false, true);
		}

		// Token: 0x06003870 RID: 14448 RVA: 0x00106550 File Offset: 0x00104750
		protected void method_17()
		{
			for (int i = 0; i <= this.m_nStampEachLine * 2; i++)
			{
				this.m_StampIcons[i].method_7(KillingStampManager.smethod_0().method_3(i + this.m_nAnchor * this.m_nStampEachLine));
			}
			for (int j = this.m_nStampEachLine * 2 + 1; j < this.m_nStampEachLine * 3; j++)
			{
				this.m_StampIcons[j].method_6();
			}
		}

		// Token: 0x06003871 RID: 14449 RVA: 0x001065C0 File Offset: 0x001047C0
		protected void method_18()
		{
			if (this.m_StampCount == 0)
			{
				StatisticsManager.StatSheet statSheet = MonoSingleton<StatisticsManager>.Instance.method_5().method_21();
				if (statSheet == null)
				{
					return;
				}
				if (!statSheet.m_isFail)
				{
					if (!MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1 && !LuckyBoxManager.smethod_0().m_bLuckyBoxOpened)
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1 = true;
					}
					return;
				}
				this.method_5();
			}
			if (this.m_nCurretnStamp > this.m_StampCount * this.m_nStampInterval)
			{
				return;
			}
			if (this.m_nCurretnStamp / this.m_nStampInterval < this.m_StampCount && this.m_nCurretnStamp % this.m_nStampInterval == 0)
			{
				if (this.m_nCurretnStamp / this.m_nStampInterval >= this.STAMP_TOTAL)
				{
					if (this.m_nAnchor != (this.m_nCurretnStamp / this.m_nStampInterval - this.STAMP_TOTAL) / this.m_nStampEachLine + 1)
					{
						this.m_nAnchor = (this.m_nCurretnStamp / this.m_nStampInterval - this.STAMP_TOTAL) / this.m_nStampEachLine + 1;
						this.method_17();
					}
					else
					{
						this.m_StampIcons[this.m_nCurretnStamp / this.m_nStampInterval - this.m_nAnchor * this.m_nStampEachLine].method_7(KillingStampManager.smethod_0().method_3(this.m_nCurretnStamp / this.m_nStampInterval));
					}
				}
				else
				{
					this.m_StampIcons[this.m_nCurretnStamp / this.m_nStampInterval].method_7(KillingStampManager.smethod_0().method_3(this.m_nCurretnStamp / this.m_nStampInterval));
				}
			}
			this.m_nCurretnStamp++;
			if (this.m_nCurretnStamp > this.m_StampCount * this.m_nStampInterval)
			{
				StatisticsManager.StatSheet statSheet2 = MonoSingleton<StatisticsManager>.Instance.method_5().method_21();
				if (statSheet2 == null)
				{
					return;
				}
				if (!statSheet2.m_isFail)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1 = true;
					return;
				}
				this.method_5();
			}
		}

		// Token: 0x06003872 RID: 14450 RVA: 0x001067A4 File Offset: 0x001049A4
		protected void method_19(CEvent cevent_0)
		{
			this.method_18();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().Update(Time.deltaTime);
			this.m_CountDownTime -= Time.deltaTime;
			int num = (int)(this.m_CountDownTime - this.m_CountDownInterval);
			if (this.m_CountDownTime <= 0f)
			{
				this.m_CountDownTime = 0f;
			}
			if (num <= 0)
			{
				num = 0;
			}
			this.tf_CountDown.text = num + "''";
			StatisticsManager.StatSheet statSheet = MonoSingleton<StatisticsManager>.Instance.method_5().method_21();
			if (num == 0 && !LuckyBoxManager.smethod_0().m_bLuckyBoxOpened && !statSheet.m_isFail)
			{
				LuckyBoxManager.smethod_0().method_2();
			}
			if (this.m_CountDownTime == 0f && (!TreasureBoxBehaviour.m_bPlayOpenBox || !TreasureBoxBehaviour.m_bNeedReplay))
			{
				this.m_wrapupPanel.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
				this.method_9();
			}
		}

		// Token: 0x06003873 RID: 14451 RVA: 0x0010689C File Offset: 0x00104A9C
		public void method_20()
		{
			switch (this.m_state)
			{
			case uniHUDPvPInfoView.PVPHudScreen.HudState.Init:
				this.m_targetInfo.visible = false;
				this.m_resultInfoPanel.visible = false;
				this.m_tabPanel.visible = false;
				this.m_wrapupPanel.visible = false;
				this.m_KillInfoItemContainer.DisplayObjectContainer_0.visible = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(false);
				this.m_state = uniHUDPvPInfoView.PVPHudScreen.HudState.Start;
				this.method_20();
				return;
			case uniHUDPvPInfoView.PVPHudScreen.HudState.Start:
				if (MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_0)
				{
					MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_0 = false;
				}
				this.m_targetInfo.visible = true;
				this.m_targetInfo.play();
				this.m_resultInfoPanel.visible = false;
				this.m_tabPanel.visible = false;
				this.m_wrapupPanel.visible = false;
				this.m_KillInfoItemContainer.DisplayObjectContainer_0.visible = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(false);
				this.m_rootView.method_3(true);
				this.method_13(5f);
				return;
			case uniHUDPvPInfoView.PVPHudScreen.HudState.Game:
				this.m_targetInfo.visible = false;
				this.m_resultInfoPanel.visible = false;
				this.m_tabPanel.visible = false;
				this.m_wrapupPanel.visible = false;
				this.m_KillInfoItemContainer.DisplayObjectContainer_0.visible = true;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(true);
				return;
			case uniHUDPvPInfoView.PVPHudScreen.HudState.Tab:
				this.m_targetInfo.visible = false;
				this.m_resultInfoPanel.visible = false;
				this.m_tabPanel.visible = true;
				this.m_wrapupPanel.visible = false;
				this.m_KillInfoItemContainer.DisplayObjectContainer_0.visible = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(false);
				return;
			case uniHUDPvPInfoView.PVPHudScreen.HudState.End:
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PauseMenuView>().Boolean_0 = false;
				this.m_rootView.method_12();
				this.m_rootView.method_3(false);
				this.m_targetInfo.visible = false;
				this.m_resultInfoPanel.gotoAndPlay("fadein");
				this.method_22();
				this.method_16(this.m_wrapupContainer, MonoSingleton<StatisticsManager>.Instance.method_5());
				this.m_resultInfoPanel.visible = true;
				this.m_tabPanel.visible = false;
				this.m_wrapupPanel.visible = false;
				this.m_KillInfoItemContainer.DisplayObjectContainer_0.visible = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(false);
				this.method_13(1.5f);
				return;
			case uniHUDPvPInfoView.PVPHudScreen.HudState.WrapUp:
				this.m_targetInfo.visible = false;
				this.m_resultInfoPanel.visible = false;
				this.m_tabPanel.visible = false;
				this.m_wrapupPanel.visible = true;
				this.m_wrapupPanel.gotoAndPlay("fadein");
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_9();
				this.m_KillInfoItemContainer.DisplayObjectContainer_0.visible = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(false);
				this.method_8();
				this.method_5();
				MonoSingleton<AppManager>.Instance.method_0().method_15(true, "PvpWrapUpppp");
				MonoSingleton<GameFlowManager>.Instance.method_1();
				Screen.showCursor = true;
				this.m_rootView.method_4(false);
				this.method_13(30f);
				return;
			default:
				return;
			}
		}

		// Token: 0x06003874 RID: 14452 RVA: 0x00106BFC File Offset: 0x00104DFC
		private string method_21(int int_0, int int_1)
		{
			float num = (float)int_0;
			float num2 = (float)int_1;
			string text = "D";
			if ((double)num2 >= (double)num * 0.5)
			{
				text = "C";
			}
			if ((double)num2 >= (double)num * 0.7)
			{
				text = "B";
			}
			if ((double)num2 >= (double)num * 0.9)
			{
				text = "A";
			}
			if (num2 >= num)
			{
				text = "S";
			}
			return text;
		}

		// Token: 0x06003875 RID: 14453 RVA: 0x00106C64 File Offset: 0x00104E64
		private void method_22()
		{
			MovieClip movieClip = ((this.m_resultContainer != null) ? this.m_resultContainer.getChildByName<MovieClip>("mcWin") : null);
			if (movieClip != null)
			{
				movieClip.visible = false;
			}
			MovieClip movieClip2 = ((this.m_resultContainer != null) ? this.m_resultContainer.getChildByName<MovieClip>("mcLose") : null);
			if (movieClip2 != null)
			{
				movieClip2.visible = false;
			}
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			StatisticsManager.SessionStats sessionStats = MonoSingleton<StatisticsManager>.Instance.method_5();
			StatisticsManager.StatSheet statSheet = ((sessionStats != null) ? sessionStats.method_21() : null);
			if (statSheet != null && this.m_wrapupContainer != null)
			{
				InstanceGrade instanceGrade = statSheet.method_0(sessionStats);
				MovieClip childByName = this.m_wrapupContainer.getChildByName<MovieClip>("mc_rankPanel");
				this.mc_Rank = ((childByName != null) ? childByName.getChildByName<MovieClip>("mc_grade") : null);
				if (this.mc_Rank != null)
				{
					this.mc_Rank.gotoAndStop(instanceGrade.ToString());
				}
			}
			if (movieClip != null && localPlayer != null)
			{
				movieClip.visible = MonoSingleton<ScoringManager>.Instance.method_17(localPlayer);
			}
			if (movieClip2 != null && movieClip != null)
			{
				movieClip2.visible = !movieClip.visible;
			}
		}

		// Token: 0x06003876 RID: 14454 RVA: 0x00106D74 File Offset: 0x00104F74
		private void method_23(MovieClip movieClip_0, string string_1, int int_0 = 0, bool bool_0 = false, bool bool_1 = true)
		{
			TextField childByName = movieClip_0.getChildByName<TextField>("textField");
			if (!bool_0)
			{
				if (childByName.textFormat.color != Color.white)
				{
					childByName.textFormat.color = Color.white;
				}
			}
			else if (childByName.textFormat.color != Color.yellow)
			{
				childByName.textFormat.color = Color.yellow;
			}
			if (childByName.text != string_1)
			{
				childByName.text = string_1;
			}
			if (childByName.visible != bool_1)
			{
				childByName.visible = bool_1;
			}
		}

		// Token: 0x06003877 RID: 14455 RVA: 0x00106E08 File Offset: 0x00105008
		public void method_24(bool bool_0)
		{
			if (this.m_state != uniHUDPvPInfoView.PVPHudScreen.HudState.Game && this.m_state != uniHUDPvPInfoView.PVPHudScreen.HudState.Tab)
			{
				return;
			}
			this.m_state = ((!bool_0) ? uniHUDPvPInfoView.PVPHudScreen.HudState.Game : uniHUDPvPInfoView.PVPHudScreen.HudState.Tab);
			if (bool_0)
			{
				this.method_16(this.m_tabPanel, MonoSingleton<StatisticsManager>.Instance.GetCurrentSession());
				this.m_rootView.method_4(false);
			}
			else
			{
				this.m_rootView.method_4(true);
			}
			this.method_20();
		}

		// Token: 0x06003878 RID: 14456 RVA: 0x00106E70 File Offset: 0x00105070
		private void method_25()
		{
			if (this.displayObjectContainer_0.hasEventListener(CEvent.ENTER_FRAME))
			{
				this.displayObjectContainer_0.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_14));
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_5(true);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDPvPInfoView>();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDVictoryCondition>();
			MonoSingleton<AppManager>.Instance.method_0().Boolean_0 = true;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = true;
			MatchmakingService.MatchmakingService_0.method_5();
		}

		// Token: 0x04002761 RID: 10081
		private const int NUM_OF_ROWS = 8;

		// Token: 0x04002762 RID: 10082
		private const float TIME = 5f;

		// Token: 0x04002763 RID: 10083
		private const float START_COUNT_DOWN = 30f;

		// Token: 0x04002764 RID: 10084
		public uniHUDPvPInfoView.KillInfoItemContainer m_KillInfoItemContainer;

		// Token: 0x04002765 RID: 10085
		protected int m_iLastFrameKillInfoCount;

		// Token: 0x04002766 RID: 10086
		protected bool m_bOnKillInfoFadeOutAnima;

		// Token: 0x04002767 RID: 10087
		private MovieClip m_targetInfo;

		// Token: 0x04002768 RID: 10088
		private MovieClip m_wrapupPanel;

		// Token: 0x04002769 RID: 10089
		private MovieClip m_wrapupContainer;

		// Token: 0x0400276A RID: 10090
		private MovieClip m_tabPanel;

		// Token: 0x0400276B RID: 10091
		private MovieClip m_resultInfoPanel;

		// Token: 0x0400276C RID: 10092
		private GClass25 m_backToLobbyButton;

		// Token: 0x0400276D RID: 10093
		private GClass25 m_matchMakingButton;

		// Token: 0x0400276E RID: 10094
		private UIMapDisplayManager.UIMapRoot m_mapRoot;

		// Token: 0x0400276F RID: 10095
		private MovieClip m_resultContainer;

		// Token: 0x04002770 RID: 10096
		private uniHUDPvPInfoView.PVPHudScreen.HudState m_state = uniHUDPvPInfoView.PVPHudScreen.HudState.Init;

		// Token: 0x04002771 RID: 10097
		private float m_startTime;

		// Token: 0x04002772 RID: 10098
		private float m_triggerTime;

		// Token: 0x04002773 RID: 10099
		public uniHUDPvPInfoView m_rootView;

		// Token: 0x04002774 RID: 10100
		public bool isInited;

		// Token: 0x04002775 RID: 10101
		private float m_CountDownTime = 65f;

		// Token: 0x04002776 RID: 10102
		private float m_CountDownInterval = 5f;

		// Token: 0x04002777 RID: 10103
		private int STAMP_TOTAL = 15;

		// Token: 0x04002778 RID: 10104
		private int m_StampCount;

		// Token: 0x04002779 RID: 10105
		private int m_nCurretnStamp;

		// Token: 0x0400277A RID: 10106
		private int m_nAnchor;

		// Token: 0x0400277B RID: 10107
		private int m_nStampInterval = 5;

		// Token: 0x0400277C RID: 10108
		private int m_nStampEachLine = 5;

		// Token: 0x0400277D RID: 10109
		protected uniHUDPvPInfoView.KillingStampIcon[] m_StampIcons;

		// Token: 0x0400277E RID: 10110
		private TextField tf_CountDown;

		// Token: 0x0400277F RID: 10111
		private MovieClip mc_Rank;

		// Token: 0x04002780 RID: 10112
		private GClass24 m_Box1;

		// Token: 0x04002781 RID: 10113
		private GClass24 m_Box2;

		// Token: 0x02000823 RID: 2083
		public enum HudState
		{
			// Token: 0x04002784 RID: 10116
			Raw,
			// Token: 0x04002785 RID: 10117
			Init,
			// Token: 0x04002786 RID: 10118
			Start,
			// Token: 0x04002787 RID: 10119
			Game,
			// Token: 0x04002788 RID: 10120
			Tab,
			// Token: 0x04002789 RID: 10121
			End,
			// Token: 0x0400278A RID: 10122
			WrapUp
		}
	}

	// Token: 0x02000829 RID: 2089
	public class KillInfoItemContainer : GClass51
	{
		private const int MAX_KILL_INFO = 7;

		protected KillInfoItem[] m_ItemArray = new KillInfoItem[HUDPvPInfoView.m_sMaxKillInfoCount];

		protected MovieClip[] m_ItemMCArray = new MovieClip[HUDPvPInfoView.m_sMaxKillInfoCount];

		private MovieClip m_container;

		private MovieClip m_content;

		public bool isLocked;

		public bool Boolean_0
		{
			get
			{
				return m_container.visible;
			}
			set
			{
				if (!isLocked)
				{
					m_container.visible = value;
				}
			}
		}

		public KillInfoItemContainer()
		{
			for (int i = 0; i < m_ItemArray.Length; i++)
			{
				m_ItemArray[i] = new KillInfoItem();
			}
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
		}

		public void method_5(string string_1)
		{
			if (m_container.visible)
			{
				m_container.gotoAndPlay(string_1);
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			switch (movieClip.name)
			{
			case "mcContent":
			{
				m_content = movieClip;
				for (int i = 0; i < 7; i++)
				{
					string name = "mcItem_" + i;
					MovieClip childByName = m_content.getChildByName<MovieClip>(name);
					m_ItemMCArray[i] = childByName;
					m_ItemArray[i].method_0(childByName);
				}
				break;
			}
			case "mcRootContainer":
				m_container = movieClip;
				m_container.visible = false;
				m_container.gotoAndStop("normal");
				break;
			}
			return result;
		}

		private void method_6()
		{
			for (int i = 0; i < m_ItemMCArray.Length; i++)
			{
				m_ItemMCArray[i].visible = false;
			}
		}

		public void method_7(Queue<KillInfo> queue_0)
		{
			KillInfo[] array = queue_0.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				m_ItemArray[i].Boolean_0 = true;
				m_ItemArray[i].method_8(array[i]);
			}
			for (int j = array.Length; j < HUDPvPInfoView.m_sMaxKillInfoCount; j++)
			{
				m_ItemArray[j].Boolean_0 = false;
			}
		}
	}
	// Token: 0x0200082A RID: 2090
	public class KillInfoItem : GClass51
	{
		private MovieClip m_KillTypeIcon;

		private MovieClip m_KillerName;

		private MovieClip m_VictimName;

		private MovieClip m_ElementIcon;

		public virtual bool Boolean_0
		{
			get
			{
				if (displayObjectContainer_0 != null)
				{
					return displayObjectContainer_0.visible;
				}
				return false;
			}
			set
			{
				if (displayObjectContainer_0 != null)
				{
					displayObjectContainer_0.visible = value;
				}
			}
		}

		private bool method_5(string string_1)
		{
			int num = 0;
			ns0.MonoSingleton<Session>.Instance.method_38(out var list);
			for (int i = 0; i < list.Count; i++)
			{
				if (!list[i].IsMyActor() && list[i].m_name == string_1)
				{
					num = list[i].m_teamID;
					break;
				}
			}
			if (num == ns0.MonoSingleton<Session>.Instance.GetLocalPlayer().m_teamID)
			{
				return true;
			}
			return false;
		}

		private bool method_6(string string_1)
		{
			return ns0.MonoSingleton<Session>.Instance.GetLocalPlayer().m_name == string_1;
		}

		private void method_7(CEvent cevent_0)
		{
			if (!displayObjectContainer_0.visible)
			{
				displayObjectContainer_0.visible = true;
			}
		}

		public void method_8(KillInfo killInfo_0)
		{
			m_VictimName = (displayObjectContainer_0 as MovieClip).getChildByName<MovieClip>("mcVictimName");
			m_KillerName = (displayObjectContainer_0 as MovieClip).getChildByName<MovieClip>("mcKillerName");
			m_KillTypeIcon = (displayObjectContainer_0 as MovieClip).getChildByName<MovieClip>("KillType");
			m_ElementIcon = (displayObjectContainer_0 as MovieClip).getChildByName<MovieClip>("element");
			if (ns0.MonoSingleton<Session>.Instance.method_14())
			{
				if (method_6(killInfo_0.strKiller))
				{
					m_KillerName.gotoAndStop("self");
				}
				else if (method_5(killInfo_0.strKiller))
				{
					m_KillerName.gotoAndStop("teammate");
				}
				else
				{
					m_KillerName.gotoAndStop("emeny");
				}
				if (method_6(killInfo_0.strVictim))
				{
					m_VictimName.gotoAndStop("self");
				}
				else if (method_5(killInfo_0.strVictim))
				{
					m_VictimName.gotoAndStop("teammate");
				}
				else
				{
					m_VictimName.gotoAndStop("emeny");
				}
			}
			else
			{
				if (method_6(killInfo_0.strKiller))
				{
					m_KillerName.gotoAndStop("self");
				}
				else
				{
					m_KillerName.gotoAndStop("emeny");
				}
				if (method_6(killInfo_0.strVictim))
				{
					m_VictimName.gotoAndStop("self");
				}
				else
				{
					m_VictimName.gotoAndStop("emeny");
				}
			}
			TextField childByName = m_VictimName.getChildByName<TextField>("textField");
			TextField childByName2 = m_KillerName.getChildByName<TextField>("textField");
			if (killInfo_0.strVictim == killInfo_0.strKiller)
			{
				m_ElementIcon.visible = false;
				m_KillTypeIcon.gotoAndStop("Grenade");
				childByName.text = string.Empty;
				childByName2.text = Utility.smethod_5(killInfo_0.strKiller, LocalizedString.smethod_0(new LocalizedString("PVP_Suicide")));
				return;
			}
			if (childByName.text != killInfo_0.strVictim)
			{
				childByName.text = killInfo_0.strVictim;
			}
			if (childByName2.text != killInfo_0.strKiller)
			{
				childByName2.text = killInfo_0.strKiller;
			}
			m_ElementIcon.visible = false;
			if (killInfo_0.scoringActionList.Contains(ScoringActionType.BonusCritical))
			{
				m_KillTypeIcon.gotoAndStop("BonusCritical");
			}
			else if (AttackInfo.smethod_0(killInfo_0.attackSubType) == AttackInfo.AttackType.Melee)
			{
				m_KillTypeIcon.gotoAndStop("Melee");
			}
			else
			{
				m_KillTypeIcon.gotoAndStop(killInfo_0.attackSubType.ToString());
			}
		}
	}
	// Token: 0x0200082B RID: 2091
	public class ScoringInfoContainer : GClass51
	{
		// Token: 0x06003897 RID: 14487 RVA: 0x0010748C File Offset: 0x0010568C
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcRoot_1":
			{
				movieClip.gotoAndStop("normal");
				movieClip.addFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_5));
				this.m_OriginalPosArray[0] = new Vector2(movieClip.x, movieClip.y);
				uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem = new uniHUDPvPInfoView.ScoringInfoItem();
				scoringInfoItem.method_0(movieClip);
				this.m_backupQueue.Enqueue(scoringInfoItem);
				flag = true;
				break;
			}
			case "mcRoot_2":
			{
				movieClip.gotoAndStop("normal");
				movieClip.addFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_5));
				this.m_OriginalPosArray[1] = new Vector2(movieClip.x, movieClip.y);
				uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem = new uniHUDPvPInfoView.ScoringInfoItem();
				scoringInfoItem.method_0(movieClip);
				this.m_backupQueue.Enqueue(scoringInfoItem);
				flag = true;
				break;
			}
			case "mcRoot_3":
			{
				movieClip.gotoAndStop("normal");
				movieClip.addFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_5));
				this.m_OriginalPosArray[2] = new Vector2(movieClip.x, movieClip.y);
				uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem = new uniHUDPvPInfoView.ScoringInfoItem();
				scoringInfoItem.method_0(movieClip);
				this.m_backupQueue.Enqueue(scoringInfoItem);
				flag = true;
				break;
			}
			case "mcRoot_4":
			{
				movieClip.gotoAndStop("normal");
				movieClip.addFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_5));
				this.m_OriginalPosArray[3] = new Vector2(movieClip.x, movieClip.y);
				uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem = new uniHUDPvPInfoView.ScoringInfoItem();
				scoringInfoItem.method_0(movieClip);
				this.m_backupQueue.Enqueue(scoringInfoItem);
				flag = true;
				break;
			}
			case "mcRoot_5":
			{
				movieClip.gotoAndStop("normal");
				movieClip.addFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_5));
				this.m_OriginalPosArray[4] = new Vector2(movieClip.x, movieClip.y);
				uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem = new uniHUDPvPInfoView.ScoringInfoItem();
				scoringInfoItem.method_0(movieClip);
				this.m_backupQueue.Enqueue(scoringInfoItem);
				flag = true;
				break;
			}
			}
			return flag;
		}

		// Token: 0x06003898 RID: 14488 RVA: 0x00107740 File Offset: 0x00105940
		public void method_5(CEvent cevent_0)
		{
			uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem = this.m_onusingQueue.Dequeue();
			scoringInfoItem.method_7(false);
			this.m_backupQueue.Enqueue(scoringInfoItem);
		}

		// Token: 0x06003899 RID: 14489 RVA: 0x0010776C File Offset: 0x0010596C
		public void Update(float _deltaTime)
		{
			Queue<uniHUDPvPInfoView.ScoringInfoItem> queue = new Queue<uniHUDPvPInfoView.ScoringInfoItem>(this.m_onusingQueue);
			this.m_onusingQueue.Clear();
			int num = 0;
			int count = queue.Count;
			while (queue.Count > 0)
			{
				num++;
				uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem = queue.Dequeue();
				scoringInfoItem.Update(_deltaTime);
				if (this.m_bNeedUpdatePos)
				{
					scoringInfoItem.method_6(this.m_OriginalPosArray[count - num]);
				}
				this.m_onusingQueue.Enqueue(scoringInfoItem);
			}
			this.m_bNeedUpdatePos = false;
		}

		// Token: 0x0600389A RID: 14490 RVA: 0x001077EC File Offset: 0x001059EC
		public void method_6(HUDPvPInfoView.ScoreInfo scoreInfo_0)
		{
			this.m_bNeedUpdatePos = true;
			uniHUDPvPInfoView.ScoringInfoItem scoringInfoItem;
			if (this.m_onusingQueue.Count == HUDPvPInfoView.m_sMaxScoreInfoCount)
			{
				scoringInfoItem = this.m_onusingQueue.Dequeue();
			}
			else
			{
				scoringInfoItem = this.m_backupQueue.Dequeue();
			}
			scoringInfoItem.method_8();
			scoringInfoItem.method_5(scoreInfo_0);
			this.m_onusingQueue.Enqueue(scoringInfoItem);
		}

		// Token: 0x0400279F RID: 10143
		protected Vector2[] m_OriginalPosArray = new Vector2[HUDPvPInfoView.m_sMaxScoreInfoCount];

		// Token: 0x040027A0 RID: 10144
		protected Queue<uniHUDPvPInfoView.ScoringInfoItem> m_backupQueue = new Queue<uniHUDPvPInfoView.ScoringInfoItem>();

		// Token: 0x040027A1 RID: 10145
		protected Queue<uniHUDPvPInfoView.ScoringInfoItem> m_onusingQueue = new Queue<uniHUDPvPInfoView.ScoringInfoItem>();

		// Token: 0x040027A2 RID: 10146
		protected bool m_bNeedUpdatePos;
	}

	// Token: 0x0200082C RID: 2092
	public class ScoringInfoItem : GClass51
	{
		// Token: 0x0600389C RID: 14492 RVA: 0x00107848 File Offset: 0x00105A48
		public void method_5(HUDPvPInfoView.ScoreInfo scoreInfo_0)
		{
			this.m_fTimeLeft = scoreInfo_0.fTimeLeft;
			if (scoreInfo_0.iScore >= 0)
			{
				this.m_strScoreNumber = Utility.smethod_5("+", Utility.smethod_8(scoreInfo_0.iScore));
			}
			else
			{
				this.m_strScoreNumber = Utility.smethod_8(scoreInfo_0.iScore);
			}
			this.m_strScoreType = LocalizedString.smethod_0(new LocalizedString(scoreInfo_0.ScoringType.ToString()));
		}

		// Token: 0x0600389D RID: 14493 RVA: 0x001078B8 File Offset: 0x00105AB8
		public void Update(float _fDeltaTime)
		{
			if (!this.m_bOnFadeoutAnimation)
			{
				this.m_fTimeLeft -= _fDeltaTime;
				if (this.m_fTimeLeft < 0f)
				{
					(this.displayObjectContainer_0 as MovieClip).gotoAndPlay("fadeout");
					this.m_bOnFadeoutAnimation = true;
				}
				MovieClip childByName = (this.displayObjectContainer_0 as MovieClip).getChildByName<MovieClip>("mcPVPkillscore");
				if (childByName != null)
				{
					TextField textField = childByName.getChildByName<TextField>("text_ScoringType");
					if (textField.text != this.m_strScoreType)
					{
						textField.text = this.m_strScoreType;
					}
					textField = childByName.getChildByName<TextField>("text_ScoreNumber");
					if (textField.text != this.m_strScoreNumber)
					{
						textField.text = this.m_strScoreNumber;
					}
				}
			}
		}

		// Token: 0x0600389E RID: 14494 RVA: 0x00025A45 File Offset: 0x00023C45
		public void method_6(Vector2 vector2_0)
		{
			(this.displayObjectContainer_0 as MovieClip).x = vector2_0.x;
			(this.displayObjectContainer_0 as MovieClip).y = vector2_0.y;
		}

		// Token: 0x0600389F RID: 14495 RVA: 0x00025A75 File Offset: 0x00023C75
		public void method_7(bool bool_0)
		{
			if (this.m_bVisible != bool_0)
			{
				(this.displayObjectContainer_0 as MovieClip).visible = bool_0;
				this.m_bVisible = bool_0;
			}
		}

		// Token: 0x060038A0 RID: 14496 RVA: 0x00025A98 File Offset: 0x00023C98
		public void method_8()
		{
			this.method_7(true);
			this.m_bOnFadeoutAnimation = false;
			(this.displayObjectContainer_0 as MovieClip).gotoAndPlay("fadein");
		}

		// Token: 0x040027A4 RID: 10148
		protected float m_fTimeLeft;

		// Token: 0x040027A5 RID: 10149
		protected string m_strScoreType;

		// Token: 0x040027A6 RID: 10150
		protected string m_strScoreNumber;

		// Token: 0x040027A7 RID: 10151
		protected bool m_bOnFadeoutAnimation;

		// Token: 0x040027A8 RID: 10152
		protected bool m_bVisible;
	}
}
