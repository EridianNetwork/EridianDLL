using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009A6 RID: 2470
	public class ControlScheme
	{
		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x060044B2 RID: 17586 RVA: 0x0002D876 File Offset: 0x0002BA76
		// (set) Token: 0x060044B3 RID: 17587 RVA: 0x0002D87E File Offset: 0x0002BA7E
		public string mID { get; set; }

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x060044B4 RID: 17588 RVA: 0x0002D887 File Offset: 0x0002BA87
		// (set) Token: 0x060044B5 RID: 17589 RVA: 0x0002D88F File Offset: 0x0002BA8F
		[XmlArrayItem("mKeyBindings", IsNullable = false)]
		public KeyBindingItem[] mKeyBindingList { get; set; }

		// Token: 0x0400301D RID: 12317
		private KeyBindingItem[] mKeyBindingListField;
	}
}
