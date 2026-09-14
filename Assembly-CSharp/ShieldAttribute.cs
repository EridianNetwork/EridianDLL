using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x020008EA RID: 2282
public class ShieldAttribute
{
	// Token: 0x06003ED3 RID: 16083 RVA: 0x0012B44C File Offset: 0x0012964C
	public ShieldAttribute()
	{
		this.m_shieldAttributes.Clear();
		foreach (object obj in Enum.GetValues(typeof(ShieldAttributeType)))
		{
			ShieldAttributeType shieldAttributeType = (ShieldAttributeType)((int)obj);
			this.m_shieldAttributes.Add(new ShieldAttributeConfig(shieldAttributeType));
		}
	}

	// Token: 0x06003ED4 RID: 16084 RVA: 0x0002A545 File Offset: 0x00028745
	public float method_0(ShieldAttributeType shieldAttributeType_0)
	{
		return this.m_shieldAttributes[(int)shieldAttributeType_0].m_attrValue;
	}

	// Token: 0x04002C37 RID: 11319
	public List<ShieldAttributeConfig> m_shieldAttributes = new List<ShieldAttributeConfig>();
}
