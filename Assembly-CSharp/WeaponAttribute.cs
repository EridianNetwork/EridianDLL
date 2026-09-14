using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

// Token: 0x0200090B RID: 2315
[Serializable]
public class WeaponAttribute
{
	// Token: 0x06003FCC RID: 16332 RVA: 0x0002AC79 File Offset: 0x00028E79
	public WeaponAttribute()
	{
	}

	// Token: 0x06003FCD RID: 16333 RVA: 0x0012DF80 File Offset: 0x0012C180
	public WeaponAttribute(WeaponAttribute weaponAttribute_0)
	{
		this.m_weaponType = weaponAttribute_0.m_weaponType;
		this.m_weaponAttribute.Clear();
		foreach (BOLAttribute bolattribute in weaponAttribute_0.m_weaponAttribute)
		{
			this.m_weaponAttribute.Add(new BOLAttribute(bolattribute));
		}
	}

	// Token: 0x06003FCE RID: 16334 RVA: 0x0012E004 File Offset: 0x0012C204
	public WeaponAttribute(bool bool_0, WeaponType weaponType_0)
	{
		this.m_weaponType = weaponType_0;
		if (bool_0)
		{
			this.m_weaponAttribute.Clear();
			foreach (object obj in Enum.GetValues(typeof(AttributeType)))
			{
				AttributeType attributeType = (AttributeType)((int)obj);
				this.m_weaponAttribute.Add(AttributeStore.attributeStore.method_0(attributeType));
			}
		}
	}

	// Token: 0x06003FCF RID: 16335 RVA: 0x0012E0A0 File Offset: 0x0012C2A0
	public void method_0()
	{
		List<BOLAttribute> list = new List<BOLAttribute>();
		AttributeType attributeType;
		foreach (int value in Enum.GetValues(typeof(AttributeType)))
		{
			attributeType = (AttributeType)value;
			int num = m_weaponAttribute.FindIndex((BOLAttribute bolattribute_0) => bolattribute_0.m_attributeType == attributeType);
			if (num >= 0)
			{
				list.Add(m_weaponAttribute[num]);
			}
			else
			{
				list.Add(AttributeStore.attributeStore.method_0(attributeType));
			}
		}
		foreach (BOLAttribute item in list)
		{
			item.vmethod_0();
		}
		m_weaponAttribute = list;
	}
	// Token: 0x06003FD0 RID: 16336 RVA: 0x0002AC8C File Offset: 0x00028E8C
	public AttributeValue method_1(AttributeType attributeType_0)
	{
		return this.m_weaponAttribute[(int)attributeType_0].m_attributeValue;
	}

	// Token: 0x06003FD1 RID: 16337 RVA: 0x0012E1A0 File Offset: 0x0012C3A0
	public float method_2()
	{
		if (this.m_weaponType == WeaponType.SniperRifle)
		{
			return 100f - (this.m_weaponAttribute[8].m_attributeValue as FloatAttributeValue).m_value;
		}
		return 100f - (this.m_weaponAttribute[2].m_attributeValue as FloatAttributeValue).m_value;
	}

	// Token: 0x04002CE5 RID: 11493
	[SerializeField]
	public WeaponType m_weaponType;

	// Token: 0x04002CE6 RID: 11494
	[SerializeField]
	public List<BOLAttribute> m_weaponAttribute = new List<BOLAttribute>();
}
