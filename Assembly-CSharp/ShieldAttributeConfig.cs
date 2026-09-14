using System;
using XsdSettings;

// Token: 0x020008E9 RID: 2281
public class ShieldAttributeConfig
{
	// Token: 0x06003ED1 RID: 16081 RVA: 0x0012B3D4 File Offset: 0x001295D4
	public ShieldAttributeConfig(ShieldAttributeType shieldAttributeType_0)
	{
		this.m_attrType = shieldAttributeType_0;
		switch (this.m_attrType)
		{
		case ShieldAttributeType.Capacity:
			this.m_attrValue = ShieldAttributeConfig.s_maxShieldPoint;
			break;
		case ShieldAttributeType.RechargeRate:
			this.m_attrValue = ShieldAttributeConfig.s_regenRatePercent;
			break;
		case ShieldAttributeType.RechargeDelay:
			this.m_attrValue = ShieldAttributeConfig.s_regenerationCD;
			break;
		case ShieldAttributeType.Manufacturer:
			this.m_attrValue = 0f;
			break;
		default:
			this.m_attrValue = 0f;
			break;
		}
	}

	// Token: 0x04002C32 RID: 11314
	public float m_attrValue;

	// Token: 0x04002C33 RID: 11315
	public ShieldAttributeType m_attrType;

	// Token: 0x04002C34 RID: 11316
	public static float s_maxShieldPoint = 100f;

	// Token: 0x04002C35 RID: 11317
	public static float s_regenerationCD = 5f;

	// Token: 0x04002C36 RID: 11318
	public static float s_regenRatePercent = 0.2f;
}
