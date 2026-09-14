using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000548 RID: 1352
public class PassiveSkillsManager : MonoBehaviour
{
	// Token: 0x060022DF RID: 8927 RVA: 0x00017EE5 File Offset: 0x000160E5
	private PassiveSkillsManager()
	{
	}

	// Token: 0x060022E0 RID: 8928 RVA: 0x00017EF8 File Offset: 0x000160F8
	private void Awake()
	{
		PassiveSkillsManager.s_instance = this;
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x060022E1 RID: 8929 RVA: 0x00017F00 File Offset: 0x00016100
	public static PassiveSkillsManager PassiveSkillsManager_0
	{
		get
		{
			if (PassiveSkillsManager.s_instance == null)
			{
				PassiveSkillsManager.s_instance = new PassiveSkillsManager();
			}
			return PassiveSkillsManager.s_instance;
		}
	}

	// Token: 0x060022E2 RID: 8930 RVA: 0x000A573C File Offset: 0x000A393C
	public void Start()
	{
		TextAsset textAsset = ResourcesLoader.smethod_0("Entities/PassiveSkillsTable") as TextAsset;
		using (MemoryStream memoryStream = new MemoryStream(textAsset.bytes))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PassiveSkillSettings>));
			this.m_passiveSkills = xmlSerializer.Deserialize(memoryStream) as List<PassiveSkillSettings>;
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x060022E3 RID: 8931 RVA: 0x000A57AC File Offset: 0x000A39AC
	public List<PassiveSkillSettings> method_0(List<PassiveSkill> list_0)
	{
		List<PassiveSkillSettings> list = new List<PassiveSkillSettings>();
		ELevelDifficulty difficulty = MonoSingleton<AppManager>.Instance.m_difficulty;
		int num = 0;
		int num2 = 0;
		foreach (PassiveSkill passiveSkill in list_0)
		{
			num2 += passiveSkill.m_probability;
		}
		int num3 = global::UnityEngine.Random.Range(0, num2);
		int num4 = 0;
		foreach (PassiveSkill passiveSkill2 in list_0)
		{
			foreach (PassiveSkillSettings passiveSkillSettings in this.m_passiveSkills)
			{
				if (num <= (int)difficulty && passiveSkill2.m_skillID == passiveSkillSettings.m_skillID && passiveSkill2.m_passiveSkillType == passiveSkillSettings.m_skillType && num3 < num4 + passiveSkill2.m_probability && num3 >= num4)
				{
					list.Add(passiveSkillSettings);
					num++;
				}
			}
			num4 += passiveSkill2.m_probability;
		}
		return list;
	}

	// Token: 0x04001736 RID: 5942
	private List<PassiveSkillSettings> m_passiveSkills = new List<PassiveSkillSettings>();

	// Token: 0x04001737 RID: 5943
	private static PassiveSkillsManager s_instance;
}
