using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x020000E2 RID: 226
public class ResourcesLoader
{
	// Token: 0x06000572 RID: 1394 RVA: 0x00050334 File Offset: 0x0004E534
	public static global::UnityEngine.Object smethod_0(string string_0)
	{
		global::UnityEngine.Object @object = Resources.Load(string_0);
		if (@object != null)
		{
			ResourcesLoader.s_objList.Add(@object);
		}
		else
		{
			DebugUtils.LogError(LogCategory.Framework, "Obj null with Resources.Load: " + string_0);
		}
		return @object;
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x00050374 File Offset: 0x0004E574
	public static global::UnityEngine.Object smethod_1(string string_0, Type type_0)
	{
		global::UnityEngine.Object @object = Resources.Load(string_0, type_0);
		if (@object != null)
		{
			ResourcesLoader.s_objList.Add(@object);
		}
		else
		{
			DebugUtils.LogError(LogCategory.Framework, "Obj null with Resources.Load: " + string_0);
		}
		return @object;
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x000503B4 File Offset: 0x0004E5B4
	public static global::UnityEngine.Object[] smethod_2(string string_0)
	{
		global::UnityEngine.Object[] array = Resources.LoadAll(string_0);
		if (array != null)
		{
			ResourcesLoader.s_objList.UnionWith(array);
		}
		else
		{
			DebugUtils.LogError(LogCategory.Framework, "Obj null with Resources.LoadAll: " + string_0);
		}
		return array;
	}

	// Token: 0x06000575 RID: 1397 RVA: 0x000503EC File Offset: 0x0004E5EC
	public static global::UnityEngine.Object[] smethod_3(string string_0, Type type_0)
	{
		global::UnityEngine.Object[] array = Resources.LoadAll(string_0, type_0);
		if (array != null)
		{
			ResourcesLoader.s_objList.UnionWith(array);
		}
		else
		{
			DebugUtils.LogError(LogCategory.Framework, "Obj null with Resources.LoadAll: " + string_0);
		}
		return array;
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x00050424 File Offset: 0x0004E624
	public static global::UnityEngine.Object[] smethod_4(BaseAssetBundle baseAssetBundle_0)
	{
		global::UnityEngine.Object[] array = baseAssetBundle_0.vmethod_3();
		if (array != null)
		{
			ResourcesLoader.s_objList.UnionWith(array);
		}
		else
		{
			DebugUtils.LogError(LogCategory.Framework, "Obj null with BaseAssetBundle.LoadAll");
		}
		return array;
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x00050454 File Offset: 0x0004E654
	public static void smethod_5()
	{
		foreach (global::UnityEngine.Object @object in ResourcesLoader.s_objList)
		{
			if (@object is Texture || @object is AudioClip || @object is Mesh || @object is Material || @object is AnimationClip || @object is Shader)
			{
				Resources.UnloadAsset(@object);
			}
		}
		ResourcesLoader.s_objList.Clear();
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x000504E0 File Offset: 0x0004E6E0
	public static void smethod_6(global::UnityEngine.Object object_0)
	{
		ResourcesLoader.s_objList.Remove(object_0);
		if (object_0 is Texture || object_0 is AudioClip || object_0 is Mesh || object_0 is Material || object_0 is AnimationClip || object_0 is Shader)
		{
			Resources.UnloadAsset(object_0);
		}
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x00050530 File Offset: 0x0004E730
	public static GameObject smethod_7(string string_0, Vector3 vector3_0, Quaternion quaternion_0)
	{
		GameObject gameObject = null;
		if (string_0.Contains("|"))
		{
			string[] array = string_0.Split(new char[] { '|' });
			if (array[0] == "BKT")
			{
				BuildingKitRender buildingKitRender = new BuildingKitRender(array[1], array[2]);
				gameObject = buildingKitRender.method_6();
				gameObject.transform.position = vector3_0;
				gameObject.transform.rotation = quaternion_0;
			}
		}
		else
		{
			GameObject gameObject2 = ResourcesLoader.smethod_8(string_0);
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(gameObject2, vector3_0, quaternion_0);
		}
		return gameObject;
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x000505B0 File Offset: 0x0004E7B0
	public static GameObject smethod_8(string string_0)
	{
		GameObject gameObject = null;
		if (string_0.Contains("|"))
		{
			string[] array = string_0.Split(new char[] { '|' });
			if (array[0] == "BKT")
			{
				BuildingKitRender buildingKitRender = new BuildingKitRender(array[1], array[2]);
				gameObject = (GameObject)buildingKitRender.method_8();
			}
		}
		else if (!NetworkingPeer.UsePrefabCache || !NetworkingPeer.PrefabCache.TryGetValue(string_0, out gameObject))
		{
			gameObject = (GameObject)ResourcesLoader.smethod_1(string_0, typeof(GameObject));
			if (NetworkingPeer.UsePrefabCache)
			{
				NetworkingPeer.PrefabCache.Add(string_0, gameObject);
			}
		}
		return gameObject;
	}

	// Token: 0x040004DC RID: 1244
	private static HashSet<global::UnityEngine.Object> s_objList = new HashSet<global::UnityEngine.Object>();
}
