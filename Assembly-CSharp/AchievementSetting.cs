using System;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200040F RID: 1039
public class AchievementSetting : MonoSingleton<AchievementSetting>
{
	// Token: 0x060019F0 RID: 6640 RVA: 0x000868FC File Offset: 0x00084AFC
	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("settings/Achievements");
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(global::XsdSettings.Achievements));
			this.m_Achievements = xmlSerializer.Deserialize(stringReader) as global::XsdSettings.Achievements;
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x0400116F RID: 4463
	public global::XsdSettings.Achievements m_Achievements = new global::XsdSettings.Achievements();
}
