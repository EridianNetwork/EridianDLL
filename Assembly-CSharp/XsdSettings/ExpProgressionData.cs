using System;

namespace XsdSettings
{
	// Token: 0x020009C3 RID: 2499
	public class ExpProgressionData
	{
		// Token: 0x06004541 RID: 17729 RVA: 0x0002DD20 File Offset: 0x0002BF20
		public ExpProgressionData()
		{
			this.m_levelNumber = 0;
			this.m_expRequirement = 0;
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06004542 RID: 17730 RVA: 0x0002DD36 File Offset: 0x0002BF36
		// (set) Token: 0x06004543 RID: 17731 RVA: 0x0002DD3E File Offset: 0x0002BF3E
		public int m_levelNumber { get; set; }

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06004544 RID: 17732 RVA: 0x0002DD47 File Offset: 0x0002BF47
		// (set) Token: 0x06004545 RID: 17733 RVA: 0x0002DD4F File Offset: 0x0002BF4F
		public int m_expRequirement { get; set; }
	}
}
