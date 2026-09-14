using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x0200054B RID: 1355
public class SkillDisplayStore
{
	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x060022ED RID: 8941 RVA: 0x00017F72 File Offset: 0x00016172
	// (set) Token: 0x060022EE RID: 8942 RVA: 0x00017F85 File Offset: 0x00016185
	public static SkillDisplayStore SkillDisplayStore_0
	{
		get
		{
			if (SkillDisplayStore.s_skillDisplayStore == null)
			{
				SkillDisplayStore.smethod_0();
			}
			return SkillDisplayStore.s_skillDisplayStore;
		}
		protected set
		{
			SkillDisplayStore.s_skillDisplayStore = value;
		}
	}

	// Token: 0x060022EF RID: 8943 RVA: 0x000A59A8 File Offset: 0x000A3BA8
	private static void smethod_0()
	{
		SkillDisplayStore.s_skillDisplayStore = new SkillDisplayStore();
		TextAsset textAsset = ResourcesLoader.smethod_0("Settings/UI_SkillDisplay") as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(UI_SkillDisplaySetup));
		using (Stream stream = new MemoryStream(textAsset.bytes))
		{
			SkillDisplayStore.s_skillDisplayStore.m_skillDisplaySetup = (UI_SkillDisplaySetup)xmlSerializer.Deserialize(stream);
			if (SkillDisplayStore.s_skillDisplayStore.m_skillDisplaySetup != null)
			{
				SkillDisplayStore.s_skillDisplayStore.m_skillDisplaySetup.method_0();
			}
			stream.Close();
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.Log(LogCategory.Framework, "System.GC.Collect SkillDisplay");
		GC.Collect();
	}

	// Token: 0x0400173B RID: 5947
	public const string ResourcesAssetPath = "Settings/UI_SkillDisplay";

	// Token: 0x0400173C RID: 5948
	public UI_SkillDisplaySetup m_skillDisplaySetup = new UI_SkillDisplaySetup();

	// Token: 0x0400173D RID: 5949
	private static SkillDisplayStore s_skillDisplayStore;
}
