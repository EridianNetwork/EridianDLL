using System;
using UnityEngine;

// Token: 0x02000AA3 RID: 2723
public class TerrainSurface
{
	// Token: 0x060049CA RID: 18890 RVA: 0x0013242C File Offset: 0x0013062C
	public static float[] smethod_0(Vector3 vector3_0)
	{
		Terrain activeTerrain = Terrain.activeTerrain;
		TerrainData terrainData = activeTerrain.terrainData;
		Vector3 position = activeTerrain.transform.position;
		int num = (int)((vector3_0.x - position.x) / terrainData.size.x * (float)terrainData.alphamapWidth);
		int num2 = (int)((vector3_0.z - position.z) / terrainData.size.z * (float)terrainData.alphamapHeight);
		float[,,] alphamaps = terrainData.GetAlphamaps(num, num2, 1, 1);
		float[] array = new float[alphamaps.GetUpperBound(2) + 1];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = alphamaps[0, 0, i];
		}
		return array;
	}

	// Token: 0x060049CB RID: 18891 RVA: 0x001324E8 File Offset: 0x001306E8
	public static int smethod_1(Vector3 vector3_0)
	{
		float[] array = TerrainSurface.smethod_0(vector3_0);
		float num = 0f;
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > num)
			{
				num2 = i;
				num = array[i];
			}
		}
		return num2;
	}

	// Token: 0x060049CC RID: 18892 RVA: 0x00132520 File Offset: 0x00130720
	public static string smethod_2(Vector3 vector3_0)
	{
		int num = TerrainSurface.smethod_1(vector3_0);
		Terrain activeTerrain = Terrain.activeTerrain;
		TerrainData terrainData = activeTerrain.terrainData;
		return terrainData.splatPrototypes[num].texture.name;
	}
}
