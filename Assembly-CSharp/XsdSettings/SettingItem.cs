using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A29 RID: 2601
	public class SettingItem
	{
		// Token: 0x06004752 RID: 18258 RVA: 0x0012F6CC File Offset: 0x0012D8CC
		public SettingItem()
		{
			this.mDisplayType = SettingDisplayType.Range;
			this.mTitle = string.Empty;
			this.mDescription = string.Empty;
			this.mFunctionType = SettingFunctionType.ScreenResolution;
			this.mStoreLocation = SettingStoreLocation.Server;
			this.mDefaultFloat = -1f;
			this.mDefaultInt = -1;
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06004753 RID: 18259 RVA: 0x0002EE44 File Offset: 0x0002D044
		// (set) Token: 0x06004754 RID: 18260 RVA: 0x0002EE4C File Offset: 0x0002D04C
		public SettingDisplayType mDisplayType { get; set; }

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06004755 RID: 18261 RVA: 0x0002EE55 File Offset: 0x0002D055
		// (set) Token: 0x06004756 RID: 18262 RVA: 0x0002EE5D File Offset: 0x0002D05D
		public string mTitle { get; set; }

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06004757 RID: 18263 RVA: 0x0002EE66 File Offset: 0x0002D066
		// (set) Token: 0x06004758 RID: 18264 RVA: 0x0002EE6E File Offset: 0x0002D06E
		public string mDescription { get; set; }

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06004759 RID: 18265 RVA: 0x0002EE77 File Offset: 0x0002D077
		// (set) Token: 0x0600475A RID: 18266 RVA: 0x0002EE7F File Offset: 0x0002D07F
		public SettingFunctionType mFunctionType { get; set; }

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x0600475B RID: 18267 RVA: 0x0002EE88 File Offset: 0x0002D088
		// (set) Token: 0x0600475C RID: 18268 RVA: 0x0002EE90 File Offset: 0x0002D090
		public SettingStoreLocation mStoreLocation { get; set; }

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x0600475D RID: 18269 RVA: 0x0002EE99 File Offset: 0x0002D099
		// (set) Token: 0x0600475E RID: 18270 RVA: 0x0002EEA1 File Offset: 0x0002D0A1
		public IntPair mRange { get; set; }

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x0600475F RID: 18271 RVA: 0x0002EEAA File Offset: 0x0002D0AA
		// (set) Token: 0x06004760 RID: 18272 RVA: 0x0002EEB2 File Offset: 0x0002D0B2
		[XmlArrayItem("mResolutions", IsNullable = false)]
		public IntPair[] mResolutions { get; set; }

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x06004761 RID: 18273 RVA: 0x0002EEBB File Offset: 0x0002D0BB
		// (set) Token: 0x06004762 RID: 18274 RVA: 0x0002EEC3 File Offset: 0x0002D0C3
		[XmlArrayItem("mQuality", IsNullable = false)]
		public QualityLevel[] mQualitys { get; set; }

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06004763 RID: 18275 RVA: 0x0002EECC File Offset: 0x0002D0CC
		// (set) Token: 0x06004764 RID: 18276 RVA: 0x0002EED4 File Offset: 0x0002D0D4
		[XmlArrayItem("mFrameRate", IsNullable = false)]
		public FrameRate[] mFrameRates { get; set; }

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06004765 RID: 18277 RVA: 0x0002EEDD File Offset: 0x0002D0DD
		// (set) Token: 0x06004766 RID: 18278 RVA: 0x0002EEE5 File Offset: 0x0002D0E5
		[XmlArrayItem("StrValue", IsNullable = false)]
		public string[] mControlSchemeList { get; set; }

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06004767 RID: 18279 RVA: 0x0002EEEE File Offset: 0x0002D0EE
		// (set) Token: 0x06004768 RID: 18280 RVA: 0x0002EEF6 File Offset: 0x0002D0F6
		[DefaultValue(typeof(float), "-1")]
		public float mDefaultFloat { get; set; }

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x06004769 RID: 18281 RVA: 0x0002EEFF File Offset: 0x0002D0FF
		// (set) Token: 0x0600476A RID: 18282 RVA: 0x0002EF07 File Offset: 0x0002D107
		[DefaultValue(-1)]
		public int mDefaultInt { get; set; }

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x0600476B RID: 18283 RVA: 0x0002EF10 File Offset: 0x0002D110
		// (set) Token: 0x0600476C RID: 18284 RVA: 0x0002EF18 File Offset: 0x0002D118
		public bool mDefaultBool { get; set; }

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x0600476D RID: 18285 RVA: 0x0002EF21 File Offset: 0x0002D121
		// (set) Token: 0x0600476E RID: 18286 RVA: 0x0002EF29 File Offset: 0x0002D129
		[XmlIgnore]
		public bool mDefaultBoolSpecified { get; set; }

		// Token: 0x04003325 RID: 13093
		private IntPair mRangeField;

		// Token: 0x04003326 RID: 13094
		private IntPair[] mResolutionsField;

		// Token: 0x04003327 RID: 13095
		private QualityLevel[] mQualitysField;

		// Token: 0x04003328 RID: 13096
		private FrameRate[] mFrameRatesField;
	}
}
