using System;
using UnityEngine;

// Token: 0x02000A8F RID: 2703
public static class Debug
{
	// Token: 0x17000776 RID: 1910
	// (get) Token: 0x0600491E RID: 18718 RVA: 0x0002FC71 File Offset: 0x0002DE71
	public static bool Boolean_0
	{
		get
		{
			return global::UnityEngine.Debug.isDebugBuild;
		}
	}

	// Token: 0x0600491F RID: 18719 RVA: 0x0002FC78 File Offset: 0x0002DE78
	public static void smethod_0()
	{
		global::UnityEngine.Debug.Break();
	}

	// Token: 0x06004920 RID: 18720 RVA: 0x0002FC7F File Offset: 0x0002DE7F
	public static void smethod_1()
	{
		global::UnityEngine.Debug.ClearDeveloperConsole();
	}

	// Token: 0x06004921 RID: 18721 RVA: 0x0002FC86 File Offset: 0x0002DE86
	public static void smethod_2()
	{
		global::UnityEngine.Debug.DebugBreak();
	}

	// Token: 0x06004922 RID: 18722 RVA: 0x0002FC8D File Offset: 0x0002DE8D
	public static void smethod_3(Vector3 vector3_0, Vector3 vector3_1)
	{
		global::UnityEngine.Debug.DrawLine(vector3_0, vector3_1);
	}

	// Token: 0x06004923 RID: 18723 RVA: 0x0002FC96 File Offset: 0x0002DE96
	public static void smethod_4(Vector3 vector3_0, Vector3 vector3_1, Color color_0)
	{
		global::UnityEngine.Debug.DrawLine(vector3_0, vector3_1, color_0);
	}

	// Token: 0x06004924 RID: 18724 RVA: 0x0002FCA0 File Offset: 0x0002DEA0
	public static void smethod_5(Vector3 vector3_0, Vector3 vector3_1, Color color_0, float float_0)
	{
		global::UnityEngine.Debug.DrawLine(vector3_0, vector3_1, color_0, float_0);
	}

	// Token: 0x06004925 RID: 18725 RVA: 0x0002FCAB File Offset: 0x0002DEAB
	public static void smethod_6(Vector3 vector3_0, Vector3 vector3_1, Color color_0, float float_0, bool bool_0)
	{
		global::UnityEngine.Debug.DrawLine(vector3_0, vector3_1, color_0, float_0, bool_0);
	}

	// Token: 0x06004926 RID: 18726 RVA: 0x0002FCB8 File Offset: 0x0002DEB8
	public static void smethod_7(Vector3 vector3_0, Vector3 vector3_1)
	{
		global::UnityEngine.Debug.DrawRay(vector3_0, vector3_1);
	}

	// Token: 0x06004927 RID: 18727 RVA: 0x0002FCC1 File Offset: 0x0002DEC1
	public static void smethod_8(Vector3 vector3_0, Vector3 vector3_1, Color color_0)
	{
		global::UnityEngine.Debug.DrawRay(vector3_0, vector3_1, color_0);
	}

	// Token: 0x06004928 RID: 18728 RVA: 0x0002FCCB File Offset: 0x0002DECB
	public static void smethod_9(Vector3 vector3_0, Vector3 vector3_1, Color color_0, float float_0)
	{
		global::UnityEngine.Debug.DrawRay(vector3_0, vector3_1, color_0, float_0);
	}

	// Token: 0x06004929 RID: 18729 RVA: 0x0002FCD6 File Offset: 0x0002DED6
	public static void smethod_10(Vector3 vector3_0, Vector3 vector3_1, Color color_0, float float_0, bool bool_0)
	{
		global::UnityEngine.Debug.DrawRay(vector3_0, vector3_1, color_0, float_0, bool_0);
	}
}
