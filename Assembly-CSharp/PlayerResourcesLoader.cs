using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000134 RID: 308
public class PlayerResourcesLoader : ServiceWrapperBase<PlayerResourcesLoader>
{
	// Token: 0x06000715 RID: 1813 RVA: 0x00007A7F File Offset: 0x00005C7F
	public PlayerResourcesLoader()
	{
		this.method_1();
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x00007A8D File Offset: 0x00005C8D
	public bool method_0()
	{
		return null != this.m_resources;
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x000559F0 File Offset: 0x00053BF0
	private void method_1()
	{
		try
		{
			TextAsset textAsset = ResourcesLoader.smethod_0("Audio/Resource/PlayerAudioResources") as TextAsset;
			using (StringReader stringReader = new StringReader(textAsset.text))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerResources));
				this.m_resources = xmlSerializer.Deserialize(stringReader) as PlayerResources;
			}
			ResourcesLoader.smethod_6(textAsset);
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Audio, "Failed loading player resources: " + ex.Message + "\nfrom: " + ex.StackTrace);
			this.m_resources = null;
		}
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x00007A9B File Offset: 0x00005C9B
	private static List<string> smethod_0(IEnumerable<string> ienumerable_0)
	{
		return ienumerable_0.Distinct<string>().Select<string, string>(new Func<string, string>(PlayerResourcesLoader.smethod_1)).ToList<string>();
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x00055A98 File Offset: 0x00053C98
	private AvatarType[] method_2()
	{
		AvatarType[] array = new AvatarType[4];
		for (int i = 0; i < 4; i++)
		{
			array[i] = (AvatarType)i;
		}
		return array;
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x00055AC0 File Offset: 0x00053CC0
	public List<string> method_3(AvatarType avatarType_0, AvatarType[] avatarType_1 = null)
	{
		if (!this.method_0())
		{
			DebugUtils.LogError(LogCategory.Audio, "GetPlayerAssetBundleNames: PlayerResources not loaded");
			return null;
		}
		DebugUtils.Log(LogCategory.Audio, "Listing game map player audio bundles, with local avatar: " + avatarType_0);
		List<string> list = new List<string>();
		list.AddRange(this.method_5());
		string[] array = this.method_7(avatarType_0, true);
		if (array != null)
		{
			list.AddRange(array);
		}
		if (avatarType_1 == null)
		{
			avatarType_1 = this.method_2();
		}
		foreach (AvatarType avatarType in avatarType_1)
		{
			string[] array3 = this.method_7(avatarType, false);
			if (array3 != null)
			{
				list.AddRange(array3);
			}
		}
		return PlayerResourcesLoader.smethod_0(list);
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x00055B60 File Offset: 0x00053D60
	public List<string> method_4(AvatarType avatarType_0)
	{
		if (!this.method_0())
		{
			DebugUtils.LogError(LogCategory.Audio, "GetPlayerAssetBundleNames: PlayerResources not loaded");
			return null;
		}
		DebugUtils.Log(LogCategory.Audio, "Listing town map player audio bundles, with local avatar: " + avatarType_0);
		List<string> list = new List<string>();
		list.AddRange(this.method_6());
		foreach (PlayerResources.BundleSet bundleSet in this.m_resources.m_playerTownBundleSets)
		{
			if (bundleSet.m_bundles != null)
			{
				list.AddRange(bundleSet.m_bundles);
			}
		}
		return PlayerResourcesLoader.smethod_0(list);
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x00007ACA File Offset: 0x00005CCA
	private string[] method_5()
	{
		if (!this.method_0())
		{
			DebugUtils.LogError(LogCategory.Audio, "PlayerResources already loaded");
			return null;
		}
		return this.m_resources.m_commonBundleSet.m_bundles;
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x00007AF1 File Offset: 0x00005CF1
	private string[] method_6()
	{
		if (!this.method_0())
		{
			DebugUtils.LogError(LogCategory.Audio, "PlayerResources already loaded");
			return null;
		}
		return this.m_resources.m_commonTownBundleSet.m_bundles;
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00055BE4 File Offset: 0x00053DE4
	private string[] method_7(AvatarType avatarType_0, bool bool_1)
	{
		if (!this.method_0())
		{
			DebugUtils.LogError(LogCategory.Audio, "PlayerResources already loaded");
			return null;
		}
		PlayerResources.BundleSet[] array = ((!bool_1) ? this.m_resources.m_classSpecificBundleSets : this.m_resources.m_localPlayerBundleSets);
		PlayerResources.BundleSet bundleSet = array[(int)avatarType_0];
		return bundleSet.m_bundles;
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x00007B18 File Offset: 0x00005D18
	[CompilerGenerated]
	private static string smethod_1(string string_0)
	{
		return string_0 + ".assetbundle";
	}

	// Token: 0x0400065F RID: 1631
	public const string ASSETBUNDLE_EXTENSION = ".assetbundle";

	// Token: 0x04000660 RID: 1632
	public const string PLAYER_RESOURCES_RESOURCE_PATH = "Audio/Resource/PlayerAudioResources";

	// Token: 0x04000661 RID: 1633
	private PlayerResources m_resources;
}
