using System;

namespace AutoTest
{
	// Token: 0x02000608 RID: 1544
	internal class AutoTestCase_NpcAdvanceSpawn : AutoTestCase
	{
		// Token: 0x06002786 RID: 10118 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x06002787 RID: 10119 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x06002788 RID: 10120 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x06002789 RID: 10121 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
