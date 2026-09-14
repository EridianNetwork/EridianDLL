using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009AD RID: 2477
	public class EchoMessagesSetup
	{
		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x060044C6 RID: 17606 RVA: 0x0002D8FE File Offset: 0x0002BAFE
		// (set) Token: 0x060044C7 RID: 17607 RVA: 0x0002D906 File Offset: 0x0002BB06
		[XmlArrayItem("m_message", IsNullable = false)]
		public EchoMessage[] m_messages { get; set; }

		// Token: 0x040030B8 RID: 12472
		private EchoMessage[] m_messagesField;
	}
}
