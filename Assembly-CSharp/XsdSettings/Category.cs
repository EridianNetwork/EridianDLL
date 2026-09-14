using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A27 RID: 2599
	public class Category
	{
		// Token: 0x0600474D RID: 18253 RVA: 0x0002EE13 File Offset: 0x0002D013
		public Category()
		{
			this.mCategoryType = SettingCategory.Gameplay;
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x0600474E RID: 18254 RVA: 0x0002EE22 File Offset: 0x0002D022
		// (set) Token: 0x0600474F RID: 18255 RVA: 0x0002EE2A File Offset: 0x0002D02A
		public SettingCategory mCategoryType { get; set; }

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06004750 RID: 18256 RVA: 0x0002EE33 File Offset: 0x0002D033
		// (set) Token: 0x06004751 RID: 18257 RVA: 0x0002EE3B File Offset: 0x0002D03B
		[XmlArrayItem("mItem", IsNullable = false)]
		public SettingItem[] mConfigItems { get; set; }

		// Token: 0x0400331C RID: 13084
		private SettingItem[] mConfigItemsField;
	}
}
