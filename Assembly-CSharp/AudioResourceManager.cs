using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000129 RID: 297
[ExecuteInEditMode]
public class AudioResourceManager : AudioSubsystem
{
	// Token: 0x060006CC RID: 1740 RVA: 0x000078DC File Offset: 0x00005ADC
	public AudioResourceManager()
	{
		this.m_poolManager = new AudioPoolManager();
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x00007910 File Offset: 0x00005B10
	public Dictionary<string, List<string>> method_0()
	{
		return this.m_assetbundleContentInfo;
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x00007918 File Offset: 0x00005B18
	protected override bool vmethod_0()
	{
		this.m_enableAssetbundle = true;
		this.m_poolManager.method_0();
		return true;
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_1()
	{
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x00054ED4 File Offset: 0x000530D4
	public override void imethod_4()
	{
		Dictionary<string, UnityEngine.Object> dictionary = new Dictionary<string, UnityEngine.Object>();
		Dictionary<string, UnityEngine.Object>.Enumerator enumerator = m_audioResources.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (m_retainedResources.Contains(enumerator.Current.Key))
			{
				dictionary.Add(enumerator.Current.Key, enumerator.Current.Value);
			}
		}
		m_audioResources.Clear();
		m_audioResources = dictionary;
		if (m_enableAssetbundle)
		{
			Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
			Dictionary<string, List<string>>.Enumerator enumerator2 = m_assetbundleContentInfo.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				List<string> value = enumerator2.Current.Value;
				if (value.Count == 0)
				{
					DebugUtils.LogWarning(LogCategory.Audio, "Found audio bundle containing no resources: " + enumerator2.Current.Key);
				}
				else if (m_retainedResources.Contains(value[0]))
				{
					dictionary2.Add(enumerator2.Current.Key, value);
				}
			}
			m_assetbundleContentInfo.Clear();
			m_assetbundleContentInfo = dictionary2;
		}
		TkAudioSystem.smethod_3();
		TkAudioSystem.TkAudioSystem_0.method_3();
		m_poolManager.method_1();
	}
	// Token: 0x060006D1 RID: 1745 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_1()
	{
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x00055014 File Offset: 0x00053214
	public GameObject method_2(string string_0)
	{
		global::UnityEngine.Object @object = null;
		if (!this.m_audioResources.TryGetValue(string_0, out @object))
		{
			DebugUtils.LogError(LogCategory.Audio, string_0 + " missing in AudioResourceManager");
		}
		return @object as GameObject;
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x0000792D File Offset: 0x00005B2D
	public bool method_3(string string_0)
	{
		return this.m_assetbundleContentInfo.ContainsKey(string_0);
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0005504C File Offset: 0x0005324C
	public bool method_4(string string_0, global::UnityEngine.Object[] object_0, bool bool_0 = false)
	{
		bool flag = false;
		if (this.method_3(string_0))
		{
			DebugUtils.Log(LogCategory.Audio, "AudioPackage:" + string_0 + ".assetbundle is already loaded.");
			flag = false;
		}
		else
		{
			DebugUtils.Log(LogCategory.Audio, "ready add audio resource: " + string_0);
			List<string> list = new List<string>();
			this.m_assetbundleContentInfo.Add(string_0, list);
			for (int i = 0; i < object_0.Length; i++)
			{
				GameObject gameObject = object_0[i] as GameObject;
				if (!(null == gameObject))
				{
					string name = object_0[i].name;
					TkAudioSource component = gameObject.GetComponent<TkAudioSource>();
					if (null == component)
					{
						if (null != gameObject.GetComponent<AudioSource>())
						{
							DebugUtils.Log(LogCategory.Audio, string.Concat(new string[] { "Resource: ", name, " in package '", string_0, "' doesn't contain TkAudioSource but does contain an AudioSource, so it's probably a template -> ignoring it quietly" }));
						}
						else
						{
							DebugUtils.LogWarning(LogCategory.Audio, string.Concat(new string[] { "Resource: ", name, " in package '", string_0, "' doesn't contain a TkAudioSource -> ignoring it" }));
						}
					}
					else if (this.m_audioResources.ContainsKey(name))
					{
						if (this.m_retainedResources.Contains(name))
						{
							DebugUtils.Log(LogCategory.Audio, "Ignoring load of audio resource: " + name + " because it's retained");
							if (!bool_0)
							{
								DebugUtils.Log(LogCategory.Audio, "Mixing retained and non-retained mode for audio resource:" + name + " in 2 different packages or load by dependence !");
							}
						}
						else
						{
							DebugUtils.Log(LogCategory.Audio, "load prefab:" + name + " twice! please check the prefab to make sure one prefab only in one asset bundle.");
						}
					}
					else
					{
						this.m_audioResources.Add(name, object_0[i]);
						DebugUtils.Log(LogCategory.Audio, "add audio resource: " + name);
						if (bool_0)
						{
							DebugUtils.Log(LogCategory.Audio, "Retaining audio resource: " + name);
							this.m_retainedResources.Add(name);
						}
						list.Add(name);
					}
				}
			}
		}
		return flag;
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0000793B File Offset: 0x00005B3B
	public bool Boolean_0
	{
		get
		{
			return this.m_isLoading;
		}
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x00055220 File Offset: 0x00053420
	public IEnumerator method_5(string string_0, bool bool_0 = false, string string_1 = "")
	{
		string resourcePath = "Audio/Resource/" + string_0;
		TextAsset audioResList = ResourcesLoader.smethod_0(resourcePath) as TextAsset;
		if (audioResList == null)
		{
			DebugUtils.LogError(LogCategory.Audio, string_0 + " missing");
			yield break;
		}
		DebugUtils.Log(LogCategory.Audio, "Load audio configure file: " + string_0 + ".xml");
		m_isLoading = true;
		AudioPackageList packageList = null;
		try
		{
			using (StringReader reader = new StringReader(audioResList.text))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(AudioPackageList));
				packageList = serializer.Deserialize(reader) as AudioPackageList;
			}
			ResourcesLoader.smethod_6(audioResList);
		}
		catch (Exception ex2)
		{
			Exception ex = ex2;
			DebugUtils.LogError(LogCategory.Audio, "Failed loading AudioPackageList @: " + resourcePath + " caused by: " + ex.Message + "\nfrom: " + ex.StackTrace);
		}
		if (packageList != null)
		{
			for (int i = 0; i < packageList.m_packages.Length; i++)
			{
				string packageName = packageList.m_packages[i] + ".assetbundle";
				if (!string.IsNullOrEmpty(string_1) && packageList.m_packages[i] != string_1)
				{
					continue;
				}
				if (m_assetbundleContentInfo.ContainsKey(packageName))
				{
					DebugUtils.Log(LogCategory.Audio, "AudioPackage:" + packageName + ".assetbundle is already loaded.");
					continue;
				}
				DebugUtils.Log(LogCategory.Audio, "Loading audio package:" + packageName);
				yield return ns0.MonoSingleton<AudioManager>.Instance.StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_4(packageName, null, null, bool_0));
				UnityEngine.Object[] audioObjs = ns0.MonoSingleton<AssetBundleManager>.Instance.method_8(packageName).vmethod_3();
				if (audioObjs == null)
				{
					DebugUtils.LogWarning(LogCategory.Audio, "Audio package: " + packageName + " does not contain any objects");
				}
				else
				{
					method_4(packageName, audioObjs, bool_0);
				}
			}
			DebugUtils.Log(LogCategory.Audio, "Total loaded audio prefabs count:" + m_audioResources.Count);
		}
		m_isLoading = false;
		yield return 0;
	}
	// Token: 0x0400062D RID: 1581
	public const string AUDIO_RESOURCES_CONFIG_PATH = "Audio/Resource/";

	// Token: 0x0400062E RID: 1582
	private Dictionary<string, global::UnityEngine.Object> m_audioResources = new Dictionary<string, global::UnityEngine.Object>();

	// Token: 0x0400062F RID: 1583
	private HashSet<string> m_retainedResources = new HashSet<string>();

	// Token: 0x04000630 RID: 1584
	private Dictionary<string, List<string>> m_assetbundleContentInfo = new Dictionary<string, List<string>>();

	// Token: 0x04000631 RID: 1585
	public AudioPoolManager m_poolManager;

	// Token: 0x04000632 RID: 1586
	private bool m_isLoading;

	// Token: 0x04000633 RID: 1587
	public bool m_enableAssetbundle;
}
