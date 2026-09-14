using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020008F4 RID: 2292
public class SubPartClassModeStore
{
	// Token: 0x06003F4D RID: 16205 RVA: 0x0002A97F File Offset: 0x00028B7F
	public static string smethod_0()
	{
		return "Assets/Resources/WeaponEditor/SubParts_ClassMode.xml";
	}

	// Token: 0x06003F4E RID: 16206 RVA: 0x0002A986 File Offset: 0x00028B86
	public static string smethod_1()
	{
		return "WeaponEditor/SubParts_ClassMode";
	}

	// Token: 0x06003F4F RID: 16207 RVA: 0x0002A98D File Offset: 0x00028B8D
	public SubPartClassMode method_0(int int_0)
	{
		return this.m_setups.method_1(int_0);
	}

	// Token: 0x06003F50 RID: 16208 RVA: 0x0002A99B File Offset: 0x00028B9B
	public SubPartClassMode method_1(ClassModeType classModeType_0, ClassModeSubPart classModeSubPart_0, int int_0)
	{
		return this.method_0(SubPartClassMode.smethod_0(classModeType_0, classModeSubPart_0, int_0));
	}

	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06003F51 RID: 16209 RVA: 0x0002A9AB File Offset: 0x00028BAB
	// (set) Token: 0x06003F52 RID: 16210 RVA: 0x0002A9BE File Offset: 0x00028BBE
	public static SubPartClassModeStore SubPartClassModeStore_0
	{
		get
		{
			if (SubPartClassModeStore.s_subPartClassModeStore == null)
			{
				SubPartClassModeStore.smethod_2();
			}
			return SubPartClassModeStore.s_subPartClassModeStore;
		}
		protected set
		{
			SubPartClassModeStore.s_subPartClassModeStore = value;
		}
	}

	// Token: 0x06003F53 RID: 16211 RVA: 0x0012BAD4 File Offset: 0x00129CD4
	private static void smethod_2()
	{
		SubPartClassModeStore.s_subPartClassModeStore = new SubPartClassModeStore();
		if (SubPartClassModeStore.s_subPartClassModeStore == null)
		{
			return;
		}
		TextAsset textAsset = ResourcesLoader.smethod_0(SubPartClassModeStore.smethod_1()) as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SubPartClassModeStoreSetup));
		using (Stream stream = new MemoryStream(textAsset.bytes))
		{
			SubPartClassModeStore.s_subPartClassModeStore.m_setups = (SubPartClassModeStoreSetup)xmlSerializer.Deserialize(stream);
			if (SubPartClassModeStore.s_subPartClassModeStore.m_setups != null)
			{
				SubPartClassModeStore.s_subPartClassModeStore.m_setups.method_0();
			}
			stream.Close();
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}

	// Token: 0x04002C7A RID: 11386
	public const string AssetPath = "Assets/Resources/WeaponEditor/SubParts_ClassMode";

	// Token: 0x04002C7B RID: 11387
	public const string ResourcesAssetPath = "WeaponEditor/SubParts_ClassMode";

	// Token: 0x04002C7C RID: 11388
	public SubPartClassModeStoreSetup m_setups = new SubPartClassModeStoreSetup();

	// Token: 0x04002C7D RID: 11389
	private static SubPartClassModeStore s_subPartClassModeStore;
}
