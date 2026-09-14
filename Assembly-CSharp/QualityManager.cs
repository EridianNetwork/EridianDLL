using System;
using System.Collections.Generic;
using System.IO;
using ns0;
using UnityEngine;

// Token: 0x02000A9E RID: 2718
public class QualityManager : MonoSingleton<QualityManager>
{
	// Token: 0x0600497F RID: 18815 RVA: 0x000300F8 File Offset: 0x0002E2F8
	public QualityManager()
	{
		this.lightShadows = new List<LightShadows>();
		this.mLights = new List<Light>();
		this.method_40();
	}

	// Token: 0x06004980 RID: 18816 RVA: 0x00131870 File Offset: 0x0012FA70
	public void method_0()
	{
		this.lightShadows.Clear();
		this.mLights.Clear();
		Light[] array = (Light[])global::UnityEngine.Object.FindObjectsOfType(typeof(Light));
		for (int i = 0; i < array.Length; i++)
		{
			this.lightShadows.Add(array[i].shadows);
			this.mLights.Add(array[i]);
		}
		this.mShadowSetting = QualityManager.SceneShadowSetting.SceneSetting;
	}

	// Token: 0x06004981 RID: 18817 RVA: 0x001318E0 File Offset: 0x0012FAE0
	private bool method_1()
	{
		if (this.mCamera != null)
		{
			return true;
		}
		foreach (Camera camera in Camera.allCameras)
		{
			if (camera.name == "FpsCamera(Clone)")
			{
				this.mCamera = camera;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004982 RID: 18818 RVA: 0x0003011C File Offset: 0x0002E31C
	public RenderingPath method_2()
	{
		if (this.method_1())
		{
			return this.mCamera.actualRenderingPath;
		}
		return RenderingPath.UsePlayerSettings;
	}

	// Token: 0x06004983 RID: 18819 RVA: 0x00030133 File Offset: 0x0002E333
	public void method_3(RenderingPath renderingPath_0)
	{
		if (this.method_1())
		{
			this.mCamera.renderingPath = renderingPath_0;
		}
	}

	// Token: 0x06004984 RID: 18820 RVA: 0x00030149 File Offset: 0x0002E349
	public int method_4()
	{
		if (this.method_1())
		{
			return this.mCamera.GetComponents<MonoBehaviour>().Length;
		}
		return 0;
	}

	// Token: 0x06004985 RID: 18821 RVA: 0x00131934 File Offset: 0x0012FB34
	public string method_5(int int_0)
	{
		if (int_0 > this.method_4() - 1)
		{
			return string.Empty;
		}
		string text = this.mCamera.GetComponents<MonoBehaviour>()[int_0].ToString();
		int num = text.LastIndexOf('(');
		int num2 = text.LastIndexOf(')');
		return text.Substring(num + 1, num2 - num - 1);
	}

	// Token: 0x06004986 RID: 18822 RVA: 0x00030162 File Offset: 0x0002E362
	public bool method_6(int int_0)
	{
		return int_0 <= this.method_4() - 1 && this.mCamera.GetComponents<MonoBehaviour>()[int_0].enabled;
	}

	// Token: 0x06004987 RID: 18823 RVA: 0x00131988 File Offset: 0x0012FB88
	public void method_7(int int_0)
	{
		if (int_0 > this.method_4() - 1)
		{
			return;
		}
		MonoBehaviour monoBehaviour = this.mCamera.GetComponents<MonoBehaviour>()[int_0];
		monoBehaviour.enabled = !monoBehaviour.enabled;
	}

	// Token: 0x06004988 RID: 18824 RVA: 0x001319C0 File Offset: 0x0012FBC0
	public void method_8(bool bool_0)
	{
		for (int i = 0; i < this.method_4(); i++)
		{
			MonoBehaviour monoBehaviour = this.mCamera.GetComponents<MonoBehaviour>()[i];
			monoBehaviour.enabled = bool_0;
		}
	}

	// Token: 0x06004989 RID: 18825 RVA: 0x00030183 File Offset: 0x0002E383
	public int method_9()
	{
		return QualitySettings.antiAliasing;
	}

	// Token: 0x0600498A RID: 18826 RVA: 0x0003018A File Offset: 0x0002E38A
	public void method_10(int int_0)
	{
		QualitySettings.antiAliasing = int_0;
	}

	// Token: 0x0600498B RID: 18827 RVA: 0x00030192 File Offset: 0x0002E392
	public int method_11()
	{
		return QualitySettings.pixelLightCount;
	}

	// Token: 0x0600498C RID: 18828 RVA: 0x00030199 File Offset: 0x0002E399
	public void method_12()
	{
		QualitySettings.pixelLightCount++;
	}

	// Token: 0x0600498D RID: 18829 RVA: 0x000301A7 File Offset: 0x0002E3A7
	public void method_13()
	{
		if (QualitySettings.pixelLightCount > 0)
		{
			QualitySettings.pixelLightCount--;
		}
	}

	// Token: 0x0600498E RID: 18830 RVA: 0x000301BD File Offset: 0x0002E3BD
	public AnisotropicFiltering method_14()
	{
		return QualitySettings.anisotropicFiltering;
	}

	// Token: 0x0600498F RID: 18831 RVA: 0x000301C4 File Offset: 0x0002E3C4
	public void method_15(AnisotropicFiltering anisotropicFiltering_0)
	{
		QualitySettings.anisotropicFiltering = anisotropicFiltering_0;
	}

	// Token: 0x06004990 RID: 18832 RVA: 0x000301CC File Offset: 0x0002E3CC
	public int method_16()
	{
		return QualitySettings.masterTextureLimit;
	}

	// Token: 0x06004991 RID: 18833 RVA: 0x000301D3 File Offset: 0x0002E3D3
	public void method_17()
	{
		if (QualitySettings.masterTextureLimit > 0)
		{
			QualitySettings.masterTextureLimit--;
		}
	}

	// Token: 0x06004992 RID: 18834 RVA: 0x000301E9 File Offset: 0x0002E3E9
	public void method_18()
	{
		if (QualitySettings.masterTextureLimit < 3)
		{
			QualitySettings.masterTextureLimit++;
		}
	}

	// Token: 0x06004993 RID: 18835 RVA: 0x000301FF File Offset: 0x0002E3FF
	public bool method_19()
	{
		return QualitySettings.softVegetation;
	}

	// Token: 0x06004994 RID: 18836 RVA: 0x00030206 File Offset: 0x0002E406
	public void method_20(bool bool_0)
	{
		QualitySettings.softVegetation = !QualitySettings.softVegetation;
	}

	// Token: 0x06004995 RID: 18837 RVA: 0x001319F4 File Offset: 0x0012FBF4
	public void method_21()
	{
		for (int i = 0; i < this.mLights.Count; i++)
		{
			this.mLights[i].shadows = this.lightShadows[i];
		}
		this.mShadowSetting = QualityManager.SceneShadowSetting.SceneSetting;
	}

	// Token: 0x06004996 RID: 18838 RVA: 0x00131A3C File Offset: 0x0012FC3C
	public void method_22(LightShadows lightShadows_0)
	{
		Light[] array = (Light[])global::UnityEngine.Object.FindObjectsOfType(typeof(Light));
		for (int i = 0; i < array.Length; i++)
		{
			array[i].shadows = lightShadows_0;
		}
		if (lightShadows_0 == LightShadows.None)
		{
			this.mShadowSetting = QualityManager.SceneShadowSetting.NoShadows;
		}
		else if (lightShadows_0 == LightShadows.Hard)
		{
			this.mShadowSetting = QualityManager.SceneShadowSetting.HardShadows;
		}
		else if (lightShadows_0 == LightShadows.Soft)
		{
			this.mShadowSetting = QualityManager.SceneShadowSetting.SoftShadows;
		}
	}

	// Token: 0x06004997 RID: 18839 RVA: 0x00030215 File Offset: 0x0002E415
	public QualityManager.SceneShadowSetting method_23()
	{
		return this.mShadowSetting;
	}

	// Token: 0x06004998 RID: 18840 RVA: 0x0003021D File Offset: 0x0002E41D
	public ShadowProjection method_24()
	{
		return QualitySettings.shadowProjection;
	}

	// Token: 0x06004999 RID: 18841 RVA: 0x00030224 File Offset: 0x0002E424
	public void method_25(ShadowProjection shadowProjection_0)
	{
		QualitySettings.shadowProjection = shadowProjection_0;
	}

	// Token: 0x0600499A RID: 18842 RVA: 0x0003022C File Offset: 0x0002E42C
	public int method_26()
	{
		return QualitySettings.shadowCascades;
	}

	// Token: 0x0600499B RID: 18843 RVA: 0x00030233 File Offset: 0x0002E433
	public void method_27(int int_0)
	{
		if (int_0 == 1 || int_0 == 2 || int_0 == 4)
		{
			QualitySettings.shadowCascades = int_0;
		}
	}

	// Token: 0x0600499C RID: 18844 RVA: 0x00030247 File Offset: 0x0002E447
	public float method_28()
	{
		return QualitySettings.shadowDistance;
	}

	// Token: 0x0600499D RID: 18845 RVA: 0x0003024E File Offset: 0x0002E44E
	public void method_29()
	{
		QualitySettings.shadowDistance += 5f;
	}

	// Token: 0x0600499E RID: 18846 RVA: 0x00030260 File Offset: 0x0002E460
	public void method_30()
	{
		if (QualitySettings.shadowDistance - 5f >= 0f)
		{
			QualitySettings.shadowDistance -= 5f;
		}
	}

	// Token: 0x0600499F RID: 18847 RVA: 0x00030284 File Offset: 0x0002E484
	public BlendWeights method_31()
	{
		return QualitySettings.blendWeights;
	}

	// Token: 0x060049A0 RID: 18848 RVA: 0x0003028B File Offset: 0x0002E48B
	public void method_32(BlendWeights blendWeights_0)
	{
		QualitySettings.blendWeights = blendWeights_0;
	}

	// Token: 0x060049A1 RID: 18849 RVA: 0x00030293 File Offset: 0x0002E493
	public int method_33()
	{
		return QualitySettings.vSyncCount;
	}

	// Token: 0x060049A2 RID: 18850 RVA: 0x0003029A File Offset: 0x0002E49A
	public void method_34(int int_0)
	{
		if (int_0 == 0 || int_0 == 1 || int_0 == 2)
		{
			QualitySettings.vSyncCount = int_0;
		}
	}

	// Token: 0x060049A3 RID: 18851 RVA: 0x000302AD File Offset: 0x0002E4AD
	public float method_35()
	{
		return QualitySettings.lodBias;
	}

	// Token: 0x060049A4 RID: 18852 RVA: 0x000302B4 File Offset: 0x0002E4B4
	public void method_36()
	{
		QualitySettings.lodBias += 0.1f;
	}

	// Token: 0x060049A5 RID: 18853 RVA: 0x000302C6 File Offset: 0x0002E4C6
	public void method_37()
	{
		if (QualitySettings.lodBias - 0.1f >= 0f)
		{
			QualitySettings.lodBias -= 0.1f;
		}
	}

	// Token: 0x060049A6 RID: 18854 RVA: 0x000302EA File Offset: 0x0002E4EA
	public int method_38()
	{
		return QualitySettings.maximumLODLevel;
	}

	// Token: 0x060049A7 RID: 18855 RVA: 0x000302F1 File Offset: 0x0002E4F1
	public void method_39(int int_0)
	{
		if (int_0 == 0 || int_0 == 1 || int_0 == 2)
		{
			QualitySettings.maximumLODLevel = int_0;
		}
	}

	// Token: 0x060049A8 RID: 18856 RVA: 0x00131A9C File Offset: 0x0012FC9C
	private void method_40()
	{
		TextAsset textAsset = Resources.Load("Quality/BaseCompat", typeof(TextAsset)) as TextAsset;
		if (textAsset != null)
		{
			StringReader stringReader = new StringReader(textAsset.text);
			string text = "[AppCompatGPU-0x" + SystemInfo.graphicsDeviceVendorID.ToString("X4") + "]";
			List<string> list = new List<string>();
			for (string text2 = stringReader.ReadLine(); text2 != null; text2 = stringReader.ReadLine())
			{
				list.Add(text2);
			}
			int num = -1;
			for (int i = 0; i < list.Count; i++)
			{
				if (text == list[i])
				{
					num = i;
					break;
				}
			}
			bool flag = false;
			if (num != -1)
			{
				list.RemoveRange(0, num);
				int num2 = -1;
				for (int j = 1; j < list.Count; j++)
				{
					if (list[j].StartsWith("[AppCompatGPU"))
					{
						num2 = j;
					}
				}
				if (num2 != -1)
				{
					list.RemoveRange(num2, list.Count - num2);
				}
				string value = "0x" + SystemInfo.graphicsDeviceID.ToString("X4");
				for (int k = 0; k < list.Count; k++)
				{
					if (list[k].StartsWith(value))
					{
						int num3 = list[k].IndexOf('=');
						int num4 = list[k].IndexOf(',');
						string s = list[k].Substring(num3 + 1, num4 - num3 - 1);
						flag = true;
						int num5 = int.Parse(s);
						if (num5 < 2)
						{
							QualitySettings.SetQualityLevel(0);
						}
						else if (num5 < 4)
						{
							QualitySettings.SetQualityLevel(1);
						}
						else
						{
							QualitySettings.SetQualityLevel(2);
						}
					}
				}
			}
			if (!flag)
			{
				method_41();
			}
		}
		m_qualityLevel = (QualityLevel)QualitySettings.GetQualityLevel();
	}
	// Token: 0x060049A9 RID: 18857 RVA: 0x00131C70 File Offset: 0x0012FE70
	private void method_41()
	{
		if (SystemInfo.graphicsShaderLevel >= 30 && SystemInfo.graphicsMemorySize >= 256 && SystemInfo.graphicsPixelFillrate >= 2000)
		{
			if (SystemInfo.graphicsDeviceVendorID == 32902)
			{
				QualitySettings.SetQualityLevel(0);
			}
			else if (SystemInfo.graphicsDeviceVendorID == 4098)
			{
				if (SystemInfo.graphicsMemorySize > 512)
				{
					QualitySettings.SetQualityLevel(2);
				}
				else
				{
					QualitySettings.SetQualityLevel(1);
				}
			}
			else if (SystemInfo.graphicsDeviceVendorID == 4318)
			{
				if (SystemInfo.graphicsDeviceID > 4096)
				{
					QualitySettings.SetQualityLevel(2);
				}
				else if (SystemInfo.graphicsDeviceID < 1536)
				{
					QualitySettings.SetQualityLevel(0);
				}
				else
				{
					QualitySettings.SetQualityLevel(1);
				}
			}
			else
			{
				QualitySettings.SetQualityLevel(0);
			}
		}
		else
		{
			QualitySettings.SetQualityLevel(0);
		}
	}

	// Token: 0x060049AA RID: 18858 RVA: 0x00131D30 File Offset: 0x0012FF30
	private void method_42(GameObject gameObject_0, bool bool_0)
	{
		GlobalFog component = gameObject_0.GetComponent<GlobalFog>();
		if (component != null)
		{
			component.enabled = bool_0;
		}
	}

	// Token: 0x060049AB RID: 18859 RVA: 0x00131D54 File Offset: 0x0012FF54
	private void method_43(GameObject gameObject_0, bool bool_0)
	{
		SSAOEffect component = gameObject_0.GetComponent<SSAOEffect>();
		if (component != null)
		{
			component.enabled = bool_0;
		}
	}

	// Token: 0x060049AC RID: 18860 RVA: 0x00131D78 File Offset: 0x0012FF78
	private void method_44(GameObject gameObject_0, bool bool_0)
	{
		AntialiasingAsPostEffect component = gameObject_0.GetComponent<AntialiasingAsPostEffect>();
		if (component != null)
		{
			component.enabled = bool_0;
		}
	}

	// Token: 0x060049AD RID: 18861 RVA: 0x00131D9C File Offset: 0x0012FF9C
	public void method_45(GameObject gameObject_0)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		if (this.m_qualityLevel == QualityManager.QualityLevel.QualityLevel_High)
		{
			this.method_42(gameObject_0, true);
			this.method_43(gameObject_0, true);
			this.method_44(gameObject_0, true);
		}
		else if (this.m_qualityLevel == QualityManager.QualityLevel.QualityLevel_Medium)
		{
			this.method_42(gameObject_0, true);
			this.method_43(gameObject_0, false);
			this.method_44(gameObject_0, false);
		}
		else if (this.m_qualityLevel == QualityManager.QualityLevel.QualityLevel_Low)
		{
			this.method_42(gameObject_0, false);
			this.method_43(gameObject_0, false);
			this.method_44(gameObject_0, false);
		}
	}

	// Token: 0x060049AE RID: 18862 RVA: 0x00131E1C File Offset: 0x0013001C
	private void method_46(Camera camera_0)
	{
		if (camera_0 != null)
		{
			SSAOEffect component = camera_0.GetComponent<SSAOEffect>();
			if (component != null)
			{
				component.enabled = !component.enabled;
			}
			BOL_Outline component2 = camera_0.GetComponent<BOL_Outline>();
			if (component2 != null)
			{
				component2.enabled = !component2.enabled;
			}
			DepthOfFieldScatter component3 = camera_0.GetComponent<DepthOfFieldScatter>();
			if (component3 != null)
			{
				component3.enabled = !component3.enabled;
			}
			AntialiasingAsPostEffect component4 = camera_0.GetComponent<AntialiasingAsPostEffect>();
			if (component4 != null)
			{
				component4.enabled = false;
			}
		}
	}

	// Token: 0x060049AF RID: 18863 RVA: 0x00131EAC File Offset: 0x001300AC
	public void method_47()
	{
		if (MonoSingleton<Session>.Instance != null)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer != null)
			{
				Entity entity = localPlayer.GetEntity();
				if (entity != null)
				{
					Camera componentInChildren = entity.GetComponentInChildren<Camera>();
					this.method_46(componentInChildren);
				}
			}
		}
	}

	// Token: 0x060049B0 RID: 18864 RVA: 0x00131EF8 File Offset: 0x001300F8
	public bool method_48()
	{
		if (this.method_1())
		{
			AntialiasingAsPostEffect component = this.mCamera.GetComponent<AntialiasingAsPostEffect>();
			return component != null;
		}
		return false;
	}

	// Token: 0x060049B1 RID: 18865 RVA: 0x00131F24 File Offset: 0x00130124
	public void method_49()
	{
		if (this.method_48() && !this.method_1())
		{
			return;
		}
		AntialiasingAsPostEffect antialiasingAsPostEffect = this.mCamera.gameObject.AddComponent<AntialiasingAsPostEffect>();
		antialiasingAsPostEffect.shaderFXAAII = Shader.Find("Hidden/FXAA II");
		antialiasingAsPostEffect.shaderFXAAIII = Shader.Find("Hidden/FXAA III (Console)");
		antialiasingAsPostEffect.shaderFXAAPreset2 = Shader.Find("Hidden/FXAA Preset 2");
		antialiasingAsPostEffect.shaderFXAAPreset3 = Shader.Find("Hidden/FXAA Preset 3");
		antialiasingAsPostEffect.nfaaShader = Shader.Find("Hidden/NFAA");
		antialiasingAsPostEffect.ssaaShader = Shader.Find("Hidden/SSAA");
		antialiasingAsPostEffect.dlaaShader = Shader.Find("Hidden/DLAA");
		if (antialiasingAsPostEffect)
		{
			antialiasingAsPostEffect.mode = AAMode.FXAA1PresetB;
		}
	}

	// Token: 0x060049B2 RID: 18866 RVA: 0x00131FD4 File Offset: 0x001301D4
	public AAMode method_50()
	{
		if (!this.method_48())
		{
			return AAMode.FXAA2;
		}
		AntialiasingAsPostEffect component = this.mCamera.GetComponent<AntialiasingAsPostEffect>();
		if (component)
		{
			return component.mode;
		}
		return AAMode.FXAA2;
	}

	// Token: 0x060049B3 RID: 18867 RVA: 0x00132008 File Offset: 0x00130208
	public void method_51(AAMode aamode_0)
	{
		if (!this.method_48())
		{
			return;
		}
		AntialiasingAsPostEffect component = this.mCamera.GetComponent<AntialiasingAsPostEffect>();
		if (component)
		{
			component.mode = aamode_0;
		}
	}

	// Token: 0x060049B4 RID: 18868 RVA: 0x00030304 File Offset: 0x0002E504
	public QualityManager.QualityLevel method_52()
	{
		return this.m_qualityLevel;
	}

	// Token: 0x060049B5 RID: 18869 RVA: 0x0003030C File Offset: 0x0002E50C
	public string method_53()
	{
		if (this.m_qualityLevel == QualityManager.QualityLevel.QualityLevel_Low)
		{
			return "Low";
		}
		if (this.m_qualityLevel == QualityManager.QualityLevel.QualityLevel_Medium)
		{
			return "Medium";
		}
		return "High";
	}

	// Token: 0x060049B6 RID: 18870 RVA: 0x00030304 File Offset: 0x0002E504
	public int method_54()
	{
		return (int)this.m_qualityLevel;
	}

	// Token: 0x060049B7 RID: 18871 RVA: 0x00030330 File Offset: 0x0002E530
	public void method_55()
	{
		if (this.method_54() + 1 >= 3)
		{
			return;
		}
		this.m_qualityLevel++;
		QualitySettings.SetQualityLevel(this.method_54());
	}

	// Token: 0x060049B8 RID: 18872 RVA: 0x00030357 File Offset: 0x0002E557
	public void method_56()
	{
		if (this.method_54() <= 0)
		{
			return;
		}
		this.m_qualityLevel--;
		QualitySettings.SetQualityLevel(this.method_54());
	}

	// Token: 0x040035DE RID: 13790
	private Camera mCamera;

	// Token: 0x040035DF RID: 13791
	private List<LightShadows> lightShadows;

	// Token: 0x040035E0 RID: 13792
	private List<Light> mLights;

	// Token: 0x040035E1 RID: 13793
	private QualityManager.SceneShadowSetting mShadowSetting;

	// Token: 0x040035E2 RID: 13794
	private QualityManager.QualityLevel m_qualityLevel;

	// Token: 0x02000A9F RID: 2719
	public enum SceneShadowSetting
	{
		// Token: 0x040035E4 RID: 13796
		SceneSetting,
		// Token: 0x040035E5 RID: 13797
		NoShadows,
		// Token: 0x040035E6 RID: 13798
		HardShadows,
		// Token: 0x040035E7 RID: 13799
		SoftShadows
	}

	// Token: 0x02000AA0 RID: 2720
	public enum QualityLevel
	{
		// Token: 0x040035E9 RID: 13801
		QualityLevel_Low,
		// Token: 0x040035EA RID: 13802
		QualityLevel_Medium,
		// Token: 0x040035EB RID: 13803
		QualityLevel_High,
		// Token: 0x040035EC RID: 13804
		QualityLevel_Count
	}
}
