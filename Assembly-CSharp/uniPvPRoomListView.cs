using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x0200088C RID: 2188
public class uniPvPRoomListView : PvPRoomListView
{
	// Token: 0x06003BED RID: 15341 RVA: 0x000283E8 File Offset: 0x000265E8
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_PvP_Flow.swf", "Mc_pvpmatch_frame", new FuncLoad(this.method_3));
	}

	// Token: 0x06003BEE RID: 15342 RVA: 0x0011ADD0 File Offset: 0x00118FD0
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._pvpRoomListPanel);
		this._pvpRoomListPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_PvP_Flow.swf");
	}

	// Token: 0x06003BEF RID: 15343 RVA: 0x0011AE20 File Offset: 0x00119020
	private void method_3(MovieClip movieClip_0)
	{
		this._pvpRoomListPanel = new uniPvPRoomListView.PvPRoomListPanel();
		this._pvpRoomListPanel.method_0(movieClip_0);
		this._pvpRoomListPanel.Boolean_0 = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._pvpRoomListPanel);
	}

	// Token: 0x06003BF0 RID: 15344 RVA: 0x0002841A File Offset: 0x0002661A
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		this._pvpRoomListPanel.Boolean_0 = this._bVisible;
	}

	// Token: 0x06003BF1 RID: 15345 RVA: 0x00028435 File Offset: 0x00026635
	public override bool vmethod_4()
	{
		if (this._pvpRoomListPanel != null && this._pvpRoomListPanel.Boolean_0)
		{
			this._pvpRoomListPanel.Boolean_0 = false;
		}
		return base.vmethod_4();
	}

	// Token: 0x04002A15 RID: 10773
	private uniPvPRoomListView.PvPRoomListPanel _pvpRoomListPanel;

	// Token: 0x0200088D RID: 2189
	private class PvPRoomListPanel : GClass51
	{
		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06003BF4 RID: 15348 RVA: 0x0002847F File Offset: 0x0002667F
		// (set) Token: 0x06003BF3 RID: 15347 RVA: 0x0002845E File Offset: 0x0002665E
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
						this.method_6();
					}
					else
					{
						this.mc_root.visible = value;
					}
				}
			}
		}

		// Token: 0x06003BF5 RID: 15349 RVA: 0x0011AE6C File Offset: 0x0011906C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PvPRoomListPanel onInit() 'mc_root' is null! PvPRoomListPanel won't work!!!");
				return;
			}
			this.mc_root.stop();
			this.mc_CloseBtn = new GClass25();
			this.mc_CloseBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_base").getChildByName<MovieClip>("mcBtnClose"));
			this.mc_CloseBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
		}

		// Token: 0x06003BF6 RID: 15350 RVA: 0x00028496 File Offset: 0x00026696
		private void method_5(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPRoomListView>().Boolean_1 = false;
		}

		// Token: 0x06003BF7 RID: 15351 RVA: 0x000284AD File Offset: 0x000266AD
		protected void method_6()
		{
			this.mc_root.visible = true;
			this.mc_root.gotoAndPlay("fade in");
		}

		// Token: 0x04002A16 RID: 10774
		public MovieClip mc_root;

		// Token: 0x04002A17 RID: 10775
		protected MovieClip mc_base;

		// Token: 0x04002A18 RID: 10776
		protected GClass25 mc_DeathMatchBtn;

		// Token: 0x04002A19 RID: 10777
		protected GClass25 mc_TeamMatchBtn;

		// Token: 0x04002A1A RID: 10778
		protected GClass25 mc_TempBtn;

		// Token: 0x04002A1B RID: 10779
		protected GClass25 mc_CloseBtn;
	}
}
