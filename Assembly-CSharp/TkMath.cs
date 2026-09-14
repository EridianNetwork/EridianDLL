using System;
using UnityEngine;

// Token: 0x02000B66 RID: 2918
public static class TkMath
{
	// Token: 0x06004F2C RID: 20268 RVA: 0x00033948 File Offset: 0x00031B48
	public static int smethod_0(int int_0, int int_1, int int_2)
	{
		if (int_0 < int_1)
		{
			return int_1;
		}
		if (int_0 > int_2)
		{
			return int_2;
		}
		return int_0;
	}

	// Token: 0x06004F2D RID: 20269 RVA: 0x00033957 File Offset: 0x00031B57
	public static float smethod_1(float float_0, float float_1, float float_2)
	{
		if (float_0 < float_1)
		{
			return float_1;
		}
		if (float_0 > float_2)
		{
			return float_2;
		}
		return float_0;
	}

	// Token: 0x06004F2E RID: 20270 RVA: 0x00033966 File Offset: 0x00031B66
	public static Vector2 smethod_2(Vector2 vector2_0, float float_0, float float_1)
	{
		return new Vector2(TkMath.smethod_1(vector2_0.x, float_0, float_1), TkMath.smethod_1(vector2_0.y, float_0, float_1));
	}

	// Token: 0x06004F2F RID: 20271 RVA: 0x00033989 File Offset: 0x00031B89
	public static Vector3 smethod_3(Vector3 vector3_0, float float_0, float float_1)
	{
		return new Vector3(TkMath.smethod_1(vector3_0.x, float_0, float_1), TkMath.smethod_1(vector3_0.y, float_0, float_1), TkMath.smethod_1(vector3_0.z, float_0, float_1));
	}

	// Token: 0x06004F30 RID: 20272 RVA: 0x000339BA File Offset: 0x00031BBA
	public static int smethod_4(int int_0)
	{
		if (int_0 < 0)
		{
			return 0;
		}
		if (int_0 > 1)
		{
			return 1;
		}
		return int_0;
	}

	// Token: 0x06004F31 RID: 20273 RVA: 0x000339C9 File Offset: 0x00031BC9
	public static float smethod_5(float float_0)
	{
		if (float_0 < 0f)
		{
			return 0f;
		}
		if (float_0 > 1f)
		{
			return 1f;
		}
		return float_0;
	}

	// Token: 0x06004F32 RID: 20274 RVA: 0x000339E8 File Offset: 0x00031BE8
	public static void smethod_6(ref int int_0, int int_1, int int_2)
	{
		if (int_0 < int_1)
		{
			int_0 = int_1;
		}
		else if (int_0 > int_2)
		{
			int_0 = int_2;
		}
	}

	// Token: 0x06004F33 RID: 20275 RVA: 0x000339FC File Offset: 0x00031BFC
	public static void smethod_7(ref float float_0, float float_1, float float_2)
	{
		if (float_0 < float_1)
		{
			float_0 = float_1;
		}
		else if (float_0 > float_2)
		{
			float_0 = float_2;
		}
	}

	// Token: 0x06004F34 RID: 20276 RVA: 0x00033A10 File Offset: 0x00031C10
	public static void smethod_8(ref int int_0)
	{
		if (int_0 < 0)
		{
			int_0 = 0;
		}
		else if (int_0 > 1)
		{
			int_0 = 1;
		}
	}

	// Token: 0x06004F35 RID: 20277 RVA: 0x00033A24 File Offset: 0x00031C24
	public static void smethod_9(ref float float_0)
	{
		if (float_0 < 0f)
		{
			float_0 = 0f;
		}
		else if (float_0 > 1f)
		{
			float_0 = 1f;
		}
	}

	// Token: 0x06004F36 RID: 20278 RVA: 0x00033A48 File Offset: 0x00031C48
	public static int smethod_10(int int_0, int int_1)
	{
		return (int_0 >= int_1) ? int_1 : int_0;
	}

	// Token: 0x06004F37 RID: 20279 RVA: 0x00033A52 File Offset: 0x00031C52
	public static int smethod_11(int int_0, int int_1)
	{
		return (int_0 <= int_1) ? int_1 : int_0;
	}

	// Token: 0x06004F38 RID: 20280 RVA: 0x00033A5C File Offset: 0x00031C5C
	public static float smethod_12(float float_0, float float_1)
	{
		return (float_0 >= float_1) ? float_1 : float_0;
	}

	// Token: 0x06004F39 RID: 20281 RVA: 0x00033A66 File Offset: 0x00031C66
	public static float smethod_13(float float_0, float float_1)
	{
		return (float_0 <= float_1) ? float_1 : float_0;
	}

	// Token: 0x06004F3A RID: 20282 RVA: 0x00033A70 File Offset: 0x00031C70
	public static void smethod_14(ref int int_0, int int_1)
	{
		int_0 = TkMath.smethod_10(int_0, int_1);
	}

	// Token: 0x06004F3B RID: 20283 RVA: 0x00033A7C File Offset: 0x00031C7C
	public static void smethod_15(ref int int_0, int int_1)
	{
		int_0 = TkMath.smethod_11(int_0, int_1);
	}

	// Token: 0x06004F3C RID: 20284 RVA: 0x00033A88 File Offset: 0x00031C88
	public static void smethod_16(ref float float_0, float float_1)
	{
		float_0 = TkMath.smethod_12(float_0, float_1);
	}

	// Token: 0x06004F3D RID: 20285 RVA: 0x00033A94 File Offset: 0x00031C94
	public static void smethod_17(ref float float_0, float float_1)
	{
		float_0 = TkMath.smethod_13(float_0, float_1);
	}

	// Token: 0x06004F3E RID: 20286 RVA: 0x00033AA0 File Offset: 0x00031CA0
	public static bool smethod_18(int int_0, int int_1, int int_2)
	{
		return int_0 >= int_1 && int_0 <= int_2;
	}

	// Token: 0x06004F3F RID: 20287 RVA: 0x00033AB0 File Offset: 0x00031CB0
	public static bool smethod_19(float float_0, float float_1, float float_2)
	{
		return float_0 >= float_1 && float_0 <= float_2;
	}

	// Token: 0x06004F40 RID: 20288 RVA: 0x00033AC0 File Offset: 0x00031CC0
	public static int smethod_20(int int_0)
	{
		return (int_0 < 0) ? (-int_0) : int_0;
	}

	// Token: 0x06004F41 RID: 20289 RVA: 0x00033ACB File Offset: 0x00031CCB
	public static float smethod_21(float float_0)
	{
		return Mathf.Abs(float_0);
	}

	// Token: 0x06004F42 RID: 20290 RVA: 0x00033AD3 File Offset: 0x00031CD3
	public static Vector2 smethod_22(Vector2 vector2_0)
	{
		return new Vector2(Mathf.Abs(vector2_0.x), Mathf.Abs(vector2_0.y));
	}

	// Token: 0x06004F43 RID: 20291 RVA: 0x00033AF2 File Offset: 0x00031CF2
	public static Vector3 smethod_23(Vector3 vector3_0)
	{
		return new Vector3(Mathf.Abs(vector3_0.x), Mathf.Abs(vector3_0.y), Mathf.Abs(vector3_0.z));
	}

	// Token: 0x06004F44 RID: 20292 RVA: 0x00033B1D File Offset: 0x00031D1D
	public static Vector2 smethod_24(Vector2 vector2_0, Vector2 vector2_1, float float_0)
	{
		return vector2_0 + (vector2_1 - vector2_0) * float_0;
	}

	// Token: 0x06004F45 RID: 20293 RVA: 0x000031C5 File Offset: 0x000013C5
	public static Vector3 smethod_25(Vector3 vector3_0, Vector3 vector3_1, float float_0)
	{
		return vector3_0 + (vector3_1 - vector3_0) * float_0;
	}

	// Token: 0x06004F46 RID: 20294 RVA: 0x00033B32 File Offset: 0x00031D32
	public static Color smethod_26(Color color_0, Color color_1, float float_0)
	{
		return color_0 + (color_1 - color_0) * float_0;
	}

	// Token: 0x06004F47 RID: 20295 RVA: 0x00033B47 File Offset: 0x00031D47
	public static float smethod_27(float float_0, float float_1, float float_2)
	{
		return float_0 + (float_1 - float_0) * float_2;
	}

	// Token: 0x06004F48 RID: 20296 RVA: 0x00033B50 File Offset: 0x00031D50
	public static Vector3 smethod_28(Vector3 vector3_0, Vector3 vector3_1, float float_0, float float_1)
	{
		return (vector3_0 * float_1 + vector3_1 * float_0) / (float_1 + float_0);
	}

	// Token: 0x06004F49 RID: 20297 RVA: 0x00033B6D File Offset: 0x00031D6D
	public static float smethod_29(float float_0, float float_1, float float_2, float float_3)
	{
		return (float_0 * float_3 + float_1 * float_2) / (float_3 + float_2);
	}

	// Token: 0x06004F4A RID: 20298 RVA: 0x00150630 File Offset: 0x0014E830
	public static float smethod_30(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		float num = float_1 - float_0;
		float num2 = TkMath.smethod_12(num, float_2 * float_4);
		float num3 = TkMath.smethod_12(num, float_3 * float_4);
		float num4 = TkMath.smethod_1(TkMath.smethod_29(0f, num, float_4, float_5), num2, num3);
		return float_0 + num4;
	}

	// Token: 0x06004F4B RID: 20299 RVA: 0x00150674 File Offset: 0x0014E874
	public static Vector3 smethod_31(Vector3 vector3_0, Vector3 vector3_1, float float_0, float float_1, float float_2, float float_3)
	{
		float magnitude = (vector3_1 - vector3_0).magnitude;
		float num = TkMath.smethod_30(0f, magnitude, float_0, float_1, float_2, float_3);
		return (num <= 0f) ? vector3_1 : (vector3_0 + (vector3_1 - vector3_0).normalized * num);
	}

	// Token: 0x06004F4C RID: 20300 RVA: 0x00033B7A File Offset: 0x00031D7A
	public static float smethod_32(float float_0, float float_1)
	{
		return (float_1 != 0f) ? (float_0 / float_1) : 0f;
	}

	// Token: 0x06004F4D RID: 20301 RVA: 0x00033B8E File Offset: 0x00031D8E
	public static double smethod_33(double double_0, double double_1)
	{
		return (double_1 != 0.0) ? (double_0 / double_1) : 0.0;
	}

	// Token: 0x06004F4E RID: 20302 RVA: 0x001506CC File Offset: 0x0014E8CC
	public static bool smethod_34(Vector3 vector3_0, Vector3 vector3_1)
	{
		return Mathf.Approximately(vector3_0.x, vector3_1.x) && Mathf.Approximately(vector3_0.y, vector3_1.y) && Mathf.Approximately(vector3_0.z, vector3_1.z);
	}

	// Token: 0x06004F4F RID: 20303 RVA: 0x0015071C File Offset: 0x0014E91C
	public static int smethod_35(ulong ulong_0)
	{
		int num = 0;
		while (ulong_0 != 0UL)
		{
			if ((ulong_0 & 1UL) != 0UL)
			{
				num++;
			}
			ulong_0 >>= 1;
		}
		return num;
	}

	// Token: 0x04003B54 RID: 15188
	public const float cos15 = 0.9659258f;

	// Token: 0x04003B55 RID: 15189
	public const float cos30 = 0.8660254f;

	// Token: 0x04003B56 RID: 15190
	public const float sqrt2 = 1.4142135f;
}
