using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020003C8 RID: 968
internal class PresenceService : OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>, IPresenceService
{
	// Token: 0x0600186F RID: 6255 RVA: 0x00081AB0 File Offset: 0x0007FCB0
	public PresenceService()
	{
		this.mOnPresenceUpdated = new List<OnPresenceUpdated>();
		this.mOnNotifyAntiAddictionLevelEvent = new List<OnNotifyAntiAddictionLevelEvent>();
		PhotonNetwork.onlinePeer.method_5(147, new OperationResponseCallback(this.OnGetPresenceResponse));
		PhotonNetwork.onlinePeer.method_5(146, new OperationResponseCallback(this.OnGetAllFriendsPresenceResponse));
		PhotonNetwork.onlinePeer.method_5(152, new OperationResponseCallback(this.OnCharacterSearch));
		PhotonNetwork.onlinePeer.method_5(85, new OperationResponseCallback(this.OnGetAntiLevel));
		PhotonNetwork.onlinePeer.method_7(195, new EventCallback(this.OnPresenceUpdatedEvent));
		PhotonNetwork.onlinePeer.method_7(163, new EventCallback(this.OnKickPlayerEvent));
		PhotonNetwork.onlinePeer.method_7(159, new EventCallback(this.OnNotifyAntiAddictionLevelEvent));
	}

	// Token: 0x06001870 RID: 6256 RVA: 0x0001239B File Offset: 0x0001059B
	public void imethod_0(int int_0, OnGetPresence onGetPresence_0)
	{
		this.mOnGetPresence = onGetPresence_0;
		PhotonNetwork.onlinePeer.method_3(147, new object[] { int_0 });
	}

	// Token: 0x06001871 RID: 6257 RVA: 0x000123C3 File Offset: 0x000105C3
	public void imethod_1(OnGetPresence onGetPresence_0)
	{
		this.mOnGetPresence = onGetPresence_0;
		PhotonNetwork.onlinePeer.method_3(147, new object[] { OnlineService.s_characterId });
	}

	// Token: 0x06001872 RID: 6258 RVA: 0x00081BB0 File Offset: 0x0007FDB0
	private void OnGetPresenceResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetPresence != null)
		{
			if (operationResponse == 0)
			{
				Hashtable hashtable = (Hashtable)parameters[0];
				this.mOnGetPresence(new Presence(hashtable));
			}
			else
			{
				this.mOnGetPresence(null);
			}
			this.mOnGetPresence = null;
		}
	}

	// Token: 0x06001873 RID: 6259 RVA: 0x000123EF File Offset: 0x000105EF
	public void imethod_2(OnGetFriendsPresence onGetFriendsPresence_0)
	{
		this.mOnGetFriendsPresence = onGetFriendsPresence_0;
		PhotonNetwork.onlinePeer.method_3(146, new object[0]);
	}

	// Token: 0x06001874 RID: 6260 RVA: 0x00081BFC File Offset: 0x0007FDFC
	private void OnGetAllFriendsPresenceResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetFriendsPresence != null)
		{
			if (operationResponse == 0)
			{
				Presence[] array = new Presence[parameters.Count];
				int num = 0;
				foreach (object obj in parameters.Values)
				{
					Hashtable hashtable = (Hashtable)obj;
					array[num++] = new Presence(hashtable);
				}
				this.mOnGetFriendsPresence(array);
			}
			else
			{
				this.mOnGetFriendsPresence(null);
			}
			this.mOnGetFriendsPresence = null;
		}
	}

	// Token: 0x06001875 RID: 6261 RVA: 0x0001240E File Offset: 0x0001060E
	public void method_0(int int_0, int int_1)
	{
		PhotonNetwork.onlinePeer.method_3(155, new object[] { int_0, int_1 });
	}

	// Token: 0x06001876 RID: 6262 RVA: 0x00012438 File Offset: 0x00010638
	public void imethod_3(OnSearchForCharacter onSearchForCharacter_0, string string_0)
	{
		this.mOnSearchForCharacter = onSearchForCharacter_0;
		PhotonNetwork.onlinePeer.method_3(152, new object[] { string_0 });
	}

	// Token: 0x06001877 RID: 6263 RVA: 0x00081C98 File Offset: 0x0007FE98
	private void OnCharacterSearch(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnSearchForCharacter != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				Hashtable hashtable = (Hashtable)parameters[0];
				Presence presence = new Presence(hashtable);
				this.mOnSearchForCharacter(presence);
			}
			else
			{
				this.mOnSearchForCharacter(null);
			}
			this.mOnSearchForCharacter = null;
		}
	}

	// Token: 0x06001878 RID: 6264 RVA: 0x00081CF0 File Offset: 0x0007FEF0
	public void OnKickPlayerEvent(Dictionary<byte, object> parameters)
	{
		string text = "You have been Kicked by Server[" + ((int)parameters[0]).ToString() + "]";
		if (!string.IsNullOrEmpty(text))
		{
			DebugUtils.LogWarning(LogCategory.Network, text);
		}
		GameUIManager gameUIManager = MonoSingleton<AppManager>.Instance.method_0();
		LocalizedString localizedString = new LocalizedString("Warning_LogonPC2");
		gameUIManager.vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(localizedString), new Delegate_EventProc(this.method_1), null);
	}

	// Token: 0x06001879 RID: 6265 RVA: 0x0000C515 File Offset: 0x0000A715
	private void method_1()
	{
		AppManager.s_allowQuit = true;
		Application.Quit();
	}

	// Token: 0x0600187A RID: 6266 RVA: 0x0001245B File Offset: 0x0001065B
	public void method_2(int int_0, OnGetAntiAddictionLevel onGetAntiAddictionLevel_0)
	{
		this.mOnGetAntiAddictionLevel = onGetAntiAddictionLevel_0;
		PhotonNetwork.onlinePeer.method_3(85, new object[] { int_0 });
	}

	// Token: 0x0600187B RID: 6267 RVA: 0x00081D68 File Offset: 0x0007FF68
	public void OnGetAntiLevel(short operationResponse, Dictionary<byte, object> parameters)
	{
		int num = (int)parameters[0];
		int num2 = (int)parameters[1];
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[] { "OnGetAntiLevel  accountId:", num, " antilevel:", num2 }));
		if (this.mOnGetAntiAddictionLevel != null)
		{
			this.mOnGetAntiAddictionLevel(num, num2);
		}
	}

	// Token: 0x0600187C RID: 6268 RVA: 0x00012480 File Offset: 0x00010680
	public void imethod_4(OnPresenceUpdated onPresenceUpdated_0)
	{
		this.mOnPresenceUpdated.Add(onPresenceUpdated_0);
	}

	// Token: 0x0600187D RID: 6269 RVA: 0x0001248E File Offset: 0x0001068E
	public void imethod_5(OnPresenceUpdated onPresenceUpdated_0)
	{
		this.mOnPresenceUpdated.Remove(onPresenceUpdated_0);
	}

	// Token: 0x0600187E RID: 6270 RVA: 0x00081DD8 File Offset: 0x0007FFD8
	private void OnPresenceUpdatedEvent(Dictionary<byte, object> parameters)
	{
		Presence presence = new Presence((Hashtable)parameters[0]);
		mOnPresenceUpdated.ForEach(delegate(OnPresenceUpdated onPresenceUpdated_0)
		{
			onPresenceUpdated_0(presence);
		});
	}
	// Token: 0x0600187F RID: 6271 RVA: 0x0001249D File Offset: 0x0001069D
	public void imethod_6(OnNotifyAntiAddictionLevelEvent onNotifyAntiAddictionLevelEvent_0)
	{
		this.mOnNotifyAntiAddictionLevelEvent.Add(onNotifyAntiAddictionLevelEvent_0);
	}

	// Token: 0x06001880 RID: 6272 RVA: 0x000124AB File Offset: 0x000106AB
	public void imethod_7(OnNotifyAntiAddictionLevelEvent onNotifyAntiAddictionLevelEvent_0)
	{
		this.mOnNotifyAntiAddictionLevelEvent.Remove(onNotifyAntiAddictionLevelEvent_0);
	}

	// Token: 0x06001881 RID: 6273 RVA: 0x00081E1C File Offset: 0x0008001C
	public void OnNotifyAntiAddictionLevelEvent(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int antilevel = (int)parameters[1];
		DebugUtils.Log(LogCategory.Network, "OnNotifyAntiLevel  accountId:" + accountId + " antilevel:" + antilevel);
		mOnNotifyAntiAddictionLevelEvent.ForEach(delegate(OnNotifyAntiAddictionLevelEvent onNotifyAntiAddictionLevelEvent_0)
		{
			onNotifyAntiAddictionLevelEvent_0(accountId, antilevel);
		});
	}
	// Token: 0x040010A4 RID: 4260
	public readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	// Token: 0x040010A5 RID: 4261
	private List<OnPresenceUpdated> mOnPresenceUpdated;

	// Token: 0x040010A6 RID: 4262
	private List<OnNotifyAntiAddictionLevelEvent> mOnNotifyAntiAddictionLevelEvent;

	// Token: 0x040010A7 RID: 4263
	private OnGetPresence mOnGetPresence;

	// Token: 0x040010A8 RID: 4264
	private OnGetAntiAddictionLevel mOnGetAntiAddictionLevel;

	// Token: 0x040010A9 RID: 4265
	private OnGetFriendsPresence mOnGetFriendsPresence;

	// Token: 0x040010AA RID: 4266
	private OnSearchForCharacter mOnSearchForCharacter;
}
