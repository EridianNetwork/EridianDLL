using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

// Token: 0x0200088E RID: 2190
public class uniPvPTipsView : PvPTipsView
{
	// Token: 0x06003BF9 RID: 15353 RVA: 0x000284D3 File Offset: 0x000266D3
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("pvp_match_making.swf", "Mc_tips", new FuncLoad(this.method_3));
	}

	// Token: 0x06003BFA RID: 15354 RVA: 0x0011AF00 File Offset: 0x00119100
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._tipsPanel);
		this._tipsPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("pvp_match_making.swf");
	}

	// Token: 0x06003BFB RID: 15355 RVA: 0x00028505 File Offset: 0x00026705
	private void method_3(MovieClip movieClip_0)
	{
		this._tipsPanel = new uniPvPTipsView.PvPTipsPanel();
		this._tipsPanel.method_0(movieClip_0);
		this._tipsPanel.Boolean_0 = false;
	}

	// Token: 0x06003BFC RID: 15356 RVA: 0x0011AF50 File Offset: 0x00119150
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._tipsPanel);
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._tipsPanel);
		}
		this._tipsPanel.Boolean_0 = bool_0;
	}

	// Token: 0x04002A1C RID: 10780
	private uniPvPTipsView.PvPTipsPanel _tipsPanel;

	// Token: 0x0200088F RID: 2191
	private class PvPTipsPanel : GClass51
	{
		// Token: 0x06003BFE RID: 15358 RVA: 0x0011AFAC File Offset: 0x001191AC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PvPTipsPanel onInit() 'mc_root' is null! PvPTipsPanel won't work!!!");
				return;
			}
			this.mc_root.stopAll();
			this.mc_root.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
			this.mc_Join = new GClass25();
			this.mc_Join.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_Join"));
			this.mc_Join.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
			this.mc_Reject = new GClass25();
			this.mc_Reject.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_Reject"));
			this.mc_Reject.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			this.tf_Content = this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<TextField>("mc_content");
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06003C00 RID: 15360 RVA: 0x00028565 File Offset: 0x00026765
		// (set) Token: 0x06003BFF RID: 15359 RVA: 0x0002853E File Offset: 0x0002673E
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
						this.method_5();
					}
					else
					{
						this.method_6();
					}
					this.mc_root.visible = value;
				}
			}
		}

		// Token: 0x06003C01 RID: 15361 RVA: 0x0011B0C8 File Offset: 0x001192C8
		protected void method_5()
		{
			this.m_Timer.method_4();
			this.m_Timer.Start(180f);
			this.tf_Content.text = LobbyManager.smethod_0().method_28() + LocalizedString.smethod_0(new LocalizedString("PVP_MatchMaking_Invitation"));
			MonoSingleton<AppManager>.Instance.method_0().method_15(true, base.String_0);
			this.mc_root.gotoAndPlay("fadein");
		}

		// Token: 0x06003C02 RID: 15362 RVA: 0x0002857C File Offset: 0x0002677C
		protected void method_6()
		{
			LobbyManager.smethod_0().m_bCanShowMessage = true;
			MonoSingleton<AppManager>.Instance.method_0().method_15(false, base.String_0);
			this.mc_root.gotoAndPlay("fadeout");
		}

		// Token: 0x06003C03 RID: 15363 RVA: 0x000285AF File Offset: 0x000267AF
		private void method_7(CEvent cevent_0)
		{
			this.m_Timer.method_4();
			LobbyManager.smethod_0().method_18();
		}

		// Token: 0x06003C04 RID: 15364 RVA: 0x000285C6 File Offset: 0x000267C6
		private void method_8(CEvent cevent_0)
		{
			this.m_Timer.method_4();
			LobbyManager.smethod_0().method_20();
		}

		// Token: 0x06003C05 RID: 15365 RVA: 0x000285DD File Offset: 0x000267DD
		private void method_9(CEvent cevent_0)
		{
			if (this.m_Timer.method_6() && this.m_Timer.method_7())
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPTipsView>().Boolean_1 = false;
			}
		}

		// Token: 0x04002A1D RID: 10781
		public MovieClip mc_root;

		// Token: 0x04002A1E RID: 10782
		private GClass25 mc_Join;

		// Token: 0x04002A1F RID: 10783
		private GClass25 mc_Reject;

		// Token: 0x04002A20 RID: 10784
		private TextField tf_Content;

		// Token: 0x04002A21 RID: 10785
		private Utils.Timer m_Timer = new Utils.Timer();
	}
}
