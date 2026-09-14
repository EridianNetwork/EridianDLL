using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Core;

namespace XsdSettings
{
	// Token: 0x0200054A RID: 1354
	public class UI_SkillDisplaySetup
	{
		// Token: 0x060022E8 RID: 8936 RVA: 0x000A58EC File Offset: 0x000A3AEC
		public void method_0()
		{
			this.m_skillDisplayLUT.Clear();
			for (int i = 0; i < this.m_skillDisplaySetupList.Length; i++)
			{
				DisplayType displayType = DisplayType.Total;
				if (this.m_skillDisplayLUT.TryGetValue(this.m_skillDisplaySetupList[i].m_effectType, out displayType))
				{
					DebugUtils.LogError(LogCategory.Gamelogic, "Skill " + this.m_skillDisplaySetupList[i].m_effectType.ToString() + " UI display shouldn't have two setups. Pls give this to yihan");
				}
				else
				{
					this.m_skillDisplayLUT.Add(this.m_skillDisplaySetupList[i].m_effectType, this.m_skillDisplaySetupList[i].m_displayType);
				}
			}
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x000A5988 File Offset: 0x000A3B88
		public DisplayType method_1(EffectType effectType_0)
		{
			DisplayType displayType = DisplayType.Percentage;
			this.m_skillDisplayLUT.TryGetValue(effectType_0, out displayType);
			return displayType;
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060022EA RID: 8938 RVA: 0x00017F4E File Offset: 0x0001614E
		// (set) Token: 0x060022EB RID: 8939 RVA: 0x00017F56 File Offset: 0x00016156
		[XmlArrayItem("m_skillDisplay", IsNullable = false)]
		public SkillDisplayType[] m_skillDisplaySetupList { get; set; }

		// Token: 0x04001738 RID: 5944
		private Dictionary<EffectType, DisplayType> m_skillDisplayLUT = new Dictionary<EffectType, DisplayType>();

		// Token: 0x04001739 RID: 5945
		private SkillDisplayType[] m_skillDisplaySetupListField;
	}
}
