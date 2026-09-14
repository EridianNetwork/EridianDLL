using System;

namespace XsdSettings
{
	// Token: 0x02000A59 RID: 2649
	public class ConsumedMaterial
	{
		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x06004824 RID: 18468 RVA: 0x0002F487 File Offset: 0x0002D687
		// (set) Token: 0x06004825 RID: 18469 RVA: 0x0002F48F File Offset: 0x0002D68F
		public MaterialType m_consumedMaterialType { get; set; }

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06004826 RID: 18470 RVA: 0x0002F498 File Offset: 0x0002D698
		// (set) Token: 0x06004827 RID: 18471 RVA: 0x0002F4A0 File Offset: 0x0002D6A0
		public int m_consumedMaterialNums { get; set; }

		// Token: 0x04003460 RID: 13408
		private MaterialType m_consumedMaterialTypeField;
	}
}
