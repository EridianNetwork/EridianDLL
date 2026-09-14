using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

using System.Runtime.CompilerServices;
// Token: 0x0200085C RID: 2140
public class uniMailView : MailView
{
	// Token: 0x06003A4C RID: 14924 RVA: 0x00027056 File Offset: 0x00025256
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("InboxMail.swf", "Whole", new FuncLoad(this.method_5));
	}

	// Token: 0x06003A4D RID: 14925 RVA: 0x0011157C File Offset: 0x0010F77C
	protected void method_5(MovieClip movieClip_0)
	{
		this._container = new GClass51();
		this._mailBox = new uniMailView.MailBox();
		this._mailContentBoard = new uniMailView.MailContentBoard();
		this._container.method_0(movieClip_0);
		this._mcRootAnimation = movieClip_0;
		this._mcRootAnimation.visible = false;
		this._mcRootAnimation.addFrameScript("InboxOpen", new EventDispatcher.EventCallback(this.method_6));
		this._mcRootAnimation.addFrameScript("InboxFadeOut", new EventDispatcher.EventCallback(this.method_6));
		this._mcRootAnimation.addFrameScript("DetailAppear", new EventDispatcher.EventCallback(this.method_6));
		this._mcRootAnimation.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_6));
		this._mcRootAnimation.addFrameScript("PannelFadeOut", new EventDispatcher.EventCallback(this.method_6));
		this._mcRootAnimation.addFrameScript("ContentShrink", new EventDispatcher.EventCallback(this.method_6));
		this._mcRootAnimation.addFrameScript("InboxFadeOutEnd", new EventDispatcher.EventCallback(this.method_8));
		this._mcRootAnimation.addFrameScript("fadeoutend", new EventDispatcher.EventCallback(this.method_8));
		this._bActive = true;
	}

	// Token: 0x06003A4E RID: 14926 RVA: 0x001116BC File Offset: 0x0010F8BC
	public override void vmethod_3()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._container);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("InboxMail.swf");
		this._container = null;
		this._mailBox = null;
		this._mailContentBoard = null;
	}

	// Token: 0x06003A4F RID: 14927 RVA: 0x00111714 File Offset: 0x0010F914
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._mcRootAnimation != null)
		{
			if (bool_0)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._container);
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
				this._mcRootAnimation.visible = true;
				this.method_7();
				this.vmethod_6(MailView.MailAnimaState.KickOff);
				this.vmethod_5();
				MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_mail");
			}
			else
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
				this.vmethod_6(MailView.MailAnimaState.Quit);
			}
		}
	}

	// Token: 0x06003A50 RID: 14928 RVA: 0x0002708F File Offset: 0x0002528F
	protected override void vmethod_5()
	{
		base.vmethod_5();
		if (this._mailBox != null)
		{
			this._mailBox.method_19(this._mailInfoList);
		}
	}

	// Token: 0x06003A51 RID: 14929 RVA: 0x001117BC File Offset: 0x0010F9BC
	protected override void vmethod_7(object object_0)
	{
		base.vmethod_7(object_0);
		MailInfo mailInfo = object_0 as MailInfo;
		if (mailInfo != null)
		{
			this.vmethod_9(mailInfo);
		}
	}

	// Token: 0x06003A52 RID: 14930 RVA: 0x000270B0 File Offset: 0x000252B0
	protected override void vmethod_9(MailInfo mailInfo_0)
	{
		base.vmethod_9(mailInfo_0);
		if (mailInfo_0 == null)
		{
			return;
		}
		this.vmethod_11(mailInfo_0);
		this.vmethod_6(MailView.MailAnimaState.MailContent);
		this._mailContentBoard.method_6(mailInfo_0);
	}

	// Token: 0x06003A53 RID: 14931 RVA: 0x000270D7 File Offset: 0x000252D7
	protected override void vmethod_10(int int_0)
	{
		base.vmethod_10(int_0);
		this.vmethod_6(MailView.MailAnimaState.MailList);
	}

	// Token: 0x06003A54 RID: 14932 RVA: 0x001117E4 File Offset: 0x0010F9E4
	protected override void vmethod_6(MailView.MailAnimaState mailAnimaState_0)
	{
		if (this._curState == mailAnimaState_0)
		{
			return;
		}
		switch (mailAnimaState_0)
		{
		case MailView.MailAnimaState.KickOff:
			this._mcRootAnimation.gotoAndPlay("InboxOpen");
			break;
		case MailView.MailAnimaState.MailList:
			if (this._curState == MailView.MailAnimaState.MailContent || this._curState == MailView.MailAnimaState.Reply)
			{
				this._mcRootAnimation.gotoAndPlay("ContentShrink");
			}
			break;
		case MailView.MailAnimaState.MailContent:
			this._mcRootAnimation.gotoAndPlay("DetailAppear");
			break;
		case MailView.MailAnimaState.CreateNewMail:
			if (this._curState == MailView.MailAnimaState.MailContent)
			{
				this._mcRootAnimation.gotoAndPlay("ContentShrink");
			}
			break;
		case MailView.MailAnimaState.Quit:
			if (this._curState != MailView.MailAnimaState.MailList && this._curState != MailView.MailAnimaState.KickOff)
			{
				if (this._curState != MailView.MailAnimaState.CreateNewMail)
				{
					this._mcRootAnimation.gotoAndPlay("PannelFadeOut");
					break;
				}
			}
			this._mcRootAnimation.gotoAndPlay("InboxFadeOut");
			break;
		}
		this._curState = mailAnimaState_0;
		this._mailBox.method_18(mailAnimaState_0);
	}

	// Token: 0x06003A55 RID: 14933 RVA: 0x000270E7 File Offset: 0x000252E7
	protected void method_6(CEvent cevent_0 = null)
	{
		this.method_7();
		this.vmethod_5();
	}

	// Token: 0x06003A56 RID: 14934 RVA: 0x001118DC File Offset: 0x0010FADC
	protected void method_7()
	{
		MovieClip childByName = this._mcRootAnimation.getChildByName<MovieClip>("mcInbox");
		if (childByName != null)
		{
			MovieClip childByName2 = childByName.getChildByName<MovieClip>("mcMailBoxRoot");
			if (childByName2 != null)
			{
				this._mailBox.method_0(childByName2);
				this._mailBox.removeAllEventListeners("EVT_CLICK_CREATE_NEW_MAIL");
				this._mailBox.removeAllEventListeners("EVT_CLICK_MAILLIST_CLOSE");
				this._mailBox.removeAllEventListeners("EVT_LEFT_CLICK_MAILLIST_ITEM");
				this._mailBox.removeAllEventListeners("EVT_RIGHT_CLICK_MAILLIST_ITEM");
				this._mailBox.removeAllEventListeners("EVT_CLICK_SEND");
				this._mailBox.removeAllEventListeners("EVT_CLICK_MAILLIST");
				this._mailBox.addEventListener("EVT_CLICK_CREATE_NEW_MAIL", new EventDispatcher.EventCallback(this.method_10));
				this._mailBox.addEventListener("EVT_CLICK_MAILLIST_CLOSE", new EventDispatcher.EventCallback(this.method_9));
				this._mailBox.addEventListener("EVT_LEFT_CLICK_MAILLIST_ITEM", new EventDispatcher.EventCallback(this.method_12));
				this._mailBox.addEventListener("EVT_RIGHT_CLICK_MAILLIST_ITEM", new EventDispatcher.EventCallback(this.method_13));
				this._mailBox.addEventListener("EVT_CLICK_SEND", new EventDispatcher.EventCallback(this.method_14));
				this._mailBox.addEventListener("EVT_CLICK_MAILLIST", new EventDispatcher.EventCallback(this.method_11));
			}
		}
		MovieClip childByName3 = this._mcRootAnimation.getChildByName<MovieClip>("mcMailContent");
		if (childByName3 != null)
		{
			this._mailContentBoard.method_0(childByName3);
			this._mailContentBoard.removeAllEventListeners("EVT_CLICK_REPLY");
			this._mailContentBoard.addEventListener("EVT_CLICK_REPLY", new EventDispatcher.EventCallback(this.method_15));
			this._mailContentBoard.removeAllEventListeners("EVT_CLICK_GETREWARD");
			this._mailContentBoard.addEventListener("EVT_CLICK_GETREWARD", new EventDispatcher.EventCallback(this.method_16));
		}
	}

	// Token: 0x06003A57 RID: 14935 RVA: 0x000270F5 File Offset: 0x000252F5
	protected void method_8(CEvent cevent_0)
	{
		this._mcRootAnimation.visible = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._container);
	}

	// Token: 0x06003A58 RID: 14936 RVA: 0x0002711D File Offset: 0x0002531D
	protected void method_9(CEvent cevent_0)
	{
		this.vmethod_1(false, false);
	}

	// Token: 0x06003A59 RID: 14937 RVA: 0x00027127 File Offset: 0x00025327
	protected void method_10(CEvent cevent_0)
	{
		if (this._curState != MailView.MailAnimaState.Reply)
		{
			this.vmethod_6(MailView.MailAnimaState.CreateNewMail);
		}
	}

	// Token: 0x06003A5A RID: 14938 RVA: 0x00027139 File Offset: 0x00025339
	protected void method_11(CEvent cevent_0)
	{
		this.vmethod_6(MailView.MailAnimaState.MailList);
	}

	// Token: 0x06003A5B RID: 14939 RVA: 0x00111AB0 File Offset: 0x0010FCB0
	protected void method_12(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			MailInfo mailInfo = gclass.object_0 as MailInfo;
			if (mailInfo != null)
			{
				this.vmethod_9(mailInfo);
			}
		}
	}

	// Token: 0x06003A5C RID: 14940 RVA: 0x00111AE0 File Offset: 0x0010FCE0
	protected void method_13(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			MailInfo mailInfo = gclass.object_0 as MailInfo;
			if (mailInfo != null)
			{
				base.method_3(mailInfo);
			}
		}
	}

	// Token: 0x06003A5D RID: 14941 RVA: 0x00111B10 File Offset: 0x0010FD10
	protected void method_14(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			MailView.NewMailInfoContainer newMailInfoContainer = gclass.object_0 as MailView.NewMailInfoContainer;
			if (newMailInfoContainer != null)
			{
				this.vmethod_8(newMailInfoContainer);
			}
		}
	}

	// Token: 0x06003A5E RID: 14942 RVA: 0x00111B40 File Offset: 0x0010FD40
	protected void method_15(CEvent cevent_0)
	{
		this.vmethod_6(MailView.MailAnimaState.Reply);
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			MailInfo mailInfo = gclass.object_0 as MailInfo;
			if (mailInfo != null)
			{
				this._mailBox.method_21(mailInfo.SenderName);
			}
		}
	}

	// Token: 0x06003A5F RID: 14943 RVA: 0x00111B80 File Offset: 0x0010FD80
	protected void method_16(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			MailInfo mailInfo = gclass.object_0 as MailInfo;
			if (mailInfo != null)
			{
				this.vmethod_12(mailInfo);
			}
		}
	}

	// Token: 0x06003A60 RID: 14944 RVA: 0x00027142 File Offset: 0x00025342
	protected override void vmethod_13()
	{
		if (this._mailBox != null)
		{
			this._mailBox.method_14();
		}
	}

	// Token: 0x040028E5 RID: 10469
	protected const string EVT_CLICK_MAILLIST_CLOSE = "EVT_CLICK_MAILLIST_CLOSE";

	// Token: 0x040028E6 RID: 10470
	protected const string EVT_LEFT_CLICK_MAILLIST_ITEM = "EVT_LEFT_CLICK_MAILLIST_ITEM";

	// Token: 0x040028E7 RID: 10471
	protected const string EVT_RIGHT_CLICK_MAILLIST_ITEM = "EVT_RIGHT_CLICK_MAILLIST_ITEM";

	// Token: 0x040028E8 RID: 10472
	protected const string EVT_CLICK_CREATE_NEW_MAIL = "EVT_CLICK_CREATE_NEW_MAIL";

	// Token: 0x040028E9 RID: 10473
	protected const string EVT_CLICK_MAILLIST = "EVT_CLICK_MAILLIST";

	// Token: 0x040028EA RID: 10474
	protected const string EVT_CLICK_REPLY = "EVT_CLICK_REPLY";

	// Token: 0x040028EB RID: 10475
	protected const string EVT_CLICK_GETREWARD = "EVT_CLICK_GETREWARD";

	// Token: 0x040028EC RID: 10476
	protected const string EVT_CLICK_SEND = "EVT_CLICK_SEND";

	// Token: 0x040028ED RID: 10477
	protected const int MAX_MAIL_CONTENT_LENGTH = 300;

	// Token: 0x040028EE RID: 10478
	protected MailView.MailAnimaState _curState;

	// Token: 0x040028EF RID: 10479
	protected MovieClip _mcRootAnimation;

	// Token: 0x040028F0 RID: 10480
	protected GClass51 _container = new GClass51();

	// Token: 0x040028F1 RID: 10481
	protected uniMailView.MailBox _mailBox = new uniMailView.MailBox();

	// Token: 0x040028F2 RID: 10482
	protected uniMailView.MailContentBoard _mailContentBoard = new uniMailView.MailContentBoard();

	// Token: 0x0200085D RID: 2141
	protected class MailBox : GClass51
	{
		// Token: 0x06003A62 RID: 14946 RVA: 0x00111C28 File Offset: 0x0010FE28
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "btnMailList":
				this._tabMailList.method_0(movieClip);
				this._tabMailList.String_1 = "MAILLIST_FUNCTION_TAB";
				this._tabMailList.GClass17_0.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_12));
				this._tabMailList.Boolean_3 = true;
				this._tabMailList.bool_5 = false;
				flag = true;
				break;
			case "btnCreateNewMail":
				this._tabCreateNewMail.method_0(movieClip);
				this._tabCreateNewMail.String_1 = "MAILLIST_FUNCTION_TAB";
				this._tabCreateNewMail.bool_5 = false;
				this._tabCreateNewMail.removeAllEventListeners(MouseEvent.CLICK);
				this._tabCreateNewMail.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
				flag = true;
				break;
			case "mcBtnClose":
				this._btnClose.method_0(movieClip);
				this._btnClose.removeAllEventListeners(MouseEvent.CLICK);
				this._btnClose.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
				flag = true;
				break;
			case "mcScrollingBar":
			{
				this._scBar.method_0(movieClip);
				this._scBar.removeAllEventListeners("Scrolling");
				this._scBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_15));
				GClass45 scBar = this._scBar;
				this._scBar.int_0 = 0;
				scBar.int_1 = 0;
				movieClip.visible = false;
				flag = true;
				break;
			}
			case "mcCreateNewMail":
				this._mcCreateMaillRoot = movieClip;
				this._mcCreateMaillRoot.visible = true;
				flag = false;
				break;
			case "mcReveiverName":
				this._textInputReceiver.method_0(movieClip);
				this._textInputReceiver.removeAllEventListeners(CEvent.CHANGED);
				this._textInputReceiver.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_10));
				flag = true;
				break;
			case "mcNewMailContent":
				this._textInputNewMailContent.method_0(movieClip);
				this._textInputNewMailContent.removeAllEventListeners(CEvent.CHANGED);
				this._textInputNewMailContent.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_10));
				this._textInputNewMailContent.Int32_0 = 300;
				flag = true;
				break;
			case "btnSend":
				this._btnSend.method_0(movieClip);
				this._btnSend.removeAllEventListeners(MouseEvent.CLICK);
				this._btnSend.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_13));
				this._btnSend.Boolean_6 = false;
				flag = true;
				break;
			case "mcMailList":
			{
				this._mcMailListRoot = movieClip;
				this._mcMailListRoot.visible = false;
				for (int i = 0; i < 16; i++)
				{
					string text = "mcMailItem_" + i;
					MovieClip childByName = movieClip.getChildByName<MovieClip>(text);
					if (childByName != null)
					{
						if (this._mailItemList[i] == null)
						{
							this._mailItemList[i] = new uniMailView.MailListItem();
						}
						this._mailItemList[i].method_0(childByName);
						this._mailItemList[i].removeAllEventListeners(MouseEvent.CLICK);
						this._mailItemList[i].addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
						this._mailItemList[i].removeAllEventListeners(GClass53.string_5);
						this._mailItemList[i].addEventListener(GClass53.string_5, new EventDispatcher.EventCallback(this.method_9));
					}
				}
				flag = true;
				break;
			}
			}
			return flag;
		}

		// Token: 0x06003A63 RID: 14947 RVA: 0x00112050 File Offset: 0x00110250
		protected override void vmethod_0()
		{
			base.vmethod_0();
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			if (movieClip != null)
			{
				movieClip.addFrameScript("Ready", new EventDispatcher.EventCallback(this.method_5));
				this.method_6();
			}
		}

		// Token: 0x06003A64 RID: 14948 RVA: 0x00027157 File Offset: 0x00025357
		protected void method_5(CEvent cevent_0)
		{
			this.method_6();
		}

		// Token: 0x06003A65 RID: 14949 RVA: 0x00112090 File Offset: 0x00110290
		protected void method_6()
		{
			this._textCurMailCount = base.DisplayObjectContainer_0.getChildByName<TextField>("textCurMailCnt");
			this._textMaxMailCount = base.DisplayObjectContainer_0.getChildByName<TextField>("textMaxMailCnt");
			bool flag = this._curState != MailView.MailAnimaState.CreateNewMail && this._curState != MailView.MailAnimaState.Reply;
			if (this._mcCreateMaillRoot != null)
			{
				this._mcCreateMaillRoot.visible = !flag;
			}
			if (this._mcMailListRoot != null)
			{
				this._mcMailListRoot.visible = flag;
			}
			this._scBar.DisplayObjectContainer_0.visible = this._mailInfoList.Count > 16;
		}

		// Token: 0x06003A66 RID: 14950 RVA: 0x0002715F File Offset: 0x0002535F
		protected void method_7(CEvent cevent_0)
		{
			this.method_17();
			base.dispatchEvent(new CEvent("EVT_CLICK_MAILLIST_CLOSE"));
		}

		// Token: 0x06003A67 RID: 14951 RVA: 0x0011212C File Offset: 0x0011032C
		protected void method_8(CEvent cevent_0)
		{
			uniMailView.MailListItem mailListItem = cevent_0.target as uniMailView.MailListItem;
			if (mailListItem != null)
			{
				base.dispatchEvent(new GClass55("EVT_LEFT_CLICK_MAILLIST_ITEM", mailListItem.Object_0, true, false));
			}
		}

		// Token: 0x06003A68 RID: 14952 RVA: 0x00112164 File Offset: 0x00110364
		protected void method_9(CEvent cevent_0)
		{
			uniMailView.MailListItem mailListItem = cevent_0.target as uniMailView.MailListItem;
			if (mailListItem != null)
			{
				base.dispatchEvent(new GClass55("EVT_RIGHT_CLICK_MAILLIST_ITEM", mailListItem.Object_0, true, false));
			}
		}

		// Token: 0x06003A69 RID: 14953 RVA: 0x0011219C File Offset: 0x0011039C
		protected void method_10(CEvent cevent_0)
		{
			bool flag = false;
			if (this._textInputNewMailContent.String_0 != null && this._textInputReceiver.String_0 != null)
			{
				flag = this._textInputNewMailContent.String_0.Length != 0 && this._textInputReceiver.String_0.Length != 0;
			}
			this._btnSend.Boolean_6 = flag;
		}

		// Token: 0x06003A6A RID: 14954 RVA: 0x00027178 File Offset: 0x00025378
		protected void method_11(CEvent cevent_0)
		{
			if (this._textInputNewMailContent != null)
			{
				this._textInputNewMailContent.String_0 = string.Empty;
				this._textInputReceiver.String_0 = null;
			}
		}

		// Token: 0x06003A6B RID: 14955 RVA: 0x00112200 File Offset: 0x00110400
		protected void method_12(CEvent cevent_0)
		{
			if (this._mcCreateMaillRoot != null)
			{
				this._mcCreateMaillRoot.visible = this._tabCreateNewMail.Boolean_3;
				if (this._tabCreateNewMail.Boolean_3)
				{
					if (this._textInputNewMailContent != null)
					{
						this._textInputNewMailContent.String_0 = string.Empty;
						this._textInputReceiver.String_0 = null;
						this._scBar.DisplayObjectContainer_0.visible = false;
					}
					base.dispatchEvent(new CEvent("EVT_CLICK_CREATE_NEW_MAIL"));
				}
			}
			if (this._mcMailListRoot != null)
			{
				this._mcMailListRoot.visible = this._tabMailList.Boolean_3;
				if (this._tabMailList.Boolean_3)
				{
					base.dispatchEvent(new CEvent("EVT_CLICK_MAILLIST"));
					this._scBar.Int32_1 = 0;
				}
			}
		}

		// Token: 0x06003A6C RID: 14956 RVA: 0x001122C8 File Offset: 0x001104C8
		protected void method_13(CEvent cevent_0)
		{
			MailView.NewMailInfoContainer newMailInfoContainer = new MailView.NewMailInfoContainer();
			newMailInfoContainer.StrReceiverNickName = this._textInputReceiver.String_0;
			newMailInfoContainer.StrMailContent = this._textInputNewMailContent.String_0;
			this.method_17();
			base.dispatchEvent(new GClass55("EVT_CLICK_SEND", newMailInfoContainer, true, false));
		}

		// Token: 0x06003A6D RID: 14957 RVA: 0x0002719E File Offset: 0x0002539E
		public void method_14()
		{
			this._textInputReceiver.String_0 = string.Empty;
			this._textInputNewMailContent.String_0 = string.Empty;
		}

		// Token: 0x06003A6E RID: 14958 RVA: 0x000271C0 File Offset: 0x000253C0
		protected void method_15(CEvent cevent_0)
		{
			this.method_20(this._scBar.Int32_1);
		}

		// Token: 0x06003A6F RID: 14959 RVA: 0x000271D3 File Offset: 0x000253D3
		public void method_16()
		{
			this._tabMailList.Boolean_3 = true;
		}

		// Token: 0x06003A70 RID: 14960 RVA: 0x000271E1 File Offset: 0x000253E1
		protected void method_17()
		{
			if (this._textInputReceiver != null)
			{
				this._textInputReceiver.Boolean_2 = false;
			}
			if (this._textInputNewMailContent != null)
			{
				this._textInputNewMailContent.Boolean_2 = false;
			}
		}

		// Token: 0x06003A71 RID: 14961 RVA: 0x00112318 File Offset: 0x00110518
		public void method_18(MailView.MailAnimaState mailAnimaState_0)
		{
			if (mailAnimaState_0 == MailView.MailAnimaState.KickOff)
			{
				this._scBar.Int32_1 = 0;
			}
			bool flag = false;
			if (mailAnimaState_0 != MailView.MailAnimaState.CreateNewMail)
			{
				if (mailAnimaState_0 != MailView.MailAnimaState.Reply)
				{
					flag = true;
					if (!this._tabMailList.Boolean_3)
					{
						this._tabMailList.Boolean_3 = true;
						goto IL_0052;
					}
					goto IL_0052;
				}
			}
			if (!this._tabCreateNewMail.Boolean_3)
			{
				this._tabCreateNewMail.Boolean_3 = true;
			}
			IL_0052:
			TextField childByName = base.DisplayObjectContainer_0.getChildByName<TextField>("textMailTips");
			if (childByName != null)
			{
				childByName.visible = flag;
			}
		}

		// Token: 0x06003A72 RID: 14962 RVA: 0x00112394 File Offset: 0x00110594
		public void method_19(List<MailInfo> list_1)
		{
			this._mailInfoList = list_1;
			if (!(this._scBar.DisplayObjectContainer_0 is MovieClip))
			{
				return;
			}
			if (this._textCurMailCount != null && this._textMaxMailCount != null)
			{
				this._textMaxMailCount.text = Convert.ToString(MailServiceWrapper.MAILBOX_MAXVOLUME);
				if (list_1.Count == MailServiceWrapper.MAILBOX_MAXVOLUME)
				{
					this._textCurMailCount.textFormat.color = new Color(255f, 0f, 0f);
				}
				else
				{
					this._textCurMailCount.textFormat.color = new Color(255f, 204f, 0f);
				}
				this._textCurMailCount.text = Convert.ToString(list_1.Count);
			}
			if (list_1.Count > 16)
			{
				this._scBar.DisplayObjectContainer_0.visible = true;
				this._scBar.method_10(16, 0, list_1.Count, 1);
			}
			else
			{
				this._scBar.DisplayObjectContainer_0.visible = false;
				this._scBar.Int32_1 = 0;
			}
			this.method_20(this._scBar.Int32_1);
			string text = LocalizedString.smethod_0(new LocalizedString("MAIL_EXPIRE_WARNING"));
			Color color = Color.yellow;
			if (list_1.Count == MailServiceWrapper.MAILBOX_MAXVOLUME)
			{
				text = LocalizedString.smethod_0(new LocalizedString("MAIL_FULL_WARNING"));
				color = Color.red;
			}
			UnityTextField childByName = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textMailTips");
			if (childByName != null)
			{
				childByName.text = text;
				childByName.Color_0 = color;
			}
		}

		// Token: 0x06003A73 RID: 14963 RVA: 0x00112510 File Offset: 0x00110710
		protected void method_20(int int_0)
		{
			if (int_0 >= 0 && int_0 <= this._mailInfoList.Count)
			{
				this._scBar.DisplayObjectContainer_0.visible = this._mailInfoList.Count > 16;
				int i = 0;
				int num = int_0;
				while (i < 16 && num < this._mailInfoList.Count)
				{
					this._mailItemList[i].method_19(true);
					this._mailItemList[i].method_20(this._mailInfoList[num]);
					i++;
					num++;
				}
				while (i < 16)
				{
					if (this._mailItemList[i] != null)
					{
						this._mailItemList[i].method_19(false);
					}
					i++;
				}
				return;
			}
		}

		// Token: 0x06003A74 RID: 14964 RVA: 0x0002720B File Offset: 0x0002540B
		public void method_21(string string_1)
		{
			this._textInputReceiver.String_0 = string_1;
		}

		// Token: 0x040028F3 RID: 10483
		protected const string TAB_GROUP_NAME = "MAILLIST_FUNCTION_TAB";

		// Token: 0x040028F4 RID: 10484
		protected const string MAIL_ITEM_NAME_PREFIX = "mcMailItem_";

		// Token: 0x040028F5 RID: 10485
		protected const int MAIL_SLOT_COUNT = 16;

		// Token: 0x040028F6 RID: 10486
		protected GClass40 _tabMailList = new GClass40();

		// Token: 0x040028F7 RID: 10487
		protected GClass40 _tabCreateNewMail = new GClass40();

		// Token: 0x040028F8 RID: 10488
		protected GClass25 _btnClose = new GClass25();

		// Token: 0x040028F9 RID: 10489
		protected GClass25 _btnSend = new GClass25();

		// Token: 0x040028FA RID: 10490
		protected GClass46 _scBar = new GClass46();

		// Token: 0x040028FB RID: 10491
		protected GClass50 _textInputReceiver = new GClass50();

		// Token: 0x040028FC RID: 10492
		protected GClass50 _textInputNewMailContent = new GClass50();

		// Token: 0x040028FD RID: 10493
		protected TextField _textCurMailCount;

		// Token: 0x040028FE RID: 10494
		protected TextField _textMaxMailCount;

		// Token: 0x040028FF RID: 10495
		protected MovieClip _mcCreateMaillRoot;

		// Token: 0x04002900 RID: 10496
		protected MovieClip _mcMailListRoot;

		// Token: 0x04002901 RID: 10497
		protected uniMailView.MailListItem[] _mailItemList = new uniMailView.MailListItem[16];

		// Token: 0x04002902 RID: 10498
		protected List<MailInfo> _mailInfoList = new List<MailInfo>();

		// Token: 0x04002903 RID: 10499
		protected MailView.MailAnimaState _curState;
	}

	// Token: 0x0200085E RID: 2142
	protected class MailListItem : GClass25
	{
		protected MovieClip _mcMailStatus;

		protected MovieClip _mcRoot;

		protected MailInfo _mailInfo;

		[CompilerGenerated]
		private static Dictionary<string, int> f__switch_map23;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (f__switch_map23 == null)
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcStatusIcon", 0);
					f__switch_map23 = dictionary;
				}
				if (f__switch_map23.TryGetValue(name, out var value) && value == 0)
				{
					_mcMailStatus = movieClip;
				}
			}
			return result;
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			_mcRoot = base.DisplayObjectContainer_0 as MovieClip;
			if (_mcRoot != null)
			{
				_mcRoot.addFrameScript("up", method_22);
				_mcRoot.addFrameScript("over", method_22);
				_mcRoot.addFrameScript("disable", method_22);
			}
		}

		public void method_19(bool bool_8)
		{
			base.DisplayObjectContainer_0.visible = bool_8;
		}

		public void method_20(MailInfo mailInfo_0)
		{
			_mailInfo = mailInfo_0;
			base.Object_0 = mailInfo_0;
			method_21();
		}

		protected void method_21()
		{
			if (_mailInfo == null || _mcRoot == null)
			{
				return;
			}
			UnityTextField childByName = _mcRoot.getChildByName<UnityTextField>("textSenderName");
			UnityTextField childByName2 = _mcRoot.getChildByName<UnityTextField>("textMailDate");
			if (childByName != null)
			{
				string empty = string.Empty;
				empty = ((_mailInfo.Mailtype != 0) ? (_mailInfo.SenderName + LocalizedString.smethod_0(new LocalizedString("MAIL_PLAYER"))) : LocalizedString.smethod_0(new LocalizedString("MAIL_SYSTEM")));
				childByName.text = empty;
				if (_mailInfo.Mailstate == MailState.Unread)
				{
					childByName.Color_0 = Color.white;
					childByName2.Color_0 = Color.white;
				}
				else
				{
					childByName.Color_0 = Color.gray;
					childByName2.Color_0 = Color.gray;
				}
			}
			if (childByName2 != null)
			{
				childByName2.text = MailView.EPOCH.AddSeconds(_mailInfo.Expiration).ToLocalTime().Subtract(MailServiceWrapper.MAIL_LIFETIME)
					.ToString("d");
			}
			if (_mcMailStatus == null)
			{
				return;
			}
			string to = null;
			switch (_mailInfo.Mailstate)
			{
			case MailState.Unread:
				to = "Unread";
				if (_mailInfo.Item != null)
				{
					to = "Items";
				}
				break;
			case MailState.Read:
				to = "Read";
				if (_mailInfo.Item != null)
				{
					to = "GetItems";
				}
				break;
			case MailState.GetItems:
				to = "Read";
				break;
			}
			_mcMailStatus.gotoAndStop(to);
		}

		protected void method_22(CEvent cevent_0)
		{
			method_21();
		}
	}
	// Token: 0x0200085F RID: 2143
	public class MoneySlot : GClass24
	{
		public GClass25 button;

		public MovieClip icons;

		private TextField qtyFld;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			switch (movieClip.name)
			{
			case "icons":
				icons = movieClip;
				icons.mouseEnabled = false;
				result = true;
				break;
			case "button":
				button = new GClass25();
				button.method_0(movieClip);
				result = true;
				break;
			}
			return result;
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			qtyFld = base.DisplayObjectContainer_0.getChildByName<TextField>("textNumber");
		}

		public void method_10(QuestRewardType questRewardType_0, int int_0)
		{
			icons.gotoAndStop(questRewardType_0.ToString());
			if (qtyFld != null)
			{
				qtyFld.text = int_0.ToString();
			}
		}
	}
	// Token: 0x02000860 RID: 2144
	protected class MailContentBoard : GClass51
	{
		// Token: 0x06003A81 RID: 14977 RVA: 0x001128C8 File Offset: 0x00110AC8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			if (movieClip == null)
			{
				return;
			}
			MovieClip childByName = movieClip.getChildByName<MovieClip>("mcReceive");
			if (childByName != null)
			{
				this._textSenderName = childByName.getChildByName<TextField>("textSenderName");
				this._textMailContent = childByName.getChildByName<TextField>("textMailContent");
				this._textRewardTitle = childByName.getChildByName<TextField>("textRewardTitle");
				if (this._textRewardTitle != null)
				{
					this._textRewardTitle.visible = false;
				}
				childByName.addFrameScript("NormalMail", new EventDispatcher.EventCallback(this.method_5));
				MovieClip childByName2 = childByName.getChildByName<MovieClip>("btnReply");
				if (childByName2 != null)
				{
					this._btnReply.method_0(childByName2);
					this._btnReply.removeAllEventListeners(MouseEvent.CLICK);
					this._btnReply.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
				}
				MovieClip childByName3 = childByName.getChildByName<MovieClip>("btnGetReward");
				if (childByName3 != null)
				{
					this._btnGetReward.method_0(childByName3);
					this._btnGetReward.removeAllEventListeners(MouseEvent.CLICK);
					this._btnGetReward.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
				}
				MovieClip childByName4 = childByName.getChildByName<MovieClip>("mcRewardItem");
				if (childByName4 != null)
				{
					this._rewardSlot.method_0(childByName4);
					childByName4.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
					this._rewardSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				}
				MovieClip childByName5 = childByName.getChildByName<MovieClip>("mcRewardMoney");
				if (childByName5 != null)
				{
					this._moneySlot.method_0(childByName5);
				}
			}
			this.method_6(this._mailInfo);
		}

		// Token: 0x06003A82 RID: 14978 RVA: 0x000272D4 File Offset: 0x000254D4
		protected void method_5(CEvent cevent_0)
		{
			this.method_6(this._mailInfo);
		}

		// Token: 0x06003A83 RID: 14979 RVA: 0x00112A78 File Offset: 0x00110C78
		public void method_6(MailInfo mailInfo_0)
		{
			if (mailInfo_0 == null)
			{
				return;
			}
			string text = string.Empty;
			string text2 = string.Empty;
			if (mailInfo_0.Mailtype == MailType.System)
			{
				text = LocalizedString.smethod_0(new LocalizedString("MAIL_SYSTEM"));
				JSONObject jsonobject = JSONObject.Create(mailInfo_0.Content, -2, false, false);
				text2 = string.Empty;
				if (jsonobject != null)
				{
					JSONObject field = jsonobject.GetField("type");
					if (field != null)
					{
						switch ((int)field.n)
						{
						case 0:
							text2 = jsonobject.GetField("p1").str;
							break;
						case 1:
							text2 = LocalizedString.smethod_0(new LocalizedString("MAIL_REWARD_CONTENT"));
							break;
						case 2:
							text2 = LocalizedString.smethod_0(new LocalizedString("MAIL_QuestReward_CONTENT"));
							break;
						}
					}
				}
			}
			else
			{
				text = mailInfo_0.SenderName + LocalizedString.smethod_0(new LocalizedString("MAIL_PLAYER"));
				text2 = mailInfo_0.Content;
			}
			if (this._textSenderName != null)
			{
				this._textSenderName.text = text;
			}
			if (this._textMailContent != null)
			{
				this._textMailContent.text = text2;
			}
			bool flag = mailInfo_0.Mailtype != MailType.System;
			bool flag2 = mailInfo_0.Mailtype == MailType.System && mailInfo_0.Item != null && mailInfo_0.Item.mItem != null;
			this._btnReply.DisplayObjectContainer_0.visible = flag;
			this._btnGetReward.DisplayObjectContainer_0.visible = flag2;
			if (this._textRewardTitle != null)
			{
				this._textRewardTitle.visible = flag2;
			}
			if (mailInfo_0.Item != null && mailInfo_0.Item.mItem != null)
			{
				UIItemSlotData uiitemSlotData = new UIItemSlotData(mailInfo_0.Item.mItem, "Quest_Detail", 0, false);
				switch (mailInfo_0.Item.mItem.m_type)
				{
				case ItemType.Weapon:
				case ItemType.Shield:
				case ItemType.Material:
				case ItemType.ClassMode:
				case ItemType.Outfit:
					this._rewardSlot.Boolean_1 = true;
					this._moneySlot.Boolean_1 = false;
					this._rewardSlot.Object_0 = uiitemSlotData;
					this._rewardSlot.GInterface1_0 = new ItemTips(uiitemSlotData.item);
					this._rewardSlot.Boolean_6 = true;
					this._rewardSlot.MovieClip_0.mouseEnabled = true;
					break;
				case ItemType.Money:
					this._rewardSlot.Boolean_1 = false;
					this._moneySlot.Boolean_1 = true;
					this._moneySlot.method_10(QuestRewardType.BondCurrency, mailInfo_0.Item.mItem.m_value);
					break;
				}
			}
			else
			{
				this._rewardSlot.Boolean_1 = false;
				this._moneySlot.Boolean_1 = false;
			}
			this._mailInfo = mailInfo_0;
		}

		// Token: 0x06003A84 RID: 14980 RVA: 0x000272E2 File Offset: 0x000254E2
		protected void method_7(CEvent cevent_0)
		{
			base.dispatchEvent(new GClass55("EVT_CLICK_REPLY", this._mailInfo, true, false));
		}

		// Token: 0x06003A85 RID: 14981 RVA: 0x000272FD File Offset: 0x000254FD
		protected void method_8(CEvent cevent_0)
		{
			base.dispatchEvent(new GClass55("EVT_CLICK_GETREWARD", this._mailInfo, true, false));
		}

		// Token: 0x0400290D RID: 10509
		protected TextField _textSenderName;

		// Token: 0x0400290E RID: 10510
		protected TextField _textMailContent;

		// Token: 0x0400290F RID: 10511
		protected TextField _textRewardTitle;

		// Token: 0x04002910 RID: 10512
		protected GClass44 _rewardSlot = new GClass44();

		// Token: 0x04002911 RID: 10513
		protected uniMailView.MoneySlot _moneySlot = new uniMailView.MoneySlot();

		// Token: 0x04002912 RID: 10514
		protected GClass50 _textInputReceiverName = new GClass50();

		// Token: 0x04002913 RID: 10515
		protected GClass25 _btnReply = new GClass25();

		// Token: 0x04002914 RID: 10516
		protected GClass25 _btnGetReward = new GClass25();

		// Token: 0x04002915 RID: 10517
		protected MailInfo _mailInfo;
	}
}
