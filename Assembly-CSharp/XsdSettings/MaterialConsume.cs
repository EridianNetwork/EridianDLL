using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A58 RID: 2648
	public class MaterialConsume
	{
		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x0600481F RID: 18463 RVA: 0x0002F465 File Offset: 0x0002D665
		// (set) Token: 0x06004820 RID: 18464 RVA: 0x0002F46D File Offset: 0x0002D66D
		public WeaponType m_weaponType { get; set; }

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06004821 RID: 18465 RVA: 0x0002F476 File Offset: 0x0002D676
		// (set) Token: 0x06004822 RID: 18466 RVA: 0x0002F47E File Offset: 0x0002D67E
		[XmlArrayItem("m_consumedMaterial", IsNullable = false)]
		public ConsumedMaterial[] m_consumedMaterialList { get; set; }

		// Token: 0x0400345C RID: 13404
		private WeaponType m_weaponTypeField;

		// Token: 0x0400345D RID: 13405
		private ConsumedMaterial[] m_consumedMaterialListField;
	}
}
