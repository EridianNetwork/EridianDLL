using System;
using System.Collections.Generic;
using Core;

// Token: 0x02000364 RID: 868
internal class ChatService : OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>, IChatService
{
	// Token: 0x060015E1 RID: 5601 RVA: 0x0007A994 File Offset: 0x00078B94
	public ChatService()
	{
		PhotonNetwork.onlinePeer.method_5(139, new OperationResponseCallback(this.OnChated));
		PhotonNetwork.onlinePeer.method_7(199, new EventCallback(this.OnNewchated));
		PhotonNetwork.onlinePeer.method_7(198, new EventCallback(this.OnSendChatOk));
		PhotonNetwork.networkingPeer.RegisterOperationResponseCallback(139, new OperationResponseCallback(this.OnGameChated));
		PhotonNetwork.networkingPeer.RegisterEventCallback(199, new EventCallback(this.OnGameNewchated));
	}

	// Token: 0x060015E2 RID: 5602 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0()
	{
	}

	// Token: 0x060015E3 RID: 5603 RVA: 0x0007AA48 File Offset: 0x00078C48
	public void imethod_1(OnChat onChat_0, byte byte_0, int int_0, string string_0, string string_1, byte[] byte_1)
	{
		if (byte_0 != 8)
		{
			if (byte_0 != 5)
			{
				this.mOnChat = onChat_0;
				PhotonNetwork.onlinePeer.method_3(139, new object[] { byte_0, int_0, string_0, string_1, byte_1 });
				return;
			}
		}
		this.mOnChat = onChat_0;
		DebugUtils.Log(LogCategory.Framework, "chatType: " + byte_0);
		PhotonNetwork.networkingPeer.OpCustom(139, new Dictionary<byte, object>
		{
			{ 0, byte_0 },
			{ 1, int_0 },
			{ 2, string_0 },
			{ 3, string_1 },
			{ 4, byte_1 }
		}, true);
	}

	// Token: 0x060015E4 RID: 5604 RVA: 0x0007AB0C File Offset: 0x00078D0C
	private void OnChated(short operationResponse, Dictionary<byte, object> parameters)
	{
		short num = (short)parameters[0];
		DebugUtils.Log(LogCategory.Framework, string.Concat(new object[] { "OnChated: ", operationResponse, " Result ", num }));
		if (this.mOnChat != null)
		{
			this.mOnChat((int)num);
			this.mOnChat = null;
		}
	}

	// Token: 0x060015E5 RID: 5605 RVA: 0x0000FFBA File Offset: 0x0000E1BA
	private void OnGameChated(short operationResponse, Dictionary<byte, object> parameters)
	{
		DebugUtils.Log(LogCategory.Framework, "OnChated: " + operationResponse);
		if (this.mOnChat != null)
		{
			this.mOnChat((int)operationResponse);
			this.mOnChat = null;
		}
	}

	// Token: 0x060015E6 RID: 5606 RVA: 0x0007AB74 File Offset: 0x00078D74
	private void OnNewchated(Dictionary<byte, object> parameters)
	{
		byte chattype = (byte)parameters[0];
		int charID = (int)parameters[1];
		string charNickname = (string)parameters[2];
		string content = (string)parameters[3];
		byte[] attachedobject = (byte[])parameters[4];
		mOnNewChat.ForEach(delegate(OnNewChat onNewChat_0)
		{
			onNewChat_0(chattype, charID, charNickname, content, attachedobject);
		});
		DebugUtils.Log(LogCategory.Framework, "OnNewchated  chattype: " + (int)chattype + " CharID: " + charID + " nickname : " + charNickname + " content: " + content);
	}
	// Token: 0x060015E7 RID: 5607 RVA: 0x0007AC58 File Offset: 0x00078E58
	private void OnGameNewchated(Dictionary<byte, object> parameters)
	{
		byte chattype = (byte)parameters[0];
		int charID = (int)parameters[1];
		string charNickname = (string)parameters[2];
		string content = (string)parameters[3];
		byte[] attachedobject = (byte[])parameters[4];
		mOnNewChat.ForEach(delegate(OnNewChat onNewChat_0)
		{
			onNewChat_0(chattype, charID, charNickname, content, attachedobject);
		});
		DebugUtils.Log(LogCategory.Framework, "OnNewchated  chattype: " + (int)chattype + " CharID: " + charID + " nickname : " + charNickname + " content: " + content);
	}
	// Token: 0x060015E8 RID: 5608 RVA: 0x0007AD3C File Offset: 0x00078F3C
	private void OnSendChatOk(Dictionary<byte, object> parameters)
	{
		byte chattype = (byte)parameters[0];
		int charID = (int)parameters[1];
		string charNickname = (string)parameters[2];
		string content = (string)parameters[3];
		byte[] attachedobject = (byte[])parameters[4];
		mOnChatOK.ForEach(delegate(OnChatOK onChatOK_0)
		{
			onChatOK_0(chattype, charID, charNickname, content, attachedobject);
		});
		DebugUtils.Log(LogCategory.Framework, "OnSendChatOk  chattype: " + (int)chattype + " CharID: " + charID + " nickname : " + charNickname + " content: " + content);
	}
	// Token: 0x060015E9 RID: 5609 RVA: 0x0000FFED File Offset: 0x0000E1ED
	public void imethod_2(OnNewChat onNewChat_0)
	{
		this.mOnNewChat.Add(onNewChat_0);
	}

	// Token: 0x060015EA RID: 5610 RVA: 0x0000FFFB File Offset: 0x0000E1FB
	public void imethod_3(OnNewChat onNewChat_0)
	{
		this.mOnNewChat.Remove(onNewChat_0);
	}

	// Token: 0x060015EB RID: 5611 RVA: 0x0001000A File Offset: 0x0000E20A
	public void imethod_4(OnChatOK onChatOK_0)
	{
		this.mOnChatOK.Add(onChatOK_0);
	}

	// Token: 0x060015EC RID: 5612 RVA: 0x00010018 File Offset: 0x0000E218
	public void imethod_5(OnChatOK onChatOK_0)
	{
		this.mOnChatOK.Remove(onChatOK_0);
	}

	// Token: 0x04000ECF RID: 3791
	private OnChat mOnChat;

	// Token: 0x04000ED0 RID: 3792
	private List<OnNewChat> mOnNewChat = new List<OnNewChat>();

	// Token: 0x04000ED1 RID: 3793
	private List<OnChatOK> mOnChatOK = new List<OnChatOK>();
}
