using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using XsdSettings;

// Token: 0x020007E4 RID: 2020
public class uniClassSelectView : ClassSelectView
{
	// Token: 0x06003681 RID: 13953 RVA: 0x000F99F8 File Offset: 0x000F7BF8
	public override void vmethod_2()
	{
		this._panel = new GClass51();
		DebugUtils.Log(LogCategory.GUI, "UI Base: class select view initializing!");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("CharacterClass.swf", "ClassSelectionPanel", new FuncLoad(this.method_6));
	}

	// Token: 0x06003682 RID: 13954 RVA: 0x000F9A48 File Offset: 0x000F7C48
	private void method_6(MovieClip movieClip_0)
	{
		this._panel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._panel);
		this.mcSelectView.method_14(this._iClassID);
		this.mcSelectView.method_6(0);
	}

	// Token: 0x06003683 RID: 13955 RVA: 0x000F9AA8 File Offset: 0x000F7CA8
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
		this._panel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("CharacterClass.swf");
	}

	// Token: 0x06003684 RID: 13956 RVA: 0x000F9AF8 File Offset: 0x000F7CF8
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		switch (name)
		{
		case "mcPrevBtn":
			this.mcPrevBtn = new GClass25();
			this.mcPrevBtn.method_0(movieClip);
			this.mcPrevBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
			this.mcPrevBtn.Boolean_6 = MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().Boolean_0;
			flag = true;
			break;
		case "mcNextBtn":
			this.mcNextBtn = new GClass25();
			this.mcNextBtn.method_0(movieClip);
			this.mcNextBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			flag = true;
			break;
		case "mcDescView":
			this.mcDescView = new uniClassSelectView.IntroPanel();
			this.mcDescView.method_0(movieClip);
			flag = true;
			break;
		case "mcSelectView":
		{
			this.mcSelectView = new uniClassSelectView.ClassPanel();
			uniClassSelectView.ClassPanel classPanel = this.mcSelectView;
			classPanel.classChangeCB = (ClassSelectView.ClassChangeEvent)Delegate.Combine(classPanel.classChangeCB, this.classChangeCB);
			this.mcSelectView.method_0(movieClip);
			flag = true;
			break;
		}
		}
		return flag;
	}

	// Token: 0x06003685 RID: 13957 RVA: 0x00023F21 File Offset: 0x00022121
	public override void vmethod_7(AvatarType avatarType_0, string string_0, string string_1, bool bool_0 = false)
	{
		if (this.mcDescView == null)
		{
			return;
		}
		this.mcDescView.method_5(avatarType_0);
		if (bool_0)
		{
			this.mcDescView.method_6();
		}
		else
		{
			this.mcDescView.method_8();
		}
	}

	// Token: 0x06003686 RID: 13958 RVA: 0x00023F54 File Offset: 0x00022154
	public override void vmethod_8()
	{
		if (this.mcDescView == null)
		{
			return;
		}
		this.mcDescView.method_6();
	}

	// Token: 0x06003687 RID: 13959 RVA: 0x00023F6A File Offset: 0x0002216A
	public override void vmethod_9(AvatarType avatarType_0)
	{
		this._iClassID = avatarType_0;
		if (this.mcSelectView == null)
		{
			return;
		}
		this.mcSelectView.method_14(avatarType_0);
	}

	// Token: 0x06003688 RID: 13960 RVA: 0x00023F88 File Offset: 0x00022188
	public override void vmethod_6(ClassSelectView.ClassChangeEvent classChangeEvent_0)
	{
		base.vmethod_6(classChangeEvent_0);
		if (this.mcSelectView != null)
		{
			uniClassSelectView.ClassPanel classPanel = this.mcSelectView;
			classPanel.classChangeCB = (ClassSelectView.ClassChangeEvent)Delegate.Combine(classPanel.classChangeCB, this.classChangeCB);
		}
	}

	// Token: 0x06003689 RID: 13961 RVA: 0x00023FBA File Offset: 0x000221BA
	public override void vmethod_5(ClassSelectView.ClassChangeEvent classChangeEvent_0)
	{
		base.vmethod_5(classChangeEvent_0);
		if (this.mcSelectView != null)
		{
			uniClassSelectView.ClassPanel classPanel = this.mcSelectView;
			classPanel.descChangeCB = (ClassSelectView.ClassChangeEvent)Delegate.Combine(classPanel.descChangeCB, this.descChangeCB);
		}
	}

	// Token: 0x0600368A RID: 13962 RVA: 0x00023FEC File Offset: 0x000221EC
	protected void method_7(CEvent cevent_0)
	{
		base.method_4();
	}

	// Token: 0x0600368B RID: 13963 RVA: 0x00023FF4 File Offset: 0x000221F4
	protected void method_8(CEvent cevent_0)
	{
		base.method_5();
	}

	// Token: 0x040025B0 RID: 9648
	private GClass51 _panel;

	// Token: 0x040025B1 RID: 9649
	private GClass25 mcPrevBtn;

	// Token: 0x040025B2 RID: 9650
	private GClass25 mcNextBtn;

	// Token: 0x040025B3 RID: 9651
	private uniClassSelectView.IntroPanel mcDescView;

	// Token: 0x040025B4 RID: 9652
	private uniClassSelectView.ClassPanel mcSelectView;

	// Token: 0x040025B5 RID: 9653
	private AvatarType _iClassID = AvatarType.TOTAL;

	// Token: 0x020007E5 RID: 2021
	private class IntroPanel : GClass51
	{
		// Token: 0x0600368D RID: 13965 RVA: 0x0002400B File Offset: 0x0002220B
		public void method_5(AvatarType avatarType_0)
		{
			this._ClassID = avatarType_0;
			this.method_10();
		}

		// Token: 0x0600368E RID: 13966 RVA: 0x0002401A File Offset: 0x0002221A
		public void method_6()
		{
			this.mcSelf.gotoAndPlay("jdFadein");
		}

		// Token: 0x0600368F RID: 13967 RVA: 0x0002402C File Offset: 0x0002222C
		public void method_7()
		{
			this.mcSelf.gotoAndPlay("jafadeout");
		}

		// Token: 0x06003690 RID: 13968 RVA: 0x0002403E File Offset: 0x0002223E
		public void method_8()
		{
			this.mcSelf.gotoAndStop("jdNormal");
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x000F9C74 File Offset: 0x000F7E74
		protected override void vmethod_0()
		{
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				return;
			}
			for (int i = 1; i < 4; i++)
			{
				this.mcSelf.addFrameScript(Utility.smethod_5("checkPoint_", Utility.smethod_8(i)), new EventDispatcher.EventCallback(this.vmethod_2));
			}
			this.method_9();
		}

		// Token: 0x06003692 RID: 13970 RVA: 0x00024050 File Offset: 0x00022250
		protected virtual void vmethod_2(CEvent cevent_0)
		{
			this.method_9();
			this.method_10();
		}

		// Token: 0x06003693 RID: 13971 RVA: 0x0002405E File Offset: 0x0002225E
		private void method_9()
		{
			this.mcContent = this.mcSelf.getChildByName("mcContent") as MovieClip;
		}

		// Token: 0x06003694 RID: 13972 RVA: 0x000F9CD8 File Offset: 0x000F7ED8
		private void method_10()
		{
			if (this.mcContent != null)
			{
				UnityTextField unityTextField = (UnityTextField)this.mcContent.getChildByName<TextField>("textClassName");
				if (unityTextField != null)
				{
					unityTextField.text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("CLASS_", this._ClassID.ToString())));
				}
				UnityTextField unityTextField2 = (UnityTextField)this.mcContent.getChildByName<TextField>("textClassDes");
				if (unityTextField2 != null)
				{
					unityTextField2.text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("CLASS_DESC_", this._ClassID.ToString())));
				}
			}
		}

		// Token: 0x06003695 RID: 13973 RVA: 0x000039EC File Offset: 0x00001BEC
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			return true;
		}

		// Token: 0x040025B7 RID: 9655
		private const string CHECK_FRAME_PRENAME = "checkPoint_";

		// Token: 0x040025B8 RID: 9656
		private const string FRAME_LABEL_START = "jdFadein";

		// Token: 0x040025B9 RID: 9657
		private const string FRAME_LABEL_END = "jafadeout";

		// Token: 0x040025BA RID: 9658
		private const string FRAME_LABEL_NORMAL = "jdNormal";

		// Token: 0x040025BB RID: 9659
		private const string CLASS_NAME_PREFIX = "CLASS_";

		// Token: 0x040025BC RID: 9660
		private const string CLASS_DES_PREFIX = "CLASS_DESC_";

		// Token: 0x040025BD RID: 9661
		private MovieClip mcContent;

		// Token: 0x040025BE RID: 9662
		private MovieClip mcSelf;

		// Token: 0x040025BF RID: 9663
		private AvatarType _ClassID = AvatarType.TOTAL;
	}

	// Token: 0x020007E6 RID: 2022
	private class ClassPanel : ExpandPanel
	{
		private const string START_FRAME_LABEL = "frameFadeIN";

		private AvatarType[] _arrAvatarTypeList;

		private GClass40[] _arrRadioBtn;

		public ClassChangeEvent classChangeCB;

		public ClassChangeEvent descChangeCB;

		public ClassPanel()
		{
			_arrRadioBtn = new GClass40[4];
			_arrAvatarTypeList = new AvatarType[4];
			_arrAvatarTypeList[0] = AvatarType.BERSERKER;
			_arrAvatarTypeList[1] = AvatarType.SIREN;
			_arrAvatarTypeList[2] = AvatarType.SOLDIER;
			_arrAvatarTypeList[3] = AvatarType.HUNTER;
			method_5("maskMC", "mcClassBtn");
		}

		public void method_13()
		{
			mcSelf.gotoAndPlay("frameFadeIN");
		}

		public void method_14(AvatarType avatarType_0)
		{
			int num = 0;
			for (int i = 0; i < _arrAvatarTypeList.Length; i++)
			{
				if (_arrAvatarTypeList[i] == avatarType_0)
				{
					num = i;
					break;
				}
			}
			if (_arrRadioBtn[num] != null)
			{
				_arrRadioBtn[num].Boolean_3 = true;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Length > "element".Length)
			{
				string text = movieClip.name.Substring(0, "element".Length);
				if (text == "element")
				{
					int num = Convert.ToInt32(movieClip.name.Substring("element".Length, 1));
					MovieClip movieClip2 = null;
					_arrRadioBtn[num] = null;
					movieClip2 = movieClip.getChildByName<MovieClip>("mcClassBtn");
					if (movieClip2 != null)
					{
						_arrRadioBtn[num] = new GClass40();
						_arrRadioBtn[num].method_0(movieClip2);
						_arrRadioBtn[num].addEventListener(GClass53.string_4, vmethod_3);
						_arrRadioBtn[num].addEventListener(GClass54.string_0, vmethod_2);
						_arrRadioBtn[num].bool_5 = false;
						_arrRadioBtn[num].String_1 = "classSelectView";
						_arrRadioBtn[num].Object_0 = num;
						_arrRadioBtn[num].Boolean_3 = num == 0;
						_arrRadioBtn[num].Boolean_6 = num < 4;
						MovieClip childByName = movieClip2.getChildByName<MovieClip>("mcIcon");
						MovieClip childByName2 = movieClip2.getChildByName<MovieClip>("mcBigIcon");
						childByName?.gotoAndStop(_arrAvatarTypeList[num].ToString());
						if (childByName2 != null)
						{
							childByName2.mouseEnabled = false;
							childByName2.gotoAndStop(_arrAvatarTypeList[num].ToString());
						}
					}
					result = true;
				}
			}
			return result;
		}

		protected void method_15(CEvent cevent_0)
		{
			int i;
			for (i = 0; i < _arrRadioBtn.Length && !_arrRadioBtn[i].Boolean_3; i++)
			{
			}
			if (descChangeCB != null)
			{
				descChangeCB(_arrAvatarTypeList[i]);
			}
		}

		protected void method_16(CEvent cevent_0)
		{
			GClass40 gClass = cevent_0.target as GClass40;
			if (gClass.Object_0 != null && descChangeCB != null)
			{
				descChangeCB(_arrAvatarTypeList[(int)gClass.Object_0]);
			}
		}

		protected virtual void vmethod_2(CEvent cevent_0)
		{
			if (cevent_0.target is GClass40 gClass)
			{
				gClass.DisplayObjectContainer_0.getChildByName<MovieClip>("mcIcon")?.getChildByName<MovieClip>("mcIcon")?.gotoAndStop(Utility.smethod_5("class", Utility.smethod_8((int)gClass.Object_0)));
			}
		}

		protected virtual void vmethod_3(CEvent cevent_0)
		{
			if (cevent_0.target is GClass25 { Boolean_3: not false } gClass && classChangeCB != null)
			{
				int num = (int)gClass.Object_0;
				method_6(num);
				classChangeCB(_arrAvatarTypeList[num]);
			}
		}
	}
}
