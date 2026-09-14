using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x020007DD RID: 2013
public class uniChatView : ChatView
{
	// Token: 0x06003628 RID: 13864 RVA: 0x0002397A File Offset: 0x00021B7A
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("ChatSystem.swf", "Panel_ChatAll", new FuncLoad(this.method_18));
	}

	// Token: 0x06003629 RID: 13865 RVA: 0x000F85C8 File Offset: 0x000F67C8
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this.m_ChatPanel != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_ChatPanel);
		}
		this.m_ChatPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("ChatSystem.swf");
	}

	// Token: 0x0600362A RID: 13866 RVA: 0x000239AC File Offset: 0x00021BAC
	public override void vmethod_5()
	{
		if (this.m_ChatPanel != null)
		{
			if (this.m_ChatPanel.Boolean_1)
			{
				return;
			}
			base.vmethod_5();
			this.m_ChatPanel.method_7();
		}
	}

	// Token: 0x0600362B RID: 13867 RVA: 0x000239D5 File Offset: 0x00021BD5
	public override void vmethod_6()
	{
		base.vmethod_6();
		if (this.m_ChatPanel != null)
		{
			this.m_ChatPanel.method_9(string.Empty, 0);
			this.m_ChatPanel.method_8();
		}
	}

	// Token: 0x0600362C RID: 13868 RVA: 0x00023A01 File Offset: 0x00021C01
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this.m_ChatPanel != null)
		{
			this.m_ChatPanel.DisplayObjectContainer_0.visible = this._bVisible;
		}
	}

	// Token: 0x0600362D RID: 13869 RVA: 0x000F8620 File Offset: 0x000F6820
	private void method_18(MovieClip movieClip_0)
	{
		this.m_ChatPanel = new uniChatView.ChatPanel();
		this.m_ChatPanel._arrChannelNames = new string[6];
		this.m_ChatPanel._arrChannelNames[0] = LocalizedString.smethod_0(new LocalizedString("ChatChannel_All"));
		this.m_ChatPanel.addEventListener("Channel0", new EventDispatcher.EventCallback(this.method_19));
		int num = 1;
		List<byte>.Enumerator enumerator = this.m_arAvailableChannel.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (num < 6)
			{
				this.m_ChatPanel._arrChannelNames[num] = this.m_mapChannelName[enumerator.Current];
				this.m_ChatPanel.addEventListener(Utility.smethod_5("Channel", Utility.smethod_8(num)), new EventDispatcher.EventCallback(this.method_20));
				num++;
			}
		}
		movieClip_0.stopAll();
		this.m_ChatPanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_32(this.m_ChatPanel);
		this.method_26();
		this.m_ChatPanel.addEventListener("Send", new EventDispatcher.EventCallback(this.method_21));
		this.m_ChatPanel.addEventListener("SendChannel", new EventDispatcher.EventCallback(this.method_22));
		this.m_ChatPanel.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_23));
		this.m_ChatPanel.addEventListener("GotoLast", new EventDispatcher.EventCallback(this.method_24));
	}

	// Token: 0x0600362E RID: 13870 RVA: 0x000F8794 File Offset: 0x000F6994
	protected void method_19(CEvent cevent_0)
	{
		byte[] array = this.m_arAvailableChannel.ToArray();
		base.method_12(array);
	}

	// Token: 0x0600362F RID: 13871 RVA: 0x000F87B4 File Offset: 0x000F69B4
	protected void method_20(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			int num = (int)gclass.object_0;
			byte[] array = new byte[] { this.m_arAvailableChannel[num - 1] };
			base.method_12(array);
		}
	}

	// Token: 0x06003630 RID: 13872 RVA: 0x00023A29 File Offset: 0x00021C29
	protected void method_21(CEvent cevent_0)
	{
		base.method_15();
	}

	// Token: 0x06003631 RID: 13873 RVA: 0x00023A31 File Offset: 0x00021C31
	protected void method_22(CEvent cevent_0)
	{
		base.method_13(this.m_ChatPanel.method_11());
	}

	// Token: 0x06003632 RID: 13874 RVA: 0x00023A44 File Offset: 0x00021C44
	protected void method_23(CEvent cevent_0)
	{
		this._iStartIndex = this.m_ChatPanel.Int32_0;
		this.method_25();
	}

	// Token: 0x06003633 RID: 13875 RVA: 0x00023A5D File Offset: 0x00021C5D
	protected void method_24(CEvent cevent_0)
	{
		this.m_ChatPanel.Int32_0 = this.m_arFilteredMsg.Count - 1;
	}

	// Token: 0x06003634 RID: 13876 RVA: 0x00023A77 File Offset: 0x00021C77
	protected override void vmethod_7()
	{
		this.method_26();
	}

	// Token: 0x06003635 RID: 13877 RVA: 0x000F87F8 File Offset: 0x000F69F8
	protected void method_25()
	{
		if (this.m_ChatPanel != null)
		{
			string text = string.Empty;
			ChatView.ChatInfoDesc[] array = base.method_9();
			foreach (ChatView.ChatInfoDesc chatInfoDesc in array)
			{
				text = text + chatInfoDesc.m_strChatText + "\n";
			}
			this.m_ChatPanel.method_10(text);
		}
	}

	// Token: 0x06003636 RID: 13878 RVA: 0x000F885C File Offset: 0x000F6A5C
	protected void method_26()
	{
		if (this.m_ChatPanel != null)
		{
			this.m_ChatPanel.method_12(this.Page_Msg_Number, Math.Min(this.Page_Msg_Number - 1, this.m_arFilteredMsg.Count - 1), this.m_arFilteredMsg.Count - 1, this._iStartIndex);
		}
	}

	// Token: 0x06003637 RID: 13879 RVA: 0x00023A7F File Offset: 0x00021C7F
	protected override void vmethod_8()
	{
		if (this.m_ChatPanel != null)
		{
			this.m_ChatPanel.method_9(this.msgMaker.method_7(), 0);
		}
	}

	// Token: 0x06003638 RID: 13880 RVA: 0x00023AA0 File Offset: 0x00021CA0
	protected override void vmethod_9()
	{
		if (this.m_ChatPanel != null)
		{
			this.m_ChatPanel.method_6();
		}
	}

	// Token: 0x06003639 RID: 13881 RVA: 0x00023AB5 File Offset: 0x00021CB5
	protected override void vmethod_10()
	{
		if (this.m_ChatPanel != null)
		{
			this.m_ChatPanel.method_5();
		}
	}

	// Token: 0x04002580 RID: 9600
	protected uniChatView.ChatPanel m_ChatPanel;

	// Token: 0x020007DE RID: 2014
	public class ChatPanel : GClass51
	{
		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x0600363B RID: 13883 RVA: 0x00023ADE File Offset: 0x00021CDE
		// (set) Token: 0x0600363C RID: 13884 RVA: 0x00023AEB File Offset: 0x00021CEB
		public bool Boolean_0
		{
			get
			{
				return base.DisplayObjectContainer_0.visible;
			}
			set
			{
				if (value)
				{
					this.method_16();
				}
				else
				{
					this.method_17();
				}
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x0600363D RID: 13885 RVA: 0x00023AFE File Offset: 0x00021CFE
		public bool Boolean_1
		{
			get
			{
				return this.mcInputer.isPlaying;
			}
		}

		// Token: 0x0600363E RID: 13886 RVA: 0x00023B0B File Offset: 0x00021D0B
		public void method_5()
		{
			if (this.mcContent != null && !this._contentVisible)
			{
				this.mcContent.visible = true;
				this.mcContent.gotoAndPlay("fadein");
				this._contentVisible = true;
			}
		}

		// Token: 0x0600363F RID: 13887 RVA: 0x00023B40 File Offset: 0x00021D40
		public void method_6()
		{
			if (this.mcContent != null && this._contentVisible)
			{
				this.mcContent.gotoAndPlay("fadeout");
				this._contentVisible = false;
			}
		}

		// Token: 0x06003640 RID: 13888 RVA: 0x00023B69 File Offset: 0x00021D69
		public void method_7()
		{
			if (this.mcInputer != null)
			{
				this.mcInputer.visible = true;
				this.mcInputer.gotoAndPlay("fadein");
			}
		}

		// Token: 0x06003641 RID: 13889 RVA: 0x00023B8F File Offset: 0x00021D8F
		public void method_8()
		{
			if (this.mcInputer != null)
			{
				this.mcInputer.gotoAndPlay("fadeout");
			}
		}

		// Token: 0x06003642 RID: 13890 RVA: 0x00023BA9 File Offset: 0x00021DA9
		public void method_9(string string_1, int int_0 = 0)
		{
			if (this.tfInputer != null)
			{
				this.tfInputer.text = string_1;
			}
		}

		// Token: 0x06003643 RID: 13891 RVA: 0x00023BBF File Offset: 0x00021DBF
		public void method_10(string string_1)
		{
			if (this.tfContent != null)
			{
				this.tfContent.text = string_1;
			}
		}

		// Token: 0x06003644 RID: 13892 RVA: 0x00023BD5 File Offset: 0x00021DD5
		public Vector2 method_11()
		{
			return GClass20.GClass20_0.method_3(this.mcChannelBtn.DisplayObjectContainer_0, new Vector2(this.mcChannelBtn.DisplayObjectContainer_0.x, this.mcChannelBtn.DisplayObjectContainer_0.y));
		}

		// Token: 0x06003645 RID: 13893 RVA: 0x00023C11 File Offset: 0x00021E11
		public void method_12(int int_0, int int_1, int int_2, int int_3)
		{
			if (this.mcScrollingBar != null)
			{
				this.mcScrollingBar.method_10(int_0, int_1, int_2, 1);
				this.mcScrollingBar.Int32_1 = int_3;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06003646 RID: 13894 RVA: 0x00023C37 File Offset: 0x00021E37
		// (set) Token: 0x06003647 RID: 13895 RVA: 0x00023C4E File Offset: 0x00021E4E
		public int Int32_0
		{
			get
			{
				if (this.mcScrollingBar != null)
				{
					return this.mcScrollingBar.Int32_1;
				}
				return 0;
			}
			set
			{
				if (this.mcScrollingBar != null)
				{
					this.mcScrollingBar.Int32_1 = value;
				}
			}
		}

		// Token: 0x06003648 RID: 13896 RVA: 0x00023C64 File Offset: 0x00021E64
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcContent.visible = this._contentVisible;
		}

		// Token: 0x06003649 RID: 13897 RVA: 0x000F88B0 File Offset: 0x000F6AB0
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcChanelBtn0":
			case "mcChanelBtn1":
			case "mcChanelBtn2":
			case "mcChanelBtn3":
			case "mcChanelBtn4":
			case "mcChanelBtn5":
			{
				int num2 = Convert.ToInt32(movieClip.name.Substring(movieClip.name.Length - 1, 1));
				this._arrChanelBtn[num2] = new GClass40();
				this._arrChanelBtn[num2].method_0(movieClip);
				this._arrChanelBtn[num2].bool_5 = false;
				this._arrChanelBtn[num2].String_1 = "chatChannel";
				this._arrChanelBtn[num2].Object_0 = num2;
				this._arrChanelBtn[num2].Boolean_3 = num2 == 0;
				this._arrChanelBtn[num2].Boolean_1 = num2 < 6;
				this._arrChanelBtn[num2].addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_14));
				if (this._arrChannelNames != null)
				{
					this._arrChanelBtn[num2].String_2 = this._arrChannelNames[num2];
				}
				flag = true;
				break;
			}
			case "mcInputer":
				this.mcInputer = movieClip;
				this.mcInputer.addFrameScript("end", new EventDispatcher.EventCallback(this.method_18));
				this.mcInputer.gotoAndStop("end");
				this.mcInputer.visible = false;
				flag = false;
				break;
			case "mcInputRoot":
				this.mcInputRoot = movieClip;
				this.tfInputer = this.mcInputRoot.getChildByName<UnityTextField>("tfInputer");
				if (this.tfInputer != null)
				{
					this.tfInputer.text = string.Empty;
				}
				flag = false;
				break;
			case "mcContent":
				this.mcContent = movieClip;
				this.mcContent.visible = false;
				this.mcContent.addFrameScript("end", new EventDispatcher.EventCallback(this.method_18));
				this.mcContent.gotoAndStop("end");
				flag = false;
				break;
			case "mcContentRoot":
				this.mcContentRoot = movieClip;
				this.tfContent = this.mcContentRoot.getChildByName<UnityTextField>("tfContent");
				if (this.tfContent != null)
				{
					this.tfContent.text = string.Empty;
				}
				flag = false;
				break;
			case "mcChannelBtn":
				this.mcChannelBtn = new GClass25();
				this.mcChannelBtn.method_0(movieClip);
				this.mcChannelBtn.Object_0 = "SendChannel";
				this.mcChannelBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_15));
				flag = true;
				break;
			case "mcSendBtn":
				this.mcSendBtn = new GClass25();
				this.mcSendBtn.method_0(movieClip);
				this.mcSendBtn.Object_0 = "Send";
				this.mcSendBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_15));
				flag = true;
				break;
			case "mcLastBtn":
				this.mcLastBtn = new GClass25();
				this.mcLastBtn.method_0(movieClip);
				this.mcLastBtn.Object_0 = "GotoLast";
				this.mcLastBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_15));
				flag = true;
				break;
			case "mcScrollingBar":
				this.mcScrollingBar = new GClass46();
				this.mcScrollingBar.method_0(movieClip);
				this.mcScrollingBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_13));
				flag = true;
				break;
			case "mcSettingBtn":
				this.mcSettingBtn = new GClass25();
				this.mcSettingBtn.method_0(movieClip);
				this.mcSettingBtn.Boolean_6 = false;
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x0600364A RID: 13898 RVA: 0x000216B0 File Offset: 0x0001F8B0
		protected void method_13(CEvent cevent_0)
		{
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x0600364B RID: 13899 RVA: 0x000F8D08 File Offset: 0x000F6F08
		protected void method_14(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass != null && gclass.Object_0 != null)
			{
				base.dispatchEvent(new GClass55(Utility.smethod_5("Channel", gclass.Object_0.ToString()), gclass.Object_0, true, false));
			}
		}

		// Token: 0x0600364C RID: 13900 RVA: 0x000F8D58 File Offset: 0x000F6F58
		protected void method_15(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass != null && gclass.Object_0 != null)
			{
				base.dispatchEvent(new CEvent(gclass.Object_0.ToString()));
			}
		}

		// Token: 0x0600364D RID: 13901 RVA: 0x0000311B File Offset: 0x0000131B
		protected void method_16()
		{
		}

		// Token: 0x0600364E RID: 13902 RVA: 0x0000311B File Offset: 0x0000131B
		protected void method_17()
		{
		}

		// Token: 0x0600364F RID: 13903 RVA: 0x00023C7D File Offset: 0x00021E7D
		protected void method_18(CEvent cevent_0)
		{
			(cevent_0.currentTarget as MovieClip).visible = false;
		}

		// Token: 0x04002581 RID: 9601
		public const int CHANNEL_BUTTON_NUMBER = 6;

		// Token: 0x04002582 RID: 9602
		protected MovieClip mcContent;

		// Token: 0x04002583 RID: 9603
		protected MovieClip mcContentRoot;

		// Token: 0x04002584 RID: 9604
		protected GClass46 mcScrollingBar;

		// Token: 0x04002585 RID: 9605
		protected GClass25 mcLastBtn;

		// Token: 0x04002586 RID: 9606
		protected UnityTextField tfContent;

		// Token: 0x04002587 RID: 9607
		protected UnityTextField tfInputer;

		// Token: 0x04002588 RID: 9608
		protected MovieClip mcInputer;

		// Token: 0x04002589 RID: 9609
		protected MovieClip mcInputRoot;

		// Token: 0x0400258A RID: 9610
		protected GClass25 mcSendBtn;

		// Token: 0x0400258B RID: 9611
		protected GClass25 mcChannelBtn;

		// Token: 0x0400258C RID: 9612
		protected GClass25 mcSettingBtn;

		// Token: 0x0400258D RID: 9613
		protected GClass40[] _arrChanelBtn = new GClass40[6];

		// Token: 0x0400258E RID: 9614
		public string[] _arrChannelNames;

		// Token: 0x0400258F RID: 9615
		protected bool _contentVisible;
	}
}
