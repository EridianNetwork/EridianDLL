using System;
using System.Collections.Generic;
using UnityEngine;
using Valkyrie.VPaint;

// Token: 0x02000B83 RID: 2947
public class VPaintStorageCache : ScriptableObject
{
	// Token: 0x06004FC5 RID: 20421 RVA: 0x00152718 File Offset: 0x00150918
	public VPaintGroup method_0(string string_0, bool bool_0 = true)
	{
		VPaintGroup vpaintGroup = new GameObject(string_0).AddComponent<VPaintGroup>();
		VPaintLayerStack vpaintLayerStack = this.layerStack.Clone();
		List<VPaintObject> list = new List<VPaintObject>();
		list.AddRange(this.vmethod_0());
		foreach (VPaintLayer vpaintLayer in vpaintLayerStack.layers)
		{
			foreach (VPaintVertexData vpaintVertexData in vpaintLayer.paintData)
			{
				VPaintStorageObject vpaintStorageObject = vpaintVertexData.colorer as VPaintStorageObject;
				VPaintObject vpaintObject = this.vmethod_1(vpaintStorageObject);
				if (vpaintObject)
				{
					vpaintVertexData.vpaintObject = vpaintObject;
					if (!list.Contains(vpaintObject))
					{
						list.Add(vpaintObject);
					}
				}
			}
		}
		if (bool_0)
		{
			foreach (VPaintVertexCache vpaintVertexCache in this.vertexCache)
			{
				VPaintObject vpaintObject2 = this.vmethod_1(vpaintVertexCache.obj as VPaintStorageObject);
				if (vpaintObject2)
				{
					vpaintGroup.vertexCache.Add(new VPaintVertexCache
					{
						vpaintObject = vpaintObject2,
						vertices = vpaintVertexCache.vertices
					});
				}
			}
		}
		VPaintStorageCacheInstance vpaintStorageCacheInstance = vpaintGroup.gameObject.AddComponent<VPaintStorageCacheInstance>();
		vpaintStorageCacheInstance.vpaintStorageCache = this;
		vpaintStorageCacheInstance.vpaintGroup = vpaintGroup;
		foreach (VPaintObject vpaintObject3 in list)
		{
			vpaintGroup.method_3(vpaintObject3);
		}
		vpaintGroup.layerStack = vpaintLayerStack;
		return vpaintGroup;
	}

	// Token: 0x06004FC6 RID: 20422 RVA: 0x00003727 File Offset: 0x00001927
	public virtual VPaintObject[] vmethod_0()
	{
		return null;
	}

	// Token: 0x06004FC7 RID: 20423 RVA: 0x00003727 File Offset: 0x00001927
	public virtual VPaintObject vmethod_1(VPaintStorageObject vpaintStorageObject_0)
	{
		return null;
	}

	// Token: 0x04003BF1 RID: 15345
	public VPaintLayerStack layerStack = new VPaintLayerStack();

	// Token: 0x04003BF2 RID: 15346
	[HideInInspector]
	[SerializeField]
	public List<VPaintStorageObject> storageObjects = new List<VPaintStorageObject>();

	// Token: 0x04003BF3 RID: 15347
	[SerializeField]
	[HideInInspector]
	public List<VPaintVertexCache> vertexCache = new List<VPaintVertexCache>();
}
