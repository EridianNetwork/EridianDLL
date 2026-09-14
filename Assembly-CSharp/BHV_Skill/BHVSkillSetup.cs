using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_Skill
{
	// Token: 0x020004C0 RID: 1216
	public class BHVSkillSetup
	{
		// Token: 0x060020C0 RID: 8384 RVA: 0x0009FAD0 File Offset: 0x0009DCD0
		public void method_0()
		{
			if (this.m_settings.Length <= 0)
			{
				return;
			}
			this.dictionary_0 = new Dictionary<Type, BHVSkillSettings>(this.m_settings.Length);
			for (int i = 0; i < this.m_settings.Length; i++)
			{
				this.dictionary_0.Add(this.m_settings[i].GetType(), this.m_settings[i]);
			}
		}

		// Token: 0x060020C1 RID: 8385 RVA: 0x0009FB30 File Offset: 0x0009DD30
		public T method_1<T>() where T : BHVSkillSettings
		{
			BHVSkillSettings bhvskillSettings = null;
			this.dictionary_0.TryGetValue(typeof(T), out bhvskillSettings);
			return (T)((object)bhvskillSettings);
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060020C2 RID: 8386 RVA: 0x00016BBD File Offset: 0x00014DBD
		// (set) Token: 0x060020C3 RID: 8387 RVA: 0x00016BC5 File Offset: 0x00014DC5
		[XmlArrayItem("m_skillSettings", IsNullable = false)]
		public BHVSkillSettings[] m_settings { get; set; }

		// Token: 0x04001578 RID: 5496
		private Dictionary<Type, BHVSkillSettings> dictionary_0;

		// Token: 0x04001579 RID: 5497
		private BHVSkillSettings[] bhvskillSettings_0;

		// Token: 0x0400157A RID: 5498
		[CompilerGenerated]
		private BHVSkillSettings[] bhvskillSettings_1;
	}
}
