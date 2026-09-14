using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000A96 RID: 2710
public static class GameObjectExtensions
{
	// Token: 0x06004951 RID: 18769 RVA: 0x00130AC0 File Offset: 0x0012ECC0
	public static T smethod_0<T>(this GameObject gameObject_0) where T : Component
	{
		Transform transform = gameObject_0.transform;
		while (transform != null)
		{
			T component = transform.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			transform = transform.parent;
		}
		return (T)((object)null);
	}

	// Token: 0x06004952 RID: 18770 RVA: 0x00130B04 File Offset: 0x0012ED04
	public static T[] smethod_1<T>(this GameObject gameObject_0) where T : Component
	{
		List<T> list = new List<T>();
		Transform transform = gameObject_0.transform;
		while (transform != null)
		{
			T component = transform.GetComponent<T>();
			if (component != null)
			{
				list.Add(component);
			}
			transform = transform.parent;
		}
		return list.ToArray();
	}

	// Token: 0x06004953 RID: 18771 RVA: 0x00130B54 File Offset: 0x0012ED54
	public static T[] smethod_2<T>(this GameObject gameObject_0, string string_0) where T : Component
	{
		List<T> list = new List<T>();
		if (gameObject_0.CompareTag(string_0) && gameObject_0.GetComponent<T>() != null)
		{
			list.Add(gameObject_0.GetComponent<T>());
		}
		foreach (object obj in gameObject_0.transform)
		{
			Transform transform = (Transform)obj;
			list.AddRange(transform.gameObject.smethod_2<T>(string_0));
		}
		return list.ToArray();
	}

	// Token: 0x06004954 RID: 18772 RVA: 0x00130BF0 File Offset: 0x0012EDF0
	public static T[] smethod_3<T>(this GameObject gameObject_0, int int_0) where T : Component
	{
		List<T> list = new List<T>();
		if (gameObject_0.layer == int_0 && gameObject_0.GetComponent<T>() != null)
		{
			list.Add(gameObject_0.GetComponent<T>());
		}
		foreach (object obj in gameObject_0.transform)
		{
			Transform transform = (Transform)obj;
			list.AddRange(transform.gameObject.smethod_3<T>(int_0));
		}
		return list.ToArray();
	}

	// Token: 0x06004955 RID: 18773 RVA: 0x00130C8C File Offset: 0x0012EE8C
	public static void smethod_4<T>(this GameObject gameObject_0, bool bool_0) where T : MonoBehaviour
	{
		if (gameObject_0.GetComponent<T>() != null)
		{
			T component = gameObject_0.GetComponent<T>();
			component.enabled = bool_0;
		}
		foreach (object obj in gameObject_0.transform)
		{
			Transform transform = (Transform)obj;
			transform.gameObject.smethod_4<T>(bool_0);
		}
	}

	// Token: 0x06004956 RID: 18774 RVA: 0x00130D14 File Offset: 0x0012EF14
	public static void smethod_5(this GameObject gameObject_0, int int_0)
	{
		DebugUtils.Log(LogCategory.Framework, "SetLayerRecursively");
		gameObject_0.layer = int_0;
		foreach (object obj in gameObject_0.transform)
		{
			Transform transform = (Transform)obj;
			transform.gameObject.smethod_5(int_0);
		}
	}

	// Token: 0x06004957 RID: 18775 RVA: 0x00130D88 File Offset: 0x0012EF88
	public static void smethod_6(this GameObject gameObject_0, bool bool_0)
	{
		Collider[] componentsInChildren = gameObject_0.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			collider.enabled = bool_0;
		}
	}

	// Token: 0x06004958 RID: 18776 RVA: 0x00130DB8 File Offset: 0x0012EFB8
	public static int smethod_7(this GameObject gameObject_0, int int_0 = -1)
	{
		if (int_0 == -1)
		{
			int_0 = gameObject_0.layer;
		}
		int num = 0;
		for (int i = 0; i < 32; i++)
		{
			num |= ((!Physics.GetIgnoreLayerCollision(int_0, i)) ? 1 : 0) << i;
		}
		return num;
	}
}
