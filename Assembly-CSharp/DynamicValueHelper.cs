using System;
using System.Reflection;
using UnityEngine;

// Token: 0x020000FF RID: 255
internal class DynamicValueHelper<T>
{
	// Token: 0x060005E4 RID: 1508 RVA: 0x00051B6C File Offset: 0x0004FD6C
	public static Func<T> smethod_0(global::UnityEngine.Object object_0, string string_0)
	{
		Func<T> func = null;
		Type type = object_0.GetType();
		MethodInfo method = type.GetMethod(string_0, Type.EmptyTypes, null);
		if (method != null && method.ReturnType == typeof(T) && method.IsPublic && !method.IsStatic)
		{
			func = Delegate.CreateDelegate(typeof(Func<T>), object_0, method, false) as Func<T>;
		}
		return func;
	}
}
