using System;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;

// Token: 0x0200014C RID: 332
public class BuildingKitXmlLoader : BuildingKitLoader
{
	// Token: 0x0600079B RID: 1947 RVA: 0x00007F7E File Offset: 0x0000617E
	public BuildingKitXmlLoader(string string_0)
	{
		this.str = string_0;
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x00057CF4 File Offset: 0x00055EF4
	protected override object vmethod_1()
	{
		string text = this.str;
		TextAsset textAsset = ResourcesLoader.smethod_0(text) as TextAsset;
		ComposableCharacter composableCharacter;
		using (MemoryStream memoryStream = new MemoryStream(textAsset.bytes))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ComposableCharacter));
			composableCharacter = (ComposableCharacter)xmlSerializer.Deserialize(memoryStream);
			if (MonoSingleton<AppManager>.Instance != null && MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				composableCharacter.m_aParts.Clear();
			}
			memoryStream.Close();
		}
		ResourcesLoader.smethod_6(textAsset);
		return composableCharacter;
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x00007F8D File Offset: 0x0000618D
	protected override uint vmethod_0()
	{
		return Utility.smethod_1(this.str);
	}

	// Token: 0x040006C3 RID: 1731
	private string str;
}
