using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A26 RID: 2598
	public class SettingMenuSetup
	{
		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x0600474B RID: 18251 RVA: 0x0002EE02 File Offset: 0x0002D002
		// (set) Token: 0x0600474C RID: 18252 RVA: 0x0002EE0A File Offset: 0x0002D00A
		[XmlArrayItem("mCategory", IsNullable = false)]
		public Category[] Settings { get; set; }

		// Token: 0x0400331A RID: 13082
		private Category[] settingsField;
	}
}
