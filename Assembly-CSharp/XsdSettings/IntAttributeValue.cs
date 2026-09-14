using System;
using System.Collections.Generic;

namespace XsdSettings
{
	// Token: 0x020008D6 RID: 2262
	public class IntAttributeValue : AttributeValue
	{
		// Token: 0x06003E71 RID: 15985 RVA: 0x0002A269 File Offset: 0x00028469
		public IntAttributeValue()
		{
			base.m_type = AttributeValueType.IntAttributeValue;
			this.m_value = 0;
		}

		// Token: 0x06003E72 RID: 15986 RVA: 0x001299CC File Offset: 0x00127BCC
		public override void vmethod_1(List<AttributeValue> list_0)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			foreach (AttributeValue attributeValue in list_0)
			{
				IntAttributeValue intAttributeValue = (IntAttributeValue)attributeValue;
				if (intAttributeValue.m_affectType == AffectType.Scale)
				{
					if (intAttributeValue.m_value > 0)
					{
						num2 += (float)intAttributeValue.m_value;
					}
					else
					{
						num += (float)intAttributeValue.m_value;
					}
				}
				if (intAttributeValue.m_affectType == AffectType.PostAdd)
				{
					num4 += (float)intAttributeValue.m_value;
				}
				if (intAttributeValue.m_affectType == AffectType.PrevAdd)
				{
					num3 += (float)intAttributeValue.m_value;
				}
			}
			this.m_value = (int)(((float)this.m_value + num3) * ((1f + num2) / (1f - num)) + num4);
		}

		// Token: 0x06003E73 RID: 15987 RVA: 0x00129AB0 File Offset: 0x00127CB0
		public override void vmethod_2(AttributeValue attributeValue_0)
		{
			if (attributeValue_0 is FloatAttributeValue)
			{
				FloatAttributeValue floatAttributeValue = (FloatAttributeValue)attributeValue_0;
				this.m_value = (int)floatAttributeValue.m_value;
				base.m_affectType = floatAttributeValue.m_affectType;
			}
			if (attributeValue_0 is IntAttributeValue)
			{
				IntAttributeValue intAttributeValue = (IntAttributeValue)attributeValue_0;
				this.m_value = intAttributeValue.m_value;
				base.m_affectType = intAttributeValue.m_affectType;
			}
		}

		// Token: 0x06003E74 RID: 15988 RVA: 0x0002A27F File Offset: 0x0002847F
		public override string ToString()
		{
			return base.m_type.ToString() + "_" + this.m_value;
		}

		// Token: 0x06003E75 RID: 15989 RVA: 0x0002A2A6 File Offset: 0x000284A6
		public override void vmethod_3(float float_0)
		{
			this.m_value = (int)float_0;
		}

		// Token: 0x06003E76 RID: 15990 RVA: 0x0002A2B0 File Offset: 0x000284B0
		public override float vmethod_4()
		{
			return (float)this.m_value;
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06003E77 RID: 15991 RVA: 0x0002A2B9 File Offset: 0x000284B9
		// (set) Token: 0x06003E78 RID: 15992 RVA: 0x0002A2C1 File Offset: 0x000284C1
		public int m_value { get; set; }

		// Token: 0x06003E79 RID: 15993 RVA: 0x0002A2CA File Offset: 0x000284CA
		public static int smethod_0(IntAttributeValue intAttributeValue_0)
		{
			return intAttributeValue_0.m_value;
		}
	}
}
