using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020008F6 RID: 2294
public class SubPartShieldStore
{
	// Token: 0x06003F5A RID: 16218 RVA: 0x0002A9FD File Offset: 0x00028BFD
	public static string smethod_0()
	{
		return "Assets/Resources/WeaponEditor/SubParts_Shield.xml";
	}

	// Token: 0x06003F5B RID: 16219 RVA: 0x0002AA04 File Offset: 0x00028C04
	public static string smethod_1()
	{
		return "WeaponEditor/SubParts_Shield";
	}

	// Token: 0x06003F5C RID: 16220 RVA: 0x0002AA0B File Offset: 0x00028C0B
	public SubPartShield method_0(int int_0)
	{
		return this.m_setups.method_1(int_0);
	}

	// Token: 0x06003F5D RID: 16221 RVA: 0x0002AA19 File Offset: 0x00028C19
	public SubPartShield method_1(ShieldSubPart shieldSubPart_0, int int_0)
	{
		return this.method_0(SubPartShield.smethod_0(shieldSubPart_0, int_0));
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x06003F5E RID: 16222 RVA: 0x0002AA28 File Offset: 0x00028C28
	// (set) Token: 0x06003F5F RID: 16223 RVA: 0x0002AA3B File Offset: 0x00028C3B
	public static SubPartShieldStore SubPartShieldStore_0
	{
		get
		{
			if (SubPartShieldStore.s_subPartShieldStore == null)
			{
				SubPartShieldStore.smethod_2();
			}
			return SubPartShieldStore.s_subPartShieldStore;
		}
		protected set
		{
			SubPartShieldStore.s_subPartShieldStore = value;
		}
	}

	// Token: 0x06003F60 RID: 16224 RVA: 0x0012BBF8 File Offset: 0x00129DF8
	private static void smethod_2()
	{
		SubPartShieldStore.s_subPartShieldStore = new SubPartShieldStore();
		if (SubPartShieldStore.s_subPartShieldStore == null)
		{
			return;
		}
		TextAsset textAsset = ResourcesLoader.smethod_0(SubPartShieldStore.smethod_1()) as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SubPartShieldStoreSetup));
		using (Stream stream = new MemoryStream(textAsset.bytes))
		{
			SubPartShieldStore.s_subPartShieldStore.m_setups = (SubPartShieldStoreSetup)xmlSerializer.Deserialize(stream);
			if (SubPartShieldStore.s_subPartShieldStore.m_setups != null)
			{
				SubPartShieldStore.s_subPartShieldStore.m_setups.method_0();
			}
			stream.Close();
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}

	// Token: 0x04002C81 RID: 11393
	public const string AssetPath = "Assets/Resources/WeaponEditor/SubParts_Shield";

	// Token: 0x04002C82 RID: 11394
	public const string ResourcesAssetPath = "WeaponEditor/SubParts_Shield";

	// Token: 0x04002C83 RID: 11395
	public SubPartShieldStoreSetup m_setups = new SubPartShieldStoreSetup();

	// Token: 0x04002C84 RID: 11396
	private static SubPartShieldStore s_subPartShieldStore;
}
