using System;

namespace AutoTest
{
	// Token: 0x02000607 RID: 1543
	internal class AutoTestCase_NpcBasicSpawn : AutoTestCase
	{
		// Token: 0x06002781 RID: 10113 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x06002782 RID: 10114 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x06002783 RID: 10115 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x06002784 RID: 10116 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
