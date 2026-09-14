using System;

namespace XsdSettings
{
	// Token: 0x02000997 RID: 2455
	public class AmmoSetup
	{
		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06004479 RID: 17529 RVA: 0x0002D711 File Offset: 0x0002B911
		// (set) Token: 0x0600447A RID: 17530 RVA: 0x0002D719 File Offset: 0x0002B919
		public AmmoType m_ammoType { get; set; }

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x0600447B RID: 17531 RVA: 0x0002D722 File Offset: 0x0002B922
		// (set) Token: 0x0600447C RID: 17532 RVA: 0x0002D72A File Offset: 0x0002B92A
		public int m_ammoCount { get; set; }

		// Token: 0x04002FF7 RID: 12279
		private AmmoType m_ammoTypeField;
	}
}
