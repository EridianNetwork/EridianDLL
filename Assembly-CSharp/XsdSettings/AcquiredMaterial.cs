using System;

namespace XsdSettings
{
	// Token: 0x02000A85 RID: 2693
	public class AcquiredMaterial
	{
		// Token: 0x060048DE RID: 18654 RVA: 0x0002F9BA File Offset: 0x0002DBBA
		public AcquiredMaterial()
		{
			this.m_Percentage = 100;
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x060048DF RID: 18655 RVA: 0x0002F9CA File Offset: 0x0002DBCA
		// (set) Token: 0x060048E0 RID: 18656 RVA: 0x0002F9D2 File Offset: 0x0002DBD2
		public MaterialType m_MaterialType { get; set; }

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x060048E1 RID: 18657 RVA: 0x0002F9DB File Offset: 0x0002DBDB
		// (set) Token: 0x060048E2 RID: 18658 RVA: 0x0002F9E3 File Offset: 0x0002DBE3
		public int m_MaterialNums { get; set; }

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x060048E3 RID: 18659 RVA: 0x0002F9EC File Offset: 0x0002DBEC
		// (set) Token: 0x060048E4 RID: 18660 RVA: 0x0002F9F4 File Offset: 0x0002DBF4
		public int m_Percentage { get; set; }

		// Token: 0x04003578 RID: 13688
		private MaterialType m_MaterialTypeField;
	}
}
