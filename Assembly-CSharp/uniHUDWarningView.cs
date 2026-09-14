using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

// Token: 0x02000845 RID: 2117
public class uniHUDWarningView : HUDWarningView
{
	// Token: 0x06003962 RID: 14690 RVA: 0x0010B538 File Offset: 0x00109738
	public override void vmethod_2()
	{
		base.vmethod_2();
		BadAssMovieClip badAssMovieClip = new BadAssMovieClip("CommonLib.swf", "SystemInfo");
		this.method_4(badAssMovieClip);
		badAssMovieClip = new BadAssMovieClip("Warning.swf", "Whole");
		this.method_3(badAssMovieClip);
	}

	// Token: 0x06003963 RID: 14691 RVA: 0x0010B57C File Offset: 0x0010977C
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._warningPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._infoPanel);
		this._warningPanel = null;
		this._infoPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Warning.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("CommonLib.swf");
	}

	// Token: 0x06003964 RID: 14692 RVA: 0x0010B604 File Offset: 0x00109804
	public override void vmethod_6()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._warningPanel);
		this._warningPanel = null;
		BadAssMovieClip badAssMovieClip = new BadAssMovieClip("Warning.swf", "Whole");
		this.method_3(badAssMovieClip);
	}

	// Token: 0x06003965 RID: 14693 RVA: 0x0010B64C File Offset: 0x0010984C
	public override void vmethod_7(string string_0 = "", Delegate_EventProc delegate_EventProc_0 = null, Delegate_EventProc delegate_EventProc_1 = null)
	{
		base.vmethod_7(string_0, delegate_EventProc_0, delegate_EventProc_1);
		if (this._warningPanel != null)
		{
			this.vmethod_10();
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._warningPanel);
			this._warningPanel.method_5(string_0, delegate_EventProc_0, delegate_EventProc_1);
			this._warningPanel.method_6();
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_World_Use_Over");
		}
	}

	// Token: 0x06003966 RID: 14694 RVA: 0x0010B6C0 File Offset: 0x001098C0
	public override void vmethod_8(bool bool_0 = true)
	{
		base.vmethod_8(bool_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Generic_Window_Close");
		if (this._warningPanel != null)
		{
			this._warningPanel.DisplayObjectContainer_0.visible = false;
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._warningPanel);
	}

	// Token: 0x06003967 RID: 14695 RVA: 0x000263E4 File Offset: 0x000245E4
	public override void vmethod_9(string string_0 = "")
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._infoPanel);
		this._infoPanel.method_5(string_0);
		this._infoPanel.mc_root.visible = true;
	}

	// Token: 0x06003968 RID: 14696 RVA: 0x0002641E File Offset: 0x0002461E
	public override void vmethod_10()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._infoPanel);
		this._infoPanel.mc_root.visible = false;
	}

	// Token: 0x06003969 RID: 14697 RVA: 0x0002644B File Offset: 0x0002464B
	private void method_3(MovieClip movieClip_0)
	{
		this._warningPanel = new uniHUDWarningView.WarningPanel();
		this._warningPanel.method_0(movieClip_0);
		movieClip_0.visible = false;
	}

	// Token: 0x0600396A RID: 14698 RVA: 0x0002646C File Offset: 0x0002466C
	private void method_4(MovieClip movieClip_0)
	{
		this._infoPanel = new uniHUDWarningView.InfoPanel();
		this._infoPanel.method_0(movieClip_0);
		this.vmethod_10();
	}

	// Token: 0x0600396B RID: 14699 RVA: 0x0002648C File Offset: 0x0002468C
	public override void vmethod_5(string string_0, string string_1)
	{
		if (this._warningPanel != null)
		{
			this._warningPanel.method_11(string_0, string_1);
		}
	}

	// Token: 0x04002820 RID: 10272
	private uniHUDWarningView.WarningPanel _warningPanel;

	// Token: 0x04002821 RID: 10273
	private uniHUDWarningView.InfoPanel _infoPanel;

	// Token: 0x02000846 RID: 2118
	private class WarningPanel : GClass51
	{
		// Token: 0x0600396D RID: 14701 RVA: 0x0010B720 File Offset: 0x00109920
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: WarningPanel onInit() 'mc_root' is null! WarningPanel won't work!!!");
				return;
			}
			this.mc_root.addFrameScript("fadeout", new EventDispatcher.EventCallback(this.method_10));
			this.mc_Confirm.method_0(this.mc_root.getChildByName<MovieClip>("mcPrevBtn"));
			this.mc_Back.method_0(this.mc_root.getChildByName<MovieClip>("mcBackBtn"));
			this.m_txMessage = this.mc_root.getChildByName<MovieClip>("mcPanel").getChildByName<TextField>("txMessage");
		}

		// Token: 0x0600396E RID: 14702 RVA: 0x0010B7D0 File Offset: 0x001099D0
		public void method_5(string string_1 = "", Delegate_EventProc delegate_EventProc_0 = null, Delegate_EventProc delegate_EventProc_1 = null)
		{
			if (this.m_txMessage != null)
			{
				this.m_txMessage.text = string_1;
			}
			if (delegate_EventProc_0 != null)
			{
				this.mc_Confirm.Boolean_1 = true;
				this.mc_Confirm.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			}
			else
			{
				this.mc_Confirm.Boolean_1 = false;
				this.mc_Confirm.removeAllEventListeners(MouseEvent.CLICK);
			}
			if (delegate_EventProc_1 != null)
			{
				this.mc_Back.Boolean_1 = true;
				this.mc_Back.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
			}
			else
			{
				this.mc_Back.Boolean_1 = false;
				this.mc_Back.removeAllEventListeners(MouseEvent.CLICK);
			}
		}

		// Token: 0x0600396F RID: 14703 RVA: 0x000264C1 File Offset: 0x000246C1
		public void method_6()
		{
			this.mc_root.visible = true;
			this.mc_root.gotoAndPlay("fadein");
		}

		// Token: 0x06003970 RID: 14704 RVA: 0x000264DF File Offset: 0x000246DF
		public void method_7()
		{
			this.mc_root.gotoAndPlay("fadeout");
		}

		// Token: 0x06003971 RID: 14705 RVA: 0x000264F1 File Offset: 0x000246F1
		private void method_8(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(false);
		}

		// Token: 0x06003972 RID: 14706 RVA: 0x0001B43F File Offset: 0x0001963F
		private void method_9(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(true);
		}

		// Token: 0x06003973 RID: 14707 RVA: 0x00026508 File Offset: 0x00024708
		private void method_10(CEvent cevent_0)
		{
			this.mc_root.visible = false;
		}

		// Token: 0x06003974 RID: 14708 RVA: 0x00026516 File Offset: 0x00024716
		public void method_11(string string_1, string string_2)
		{
			this.mc_Confirm.textField_0.text = string_1;
			this.mc_Back.textField_0.text = string_2;
		}

		// Token: 0x04002822 RID: 10274
		public MovieClip mc_root;

		// Token: 0x04002823 RID: 10275
		private GClass25 mc_Confirm = new GClass25();

		// Token: 0x04002824 RID: 10276
		private GClass25 mc_Back = new GClass25();

		// Token: 0x04002825 RID: 10277
		private TextField m_txMessage;
	}

	// Token: 0x02000847 RID: 2119
	private class InfoPanel : GClass51
	{
		// Token: 0x06003976 RID: 14710 RVA: 0x0010B888 File Offset: 0x00109A88
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: infoPanel onInit() 'mc_root' is null! WarningPanel won't work!!!");
				return;
			}
			this._infoField = this.mc_root.getChildByName<TextField>("textTips");
		}

		// Token: 0x06003977 RID: 14711 RVA: 0x0002653A File Offset: 0x0002473A
		public void method_5(string string_1)
		{
			if (this._infoField != null)
			{
				this._infoField.text = LocalizedString.smethod_0(new LocalizedString(string_1));
			}
		}

		// Token: 0x04002826 RID: 10278
		public MovieClip mc_root;

		// Token: 0x04002827 RID: 10279
		private TextField _infoField;
	}
}
