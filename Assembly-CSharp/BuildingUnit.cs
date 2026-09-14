using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x02000151 RID: 337
[Serializable]
public class BuildingUnit : ICloneable
{
	// Token: 0x060007C2 RID: 1986 RVA: 0x00003197 File Offset: 0x00001397
	private BuildingUnit()
	{
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x000586F8 File Offset: 0x000568F8
	public BuildingUnit(int int_0)
	{
		this.bkID = 0U;
		this.mFBXs = new List<byte>();
		this.mMats = new List<byte>();
		for (int i = 0; i < int_0; i++)
		{
			this.mFBXs.Add(0);
			this.mMats.Add(0);
		}
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x0005874C File Offset: 0x0005694C
	public BuildingUnit(BuildingPart[] buildingPart_0)
	{
		this.bkID = buildingPart_0[0].bkID;
		this.mFBXs = new List<byte>();
		this.mMats = new List<byte>();
		for (int i = 0; i < buildingPart_0.Length; i++)
		{
			for (int j = 0; j < buildingPart_0.Length; j++)
			{
				if ((int)buildingPart_0[j].mPart == i)
				{
					this.mFBXs.Add(buildingPart_0[j].mFBX);
					this.mMats.Add(buildingPart_0[j].mMat);
				}
			}
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x000587D0 File Offset: 0x000569D0
	public void method_0(BuildingPart buildingPart_0)
	{
		if (buildingPart_0.bkID == this.bkID && (int)buildingPart_0.mPart < this.mFBXs.Count)
		{
			this.mFBXs[(int)buildingPart_0.mPart] = buildingPart_0.mFBX;
			this.mMats[(int)buildingPart_0.mPart] = buildingPart_0.mMat;
		}
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x00008145 File Offset: 0x00006345
	public BuildingPart method_1(int int_0)
	{
		return new BuildingPart(this.bkID, (byte)int_0, this.mFBXs[int_0], this.mMats[int_0]);
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x0005882C File Offset: 0x00056A2C
	public BuildingPart[] method_2()
	{
		BuildingPart[] array = new BuildingPart[this.mFBXs.Count];
		for (int i = 0; i < this.mFBXs.Count; i++)
		{
			array[i] = new BuildingPart(this.bkID, (byte)i, this.mFBXs[i], this.mMats[i]);
		}
		return array;
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x0000816C File Offset: 0x0000636C
	public int method_3()
	{
		return this.mFBXs.Count;
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x0005888C File Offset: 0x00056A8C
	public object Clone()
	{
		return (BuildingUnit)base.MemberwiseClone();
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x000588A8 File Offset: 0x00056AA8
	public override bool Equals(object obj)
	{
		BuildingUnit buildingUnit = obj as BuildingUnit;
		return buildingUnit != null && this.bkID == buildingUnit.bkID && this.mFBXs == buildingUnit.mFBXs && this.mMats == buildingUnit.mMats;
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x000588EC File Offset: 0x00056AEC
	public override int GetHashCode()
	{
		return this.bkID.GetHashCode() ^ this.mFBXs.GetHashCode() ^ this.mMats.GetHashCode();
	}

	// Token: 0x040006D1 RID: 1745
	public uint bkID;

	// Token: 0x040006D2 RID: 1746
	public List<byte> mFBXs;

	// Token: 0x040006D3 RID: 1747
	public List<byte> mMats;
}
