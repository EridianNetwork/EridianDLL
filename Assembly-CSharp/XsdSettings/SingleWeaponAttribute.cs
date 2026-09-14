using System;

namespace XsdSettings
{
	// Token: 0x02000A5E RID: 2654
	public class SingleWeaponAttribute
	{
		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06004839 RID: 18489 RVA: 0x0002F50F File Offset: 0x0002D70F
		// (set) Token: 0x0600483A RID: 18490 RVA: 0x0002F517 File Offset: 0x0002D717
		public AttributeType m_attributeType { get; set; }

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x0600483B RID: 18491 RVA: 0x0002F520 File Offset: 0x0002D720
		// (set) Token: 0x0600483C RID: 18492 RVA: 0x0002F528 File Offset: 0x0002D728
		public AffectType m_affectType { get; set; }

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x0600483D RID: 18493 RVA: 0x0002F531 File Offset: 0x0002D731
		// (set) Token: 0x0600483E RID: 18494 RVA: 0x0002F539 File Offset: 0x0002D739
		public float m_value { get; set; }

		// Token: 0x0400346E RID: 13422
		private AttributeType m_attributeTypeField;

		// Token: 0x0400346F RID: 13423
		private AffectType m_affectTypeField;
	}
}
