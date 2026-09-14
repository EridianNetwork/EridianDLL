using System;

namespace XsdSettings
{
	// Token: 0x020008F1 RID: 2289
	public class SubPartClassMode
	{
		// Token: 0x06003F1A RID: 16154 RVA: 0x0002A79D File Offset: 0x0002899D
		public override int GetHashCode()
		{
			return SubPartClassMode.smethod_0(this.m_classModeType, this.m_subpartType, this.m_index);
		}

		// Token: 0x06003F1B RID: 16155 RVA: 0x0012B920 File Offset: 0x00129B20
		public static int smethod_0(ClassModeType classModeType_0, ClassModeSubPart classModeSubPart_0, int int_0)
		{
			int num = (int)((ClassModeType)255 & classModeType_0);
			num <<= 8;
			num |= (int)((ClassModeSubPart)255 & classModeSubPart_0);
			num <<= 16;
			return num | (65535 & (int)((short)int_0));
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06003F1C RID: 16156 RVA: 0x0002A7B6 File Offset: 0x000289B6
		// (set) Token: 0x06003F1D RID: 16157 RVA: 0x0002A7BE File Offset: 0x000289BE
		public ClassModeType m_classModeType { get; set; }

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06003F1E RID: 16158 RVA: 0x0002A7C7 File Offset: 0x000289C7
		// (set) Token: 0x06003F1F RID: 16159 RVA: 0x0002A7CF File Offset: 0x000289CF
		public ClassModeSubPart m_subpartType { get; set; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06003F20 RID: 16160 RVA: 0x0002A7D8 File Offset: 0x000289D8
		// (set) Token: 0x06003F21 RID: 16161 RVA: 0x0002A7E0 File Offset: 0x000289E0
		public int m_index { get; set; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06003F22 RID: 16162 RVA: 0x0002A7E9 File Offset: 0x000289E9
		// (set) Token: 0x06003F23 RID: 16163 RVA: 0x0002A7F1 File Offset: 0x000289F1
		public float m_attributeValue { get; set; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06003F24 RID: 16164 RVA: 0x0002A7FA File Offset: 0x000289FA
		// (set) Token: 0x06003F25 RID: 16165 RVA: 0x0002A802 File Offset: 0x00028A02
		public AffectType m_affectType { get; set; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06003F26 RID: 16166 RVA: 0x0002A80B File Offset: 0x00028A0B
		// (set) Token: 0x06003F27 RID: 16167 RVA: 0x0002A813 File Offset: 0x00028A13
		public EffectType m_classModeAttribute { get; set; }

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06003F28 RID: 16168 RVA: 0x0002A81C File Offset: 0x00028A1C
		// (set) Token: 0x06003F29 RID: 16169 RVA: 0x0002A824 File Offset: 0x00028A24
		public string m_partName { get; set; }

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06003F2A RID: 16170 RVA: 0x0002A82D File Offset: 0x00028A2D
		// (set) Token: 0x06003F2B RID: 16171 RVA: 0x0002A835 File Offset: 0x00028A35
		public int m_namePriority { get; set; }

		// Token: 0x04002C60 RID: 11360
		private ClassModeType m_classModeTypeField;

		// Token: 0x04002C61 RID: 11361
		private ClassModeSubPart m_subpartTypeField;

		// Token: 0x04002C62 RID: 11362
		private AffectType m_affectTypeField;

		// Token: 0x04002C63 RID: 11363
		private EffectType m_classModeAttributeField;
	}
}
