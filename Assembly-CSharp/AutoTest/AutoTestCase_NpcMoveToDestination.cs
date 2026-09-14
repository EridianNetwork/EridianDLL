using System;

namespace AutoTest
{
	// Token: 0x02000606 RID: 1542
	internal class AutoTestCase_NpcMoveToDestination : AutoTestCase
	{
		// Token: 0x0600277C RID: 10108 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x0600277D RID: 10109 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x0600277E RID: 10110 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x0600277F RID: 10111 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
