using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x0200088A RID: 2186
public class uniPvPModeSelectView : PvPModeSelectView
{
	// Token: 0x06003BE1 RID: 15329 RVA: 0x00028303 File Offset: 0x00026503
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PvP_Flow.swf", "option", new FuncLoad(this.method_4));
	}

	// Token: 0x06003BE2 RID: 15330 RVA: 0x0011ABFC File Offset: 0x00118DFC
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._PvPModePanel);
		this._PvPModePanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_PvP_Flow.swf");
	}

	// Token: 0x06003BE3 RID: 15331 RVA: 0x0011AC4C File Offset: 0x00118E4C
	private void method_4(MovieClip movieClip_0)
	{
		this._PvPModePanel = new uniPvPModeSelectView.PvPModePanel();
		this._PvPModePanel.method_0(movieClip_0);
		this._PvPModePanel.Boolean_0 = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._PvPModePanel);
	}

	// Token: 0x06003BE4 RID: 15332 RVA: 0x0011AC98 File Offset: 0x00118E98
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this.m_bCheckCondition)
		{
			if (bool_0 && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPRoomListView>().Boolean_1)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPRoomListView>().Boolean_1 = false;
			}
			this._PvPModePanel.Boolean_0 = this._bVisible;
		}
	}

	// Token: 0x06003BE5 RID: 15333 RVA: 0x00028335 File Offset: 0x00026535
	public override bool vmethod_4()
	{
		if (this._PvPModePanel != null && this._PvPModePanel.Boolean_0)
		{
			this._PvPModePanel.Boolean_0 = false;
		}
		return base.vmethod_4();
	}

	// Token: 0x04002A10 RID: 10768
	private uniPvPModeSelectView.PvPModePanel _PvPModePanel;

	// Token: 0x0200088B RID: 2187
	private class PvPModePanel : GClass51
	{
		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06003BE8 RID: 15336 RVA: 0x0002837F File Offset: 0x0002657F
		// (set) Token: 0x06003BE7 RID: 15335 RVA: 0x0002835E File Offset: 0x0002655E
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
						this.mc_root.visible = value;
					}
				}
			}
		}

		// Token: 0x06003BE9 RID: 15337 RVA: 0x0011ACF4 File Offset: 0x00118EF4
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PvPModePanel onInit() 'mc_root' is null! PvPModePanel won't work!!!");
				return;
			}
			this.mc_base = this.mc_root.getChildByName<MovieClip>("mc_root");
			this.mc_CommonBtn = new GClass25();
			this.mc_CommonBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_root").getChildByName<MovieClip>("mc_commonBtn"));
			this.mc_CommonBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
			this.mc_OfficialBtn = new GClass25();
			this.mc_OfficialBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_root").getChildByName<MovieClip>("mc_officialBtn"));
			this.mc_OfficialBtn.Boolean_6 = false;
		}

		// Token: 0x06003BEA RID: 15338 RVA: 0x00028396 File Offset: 0x00026596
		protected void method_5()
		{
			this.mc_root.visible = true;
			this.mc_base.gotoAndPlay("fadein");
		}

		// Token: 0x06003BEB RID: 15339 RVA: 0x000283B4 File Offset: 0x000265B4
		private void method_6(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPModeSelectView>().Boolean_1 = false;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPRoomListView>().Boolean_1 = true;
		}

		// Token: 0x04002A11 RID: 10769
		public MovieClip mc_root;

		// Token: 0x04002A12 RID: 10770
		public MovieClip mc_base;

		// Token: 0x04002A13 RID: 10771
		protected GClass25 mc_CommonBtn;

		// Token: 0x04002A14 RID: 10772
		protected GClass25 mc_OfficialBtn;
	}
}
