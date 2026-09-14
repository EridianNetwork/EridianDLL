using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x020008B1 RID: 2225
public class uniTownHUDView : TownHUDView
{
	// Token: 0x06003D22 RID: 15650 RVA: 0x00029425 File Offset: 0x00027625
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("TownSightBead.swf", "TownScreen", new FuncLoad(this.method_3));
	}

	// Token: 0x06003D23 RID: 15651 RVA: 0x00122494 File Offset: 0x00120694
	private void method_3(MovieClip movieClip_0)
	{
		float num = 0f;
		float num2;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num2, out num);
		movieClip_0.x = num2;
		movieClip_0.y = num;
		this._rootPanel = new GClass51();
		this._rootPanel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._rootPanel);
	}

	// Token: 0x06003D24 RID: 15652 RVA: 0x0012250C File Offset: 0x0012070C
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
		this._eTipsPanel = null;
		this._crossHairPanel = null;
		this._rootPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("TownSightBead.swf");
	}

	// Token: 0x06003D25 RID: 15653 RVA: 0x00122568 File Offset: 0x00120768
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		switch (movieClip.name)
		{
		case "mcCrossHair":
			_crossHairPanel = new TownCrossHairPanel();
			_crossHairPanel.method_0(movieClip);
			result = true;
			break;
		case "mcETips":
			_eTipsPanel = new ETipsPanel();
			_eTipsPanel.method_0(movieClip);
			result = true;
			break;
		}
		return result;
	}
	// Token: 0x06003D26 RID: 15654 RVA: 0x00122600 File Offset: 0x00120800
	public override void vmethod_5(E_USE_TYPE e_USE_TYPE_0)
	{
		base.vmethod_5(e_USE_TYPE_0);
		if (this._eTipsPanel == null)
		{
			return;
		}
		if (e_USE_TYPE_0 == E_USE_TYPE.E_NONE)
		{
			this._eTipsPanel.Boolean_0 = false;
		}
		else
		{
			this._eTipsPanel.vmethod_2((int)this._curType);
			this._eTipsPanel.Boolean_0 = true;
		}
		this.method_4();
	}

	// Token: 0x06003D27 RID: 15655 RVA: 0x00029457 File Offset: 0x00027657
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this._rootPanel == null)
		{
			return;
		}
		base.vmethod_1(bool_0, bool_1);
		this._rootPanel.DisplayObjectContainer_0.visible = this._bVisible;
	}

	// Token: 0x06003D28 RID: 15656 RVA: 0x00122654 File Offset: 0x00120854
	private void method_4()
	{
		uniHUDAimTargetView.CROSS_HAIR_COLOR cross_HAIR_COLOR;
		if (this._curType != E_USE_TYPE.E_TALK && this._curType != E_USE_TYPE.E_OPEN && this._curType != E_USE_TYPE.E_PICKUP)
		{
			if (this._curType != E_USE_TYPE.E_ENTER)
			{
				cross_HAIR_COLOR = uniHUDAimTargetView.CROSS_HAIR_COLOR.WHITE;
				goto IL_002D;
			}
		}
		cross_HAIR_COLOR = uniHUDAimTargetView.CROSS_HAIR_COLOR.GREEN;
		IL_002D:
		if (this._crossHairPanel != null)
		{
			this._crossHairPanel.vmethod_2("Town_Cross", cross_HAIR_COLOR, false);
		}
	}

	// Token: 0x06003D29 RID: 15657 RVA: 0x001226A8 File Offset: 0x001208A8
	public override bool OnScreenResized()
	{
		float num = 0f;
		float num2;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num2, out num);
		this._rootPanel.DisplayObjectContainer_0.x = num2;
		this._rootPanel.DisplayObjectContainer_0.y = num;
		return true;
	}

	// Token: 0x04002B14 RID: 11028
	private GClass51 _rootPanel;

	// Token: 0x04002B15 RID: 11029
	private ETipsPanel _eTipsPanel;

	// Token: 0x04002B16 RID: 11030
	private uniTownHUDView.TownCrossHairPanel _crossHairPanel;

	// Token: 0x020008B2 RID: 2226
	private class TownCrossHairPanel : uniHUDAimTargetView.CrossHairPanel
	{
		// Token: 0x06003D2B RID: 15659 RVA: 0x001226F8 File Offset: 0x001208F8
		public override void vmethod_2(string string_1, uniHUDAimTargetView.CROSS_HAIR_COLOR cross_HAIR_COLOR_0, bool bool_0 = false)
		{
			this._bScopeMode = bool_0;
			this._color = cross_HAIR_COLOR_0;
			if (this.mcSelf != null)
			{
				this.mcSelf.gotoAndStop(string_1);
				this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_7));
			}
		}

		// Token: 0x06003D2C RID: 15660 RVA: 0x00122744 File Offset: 0x00120944
		protected void method_7(CEvent cevent_0)
		{
			this.mcSelf.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_7));
			this.mcCrossHair = this.mcSelf.getChildByName<MovieClip>("crossHair");
			if (this.mcCrossHair != null)
			{
				this.mcCrossHair.addFrameScript("green", new EventDispatcher.EventCallback(this.method_8));
				this.mcCrossHair.gotoAndStop(this._ColorFrameMap[this._color]);
			}
		}

		// Token: 0x06003D2D RID: 15661 RVA: 0x001227C8 File Offset: 0x001209C8
		protected void method_8(CEvent cevent_0)
		{
			this.mcCrossHair.removeFrameScript("green", new EventDispatcher.EventCallback(this.method_8));
			MovieClip movieClip = this.mcCrossHair.getChildByName<MovieClip>("down");
			if (movieClip != null)
			{
				movieClip.gotoAndPlay(1);
			}
			movieClip = this.mcCrossHair.getChildByName<MovieClip>("up");
			if (movieClip != null)
			{
				movieClip.gotoAndPlay(1);
			}
			movieClip = this.mcCrossHair.getChildByName<MovieClip>("left");
			if (movieClip != null)
			{
				movieClip.gotoAndPlay(1);
			}
			movieClip = this.mcCrossHair.getChildByName<MovieClip>("right");
			if (movieClip != null)
			{
				movieClip.gotoAndPlay(1);
			}
		}
	}
}
