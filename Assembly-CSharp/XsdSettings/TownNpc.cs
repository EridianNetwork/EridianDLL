using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A71 RID: 2673
	public class TownNpc
	{
		// Token: 0x0600487C RID: 18556 RVA: 0x0002F6C9 File Offset: 0x0002D8C9
		public TownNpc()
		{
			this.m_WeaponShopID = -1;
			this.m_CoinShieldShopID = -1;
			this.m_ClassModeShopID = -1;
			this.m_OutfitShopID = -1;
		}

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x0600487D RID: 18557 RVA: 0x0002F6ED File Offset: 0x0002D8ED
		// (set) Token: 0x0600487E RID: 18558 RVA: 0x0002F6F5 File Offset: 0x0002D8F5
		public int m_id { get; set; }

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x0600487F RID: 18559 RVA: 0x0002F6FE File Offset: 0x0002D8FE
		// (set) Token: 0x06004880 RID: 18560 RVA: 0x0002F706 File Offset: 0x0002D906
		public string m_nameId { get; set; }

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06004881 RID: 18561 RVA: 0x0002F70F File Offset: 0x0002D90F
		// (set) Token: 0x06004882 RID: 18562 RVA: 0x0002F717 File Offset: 0x0002D917
		public string m_greetingsId { get; set; }

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06004883 RID: 18563 RVA: 0x0002F720 File Offset: 0x0002D920
		// (set) Token: 0x06004884 RID: 18564 RVA: 0x0002F728 File Offset: 0x0002D928
		[XmlArrayItem("m_occupation", IsNullable = false)]
		public NpcOccupation[] m_occupations { get; set; }

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06004885 RID: 18565 RVA: 0x0002F731 File Offset: 0x0002D931
		// (set) Token: 0x06004886 RID: 18566 RVA: 0x0002F739 File Offset: 0x0002D939
		[DefaultValue(-1)]
		public int m_WeaponShopID { get; set; }

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06004887 RID: 18567 RVA: 0x0002F742 File Offset: 0x0002D942
		// (set) Token: 0x06004888 RID: 18568 RVA: 0x0002F74A File Offset: 0x0002D94A
		[DefaultValue(-1)]
		public int m_CoinShieldShopID { get; set; }

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06004889 RID: 18569 RVA: 0x0002F753 File Offset: 0x0002D953
		// (set) Token: 0x0600488A RID: 18570 RVA: 0x0002F75B File Offset: 0x0002D95B
		[DefaultValue(-1)]
		public int m_ClassModeShopID { get; set; }

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x0600488B RID: 18571 RVA: 0x0002F764 File Offset: 0x0002D964
		// (set) Token: 0x0600488C RID: 18572 RVA: 0x0002F76C File Offset: 0x0002D96C
		[DefaultValue(-1)]
		public int m_OutfitShopID { get; set; }

		// Token: 0x0400352B RID: 13611
		private NpcOccupation[] m_occupationsField;
	}
}
