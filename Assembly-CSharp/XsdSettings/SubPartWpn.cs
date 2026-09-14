using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008F2 RID: 2290
	public class SubPartWpn
	{
		// Token: 0x06003F2C RID: 16172 RVA: 0x0002A83E File Offset: 0x00028A3E
		public SubPartWpn(WeaponType weaponType_0, WeaponSubPart weaponSubPart_0)
		{
			this.m_Index = 0;
			this.m_weaponType = weaponType_0;
			this.m_partType = weaponSubPart_0;
		}

		// Token: 0x06003F2D RID: 16173 RVA: 0x0012B97C File Offset: 0x00129B7C
		public SubPartWpn(SubPartWpn subPartWpn_0)
		{
			this.m_Index = subPartWpn_0.m_Index;
			this.m_weaponType = subPartWpn_0.m_weaponType;
			this.m_partType = subPartWpn_0.m_partType;
			this.m_Attributes = new BOLAttribute[subPartWpn_0.m_Attributes.Length];
			for (int i = 0; i < subPartWpn_0.m_Attributes.Length; i++)
			{
				this.m_Attributes[i] = new BOLAttribute(subPartWpn_0.m_Attributes[i]);
			}
		}

		// Token: 0x06003F2E RID: 16174 RVA: 0x0012B9F0 File Offset: 0x00129BF0
		public SubPartWpn()
		{
			this.m_Index = 0;
			this.m_weaponType = WeaponType.SMG;
			this.m_partType = WeaponSubPart.ACC;
			this.m_partName = string.Empty;
			this.m_namePriority = 0;
			this.m_redline = string.Empty;
			this.m_redlinePriority = 0;
		}

		// Token: 0x06003F2F RID: 16175 RVA: 0x0002A85B File Offset: 0x00028A5B
		public override int GetHashCode()
		{
			return SubPartWpn.smethod_1(this.m_weaponType, this.m_partType, this.m_Index);
		}

		// Token: 0x06003F30 RID: 16176 RVA: 0x0002A874 File Offset: 0x00028A74
		public static WeaponType smethod_0(int int_0)
		{
			int_0 >>= 24;
			int_0 &= 255;
			return (WeaponType)int_0;
		}

		// Token: 0x06003F31 RID: 16177 RVA: 0x0012B920 File Offset: 0x00129B20
		public static int smethod_1(WeaponType weaponType_0, WeaponSubPart weaponSubPart_0, int int_0)
		{
			int num = (int)((WeaponType)255 & weaponType_0);
			num <<= 8;
			num |= (int)((WeaponSubPart)255 & weaponSubPart_0);
			num <<= 16;
			return num | (65535 & (int)((short)int_0));
		}

		// Token: 0x06003F32 RID: 16178 RVA: 0x0012BA3C File Offset: 0x00129C3C
		public override bool Equals(object obj)
		{
			SubPartWpn subPartWpn = obj as SubPartWpn;
			return subPartWpn != null && subPartWpn.GetHashCode() == this.GetHashCode();
		}

		// Token: 0x06003F33 RID: 16179 RVA: 0x0002A88A File Offset: 0x00028A8A
		public bool method_0(WeaponSubPart weaponSubPart_0)
		{
			if (weaponSubPart_0 != WeaponSubPart.ACC)
			{
				if (weaponSubPart_0 != WeaponSubPart.MATERIAL)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06003F34 RID: 16180 RVA: 0x0002A898 File Offset: 0x00028A98
		public bool method_1(WeaponSubPart weaponSubPart_0)
		{
			if (weaponSubPart_0 != WeaponSubPart.GRIP && weaponSubPart_0 != WeaponSubPart.BARREL && weaponSubPart_0 != WeaponSubPart.BODY)
			{
				if (weaponSubPart_0 != WeaponSubPart.MAG)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06003F35 RID: 16181 RVA: 0x0002A8AF File Offset: 0x00028AAF
		// (set) Token: 0x06003F36 RID: 16182 RVA: 0x0002A8B7 File Offset: 0x00028AB7
		public int m_Index { get; set; }

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06003F37 RID: 16183 RVA: 0x0002A8C0 File Offset: 0x00028AC0
		// (set) Token: 0x06003F38 RID: 16184 RVA: 0x0002A8C8 File Offset: 0x00028AC8
		public WeaponType m_weaponType { get; set; }

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06003F39 RID: 16185 RVA: 0x0002A8D1 File Offset: 0x00028AD1
		// (set) Token: 0x06003F3A RID: 16186 RVA: 0x0002A8D9 File Offset: 0x00028AD9
		public WeaponSubPart m_partType { get; set; }

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06003F3B RID: 16187 RVA: 0x0002A8E2 File Offset: 0x00028AE2
		// (set) Token: 0x06003F3C RID: 16188 RVA: 0x0002A8EA File Offset: 0x00028AEA
		public BuildingPart m_BuildingPart { get; set; }

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06003F3D RID: 16189 RVA: 0x0002A8F3 File Offset: 0x00028AF3
		// (set) Token: 0x06003F3E RID: 16190 RVA: 0x0002A8FB File Offset: 0x00028AFB
		[DefaultValue("")]
		public string m_partName { get; set; }

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06003F3F RID: 16191 RVA: 0x0002A904 File Offset: 0x00028B04
		// (set) Token: 0x06003F40 RID: 16192 RVA: 0x0002A90C File Offset: 0x00028B0C
		[DefaultValue(0)]
		public int m_namePriority { get; set; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06003F41 RID: 16193 RVA: 0x0002A915 File Offset: 0x00028B15
		// (set) Token: 0x06003F42 RID: 16194 RVA: 0x0002A91D File Offset: 0x00028B1D
		[DefaultValue("")]
		public string m_redline { get; set; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06003F43 RID: 16195 RVA: 0x0002A926 File Offset: 0x00028B26
		// (set) Token: 0x06003F44 RID: 16196 RVA: 0x0002A92E File Offset: 0x00028B2E
		[DefaultValue(0)]
		public int m_redlinePriority { get; set; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06003F45 RID: 16197 RVA: 0x0002A937 File Offset: 0x00028B37
		// (set) Token: 0x06003F46 RID: 16198 RVA: 0x0002A93F File Offset: 0x00028B3F
		[XmlArrayItem("m_attribute", IsNullable = false)]
		public BOLAttribute[] m_Attributes { get; set; }

		// Token: 0x04002C6C RID: 11372
		private BuildingPart m_BuildingPartField;

		// Token: 0x04002C6D RID: 11373
		private BOLAttribute[] m_AttributesField;
	}
}
