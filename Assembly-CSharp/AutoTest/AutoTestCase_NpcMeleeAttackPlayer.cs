using System;

namespace AutoTest
{
	// Token: 0x02000612 RID: 1554
	internal class AutoTestCase_NpcMeleeAttackPlayer : AutoTestCase
	{
		// Token: 0x060027B8 RID: 10168 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027B9 RID: 10169 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027BA RID: 10170 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027BB RID: 10171 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
