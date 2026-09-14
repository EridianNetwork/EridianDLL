using System;

namespace AutoTest
{
	// Token: 0x0200061F RID: 1567
	internal class AutoTestCase_TentacleMeleeAttack : AutoTestCase
	{
		// Token: 0x060027F9 RID: 10233 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027FA RID: 10234 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027FB RID: 10235 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027FC RID: 10236 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
