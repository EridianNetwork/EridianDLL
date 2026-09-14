using System;
using System.ComponentModel;

namespace XsdSettings
{
	// Token: 0x020009BF RID: 2495
	public class GuidanceTip
	{
		// Token: 0x0600452C RID: 17708 RVA: 0x0002DC71 File Offset: 0x0002BE71
		public GuidanceTip()
		{
			this.m_trigger = TipTrigger.LevelUp;
			this.m_value = 1;
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x0600452D RID: 17709 RVA: 0x0002DC87 File Offset: 0x0002BE87
		// (set) Token: 0x0600452E RID: 17710 RVA: 0x0002DC8F File Offset: 0x0002BE8F
		public string m_id { get; set; }

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x0600452F RID: 17711 RVA: 0x0002DC98 File Offset: 0x0002BE98
		// (set) Token: 0x06004530 RID: 17712 RVA: 0x0002DCA0 File Offset: 0x0002BEA0
		public string m_echoMsgId { get; set; }

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06004531 RID: 17713 RVA: 0x0002DCA9 File Offset: 0x0002BEA9
		// (set) Token: 0x06004532 RID: 17714 RVA: 0x0002DCB1 File Offset: 0x0002BEB1
		public TipTrigger m_trigger { get; set; }

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06004533 RID: 17715 RVA: 0x0002DCBA File Offset: 0x0002BEBA
		// (set) Token: 0x06004534 RID: 17716 RVA: 0x0002DCC2 File Offset: 0x0002BEC2
		[DefaultValue(1)]
		public int m_value { get; set; }
	}
}
