using System;

namespace AutoTest
{
	// Token: 0x0200060B RID: 1547
	internal class AutoTestCase_NpcSniperAttackPlayer : AutoTestCase
	{
		// Token: 0x06002795 RID: 10133 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x06002796 RID: 10134 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x06002797 RID: 10135 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x06002798 RID: 10136 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
