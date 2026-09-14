using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020008EE RID: 2286
public class StarLevelAttributeStore
{
	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06003EE8 RID: 16104 RVA: 0x0002A5D6 File Offset: 0x000287D6
	// (set) Token: 0x06003EE9 RID: 16105 RVA: 0x0002A5E9 File Offset: 0x000287E9
	public static StarLevelAttributeStore StarLevelAttributeStore_0
	{
		get
		{
			if (StarLevelAttributeStore.s_starLevelAttributeStore == null)
			{
				StarLevelAttributeStore.smethod_0();
			}
			return StarLevelAttributeStore.s_starLevelAttributeStore;
		}
		protected set
		{
			StarLevelAttributeStore.s_starLevelAttributeStore = value;
		}
	}

	// Token: 0x06003EEA RID: 16106 RVA: 0x0002A5F1 File Offset: 0x000287F1
	public List<SingleWeaponAttribute> method_0(WeaponType weaponType_0, int int_0)
	{
		return this.m_starLevelAttrSetup.method_1(weaponType_0, int_0);
	}

	// Token: 0x06003EEB RID: 16107 RVA: 0x0002A600 File Offset: 0x00028800
	public int method_1(WeaponType weaponType_0, int int_0, int int_1, WeaponRarity weaponRarity_0)
	{
		return this.m_starLevelUpgradeSetup.method_0(weaponType_0, int_0, int_1, weaponRarity_0);
	}

	// Token: 0x06003EEC RID: 16108 RVA: 0x0002A612 File Offset: 0x00028812
	public ConsumedMaterial[] method_2(WeaponType weaponType_0)
	{
		return this.m_starExpUpgradeSetup.method_0(weaponType_0);
	}

	// Token: 0x06003EED RID: 16109 RVA: 0x0002A620 File Offset: 0x00028820
	public ItemConsume method_3(WeaponType weaponType_0, int int_0)
	{
		return this.m_starLevelUpgradeSetup.method_1(weaponType_0, int_0);
	}

	// Token: 0x06003EEE RID: 16110 RVA: 0x0012B7A8 File Offset: 0x001299A8
	private static void smethod_0()
	{
		StarLevelAttributeStore.s_starLevelAttributeStore = new StarLevelAttributeStore();
		if (StarLevelAttributeStore.s_starLevelAttributeStore == null)
		{
			return;
		}
		TextAsset textAsset = ResourcesLoader.smethod_0("Settings/StarLevelAttributeSetup") as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(StarLevelAttributeSetup));
		using (Stream stream = new MemoryStream(textAsset.bytes))
		{
			StarLevelAttributeStore.s_starLevelAttributeStore.m_starLevelAttrSetup = (StarLevelAttributeSetup)xmlSerializer.Deserialize(stream);
			stream.Close();
		}
		Resources.UnloadAsset(textAsset);
		TextAsset textAsset2 = ResourcesLoader.smethod_0("Settings/StarLevelUpgrade") as TextAsset;
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(StarLevelUpgradeSetup));
		using (Stream stream2 = new MemoryStream(textAsset2.bytes))
		{
			StarLevelAttributeStore.s_starLevelAttributeStore.m_starLevelUpgradeSetup = (StarLevelUpgradeSetup)xmlSerializer2.Deserialize(stream2);
			stream2.Close();
		}
		Resources.UnloadAsset(textAsset2);
		TextAsset textAsset3 = ResourcesLoader.smethod_0("Settings/StarExpUpgrade") as TextAsset;
		XmlSerializer xmlSerializer3 = new XmlSerializer(typeof(StarExpUpgradeSetup));
		using (Stream stream3 = new MemoryStream(textAsset3.bytes))
		{
			StarLevelAttributeStore.s_starLevelAttributeStore.m_starExpUpgradeSetup = (StarExpUpgradeSetup)xmlSerializer3.Deserialize(stream3);
			stream3.Close();
		}
		Resources.UnloadAsset(textAsset3);
		DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}

	// Token: 0x04002C41 RID: 11329
	public const string LevelAttributeAssetPath = "Settings/StarLevelAttributeSetup";

	// Token: 0x04002C42 RID: 11330
	public const string LevelUpgradeAssetPath = "Settings/StarLevelUpgrade";

	// Token: 0x04002C43 RID: 11331
	public const string ExpUpgradeAssetPath = "Settings/StarExpUpgrade";

	// Token: 0x04002C44 RID: 11332
	public StarLevelAttributeSetup m_starLevelAttrSetup = new StarLevelAttributeSetup();

	// Token: 0x04002C45 RID: 11333
	public StarLevelUpgradeSetup m_starLevelUpgradeSetup = new StarLevelUpgradeSetup();

	// Token: 0x04002C46 RID: 11334
	public StarExpUpgradeSetup m_starExpUpgradeSetup = new StarExpUpgradeSetup();

	// Token: 0x04002C47 RID: 11335
	private static StarLevelAttributeStore s_starLevelAttributeStore;
}
