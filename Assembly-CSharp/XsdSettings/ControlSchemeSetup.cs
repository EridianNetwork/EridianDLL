using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009A5 RID: 2469
	public class ControlSchemeSetup
	{
		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x060044AF RID: 17583 RVA: 0x0002D865 File Offset: 0x0002BA65
		// (set) Token: 0x060044B0 RID: 17584 RVA: 0x0002D86D File Offset: 0x0002BA6D
		[XmlArrayItem("mControlScheme", IsNullable = false)]
		public ControlScheme[] mControlSchemeList { get; set; }

		// Token: 0x0400301B RID: 12315
		private ControlScheme[] mControlSchemeListField;
	}
}
