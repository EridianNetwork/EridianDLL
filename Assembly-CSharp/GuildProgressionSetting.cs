using System;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000480 RID: 1152
public class GuildProgressionSetting : MonoSingleton<GuildProgressionSetting>
{
	// Token: 0x06001E2B RID: 7723 RVA: 0x00096210 File Offset: 0x00094410
	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/GuildProgression");
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(GuildProgression));
			this.m_progressionSetup = xmlSerializer.Deserialize(stringReader) as GuildProgression;
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06001E2C RID: 7724 RVA: 0x000152B3 File Offset: 0x000134B3
	public GuildSkillData method_0(int int_0)
	{
		if (int_0 >= 0 && int_0 <= this.m_progressionSetup.m_guildSkills.Length)
		{
			return this.m_progressionSetup.m_guildSkills[int_0];
		}
		return null;
	}

	// Token: 0x06001E2D RID: 7725 RVA: 0x000152D8 File Offset: 0x000134D8
	public PvEGuildExpFactorDataList method_1()
	{
		return this.m_progressionSetup.m_guildExpFactors.m_PvEGuildExpFactors;
	}

	// Token: 0x06001E2E RID: 7726 RVA: 0x000152EA File Offset: 0x000134EA
	public PvPGuildExpFactorDataList method_2()
	{
		return this.m_progressionSetup.m_guildExpFactors.m_PvPGuildExpFactors;
	}

	// Token: 0x040013BD RID: 5053
	public GuildProgression m_progressionSetup = new GuildProgression();
}
