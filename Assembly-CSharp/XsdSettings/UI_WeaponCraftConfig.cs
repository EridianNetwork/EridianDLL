using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A76 RID: 2678
	public class UI_WeaponCraftConfig
	{
		// Token: 0x06004896 RID: 18582 RVA: 0x0002F7A8 File Offset: 0x0002D9A8
		public UI_WeaponCraftConfig()
		{
			this.Stage = 0;
			this.DisplayLevel = 0;
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06004897 RID: 18583 RVA: 0x0002F7BE File Offset: 0x0002D9BE
		// (set) Token: 0x06004898 RID: 18584 RVA: 0x0002F7C6 File Offset: 0x0002D9C6
		public int Stage { get; set; }

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x06004899 RID: 18585 RVA: 0x0002F7CF File Offset: 0x0002D9CF
		// (set) Token: 0x0600489A RID: 18586 RVA: 0x0002F7D7 File Offset: 0x0002D9D7
		public int DisplayLevel { get; set; }

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x0600489B RID: 18587 RVA: 0x0002F7E0 File Offset: 0x0002D9E0
		// (set) Token: 0x0600489C RID: 18588 RVA: 0x0002F7E8 File Offset: 0x0002D9E8
		[XmlArrayItem("WeaponID", IsNullable = false)]
		public int[] Weapons { get; set; }
	}
}
