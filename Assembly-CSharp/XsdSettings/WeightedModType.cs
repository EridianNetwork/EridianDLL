using System;

namespace XsdSettings
{
	// Token: 0x02000A41 RID: 2625
	public class WeightedModType
	{
		// Token: 0x060047B8 RID: 18360 RVA: 0x0002F17A File Offset: 0x0002D37A
		public WeightedModType()
		{
			this.m_modType = AvatarType.SIREN;
			this.m_weight = 1f;
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x060047B9 RID: 18361 RVA: 0x0002F194 File Offset: 0x0002D394
		// (set) Token: 0x060047BA RID: 18362 RVA: 0x0002F19C File Offset: 0x0002D39C
		public AvatarType m_modType { get; set; }

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x060047BB RID: 18363 RVA: 0x0002F1A5 File Offset: 0x0002D3A5
		// (set) Token: 0x060047BC RID: 18364 RVA: 0x0002F1AD File Offset: 0x0002D3AD
		public float m_weight { get; set; }
	}
}
