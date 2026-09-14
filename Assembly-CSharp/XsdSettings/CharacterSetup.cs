using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000995 RID: 2453
	public class CharacterSetup
	{
		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06004459 RID: 17497 RVA: 0x0002D5D9 File Offset: 0x0002B7D9
		// (set) Token: 0x0600445A RID: 17498 RVA: 0x0002D5E1 File Offset: 0x0002B7E1
		public InventorySetup m_inventorySetup { get; set; }

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x0600445B RID: 17499 RVA: 0x0002D5EA File Offset: 0x0002B7EA
		// (set) Token: 0x0600445C RID: 17500 RVA: 0x0002D5F2 File Offset: 0x0002B7F2
		[XmlArrayItem("m_id", IsNullable = false)]
		public int[] m_quests { get; set; }

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x0600445D RID: 17501 RVA: 0x0002D5FB File Offset: 0x0002B7FB
		// (set) Token: 0x0600445E RID: 17502 RVA: 0x0002D603 File Offset: 0x0002B803
		[XmlArrayItem("m_id", IsNullable = false)]
		public int[] m_instances { get; set; }

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x0600445F RID: 17503 RVA: 0x0002D60C File Offset: 0x0002B80C
		// (set) Token: 0x06004460 RID: 17504 RVA: 0x0002D614 File Offset: 0x0002B814
		public AvatarType m_avatarType { get; set; }

		// Token: 0x04002FE4 RID: 12260
		private InventorySetup m_inventorySetupField;

		// Token: 0x04002FE5 RID: 12261
		private AvatarType m_avatarTypeField;
	}
}
