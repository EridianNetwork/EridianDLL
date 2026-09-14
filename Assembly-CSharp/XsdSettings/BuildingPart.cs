using System;
using UnityEngine;

namespace XsdSettings
{
	// Token: 0x02000152 RID: 338
	public class BuildingPart : ICloneable
	{
		// Token: 0x060007CC RID: 1996 RVA: 0x00008179 File Offset: 0x00006379
		public BuildingPart(uint uint_0, byte byte_0, byte byte_1, byte byte_2)
		{
			this.bkID = uint_0;
			this.mPart = byte_0;
			this.mFBX = byte_1;
			this.mMat = byte_2;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00058920 File Offset: 0x00056B20
		public BuildingPart(SubPartWpn subPartWpn_0)
		{
			if (subPartWpn_0 != null)
			{
				if (subPartWpn_0.m_BuildingPart.bkID != 0U)
				{
					this.bkID = subPartWpn_0.m_BuildingPart.bkID;
					this.mPart = subPartWpn_0.m_BuildingPart.mPart;
					this.mFBX = subPartWpn_0.m_BuildingPart.mFBX;
					this.mMat = subPartWpn_0.m_BuildingPart.mMat;
				}
				else
				{
					this.bkID = BuildingKitManager.smethod_1("WPN", Enum.GetName(typeof(WeaponType), subPartWpn_0.m_weaponType));
					BuildingKit buildingKit = BuildingKitManager.smethod_0(this.bkID);
					this.mPart = (byte)Mathf.Clamp((int)subPartWpn_0.m_partType, 0, buildingKit.method_5() - 1);
					this.mFBX = (byte)Mathf.Clamp(subPartWpn_0.m_Index, 0, buildingKit.method_7((int)subPartWpn_0.m_partType) - 1);
					this.mMat = 0;
				}
			}
			else
			{
				this.bkID = 0U;
				this.mPart = byte.MaxValue;
				this.mFBX = byte.MaxValue;
				this.mMat = byte.MaxValue;
			}
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0000819E File Offset: 0x0000639E
		public BuildingPart()
		{
			this.bkID = 0U;
			this.mPart = 0;
			this.mFBX = 0;
			this.mMat = 0;
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00058A34 File Offset: 0x00056C34
		public object Clone()
		{
			return (BuildingPart)base.MemberwiseClone();
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00058A50 File Offset: 0x00056C50
		public override bool Equals(object obj)
		{
			BuildingPart buildingPart = obj as BuildingPart;
			return buildingPart != null && this.bkID == buildingPart.bkID && this.mPart == buildingPart.mPart && this.mFBX == buildingPart.mFBX && this.mMat == buildingPart.mMat;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x00058AA4 File Offset: 0x00056CA4
		public override int GetHashCode()
		{
			return this.bkID.GetHashCode() ^ this.mPart.GetHashCode() ^ this.mFBX.GetHashCode() ^ this.mMat.GetHashCode();
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x000081C2 File Offset: 0x000063C2
		// (set) Token: 0x060007D3 RID: 2003 RVA: 0x000081CA File Offset: 0x000063CA
		public uint bkID { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x000081D3 File Offset: 0x000063D3
		// (set) Token: 0x060007D5 RID: 2005 RVA: 0x000081DB File Offset: 0x000063DB
		public byte mPart { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x000081E4 File Offset: 0x000063E4
		// (set) Token: 0x060007D7 RID: 2007 RVA: 0x000081EC File Offset: 0x000063EC
		public byte mFBX { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x000081F5 File Offset: 0x000063F5
		// (set) Token: 0x060007D9 RID: 2009 RVA: 0x000081FD File Offset: 0x000063FD
		public byte mMat { get; set; }

		// Token: 0x040006D4 RID: 1748
		private const byte mEmpty = 255;
	}
}
