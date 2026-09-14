using System;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000499 RID: 1177
public class LadderProgressionSetting : MonoSingleton<LadderProgressionSetting>
{
	// Token: 0x06001F79 RID: 8057 RVA: 0x0009AF44 File Offset: 0x00099144
	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/LadderProgression");
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(LadderProgression));
			this.m_progressionSetup = xmlSerializer.Deserialize(stringReader) as LadderProgression;
		}
		int num = 0;
		for (int i = 0; i < this.m_progressionSetup.m_progressionTable.Length; i++)
		{
			if (this.m_progressionSetup.m_progressionTable[i].m_maxLadder > num)
			{
				this.m_MaxLadderData = this.m_progressionSetup.m_progressionTable[i];
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x00015D23 File Offset: 0x00013F23
	public int method_0()
	{
		return this.m_MaxLadderData.m_maxLadder - 1;
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x0009AFFC File Offset: 0x000991FC
	public LadderProgressionData method_1(int int_0)
	{
		LadderProgressionData ladderProgressionData = this.m_MaxLadderData;
		if (int_0 >= this.method_0())
		{
			return ladderProgressionData;
		}
		for (int i = 0; i < this.m_progressionSetup.m_progressionTable.Length; i++)
		{
			if (int_0 >= this.m_progressionSetup.m_progressionTable[i].m_minLadder && int_0 < this.m_progressionSetup.m_progressionTable[i].m_maxLadder)
			{
				ladderProgressionData = this.m_progressionSetup.m_progressionTable[i];
				return ladderProgressionData;
			}
		}
		return ladderProgressionData;
	}

	// Token: 0x04001448 RID: 5192
	public LadderProgressionData m_MaxLadderData;

	// Token: 0x04001449 RID: 5193
	public LadderProgression m_progressionSetup = new LadderProgression();
}
