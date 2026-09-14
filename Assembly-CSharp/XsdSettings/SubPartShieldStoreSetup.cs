using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008F5 RID: 2293
	public class SubPartShieldStoreSetup
	{
		// Token: 0x06003F55 RID: 16213 RVA: 0x0012BB88 File Offset: 0x00129D88
		public void method_0()
		{
			this.m_subPartsLUT.Clear();
			for (int i = 0; i < this.m_shieldSubparts.Length; i++)
			{
				int hashCode = this.m_shieldSubparts[i].GetHashCode();
				this.m_subPartsLUT.Add(hashCode, this.m_shieldSubparts[i]);
			}
		}

		// Token: 0x06003F56 RID: 16214 RVA: 0x0012BBD8 File Offset: 0x00129DD8
		public SubPartShield method_1(int int_0)
		{
			SubPartShield subPartShield = null;
			this.m_subPartsLUT.TryGetValue(int_0, out subPartShield);
			return subPartShield;
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06003F57 RID: 16215 RVA: 0x0002A9D9 File Offset: 0x00028BD9
		// (set) Token: 0x06003F58 RID: 16216 RVA: 0x0002A9E1 File Offset: 0x00028BE1
		[XmlArrayItem("m_shieldSubpart", IsNullable = false)]
		public SubPartShield[] m_shieldSubparts { get; set; }

		// Token: 0x04002C7E RID: 11390
		private Dictionary<int, SubPartShield> m_subPartsLUT = new Dictionary<int, SubPartShield>();

		// Token: 0x04002C7F RID: 11391
		private SubPartShield[] m_shieldSubpartsField;
	}
}
