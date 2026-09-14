using System;

namespace XsdSettings
{
	// Token: 0x020008F0 RID: 2288
	public class SubPartShield
	{
		// Token: 0x06003F07 RID: 16135 RVA: 0x0002A6F2 File Offset: 0x000288F2
		public override int GetHashCode()
		{
			return SubPartShield.smethod_0(this.m_subpartType, this.m_index);
		}

		// Token: 0x06003F08 RID: 16136 RVA: 0x0012B954 File Offset: 0x00129B54
		public static int smethod_0(ShieldSubPart shieldSubPart_0, int int_0)
		{
			int num = (int)((ShieldSubPart)255 & shieldSubPart_0);
			num <<= 16;
			return num | (65535 & (int)((short)int_0));
		}

		// Token: 0x06003F09 RID: 16137 RVA: 0x0002A705 File Offset: 0x00028905
		public bool method_0(ShieldSubPart shieldSubPart_0)
		{
			if (shieldSubPart_0 != ShieldSubPart.Battery && shieldSubPart_0 != ShieldSubPart.Body)
			{
				if (shieldSubPart_0 != ShieldSubPart.Capacitor)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06003F0A RID: 16138 RVA: 0x0002A717 File Offset: 0x00028917
		public bool method_1(ShieldSubPart shieldSubPart_0)
		{
			if (shieldSubPart_0 != ShieldSubPart.Accessory)
			{
				if (shieldSubPart_0 != ShieldSubPart.Material)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06003F0B RID: 16139 RVA: 0x0002A726 File Offset: 0x00028926
		// (set) Token: 0x06003F0C RID: 16140 RVA: 0x0002A72E File Offset: 0x0002892E
		public ShieldSubPart m_subpartType { get; set; }

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06003F0D RID: 16141 RVA: 0x0002A737 File Offset: 0x00028937
		// (set) Token: 0x06003F0E RID: 16142 RVA: 0x0002A73F File Offset: 0x0002893F
		public int m_index { get; set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06003F0F RID: 16143 RVA: 0x0002A748 File Offset: 0x00028948
		// (set) Token: 0x06003F10 RID: 16144 RVA: 0x0002A750 File Offset: 0x00028950
		public string m_partName { get; set; }

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06003F11 RID: 16145 RVA: 0x0002A759 File Offset: 0x00028959
		// (set) Token: 0x06003F12 RID: 16146 RVA: 0x0002A761 File Offset: 0x00028961
		public ShieldAttributeType m_shieldAttribute { get; set; }

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06003F13 RID: 16147 RVA: 0x0002A76A File Offset: 0x0002896A
		// (set) Token: 0x06003F14 RID: 16148 RVA: 0x0002A772 File Offset: 0x00028972
		public AffectType m_affectType { get; set; }

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06003F15 RID: 16149 RVA: 0x0002A77B File Offset: 0x0002897B
		// (set) Token: 0x06003F16 RID: 16150 RVA: 0x0002A783 File Offset: 0x00028983
		public float m_attributeValue { get; set; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06003F17 RID: 16151 RVA: 0x0002A78C File Offset: 0x0002898C
		// (set) Token: 0x06003F18 RID: 16152 RVA: 0x0002A794 File Offset: 0x00028994
		public int m_namePriority { get; set; }

		// Token: 0x04002C56 RID: 11350
		private ShieldSubPart m_subpartTypeField;

		// Token: 0x04002C57 RID: 11351
		private ShieldAttributeType m_shieldAttributeField;

		// Token: 0x04002C58 RID: 11352
		private AffectType m_affectTypeField;
	}
}
