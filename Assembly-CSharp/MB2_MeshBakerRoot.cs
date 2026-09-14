using System;
using System.Collections.Generic;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

// Token: 0x02000ADE RID: 2782
public class MB2_MeshBakerRoot : MonoBehaviour
{
	// Token: 0x06004B86 RID: 19334 RVA: 0x00003727 File Offset: 0x00001927
	public virtual List<GameObject> vmethod_0()
	{
		return null;
	}

	// Token: 0x06004B87 RID: 19335 RVA: 0x00139794 File Offset: 0x00137994
	public static bool smethod_0(MB2_MeshBakerRoot mb2_MeshBakerRoot_0, MB_ObjsToCombineTypes mb_ObjsToCombineTypes_0)
	{
		if (mb2_MeshBakerRoot_0.textureBakeResults == null)
		{
			DebugUtils.LogError(LogCategory.Tool, "Need to set textureBakeResults");
			return false;
		}
		if (!(mb2_MeshBakerRoot_0 is MB2_TextureBaker))
		{
			MB2_TextureBaker component = mb2_MeshBakerRoot_0.GetComponent<MB2_TextureBaker>();
			if (component != null && component.textureBakeResults != mb2_MeshBakerRoot_0.textureBakeResults)
			{
				DebugUtils.LogWarning(LogCategory.Tool, "textureBakeResults on this component is not the same as the textureBakeResults on the MB2_TextureBaker.");
			}
		}
		List<GameObject> list = mb2_MeshBakerRoot_0.vmethod_0();
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject = list[i];
			if (gameObject == null)
			{
				DebugUtils.LogError(LogCategory.Tool, "The list of objects to combine contains a null at position." + i + " Select and use [shift] delete to remove");
				return false;
			}
			for (int j = i + 1; j < list.Count; j++)
			{
				if (list[i] == list[j])
				{
					DebugUtils.LogError(LogCategory.Tool, "The list of objects to combine contains duplicates.");
					return false;
				}
			}
			if (MB_Utility.GetGOMaterials(gameObject) == null)
			{
				DebugUtils.LogError(LogCategory.Tool, "Object " + gameObject + " in the list of objects to be combined does not have a material");
				return false;
			}
			if (MB_Utility.GetMesh(gameObject) == null)
			{
				DebugUtils.LogError(LogCategory.Tool, "Object " + gameObject + " in the list of objects to be combined does not have a mesh");
				return false;
			}
		}
		if (mb2_MeshBakerRoot_0.textureBakeResults.doMultiMaterial && !MB2_MeshBakerRoot.smethod_1(mb2_MeshBakerRoot_0))
		{
			return false;
		}
		List<GameObject> list2 = list;
		if (mb2_MeshBakerRoot_0 is MB2_MeshBaker)
		{
			MB2_TextureBaker component2 = mb2_MeshBakerRoot_0.GetComponent<MB2_TextureBaker>();
			if (((MB2_MeshBaker)mb2_MeshBakerRoot_0).useObjsToMeshFromTexBaker && component2 != null)
			{
				list2 = component2.objsToMesh;
			}
			if (list2 == null || list2.Count == 0)
			{
				DebugUtils.LogError(LogCategory.Tool, "No meshes to combine. Please assign some meshes to combine.");
				return false;
			}
		}
		return true;
	}

	// Token: 0x06004B88 RID: 19336 RVA: 0x00139930 File Offset: 0x00137B30
	private static bool smethod_1(MB2_MeshBakerRoot mb2_MeshBakerRoot_0)
	{
		List<GameObject> list = mb2_MeshBakerRoot_0.vmethod_0();
		for (int i = 0; i < list.Count; i++)
		{
			Mesh mesh = MB_Utility.GetMesh(list[i]);
			if (MB_Utility.doSubmeshesShareVertsOrTris(mesh) != 0)
			{
				DebugUtils.LogWarning(LogCategory.Tool, "Object " + list[i] + " in the list of objects to combine has overlapping submeshes (submeshes share vertices). If the UVs associated with the shared vertices are important then this bake may not work. If you are using multiple materials then this object can only be combined with objects that use the exact same set of textures (each atlas contains one texture). There may be other undesirable side affects as well. Mesh Master, available in the asset store can fix overlapping submeshes.");
				return true;
			}
		}
		return true;
	}

	// Token: 0x040036F6 RID: 14070
	[HideInInspector]
	public MB2_TextureBakeResults textureBakeResults;
}
