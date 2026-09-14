using System;

namespace XsdSettings
{
	// Token: 0x02000A2D RID: 2605
	public class IntPair
	{
		// Token: 0x0600476F RID: 18287 RVA: 0x0002EF32 File Offset: 0x0002D132
		public IntPair()
		{
			this.LeftValue = 0;
			this.RightValue = 0;
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x06004770 RID: 18288 RVA: 0x0002EF48 File Offset: 0x0002D148
		// (set) Token: 0x06004771 RID: 18289 RVA: 0x0002EF50 File Offset: 0x0002D150
		public int LeftValue { get; set; }

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x06004772 RID: 18290 RVA: 0x0002EF59 File Offset: 0x0002D159
		// (set) Token: 0x06004773 RID: 18291 RVA: 0x0002EF61 File Offset: 0x0002D161
		public int RightValue { get; set; }
	}
}
