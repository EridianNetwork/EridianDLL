using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000B64 RID: 2916
public class Tk
{
	// Token: 0x06004EF2 RID: 20210 RVA: 0x0014FB6C File Offset: 0x0014DD6C
	public static T[] smethod_0<T>(int int_0) where T : new()
	{
		T[] array = new T[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i] = ((default(T) == null) ? new T() : default(T));
		}
		return array;
	}

	// Token: 0x06004EF3 RID: 20211 RVA: 0x0014FBB4 File Offset: 0x0014DDB4
	public static T[,] smethod_1<T>(int int_0, int int_1) where T : new()
	{
		T[,] array = new T[int_0, int_1];
		for (int i = 0; i < int_0; i++)
		{
			for (int j = 0; j < int_1; j++)
			{
				array[i, j] = ((default(T) == null) ? new T() : default(T));
			}
		}
		return array;
	}

	// Token: 0x06004EF4 RID: 20212 RVA: 0x0014FC0C File Offset: 0x0014DE0C
	public static void smethod_2<T>(T[,] gparam_0, T gparam_1)
	{
		for (int i = 0; i < gparam_0.GetLength(0); i++)
		{
			for (int j = 0; j < gparam_0.GetLength(1); j++)
			{
				gparam_0[i, j] = gparam_1;
			}
		}
	}

	// Token: 0x06004EF5 RID: 20213 RVA: 0x0014FC48 File Offset: 0x0014DE48
	public static T smethod_3<T>(T[] gparam_0, int int_0)
	{
		if (gparam_0 == null)
		{
			return default(T);
		}
		if (int_0 >= 0 && int_0 < gparam_0.Length)
		{
			return gparam_0[int_0];
		}
		return default(T);
	}

	// Token: 0x06004EF6 RID: 20214 RVA: 0x0014FC80 File Offset: 0x0014DE80
	public static T smethod_4<T>(List<T> list_0, int int_0)
	{
		if (list_0 == null)
		{
			return default(T);
		}
		if (int_0 >= 0 && int_0 < list_0.Count)
		{
			return list_0[int_0];
		}
		return default(T);
	}

	// Token: 0x06004EF7 RID: 20215 RVA: 0x0014FCB8 File Offset: 0x0014DEB8
	public static T smethod_5<T>(T[] gparam_0, int int_0)
	{
		if (gparam_0 == null)
		{
			return default(T);
		}
		if (int_0 >= 0 && int_0 < gparam_0.Length)
		{
			return gparam_0[gparam_0.Length - 1 - int_0];
		}
		return default(T);
	}

	// Token: 0x06004EF8 RID: 20216 RVA: 0x0014FCF4 File Offset: 0x0014DEF4
	public static T smethod_6<T>(List<T> list_0, int int_0)
	{
		if (list_0 == null)
		{
			return default(T);
		}
		if (int_0 >= 0 && int_0 < list_0.Count)
		{
			return list_0[list_0.Count - 1 - int_0];
		}
		return default(T);
	}

	// Token: 0x06004EF9 RID: 20217 RVA: 0x0014FD38 File Offset: 0x0014DF38
	public static void smethod_7<T>(List<T> list_0, int int_0)
	{
		if (list_0 == null)
		{
			return;
		}
		if (int_0 >= 0 && int_0 < list_0.Count)
		{
			int num = list_0.Count - 1;
			if (list_0.Count > 0)
			{
				list_0[int_0] = list_0[num];
			}
			list_0.RemoveAt(num);
			return;
		}
	}

	// Token: 0x06004EFA RID: 20218 RVA: 0x00033787 File Offset: 0x00031987
	public static bool smethod_8<T>(T[] gparam_0)
	{
		return gparam_0 == null || gparam_0.Length == 0;
	}

	// Token: 0x06004EFB RID: 20219 RVA: 0x00033795 File Offset: 0x00031995
	public static bool smethod_9<T>(List<T> list_0)
	{
		return list_0 == null || list_0.Count == 0;
	}

	// Token: 0x06004EFC RID: 20220 RVA: 0x000337A6 File Offset: 0x000319A6
	public static void smethod_10(ref IntPtr intptr_0, int int_0)
	{
		intptr_0 = new IntPtr(intptr_0.ToInt64() + (long)int_0);
	}

	// Token: 0x06004EFD RID: 20221 RVA: 0x000337B7 File Offset: 0x000319B7
	public static T smethod_11<T>(string string_0) where T : global::UnityEngine.Object
	{
		return Resources.Load(string_0, typeof(T)) as T;
	}

	// Token: 0x06004EFE RID: 20222 RVA: 0x0014FD80 File Offset: 0x0014DF80
	public static T smethod_12<T>(string string_0) where T : global::UnityEngine.Object
	{
		T t = Tk.smethod_11<T>(string_0);
		if (t == null)
		{
			global::UnityEngine.Debug.LogWarning(string.Concat(new string[]
			{
				"Cannot load resource ",
				typeof(T).Name,
				" \"",
				string_0,
				"\""
			}));
		}
		return t;
	}

	// Token: 0x06004EFF RID: 20223 RVA: 0x0014FDE4 File Offset: 0x0014DFE4
	public static GameObject smethod_13(string string_0)
	{
		GameObject gameObject = Tk.smethod_12<GameObject>(string_0);
		if (!gameObject)
		{
			return null;
		}
		return global::UnityEngine.Object.Instantiate(gameObject) as GameObject;
	}

	// Token: 0x06004F00 RID: 20224 RVA: 0x0014FE10 File Offset: 0x0014E010
	public static GameObject smethod_14(string string_0)
	{
		GameObject gameObject = Tk.smethod_11<GameObject>(string_0);
		if (!gameObject)
		{
			return null;
		}
		return global::UnityEngine.Object.Instantiate(gameObject) as GameObject;
	}

	// Token: 0x06004F01 RID: 20225 RVA: 0x000337D3 File Offset: 0x000319D3
	public static GameObject smethod_15(string string_0)
	{
		return Tk.smethod_12<GameObject>(string_0);
	}

	// Token: 0x06004F02 RID: 20226 RVA: 0x000337DB File Offset: 0x000319DB
	public static Texture smethod_16(string string_0)
	{
		return Tk.smethod_12<Texture>(string_0);
	}

	// Token: 0x06004F03 RID: 20227 RVA: 0x000337E3 File Offset: 0x000319E3
	public static Material smethod_17(string string_0)
	{
		return Tk.smethod_12<Material>(string_0);
	}

	// Token: 0x06004F04 RID: 20228 RVA: 0x000337EB File Offset: 0x000319EB
	public static AnimationClip smethod_18(string string_0)
	{
		return Tk.smethod_12<AnimationClip>(string_0);
	}

	// Token: 0x06004F05 RID: 20229 RVA: 0x000337F3 File Offset: 0x000319F3
	public static GameObject smethod_19(string string_0)
	{
		return Tk.smethod_11<GameObject>(string_0);
	}

	// Token: 0x06004F06 RID: 20230 RVA: 0x000337FB File Offset: 0x000319FB
	public static Texture smethod_20(string string_0)
	{
		return Tk.smethod_11<Texture>(string_0);
	}

	// Token: 0x06004F07 RID: 20231 RVA: 0x00033803 File Offset: 0x00031A03
	public static Material smethod_21(string string_0)
	{
		return Tk.smethod_11<Material>(string_0);
	}

	// Token: 0x06004F08 RID: 20232 RVA: 0x0003380B File Offset: 0x00031A0B
	public static AnimationClip smethod_22(string string_0)
	{
		return Tk.smethod_11<AnimationClip>(string_0);
	}

	// Token: 0x06004F09 RID: 20233 RVA: 0x00033813 File Offset: 0x00031A13
	public static void smethod_23(GameObject gameObject_0)
	{
		Tk.smethod_24(gameObject_0.transform);
	}

	// Token: 0x06004F0A RID: 20234 RVA: 0x0014FE3C File Offset: 0x0014E03C
	public static void smethod_24(Transform transform_0)
	{
		int childCount = transform_0.childCount;
		if (childCount == 0)
		{
			return;
		}
		Transform[] array = new Transform[childCount];
		for (int i = 0; i < childCount; i++)
		{
			array[i] = transform_0.GetChild(i);
		}
		for (int j = 0; j < childCount; j++)
		{
			if (array[j])
			{
				Tk.smethod_50(array[j].gameObject);
			}
		}
	}

	// Token: 0x06004F0B RID: 20235 RVA: 0x0014FE94 File Offset: 0x0014E094
	public static bool smethod_25<T>(T gparam_0, T gparam_1) where T : struct
	{
		int num = (int)((object)gparam_0);
		int num2 = (int)((object)gparam_1);
		return (num & num2) == num2;
	}

	// Token: 0x06004F0C RID: 20236 RVA: 0x0014FEC0 File Offset: 0x0014E0C0
	public static void smethod_26<T>(ref T gparam_0, ref T gparam_1)
	{
		T t = gparam_0;
		gparam_0 = gparam_1;
		gparam_1 = t;
	}

	// Token: 0x06004F0D RID: 20237 RVA: 0x0014FEE8 File Offset: 0x0014E0E8
	public static string smethod_27(GameObject gameObject_0)
	{
		if (gameObject_0 == null)
		{
			return "null";
		}
		if (gameObject_0.transform.parent)
		{
			return Tk.smethod_27(gameObject_0.transform.parent.gameObject) + "/" + gameObject_0.name;
		}
		return gameObject_0.name;
	}

	// Token: 0x06004F0E RID: 20238 RVA: 0x00033820 File Offset: 0x00031A20
	public static string smethod_28(Component component_0)
	{
		if (component_0 == null)
		{
			return "null";
		}
		return Tk.smethod_27(component_0.gameObject) + "." + component_0.GetType().Name;
	}

	// Token: 0x06004F0F RID: 20239 RVA: 0x00033851 File Offset: 0x00031A51
	public static void smethod_29(Transform transform_0, Vector3 vector3_0)
	{
		if (transform_0 == null)
		{
			return;
		}
		if (transform_0.position == vector3_0)
		{
			return;
		}
		transform_0.position = vector3_0;
	}

	// Token: 0x06004F10 RID: 20240 RVA: 0x00033873 File Offset: 0x00031A73
	public static void smethod_30(Transform transform_0, Vector3 vector3_0)
	{
		if (transform_0 == null)
		{
			return;
		}
		if (transform_0.localPosition == vector3_0)
		{
			return;
		}
		transform_0.localPosition = vector3_0;
	}

	// Token: 0x06004F11 RID: 20241 RVA: 0x00033895 File Offset: 0x00031A95
	public static void smethod_31(GameObject gameObject_0, GameObject gameObject_1, bool bool_0)
	{
		if (!gameObject_0)
		{
			return;
		}
		Tk.smethod_32(gameObject_0.transform, (!gameObject_1) ? null : gameObject_1.transform, bool_0);
	}

	// Token: 0x06004F12 RID: 20242 RVA: 0x0014FF44 File Offset: 0x0014E144
	public static void smethod_32(Transform transform_0, Transform transform_1, bool bool_0)
	{
		if (!transform_0)
		{
			return;
		}
		if (bool_0)
		{
			transform_0.transform.parent = transform_1;
		}
		else
		{
			Vector3 localPosition = transform_0.localPosition;
			Quaternion localRotation = transform_0.localRotation;
			Vector3 localScale = transform_0.localScale;
			transform_0.transform.parent = transform_1;
			transform_0.localPosition = localPosition;
			transform_0.localRotation = localRotation;
			transform_0.localScale = localScale;
		}
	}

	// Token: 0x06004F13 RID: 20243 RVA: 0x0014FFA4 File Offset: 0x0014E1A4
	public static GameObject smethod_33(GameObject gameObject_0, string string_0, bool bool_0, bool bool_1 = true)
	{
		if (!gameObject_0)
		{
			return null;
		}
		int childCount = gameObject_0.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = gameObject_0.transform.GetChild(i);
			if (child.name.Equals(string_0, (!bool_0) ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase))
			{
				return child.gameObject;
			}
			if (bool_1)
			{
				GameObject gameObject = Tk.smethod_33(child.gameObject, string_0, bool_0, bool_1);
				if (gameObject)
				{
					return gameObject;
				}
			}
		}
		return null;
	}

	// Token: 0x06004F14 RID: 20244 RVA: 0x0015001C File Offset: 0x0014E21C
	public static GameObject[] smethod_34(GameObject gameObject_0, string string_0, bool bool_0, bool bool_1 = true)
	{
		List<GameObject> list = new List<GameObject>();
		Tk.smethod_35(ref list, gameObject_0, string_0, bool_0, bool_1);
		return list.ToArray();
	}

	// Token: 0x06004F15 RID: 20245 RVA: 0x00150040 File Offset: 0x0014E240
	private static void smethod_35(ref List<GameObject> list_0, GameObject gameObject_0, string string_0, bool bool_0, bool bool_1)
	{
		if (!gameObject_0)
		{
			return;
		}
		int childCount = gameObject_0.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = gameObject_0.transform.GetChild(i);
			if (child.name.Equals(string_0, (!bool_0) ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase))
			{
				list_0.Add(child.gameObject);
			}
			if (bool_1)
			{
				Tk.smethod_35(ref list_0, child.gameObject, string_0, bool_0, bool_1);
			}
		}
	}

	// Token: 0x06004F16 RID: 20246 RVA: 0x001500B4 File Offset: 0x0014E2B4
	public static GameObject smethod_36(GameObject gameObject_0, string string_0, bool bool_0, bool bool_1 = true)
	{
		if (!gameObject_0)
		{
			return null;
		}
		int childCount = gameObject_0.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = gameObject_0.transform.GetChild(i);
			if (child.name.StartsWith(string_0, bool_0, null))
			{
				return child.gameObject;
			}
			if (bool_1)
			{
				GameObject gameObject = Tk.smethod_33(child.gameObject, string_0, bool_0, bool_1);
				if (gameObject)
				{
					return gameObject;
				}
			}
		}
		return null;
	}

	// Token: 0x06004F17 RID: 20247 RVA: 0x00150124 File Offset: 0x0014E324
	public static GameObject[] smethod_37(GameObject gameObject_0, string string_0, bool bool_0, bool bool_1 = true)
	{
		List<GameObject> list = new List<GameObject>();
		Tk.smethod_38(ref list, gameObject_0, string_0, bool_0, bool_1);
		return list.ToArray();
	}

	// Token: 0x06004F18 RID: 20248 RVA: 0x00150148 File Offset: 0x0014E348
	private static void smethod_38(ref List<GameObject> list_0, GameObject gameObject_0, string string_0, bool bool_0, bool bool_1)
	{
		if (!gameObject_0)
		{
			return;
		}
		int childCount = gameObject_0.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = gameObject_0.transform.GetChild(i);
			if (child.name.StartsWith(string_0, bool_0, null))
			{
				list_0.Add(child.gameObject);
			}
			if (bool_1)
			{
				Tk.smethod_38(ref list_0, child.gameObject, string_0, bool_0, bool_1);
			}
		}
	}

	// Token: 0x06004F19 RID: 20249 RVA: 0x001501B4 File Offset: 0x0014E3B4
	public static T smethod_39<T>(GameObject gameObject_0, bool bool_0 = true) where T : Component
	{
		if (!gameObject_0)
		{
			return (T)((object)null);
		}
		int childCount = gameObject_0.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = gameObject_0.transform.GetChild(i);
			T t = child.gameObject.GetComponent<T>();
			if (t)
			{
				return t;
			}
			if (bool_0)
			{
				t = Tk.smethod_39<T>(child.gameObject, bool_0);
				if (t)
				{
					return t;
				}
			}
		}
		return (T)((object)null);
	}

	// Token: 0x06004F1A RID: 20250 RVA: 0x00150238 File Offset: 0x0014E438
	public static void smethod_40<T>(T[] gparam_0, int int_0, int int_1)
	{
		int num = Marshal.SizeOf(typeof(T));
		string text = "{0:X" + num * 2 + "} ";
		string text2 = string.Empty;
		for (int i = 0; i < int_1; i++)
		{
			for (int j = 0; j < int_0; j++)
			{
				text2 += string.Format(text, gparam_0[j + i * int_0]);
			}
			text2 += '\n';
		}
		global::UnityEngine.Debug.Log(text2);
	}

	// Token: 0x06004F1B RID: 20251 RVA: 0x000338BD File Offset: 0x00031ABD
	public static void smethod_41(GameObject gameObject_0)
	{
		Tk.smethod_42(gameObject_0.transform);
	}

	// Token: 0x06004F1C RID: 20252 RVA: 0x000338CA File Offset: 0x00031ACA
	public static void smethod_42(Transform transform_0)
	{
		transform_0.localPosition = Vector3.zero;
		transform_0.localRotation = Quaternion.identity;
		transform_0.localScale = Vector3.one;
	}

	// Token: 0x06004F1D RID: 20253 RVA: 0x001502C4 File Offset: 0x0014E4C4
	public static int smethod_43(params string[] string_0)
	{
		int num = 0;
		for (int i = 0; i < string_0.Length; i++)
		{
			num |= 1 << LayerMask.NameToLayer(string_0[i]);
		}
		return num;
	}

	// Token: 0x06004F1E RID: 20254 RVA: 0x000338ED File Offset: 0x00031AED
	public static int smethod_44(string string_0)
	{
		return LayerMask.NameToLayer(string_0);
	}

	// Token: 0x06004F1F RID: 20255 RVA: 0x000338F5 File Offset: 0x00031AF5
	public static void smethod_45(GameObject gameObject_0, string string_0)
	{
		Tk.smethod_46(gameObject_0, LayerMask.NameToLayer(string_0));
	}

	// Token: 0x06004F20 RID: 20256 RVA: 0x001502F8 File Offset: 0x0014E4F8
	public static void smethod_46(GameObject gameObject_0, int int_0)
	{
		if (!gameObject_0)
		{
			return;
		}
		gameObject_0.layer = int_0;
		int childCount = gameObject_0.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Tk.smethod_46(gameObject_0.transform.GetChild(i).gameObject, int_0);
		}
	}

	// Token: 0x06004F21 RID: 20257 RVA: 0x00150344 File Offset: 0x0014E544
	public static Dictionary<string, GameObject> smethod_47(GameObject gameObject_0, Dictionary<string, GameObject> dictionary_0, bool bool_0)
	{
		if (!gameObject_0)
		{
			return null;
		}
		if (dictionary_0 == null)
		{
			dictionary_0 = new Dictionary<string, GameObject>();
		}
		dictionary_0.Add((!bool_0) ? gameObject_0.name : gameObject_0.name.ToUpper(), gameObject_0);
		int childCount = gameObject_0.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Tk.smethod_47(gameObject_0.transform.GetChild(i).gameObject, dictionary_0, bool_0);
		}
		return dictionary_0;
	}

	// Token: 0x06004F22 RID: 20258 RVA: 0x001503B8 File Offset: 0x0014E5B8
	public static T smethod_48<T>(GameObject gameObject_0) where T : Component
	{
		T component = gameObject_0.GetComponent<T>();
		if (component)
		{
			return component;
		}
		return gameObject_0.AddComponent<T>();
	}

	// Token: 0x06004F23 RID: 20259 RVA: 0x001503E4 File Offset: 0x0014E5E4
	public static GameObject smethod_49(GameObject gameObject_0, string string_0)
	{
		if (!gameObject_0)
		{
			return null;
		}
		Transform transform = gameObject_0.transform.Find(string_0);
		if (transform)
		{
			return transform.gameObject;
		}
		GameObject gameObject = new GameObject(string_0);
		gameObject.transform.parent = gameObject_0.transform;
		Tk.smethod_41(gameObject);
		return gameObject;
	}

	// Token: 0x06004F24 RID: 20260 RVA: 0x00033903 File Offset: 0x00031B03
	public static void smethod_50(global::UnityEngine.Object object_0)
	{
		if (!object_0)
		{
			return;
		}
		if (Application.isEditor && !Application.isPlaying)
		{
			global::UnityEngine.Object.DestroyImmediate(object_0);
		}
		else
		{
			global::UnityEngine.Object.Destroy(object_0);
		}
	}

	// Token: 0x04003B53 RID: 15187
	public const string NativeDll = "TkNativeDll";
}
