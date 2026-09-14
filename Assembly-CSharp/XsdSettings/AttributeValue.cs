using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008C7 RID: 2247
	[XmlInclude(typeof(IntAttributeValue))]
	[XmlInclude(typeof(FloatAttributeValue))]
	public class AttributeValue : ICloneable
	{
		// Token: 0x06003E26 RID: 15910 RVA: 0x00029FD1 File Offset: 0x000281D1
		public AttributeValue()
		{
			this.m_type = AttributeValueType.AttributeValue;
			this.m_affectType = AffectType.Scale;
		}

		// Token: 0x06003E27 RID: 15911 RVA: 0x00128804 File Offset: 0x00126A04
		public object Clone()
		{
			return (AttributeValue)base.MemberwiseClone();
		}

		// Token: 0x06003E28 RID: 15912 RVA: 0x00003C2E File Offset: 0x00001E2E
		public virtual void vmethod_0(float float_0, float float_1, float float_2)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003E29 RID: 15913 RVA: 0x00003C2E File Offset: 0x00001E2E
		public virtual void vmethod_1(List<AttributeValue> list_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003E2A RID: 15914 RVA: 0x00003C2E File Offset: 0x00001E2E
		public virtual void vmethod_2(AttributeValue attributeValue_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003E2B RID: 15915 RVA: 0x00029FE7 File Offset: 0x000281E7
		public override string ToString()
		{
			return this.m_type.ToString();
		}

		// Token: 0x06003E2C RID: 15916 RVA: 0x00003C2E File Offset: 0x00001E2E
		public virtual void vmethod_3(float float_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003E2D RID: 15917 RVA: 0x00003C2E File Offset: 0x00001E2E
		public virtual float vmethod_4()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06003E2E RID: 15918 RVA: 0x00029FF9 File Offset: 0x000281F9
		// (set) Token: 0x06003E2F RID: 15919 RVA: 0x0002A001 File Offset: 0x00028201
		public AttributeValueType m_type { get; set; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06003E30 RID: 15920 RVA: 0x0002A00A File Offset: 0x0002820A
		// (set) Token: 0x06003E31 RID: 15921 RVA: 0x0002A012 File Offset: 0x00028212
		public AffectType m_affectType { get; set; }
	}
}
