using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000994 RID: 2452
	public class CharacterStoreSetup
	{
		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06004456 RID: 17494 RVA: 0x0002D5C8 File Offset: 0x0002B7C8
		// (set) Token: 0x06004457 RID: 17495 RVA: 0x0002D5D0 File Offset: 0x0002B7D0
		[XmlArrayItem("m_characterSetup", IsNullable = false)]
		public CharacterSetup[] m_characterSetups { get; set; }

		// Token: 0x04002FE2 RID: 12258
		private CharacterSetup[] m_characterSetupsField;
	}
}
