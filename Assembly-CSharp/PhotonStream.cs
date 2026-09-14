using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000B2D RID: 2861
public class PhotonStream
{
	// Token: 0x06004D9D RID: 19869 RVA: 0x0003266D File Offset: 0x0003086D
	public PhotonStream(bool bool_0, object[] object_0)
	{
		this.write = bool_0;
		if (object_0 == null)
		{
			this.data = new List<object>();
		}
		else
		{
			this.data = new List<object>(object_0);
		}
	}

	// Token: 0x170007CD RID: 1997
	// (get) Token: 0x06004D9E RID: 19870 RVA: 0x00032698 File Offset: 0x00030898
	public bool IsWriting
	{
		get
		{
			return this.write;
		}
	}

	// Token: 0x170007CE RID: 1998
	// (get) Token: 0x06004D9F RID: 19871 RVA: 0x000326A0 File Offset: 0x000308A0
	public bool IsReading
	{
		get
		{
			return !this.write;
		}
	}

	// Token: 0x170007CF RID: 1999
	// (get) Token: 0x06004DA0 RID: 19872 RVA: 0x000326AB File Offset: 0x000308AB
	public int Count
	{
		get
		{
			return this.data.Count;
		}
	}

	// Token: 0x06004DA1 RID: 19873 RVA: 0x0014985C File Offset: 0x00147A5C
	public object ReceiveNext()
	{
		if (this.write)
		{
			DebugUtils.LogError(LogCategory.Network, "Error: you cannot read this stream that you are writing!");
			return null;
		}
		object obj = this.data[(int)this.currentItem];
		this.currentItem += 1;
		return obj;
	}

	// Token: 0x06004DA2 RID: 19874 RVA: 0x000326B8 File Offset: 0x000308B8
	public void SendNext(object object_0)
	{
		if (!this.write)
		{
			DebugUtils.LogError(LogCategory.Network, "Error: you cannot write/send to this stream that you are reading!");
			return;
		}
		this.data.Add(object_0);
	}

	// Token: 0x06004DA3 RID: 19875 RVA: 0x000326DB File Offset: 0x000308DB
	public void ClearStream()
	{
		this.data.Clear();
	}

	// Token: 0x06004DA4 RID: 19876 RVA: 0x000326E8 File Offset: 0x000308E8
	public bool IsStreamEmpty()
	{
		return this.data.Count == 0;
	}

	// Token: 0x06004DA5 RID: 19877 RVA: 0x000326F8 File Offset: 0x000308F8
	public object[] ToArray()
	{
		return this.data.ToArray();
	}

	// Token: 0x06004DA6 RID: 19878 RVA: 0x001498A4 File Offset: 0x00147AA4
	public void Serialize(ref bool bool_0)
	{
		if (this.write)
		{
			this.data.Add(bool_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			bool_0 = (bool)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DA7 RID: 19879 RVA: 0x00149908 File Offset: 0x00147B08
	public void Serialize(ref int int_0)
	{
		if (this.write)
		{
			this.data.Add(int_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			int_0 = (int)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DA8 RID: 19880 RVA: 0x0014996C File Offset: 0x00147B6C
	public void Serialize(ref string string_0)
	{
		if (this.write)
		{
			this.data.Add(string_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			string_0 = (string)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DA9 RID: 19881 RVA: 0x001499CC File Offset: 0x00147BCC
	public void Serialize(ref char char_0)
	{
		if (this.write)
		{
			this.data.Add(char_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			char_0 = (char)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DAA RID: 19882 RVA: 0x00149A30 File Offset: 0x00147C30
	public void Serialize(ref short short_0)
	{
		if (this.write)
		{
			this.data.Add(short_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			short_0 = (short)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DAB RID: 19883 RVA: 0x00149A94 File Offset: 0x00147C94
	public void Serialize(ref float float_0)
	{
		if (this.write)
		{
			this.data.Add(float_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			float_0 = (float)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DAC RID: 19884 RVA: 0x00149AF8 File Offset: 0x00147CF8
	public void Serialize(ref PhotonPlayer photonPlayer_0)
	{
		if (this.write)
		{
			this.data.Add(photonPlayer_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			photonPlayer_0 = (PhotonPlayer)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DAD RID: 19885 RVA: 0x00149B58 File Offset: 0x00147D58
	public void Serialize(ref Vector3 vector3_0)
	{
		if (this.write)
		{
			this.data.Add(vector3_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			vector3_0 = (Vector3)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DAE RID: 19886 RVA: 0x00149BC4 File Offset: 0x00147DC4
	public void Serialize(ref Vector2 vector2_0)
	{
		if (this.write)
		{
			this.data.Add(vector2_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			vector2_0 = (Vector2)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06004DAF RID: 19887 RVA: 0x00149C30 File Offset: 0x00147E30
	public void Serialize(ref Quaternion quaternion_0)
	{
		if (this.write)
		{
			this.data.Add(quaternion_0);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			quaternion_0 = (Quaternion)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x04003A2C RID: 14892
	private bool write;

	// Token: 0x04003A2D RID: 14893
	internal List<object> data;

	// Token: 0x04003A2E RID: 14894
	private byte currentItem;
}
