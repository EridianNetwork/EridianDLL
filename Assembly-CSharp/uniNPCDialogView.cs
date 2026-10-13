using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

// Token: 0x0200086B RID: 2155
public class uniNPCDialogView : NPCDialogView
{
	// Token: 0x06003AD3 RID: 15059 RVA: 0x00027717 File Offset: 0x00025917
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Quest.swf", "Movie_DialogRoot", new FuncLoad(this.method_7));
	}

	// Token: 0x06003AD4 RID: 15060 RVA: 0x001145C4 File Offset: 0x001127C4
	private void method_7(MovieClip movieClip_0)
	{
		this._root = new GClass51();
		this._root.method_0(movieClip_0);
		MovieClip childByName = movieClip_0.getChildByName<MovieClip>("mcRoot");
		if (childByName != null)
		{
			this._dialog = new uniNPCDialogView.NPCDialog();
			this._dialog.method_0(childByName);
			this._dialog.method_5(false);
		}
	}

	// Token: 0x06003AD5 RID: 15061 RVA: 0x0011461C File Offset: 0x0011281C
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
		this._root = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Quest.swf");
	}

	// Token: 0x06003AD6 RID: 15062 RVA: 0x0011466C File Offset: 0x0011286C
	protected override void vmethod_7()
	{
		base.vmethod_7();
		if (this._dialog != null)
		{
			if (this._iOnShowStrIndex < 0 || this._iOnShowStrIndex >= this._strDialogList.Count)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "Dialog text out of index ");
				return;
			}
			this._dialog.method_6(this._strDialogList[this._iOnShowStrIndex]);
		}
	}

	// Token: 0x06003AD7 RID: 15063 RVA: 0x001146D0 File Offset: 0x001128D0
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._root);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			this._dialog.method_7();
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
			this._dialog.method_8();
		}
	}

	// Token: 0x04002946 RID: 10566
	protected uniNPCDialogView.NPCDialog _dialog;

	// Token: 0x04002947 RID: 10567
	protected GClass51 _root;

	// Token: 0x0200086C RID: 2156
	public class NPCDialog : GClass51
	{
		// Token: 0x06003AD9 RID: 15065 RVA: 0x00114754 File Offset: 0x00112954
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._rootMC.addFrameScript("fadeout", new EventDispatcher.EventCallback(this.method_11));
			this._rootMC.addFrameScript("nromal", new EventDispatcher.EventCallback(this.method_11));
			this._rootMC.addFrameScript("greetingwords_IN", new EventDispatcher.EventCallback(this.method_11));
			this._rootMC.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_9));
		}

		// Token: 0x06003ADA RID: 15066 RVA: 0x00027749 File Offset: 0x00025949
		public void method_5(bool bool_0)
		{
			this._rootMC.visible = bool_0;
		}

		// Token: 0x06003ADB RID: 15067 RVA: 0x00027757 File Offset: 0x00025957
		public void method_6(string string_1)
		{
			this._strDialogID = string_1;
			this.method_10();
		}

		// Token: 0x06003ADC RID: 15068 RVA: 0x00027766 File Offset: 0x00025966
		public void method_7()
		{
			this._rootMC.visible = true;
			if (this._rootMC != null)
			{
				this._rootMC.gotoAndPlay("fadein");
			}
		}

		// Token: 0x06003ADD RID: 15069 RVA: 0x0002778C File Offset: 0x0002598C
		public void method_8()
		{
			if (this._rootMC != null)
			{
				this._rootMC.gotoAndPlay("fadeout");
			}
		}

		// Token: 0x06003ADE RID: 15070 RVA: 0x000277A6 File Offset: 0x000259A6
		protected void method_9(CEvent cevent_0)
		{
			this._rootMC.visible = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		// Token: 0x06003ADF RID: 15071 RVA: 0x001147EC File Offset: 0x001129EC
		protected void method_10()
		{
			MovieClip childByName = (this.displayObjectContainer_0 as MovieClip).getChildByName<MovieClip>("mcNPCDialog");
			if (childByName == null)
			{
				return;
			}
			string text = null;
			if (this._strDialogID != null)
			{
				text = LocalizedString.smethod_0(new LocalizedString(this._strDialogID));
				if (text != null)
				{
					text = text.Replace("\\n", "\n").Replace("\r\n", "\n").Replace('\r', '\n');
				}
			}
			UnityTextField childByName2 = childByName.getChildByName<UnityTextField>("textDescription");
			if (childByName2 != null)
			{
				childByName2.multiline = true;
				TextFormat textFormat = childByName2.textFormat;
				if (textFormat != null)
				{
					textFormat.color = Color.yellow;
					childByName2.textFormat = textFormat;
				}
				childByName2.text = text;
			}
		}

		// Token: 0x06003AE0 RID: 15072 RVA: 0x000277C9 File Offset: 0x000259C9
		protected void method_11(CEvent cevent_0)
		{
			this.method_10();
		}

		// Token: 0x04002948 RID: 10568
		protected string _strDialogID;

		// Token: 0x04002949 RID: 10569
		private MovieClip _rootMC;
	}
}
