using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;

// Token: 0x02000B12 RID: 2834
internal class LoadbalancingPeer : PhotonPeer
{
	// Token: 0x06004CC3 RID: 19651 RVA: 0x00031EA1 File Offset: 0x000300A1
	public LoadbalancingPeer(IPhotonPeerListener iphotonPeerListener_0, ConnectionProtocol connectionProtocol_0)
		: base(iphotonPeerListener_0, connectionProtocol_0)
	{
		this.NeedEncryptFlag = true;
	}

	// Token: 0x170007B7 RID: 1975
	// (get) Token: 0x06004CC4 RID: 19652 RVA: 0x00031EB2 File Offset: 0x000300B2
	// (set) Token: 0x06004CC5 RID: 19653 RVA: 0x00031EBA File Offset: 0x000300BA
	public bool NeedEncryptFlag { get; set; }

	// Token: 0x06004CC6 RID: 19654 RVA: 0x00031EC3 File Offset: 0x000300C3
	public virtual bool vmethod_0()
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinLobby()");
		}
		return this.OpCustom(229, null, true, 0, this.NeedEncryptFlag);
	}

	// Token: 0x06004CC7 RID: 19655 RVA: 0x00031EF3 File Offset: 0x000300F3
	public virtual bool vmethod_1()
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpLeaveLobby()");
		}
		return this.OpCustom(228, null, true);
	}

	// Token: 0x06004CC8 RID: 19656 RVA: 0x00142AA8 File Offset: 0x00140CA8
	public virtual bool vmethod_2(string string_0, bool bool_0, bool bool_1, byte byte_0, bool bool_2, Hashtable hashtable_0, Hashtable hashtable_1, string[] string_1)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpCreateRoom()");
		}
		Hashtable hashtable = new Hashtable();
		hashtable[253] = bool_1;
		hashtable[254] = bool_0;
		hashtable[250] = string_1;
		hashtable.MergeStringKeys(hashtable_0);
		if (byte_0 > 0)
		{
			hashtable[byte.MaxValue] = byte_0;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[248] = hashtable;
		dictionary[249] = hashtable_1;
		dictionary[250] = true;
		if (!string.IsNullOrEmpty(string_0))
		{
			dictionary[byte.MaxValue] = string_0;
		}
		if (bool_2)
		{
			dictionary[241] = bool_2;
			hashtable[249] = bool_2;
		}
		return this.OpCustom(227, dictionary, true);
	}

	// Token: 0x06004CC9 RID: 19657 RVA: 0x00142BB8 File Offset: 0x00140DB8
	public bool method_0(Hashtable hashtable_0, Hashtable hashtable_1, int int_0 = 50)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[237] = hashtable_0;
		dictionary[236] = hashtable_1;
		dictionary[235] = int_0;
		return this.OpCustom(221, dictionary, true, 0, this.NeedEncryptFlag);
	}

	// Token: 0x06004CCA RID: 19658 RVA: 0x00142C08 File Offset: 0x00140E08
	public virtual bool vmethod_3(string string_0, Hashtable hashtable_0, Hashtable hashtable_1)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRoom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[byte.MaxValue] = string_0;
		dictionary[250] = true;
		if (hashtable_0 != null)
		{
			dictionary[249] = hashtable_0;
		}
		if (hashtable_1 != null)
		{
			dictionary[248] = hashtable_1;
		}
		return this.OpCustom(226, dictionary, true, 0, this.NeedEncryptFlag);
	}

	// Token: 0x06004CCB RID: 19659 RVA: 0x00142C84 File Offset: 0x00140E84
	public virtual bool vmethod_4(Hashtable hashtable_0, byte byte_0, Hashtable hashtable_1, MatchmakingMode matchmakingMode_0)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandomRoom()");
		}
		Hashtable hashtable = new Hashtable();
		hashtable.MergeStringKeys(hashtable_0);
		if (byte_0 > 0)
		{
			hashtable[byte.MaxValue] = byte_0;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (hashtable.Count > 0)
		{
			dictionary[248] = hashtable;
		}
		if (hashtable_1 != null && hashtable_1.Count > 0)
		{
			dictionary[249] = hashtable_1;
		}
		if (matchmakingMode_0 != MatchmakingMode.FillRoom)
		{
			dictionary[223] = (byte)matchmakingMode_0;
		}
		return this.OpCustom(225, dictionary, true, 0, this.NeedEncryptFlag);
	}

	// Token: 0x06004CCC RID: 19660 RVA: 0x00142D30 File Offset: 0x00140F30
	public bool method_1(string string_0)
	{
		PhotonNetwork.networkingPeer.mRoomToGetInto = new Room(null, null);
		return this.OpCustom(198, new Dictionary<byte, object> { { 0, string_0 } }, true);
	}

	// Token: 0x06004CCD RID: 19661 RVA: 0x00142D6C File Offset: 0x00140F6C
	public bool method_2(string string_0)
	{
		PhotonNetwork.networkingPeer.mRoomToGetInto = new Room(null, null);
		return this.OpCustom(197, new Dictionary<byte, object> { { 0, string_0 } }, true);
	}

	// Token: 0x06004CCE RID: 19662 RVA: 0x00031F1C File Offset: 0x0003011C
	public bool method_3(int int_0, Hashtable hashtable_0, bool bool_0, byte byte_0)
	{
		return this.vmethod_5(int_0, hashtable_0.StripToStringKeys(), bool_0, byte_0);
	}

	// Token: 0x06004CCF RID: 19663 RVA: 0x00142DA8 File Offset: 0x00140FA8
	protected virtual bool vmethod_5(int int_0, Hashtable hashtable_0, bool bool_0, byte byte_0)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, hashtable_0);
		dictionary.Add(254, int_0);
		if (bool_0)
		{
			dictionary.Add(250, bool_0);
		}
		return this.OpCustom(252, dictionary, bool_0, byte_0);
	}

	// Token: 0x06004CD0 RID: 19664 RVA: 0x00142E18 File Offset: 0x00141018
	protected void method_4(byte byte_0, object object_0)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[byte_0] = object_0;
		this.vmethod_6(hashtable, true, 0);
	}

	// Token: 0x06004CD1 RID: 19665 RVA: 0x00031F2E File Offset: 0x0003012E
	public bool method_5(Hashtable hashtable_0, bool bool_0, byte byte_0)
	{
		return this.vmethod_6(hashtable_0.StripToStringKeys(), bool_0, byte_0);
	}

	// Token: 0x06004CD2 RID: 19666 RVA: 0x00142E44 File Offset: 0x00141044
	public virtual bool vmethod_6(Hashtable hashtable_0, bool bool_0, byte byte_0)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfRoom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, hashtable_0);
		if (bool_0)
		{
			dictionary.Add(250, bool_0);
		}
		return this.OpCustom(252, dictionary, bool_0, byte_0);
	}

	// Token: 0x06004CD3 RID: 19667 RVA: 0x00142EA0 File Offset: 0x001410A0
	public virtual bool vmethod_7(string string_0, string string_1, string string_2, string string_3)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = string_1;
		dictionary[224] = string_0;
		dictionary[104] = string_2;
		dictionary[109] = string_3;
		dictionary[105] = 1;
		return this.OpCustom(230, dictionary, true, 0, base.IsEncryptionAvailable);
	}

	// Token: 0x06004CD4 RID: 19668 RVA: 0x00142F1C File Offset: 0x0014111C
	public virtual bool vmethod_8(byte[] byte_0, byte[] byte_1)
	{
		if (base.DebugOut >= DebugLevel.ALL)
		{
			base.Listener.DebugReturn(DebugLevel.ALL, "OpChangeGroups()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (byte_0 != null)
		{
			dictionary[239] = byte_0;
		}
		if (byte_1 != null)
		{
			dictionary[238] = byte_1;
		}
		return this.OpCustom(248, dictionary, true, 0);
	}

	// Token: 0x06004CD5 RID: 19669 RVA: 0x00142F78 File Offset: 0x00141178
	public virtual bool vmethod_9(byte byte_0, byte byte_1, Hashtable hashtable_0, bool bool_0, byte byte_2)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = hashtable_0;
		dictionary[244] = byte_0;
		if (byte_1 != 0)
		{
			dictionary[240] = byte_1;
		}
		return this.OpCustom(253, dictionary, bool_0, byte_2);
	}

	// Token: 0x06004CD6 RID: 19670 RVA: 0x00031F3E File Offset: 0x0003013E
	public virtual bool vmethod_10(byte byte_0, Hashtable hashtable_0, bool bool_0, byte byte_1)
	{
		return this.vmethod_13(byte_0, hashtable_0, bool_0, byte_1, EventCaching.DoNotCache, ReceiverGroup.Others);
	}

	// Token: 0x06004CD7 RID: 19671 RVA: 0x00031F4D File Offset: 0x0003014D
	public virtual bool vmethod_11(byte byte_0, Hashtable hashtable_0, bool bool_0, byte byte_1, int[] int_0)
	{
		return this.vmethod_12(byte_0, hashtable_0, bool_0, byte_1, int_0, EventCaching.DoNotCache);
	}

	// Token: 0x06004CD8 RID: 19672 RVA: 0x00142FCC File Offset: 0x001411CC
	public virtual bool vmethod_12(byte byte_0, Hashtable hashtable_0, bool bool_0, byte byte_1, int[] int_0, EventCaching eventCaching_0)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = hashtable_0;
		dictionary[244] = byte_0;
		if (eventCaching_0 != EventCaching.DoNotCache)
		{
			dictionary[247] = (byte)eventCaching_0;
		}
		if (int_0 != null)
		{
			dictionary[252] = int_0;
		}
		return this.OpCustom(253, dictionary, bool_0, byte_1);
	}

	// Token: 0x06004CD9 RID: 19673 RVA: 0x0014304C File Offset: 0x0014124C
	public virtual bool vmethod_13(byte byte_0, Hashtable hashtable_0, bool bool_0, byte byte_1, EventCaching eventCaching_0, ReceiverGroup receiverGroup_0)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = hashtable_0;
		dictionary[244] = byte_0;
		if (receiverGroup_0 != ReceiverGroup.Others)
		{
			dictionary[246] = (byte)receiverGroup_0;
		}
		if (eventCaching_0 != EventCaching.DoNotCache)
		{
			dictionary[247] = (byte)eventCaching_0;
		}
		return this.OpCustom(253, dictionary, bool_0, byte_1);
	}
}
