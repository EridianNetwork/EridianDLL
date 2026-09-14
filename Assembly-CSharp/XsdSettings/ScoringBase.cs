using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A1C RID: 2588
	[XmlInclude(typeof(ScoringSetupPVE))]
	[XmlInclude(typeof(ScoringSetupPVP))]
	public class ScoringBase : ScoringType
	{
		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06004713 RID: 18195 RVA: 0x0002EC73 File Offset: 0x0002CE73
		// (set) Token: 0x06004714 RID: 18196 RVA: 0x0002EC7B File Offset: 0x0002CE7B
		public float m_moneyStandardReward { get; set; }

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06004715 RID: 18197 RVA: 0x0002EC84 File Offset: 0x0002CE84
		// (set) Token: 0x06004716 RID: 18198 RVA: 0x0002EC8C File Offset: 0x0002CE8C
		public float m_modeModifierEXP { get; set; }

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x06004717 RID: 18199 RVA: 0x0002EC95 File Offset: 0x0002CE95
		// (set) Token: 0x06004718 RID: 18200 RVA: 0x0002EC9D File Offset: 0x0002CE9D
		public float m_modeModifierSoftCurrency { get; set; }

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x06004719 RID: 18201 RVA: 0x0002ECA6 File Offset: 0x0002CEA6
		// (set) Token: 0x0600471A RID: 18202 RVA: 0x0002ECAE File Offset: 0x0002CEAE
		public float m_winBonusEXP { get; set; }

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x0600471B RID: 18203 RVA: 0x0002ECB7 File Offset: 0x0002CEB7
		// (set) Token: 0x0600471C RID: 18204 RVA: 0x0002ECBF File Offset: 0x0002CEBF
		public float m_winBonusSoftCurrency { get; set; }

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x0600471D RID: 18205 RVA: 0x0002ECC8 File Offset: 0x0002CEC8
		// (set) Token: 0x0600471E RID: 18206 RVA: 0x0002ECD0 File Offset: 0x0002CED0
		[XmlArrayItem("m_value", IsNullable = false)]
		public float[] m_moneyRewardRatePerLevel { get; set; }

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x0600471F RID: 18207 RVA: 0x0002ECD9 File Offset: 0x0002CED9
		// (set) Token: 0x06004720 RID: 18208 RVA: 0x0002ECE1 File Offset: 0x0002CEE1
		[XmlArrayItem("m_value", IsNullable = false)]
		public float[] m_expRewardRatePerLevel { get; set; }
	}
}
