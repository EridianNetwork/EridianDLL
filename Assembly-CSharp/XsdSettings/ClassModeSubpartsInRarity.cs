using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x0200099F RID: 2463
	public class ClassModeSubpartsInRarity
	{
		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06004499 RID: 17561 RVA: 0x0002D7DD File Offset: 0x0002B9DD
		// (set) Token: 0x0600449A RID: 17562 RVA: 0x0002D7E5 File Offset: 0x0002B9E5
		public ClassModeSubPart m_classModeSubpart { get; set; }

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x0600449B RID: 17563 RVA: 0x0002D7EE File Offset: 0x0002B9EE
		// (set) Token: 0x0600449C RID: 17564 RVA: 0x0002D7F6 File Offset: 0x0002B9F6
		[XmlArrayItem("m_subpartChoice", IsNullable = false)]
		public ClassModeSubpartChoice[] m_subpartChoices { get; set; }

		// Token: 0x0400300D RID: 12301
		private ClassModeSubPart m_classModeSubpartField;

		// Token: 0x0400300E RID: 12302
		private ClassModeSubpartChoice[] m_subpartChoicesField;
	}
}
