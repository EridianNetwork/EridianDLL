using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008F8 RID: 2296
	public class SubPartStoreSetup
	{
		// Token: 0x06003F64 RID: 16228 RVA: 0x0012BD44 File Offset: 0x00129F44
		public void method_0()
		{
			this.m_subPartsLUT.Clear();
			for (int i = 0; i < this.m_subParts.Length; i++)
			{
				int hashCode = this.m_subParts[i].GetHashCode();
				this.m_subPartsLUT.Add(hashCode, this.m_subParts[i]);
			}
		}

		// Token: 0x06003F65 RID: 16229 RVA: 0x0012BD94 File Offset: 0x00129F94
		public SubPartWpn method_1(int int_0)
		{
			SubPartWpn subPartWpn = null;
			this.m_subPartsLUT.TryGetValue(int_0, out subPartWpn);
			return subPartWpn;
		}

		// Token: 0x06003F66 RID: 16230 RVA: 0x0012BDB4 File Offset: 0x00129FB4
		public List<SubPartWpn> method_2(WeaponSubPart weaponSubPart_0)
		{
			List<SubPartWpn> list = new List<SubPartWpn>();
			foreach (KeyValuePair<int, SubPartWpn> keyValuePair in this.m_subPartsLUT)
			{
				if (keyValuePair.Value.m_Index >= 0)
				{
					if (keyValuePair.Value.m_partType == weaponSubPart_0)
					{
						list.Add(keyValuePair.Value);
					}
				}
			}
			return list;
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06003F67 RID: 16231 RVA: 0x0002AA56 File Offset: 0x00028C56
		// (set) Token: 0x06003F68 RID: 16232 RVA: 0x0002AA5E File Offset: 0x00028C5E
		[XmlArrayItem("m_subPart", IsNullable = false)]
		public SubPartWpn[] m_subParts { get; set; }

		// Token: 0x04002C85 RID: 11397
		private Dictionary<int, SubPartWpn> m_subPartsLUT = new Dictionary<int, SubPartWpn>();

		// Token: 0x04002C86 RID: 11398
		private SubPartWpn[] m_subPartsField;
	}
}
