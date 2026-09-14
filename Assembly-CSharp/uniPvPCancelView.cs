using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x02000886 RID: 2182
public class uniPvPCancelView : PvPCancelView
{
	// Token: 0x06003BAF RID: 15279 RVA: 0x00028083 File Offset: 0x00026283
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PvP_Flow.swf", "CancelMatchMaking", new FuncLoad(this.method_3));
	}

	// Token: 0x06003BB0 RID: 15280 RVA: 0x00118EF0 File Offset: 0x001170F0
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._PvPCancelPanel);
		this._PvPCancelPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_PvP_Flow.swf");
	}

	// Token: 0x06003BB1 RID: 15281 RVA: 0x00118F40 File Offset: 0x00117140
	private void method_3(MovieClip movieClip_0)
	{
		this._PvPCancelPanel = new uniPvPCancelView.PvPCancelPanel();
		this._PvPCancelPanel.method_0(movieClip_0);
		this._PvPCancelPanel.Boolean_0 = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._PvPCancelPanel);
	}

	// Token: 0x06003BB2 RID: 15282 RVA: 0x000280B5 File Offset: 0x000262B5
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		this._PvPCancelPanel.Boolean_0 = bool_0;
	}

	// Token: 0x040029D8 RID: 10712
	private uniPvPCancelView.PvPCancelPanel _PvPCancelPanel;

	// Token: 0x02000887 RID: 2183
	private class PvPCancelPanel : GClass51
	{
		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06003BB5 RID: 15285 RVA: 0x000280E1 File Offset: 0x000262E1
		// (set) Token: 0x06003BB4 RID: 15284 RVA: 0x000280CB File Offset: 0x000262CB
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

		// Token: 0x06003BB6 RID: 15286 RVA: 0x00118F8C File Offset: 0x0011718C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PvPCancelPanel onInit() 'mc_root' is null! PvPCancelPanel won't work!!!");
				return;
			}
			this.mc_CancelBtn = new GClass25();
			this.mc_CancelBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_cancel"));
			this.mc_CancelBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
		}

		// Token: 0x06003BB7 RID: 15287 RVA: 0x00119008 File Offset: 0x00117208
		private void method_5(CEvent cevent_0)
		{
			if (MonoSingleton<AppManager>.Instance.method_0().Boolean_0)
			{
				MatchmakingService.MatchmakingService_0.method_6();
				MonoSingleton<AppManager>.Instance.method_0().Boolean_0 = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPCancelView>().Boolean_1 = false;
			}
		}

		// Token: 0x040029D9 RID: 10713
		public MovieClip mc_root;

		// Token: 0x040029DA RID: 10714
		protected GClass25 mc_CancelBtn;
	}
}
