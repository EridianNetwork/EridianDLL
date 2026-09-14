using System;

namespace AutoTest
{
	// Token: 0x0200061A RID: 1562
	internal class AutoTestCase_NpcSpitAttack : AutoTestCase
	{
		// Token: 0x060027E0 RID: 10208 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027E1 RID: 10209 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027E2 RID: 10210 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027E3 RID: 10211 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
