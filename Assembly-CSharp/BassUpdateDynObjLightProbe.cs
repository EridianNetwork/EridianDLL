using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200058A RID: 1418
public class BassUpdateDynObjLightProbe : MonoBehaviour
{
	// Token: 0x06002452 RID: 9298 RVA: 0x000AD60C File Offset: 0x000AB80C
	private void Start()
	{
		if (this.m_testLevelName != null && MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff == null && MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff == null)
		{
			string text = "LightProbe/" + this.m_testLevelName.name;
			string text2 = text + "/farlightProbes";
			string text3 = text + "/nearlightProbes";
			TextAsset textAsset = ResourcesLoader.smethod_1(text2, typeof(TextAsset)) as TextAsset;
			TextAsset textAsset2 = ResourcesLoader.smethod_1(text3, typeof(TextAsset)) as TextAsset;
			if (textAsset != null && textAsset2 != null)
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				Stream stream = null;
				try
				{
					stream = new MemoryStream(textAsset.bytes);
					MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
				}
				catch (Exception ex)
				{
					DebugUtils.LogError(LogCategory.Graphics, ex.ToString());
					DebugUtils.LogError(LogCategory.Graphics, "LinSH : Read " + text2 + " file error!");
				}
				finally
				{
					stream.Close();
					stream = null;
				}
				try
				{
					stream = new MemoryStream(textAsset2.bytes);
					MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
				}
				catch (Exception ex2)
				{
					DebugUtils.LogError(LogCategory.Graphics, ex2.ToString());
					DebugUtils.LogError(LogCategory.Graphics, "LinSH: Read " + text3 + " file error!");
				}
				finally
				{
					stream.Close();
					stream = null;
				}
				if (MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff != null && MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff != null)
				{
					if (MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff.Length != MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff.Length && MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff.Length != LightmapSettings.lightProbes.coefficients.Length)
					{
						DebugUtils.LogError(LogCategory.Graphics, "LinSH: light probe number is not match near/far/lightmapSetting!");
						MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff = (MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff = null);
					}
					else
					{
						MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes = global::UnityEngine.Object.Instantiate(LightmapSettings.lightProbes) as LightProbes;
					}
				}
				else
				{
					DebugUtils.LogError(LogCategory.Graphics, "LinSH: Can't create the light probe instance");
				}
			}
			else
			{
				DebugUtils.LogError(LogCategory.Graphics, "Light Probe missing");
			}
		}
	}

	// Token: 0x06002453 RID: 9299 RVA: 0x00018CE5 File Offset: 0x00016EE5
	private void OnWillRenderObject()
	{
		this.method_0();
	}

	// Token: 0x06002454 RID: 9300 RVA: 0x000AD858 File Offset: 0x000ABA58
	private void method_0()
	{
		if (this.m_fpsCamera == null && MonoSingleton<Session>.Instance != null)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer != null)
			{
				Entity entity = localPlayer.GetEntity();
				if (entity != null)
				{
					Camera componentInChildren = entity.GetComponentInChildren<Camera>();
					if (componentInChildren != null)
					{
						this.m_fpsCamera = componentInChildren.gameObject;
					}
				}
			}
		}
		Renderer renderer = base.renderer;
		Material material = renderer.material;
		if (MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes != null && MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff != null && MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff != null && material.HasProperty("_Tkc_SHAr") && this.m_fpsCamera != null)
		{
			Vector3 position = base.transform.position;
			Vector3 position2 = this.m_fpsCamera.transform.position;
			float num = Vector3.Distance(position, position2);
			float shadowDistance = QualitySettings.shadowDistance;
			float num2 = 3f;
			float[] array = new float[27];
			float num3 = shadowDistance + num2;
			float num4;
			if (num > num3)
			{
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.coefficients = MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff;
				num4 = 0f;
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array);
			}
			else if (num < shadowDistance)
			{
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.coefficients = MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff;
				num4 = 1f;
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array);
			}
			else
			{
				float[] array2 = new float[27];
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.coefficients = MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff;
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array2);
				float[] array3 = new float[27];
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.coefficients = MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff;
				MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array3);
				float num5 = (num3 - num) / num2;
				for (int i = 0; i < 27; i++)
				{
					array[i] = array2[i] * num5 + array3[i] * (1f - num5);
				}
				num4 = 1f - num5;
			}
			float[][] array4 = new float[][]
			{
				new float[]
				{
					array[0],
					array[3],
					array[6],
					array[9],
					array[12],
					array[15],
					array[18],
					array[21],
					array[24]
				},
				new float[]
				{
					array[1],
					array[4],
					array[7],
					array[10],
					array[13],
					array[16],
					array[19],
					array[22],
					array[25]
				},
				new float[]
				{
					array[2],
					array[5],
					array[8],
					array[11],
					array[14],
					array[17],
					array[20],
					array[23],
					array[26]
				}
			};
			Vector4[] array5 = new Vector4[]
			{
				Vector4.zero,
				Vector4.zero,
				Vector4.zero
			};
			Vector4[] array6 = new Vector4[]
			{
				Vector4.zero,
				Vector4.zero,
				Vector4.zero
			};
			for (int j = 0; j < 3; j++)
			{
				array5[j].x = -BassUpdateDynObjLightProbe.s_fC1 * array4[j][3];
				array5[j].y = -BassUpdateDynObjLightProbe.s_fC1 * array4[j][1];
				array5[j].z = BassUpdateDynObjLightProbe.s_fC1 * array4[j][2];
				array5[j].w = BassUpdateDynObjLightProbe.s_fC0 * array4[j][0] - BassUpdateDynObjLightProbe.s_fC3 * array4[j][6];
			}
			for (int j = 0; j < 3; j++)
			{
				array6[j].x = BassUpdateDynObjLightProbe.s_fC2 * array4[j][4];
				array6[j].y = -BassUpdateDynObjLightProbe.s_fC2 * array4[j][5];
				array6[j].z = 3f * BassUpdateDynObjLightProbe.s_fC3 * array4[j][6];
				array6[j].w = -BassUpdateDynObjLightProbe.s_fC2 * array4[j][7];
			}
			Vector4 zero = Vector4.zero;
			zero.x = BassUpdateDynObjLightProbe.s_fC4 * array4[0][8];
			zero.y = BassUpdateDynObjLightProbe.s_fC4 * array4[1][8];
			zero.z = BassUpdateDynObjLightProbe.s_fC4 * array4[2][8];
			zero.w = num4;
			material.SetVector("_Tkc_SHAr", array5[0]);
			material.SetVector("_Tkc_SHAg", array5[1]);
			material.SetVector("_Tkc_SHAb", array5[2]);
			material.SetVector("_Tkc_SHBr", array6[0]);
			material.SetVector("_Tkc_SHBg", array6[1]);
			material.SetVector("_Tkc_SHBb", array6[2]);
			material.SetVector("_Tkc_SHC", zero);
			material.SetColor("_AmbintLight", RenderSettings.ambientLight);
		}
	}

	// Token: 0x04001918 RID: 6424
	public GameObject m_fpsCamera;

	// Token: 0x04001919 RID: 6425
	public global::UnityEngine.Object m_testLevelName;

	// Token: 0x0400191A RID: 6426
	private static float s_fSqrtPI = (float)Math.Sqrt(3.141592653589793);

	// Token: 0x0400191B RID: 6427
	private static float s_fC0 = 1f / (2f * BassUpdateDynObjLightProbe.s_fSqrtPI);

	// Token: 0x0400191C RID: 6428
	private static float s_fC1 = (float)Math.Sqrt(3.0) / (3f * BassUpdateDynObjLightProbe.s_fSqrtPI);

	// Token: 0x0400191D RID: 6429
	private static float s_fC2 = (float)Math.Sqrt(15.0) / (8f * BassUpdateDynObjLightProbe.s_fSqrtPI);

	// Token: 0x0400191E RID: 6430
	private static float s_fC3 = (float)Math.Sqrt(5.0) / (16f * BassUpdateDynObjLightProbe.s_fSqrtPI);

	// Token: 0x0400191F RID: 6431
	private static float s_fC4 = 0.5f * BassUpdateDynObjLightProbe.s_fC2;
}
