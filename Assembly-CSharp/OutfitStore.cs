using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020008DD RID: 2269
public class OutfitStore
{
	// Token: 0x06003EA5 RID: 16037 RVA: 0x0002A38C File Offset: 0x0002858C
	public static string smethod_0()
	{
		return "Assets/Resources/Settings/Outfit.xml";
	}

	// Token: 0x06003EA6 RID: 16038 RVA: 0x0002A393 File Offset: 0x00028593
	public static string smethod_1()
	{
		return "Settings/Outfit";
	}

	// Token: 0x06003EA7 RID: 16039 RVA: 0x0002A39A File Offset: 0x0002859A
	public SubPartOutfit method_0(int int_0)
	{
		return this.m_setups.method_1(int_0);
	}

	// Token: 0x06003EA8 RID: 16040 RVA: 0x0002A3A8 File Offset: 0x000285A8
	public SubPartOutfit method_1(AvatarType avatarType_0, AvatarSubPart avatarSubPart_0, int int_0)
	{
		return this.method_0(SubPartOutfit.smethod_0(avatarType_0, avatarSubPart_0, int_0));
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x06003EA9 RID: 16041 RVA: 0x0002A3B8 File Offset: 0x000285B8
	// (set) Token: 0x06003EAA RID: 16042 RVA: 0x0002A3CB File Offset: 0x000285CB
	public static OutfitStore OutfitStore_0
	{
		get
		{
			if (OutfitStore.s_outfitStore == null)
			{
				OutfitStore.smethod_2();
			}
			return OutfitStore.s_outfitStore;
		}
		protected set
		{
			OutfitStore.s_outfitStore = value;
		}
	}

	// Token: 0x06003EAB RID: 16043 RVA: 0x0012A87C File Offset: 0x00128A7C
	private static void smethod_2()
	{
		OutfitStore.s_outfitStore = new OutfitStore();
		if (OutfitStore.s_outfitStore == null)
		{
			return;
		}
		TextAsset textAsset = ResourcesLoader.smethod_0(OutfitStore.smethod_1()) as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(OutfitStoreSetup));
		using (Stream stream = new MemoryStream(textAsset.bytes))
		{
			OutfitStore.s_outfitStore.m_setups = (OutfitStoreSetup)xmlSerializer.Deserialize(stream);
			if (OutfitStore.s_outfitStore.m_setups != null)
			{
				OutfitStore.s_outfitStore.m_setups.method_0();
			}
			stream.Close();
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}

	// Token: 0x04002C14 RID: 11284
	public const string AssetPath = "Assets/Resources/Settings/Outfit";

	// Token: 0x04002C15 RID: 11285
	public const string ResourcesAssetPath = "Settings/Outfit";

	// Token: 0x04002C16 RID: 11286
	public OutfitStoreSetup m_setups = new OutfitStoreSetup();

	// Token: 0x04002C17 RID: 11287
	private static OutfitStore s_outfitStore;
}
