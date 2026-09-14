using System;

namespace AutoTest
{
	// Token: 0x02000609 RID: 1545
	internal class AutoTestCase_NpcCombatSpawn : AutoTestCase
	{
		// Token: 0x0600278B RID: 10123 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x0600278C RID: 10124 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x0600278E RID: 10126 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
