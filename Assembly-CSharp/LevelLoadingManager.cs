using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Core;
using ns0;
using pumpkin.swf;
using UnityEngine;
using XsdSettings;

// Token: 0x02000289 RID: 649
public class LevelLoadingManager : MonoSingleton<LevelLoadingManager>
{
	// Token: 0x06000DF6 RID: 3574 RVA: 0x0000CA26 File Offset: 0x0000AC26
	public string method_0()
	{
		return this.m_cameraEffect;
	}

	// Token: 0x06000DF7 RID: 3575 RVA: 0x000714D8 File Offset: 0x0006F6D8
	public float method_1()
	{
		return this.m_stepController.method_2();
	}

	// Token: 0x06000DF8 RID: 3576 RVA: 0x0000CA2E File Offset: 0x0000AC2E
	public string method_2()
	{
		return this.m_stepController.method_3();
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x0000CA3B File Offset: 0x0000AC3B
	public bool method_3()
	{
		return this.m_stepController.method_1();
	}

	// Token: 0x06000DFA RID: 3578 RVA: 0x0000CA48 File Offset: 0x0000AC48
	public bool method_4()
	{
		return this.m_isCanceled;
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x0000CA50 File Offset: 0x0000AC50
	public void method_5()
	{
		this.m_isCanceled = true;
		this.m_stepController.method_0();
	}

	// Token: 0x06000DFC RID: 3580 RVA: 0x000714F4 File Offset: 0x0006F6F4
	private void Start()
	{
		LevelLoadingManager.MapsDescXml mapsDescXml_ = LevelLoadingManager.MapsDescXml.MapsDescXml_0;
		if (mapsDescXml_ != null)
		{
			DebugUtils.Log(LogCategory.Framework, "MapsDescXml constructed");
		}
	}

	// Token: 0x06000DFD RID: 3581 RVA: 0x0000CA64 File Offset: 0x0000AC64
	private void Update()
	{
		this.m_stepController.Update();
	}

	// Token: 0x06000DFE RID: 3582 RVA: 0x00071518 File Offset: 0x0006F718
	private void method_6(BaseAssetBundle baseAssetBundle_0, string string_0)
	{
		DebugUtils.Log(LogCategory.Framework, string_0);
		global::UnityEngine.Object @object = baseAssetBundle_0.vmethod_2("BUILD_NUMBER", typeof(TextAsset));
		if (@object != null)
		{
			TextAsset textAsset = @object as TextAsset;
			DebugUtils.Log(LogCategory.Framework, textAsset.text);
		}
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00071560 File Offset: 0x0006F760
	public bool method_7(string string_0, FuncBase funcBase_0 = null, object object_0 = null)
	{
		this.m_isCanceled = false;
		if (string.IsNullOrEmpty(string_0))
		{
			DebugUtils.Log(LogCategory.Framework, "LoadMap - Nothing to load");
			return false;
		}
		this.m_callback = funcBase_0;
		this.m_callbackParam = object_0;
		LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_2(string_0);
		this.m_stepController.Start();
		return true;
	}

	// Token: 0x04000C9F RID: 3231
	private LevelLoadingManager.LevelLoadingStepController m_stepController = new LevelLoadingManager.LevelLoadingStepController();

	// Token: 0x04000CA0 RID: 3232
	private FuncBase m_callback;

	// Token: 0x04000CA1 RID: 3233
	private object m_callbackParam;

	// Token: 0x04000CA2 RID: 3234
	private XmlNodeList m_assetBundleList;

	// Token: 0x04000CA3 RID: 3235
	public float m_farClip = 3500f;

	// Token: 0x04000CA4 RID: 3236
	private string m_cameraEffect = string.Empty;

	// Token: 0x04000CA5 RID: 3237
	private XmlNode m_previousLevel;

	// Token: 0x04000CA6 RID: 3238
	private TextAsset m_nearLigthProb;

	// Token: 0x04000CA7 RID: 3239
	private TextAsset m_farLigthProb;

	// Token: 0x04000CA8 RID: 3240
	public float[] m_farLightProCoeff;

	// Token: 0x04000CA9 RID: 3241
	public float[] m_nearLightProCoeff;

	// Token: 0x04000CAA RID: 3242
	public LightProbes m_customLightProbes;

	// Token: 0x04000CAB RID: 3243
	public Cubemap m_levelCubemap;

	// Token: 0x04000CAC RID: 3244
	public GameObject m_levelEffectCamera;

	// Token: 0x04000CAD RID: 3245
	private bool m_isCanceled;

	// Token: 0x04000CAE RID: 3246
	public float m_startLoadingTime;

	// Token: 0x0200028A RID: 650
	public class MapsDescXml
	{
		// Token: 0x06000E00 RID: 3584 RVA: 0x000715B0 File Offset: 0x0006F7B0
		private MapsDescXml()
		{
			string text = "Maps/MapsDesc";
			string text2 = null;
			try
			{
				string text3 = Path.Combine(Application.dataPath, "../overrides/mapdesc_override.xml");
				if (File.Exists(text3))
				{
					text2 = File.ReadAllText(text3);
					DebugUtils.Log(LogCategory.Framework, "MapsDescXml: using external override " + text3);
				}
			}
			catch (Exception ex)
			{
				DebugUtils.LogError(LogCategory.Framework, "MapsDescXml: override load failed: " + ex.Message);
				text2 = null;
			}
			if (text2 != null)
			{
				this.m_xmlDoc = new XmlDocument();
				this.m_xmlDoc.LoadXml(text2);
				return;
			}
			TextAsset textAsset = ResourcesLoader.smethod_0(text) as TextAsset;
			if (textAsset != null)
			{
				this.m_xmlDoc = new XmlDocument();
				if (this.m_xmlDoc != null)
				{
					this.m_xmlDoc.LoadXml(textAsset.text);
					return;
				}
			}
			else
			{
				DebugUtils.LogError(LogCategory.Framework, "Could not load Map Desc:" + text);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000E01 RID: 3585 RVA: 0x0000CA71 File Offset: 0x0000AC71
		public static LevelLoadingManager.MapsDescXml MapsDescXml_0
		{
			get
			{
				if (LevelLoadingManager.MapsDescXml.s_instance == null)
				{
					LevelLoadingManager.MapsDescXml.s_instance = new LevelLoadingManager.MapsDescXml();
				}
				return LevelLoadingManager.MapsDescXml.s_instance;
			}
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x0000CA89 File Offset: 0x0000AC89
		public XmlDocument method_0()
		{
			return this.m_xmlDoc;
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x0000CA91 File Offset: 0x0000AC91
		public XmlNode method_1()
		{
			return this.m_levelLoadingNode;
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00071690 File Offset: 0x0006F890
		public void method_2(string string_0)
		{
			XmlNodeList elementsByTagName = this.m_xmlDoc.GetElementsByTagName("Map");
			this.m_levelLoadingNode = null;
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				if (elementsByTagName[i].Attributes["name"].Value.ToLower() == string_0.ToLower() || (MonoSingleton<AppManager>.Instance.m_offlineMode && elementsByTagName[i].SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value.ToLower() == string_0.ToLower()))
				{
					this.m_levelLoadingNode = elementsByTagName[i];
					return;
				}
			}
		}

		// Token: 0x04000CAF RID: 3247
		private static LevelLoadingManager.MapsDescXml s_instance;

		// Token: 0x04000CB0 RID: 3248
		private XmlDocument m_xmlDoc;

		// Token: 0x04000CB1 RID: 3249
		private XmlNode m_levelLoadingNode;
	}

	// Token: 0x0200028B RID: 651
	private class LevelLoadingStepController
	{
		// Token: 0x06000E06 RID: 3590 RVA: 0x0000CA99 File Offset: 0x0000AC99
		public void method_0()
		{
			DebugUtils.Log(LogCategory.Framework, "Cancel Loading");
			this.m_curStep = this.m_steps.Count;
			MonoSingleton<AssetBundleManager>.Instance.method_3();
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0000CAC1 File Offset: 0x0000ACC1
		public bool method_1()
		{
			return this.m_steps != null;
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00071738 File Offset: 0x0006F938
		public float method_2()
		{
			float num = 0f;
			if (this.m_steps != null)
			{
				for (int i = 0; i < this.m_steps.Count; i++)
				{
					num += this.m_steps[i].m_weight * this.m_steps[i].m_loadingProgress;
				}
			}
			return num;
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00071790 File Offset: 0x0006F990
		public string method_3()
		{
			if (this.m_steps != null && this.m_curStep >= 0 && this.m_curStep < this.m_steps.Count)
			{
				return this.m_steps[this.m_curStep].ToString();
			}
			return "Not Loading";
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x000717E0 File Offset: 0x0006F9E0
		public void Start()
		{
			this.m_steps = new List<LevelLoadingManager.LevelLoadingStep>();
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_Init(0f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_DownloadAssetBundle(0.6f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_LoadPlayerAudio(0f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_PreLoadPlayerBuildingKit(0f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_LoadMapSetting(0f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_LoadResourceDependencyBundle(0.1f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_PreLoadNpcResources(0.05f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_PreLoadWeapon(0.05f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_SyncLocalPlayer(0f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_UI(0f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_LoadLevelBundle(0.05f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_LoadLevel(0.1f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_LoadLevelDataBundle(0.05f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_GenerateWeaponsData(0f));
			this.m_steps.Add(new LevelLoadingManager.LevelLoadingStep_EndLoading(0f));
			this.m_curStep = 0;
			if (this.m_curStep < this.m_steps.Count)
			{
				this.m_steps[this.m_curStep].vmethod_1();
				this.m_steps[this.m_curStep].m_startTime = Time.time;
			}
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00071980 File Offset: 0x0006FB80
		public void Update()
		{
			float time = Time.time;
			if (this.m_steps != null)
			{
				if (this.m_curStep < this.m_steps.Count)
				{
					if (this.m_steps[this.m_curStep].vmethod_2())
					{
						this.m_steps[this.m_curStep].vmethod_3();
						this.m_steps[this.m_curStep].m_loadingProgress = 1f;
						this.m_curStep++;
						if (this.m_curStep < this.m_steps.Count)
						{
							this.m_steps[this.m_curStep].vmethod_1();
							this.m_steps[this.m_curStep].m_startTime = Time.time;
						}
					}
					else
					{
						float num = this.m_steps[this.m_curStep].vmethod_0();
						if (Time.time - this.m_steps[this.m_curStep].m_startTime > num)
						{
							DebugUtils.LogError(LogCategory.Framework, string.Concat(new object[]
							{
								"LevelLoadingStepController.Update - More than [",
								num,
								"s] on [",
								this.m_steps[this.m_curStep].GetType(),
								"]"
							}));
							MonoSingleton<LevelLoadingManager>.Instance.method_5();
							this.m_steps[this.m_curStep].vmethod_3();
							this.m_steps[this.m_curStep].m_loadingProgress = 1f;
							this.m_curStep++;
							if (this.m_curStep < this.m_steps.Count)
							{
								this.m_steps[this.m_curStep].vmethod_1();
								this.m_steps[this.m_curStep].m_startTime = Time.time;
							}
						}
					}
				}
				else
				{
					this.m_steps = null;
				}
			}
			if (Time.time - time > 5f)
			{
				DebugUtils.LogError(LogCategory.Framework, "LevelLoadingStepController.Update - Freeze more than 5sec on [" + this.m_steps[this.m_curStep].GetType() + "]");
			}
		}

		// Token: 0x04000CB2 RID: 3250
		private List<LevelLoadingManager.LevelLoadingStep> m_steps;

		// Token: 0x04000CB3 RID: 3251
		private int m_curStep;
	}

	// Token: 0x0200028C RID: 652
	private abstract class LevelLoadingStep
	{
		// Token: 0x06000E0C RID: 3596 RVA: 0x0000CACF File Offset: 0x0000ACCF
		public LevelLoadingStep(float float_0)
		{
			this.m_weight = float_0;
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x0000CADE File Offset: 0x0000ACDE
		public virtual float vmethod_0()
		{
			return 60f;
		}

		// Token: 0x06000E0E RID: 3598
		public abstract void vmethod_1();

		// Token: 0x06000E0F RID: 3599
		public abstract bool vmethod_2();

		// Token: 0x06000E10 RID: 3600
		public abstract void vmethod_3();

		// Token: 0x06000E11 RID: 3601 RVA: 0x00071BB0 File Offset: 0x0006FDB0
		protected List<string> method_0()
		{
			List<string> list = new List<string>(MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList.Count);
			int i = 0;
			while (i < MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList.Count)
			{
				XmlAttribute xmlAttribute = MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[i].Attributes["name"];
				XmlAttribute xmlAttribute2 = MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[i].Attributes["type"];
				XmlAttribute xmlAttribute3 = MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[i].Attributes["behaviour"];
				if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
				{
					list.Add(xmlAttribute.Value);
					goto IL_0126;
				}
				if (xmlAttribute3 == null || !(xmlAttribute3.Value == "light_pillar"))
				{
					if (xmlAttribute2.Value == "Map")
					{
						list.Add("host_" + MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[i].Attributes["name"].Value);
						goto IL_0126;
					}
					list.Add(MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[i].Attributes["name"].Value);
					goto IL_0126;
				}
				IL_015C:
				i++;
				continue;
				IL_0126:
				if (xmlAttribute3 != null && xmlAttribute3.Value == "light_pillar")
				{
					string text = xmlAttribute.Value.Replace(".assetbundle", "_cl.assetbundle");
					list.Add(text);
					goto IL_015C;
				}
				goto IL_015C;
			}
			return list;
		}

		// Token: 0x04000CB4 RID: 3252
		public float m_startTime;

		// Token: 0x04000CB5 RID: 3253
		public float m_weight;

		// Token: 0x04000CB6 RID: 3254
		public float m_loadingProgress;
	}

	// Token: 0x0200028D RID: 653
	private class LevelLoadingStep_Init : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E12 RID: 3602 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_Init(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00071D34 File Offset: 0x0006FF34
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_Init.EnterStep [" + Time.time + "]");
			MonoSingleton<LevelLoadingManager>.Instance.m_startLoadingTime = Time.realtimeSinceStartup;
			MergedMeshManager.smethod_1();
			XmlNode previousLevel = MonoSingleton<LevelLoadingManager>.Instance.m_previousLevel;
			if (previousLevel != null && previousLevel.SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value != LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value)
			{
				List<string> list = new List<string>();
				XmlNodeList xmlNodeList = previousLevel.SelectNodes("NPCSetting/NPC/@value");
				for (int i = 0; i < xmlNodeList.Count; i++)
				{
					string value = xmlNodeList[i].Value;
					BuildingKitRender buildingKitRender = new BuildingKitRender("NPC", value);
					buildingKitRender.method_2();
					list.AddRange(buildingKitRender.method_16(true));
				}
				MonoSingleton<AssetBundleManager>.Instance.method_13(list, true);
			}
			if (!MonoSingleton<AppManager>.Instance.m_noimpact && MonoSingleton<ImpactManager>.Instance != null)
			{
				MonoSingleton<ImpactManager>.Instance.method_2();
			}
			VFXManager.smethod_2();
			MonoSingleton<AppManager>.Instance.method_12(true);
			this.m_async = Application.LoadLevelAsync("ResourcesLoading");
			MonoSingleton<AppManager>.Instance.method_0().OnLevelLoadingStart();
			MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList = null;
			this.method_1();
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x0000CAEE File Offset: 0x0000ACEE
		public override bool vmethod_2()
		{
			if (this.m_async.isDone)
			{
				MonoSingleton<AppManager>.Instance.method_1(true);
				return true;
			}
			return false;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x0000CB0B File Offset: 0x0000AD0B
		public override void vmethod_3()
		{
			if (ServiceWrapperBase<ObjectiveManager>.Instance == null)
			{
				return;
			}
			ServiceWrapperBase<ObjectiveManager>.Instance.method_2();
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x00071E7C File Offset: 0x0007007C
		private void method_1()
		{
			string text = string.Empty;
			if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				text = "AssetBundles/AssetBundle[@type='Map' or @behaviour='light_pillar']";
			}
			else if (MonoSingleton<AppManager>.Instance.m_offlineMode)
			{
				text = "AssetBundles/AssetBundle";
			}
			else
			{
				text = "AssetBundles/AssetBundle";
			}
			MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectNodes(text);
		}

		// Token: 0x04000CB7 RID: 3255
		private AsyncOperation m_async;
	}

	// Token: 0x0200028E RID: 654
	private class LevelLoadingStep_DownloadAssetBundle : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E17 RID: 3607 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_DownloadAssetBundle(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00071ED8 File Offset: 0x000700D8
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_DownloadAssetBundle.EnterStep [" + Time.time + "]");
			this.m_bundleList = base.method_0();
			MonoSingleton<LevelLoadingManager>.Instance.StartCoroutine(MonoSingleton<AssetBundleManager>.Instance.method_5(this.m_bundleList, new FuncBase(this.method_1), null, false, 1));
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x00071F3C File Offset: 0x0007013C
		public override bool vmethod_2()
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < this.m_bundleList.Count; i++)
			{
				string text = this.m_bundleList[i];
				float num3 = MonoSingleton<AssetBundleManager>.Instance.method_12(text);
				uint num4 = MonoSingleton<AssetBundleManager>.Instance.method_2(text);
				num += num4;
				num2 += num4 * num3;
			}
			if (num == 0f)
			{
				this.m_loadingProgress = 1f;
			}
			else
			{
				this.m_loadingProgress = num2 / num;
			}
			return this.m_finish;
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_3()
		{
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x0000CB1F File Offset: 0x0000AD1F
		private void method_1(object object_0 = null)
		{
			this.m_finish = true;
		}

		// Token: 0x04000CB8 RID: 3256
		private bool m_finish;

		// Token: 0x04000CB9 RID: 3257
		private List<string> m_bundleList;
	}

	// Token: 0x0200028F RID: 655
	private class LevelLoadingStep_PreLoadPlayerBuildingKit : LevelLoadingStep
	{
		private bool m_finished;

		public LevelLoadingStep_PreLoadPlayerBuildingKit(float float_0)
			: base(float_0)
		{
		}

		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_PreLoadPlayerBuildingKit.EnterStep [" + Time.time + "]");
			List<string> list = new List<string>();
			BuildingKitRender buildingKitRender = new BuildingKitRender("CHR", "Siren");
			list.AddRange(buildingKitRender.method_17());
			buildingKitRender = new BuildingKitRender("CHR", "Soldier");
			list.AddRange(buildingKitRender.method_17());
			buildingKitRender = new BuildingKitRender("CHR", "Berserker");
			list.AddRange(buildingKitRender.method_17());
			buildingKitRender = new BuildingKitRender("CHR", "Hunter");
			list.AddRange(buildingKitRender.method_17());
			if (list.Count > 0)
			{
				ns0.MonoSingleton<LevelLoadingManager>.Instance.StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(list, method_2, list));
			}
			else
			{
				m_finished = true;
			}
		}

		public override bool vmethod_2()
		{
			return m_finished;
		}

		public override void vmethod_3()
		{
		}

		private IEnumerator method_1(bool bool_0)
		{
			BuildingKitRender render4 = new BuildingKitRender("CHR", "Siren");
			render4.method_4(bool_0);
			while (!render4.Boolean_0)
			{
				yield return null;
			}
			render4 = new BuildingKitRender("CHR", "Soldier");
			render4.method_4(bool_0);
			while (!render4.Boolean_0)
			{
				yield return null;
			}
			render4 = new BuildingKitRender("CHR", "Berserker");
			render4.method_4(bool_0);
			while (!render4.Boolean_0)
			{
				yield return null;
			}
			render4 = new BuildingKitRender("CHR", "Hunter");
			render4.method_4(bool_0);
			while (!render4.Boolean_0)
			{
				yield return null;
			}
		}

		private void method_2(object object_0)
		{
			new Task(method_3(object_0));
		}

		private IEnumerator method_3(object object_0)
		{
			Task task = new Task(method_1(bool_0: true));
			while (task.Boolean_0)
			{
				yield return null;
			}
			List<string> bundleList = (List<string>)object_0;
			ns0.MonoSingleton<AssetBundleManager>.Instance.method_13(bundleList);
			m_finished = true;
		}
	}
	// Token: 0x02000292 RID: 658
	private class LevelLoadingStep_LoadPlayerAudio : LevelLoadingStep
	{
		private bool m_finish;

		public LevelLoadingStep_LoadPlayerAudio(float float_0)
			: base(float_0)
		{
		}

		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_LoadPlayerAudio.EnterStep [" + Time.time + "]");
			if (ns0.ComponentMonoSingleton<AudioSystem>.Boolean_0 && ns0.ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_enableAssetbundle)
			{
				PlayerProperties playerProperties = ns0.MonoSingleton<PlayerManager>.Instance.method_2();
				AvatarType avatarType_ = playerProperties.m_avatarDna.method_5();
				List<string> list = ((!ns0.MonoSingleton<Session>.Instance.method_16()) ? ns0.ServiceWrapperBase<PlayerResourcesLoader>.Instance.method_3(avatarType_) : ns0.ServiceWrapperBase<PlayerResourcesLoader>.Instance.method_4(avatarType_));
				ns0.MonoSingleton<LevelLoadingManager>.Instance.StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(list, method_1, list));
			}
			else
			{
				m_finish = true;
			}
			if (ns0.ComponentMonoSingleton<AudioSystem>.Boolean_0 && ns0.ComponentMonoSingleton<AudioSystem>.Instance.Tensity != null)
			{
				ns0.ComponentMonoSingleton<AudioSystem>.Instance.Tensity.m_currentState = TensityState.MAX;
				ns0.ComponentMonoSingleton<AudioSystem>.Instance.Tensity.m_targetState = TensityState.Normal;
			}
		}

		public override bool vmethod_2()
		{
			return m_finish;
		}

		public override void vmethod_3()
		{
		}

		private void method_1(object object_0)
		{
			List<string> list_ = (List<string>)object_0;
			new Task(method_2(list_));
		}

		private IEnumerator method_2(List<string> list_0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				string packageName = list_0[i];
				BaseAssetBundle bundle = ns0.MonoSingleton<AssetBundleManager>.Instance.method_8(packageName);
				if (bundle != null)
				{
					UnityEngine.Object[] audioObjs = bundle.vmethod_3();
					if (audioObjs != null)
					{
						ns0.ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.method_4(packageName, audioObjs);
					}
					else
					{
						DebugUtils.LogError(LogCategory.Audio, "Can't Load Bundle Content For " + packageName);
					}
				}
				yield return new WaitForEndOfFrame();
			}
			m_finish = true;
		}
	}
	// Token: 0x02000294 RID: 660
	private class LevelLoadingStep_LoadMapSetting : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E3B RID: 3643 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_LoadMapSetting(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x00072520 File Offset: 0x00070720
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_LoadMapSetting.EnterStep [" + Time.time + "]");
			XmlNode xmlNode = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("MapSetting/CameraSetting/FarClip/@value");
			if (xmlNode != null)
			{
				float.TryParse(xmlNode.Value, out MonoSingleton<LevelLoadingManager>.Instance.m_farClip);
				DebugUtils.Log(LogCategory.Framework, "MapSetting->CameraSetting->FarClip: " + MonoSingleton<LevelLoadingManager>.Instance.m_farClip);
			}
			XmlNode xmlNode2 = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("MapSetting/CameraSetting/CameraEffect/@value");
			if (xmlNode2 != null)
			{
				MonoSingleton<LevelLoadingManager>.Instance.m_cameraEffect = xmlNode2.Value;
			}
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x000039EC File Offset: 0x00001BEC
		public override bool vmethod_2()
		{
			return true;
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_3()
		{
		}
	}

	// Token: 0x02000295 RID: 661
	private class LevelLoadingStep_LoadResourceDependencyBundle : LevelLoadingStep
	{
		private bool m_finished;

		public LevelLoadingStep_LoadResourceDependencyBundle(float float_0)
			: base(float_0)
		{
		}

		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_LoadResourceDependencyBundle.EnterStep [" + Time.time + "]");
			new Task(method_1());
		}

		public override bool vmethod_2()
		{
			return m_finished;
		}

		public override void vmethod_3()
		{
		}

		private IEnumerator method_1()
		{
			for (int bundleIndex = 0; bundleIndex < ns0.MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList.Count; bundleIndex++)
			{
				XmlAttribute typeAttribute = ns0.MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[bundleIndex].Attributes["type"];
				if (typeAttribute != null && typeAttribute.Value == "ResourceDependency")
				{
					Task task = new Task(method_2(baseAssetBundle_0: ns0.MonoSingleton<AssetBundleManager>.Instance.method_8(ns0.MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[bundleIndex].Attributes["name"].Value), xmlNode_0: ns0.MonoSingleton<LevelLoadingManager>.Instance.m_assetBundleList[bundleIndex]));
					while (task.Boolean_0)
					{
						yield return null;
					}
				}
			}
			m_finished = true;
			yield return null;
		}

		private IEnumerator method_2(XmlNode xmlNode_0, BaseAssetBundle baseAssetBundle_0)
		{
			switch (xmlNode_0.Attributes["behaviour"].Value)
			{
			case "shared":
			{
				string bundleName = xmlNode_0.Attributes["name"].Value;
				UnityEngine.Object[] bundle_Objects = baseAssetBundle_0.vmethod_3();
				if (bundle_Objects != null && bundle_Objects.Length != 0)
				{
					ns0.MonoSingleton<LevelLoadingManager>.Instance.method_6(baseAssetBundle_0, "OutputBuildNumber for " + bundleName);
				}
				else
				{
					DebugUtils.LogError(LogCategory.Framework, "Fail to load " + bundleName);
				}
				break;
			}
			case "audio":
			{
				string packageName = xmlNode_0.Attributes["name"].Value;
				UnityEngine.Object[] audioObjs = baseAssetBundle_0.vmethod_3();
				if (audioObjs != null)
				{
					if (ns0.ComponentMonoSingleton<AudioSystem>.Boolean_0)
					{
						ns0.ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.method_4(packageName, audioObjs);
					}
					yield return null;
				}
				break;
			}
			case "vfxmanager":
				VFXManager.smethod_1(baseAssetBundle_0);
				break;
			case "light_pillar":
				Pickable.LightPillarManager.LightPillarManager_0.method_1();
				break;
			case "cutscene":
				ResourcesLoader.smethod_4(baseAssetBundle_0);
				break;
			}
			yield return null;
		}
	}
	// Token: 0x02000298 RID: 664
	private class LevelLoadingStep_PreLoadNpcResources : LevelLoadingStep
	{
		private bool m_finish;

		public LevelLoadingStep_PreLoadNpcResources(float float_0)
			: base(float_0)
		{
		}

		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_PreLoadNpcResources.EnterStep [" + Time.time + "]");
			AIServiceSetting.AIServiceSetting_0.method_0();
			List<string> list = method_4();
			if (list.Count > 0)
			{
				ns0.MonoSingleton<LevelLoadingManager>.Instance.StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(list, method_2, list));
			}
			else
			{
				m_finish = true;
			}
		}

		public override bool vmethod_2()
		{
			return m_finish;
		}

		public override void vmethod_3()
		{
		}

		private IEnumerator method_1(bool bool_0)
		{
			XmlNodeList npcList = MapsDescXml.MapsDescXml_0.method_1().SelectNodes("NPCSetting/NPC/@value");
			for (int i = 0; i < npcList.Count; i++)
			{
				string npcName = npcList[i].Value;
				BuildingKitRender renderer = new BuildingKitRender("NPC", npcName);
				renderer.method_4(bool_0);
				while (!renderer.Boolean_0)
				{
					yield return null;
				}
			}
		}

		private void method_2(object object_0 = null)
		{
			new Task(method_3(object_0));
		}

		private IEnumerator method_3(object object_0)
		{
			Task task = new Task(method_1(bool_0: true));
			while (task.Boolean_0)
			{
				yield return null;
			}
			List<string> npcBundleList = (List<string>)object_0;
			ns0.MonoSingleton<AssetBundleManager>.Instance.method_13(npcBundleList);
			m_finish = true;
		}

		private List<string> method_4()
		{
			List<string> list = new List<string>();
			XmlNodeList xmlNodeList = MapsDescXml.MapsDescXml_0.method_1().SelectNodes("NPCSetting/NPC/@value");
			for (int i = 0; i < xmlNodeList.Count; i++)
			{
				string value = xmlNodeList[i].Value;
				DebugUtils.Log(LogCategory.Framework, "Loading Npc for Level: " + value);
				BuildingKitRender buildingKitRender = new BuildingKitRender("NPC", value);
				list.AddRange(buildingKitRender.method_16());
			}
			return list;
		}
	}
	// Token: 0x0200029B RID: 667
	private class LevelLoadingStep_SyncLocalPlayer : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E65 RID: 3685 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_SyncLocalPlayer(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x0000CC0D File Offset: 0x0000AE0D
		public override float vmethod_0()
		{
			return 20f;
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x0000CC14 File Offset: 0x0000AE14
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_SyncLocalPlayer.EnterStep [" + Time.time + "]");
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x00072C00 File Offset: 0x00070E00
		public override bool vmethod_2()
		{
			if (MonoSingleton<Session>.Instance == null)
			{
				DebugUtils.LogError(LogCategory.Framework, "LevelLoadingStep_SyncLocalPlayer.UpdateStep: Session is null. [" + Time.time + "]");
				return false;
			}
			return !(MonoSingleton<Session>.Instance.GetLocalPlayer() == null);
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_3()
		{
		}
	}

	// Token: 0x0200029C RID: 668
	private class LevelLoadingStep_PreLoadWeapon : LevelLoadingStep
	{
		private bool m_finish;

		public LevelLoadingStep_PreLoadWeapon(float float_0)
			: base(float_0)
		{
		}

		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_PreLoadWeapon.EnterStep [" + Time.time + "]");
			List<string> list = method_4();
			if (list.Count > 0)
			{
				ns0.MonoSingleton<LevelLoadingManager>.Instance.StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(list, method_2, list));
			}
			else
			{
				m_finish = true;
			}
		}

		public override bool vmethod_2()
		{
			return m_finish;
		}

		public override void vmethod_3()
		{
		}

		private IEnumerator method_1(bool bool_0)
		{
			BuildingKitRender kitRender5 = new BuildingKitRender("WPN", "SMG");
			kitRender5.method_4(bool_0);
			while (!kitRender5.Boolean_0)
			{
				yield return null;
			}
			BuildingKitRender kitRender4 = new BuildingKitRender("WPN", "SniperRifle");
			kitRender4.method_4(bool_0);
			while (!kitRender4.Boolean_0)
			{
				yield return null;
			}
			BuildingKitRender kitRender3 = new BuildingKitRender("WPN", "ShotGun");
			kitRender3.method_4(bool_0);
			while (!kitRender3.Boolean_0)
			{
				yield return null;
			}
			BuildingKitRender kitRender2 = new BuildingKitRender("WPN", "RepeaterPistol");
			kitRender2.method_4(bool_0);
			while (!kitRender2.Boolean_0)
			{
				yield return null;
			}
			BuildingKitRender kitRender = new BuildingKitRender("WPN", "CombatRifle");
			kitRender.method_4(bool_0);
			while (!kitRender.Boolean_0)
			{
				yield return null;
			}
		}

		private void method_2(object object_0 = null)
		{
			new Task(method_3(object_0));
		}

		private IEnumerator method_3(object object_0)
		{
			Task task = new Task(method_1(bool_0: true));
			while (task.Boolean_0)
			{
				yield return null;
			}
			List<string> bundleList = (List<string>)object_0;
			ns0.MonoSingleton<AssetBundleManager>.Instance.method_13(bundleList);
			m_finish = true;
		}

		private List<string> method_4()
		{
			List<string> list = new List<string>();
			BuildingKitRender buildingKitRender = new BuildingKitRender("WPN", "SMG");
			list.AddRange(buildingKitRender.method_17());
			BuildingKitRender buildingKitRender2 = new BuildingKitRender("WPN", "SniperRifle");
			list.AddRange(buildingKitRender2.method_17());
			BuildingKitRender buildingKitRender3 = new BuildingKitRender("WPN", "ShotGun");
			list.AddRange(buildingKitRender3.method_17());
			BuildingKitRender buildingKitRender4 = new BuildingKitRender("WPN", "RepeaterPistol");
			list.AddRange(buildingKitRender4.method_17());
			BuildingKitRender buildingKitRender5 = new BuildingKitRender("WPN", "CombatRifle");
			list.AddRange(buildingKitRender5.method_17());
			return list;
		}
	}
	// Token: 0x0200029F RID: 671
	private class LevelLoadingStep_UI : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E7E RID: 3710 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_UI(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x00072FF0 File Offset: 0x000711F0
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_UI.EnterStep [" + Time.time + "]");
			if (MonoSingleton<Session>.Instance.method_17())
			{
				DebugUtils.Log(LogCategory.Framework, "GotoStep(FrontEndStepManager.StepState.RV)");
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.RV, null);
			}
			else if (MonoSingleton<Session>.Instance.method_16())
			{
				DebugUtils.Log(LogCategory.Framework, "GotoStep(FrontEndStepManager.StepState.Town)");
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.Town, null);
			}
			else if (MonoSingleton<Session>.Instance.method_12())
			{
				DebugUtils.Log(LogCategory.Framework, "GotoStep(FrontEndStepManager.StepState.PVP)");
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.PVP, null);
			}
			else
			{
				DebugUtils.Log(LogCategory.Framework, "GotoStep(FrontEndStepManager.StepState.Gaming)");
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.Gaming, null);
			}
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x000730B8 File Offset: 0x000712B8
		public override bool vmethod_2()
		{
			foreach (KeyValuePair<string, BaseAssetBundle> keyValuePair in MonoSingleton<AssetBundleManager>.Instance.Dictionary_0)
			{
				if (keyValuePair.Key.StartsWith("uniswf_"))
				{
					InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)keyValuePair.Value;
					if (!inGameAssetBundle.m_www.isDone)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_3()
		{
		}
	}

	// Token: 0x020002A0 RID: 672
	private class LevelLoadingStep_LoadLevelBundle : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E82 RID: 3714 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_LoadLevelBundle(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x0007313C File Offset: 0x0007133C
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_LoadLevelBundle.EnterStep [" + Time.time + "]");
			string value = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value;
			string text = this.method_1();
			BaseAssetBundle baseAssetBundle = MonoSingleton<AssetBundleManager>.Instance.method_8(text);
			this.m_bundleLoading = baseAssetBundle.vmethod_4(value, typeof(global::UnityEngine.Object));
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x0000CC6F File Offset: 0x0000AE6F
		public override bool vmethod_2()
		{
			if (this.m_bundleLoading != null)
			{
				this.m_loadingProgress = this.m_bundleLoading.progress;
			}
			return this.m_bundleLoading == null || this.m_bundleLoading.isDone;
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_3()
		{
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x000731AC File Offset: 0x000713AC
		private string method_1()
		{
			if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				return "host_" + LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@name").Value;
			}
			return LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@name").Value;
		}

		// Token: 0x04000D05 RID: 3333
		private AssetBundleRequest m_bundleLoading;
	}

	// Token: 0x020002A1 RID: 673
	private class LevelLoadingStep_LoadLevel : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E87 RID: 3719 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_LoadLevel(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x00073204 File Offset: 0x00071404
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_LoadLevel.EnterStep [" + Time.time + "]");
			string value = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value;
			if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				MonoSingleton<GraphicsMgr>.Instance.method_18().method_1();
			}
			this.m_levelLoadingAsync = Application.LoadLevelAsync(value);
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x0000CCA2 File Offset: 0x0000AEA2
		public override bool vmethod_2()
		{
			if (this.m_levelLoadingAsync != null)
			{
				this.m_loadingProgress = this.m_levelLoadingAsync.progress;
			}
			if (this.m_levelLoadingAsync != null && !this.m_levelLoadingAsync.isDone)
			{
				return false;
			}
			MonoSingleton<AppManager>.Instance.method_1(false);
			return true;
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x00073274 File Offset: 0x00071474
		public override void vmethod_3()
		{
			bool flag = false;
			int num = 1;
			GameObject gameObject = GameObject.Find("submap" + 1);
			while (gameObject != null)
			{
				flag = true;
				Transform transform = gameObject.transform.FindChild("LA");
				if (transform != null && transform.parent == gameObject.transform)
				{
					DebugUtils.Log(LogCategory.Framework, "Static Batching LA");
					List<GameObject> list = new List<GameObject>();
					this.method_1(list, transform.gameObject);
					if (list.Count > 0)
					{
						StaticBatchingUtility.Combine(list.ToArray(), transform.gameObject);
					}
				}
				else
				{
					DebugUtils.LogError(LogCategory.Framework, "No LA for static batching for [" + gameObject.name + "]");
				}
				num++;
				gameObject = GameObject.Find("submap" + num);
			}
			if (!flag)
			{
				GameObject gameObject2 = GameObject.Find("LA");
				if (gameObject2 != null && gameObject2.transform.parent == null)
				{
					DebugUtils.Log(LogCategory.Framework, "Static Batching LA");
					List<GameObject> list2 = new List<GameObject>();
					this.method_1(list2, gameObject2);
					if (list2.Count > 0)
					{
						StaticBatchingUtility.Combine(list2.ToArray(), gameObject2);
					}
				}
				else
				{
					DebugUtils.LogError(LogCategory.Framework, "No LA for static batching");
				}
			}
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x000733BC File Offset: 0x000715BC
		private void method_1(List<GameObject> list_0, GameObject gameObject_0)
		{
			Renderer component = gameObject_0.GetComponent<Renderer>();
			if (component != null && (component.material != null || component.sharedMaterial != null))
			{
				MeshFilter component2 = gameObject_0.GetComponent<MeshFilter>();
				if (component2 != null && component2.sharedMesh != null)
				{
					list_0.Add(gameObject_0);
					gameObject_0.AddComponent<BatchingMeshContainer>().m_mesh = component2.sharedMesh;
				}
			}
			for (int i = 0; i < gameObject_0.transform.childCount; i++)
			{
				this.method_1(list_0, gameObject_0.transform.GetChild(i).gameObject);
			}
		}

		// Token: 0x04000D06 RID: 3334
		private AsyncOperation m_levelLoadingAsync;
	}

	// Token: 0x020002A2 RID: 674
	private class LevelLoadingStep_LoadLevelDataBundle : LevelLoadingStep
	{
		private List<AssetBundleRequest> m_resourcesLoadingList = new List<AssetBundleRequest>();

		public LevelLoadingStep_LoadLevelDataBundle(float float_0)
			: base(float_0)
		{
		}

		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_LoadLevelDataBundle.EnterStep [" + Time.time + "]");
			if (ns0.MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				return;
			}
			XmlNode xmlNode = MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("AssetBundles/AssetBundle[@type='LevelData']/@name");
			XmlNode xmlNode2 = MapsDescXml.MapsDescXml_0.method_1().SelectSingleNode("AssetBundles/AssetBundle[@type='LevelData']/Cubemap/@path");
			if (xmlNode != null)
			{
				BaseAssetBundle baseAssetBundle = ns0.MonoSingleton<AssetBundleManager>.Instance.method_8(xmlNode.Value);
				if (xmlNode2 != null && baseAssetBundle.vmethod_0(xmlNode2.Value))
				{
					m_resourcesLoadingList.Add(baseAssetBundle.vmethod_4(xmlNode2.Value, typeof(Cubemap)));
				}
			}
		}

		public override bool vmethod_2()
		{
			if (ns0.MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				return true;
			}
			bool flag = true;
			for (int i = 0; i < m_resourcesLoadingList.Count; i++)
			{
				AssetBundleRequest assetBundleRequest = m_resourcesLoadingList[i];
				if (!assetBundleRequest.isDone)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				for (int j = 0; j < m_resourcesLoadingList.Count; j++)
				{
					AssetBundleRequest assetBundleRequest2 = m_resourcesLoadingList[j];
					if (!assetBundleRequest2.isDone)
					{
						continue;
					}
					UnityEngine.Object asset = assetBundleRequest2.asset;
					if (asset.GetType() == typeof(Cubemap))
					{
						ns0.MonoSingleton<LevelLoadingManager>.Instance.m_levelCubemap = asset as Cubemap;
					}
					else if (asset.GetType() == typeof(TextAsset))
					{
						if (asset.name.Contains("farlightProbes"))
						{
							ns0.MonoSingleton<LevelLoadingManager>.Instance.m_farLigthProb = asset as TextAsset;
						}
						else if (asset.name.Contains("nearlightProbes"))
						{
							ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLigthProb = asset as TextAsset;
						}
					}
					m_resourcesLoadingList.Remove(assetBundleRequest2);
				}
				if (ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLigthProb != null && ns0.MonoSingleton<LevelLoadingManager>.Instance.m_farLigthProb != null)
				{
					method_1();
				}
				if (m_resourcesLoadingList.Count == 0)
				{
					return true;
				}
			}
			return false;
		}

		public override void vmethod_3()
		{
		}

		private void method_1()
		{
			TextAsset farLigthProb = ns0.MonoSingleton<LevelLoadingManager>.Instance.m_farLigthProb;
			TextAsset nearLigthProb = ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLigthProb;
			if (farLigthProb != null && nearLigthProb != null)
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				Stream stream = null;
				try
				{
					stream = new MemoryStream(farLigthProb.bytes);
					ns0.MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
				}
				catch (Exception ex)
				{
					DebugUtils.LogError(LogCategory.Framework, ex.ToString());
					DebugUtils.LogError(LogCategory.Framework, "LinSH: Read FarData error!");
				}
				finally
				{
					stream.Close();
					stream = null;
				}
				try
				{
					stream = new MemoryStream(nearLigthProb.bytes);
					ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
				}
				catch (Exception ex2)
				{
					DebugUtils.LogError(LogCategory.Framework, ex2.ToString());
					DebugUtils.LogError(LogCategory.Framework, "LinSH: Read NearData error!");
				}
				finally
				{
					stream.Close();
					stream = null;
				}
				if (ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff != null && ns0.MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff != null && LightmapSettings.lightProbes != null)
				{
					if (ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff.Length != ns0.MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff.Length && ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff.Length != LightmapSettings.lightProbes.coefficients.Length)
					{
						DebugUtils.LogError(LogCategory.Framework, "LinSH: light probe number is not match near/far/lightmapSetting!");
						ns0.MonoSingleton<LevelLoadingManager>.Instance.m_nearLightProCoeff = (ns0.MonoSingleton<LevelLoadingManager>.Instance.m_farLightProCoeff = null);
					}
					else
					{
						ns0.MonoSingleton<LevelLoadingManager>.Instance.m_customLightProbes = UnityEngine.Object.Instantiate(LightmapSettings.lightProbes) as LightProbes;
					}
				}
				else
				{
					DebugUtils.Log(LogCategory.Framework, "LinSH : Can't create the light probe instance!");
				}
			}
			else
			{
				DebugUtils.LogError(LogCategory.Framework, "LinSH: Light Probe miss!");
			}
			nearLigthProb = null;
		}
	}
	// Token: 0x020002A3 RID: 675
	private class LevelLoadingStep_GenerateWeaponsData : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E91 RID: 3729 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_GenerateWeaponsData(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_1()
		{
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x000039EC File Offset: 0x00001BEC
		public override bool vmethod_2()
		{
			return true;
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_3()
		{
		}
	}

	// Token: 0x020002A4 RID: 676
	private class LevelLoadingStep_EndLoading : LevelLoadingManager.LevelLoadingStep
	{
		// Token: 0x06000E95 RID: 3733 RVA: 0x0000CAE5 File Offset: 0x0000ACE5
		public LevelLoadingStep_EndLoading(float float_0)
			: base(float_0)
		{
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x0000CCF4 File Offset: 0x0000AEF4
		public override void vmethod_1()
		{
			DebugUtils.Log(LogCategory.Framework, "LevelLoadingStep_EndLoading.EnterStep [" + Time.time + "]");
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x0007382C File Offset: 0x00071A2C
		public override bool vmethod_2()
		{
			List<string> list = base.method_0();
			MonoSingleton<AssetBundleManager>.Instance.method_13(list, false);
			if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				ResourcesLoader.smethod_5();
				Resources.UnloadUnusedAssets();
			}
			else
			{
				MonoSingleton<QualityManager>.Instance.method_0();
			}
			if (MonoSingleton<LevelLoadingManager>.Instance.m_callback != null)
			{
				MonoSingleton<LevelLoadingManager>.Instance.m_callback(MonoSingleton<LevelLoadingManager>.Instance.m_callbackParam);
			}
			List<string> list2 = new List<string>();
			foreach (KeyValuePair<string, BaseAssetBundle> keyValuePair in MonoSingleton<AssetBundleManager>.Instance.Dictionary_0)
			{
				if (keyValuePair.Key.StartsWith("uniswf_"))
				{
					list2.Add(keyValuePair.Key);
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				MonoSingleton<AssetBundleManager>.Instance.method_14(list2[i], false);
			}
			if (MonoSingleton<UniResourceManager>.Instance)
			{
				MonoSingleton<UniResourceManager>.Instance.method_10();
				List<KeyValuePair<string, Material>> list3 = new List<KeyValuePair<string, Material>>();
				foreach (KeyValuePair<string, Material> keyValuePair2 in TextureManager.instance.materials)
				{
					if (keyValuePair2.Key.Contains(".swf_") && !keyValuePair2.Key.Contains("swf/"))
					{
						string text = keyValuePair2.Key.Split(new string[] { ".swf" }, StringSplitOptions.RemoveEmptyEntries)[0] + ".swf/" + keyValuePair2.Key;
						list3.Add(new KeyValuePair<string, Material>(text, keyValuePair2.Value));
					}
				}
				for (int j = 0; j < list3.Count; j++)
				{
					if (!TextureManager.instance.materials.ContainsKey(list3[j].Key))
					{
						TextureManager.instance.materials.Add(list3[j].Key, list3[j].Value);
					}
					else
					{
						TextureManager.instance.materials[list3[j].Key] = list3[j].Value;
					}
				}
			}
			return true;
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00073A98 File Offset: 0x00071C98
		public override void vmethod_3()
		{
			MonoSingleton<AppManager>.Instance.method_0().OnLevelLoadingFinish();
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().OnCurStepLevelLoadingFinish();
			MonoSingleton<LevelLoadingManager>.Instance.m_previousLevel = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1();
			DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
			DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
		}
	}
}
