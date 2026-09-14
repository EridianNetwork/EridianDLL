using System;
using UnityEngine;

// Token: 0x020000E0 RID: 224
public class ldlt
{
	// Token: 0x0600056E RID: 1390 RVA: 0x0004F898 File Offset: 0x0004DA98
	public static void smethod_0(ref float[,] float_0, int int_0, bool bool_0, float[] float_1)
	{
		int num = 0;
		float num2 = (1f + Mathf.Sqrt(17f)) / 8f;
		if (bool_0)
		{
			int num3;
			for (int i = int_0 - 1; i >= 0; i -= num3)
			{
				num3 = 1;
				float num4 = Math.Abs(float_0[i, i]);
				float num5;
				if (i > 0)
				{
					num = 1;
					for (int j = 2; j <= i; j++)
					{
						if (Math.Abs(float_0[j - 1, i]) > Math.Abs(float_0[num - 1, i]))
						{
							num = j;
						}
					}
					num5 = Math.Abs(float_0[num - 1, i]);
				}
				else
				{
					num5 = 0f;
				}
				if (Math.Max(num4, num5) != 0f)
				{
					int num6;
					if (num4 >= num2 * num5)
					{
						num6 = i;
					}
					else
					{
						int num7 = num + 1;
						for (int j = num + 2; j <= i + 1; j++)
						{
							if (Math.Abs(float_0[num - 1, j - 1]) > Math.Abs(float_0[num - 1, num7 - 1]))
							{
								num7 = j;
							}
						}
						float num8 = Math.Abs(float_0[num - 1, num7 - 1]);
						if (num > 1)
						{
							num7 = 1;
							for (int j = 2; j <= num - 1; j++)
							{
								if (Math.Abs(float_0[j - 1, num - 1]) > Math.Abs(float_0[num7 - 1, num - 1]))
								{
									num7 = j;
								}
							}
							num8 = Math.Max(num8, Math.Abs(float_0[num7 - 1, num - 1]));
						}
						float num9 = num5 / num8;
						if (num4 >= num2 * num5 * num9)
						{
							num6 = i;
						}
						else if (Math.Abs(float_0[num - 1, num - 1]) >= num2 * num8)
						{
							num6 = num - 1;
						}
						else
						{
							num6 = num - 1;
							num3 = 2;
						}
					}
					int num10 = i + 1 - num3;
					if (num6 + 1 != num10 + 1)
					{
						for (int k = 0; k <= num6 - 1; k++)
						{
							float_1[k] = float_0[k, num10];
						}
						for (int k = 0; k <= num6 - 1; k++)
						{
							float_0[k, num10] = float_0[k, num6];
						}
						for (int k = 0; k <= num6 - 1; k++)
						{
							float_0[k, num6] = float_1[k];
						}
						for (int k = num6 + 1; k <= num10 - 1; k++)
						{
							float_1[k] = float_0[k, num10];
						}
						for (int k = num6 + 1; k <= num10 - 1; k++)
						{
							float_0[k, num10] = float_0[num6, k];
						}
						for (int k = num6 + 1; k <= num10 - 1; k++)
						{
							float_0[num6, k] = float_1[k];
						}
						float num11 = float_0[num10, num10];
						float_0[num10, num10] = float_0[num6, num6];
						float_0[num6, num6] = num11;
						if (num3 == 2)
						{
							num11 = float_0[i - 1, i];
							float_0[i - 1, i] = float_0[num6, i];
							float_0[num6, i] = num11;
						}
					}
					if (num3 == 1)
					{
						float num12 = 1f / float_0[i, i];
						for (int l = 0; l <= i - 1; l++)
						{
							float num9 = -(num12 * float_0[l, i]);
							for (int k = l; k <= i - 1; k++)
							{
								float_0[l, k] += num9 * float_0[k, i];
							}
						}
						for (int k = 0; k <= i - 1; k++)
						{
							float_0[k, i] = num12 * float_0[k, i];
						}
					}
					else if (i > 1)
					{
						float num13 = float_0[i - 1, i];
						float num14 = float_0[i - 1, i - 1] / num13;
						float num15 = float_0[i, i] / num13;
						float num11 = 1f / (num15 * num14 - 1f);
						num13 = num11 / num13;
						for (int m = i - 2; m >= 0; m--)
						{
							float num16 = num13 * (num15 * float_0[m, i - 1] - float_0[m, i]);
							float num17 = num13 * (num14 * float_0[m, i] - float_0[m, i - 1]);
							for (int k = 0; k <= m; k++)
							{
								float_0[k, m] -= num17 * float_0[k, i];
							}
							for (int k = 0; k <= m; k++)
							{
								float_0[k, m] -= num16 * float_0[k, i - 1];
							}
							float_0[m, i] = num17;
							float_0[m, i - 1] = num16;
						}
					}
				}
			}
		}
		else
		{
			int num3;
			for (int i = 0; i <= int_0 - 1; i += num3)
			{
				num3 = 1;
				float num4 = Math.Abs(float_0[i, i]);
				float num5;
				if (i < int_0 - 1)
				{
					num = i + 1 + 1;
					for (int j = i + 1 + 2; j <= int_0; j++)
					{
						if (Math.Abs(float_0[j - 1, i]) > Math.Abs(float_0[num - 1, i]))
						{
							num = j;
						}
					}
					num5 = Math.Abs(float_0[num - 1, i]);
				}
				else
				{
					num5 = 0f;
				}
				if (Math.Max(num4, num5) != 0f)
				{
					int num6;
					if (num4 >= num2 * num5)
					{
						num6 = i;
					}
					else
					{
						int num7 = i + 1;
						for (int j = i + 1 + 1; j <= num - 1; j++)
						{
							if (Math.Abs(float_0[num - 1, j - 1]) > Math.Abs(float_0[num - 1, num7 - 1]))
							{
								num7 = j;
							}
						}
						float num8 = Math.Abs(float_0[num - 1, num7 - 1]);
						if (num < int_0)
						{
							num7 = num + 1;
							for (int j = num + 2; j <= int_0; j++)
							{
								if (Math.Abs(float_0[j - 1, num - 1]) > Math.Abs(float_0[num7 - 1, num - 1]))
								{
									num7 = j;
								}
							}
							num8 = Math.Max(num8, Math.Abs(float_0[num7 - 1, num - 1]));
						}
						float num9 = num5 / num8;
						if (num4 >= num2 * num5 * num9)
						{
							num6 = i;
						}
						else if (Math.Abs(float_0[num - 1, num - 1]) >= num2 * num8)
						{
							num6 = num - 1;
						}
						else
						{
							num6 = num - 1;
							num3 = 2;
						}
					}
					int num10 = i + num3 - 1;
					if (num6 != num10)
					{
						if (num6 + 1 < int_0)
						{
							for (int k = num6 + 1; k <= int_0 - 1; k++)
							{
								float_1[k] = float_0[k, num10];
							}
							for (int k = num6 + 1; k <= int_0 - 1; k++)
							{
								float_0[k, num10] = float_0[k, num6];
							}
							for (int k = num6 + 1; k <= int_0 - 1; k++)
							{
								float_0[k, num6] = float_1[k];
							}
						}
						for (int k = num10 + 1; k <= num6 - 1; k++)
						{
							float_1[k] = float_0[k, num10];
						}
						for (int k = num10 + 1; k <= num6 - 1; k++)
						{
							float_0[k, num10] = float_0[num6, k];
						}
						for (int k = num10 + 1; k <= num6 - 1; k++)
						{
							float_0[num6, k] = float_1[k];
						}
						float num11 = float_0[num10, num10];
						float_0[num10, num10] = float_0[num6, num6];
						float_0[num6, num6] = num11;
						if (num3 == 2)
						{
							num11 = float_0[i + 1, i];
							float_0[i + 1, i] = float_0[num6, i];
							float_0[num6, i] = num11;
						}
					}
					if (num3 == 1)
					{
						if (i + 1 < int_0)
						{
							float num15 = 1f / float_0[i + 1 - 1, i + 1 - 1];
							for (int j = i + 1; j <= int_0 - 1; j++)
							{
								float num9 = -(num15 * float_0[j, i]);
								for (int k = i + 1; k <= j; k++)
								{
									float_0[j, k] += num9 * float_0[k, i];
								}
							}
							for (int k = i + 1; k <= int_0 - 1; k++)
							{
								float_0[k, i] = num15 * float_0[k, i];
							}
						}
					}
					else if (i < int_0 - 2)
					{
						float num18 = float_0[i + 1, i];
						float num15 = float_0[i + 1, i + 1] / num18;
						float num14 = float_0[i, i] / num18;
						float num11 = 1f / (num15 * num14 - 1f);
						num18 = num11 / num18;
						for (int m = i + 2; m <= int_0 - 1; m++)
						{
							float num17 = num18 * (num15 * float_0[m, i] - float_0[m, i + 1]);
							float num19 = num18 * (num14 * float_0[m, i + 1] - float_0[m, i]);
							for (int k = m; k <= int_0 - 1; k++)
							{
								float_0[k, m] -= num17 * float_0[k, i];
							}
							for (int k = m; k <= int_0 - 1; k++)
							{
								float_0[k, m] -= num19 * float_0[k, i + 1];
							}
							float_0[m, i] = num17;
							float_0[m, i + 1] = num19;
						}
					}
				}
			}
		}
	}
}
