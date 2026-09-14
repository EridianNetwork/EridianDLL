using System;
using System.Collections.Generic;
using UnityEngine;

namespace XsdSettings
{
	// Token: 0x020008D5 RID: 2261
	public class FloatAttributeValue : AttributeValue
	{
		// Token: 0x06003E67 RID: 15975 RVA: 0x0002A1E6 File Offset: 0x000283E6
		public FloatAttributeValue()
		{
			base.m_type = AttributeValueType.FloatAttributeValue;
			this.m_value = 0f;
		}

		// Token: 0x06003E68 RID: 15976 RVA: 0x0002A200 File Offset: 0x00028400
		public override void vmethod_0(float float_0, float float_1, float float_2)
		{
			this.m_value *= Mathf.Pow(float_0, float_1) + float_2;
		}

		// Token: 0x06003E69 RID: 15977 RVA: 0x00129890 File Offset: 0x00127A90
		public override void vmethod_1(List<AttributeValue> list_0)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			foreach (AttributeValue attributeValue in list_0)
			{
				FloatAttributeValue floatAttributeValue = (FloatAttributeValue)attributeValue;
				if (floatAttributeValue.m_affectType == AffectType.Scale)
				{
					if (floatAttributeValue.m_value > 0f)
					{
						num2 += floatAttributeValue.m_value;
					}
					else
					{
						num += floatAttributeValue.m_value;
					}
				}
				if (floatAttributeValue.m_affectType == AffectType.PostAdd)
				{
					num4 += floatAttributeValue.m_value;
				}
				if (floatAttributeValue.m_affectType == AffectType.PrevAdd)
				{
					num3 += floatAttributeValue.m_value;
				}
			}
			this.m_value = (this.m_value + num3) * ((1f + num2) / (1f - num)) + num4;
		}

		// Token: 0x06003E6A RID: 15978 RVA: 0x00129970 File Offset: 0x00127B70
		public override void vmethod_2(AttributeValue attributeValue_0)
		{
			if (attributeValue_0 is FloatAttributeValue)
			{
				FloatAttributeValue floatAttributeValue = (FloatAttributeValue)attributeValue_0;
				this.m_value = floatAttributeValue.m_value;
				base.m_affectType = floatAttributeValue.m_affectType;
			}
			if (attributeValue_0 is IntAttributeValue)
			{
				IntAttributeValue intAttributeValue = (IntAttributeValue)attributeValue_0;
				this.m_value = (float)intAttributeValue.m_value;
				base.m_affectType = intAttributeValue.m_affectType;
			}
		}

		// Token: 0x06003E6B RID: 15979 RVA: 0x0002A218 File Offset: 0x00028418
		public override string ToString()
		{
			return base.m_type.ToString() + "_" + this.m_value;
		}

		// Token: 0x06003E6C RID: 15980 RVA: 0x0002A23F File Offset: 0x0002843F
		public override void vmethod_3(float float_0)
		{
			this.m_value = float_0;
		}

		// Token: 0x06003E6D RID: 15981 RVA: 0x0002A248 File Offset: 0x00028448
		public override float vmethod_4()
		{
			return this.m_value;
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06003E6E RID: 15982 RVA: 0x0002A250 File Offset: 0x00028450
		// (set) Token: 0x06003E6F RID: 15983 RVA: 0x0002A258 File Offset: 0x00028458
		public float m_value { get; set; }

		// Token: 0x06003E70 RID: 15984 RVA: 0x0002A261 File Offset: 0x00028461
		public static float smethod_0(FloatAttributeValue floatAttributeValue_0)
		{
			return floatAttributeValue_0.m_value;
		}
	}
}
