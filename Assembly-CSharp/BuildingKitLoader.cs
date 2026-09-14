using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000146 RID: 326
public abstract class BuildingKitLoader
{
	// Token: 0x0600077E RID: 1918 RVA: 0x00007E2B File Offset: 0x0000602B
	public static void smethod_0(uint uint_0, object object_0)
	{
		BuildingKitLoader.m_cache.Add(uint_0, object_0);
	}

	// Token: 0x0600077F RID: 1919 RVA: 0x00057664 File Offset: 0x00055864
	public static void smethod_1(uint uint_0)
	{
		object obj;
		if (BuildingKitLoader.m_cache.TryGetValue(uint_0, out obj))
		{
			BuildingKitLoader.m_cache.Remove(uint_0);
			global::UnityEngine.Object @object = obj as global::UnityEngine.Object;
			if (@object is Texture || @object is AudioClip || @object is Mesh || @object is Material || @object is AnimationClip || @object is Shader)
			{
				Resources.UnloadAsset(@object);
			}
		}
	}

	// Token: 0x06000780 RID: 1920 RVA: 0x000576CC File Offset: 0x000558CC
	public static void smethod_2()
	{
		foreach (KeyValuePair<uint, object> keyValuePair in BuildingKitLoader.m_cache)
		{
			global::UnityEngine.Object @object = keyValuePair.Value as global::UnityEngine.Object;
			if (@object is Texture || @object is AudioClip || @object is Mesh || @object is Material || @object is AnimationClip || @object is Shader)
			{
				Resources.UnloadAsset(@object);
			}
		}
		BuildingKitLoader.m_cache.Clear();
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x00007E39 File Offset: 0x00006039
	private uint method_0()
	{
		if (this.m_hashcode == 0U)
		{
			this.m_hashcode = this.vmethod_0() + Utility.smethod_1(base.GetType().ToString());
		}
		return this.m_hashcode;
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x00057744 File Offset: 0x00055944
	private object method_1(uint uint_0)
	{
		object obj = this.vmethod_1();
		BuildingKitLoader.m_cache.Add(uint_0, obj);
		return obj;
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x00057768 File Offset: 0x00055968
	public object method_2()
	{
		uint num = this.method_0();
		object obj = null;
		if (!BuildingKitLoader.m_cache.TryGetValue(num, out obj))
		{
			obj = this.method_1(num);
		}
		return obj;
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x00057798 File Offset: 0x00055998
	public void method_3()
	{
		uint num = this.method_0();
		BuildingKitLoader.smethod_1(num);
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x000577B4 File Offset: 0x000559B4
	public bool method_4()
	{
		uint num = this.method_0();
		return BuildingKitLoader.m_cache.ContainsKey(num);
	}

	// Token: 0x06000786 RID: 1926
	protected abstract uint vmethod_0();

	// Token: 0x06000787 RID: 1927
	protected abstract object vmethod_1();

	// Token: 0x040006B2 RID: 1714
	private static Dictionary<uint, object> m_cache = new Dictionary<uint, object>();

	// Token: 0x040006B3 RID: 1715
	private uint m_hashcode;
}
