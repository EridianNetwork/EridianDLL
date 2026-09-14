using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008F3 RID: 2291
	public class SubPartClassModeStoreSetup
	{
		// Token: 0x06003F48 RID: 16200 RVA: 0x0012BA64 File Offset: 0x00129C64
		public void method_0()
		{
			this.m_subPartsLUT.Clear();
			for (int i = 0; i < this.m_classModeSubparts.Length; i++)
			{
				int hashCode = this.m_classModeSubparts[i].GetHashCode();
				this.m_subPartsLUT.Add(hashCode, this.m_classModeSubparts[i]);
			}
		}

		// Token: 0x06003F49 RID: 16201 RVA: 0x0012BAB4 File Offset: 0x00129CB4
		public SubPartClassMode method_1(int int_0)
		{
			SubPartClassMode subPartClassMode = null;
			this.m_subPartsLUT.TryGetValue(int_0, out subPartClassMode);
			return subPartClassMode;
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06003F4A RID: 16202 RVA: 0x0002A95B File Offset: 0x00028B5B
		// (set) Token: 0x06003F4B RID: 16203 RVA: 0x0002A963 File Offset: 0x00028B63
		[XmlArrayItem("m_classModeSubpart", IsNullable = false)]
		public SubPartClassMode[] m_classModeSubparts { get; set; }

		// Token: 0x04002C77 RID: 11383
		private Dictionary<int, SubPartClassMode> m_subPartsLUT = new Dictionary<int, SubPartClassMode>();

		// Token: 0x04002C78 RID: 11384
		private SubPartClassMode[] m_classModeSubpartsField;
	}
}
