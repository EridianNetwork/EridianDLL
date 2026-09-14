using System;
using System.Collections;
using Core;
using ExitGames.Client.Photon;

// Token: 0x02000B36 RID: 2870
public class Room : RoomInfo
{
	// Token: 0x06004E42 RID: 20034 RVA: 0x00032EF9 File Offset: 0x000310F9
	internal Room(string string_0, Hashtable hashtable_0)
		: base(string_0, hashtable_0)
	{
		this.propertiesListedInLobby = new string[0];
	}

	// Token: 0x06004E43 RID: 20035 RVA: 0x0014BE0C File Offset: 0x0014A00C
	internal Room(string string_0, Hashtable hashtable_0, bool bool_0, bool bool_1, int int_0, bool bool_2, string[] string_1)
		: base(string_0, hashtable_0)
	{
		this.visibleField = bool_0;
		this.openField = bool_1;
		this.autoCleanUpField = bool_2;
		if (int_0 > 255)
		{
			DebugUtils.LogError(LogCategory.Network, "Error: Room() called with " + int_0 + " maxplayers. This has been reverted to the max of 255 players, because internally a 'byte' is used.");
			int_0 = 255;
		}
		this.maxPlayersField = (byte)int_0;
		if (string_1 != null)
		{
			this.propertiesListedInLobby = string_1;
		}
		else
		{
			this.propertiesListedInLobby = new string[0];
		}
	}

	// Token: 0x170007F1 RID: 2033
	// (get) Token: 0x06004E44 RID: 20036 RVA: 0x00032F0F File Offset: 0x0003110F
	public int Int32_0
	{
		get
		{
			if (PhotonNetwork.playerList != null)
			{
				return PhotonNetwork.playerList.Length;
			}
			return 0;
		}
	}

	// Token: 0x170007F2 RID: 2034
	// (get) Token: 0x06004E45 RID: 20037 RVA: 0x00032F21 File Offset: 0x00031121
	// (set) Token: 0x06004E46 RID: 20038 RVA: 0x00032F29 File Offset: 0x00031129
	public string String_1
	{
		get
		{
			return this.nameField;
		}
		internal set
		{
			this.nameField = value;
		}
	}

	// Token: 0x170007F3 RID: 2035
	// (get) Token: 0x06004E47 RID: 20039 RVA: 0x00032F32 File Offset: 0x00031132
	// (set) Token: 0x06004E48 RID: 20040 RVA: 0x0014BE8C File Offset: 0x0014A08C
	public int maxPlayers
	{
		get
		{
			return (int)this.maxPlayersField;
		}
		set
		{
			if (!this.Equals(PhotonNetwork.room))
			{
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value > 255)
			{
				DebugUtils.LogError(LogCategory.Network, "Error: room.maxPlayers called with value " + value + ". This has been reverted to the max of 255 players, because internally a 'byte' is used.");
				value = 255;
			}
			if (value != (int)this.maxPlayersField && !PhotonNetwork.offlineMode)
			{
				PhotonNetwork.networkingPeer.OpSetRoomProperties(new Hashtable { 
				{
					byte.MaxValue,
					(byte)value
				} }, true, 0);
			}
			this.maxPlayersField = (byte)value;
		}
	}

	// Token: 0x170007F4 RID: 2036
	// (get) Token: 0x06004E49 RID: 20041 RVA: 0x00032F3A File Offset: 0x0003113A
	// (set) Token: 0x06004E4A RID: 20042 RVA: 0x0014BF28 File Offset: 0x0014A128
	public bool Boolean_2
	{
		get
		{
			return this.openField;
		}
		set
		{
			if (!this.Equals(PhotonNetwork.room))
			{
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value != this.openField && !PhotonNetwork.offlineMode)
			{
				PhotonNetwork.networkingPeer.OpSetRoomProperties(new Hashtable { { 253, value } }, true, 0);
			}
			this.openField = value;
		}
	}

	// Token: 0x170007F5 RID: 2037
	// (get) Token: 0x06004E4B RID: 20043 RVA: 0x00032F42 File Offset: 0x00031142
	// (set) Token: 0x06004E4C RID: 20044 RVA: 0x0014BF94 File Offset: 0x0014A194
	public bool Boolean_3
	{
		get
		{
			return this.visibleField;
		}
		set
		{
			if (!this.Equals(PhotonNetwork.room))
			{
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value != this.visibleField && !PhotonNetwork.offlineMode)
			{
				PhotonNetwork.networkingPeer.OpSetRoomProperties(new Hashtable { { 254, value } }, true, 0);
			}
			this.visibleField = value;
		}
	}

	// Token: 0x170007F6 RID: 2038
	// (get) Token: 0x06004E4D RID: 20045 RVA: 0x00032F4A File Offset: 0x0003114A
	// (set) Token: 0x06004E4E RID: 20046 RVA: 0x00032F52 File Offset: 0x00031152
	public string[] propertiesListedInLobby { get; private set; }

	// Token: 0x170007F7 RID: 2039
	// (get) Token: 0x06004E4F RID: 20047 RVA: 0x00032F5B File Offset: 0x0003115B
	public bool Boolean_4
	{
		get
		{
			return this.autoCleanUpField;
		}
	}

	// Token: 0x06004E50 RID: 20048 RVA: 0x0014C000 File Offset: 0x0014A200
	public void method_1(Hashtable hashtable_0)
	{
		if (hashtable_0 == null)
		{
			return;
		}
		base.Hashtable_0.MergeStringKeys(hashtable_0);
		base.Hashtable_0.StripKeysWithNullValues();
		Hashtable hashtable = hashtable_0.StripToStringKeys();
		PhotonNetwork.networkingPeer.method_5(hashtable, true, 0);
	}
}
