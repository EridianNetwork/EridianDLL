using System;
using System.Collections;
using Core;

// Token: 0x02000B33 RID: 2867
public class PhotonPlayer
{
	// Token: 0x06004E26 RID: 20006 RVA: 0x00032D71 File Offset: 0x00030F71
	public PhotonPlayer(bool bool_0, int int_0, string string_0)
	{
		this.customProperties = new Hashtable();
		this.isLocal = bool_0;
		this.actorID = int_0;
		this.nameField = string_0;
	}

	// Token: 0x06004E27 RID: 20007 RVA: 0x00032DAB File Offset: 0x00030FAB
	protected internal PhotonPlayer(bool bool_0, int int_0, Hashtable hashtable_0)
	{
		this.customProperties = new Hashtable();
		this.isLocal = bool_0;
		this.actorID = int_0;
		this.method_0(hashtable_0);
	}

	// Token: 0x170007EC RID: 2028
	// (get) Token: 0x06004E28 RID: 20008 RVA: 0x00032DE5 File Offset: 0x00030FE5
	public int ActorId
	{
		get
		{
			return this.actorID;
		}
	}

	// Token: 0x170007ED RID: 2029
	// (get) Token: 0x06004E29 RID: 20009 RVA: 0x00032DED File Offset: 0x00030FED
	// (set) Token: 0x06004E2A RID: 20010 RVA: 0x00032DF5 File Offset: 0x00030FF5
	public string String_0
	{
		get
		{
			return this.nameField;
		}
		set
		{
			if (!this.isLocal)
			{
				DebugUtils.LogError(LogCategory.Network, "Error: Cannot change the name of a remote player!");
				return;
			}
			this.nameField = value;
		}
	}

	// Token: 0x170007EE RID: 2030
	// (get) Token: 0x06004E2B RID: 20011 RVA: 0x00032E13 File Offset: 0x00031013
	public bool Boolean_0
	{
		get
		{
			return PhotonNetwork.networkingPeer.mMasterClient == this;
		}
	}

	// Token: 0x170007EF RID: 2031
	// (get) Token: 0x06004E2C RID: 20012 RVA: 0x00032E22 File Offset: 0x00031022
	// (set) Token: 0x06004E2D RID: 20013 RVA: 0x00032E2A File Offset: 0x0003102A
	public Hashtable customProperties { get; private set; }

	// Token: 0x170007F0 RID: 2032
	// (get) Token: 0x06004E2E RID: 20014 RVA: 0x0014B0B0 File Offset: 0x001492B0
	public Hashtable Hashtable_0
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Merge(this.customProperties);
			hashtable[byte.MaxValue] = this.String_0;
			return hashtable;
		}
	}

	// Token: 0x06004E2F RID: 20015 RVA: 0x0014B0E8 File Offset: 0x001492E8
	internal void method_0(Hashtable hashtable_0)
	{
		if (hashtable_0 != null && hashtable_0.Count != 0 && !this.customProperties.Equals(hashtable_0))
		{
			if (hashtable_0.ContainsKey(byte.MaxValue))
			{
				this.nameField = (string)hashtable_0[byte.MaxValue];
			}
			this.customProperties.MergeStringKeys(hashtable_0);
			this.customProperties.StripKeysWithNullValues();
			return;
		}
	}

	// Token: 0x06004E30 RID: 20016 RVA: 0x00032E33 File Offset: 0x00031033
	public override string ToString()
	{
		return (this.String_0 != null) ? this.String_0 : string.Empty;
	}

	// Token: 0x06004E31 RID: 20017 RVA: 0x0014B154 File Offset: 0x00149354
	public override bool Equals(object p)
	{
		PhotonPlayer photonPlayer = p as PhotonPlayer;
		return photonPlayer != null && this.GetHashCode() == photonPlayer.GetHashCode();
	}

	// Token: 0x06004E32 RID: 20018 RVA: 0x00032E4A File Offset: 0x0003104A
	public override int GetHashCode()
	{
		return this.ActorId;
	}

	// Token: 0x06004E33 RID: 20019 RVA: 0x00032E52 File Offset: 0x00031052
	internal void method_1(int int_0)
	{
		if (!this.isLocal)
		{
			DebugUtils.LogError(LogCategory.Network, "ERROR You should never change PhotonPlayer IDs!");
			return;
		}
		this.actorID = int_0;
	}

	// Token: 0x06004E34 RID: 20020 RVA: 0x0014B17C File Offset: 0x0014937C
	public void method_2(Hashtable hashtable_0)
	{
		if (hashtable_0 == null)
		{
			return;
		}
		this.customProperties.MergeStringKeys(hashtable_0);
		this.customProperties.StripKeysWithNullValues();
		Hashtable hashtable = hashtable_0.StripToStringKeys();
		PhotonNetwork.networkingPeer.method_3(this.actorID, hashtable, true, 0);
	}

	// Token: 0x06004E35 RID: 20021 RVA: 0x0014B1C0 File Offset: 0x001493C0
	public static PhotonPlayer smethod_0(int int_0)
	{
		foreach (PhotonPlayer photonPlayer in PhotonNetwork.playerList)
		{
			if (photonPlayer.ActorId == int_0)
			{
				return photonPlayer;
			}
		}
		return null;
	}

	// Token: 0x04003A56 RID: 14934
	private int actorID = -1;

	// Token: 0x04003A57 RID: 14935
	private string nameField = string.Empty;

	// Token: 0x04003A58 RID: 14936
	public readonly bool isLocal;
}
