using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;
using pumpkin.text;
using UnityEngine;

// Token: 0x020007DF RID: 2015
public class uniClassCustomView : ClassCustomView
{
	// Token: 0x06003652 RID: 13906 RVA: 0x000F8D94 File Offset: 0x000F6F94
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._panel = new GClass51();
		DebugUtils.Log(LogCategory.GUI, "UI Base: Customization initializing!");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("ClassCustomization.swf", "CustomizationPannel", new FuncLoad(this.method_9));
	}

	// Token: 0x06003653 RID: 13907 RVA: 0x000F8DE8 File Offset: 0x000F6FE8
	private void method_9(MovieClip movieClip_0)
	{
		this._warning = movieClip_0.getChildByName("warning") as MovieClip;
		this._panel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._panel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).Stage_0.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_17));
	}

	// Token: 0x06003654 RID: 13908 RVA: 0x000F8E6C File Offset: 0x000F706C
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		switch (name)
		{
		case "mcPrevBtn":
			this._mcPrevBtn = new GClass25();
			this._mcPrevBtn.method_0(movieClip);
			this._mcPrevBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_19));
			break;
		case "mcNextBtn":
			this._mcNextBtn = new GClass25();
			this._mcNextBtn.method_0(movieClip);
			this._mcNextBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_20));
			break;
		case "mcNameInput":
			this._mcNameField = new GClass50();
			this._mcNameField.method_0(movieClip);
			this._mcNameField.Int32_0 = uniClassCustomView.MAX_CHAR;
			this._mcNameField.List_0 = GClass50.list_0;
			this._mcNameField.String_0 = this._name;
			break;
		case "mcRandomBtn":
			this._mcRandomBtn = new GClass25();
			this._mcRandomBtn.method_0(movieClip);
			this._mcRandomBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			break;
		case "mcRotateZone":
			this._mcPanelRotateZone = movieClip;
			this._mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_13), false);
			this._mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_14), false);
			this._mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_15), false);
			this._mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_16), false);
			this._mcPanelRotateZone.addEventListener(GClass53.string_3, new EventDispatcher.EventCallback(this.method_14), false);
			break;
		case "mcFeaturePanel":
			this.mcFeaturePanel = new uniClassCustomView.FeaturePanel(this);
			this.mcFeaturePanel.method_0(movieClip);
			break;
		}
		return flag;
	}

	// Token: 0x06003655 RID: 13909 RVA: 0x000F90D8 File Offset: 0x000F72D8
	public override void vmethod_6(AsyncTaskStatus genum0_0)
	{
		if (this._warning != null)
		{
			this._warning.visible = true;
			TextField textField = this._warning.getChildByName("tfLabel") as TextField;
			if (genum0_0 == AsyncTaskStatus.Error)
			{
				textField.text = LocalizedString.smethod_0(new LocalizedString("NAME_INPUT"));
			}
			else if (genum0_0 == AsyncTaskStatus.Error_NameAlreadyExists)
			{
				textField.text = LocalizedString.smethod_0(new LocalizedString("NAME_INVALID"));
			}
			else if (genum0_0 == AsyncTaskStatus.Error_NameContainsIllegalWords)
			{
				textField.text = LocalizedString.smethod_0(new LocalizedString("NAME_ILLEGAL"));
			}
			else if (genum0_0 == AsyncTaskStatus.Error_NameTooLong)
			{
				textField.text = LocalizedString.smethod_0(new LocalizedString("NAME_TOOLONG"));
			}
		}
		this.method_10();
	}

	// Token: 0x06003656 RID: 13910 RVA: 0x00023CA1 File Offset: 0x00021EA1
	public override void vmethod_7()
	{
		if (this._warning != null)
		{
			this._warning.visible = false;
		}
		this.method_11();
	}

	// Token: 0x06003657 RID: 13911 RVA: 0x00023CBD File Offset: 0x00021EBD
	private void method_10()
	{
		if (this._mcNextBtn != null)
		{
			this._mcNextBtn.Boolean_6 = true;
		}
		if (this._mcPrevBtn != null)
		{
			this._mcPrevBtn.Boolean_6 = true;
		}
	}

	// Token: 0x06003658 RID: 13912 RVA: 0x00023CE7 File Offset: 0x00021EE7
	private void method_11()
	{
		if (this._mcNextBtn != null)
		{
			this._mcNextBtn.Boolean_6 = false;
		}
		if (this._mcPrevBtn != null)
		{
			this._mcPrevBtn.Boolean_6 = false;
		}
	}

	// Token: 0x06003659 RID: 13913 RVA: 0x00023D11 File Offset: 0x00021F11
	private void method_12(CEvent cevent_0)
	{
		this.mcFeaturePanel.method_15();
	}

	// Token: 0x0600365A RID: 13914 RVA: 0x00023D1E File Offset: 0x00021F1E
	private void method_13(CEvent cevent_0)
	{
		this._bRotateEnable = true;
		base.method_8(false);
	}

	// Token: 0x0600365B RID: 13915 RVA: 0x00023D2E File Offset: 0x00021F2E
	private void method_14(CEvent cevent_0)
	{
		this._bRotateEnable = false;
		base.method_8(false);
	}

	// Token: 0x0600365C RID: 13916 RVA: 0x00023D3E File Offset: 0x00021F3E
	private void method_15(CEvent cevent_0)
	{
		this._bCursorInCheckRect = true;
		base.method_8(false);
	}

	// Token: 0x0600365D RID: 13917 RVA: 0x00023D4E File Offset: 0x00021F4E
	private void method_16(CEvent cevent_0)
	{
		this._bCursorInCheckRect = false;
		base.method_8(false);
	}

	// Token: 0x0600365E RID: 13918 RVA: 0x00023D5E File Offset: 0x00021F5E
	private void method_17(CEvent cevent_0)
	{
		if (this._bRotateEnable)
		{
			this.method_14(cevent_0);
		}
	}

	// Token: 0x0600365F RID: 13919 RVA: 0x000F9184 File Offset: 0x000F7384
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).Stage_0.removeEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_17));
		this._panel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("ClassCustomization.swf");
	}

	// Token: 0x06003660 RID: 13920 RVA: 0x00023D6F File Offset: 0x00021F6F
	private bool method_18()
	{
		if (this._name.Trim() == string.Empty)
		{
			this.vmethod_6(AsyncTaskStatus.Error);
			return false;
		}
		return true;
	}

	// Token: 0x06003661 RID: 13921 RVA: 0x00023D92 File Offset: 0x00021F92
	protected void method_19(CEvent cevent_0)
	{
		base.method_3();
	}

	// Token: 0x06003662 RID: 13922 RVA: 0x00023D9A File Offset: 0x00021F9A
	protected void method_20(CEvent cevent_0)
	{
		this._name = this._mcNameField.String_0;
		if (this.method_18())
		{
			this.vmethod_7();
			base.method_4();
		}
	}

	// Token: 0x04002591 RID: 9617
	private GClass51 _panel;

	// Token: 0x04002592 RID: 9618
	private GClass25 _mcPrevBtn;

	// Token: 0x04002593 RID: 9619
	private GClass25 _mcNextBtn;

	// Token: 0x04002594 RID: 9620
	private GClass25 _mcRandomBtn;

	// Token: 0x04002595 RID: 9621
	private MovieClip _warning;

	// Token: 0x04002596 RID: 9622
	private GClass50 _mcNameField;

	// Token: 0x04002597 RID: 9623
	private static int MAX_CHAR = 16;

	// Token: 0x04002598 RID: 9624
	private uniClassCustomView.FeaturePanel mcFeaturePanel;

	// Token: 0x04002599 RID: 9625
	private MovieClip _mcPanelRotateZone;

	// Token: 0x020007E0 RID: 2016
	private class CustomRadioButton : GClass40
	{
		// Token: 0x06003663 RID: 13923 RVA: 0x00023DC1 File Offset: 0x00021FC1
		public CustomRadioButton(uniClassCustomView uniClassCustomView_0)
		{
			this.current = 0;
			this._customView = uniClassCustomView_0;
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06003664 RID: 13924 RVA: 0x00023DD7 File Offset: 0x00021FD7
		// (set) Token: 0x06003665 RID: 13925 RVA: 0x00023DDF File Offset: 0x00021FDF
		public virtual int range { get; set; }

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06003666 RID: 13926 RVA: 0x00023DE8 File Offset: 0x00021FE8
		// (set) Token: 0x06003667 RID: 13927 RVA: 0x00023DF0 File Offset: 0x00021FF0
		public virtual int current { get; set; }

		// Token: 0x06003668 RID: 13928 RVA: 0x00023DF9 File Offset: 0x00021FF9
		public void method_19()
		{
			this.String_2 = this._customView.method_7((int)base.Object_0, this.current);
		}

		// Token: 0x06003669 RID: 13929 RVA: 0x000F91FC File Offset: 0x000F73FC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.btnLeft = new GClass25();
			this.btnLeft.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
			this.btnLeft.method_7(MouseEvent.CLICK, "UI_Generic_InGame_Movement");
			this.btnRight = new GClass25();
			this.btnRight.method_7(MouseEvent.CLICK, "UI_Generic_InGame_Movement");
			this.btnRight.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_22));
		}

		// Token: 0x0600366A RID: 13930 RVA: 0x00023E1D File Offset: 0x0002201D
		protected override void vmethod_4()
		{
			base.vmethod_4();
			this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_20));
			this.movieClip_0.mouseChildrenEnabled = true;
		}

		// Token: 0x0600366B RID: 13931 RVA: 0x000F928C File Offset: 0x000F748C
		protected void method_20(CEvent cevent_0)
		{
			this.mcTextEffect = this.movieClip_0.getChildByName<MovieClip>("textEffect");
			if (this.mcTextEffect != null)
			{
				TextField childByName = this.mcTextEffect.getChildByName<TextField>("textField");
				if (childByName != null)
				{
					childByName.text = this.string_0;
				}
			}
		}

		// Token: 0x0600366C RID: 13932 RVA: 0x000F92D8 File Offset: 0x000F74D8
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.textField_0 = this.movieClip_0.getChildByName<BitmapTextField>("textField");
			MovieClip movieClip = this.movieClip_0.getChildByName("btnLeft") as MovieClip;
			if (movieClip != null)
			{
				this.btnLeft.method_0(movieClip);
			}
			else
			{
				this.btnLeft = null;
			}
			movieClip = this.movieClip_0.getChildByName("btnRight") as MovieClip;
			if (movieClip != null)
			{
				this.btnRight.method_0(movieClip);
			}
			else
			{
				this.btnRight = null;
			}
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x00023E4E File Offset: 0x0002204E
		protected void method_21(CEvent cevent_0)
		{
			if (this.range > 0)
			{
				this.current = (this.current + this.range - 1) % this.range;
				this.method_19();
			}
		}

		// Token: 0x0600366E RID: 13934 RVA: 0x00023E7B File Offset: 0x0002207B
		protected void method_22(CEvent cevent_0)
		{
			if (this.range > 0)
			{
				this.current = (this.current + this.range + 1) % this.range;
				this.method_19();
			}
		}

		// Token: 0x170002EE RID: 750
		// (set) Token: 0x0600366F RID: 13935 RVA: 0x00023EA8 File Offset: 0x000220A8
		public override bool Boolean_6
		{
			set
			{
				base.Boolean_6 = value;
				this.btnLeft.Boolean_6 = value;
				this.btnRight.Boolean_6 = value;
				if (!value)
				{
					this.String_2 = string.Empty;
				}
			}
		}

		// Token: 0x0400259B RID: 9627
		protected GClass25 btnLeft;

		// Token: 0x0400259C RID: 9628
		protected GClass25 btnRight;

		// Token: 0x0400259D RID: 9629
		protected uniClassCustomView _customView;

		// Token: 0x0400259E RID: 9630
		protected MovieClip mcTextEffect;
	}

	// Token: 0x020007E1 RID: 2017
	private class FeaturePanel : ExpandPanel
	{
		// Token: 0x06003670 RID: 13936 RVA: 0x00023ED7 File Offset: 0x000220D7
		public FeaturePanel(uniClassCustomView uniClassCustomView_0)
		{
			this._arrRadioBtn = new uniClassCustomView.CustomRadioButton[5];
			this._customView = uniClassCustomView_0;
			base.method_5("maskMC", "mcButton");
		}

		// Token: 0x06003671 RID: 13937 RVA: 0x000F9364 File Offset: 0x000F7564
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Length > "element".Length)
			{
				string text = movieClip.name.Substring(0, "element".Length);
				if (text == "element")
				{
					int num = Convert.ToInt32(movieClip.name.Substring("element".Length, 1));
					if (num < this._arrRadioBtn.Length)
					{
						this._arrRadioBtn[num] = null;
						MovieClip childByName = movieClip.getChildByName<MovieClip>("mcButton");
						if (childByName != null)
						{
							this._arrRadioBtn[num] = new uniClassCustomView.CustomRadioButton(this._customView);
							this._arrRadioBtn[num].method_0(childByName);
							this._arrRadioBtn[num].addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_13));
							this._arrRadioBtn[num].bool_5 = false;
							this._arrRadioBtn[num].String_1 = "clsCusView";
							this._arrRadioBtn[num].current = 0;
							this._arrRadioBtn[num].range = this._customView.method_6(num);
							this._arrRadioBtn[num].Object_0 = num;
							this._arrRadioBtn[num].method_19();
						}
						flag = true;
					}
					else
					{
						movieClip.visible = false;
					}
				}
			}
			return flag;
		}

		// Token: 0x06003672 RID: 13938 RVA: 0x000F94B4 File Offset: 0x000F76B4
		public void method_13(CEvent cevent_0)
		{
			uniClassCustomView.CustomRadioButton customRadioButton = cevent_0.currentTarget as uniClassCustomView.CustomRadioButton;
			this.method_14(customRadioButton, true);
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x000F94D8 File Offset: 0x000F76D8
		public void method_14(uniClassCustomView.CustomRadioButton customRadioButton_0, bool bool_0)
		{
			if (customRadioButton_0 != null && customRadioButton_0.Object_0 != null)
			{
				this._iSelIndex = (int)customRadioButton_0.Object_0;
				this._iOptionIndex = customRadioButton_0.current;
				this._customView.method_5(this._iSelIndex, this._iOptionIndex, bool_0);
			}
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x000F9528 File Offset: 0x000F7728
		public void method_15()
		{
			for (int i = 0; i < this._arrRadioBtn.Length; i++)
			{
				int num = global::UnityEngine.Random.Range(0, this._arrRadioBtn[i].range);
				this._arrRadioBtn[i].current = num;
				this.method_14(this._arrRadioBtn[i], false);
				this._arrRadioBtn[i].method_19();
			}
		}

		// Token: 0x040025A1 RID: 9633
		private uniClassCustomView.CustomRadioButton[] _arrRadioBtn;

		// Token: 0x040025A2 RID: 9634
		protected uniClassCustomView _customView;

		// Token: 0x040025A3 RID: 9635
		private int _iSelIndex;

		// Token: 0x040025A4 RID: 9636
		private int _iOptionIndex;
	}
}
