using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A3D RID: 2621
	public class ShopSetup
	{
		// Token: 0x0600479E RID: 18334 RVA: 0x0002F069 File Offset: 0x0002D269
		public ShopSetup()
		{
			this.m_soldRatio = 0.5f;
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x0600479F RID: 18335 RVA: 0x0002F07C File Offset: 0x0002D27C
		// (set) Token: 0x060047A0 RID: 18336 RVA: 0x0002F084 File Offset: 0x0002D284
		public float m_soldRatio { get; set; }

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x060047A1 RID: 18337 RVA: 0x0002F08D File Offset: 0x0002D28D
		// (set) Token: 0x060047A2 RID: 18338 RVA: 0x0002F095 File Offset: 0x0002D295
		[XmlArrayItem("m_shop", IsNullable = false)]
		public Shop[] m_shops { get; set; }

		// Token: 0x04003383 RID: 13187
		private Shop[] m_shopsField;
	}
}
