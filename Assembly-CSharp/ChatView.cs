using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020006C2 RID: 1730
public class ChatView : BaseView
{
	// Token: 0x06002D93 RID: 11667 RVA: 0x000D5124 File Offset: 0x000D3324
	public ChatView()
	{
		m_mapChannelFilter = new Dictionary<byte, bool>();
		m_mapChannelName = new Dictionary<byte, string>();
		IEnumerator enumerator = Enum.GetValues(typeof(ChatParameter)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			m_mapChannelFilter.Add((byte)enumerator.Current, value: true);
			m_mapChannelName.Add((byte)enumerator.Current, LocalizedString.smethod_0(new LocalizedString("ChatChannel_" + enumerator.Current.ToString())));
		}
	}
	// Token: 0x06002D94 RID: 11668 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002D95 RID: 11669 RVA: 0x000D52E4 File Offset: 0x000D34E4
	public override void OnTestGUI()
	{
		if (this._bInputing && this.Boolean_1)
		{
			Event current = Event.current;
			if (current != null && current.isKey)
			{
				DebugUtils.LogError(LogCategory.GUI, "Detected key code: " + current.keyCode);
			}
			string text = string.Empty;
			foreach (ChatView.ChatInfoDesc chatInfoDesc in this.m_arWorldMsg)
			{
				text = text + chatInfoDesc.m_strChatText + "\n";
			}
			GUI.TextArea(new Rect(0f, (float)(Screen.height - 300), 300f, 160f), text);
			this.chatInputString = this.msgMaker.method_7();
			GUI.TextField(new Rect(50f, (float)(Screen.height - 100), 200f, 30f), this.chatInputString);
			if (GUI.Button(new Rect(260f, (float)(Screen.height - 100), 40f, 30f), "Send"))
			{
				this.method_15();
			}
			this.selectChannel = GUI.SelectionGrid(new Rect(0f, (float)(Screen.height - 140), 300f, 30f), this.selectChannel, this.selStrings, this.selStrings.Length);
			if (GUI.Button(new Rect(0f, (float)(Screen.height - 100), 50f, 30f), this.selStrings[this.selectChannel]))
			{
				this._bChannelSel = true;
			}
			if (this._bChannelSel)
			{
				GUI.Box(new Rect(0f, (float)(Screen.height - 70), 300f, 30f), string.Empty);
				int num = GUI.SelectionGrid(new Rect(0f, (float)(Screen.height - 70), 400f, 30f), -1, this.selStrings, this.selStrings.Length);
				if (num != -1)
				{
					this._bChannelSel = false;
					this._curChannel = (ChatParameter)(num + 1);
				}
			}
		}
	}

	// Token: 0x06002D96 RID: 11670 RVA: 0x000D5510 File Offset: 0x000D3710
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "UIChatInput");
		ServiceWrapperBase<ChatServiceWarpper>.Instance.method_1(new OnNewChat(this.OnNetRecieveMsg));
		ServiceWrapperBase<ChatServiceWarpper>.Instance.method_3(new OnChatOK(this.OnNetRecievePrivateMsg));
		this.Boolean_1 = true;
	}

	// Token: 0x06002D97 RID: 11671 RVA: 0x000D556C File Offset: 0x000D376C
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.vmethod_6();
		this.Boolean_1 = false;
		ServiceWrapperBase<ChatServiceWarpper>.Instance.method_2(new OnNewChat(this.OnNetRecieveMsg));
		ServiceWrapperBase<ChatServiceWarpper>.Instance.method_4(new OnChatOK(this.OnNetRecievePrivateMsg));
		MonoSingleton<AppManager>.Instance.method_0().method_17(this, string.Empty);
	}

	// Token: 0x06002D98 RID: 11672 RVA: 0x0001E3AA File Offset: 0x0001C5AA
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bInputing && !this._bVisible)
		{
			this.vmethod_6();
		}
	}

	// Token: 0x06002D99 RID: 11673 RVA: 0x0001E3CA File Offset: 0x0001C5CA
	public override bool OnShortCutCMD(string command)
	{
		if (!this.Boolean_0 || !this._bVisible)
		{
			return false;
		}
		if (!this._bInputing)
		{
			this.vmethod_5();
			return true;
		}
		return false;
	}

	// Token: 0x06002D9A RID: 11674 RVA: 0x0001E3EF File Offset: 0x0001C5EF
	public override bool vmethod_4()
	{
		if (this._bInputing)
		{
			this.vmethod_6();
			return true;
		}
		return false;
	}

	// Token: 0x06002D9B RID: 11675 RVA: 0x0001E402 File Offset: 0x0001C602
	public void method_3(object object_0)
	{
		this.method_4(ChatParameter.Private, (string)object_0);
		this.vmethod_5();
	}

	// Token: 0x06002D9C RID: 11676 RVA: 0x000D55D0 File Offset: 0x000D37D0
	public void method_4(ChatParameter chatParameter_0, string string_0 = "")
	{
		StringBuilder stringBuilder = new StringBuilder();
		this._curChannel = chatParameter_0;
		stringBuilder.Append("[").Append(this.m_mapChannelName[(byte)this._curChannel]).Append("]");
		if (this._curChannel == ChatParameter.Private)
		{
			this._whisperTartgetName = string_0;
			stringBuilder.Append("[").Append(this._whisperTartgetName).Append("]");
		}
		this.msgMaker.method_11(stringBuilder.ToString());
		this.vmethod_8();
	}

	// Token: 0x06002D9D RID: 11677 RVA: 0x000D5660 File Offset: 0x000D3860
	public virtual void vmethod_5()
	{
		Input.imeCompositionMode = IMECompositionMode.On;
		Input.compensateSensors = true;
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
		this.msgMaker.method_4();
		this.vmethod_8();
		this.vmethod_10();
		MonoSingleton<AppManager>.Instance.method_0().method_15(true, base.String_0);
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_17), true);
		this._bInputing = true;
		this.method_6();
	}

	// Token: 0x06002D9E RID: 11678 RVA: 0x000D56E0 File Offset: 0x000D38E0
	public virtual void vmethod_6()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_17));
		Input.imeCompositionMode = IMECompositionMode.Off;
		Input.compensateSensors = false;
		MonoSingleton<AppManager>.Instance.method_0().method_15(false, base.String_0);
		this.msgMaker.method_4();
		this.vmethod_8();
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
		this._bInputing = false;
		this.method_5();
	}

	// Token: 0x06002D9F RID: 11679 RVA: 0x0001E417 File Offset: 0x0001C617
	protected void method_5()
	{
		if (this._fPastTime < 0f)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_7), false);
		}
		this._fPastTime = 0f;
	}

	// Token: 0x06002DA0 RID: 11680 RVA: 0x0001E44D File Offset: 0x0001C64D
	protected void method_6()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_7));
		this._fPastTime = -1f;
	}

	// Token: 0x06002DA1 RID: 11681 RVA: 0x0001E475 File Offset: 0x0001C675
	protected void method_7()
	{
		this._fPastTime += Time.deltaTime;
		if (this._fPastTime > 60f)
		{
			this.method_6();
			this.vmethod_9();
		}
	}

	// Token: 0x06002DA2 RID: 11682 RVA: 0x0001E4A2 File Offset: 0x0001C6A2
	public void OnNetRecieveMsg(byte chatType, int senderID, string senderNickname, string content, byte[] attachedobject)
	{
		this.method_8((ChatParameter)chatType, senderNickname, content, senderID, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9());
	}

	// Token: 0x06002DA3 RID: 11683 RVA: 0x0001E4B9 File Offset: 0x0001C6B9
	public void OnNetRecievePrivateMsg(byte chatType, int recieverID, string recieverNickname, string content, byte[] attachedobject)
	{
		this.method_8((ChatParameter)chatType, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9(), content, recieverID, recieverNickname);
	}

	// Token: 0x06002DA4 RID: 11684 RVA: 0x000D5758 File Offset: 0x000D3958
	public void method_8(ChatParameter chatParameter_0, string string_0, string string_1, int int_0, string string_2 = "")
	{
		ChatView.ChatInfoDesc chatInfoDesc = this.method_16(chatParameter_0, string_0, string_1, int_0, chatParameter_0 == ChatParameter.Private, string_2);
		this.m_arWorldMsg.Add(chatInfoDesc);
		if (this.m_arWorldMsg.Count > 2048)
		{
			this.m_arWorldMsg.RemoveRange(0, this.m_arWorldMsg.Count - 2048);
		}
		if (this.m_mapChannelFilter[(byte)chatParameter_0])
		{
			int num = Math.Max(this.m_arFilteredMsg.Count - 1, 0);
			this.m_arFilteredMsg.Add(chatInfoDesc);
			if (this._iStartIndex == num)
			{
				this._iStartIndex = Math.Max(this.m_arFilteredMsg.Count - 1, 0);
			}
			this.vmethod_10();
			this.vmethod_7();
			if (!this._bInputing)
			{
				this.method_5();
			}
		}
	}

	// Token: 0x06002DA5 RID: 11685 RVA: 0x000D581C File Offset: 0x000D3A1C
	protected ChatView.ChatInfoDesc[] method_9()
	{
		int num = this._iStartIndex + 1;
		if (num > this.Page_Msg_Number)
		{
			num = this.Page_Msg_Number;
		}
		return this.m_arFilteredMsg.GetRange(this._iStartIndex + 1 - num, num).ToArray();
	}

	// Token: 0x06002DA6 RID: 11686 RVA: 0x0001E4D0 File Offset: 0x0001C6D0
	protected void method_10(int int_0)
	{
		if (int_0 == this.CHAT_OK_RETURN_CODE)
		{
			return;
		}
		this.method_8(ChatParameter.System, string.Empty, LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5(this.CHAT_ERROR_PREFIX, Utility.smethod_8(int_0)))), 0, string.Empty);
	}

	// Token: 0x06002DA7 RID: 11687 RVA: 0x000D5860 File Offset: 0x000D3A60
	public void method_11(ChatParameter[] chatParameter_0)
	{
		this.m_arAvailableChannel.Clear();
		for (int i = 0; i < chatParameter_0.Length; i++)
		{
			this.m_arAvailableChannel.Add((byte)chatParameter_0[i]);
		}
	}

	// Token: 0x06002DA8 RID: 11688 RVA: 0x000D5894 File Offset: 0x000D3A94
	public void method_12(byte[] byte_0)
	{
		foreach (object obj in Enum.GetValues(typeof(ChatParameter)))
		{
			this.m_mapChannelFilter[(byte)obj] = false;
		}
		foreach (object obj2 in byte_0)
		{
			this.m_mapChannelFilter[(byte)obj2] = true;
		}
		this.m_arFilteredMsg.Clear();
		IEnumerator enumerator = this.m_arWorldMsg.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Dictionary<byte, bool> mapChannelFilter = this.m_mapChannelFilter;
			ChatView.ChatInfoDesc chatInfoDesc = (ChatView.ChatInfoDesc)enumerator.Current;
			if (mapChannelFilter[(byte)chatInfoDesc.m_iType])
			{
				this.m_arFilteredMsg.Add((ChatView.ChatInfoDesc)enumerator.Current);
			}
		}
		this._iStartIndex = this.m_arFilteredMsg.Count - 1;
		this.vmethod_7();
	}

	// Token: 0x06002DA9 RID: 11689 RVA: 0x000D5974 File Offset: 0x000D3B74
	protected void method_13(Vector2 vector2_0)
	{
		List<MenuItemDef> list = new List<MenuItemDef>();
		List<byte>.Enumerator enumerator = this.m_arAvailableChannel.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current != 1 && enumerator.Current != 7)
			{
				MenuItemDef menuItemDef;
				menuItemDef.itemTitle = this.m_mapChannelName[enumerator.Current];
				menuItemDef.itemData = enumerator.Current;
				menuItemDef.itemFunc = new MenuItemProcessFunc(this.method_14);
				if (enumerator.Current == 4)
				{
					if (!GroupManager.smethod_0().method_18())
					{
						menuItemDef.itemFunc = null;
					}
				}
				else if (enumerator.Current == 3 && !GuildManager.smethod_0().method_7())
				{
					menuItemDef.itemFunc = null;
				}
				list.Add(menuItemDef);
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_4(list.ToArray(), vector2_0, null);
	}

	// Token: 0x06002DAA RID: 11690 RVA: 0x0001E509 File Offset: 0x0001C709
	protected void method_14(object object_0)
	{
		this.method_4((ChatParameter)((byte)object_0), string.Empty);
	}

	// Token: 0x06002DAB RID: 11691 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7()
	{
	}

	// Token: 0x06002DAC RID: 11692 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_8()
	{
	}

	// Token: 0x06002DAD RID: 11693 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_9()
	{
	}

	// Token: 0x06002DAE RID: 11694 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_10()
	{
	}

	// Token: 0x06002DAF RID: 11695 RVA: 0x000D5A60 File Offset: 0x000D3C60
	protected void method_15()
	{
		string text = this.msgMaker.method_8().Trim();
		if (text != string.Empty)
		{
			byte[] array = new byte[1];
			ServiceWrapperBase<ChatServiceWarpper>.Instance.method_0(new OnChat(this.method_10), (byte)this._curChannel, 0, (this._curChannel != ChatParameter.Private) ? ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() : this._whisperTartgetName, this.msgMaker.method_8(), array);
		}
		this.vmethod_6();
	}

	// Token: 0x06002DB0 RID: 11696 RVA: 0x000D5ADC File Offset: 0x000D3CDC
	protected ChatView.ChatInfoDesc method_16(ChatParameter chatParameter_0, string string_0, string string_1, int int_0, bool bool_0, string string_2 = "")
	{
		string text = string.Empty;
		ChatView.ChatInfoDesc chatInfoDesc;
		chatInfoDesc.m_iType = chatParameter_0;
		chatInfoDesc.m_strUserName = string_0;
		chatInfoDesc.m_strContent = string_1;
		chatInfoDesc.m_ID = int_0;
		if (bool_0)
		{
			text = string.Concat(new string[]
			{
				"[",
				chatInfoDesc.m_strUserName,
				"] ",
				LocalizedString.smethod_0(new LocalizedString("ChatPrivate_To")),
				" [",
				string_2,
				"]",
				LocalizedString.smethod_0(new LocalizedString("Chat_Say")),
				":"
			});
		}
		else if (!(chatInfoDesc.m_strUserName == string.Empty) && chatInfoDesc.m_strUserName.Length > 0 && !(chatInfoDesc.m_strUserName == string.Empty))
		{
			text = string.Concat(new string[]
			{
				"[",
				this.m_mapChannelName[(byte)chatParameter_0],
				"][",
				chatInfoDesc.m_strUserName,
				"]",
				LocalizedString.smethod_0(new LocalizedString("Chat_Say")),
				":"
			});
		}
		else
		{
			text = string.Concat(new string[]
			{
				"[",
				this.m_mapChannelName[(byte)chatParameter_0],
				"]",
				LocalizedString.smethod_0(new LocalizedString("Chat_Say")),
				":"
			});
		}
		text += chatInfoDesc.m_strContent;
		text = string.Concat(new string[]
		{
			"<color='",
			this.m_mapChannelColor[chatInfoDesc.m_iType],
			"'>",
			text,
			"</color>"
		});
		chatInfoDesc.m_strChatText = text;
		return chatInfoDesc;
	}

	// Token: 0x06002DB1 RID: 11697 RVA: 0x000D5CA8 File Offset: 0x000D3EA8
	protected void method_17()
	{
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Return))
		{
			this.method_15();
		}
		else if (Input.inputString.Length > 0)
		{
			if (Input.inputString == "\b")
			{
				this.msgMaker.method_3(this._iCaret - 1, 1);
				this._iCaret = this.msgMaker.method_5(this._iCaret - 1, true);
				flag = true;
			}
			else if (!(Input.inputString == "\n") && !(Input.inputString == "\r"))
			{
				this.msgMaker.method_1(this._iCaret, Input.inputString);
				this._iCaret = this.msgMaker.method_5(this._iCaret + Input.inputString.Length, true);
				flag = true;
			}
		}
		if (flag)
		{
			this.vmethod_8();
		}
	}

	// Token: 0x04001FE8 RID: 8168
	protected const int Max_WorldMsg_Num = 2048;

	// Token: 0x04001FE9 RID: 8169
	protected const float TIME_HIDE = 60f;

	// Token: 0x04001FEA RID: 8170
	private string chatInputString = string.Empty;

	// Token: 0x04001FEB RID: 8171
	private int selectChannel;

	// Token: 0x04001FEC RID: 8172
	private bool _bChannelSel;

	// Token: 0x04001FED RID: 8173
	public string[] selStrings = new string[] { "System", "BroadCast", "Guild", "Group", "Team", "Friend", "Private", "Town" };

	// Token: 0x04001FEE RID: 8174
	protected bool _bInputing;

	// Token: 0x04001FEF RID: 8175
	protected Dictionary<byte, string> m_mapChannelName;

	// Token: 0x04001FF0 RID: 8176
	protected Dictionary<ChatParameter, string> m_mapChannelColor = new Dictionary<ChatParameter, string>
	{
		{
			ChatParameter.BroadCast,
			"#FFFFFF"
		},
		{
			ChatParameter.Friend,
			"#FFFFFF"
		},
		{
			ChatParameter.Group,
			"#00B0F0"
		},
		{
			ChatParameter.Guild,
			"#00FF00"
		},
		{
			ChatParameter.None,
			"#FFFFFF"
		},
		{
			ChatParameter.Private,
			"#FF2391"
		},
		{
			ChatParameter.System,
			"#A5F64E"
		},
		{
			ChatParameter.Team,
			"#00B0F0"
		},
		{
			ChatParameter.Town,
			"#A5F64E"
		}
	};

	// Token: 0x04001FF1 RID: 8177
	protected Dictionary<byte, bool> m_mapChannelFilter;

	// Token: 0x04001FF2 RID: 8178
	protected int Page_Msg_Number = 7;

	// Token: 0x04001FF3 RID: 8179
	protected int _iStartIndex;

	// Token: 0x04001FF4 RID: 8180
	protected List<ChatView.ChatInfoDesc> m_arWorldMsg = new List<ChatView.ChatInfoDesc>();

	// Token: 0x04001FF5 RID: 8181
	protected List<ChatView.ChatInfoDesc> m_arFilteredMsg = new List<ChatView.ChatInfoDesc>();

	// Token: 0x04001FF6 RID: 8182
	protected List<byte> m_arAvailableChannel = new List<byte>();

	// Token: 0x04001FF7 RID: 8183
	protected ChatStringMaker msgMaker = new ChatStringMaker();

	// Token: 0x04001FF8 RID: 8184
	protected int _iCaret;

	// Token: 0x04001FF9 RID: 8185
	protected ChatParameter _curChannel = ChatParameter.BroadCast;

	// Token: 0x04001FFA RID: 8186
	protected string _whisperTartgetName = string.Empty;

	// Token: 0x04001FFB RID: 8187
	protected float _fPastTime = -1f;

	// Token: 0x04001FFC RID: 8188
	protected string CHAT_ERROR_PREFIX = "ChatError_";

	// Token: 0x04001FFD RID: 8189
	protected int CHAT_OK_RETURN_CODE;

	// Token: 0x020006C3 RID: 1731
	protected struct ChatInfoDesc
	{
		// Token: 0x04001FFE RID: 8190
		public ChatParameter m_iType;

		// Token: 0x04001FFF RID: 8191
		public string m_strUserName;

		// Token: 0x04002000 RID: 8192
		public int m_ID;

		// Token: 0x04002001 RID: 8193
		public string m_strContent;

		// Token: 0x04002002 RID: 8194
		public string m_strChatText;
	}
}
