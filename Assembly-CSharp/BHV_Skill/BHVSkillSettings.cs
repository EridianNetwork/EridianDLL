using System;
using System.Xml.Serialization;

namespace BHV_Skill
{
	// Token: 0x02000962 RID: 2402
	[XmlInclude(typeof(BHVSkillSettingsFireBird))]
	[XmlInclude(typeof(BHVSkillSettingsTurret))]
	[XmlInclude(typeof(BHVSkillSettingsHunter))]
	[XmlInclude(typeof(BHVSkillSettingsBerserk))]
	public class BHVSkillSettings
	{
	}
}
