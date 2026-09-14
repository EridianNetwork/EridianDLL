using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000153 RID: 339
public class MergedMeshManager : MonoBehaviour
{
	// Token: 0x060007DC RID: 2012 RVA: 0x00008212 File Offset: 0x00006412
	private void Start()
	{
		if (this.m_inited)
		{
			MergedMeshManager.m_hashcodeToId[this.m_hashcode].Add(base.gameObject.GetInstanceID());
		}
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x00058AEC File Offset: 0x00056CEC
	public static void smethod_0(GameObject gameObject_0, uint uint_0, bool bool_0 = false)
	{
		if (!MergedMeshManager.smethod_2(gameObject_0, uint_0))
		{
			return;
		}
		if (MergedMeshManager.m_hashcodeToId.ContainsKey(uint_0))
		{
			MergedMeshManager.m_hashcodeToId[uint_0].Add(gameObject_0.GetInstanceID());
		}
		else
		{
			MergedMeshManager.m_hashcodeToId.Add(uint_0, new List<int> { gameObject_0.GetInstanceID() });
			BuildingKitLoader.smethod_0(uint_0, gameObject_0.GetComponent<SkinnedMeshRenderer>().sharedMesh);
		}
		MergedMeshManager mergedMeshManager = gameObject_0.AddComponent<MergedMeshManager>();
		if (bool_0)
		{
			mergedMeshManager.method_0(uint_0);
		}
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x0000823C File Offset: 0x0000643C
	public void method_0(uint uint_0)
	{
		this.m_hashcode = uint_0;
		this.m_inited = true;
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x00058B68 File Offset: 0x00056D68
	public static void smethod_1()
	{
		List<uint> list = new List<uint>();
		Dictionary<uint, List<int>>.Enumerator enumerator = m_hashcodeToId.GetEnumerator();
		while (enumerator.MoveNext())
		{
			uint key = enumerator.Current.Key;
			if (enumerator.Current.Value.Count == 0)
			{
				BuildingKitLoader.smethod_1(key);
				list.Add(key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			m_hashcodeToId.Remove(list[i]);
		}
	}
	// Token: 0x060007E0 RID: 2016 RVA: 0x0000824C File Offset: 0x0000644C
	private void OnDestroy()
	{
		if (MergedMeshManager.m_hashcodeToId.ContainsKey(this.m_hashcode))
		{
			MergedMeshManager.m_hashcodeToId[this.m_hashcode].Remove(base.gameObject.GetInstanceID());
		}
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x00058BEC File Offset: 0x00056DEC
	private static bool smethod_2(GameObject gameObject_0, uint uint_0)
	{
		SkinnedMeshRenderer component = gameObject_0.GetComponent<SkinnedMeshRenderer>();
		if (component == null)
		{
			DebugUtils.Log(LogCategory.Framework, "Merge mesh manager can only hold instances with skinned mesh renderer component");
			return false;
		}
		if (component.sharedMesh == null)
		{
			DebugUtils.Log(LogCategory.Framework, "A mesh must be assigned to the skinned mesh renderer bound to merged mesh manager");
			return false;
		}
		List<int> list;
		if (MergedMeshManager.m_hashcodeToId.TryGetValue(uint_0, out list) && list.Contains(gameObject_0.GetInstanceID()))
		{
			DebugUtils.Log(LogCategory.Framework, "That instance is already referenced into the merged mesh manager");
			return false;
		}
		return true;
	}

	// Token: 0x040006D9 RID: 1753
	private static Dictionary<uint, List<int>> m_hashcodeToId = new Dictionary<uint, List<int>>();

	// Token: 0x040006DA RID: 1754
	private uint m_hashcode;

	// Token: 0x040006DB RID: 1755
	private bool m_inited;
}
