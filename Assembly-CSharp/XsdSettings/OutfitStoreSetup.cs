using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008DC RID: 2268
	public class OutfitStoreSetup
	{
		// Token: 0x06003EA0 RID: 16032 RVA: 0x0012A80C File Offset: 0x00128A0C
		public void method_0()
		{
			this.m_subPartsLUT.Clear();
			for (int i = 0; i < this.m_outfitsList.Length; i++)
			{
				int hashCode = this.m_outfitsList[i].GetHashCode();
				this.m_subPartsLUT.Add(hashCode, this.m_outfitsList[i]);
			}
		}

		// Token: 0x06003EA1 RID: 16033 RVA: 0x0012A85C File Offset: 0x00128A5C
		public SubPartOutfit method_1(int int_0)
		{
			SubPartOutfit subPartOutfit = null;
			this.m_subPartsLUT.TryGetValue(int_0, out subPartOutfit);
			return subPartOutfit;
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06003EA2 RID: 16034 RVA: 0x0002A368 File Offset: 0x00028568
		// (set) Token: 0x06003EA3 RID: 16035 RVA: 0x0002A370 File Offset: 0x00028570
		[XmlArrayItem("m_outfit", IsNullable = false)]
		public SubPartOutfit[] m_outfitsList { get; set; }

		// Token: 0x04002C11 RID: 11281
		private Dictionary<int, SubPartOutfit> m_subPartsLUT = new Dictionary<int, SubPartOutfit>();

		// Token: 0x04002C12 RID: 11282
		private SubPartOutfit[] m_outfitsListField;
	}
}
