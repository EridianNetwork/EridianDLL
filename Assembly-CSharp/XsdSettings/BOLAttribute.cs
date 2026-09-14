using System;

namespace XsdSettings
{
	// Token: 0x020008C8 RID: 2248
	public class BOLAttribute
	{
		// Token: 0x06003E32 RID: 15922 RVA: 0x0002A01B File Offset: 0x0002821B
		public BOLAttribute(AttributeType attributeType_0)
		{
			this.m_attributeType = attributeType_0;
			this.m_attributeValue = AttributeStore.attributeStore.method_3(attributeType_0);
		}

		// Token: 0x06003E33 RID: 15923 RVA: 0x0002A03B File Offset: 0x0002823B
		public BOLAttribute(BOLAttribute bolattribute_0)
		{
			this.m_attributeType = bolattribute_0.m_attributeType;
			this.m_attributeValue = (AttributeValue)bolattribute_0.m_attributeValue.Clone();
		}

		// Token: 0x06003E34 RID: 15924 RVA: 0x0002A065 File Offset: 0x00028265
		public BOLAttribute()
		{
			this.m_attributeType = AttributeType.None;
		}

		// Token: 0x06003E35 RID: 15925 RVA: 0x00128820 File Offset: 0x00126A20
		public virtual void vmethod_0()
		{
			if (this.m_attributeValue != null && AttributeStore.attributeStore.method_2(this.m_attributeType) != this.m_attributeValue.m_type)
			{
				this.m_attributeValue = AttributeStore.attributeStore.method_4(this.m_attributeType, this.m_attributeValue);
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06003E36 RID: 15926 RVA: 0x0002A074 File Offset: 0x00028274
		// (set) Token: 0x06003E37 RID: 15927 RVA: 0x0002A07C File Offset: 0x0002827C
		public AttributeType m_attributeType { get; set; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06003E38 RID: 15928 RVA: 0x0002A085 File Offset: 0x00028285
		// (set) Token: 0x06003E39 RID: 15929 RVA: 0x0002A08D File Offset: 0x0002828D
		public AttributeValue m_attributeValue { get; set; }

		// Token: 0x04002BC1 RID: 11201
		private AttributeValue m_attributeValueField;
	}
}
