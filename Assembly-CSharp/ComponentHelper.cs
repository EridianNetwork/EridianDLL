using System;
using System.Reflection;
using UnityEngine;

// Token: 0x020000D0 RID: 208
public class ComponentHelper
{
	// Token: 0x060004E1 RID: 1249 RVA: 0x0004C00C File Offset: 0x0004A20C
	public static void smethod_0(GameObject gameObject_0, GameObject gameObject_1)
	{
		foreach (Component component in gameObject_0.GetComponents<Component>())
		{
			if (!gameObject_1.GetComponent(component.GetType()))
			{
				Component component2 = gameObject_1.AddComponent(component.GetType());
				ComponentHelper.smethod_1(component, component2);
			}
		}
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x0004C05C File Offset: 0x0004A25C
	public static void smethod_1(Component component_0, Component component_1)
	{
		if (component_0 != null && component_1 != null)
		{
			foreach (FieldInfo fieldInfo in component_0.GetType().GetFields())
			{
				if (!fieldInfo.IsStatic && !fieldInfo.IsInitOnly && !fieldInfo.IsLiteral)
				{
					fieldInfo.SetValue(component_1, fieldInfo.GetValue(component_0));
				}
			}
		}
	}
}
