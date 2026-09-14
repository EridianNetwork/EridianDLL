using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Core;
using XsdSettings;

// Token: 0x02000138 RID: 312
[Serializable]
public class AvatarDNA : ICloneable
{
	// Token: 0x06000724 RID: 1828 RVA: 0x00007B41 File Offset: 0x00005D41
	public AvatarDNA()
	{
		this.method_0(8);
	}

	// Token: 0x06000725 RID: 1829 RVA: 0x00007B50 File Offset: 0x00005D50
	public void method_0(int int_0)
	{
		this.m_buildingUnit = new BuildingUnit(int_0);
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x00055C2C File Offset: 0x00053E2C
	public object Clone()
	{
		AvatarDNA avatarDNA = (AvatarDNA)base.MemberwiseClone();
		avatarDNA.m_buildingUnit = (BuildingUnit)this.m_buildingUnit.Clone();
		return avatarDNA;
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x00055C5C File Offset: 0x00053E5C
	public override bool Equals(object obj)
	{
		AvatarDNA avatarDNA = obj as AvatarDNA;
		return avatarDNA != null && this.m_type == avatarDNA.m_type && this.m_buildingUnit.Equals(avatarDNA.m_buildingUnit);
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x00007B5E File Offset: 0x00005D5E
	public override int GetHashCode()
	{
		return this.m_type.GetHashCode() ^ this.m_buildingUnit.GetHashCode();
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x00007B7C File Offset: 0x00005D7C
	public byte method_1(byte byte_0)
	{
		return this.m_buildingUnit.mFBXs[(int)byte_0];
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x00007B8F File Offset: 0x00005D8F
	public void method_2(byte byte_0, byte byte_1)
	{
		this.m_buildingUnit.mFBXs[(int)byte_0] = byte_1;
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x00007BA3 File Offset: 0x00005DA3
	public byte method_3(byte byte_0)
	{
		return this.m_buildingUnit.mMats[(int)byte_0];
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x00007BB6 File Offset: 0x00005DB6
	public void method_4(byte byte_0, byte byte_1)
	{
		this.m_buildingUnit.mMats[(int)byte_0] = byte_1;
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x00007BCA File Offset: 0x00005DCA
	public AvatarType method_5()
	{
		return this.m_type;
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x00055C98 File Offset: 0x00053E98
	public void method_6(AvatarType avatarType_0)
	{
		switch (avatarType_0)
		{
		case AvatarType.SIREN:
			this.m_buildingUnit.bkID = 1242413768U;
			this.method_7(0, 0, 0, 0, 0, 0, 0);
			break;
		case AvatarType.SOLDIER:
			this.m_buildingUnit.bkID = 1267549099U;
			this.method_7(1, 0, 0, 0, 0, 0, 0);
			break;
		case AvatarType.BERSERKER:
			this.m_buildingUnit.bkID = 3556519174U;
			this.method_7(2, 0, 0, 0, 0, 0, 0);
			break;
		case AvatarType.HUNTER:
			this.m_buildingUnit.bkID = 3169502637U;
			this.method_7(3, 0, 0, 0, 0, 0, 0);
			break;
		}
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x00007BD2 File Offset: 0x00005DD2
	public void method_7(byte byte_0, byte byte_1, byte byte_2, byte byte_3, byte byte_4 = 0, byte byte_5 = 0, byte byte_6 = 0)
	{
		this.m_type = (AvatarType)byte_0;
		this.m_buildingUnit.mFBXs[0] = byte_1;
		this.m_buildingUnit.mFBXs[1] = byte_2;
		this.m_buildingUnit.mFBXs[2] = byte_3;
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x00055D3C File Offset: 0x00053F3C
	public void method_8(AvatarType avatarType_0, string string_0, string string_1, uint uint_0)
	{
		this.m_type = avatarType_0;
		if (this.m_buildingUnit != null)
		{
			this.m_buildingUnit.bkID = uint_0;
			this.m_buildingUnit.mFBXs.Clear();
			string[] array = string_0.Split(new char[] { ',' });
			for (int i = 0; i < array.Length; i++)
			{
				this.m_buildingUnit.mFBXs.Add(Convert.ToByte(array[i]));
			}
			this.m_buildingUnit.mMats.Clear();
			array = string_1.Split(new char[] { ',' });
			for (int j = 0; j < array.Length; j++)
			{
				this.m_buildingUnit.mMats.Add(Convert.ToByte(array[j]));
			}
		}
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x00055DF8 File Offset: 0x00053FF8
	public int method_9(string string_0, AvatarSubPart avatarSubPart_0)
	{
		string[] array = string_0.Split(new char[] { ',' });
		for (int i = 0; i < array.Length; i++)
		{
			if (avatarSubPart_0 == (AvatarSubPart)i)
			{
				return Convert.ToInt32(array[i]);
			}
		}
		DebugUtils.LogWarning(LogCategory.Gamelogic, "avaparts doesn't looks right");
		return 0;
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x00055DF8 File Offset: 0x00053FF8
	public int method_10(string string_0, AvatarSubPart avatarSubPart_0)
	{
		string[] array = string_0.Split(new char[] { ',' });
		for (int i = 0; i < array.Length; i++)
		{
			if (avatarSubPart_0 == (AvatarSubPart)i)
			{
				return Convert.ToInt32(array[i]);
			}
		}
		DebugUtils.LogWarning(LogCategory.Gamelogic, "avaparts doesn't looks right");
		return 0;
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x00007C12 File Offset: 0x00005E12
	public override string ToString()
	{
		return string.Format("{0} - {1} - {2}", this.m_type, this.m_buildingUnit.mFBXs.Count, this.m_buildingUnit.bkID);
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x00055E40 File Offset: 0x00054040
	public object[] method_11()
	{
		object[] array = new object[4];
		array[0] = Convert.ToInt32(this.m_type);
		array[1] = this.m_buildingUnit.bkID.ToString();
		array[2] = string.Join(",", this.m_buildingUnit.mFBXs.Select<byte, string>(new Func<byte, string>(AvatarDNA.smethod_0)).ToArray<string>());
		array[3] = string.Join(",", this.m_buildingUnit.mMats.Select<byte, string>(new Func<byte, string>(AvatarDNA.smethod_1)).ToArray<string>());
		return array;
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x00007C4E File Offset: 0x00005E4E
	[CompilerGenerated]
	private static string smethod_0(byte byte_0)
	{
		return byte_0.ToString();
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x00007C4E File Offset: 0x00005E4E
	[CompilerGenerated]
	private static string smethod_1(byte byte_0)
	{
		return byte_0.ToString();
	}

	// Token: 0x04000666 RID: 1638
	public AvatarType m_type;

	// Token: 0x04000667 RID: 1639
	public BuildingUnit m_buildingUnit;
}
