using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A3E RID: 2622
	public class Shop
	{
		// Token: 0x060047A3 RID: 18339 RVA: 0x0002F09E File Offset: 0x0002D29E
		public Shop()
		{
			this.m_id = 0;
			this.m_refreshTime = 3600;
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x060047A4 RID: 18340 RVA: 0x0002F0B8 File Offset: 0x0002D2B8
		// (set) Token: 0x060047A5 RID: 18341 RVA: 0x0002F0C0 File Offset: 0x0002D2C0
		public int m_id { get; set; }

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x060047A6 RID: 18342 RVA: 0x0002F0C9 File Offset: 0x0002D2C9
		// (set) Token: 0x060047A7 RID: 18343 RVA: 0x0002F0D1 File Offset: 0x0002D2D1
		public int m_refreshTime { get; set; }

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x060047A8 RID: 18344 RVA: 0x0002F0DA File Offset: 0x0002D2DA
		// (set) Token: 0x060047A9 RID: 18345 RVA: 0x0002F0E2 File Offset: 0x0002D2E2
		[XmlArrayItem("m_itemAvailabilitySettings", IsNullable = false)]
		public ItemAvailabilitySettings[] m_itemAvailabilitySettingsList { get; set; }

		// Token: 0x04003386 RID: 13190
		private ItemAvailabilitySettings[] m_itemAvailabilitySettingsListField;
	}
}
