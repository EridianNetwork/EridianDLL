using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.swf;
using UnityEngine;

// Token: 0x020007C0 RID: 1984
public class UniResourceManager : MonoSingleton<UniResourceManager>
{
	// Token: 0x0600352A RID: 13610 RVA: 0x00022EFD File Offset: 0x000210FD
	private UniResourceManager()
	{
		this.mLoader = new BadAssSWFResourceLoader();
		new UniTextureManager();
	}

	// Token: 0x0600352B RID: 13611 RVA: 0x00022F16 File Offset: 0x00021116
	public static UniResourceManager smethod_0()
	{
		if (UniResourceManager.mResourceManager == null)
		{
			UniResourceManager.mResourceManager = new UniResourceManager();
		}
		return UniResourceManager.mResourceManager;
	}

	// Token: 0x0600352C RID: 13612 RVA: 0x000F1444 File Offset: 0x000EF644
	public bool method_0(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder(string_0);
		if (string_0.EndsWith(".assetbundle"))
		{
			stringBuilder.Replace(".assetbundle", ".swf");
		}
		stringBuilder.Replace("uniswf_", string.Empty);
		for (int i = 0; i < this.mLoader.bundles.Count; i++)
		{
			if (this.mLoader.bundles[i] != null && string.Compare(this.mLoader.bundles[i].mainAsset.name, stringBuilder.ToString(), true) == 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600352D RID: 13613 RVA: 0x000F14E8 File Offset: 0x000EF6E8
	public void method_1(string string_0)
	{
		if (!this.method_6(string_0))
		{
			return;
		}
		if (!string_0.EndsWith(".assetbundle"))
		{
			string_0 += ".assetbundle";
		}
		InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)MonoSingleton<AssetBundleManager>.Instance.method_8(string_0);
		if (inGameAssetBundle != null)
		{
			this.mLoader.addAssetBundle(inGameAssetBundle.m_www.assetBundle);
		}
	}

	// Token: 0x0600352E RID: 13614 RVA: 0x00022F34 File Offset: 0x00021134
	public void method_2(AssetBundle assetBundle_0)
	{
		if (this.method_6(assetBundle_0.name))
		{
			this.mLoader.addAssetBundle(assetBundle_0);
		}
	}

	// Token: 0x0600352F RID: 13615 RVA: 0x000F1548 File Offset: 0x000EF748
	public void method_3(string[] string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			this.method_1(string_0[i]);
		}
	}

	// Token: 0x06003530 RID: 13616 RVA: 0x000F156C File Offset: 0x000EF76C
	public void method_4(AssetBundle[] assetBundle_0)
	{
		for (int i = 0; i < assetBundle_0.Length; i++)
		{
			this.method_2(assetBundle_0[i]);
		}
	}

	// Token: 0x06003531 RID: 13617 RVA: 0x000F1590 File Offset: 0x000EF790
	public void method_5()
	{
		int count = MonoSingleton<AssetBundleManager>.Instance.Dictionary_0.Count;
		for (int i = 0; i < count; i++)
		{
			this.method_1(MonoSingleton<AssetBundleManager>.Instance.Dictionary_0.ElementAt<KeyValuePair<string, BaseAssetBundle>>(i).Key);
		}
	}

	// Token: 0x06003532 RID: 13618 RVA: 0x00022F50 File Offset: 0x00021150
	private bool method_6(string string_0)
	{
		return string_0.StartsWith("uniswf_") && !this.method_0(string_0);
	}

	// Token: 0x06003533 RID: 13619 RVA: 0x00022F6B File Offset: 0x0002116B
	public void method_7(AssetBundle assetBundle_0)
	{
		this.mLoader.removeOnlyAssetBundle(assetBundle_0);
	}

	// Token: 0x06003534 RID: 13620 RVA: 0x000F15D8 File Offset: 0x000EF7D8
	public void method_8(string string_0)
	{
		if (!this.method_0(string_0))
		{
			return;
		}
		for (int i = 0; i < this.mLoader.bundles.Count; i++)
		{
			if (this.mLoader.bundles[i].mainAsset.name == string_0)
			{
				this.method_7(this.mLoader.bundles[i]);
				return;
			}
		}
	}

	// Token: 0x06003535 RID: 13621 RVA: 0x000F1648 File Offset: 0x000EF848
	public void method_9(string[] string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			if (!string.IsNullOrEmpty(string_0[i]))
			{
				this.method_8(string_0[i]);
			}
		}
	}

	// Token: 0x06003536 RID: 13622 RVA: 0x000F1678 File Offset: 0x000EF878
	public void method_10()
	{
		string[] array = new string[this.mLoader.bundles.Count];
		for (int i = 0; i < this.mLoader.bundles.Count; i++)
		{
			if (this.mLoader.bundles[i] != null && this.mLoader.bundles[i].mainAsset != null)
			{
				array[i] = this.mLoader.bundles[i].mainAsset.name;
			}
			else
			{
				array[i] = string.Empty;
				DebugUtils.LogError(LogCategory.GUI, "In RemoveAllAssetbundle, mLoader.bundles[index] is null");
			}
		}
		this.method_9(array);
	}

	// Token: 0x06003537 RID: 13623 RVA: 0x000F172C File Offset: 0x000EF92C
	public MovieClip method_11(string string_0)
	{
		MovieClip movieClip = null;
		string text = string_0.Substring(0, string_0.IndexOf(".")) + ".swf";
		if (this.method_0(text))
		{
			movieClip = new BadAssMovieClip(this.mLoader, string_0);
		}
		return movieClip;
	}

	// Token: 0x06003538 RID: 13624 RVA: 0x000F1770 File Offset: 0x000EF970
	public IEnumerator method_12(string string_0)
	{
		string strAssetbundleName = "uniswf_" + string_0.Substring(0, string_0.IndexOf(".")) + ".assetbundle";
		if (!method_0(strAssetbundleName))
		{
			yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_4(strAssetbundleName));
			while (!ns0.MonoSingleton<AssetBundleManager>.Instance.method_10(strAssetbundleName))
			{
				yield return null;
			}
			method_1(strAssetbundleName);
		}
		yield return null;
	}
	// Token: 0x06003539 RID: 13625 RVA: 0x000F179C File Offset: 0x000EF99C
	public void method_13(string string_0)
	{
		if (string_0.StartsWith("CommonLib") || string_0.StartsWith("Warning.swf") || !mLoader.unloadSWF(string_0))
		{
			return;
		}
		Dictionary<string, Material>.Enumerator enumerator = TextureManager.instance.materials.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Key.StartsWith(string_0))
			{
				UnityEngine.Object.Destroy(enumerator.Current.Value);
			}
		}
		Dictionary<string, Texture>.Enumerator enumerator2 = TextureManager.instance.textures.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			if (enumerator2.Current.Key.StartsWith(string_0))
			{
				Resources.UnloadAsset(enumerator2.Current.Value);
			}
		}
	}
	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x0600353A RID: 13626 RVA: 0x00022F79 File Offset: 0x00021179
	public BadAssSWFResourceLoader BadAssSWFResourceLoader_0
	{
		get
		{
			return this.mLoader;
		}
	}

	// Token: 0x040024BB RID: 9403
	private static UniResourceManager mResourceManager;

	// Token: 0x040024BC RID: 9404
	private BadAssSWFResourceLoader mLoader;
}
