using System;
using System.Collections;
using ExitGames.Client.Photon;

// Token: 0x02000B37 RID: 2871
public class RoomInfo
{
	// Token: 0x06004E51 RID: 20049 RVA: 0x00032F63 File Offset: 0x00031163
	protected internal RoomInfo(string string_0, Hashtable hashtable_0)
	{
		this.ApplyPropertiesUpdate(hashtable_0);
		this.nameField = string_0;
	}

	// Token: 0x170007F8 RID: 2040
	// (get) Token: 0x06004E52 RID: 20050 RVA: 0x00032F92 File Offset: 0x00031192
	// (set) Token: 0x06004E53 RID: 20051 RVA: 0x00032F9A File Offset: 0x0003119A
	public bool removedFromList { get; internal set; }

	// Token: 0x170007F9 RID: 2041
	// (get) Token: 0x06004E54 RID: 20052 RVA: 0x00032FA3 File Offset: 0x000311A3
	public Hashtable Hashtable_0
	{
		get
		{
			return this.customPropertiesField;
		}
	}

	// Token: 0x170007FA RID: 2042
	// (get) Token: 0x06004E55 RID: 20053 RVA: 0x00032F21 File Offset: 0x00031121
	public string String_0
	{
		get
		{
			return this.nameField;
		}
	}

	// Token: 0x170007FB RID: 2043
	// (get) Token: 0x06004E56 RID: 20054 RVA: 0x00032FAB File Offset: 0x000311AB
	// (set) Token: 0x06004E57 RID: 20055 RVA: 0x00032FB3 File Offset: 0x000311B3
	public int playerCount { get; private set; }

	// Token: 0x170007FC RID: 2044
	// (get) Token: 0x06004E58 RID: 20056 RVA: 0x00032FBC File Offset: 0x000311BC
	// (set) Token: 0x06004E59 RID: 20057 RVA: 0x00032FC4 File Offset: 0x000311C4
	public bool isLocalClientInside { get; set; }

	// Token: 0x170007FD RID: 2045
	// (get) Token: 0x06004E5A RID: 20058 RVA: 0x00032F32 File Offset: 0x00031132
	public byte Byte_0
	{
		get
		{
			return this.maxPlayersField;
		}
	}

	// Token: 0x170007FE RID: 2046
	// (get) Token: 0x06004E5B RID: 20059 RVA: 0x00032F3A File Offset: 0x0003113A
	public bool Boolean_0
	{
		get
		{
			return this.openField;
		}
	}

	// Token: 0x170007FF RID: 2047
	// (get) Token: 0x06004E5C RID: 20060 RVA: 0x00032F42 File Offset: 0x00031142
	public bool Boolean_1
	{
		get
		{
			return this.visibleField;
		}
	}

	// Token: 0x06004E5D RID: 20061 RVA: 0x0014C040 File Offset: 0x0014A240
	public override bool Equals(object p)
	{
		Room room = p as Room;
		return room != null && this.nameField.Equals(room.nameField);
	}

	// Token: 0x06004E5E RID: 20062 RVA: 0x00032FCD File Offset: 0x000311CD
	public override int GetHashCode()
	{
		return this.nameField.GetHashCode();
	}

	// Token: 0x06004E5F RID: 20063 RVA: 0x0014C06C File Offset: 0x0014A26C
	public override string ToString()
	{
		return string.Format("Room: '{0}' visible: {1} open: {2} max: {3} count: {4}\ncustomProps: {5}", new object[]
		{
			this.nameField,
			this.visibleField,
			this.openField,
			this.maxPlayersField,
			this.playerCount,
			SupportClass.DictionaryToString(this.customPropertiesField)
		});
	}

	// Token: 0x06004E60 RID: 20064 RVA: 0x0014C0D8 File Offset: 0x0014A2D8
	protected internal void ApplyPropertiesUpdate(Hashtable hashtable_0)
	{
		if (hashtable_0 != null && hashtable_0.Count != 0 && !this.customPropertiesField.Equals(hashtable_0))
		{
			if (hashtable_0.ContainsKey((byte)251))
			{
				this.removedFromList = (bool)hashtable_0[(byte)251];
				if (this.removedFromList)
				{
					return;
				}
			}
			if (hashtable_0.ContainsKey(byte.MaxValue))
			{
				this.maxPlayersField = (byte)hashtable_0[byte.MaxValue];
			}
			if (hashtable_0.ContainsKey((byte)253))
			{
				this.openField = (bool)hashtable_0[(byte)253];
			}
			if (hashtable_0.ContainsKey((byte)254))
			{
				this.visibleField = (bool)hashtable_0[(byte)254];
			}
			if (hashtable_0.ContainsKey((byte)252))
			{
				this.playerCount = (int)((byte)hashtable_0[(byte)252]);
			}
			if (hashtable_0.ContainsKey((byte)249))
			{
				this.autoCleanUpField = (bool)hashtable_0[(byte)249];
			}
			this.customPropertiesField.MergeStringKeys(hashtable_0);
			return;
		}
	}

	// Token: 0x04003A69 RID: 14953
	private Hashtable customPropertiesField = new Hashtable();

	// Token: 0x04003A6A RID: 14954
	protected byte maxPlayersField;

	// Token: 0x04003A6B RID: 14955
	protected bool openField = true;

	// Token: 0x04003A6C RID: 14956
	protected bool visibleField = true;

	// Token: 0x04003A6D RID: 14957
	protected bool autoCleanUpField;

	// Token: 0x04003A6E RID: 14958
	protected string nameField;
}
