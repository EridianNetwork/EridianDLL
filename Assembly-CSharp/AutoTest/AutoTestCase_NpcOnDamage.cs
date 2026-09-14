using System;

namespace AutoTest
{
	// Token: 0x0200060F RID: 1551
	internal class AutoTestCase_NpcOnDamage : AutoTestCase
	{
		// Token: 0x060027A9 RID: 10153 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027AA RID: 10154 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027AB RID: 10155 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027AC RID: 10156 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
