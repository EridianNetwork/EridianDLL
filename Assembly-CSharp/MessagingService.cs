using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003C1 RID: 961
internal class MessagingService : OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>, IMessagingService
{
	// Token: 0x06001859 RID: 6233 RVA: 0x000814D0 File Offset: 0x0007F6D0
	public MessagingService()
	{
		PhotonNetwork.onlinePeer.method_5(210, new OperationResponseCallback(this.OnMessagesRetrieved));
		PhotonNetwork.onlinePeer.method_7(223, new EventCallback(this.OnMessageReceived));
	}

	// Token: 0x0600185A RID: 6234 RVA: 0x00012201 File Offset: 0x00010401
	public void imethod_0(int int_0, string string_0, int int_1 = 0)
	{
		this.imethod_1(int_0, string_0, string.Empty, int_1);
	}

	// Token: 0x0600185B RID: 6235 RVA: 0x00012211 File Offset: 0x00010411
	public void imethod_1(int int_0, string string_0, string string_1, int int_1 = 0)
	{
		PhotonNetwork.onlinePeer.method_3(211, new object[] { int_0, string_0, string_1, int_1 });
	}

	// Token: 0x0600185C RID: 6236 RVA: 0x00012244 File Offset: 0x00010444
	public void imethod_2(OnRetrieveMessages onRetrieveMessages_0, string string_0, bool bool_0, int int_0 = 1, int int_1 = 50)
	{
		this.mOnRetrieveMessages = onRetrieveMessages_0;
		PhotonNetwork.onlinePeer.method_3(210, new object[] { string_0, bool_0, int_0, int_1 });
	}

	// Token: 0x0600185D RID: 6237 RVA: 0x00081528 File Offset: 0x0007F728
	private void OnMessagesRetrieved(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnRetrieveMessages != null)
		{
			if (operationResponse == 0)
			{
				Dictionary<int, Hashtable> dictionary = (Dictionary<int, Hashtable>)parameters[0];
				Message[] array = new Message[dictionary.Count];
				int num = 0;
				foreach (KeyValuePair<int, Hashtable> keyValuePair in dictionary)
				{
					array[num++] = new Message
					{
						mId = (int)keyValuePair.Value["id"],
						mSender = (int)keyValuePair.Value["sender"],
						mType = (string)keyValuePair.Value["type"],
						mPayload = (string)keyValuePair.Value["payload"],
						mRead = ((int)keyValuePair.Value["read"] != 0)
					};
				}
				this.mOnRetrieveMessages(array);
			}
			else
			{
				this.mOnRetrieveMessages(null);
			}
			this.mOnRetrieveMessages = null;
		}
	}

	// Token: 0x0600185E RID: 6238 RVA: 0x00012284 File Offset: 0x00010484
	public void imethod_3(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(209, new object[] { int_0 });
	}

	// Token: 0x0600185F RID: 6239 RVA: 0x000122A5 File Offset: 0x000104A5
	public void imethod_4(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(208, new object[] { int_0 });
	}

	// Token: 0x06001860 RID: 6240 RVA: 0x000122C6 File Offset: 0x000104C6
	public void imethod_5(string string_0, OnRecieveMessage onRecieveMessage_0)
	{
		if (this.mMessageListeners.ContainsKey(string_0))
		{
			throw new ArgumentException(string.Format("RegisterMessageListener: Already registered a callback for type {0}", string_0), "type");
		}
		this.mMessageListeners[string_0] = onRecieveMessage_0;
	}

	// Token: 0x06001861 RID: 6241 RVA: 0x000122F9 File Offset: 0x000104F9
	public void imethod_6(string string_0)
	{
		this.mMessageListeners.Remove(string_0);
	}

	// Token: 0x06001862 RID: 6242 RVA: 0x00081674 File Offset: 0x0007F874
	private void OnMessageReceived(Dictionary<byte, object> parameters)
	{
		Message message = new Message
		{
			mId = (int)parameters[0],
			mSender = (int)parameters[1],
			mType = (string)parameters[2],
			mPayload = (string)parameters[3]
		};
		if (this.mMessageListeners.ContainsKey(message.mType))
		{
			this.mMessageListeners[message.mType](message);
		}
	}

	// Token: 0x04001074 RID: 4212
	private Dictionary<string, OnRecieveMessage> mMessageListeners = new Dictionary<string, OnRecieveMessage>();

	// Token: 0x04001075 RID: 4213
	private OnRetrieveMessages mOnRetrieveMessages;
}
