using System;
using UnityEngine;

// Token: 0x02000A9A RID: 2714
public static class MathExtensionMethods
{
	// Token: 0x06004967 RID: 18791 RVA: 0x0002FF8C File Offset: 0x0002E18C
	public static void smethod_0(this Vector3 vector3_0)
	{
		vector3_0.x = float.NaN;
		vector3_0.y = float.NaN;
		vector3_0.z = float.NaN;
	}

	// Token: 0x06004968 RID: 18792 RVA: 0x0002FFB2 File Offset: 0x0002E1B2
	public static bool smethod_1(this Vector3 vector3_0)
	{
		return !float.IsNaN(vector3_0.x) && !float.IsNaN(vector3_0.y) && !float.IsNaN(vector3_0.z);
	}

	// Token: 0x06004969 RID: 18793 RVA: 0x001314FC File Offset: 0x0012F6FC
	public static Vector3 smethod_2(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2)
	{
		Vector3 vector = vector3_2 - vector3_0;
		vector.y = 0f;
		if (vector.sqrMagnitude < 1E-45f)
		{
			return vector3_0;
		}
		Vector3 vector2 = vector3_1 - vector3_0;
		vector2.y = 0f;
		if (vector2.sqrMagnitude < 1E-45f)
		{
			return vector3_0;
		}
		vector2.Normalize();
		float num = Vector3.Dot(vector2, vector);
		if (num <= 1E-45f)
		{
			return vector3_0;
		}
		float num2 = Vector3.Distance(vector3_0, vector3_1);
		if (num >= num2)
		{
			return vector3_1;
		}
		return vector3_0 + vector2 * num;
	}
}
