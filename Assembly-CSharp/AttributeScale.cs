using System;
using XsdSettings;

// Token: 0x020008FE RID: 2302
public class AttributeScale
{
	// Token: 0x06003F7A RID: 16250 RVA: 0x0002AB1B File Offset: 0x00028D1B
	public AttributeScale(AttributeType attributeType_0, float float_0, AttributeValueType attributeValueType_0, float float_1)
	{
		this.m_attribute = attributeType_0;
		this.m_scale = float_0;
		this.m_valueType = attributeValueType_0;
		this.m_basicValue = float_1;
	}

	// Token: 0x04002C9F RID: 11423
	public AttributeType m_attribute;

	// Token: 0x04002CA0 RID: 11424
	public float m_scale;

	// Token: 0x04002CA1 RID: 11425
	public float m_basicValue;

	// Token: 0x04002CA2 RID: 11426
	public AttributeValueType m_valueType;
}
