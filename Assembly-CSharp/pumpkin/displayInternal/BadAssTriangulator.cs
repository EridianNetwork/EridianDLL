using System;
using System.Collections.Generic;
using UnityEngine;

namespace pumpkin.displayInternal
{
	// Token: 0x02000770 RID: 1904
	internal struct BadAssTriangulator
	{
		// Token: 0x06003274 RID: 12916 RVA: 0x00020E37 File Offset: 0x0001F037
		public BadAssTriangulator(Vector2[] vector2_0)
		{
			this.list_0 = new List<Vector2>(vector2_0);
		}

		// Token: 0x06003275 RID: 12917 RVA: 0x000E69A0 File Offset: 0x000E4BA0
		public int[] method_0()
		{
			List<int> list = new List<int>();
			int count = this.list_0.Count;
			if (count < 3)
			{
				return list.ToArray();
			}
			int[] array = new int[count];
			if (this.method_1() > 0f)
			{
				for (int i = 0; i < count; i++)
				{
					array[i] = i;
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					array[j] = count - 1 - j;
				}
			}
			int k = count;
			int num = 2 * k;
			int num2 = 0;
			int num3 = k - 1;
			while (k > 2)
			{
				if (num-- <= 0)
				{
					return list.ToArray();
				}
				int num4 = num3;
				if (k <= num4)
				{
					num4 = 0;
				}
				num3 = num4 + 1;
				if (k <= num3)
				{
					num3 = 0;
				}
				int num5 = num3 + 1;
				if (k <= num5)
				{
					num5 = 0;
				}
				if (this.method_2(num4, num3, num5, k, array))
				{
					int num6 = array[num4];
					int num7 = array[num3];
					int num8 = array[num5];
					list.Add(num6);
					list.Add(num7);
					list.Add(num8);
					num2++;
					int num9 = num3;
					for (int l = num3 + 1; l < k; l++)
					{
						array[num9] = array[l];
						num9++;
					}
					k--;
					num = 2 * k;
				}
			}
			list.Reverse();
			return list.ToArray();
		}

		// Token: 0x06003276 RID: 12918 RVA: 0x000E6AE8 File Offset: 0x000E4CE8
		private float method_1()
		{
			int count = this.list_0.Count;
			float num = 0f;
			int num2 = count - 1;
			int i = 0;
			while (i < count)
			{
				Vector2 vector = this.list_0[num2];
				Vector2 vector2 = this.list_0[i];
				num += vector.x * vector2.y - vector2.x * vector.y;
				num2 = i++;
			}
			return num * 0.5f;
		}

		// Token: 0x06003277 RID: 12919 RVA: 0x000E6B60 File Offset: 0x000E4D60
		private bool method_2(int int_0, int int_1, int int_2, int int_3, int[] int_4)
		{
			Vector2 vector = this.list_0[int_4[int_0]];
			Vector2 vector2 = this.list_0[int_4[int_1]];
			Vector2 vector3 = this.list_0[int_4[int_2]];
			if (1E-45f > (vector2.x - vector.x) * (vector3.y - vector.y) - (vector2.y - vector.y) * (vector3.x - vector.x))
			{
				return false;
			}
			for (int i = 0; i < int_3; i++)
			{
				if (i != int_0 && i != int_1 && i != int_2)
				{
					Vector2 vector4 = this.list_0[int_4[i]];
					if (this.method_3(vector, vector2, vector3, vector4))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06003278 RID: 12920 RVA: 0x000E6C20 File Offset: 0x000E4E20
		private bool method_3(Vector2 vector2_0, Vector2 vector2_1, Vector2 vector2_2, Vector2 vector2_3)
		{
			float num = vector2_2.x - vector2_1.x;
			float num2 = vector2_2.y - vector2_1.y;
			float num3 = vector2_0.x - vector2_2.x;
			float num4 = vector2_0.y - vector2_2.y;
			float num5 = vector2_1.x - vector2_0.x;
			float num6 = vector2_1.y - vector2_0.y;
			float num7 = vector2_3.x - vector2_0.x;
			float num8 = vector2_3.y - vector2_0.y;
			float num9 = vector2_3.x - vector2_1.x;
			float num10 = vector2_3.y - vector2_1.y;
			float num11 = vector2_3.x - vector2_2.x;
			float num12 = vector2_3.y - vector2_2.y;
			float num13 = num * num10 - num2 * num9;
			float num14 = num5 * num8 - num6 * num7;
			float num15 = num3 * num12 - num4 * num11;
			return num13 >= 0f && num15 >= 0f && num14 >= 0f;
		}

		// Token: 0x040022F5 RID: 8949
		private List<Vector2> list_0;
	}
}
