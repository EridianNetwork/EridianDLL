using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020000CA RID: 202
public class AssetBundleManager : MonoSingleton<AssetBundleManager>
{
	// Token: 0x17000027 RID: 39
	// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000647F File Offset: 0x0000467F
	public bool Boolean_1
	{
		get
		{
			return this.m_versionTable != null;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000648D File Offset: 0x0000468D
	public Dictionary<string, BaseAssetBundle> Dictionary_0
	{
		get
		{
			return this.m_wwws;
		}
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x00006495 File Offset: 0x00004695
	private void Start()
	{
		if (this.Boolean_2)
		{
			base.StartCoroutine(this.method_0());
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0004B3FC File Offset: 0x000495FC
	private IEnumerator method_0()
	{
		DebugUtils.Log(LogCategory.Framework, "LoadVersionTable Start");
		WWW versionTableWWW = new WWW(String_0 + "VersionTable.assetbundle");
		m_wwws.Add("VersionTable.assetbundle", new InGameAssetBundle(versionTableWWW));
		yield return versionTableWWW;
		UnityEngine.Object asset = method_8("VersionTable.assetbundle").Object_0;
		TextAsset text_asset = asset as TextAsset;
		MemoryStream stream = new MemoryStream(text_asset.bytes);
		BinaryFormatter bFormatter = new BinaryFormatter();
		uint[] values = bFormatter.Deserialize(stream) as uint[];
		stream.Close();
		DebugUtils.Log(LogCategory.Framework, "LoadVersionTable End");
		m_versionTable = new Dictionary<uint, AssetBundleInfo>();
		for (int i = 0; i < values.Length; i += 3)
		{
			m_versionTable.Add(values[i], new AssetBundleInfo((int)values[i + 1], values[i + 2]));
		}
	}
	// Token: 0x060004AA RID: 1194 RVA: 0x000064AC File Offset: 0x000046AC
	private bool method_1(string string_0)
	{
		return string_0.ToLower().StartsWith("uniswf_");
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x0004B418 File Offset: 0x00049618
	public uint method_2(string string_0)
	{
		if (this.Boolean_2 && Caching.enabled)
		{
			uint num = Utility.smethod_1(string_0.ToLower());
			return this.m_versionTable[num].m_size;
		}
		return 1U;
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0004B454 File Offset: 0x00049654
	public void method_3()
	{
		foreach (KeyValuePair<string, BaseAssetBundle> keyValuePair in this.m_wwws)
		{
			InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)keyValuePair.Value;
			if (inGameAssetBundle != null)
			{
				inGameAssetBundle.method_2();
			}
		}
		MonoSingleton<AssetBundleManager>.Instance.Dictionary_0.Clear();
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x0004B4C4 File Offset: 0x000496C4
	public IEnumerator method_4(string string_0, FuncBase funcBase_0 = null, object object_0 = null, bool bool_0 = false)
	{
		while (Boolean_2 && !Boolean_1)
		{
			yield return 0;
		}
		while (Boolean_2 && Caching.enabled && !Caching.ready)
		{
			yield return 0;
		}
		yield return method_6(string_0);
		if (bool_0)
		{
			DebugUtils.Log(LogCategory.Framework, "Retaining asset bundle: " + string_0);
			m_retainedBundles.Add(string_0);
		}
		funcBase_0?.Invoke(object_0);
	}
	// Token: 0x060004AE RID: 1198 RVA: 0x0004B51C File Offset: 0x0004971C
	public IEnumerator method_5(List<string> list_0, FuncBase funcBase_0 = null, object object_0 = null, bool bool_0 = false, int int_0 = 0)
	{
		if (int_0 < 1)
		{
			int_0 = list_0.Count;
		}
		int mod;
		for (int i = 0; i < list_0.Count; i += mod)
		{
			mod = ((list_0.Count - i >= int_0) ? int_0 : (list_0.Count - i));
			List<string> checklist = list_0.GetRange(i, mod);
			for (int k = 0; k < checklist.Count; k++)
			{
				StartCoroutine(method_4(checklist[k], null, null, bool_0));
				yield return null;
			}
			int loaded2 = 0;
			do
			{
				loaded2 = 0;
				for (int j = 0; j < checklist.Count; j++)
				{
					string bundleName = checklist[j];
					if (m_wwws.ContainsKey(bundleName) && method_10(bundleName))
					{
						loaded2++;
					}
				}
				yield return new WaitForEndOfFrame();
			}
			while (loaded2 != checklist.Count);
		}
		funcBase_0?.Invoke(object_0);
	}
	// Token: 0x060004AF RID: 1199 RVA: 0x0004B584 File Offset: 0x00049784
	private WWW method_6(string string_0)
	{
		BaseAssetBundle baseAssetBundle = null;
		if (!this.m_wwws.TryGetValue(string_0, out baseAssetBundle))
		{
			if (this.Boolean_2 && Caching.enabled)
			{
				bool flag = true;
				int num = 0;
				uint num2 = Utility.smethod_1(string_0.ToLower());
				AssetBundleInfo assetBundleInfo;
				if (this.m_versionTable.TryGetValue(num2, out assetBundleInfo))
				{
					num = assetBundleInfo.m_version;
				}
				else
				{
					flag = false;
					DebugUtils.LogError(LogCategory.Framework, string.Concat(new object[] { "m_versionTable Doesn't Contains [", num2, "] of ", string_0 }));
				}
				if (flag)
				{
					if (this.LogAssetBundles)
					{
						DebugUtils.Log(LogCategory.Network, string.Concat(new object[] { "LoadFromCacheOrDownload - ", string_0, " - ", num }));
					}
					baseAssetBundle = new InGameAssetBundle(WWW.LoadFromCacheOrDownload(this.String_0 + string_0, num));
					this.m_wwws.Add(string_0, baseAssetBundle);
				}
			}
			else
			{
				WWW www = new WWW(this.String_0 + string_0);
				if (this.LogAssetBundles)
				{
					DebugUtils.Log(LogCategory.Framework, "GetWWW " + string_0 + " - " + www.error);
				}
				baseAssetBundle = new InGameAssetBundle(www);
				this.m_wwws.Add(string_0, baseAssetBundle);
			}
		}
		else if (this.m_retainedBundles.Contains(string_0))
		{
			if (this.LogAssetBundles)
			{
				DebugUtils.Log(LogCategory.Framework, "Ignoring load for retained asset bundle: " + string_0);
			}
		}
		else
		{
			if (this.LogAssetBundles)
			{
				DebugUtils.Log(LogCategory.Network, "Try to load already loaded Asset Bundle: [" + this.String_0 + string_0 + "]");
			}
			baseAssetBundle = null;
		}
		if (baseAssetBundle != null)
		{
			return ((InGameAssetBundle)baseAssetBundle).m_www;
		}
		return null;
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x0004B72C File Offset: 0x0004992C
	public global::UnityEngine.Object method_7(string string_0)
	{
		BaseAssetBundle baseAssetBundle = null;
		if (!this.m_wwws.TryGetValue(string_0, out baseAssetBundle))
		{
			DebugUtils.LogError(LogCategory.Framework, "In AssetBundleManager.GetMainAsset: [" + string_0 + "] not loaded");
			return null;
		}
		if (baseAssetBundle == null)
		{
			DebugUtils.LogError(LogCategory.Framework, "In AssetBundleManager.GetMainAsset: [" + string_0 + "] is null");
		}
		return baseAssetBundle.Object_0;
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x0004B784 File Offset: 0x00049984
	public BaseAssetBundle method_8(string string_0)
	{
		BaseAssetBundle baseAssetBundle = null;
		if (!this.m_wwws.TryGetValue(string_0, out baseAssetBundle))
		{
			if (this.LogAssetBundles)
			{
				DebugUtils.Log(LogCategory.Framework, "In AssetBundleManager.GetAssetBundle [ " + string_0 + "] not loaded");
			}
		}
		else if (baseAssetBundle == null)
		{
			DebugUtils.LogError(LogCategory.Framework, "In AssetBundleManager.GetAssetBundle [" + string_0 + "] is null");
		}
		return baseAssetBundle;
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x000064BE File Offset: 0x000046BE
	public bool method_9(string string_0)
	{
		return this.m_wwws.ContainsKey(string_0);
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x0004B7E0 File Offset: 0x000499E0
	public bool method_10(string string_0)
	{
		if (this.Boolean_2 && !this.Boolean_1)
		{
			return false;
		}
		InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)this.method_8(string_0);
		if (inGameAssetBundle == null)
		{
			DebugUtils.LogWarning(LogCategory.Framework, "Can't get bundle [" + string_0 + "]");
			return true;
		}
		return inGameAssetBundle.m_www == null || inGameAssetBundle.m_www.isDone;
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x0004B83C File Offset: 0x00049A3C
	public bool method_11(string[] string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			if (!this.m_wwws.ContainsKey(string_0[i]))
			{
				return false;
			}
			if (!this.method_10(string_0[i]))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x0004B878 File Offset: 0x00049A78
	public float method_12(string string_0)
	{
		if (this.Boolean_2 && !this.Boolean_1)
		{
			return 0f;
		}
		InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)this.method_8(string_0);
		if (inGameAssetBundle == null)
		{
			return 0f;
		}
		WWW www = inGameAssetBundle.m_www;
		if (www == null)
		{
			return 0f;
		}
		return www.progress;
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x060004B6 RID: 1206 RVA: 0x000064CC File Offset: 0x000046CC
	public bool Boolean_2
	{
		get
		{
			return Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer;
		}
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x060004B7 RID: 1207 RVA: 0x000064E1 File Offset: 0x000046E1
	private string String_0
	{
		get
		{
			if (this.Boolean_2)
			{
				return Application.dataPath + "/assetbundles/";
			}
			return "file://" + Application.dataPath + "/../assetbundles/";
		}
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x0004B8C8 File Offset: 0x00049AC8
	public void method_13(List<string> list_0, bool bool_0 = false)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			this.method_14(list_0[i], bool_0);
		}
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0004B8F4 File Offset: 0x00049AF4
	public void method_14(string string_0, bool bool_0 = false)
	{
		BaseAssetBundle baseAssetBundle = null;
		if (this.m_retainedBundles.Contains(string_0))
		{
			if (this.LogAssetBundles)
			{
				DebugUtils.Log(LogCategory.Framework, "Ignoring unload for retained bundle: " + string_0);
				return;
			}
		}
		else if (this.m_wwws.TryGetValue(string_0, out baseAssetBundle))
		{
			global::UnityEngine.Object object_ = baseAssetBundle.Object_0;
			if (MonoSingleton<UniResourceManager>.Instance != null && object_ != null)
			{
				MonoSingleton<UniResourceManager>.Instance.method_8(object_.name);
			}
			baseAssetBundle.vmethod_5(bool_0);
			if (this.LogAssetBundles)
			{
				DebugUtils.Log(LogCategory.Framework, "Unload bundle " + string_0);
			}
			this.m_wwws.Remove(string_0);
		}
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0004B998 File Offset: 0x00049B98
	public void method_15(bool bool_0 = false)
	{
		if (MonoSingleton<UniResourceManager>.Instance != null)
		{
			MonoSingleton<UniResourceManager>.Instance.method_10();
		}
		Dictionary<string, BaseAssetBundle> dictionary = new Dictionary<string, BaseAssetBundle>();
		foreach (KeyValuePair<string, BaseAssetBundle> keyValuePair in this.m_wwws)
		{
			string key = keyValuePair.Key;
			if (this.m_retainedBundles.Contains(key))
			{
				if (this.LogAssetBundles)
				{
					DebugUtils.Log(LogCategory.Framework, "Ignoring unload for retained bundle: " + key);
				}
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
			}
			else if (keyValuePair.Value != null)
			{
				keyValuePair.Value.vmethod_5(bool_0);
			}
		}
		this.m_wwws.Clear();
		this.m_wwws = null;
		this.m_wwws = dictionary;
	}

	// Token: 0x0400046B RID: 1131
	public const string VERSION_BUNDLE_NAME = "VersionTable.assetbundle";

	// Token: 0x0400046C RID: 1132
	private Dictionary<string, BaseAssetBundle> m_wwws = new Dictionary<string, BaseAssetBundle>();

	// Token: 0x0400046D RID: 1133
	private Dictionary<uint, AssetBundleInfo> m_versionTable;

	// Token: 0x0400046E RID: 1134
	private HashSet<string> m_retainedBundles = new HashSet<string>();

	// Token: 0x0400046F RID: 1135
	private bool LogAssetBundles;
}
