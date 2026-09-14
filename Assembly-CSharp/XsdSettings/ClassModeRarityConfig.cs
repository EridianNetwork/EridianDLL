using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x0200099D RID: 2461
	public class ClassModeRarityConfig
	{
		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x0600448F RID: 17551 RVA: 0x0002D799 File Offset: 0x0002B999
		// (set) Token: 0x06004490 RID: 17552 RVA: 0x0002D7A1 File Offset: 0x0002B9A1
		public ClassModeType m_classModeType { get; set; }

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06004491 RID: 17553 RVA: 0x0002D7AA File Offset: 0x0002B9AA
		// (set) Token: 0x06004492 RID: 17554 RVA: 0x0002D7B2 File Offset: 0x0002B9B2
		[XmlArrayItem("m_rarityType", IsNullable = false)]
		public ClassModeRarityTypeConfig[] m_raritiyTypes { get; set; }

		// Token: 0x04003005 RID: 12293
		private ClassModeType m_classModeTypeField;

		// Token: 0x04003006 RID: 12294
		private ClassModeRarityTypeConfig[] m_raritiyTypesField;
	}
}
