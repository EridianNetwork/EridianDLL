using System;

namespace AutoTest
{
	// Token: 0x0200060C RID: 1548
	internal class AutoTestCase_NpcFallBackFireAttackPlayer : AutoTestCase
	{
		// Token: 0x0600279A RID: 10138 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x0600279B RID: 10139 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x0600279C RID: 10140 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x0600279D RID: 10141 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
