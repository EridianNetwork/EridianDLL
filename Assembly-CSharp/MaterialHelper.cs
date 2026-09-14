using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005C6 RID: 1478
public static class MaterialHelper
{
	// Token: 0x0600256C RID: 9580 RVA: 0x000B3ED4 File Offset: 0x000B20D4
	public static void smethod_0(GameObject gameObject_0)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		MaterialHelper.smethod_4(gameObject_0, "Custom/BOL_Charactor_BRDF_Ambient_NoLP", new List<MaterialHelper.ShaderParameter>
		{
			new MaterialHelper.ShaderParameter
			{
				Type = MaterialHelper.ParameterType.PT_Color,
				Name = "custom_ambient",
				ColorValue = Color.white
			}
		});
	}

	// Token: 0x0600256D RID: 9581 RVA: 0x000B3F2C File Offset: 0x000B212C
	private static void smethod_1(GameObject gameObject_0)
	{
		MaterialHelper.smethod_4(gameObject_0, "Custom/BOL_Wpn_MaskReflect_Ambient_NoLP", new List<MaterialHelper.ShaderParameter>
		{
			new MaterialHelper.ShaderParameter
			{
				Type = MaterialHelper.ParameterType.PT_Color,
				Name = "custom_ambient",
				ColorValue = Color.white
			}
		});
	}

	// Token: 0x0600256E RID: 9582 RVA: 0x00019794 File Offset: 0x00017994
	public static void smethod_2(GameObject gameObject_0)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		MaterialHelper.smethod_1(gameObject_0);
	}

	// Token: 0x0600256F RID: 9583 RVA: 0x00019794 File Offset: 0x00017994
	public static void smethod_3(GameObject gameObject_0)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		MaterialHelper.smethod_1(gameObject_0);
	}

	// Token: 0x06002570 RID: 9584 RVA: 0x000B3F7C File Offset: 0x000B217C
	private static void smethod_4(GameObject gameObject_0, string string_0, List<MaterialHelper.ShaderParameter> list_0)
	{
		SkinnedMeshRenderer component = gameObject_0.GetComponent<SkinnedMeshRenderer>();
		if (component)
		{
			MaterialHelper.smethod_5(component, string_0, list_0);
		}
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in gameObject_0.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			if (skinnedMeshRenderer)
			{
				MaterialHelper.smethod_5(skinnedMeshRenderer, string_0, list_0);
			}
		}
	}

	// Token: 0x06002571 RID: 9585 RVA: 0x000B3FCC File Offset: 0x000B21CC
	private static void smethod_5(SkinnedMeshRenderer skinnedMeshRenderer_0, string string_0, List<MaterialHelper.ShaderParameter> list_0)
	{
		Material[] array = new Material[skinnedMeshRenderer_0.materials.Length];
		for (int i = 0; i < skinnedMeshRenderer_0.materials.Length; i++)
		{
			array[i] = new Material(Shader.Find(string_0));
			foreach (MaterialHelper.ShaderParameter shaderParameter in list_0)
			{
				if (shaderParameter.Type == MaterialHelper.ParameterType.PT_Float)
				{
					array[i].SetFloat(shaderParameter.Name, shaderParameter.FloatValue);
				}
				else if (shaderParameter.Type == MaterialHelper.ParameterType.PT_Color)
				{
					array[i].SetColor(shaderParameter.Name, shaderParameter.ColorValue);
				}
			}
			array[i].CopyPropertiesFromMaterial(skinnedMeshRenderer_0.materials[i]);
			skinnedMeshRenderer_0.materials[i].name = array[i].name;
			skinnedMeshRenderer_0.materials[i].shader = array[i].shader;
			skinnedMeshRenderer_0.materials[i].CopyPropertiesFromMaterial(array[i]);
			global::UnityEngine.Object.Destroy(array[i]);
		}
	}

	// Token: 0x020005C7 RID: 1479
	private enum ParameterType
	{
		// Token: 0x04001AD1 RID: 6865
		PT_Float,
		// Token: 0x04001AD2 RID: 6866
		PT_Color
	}

	// Token: 0x020005C8 RID: 1480
	private struct ShaderParameter
	{
		// Token: 0x04001AD3 RID: 6867
		public MaterialHelper.ParameterType Type;

		// Token: 0x04001AD4 RID: 6868
		public string Name;

		// Token: 0x04001AD5 RID: 6869
		public float FloatValue;

		// Token: 0x04001AD6 RID: 6870
		public Color ColorValue;
	}
}
