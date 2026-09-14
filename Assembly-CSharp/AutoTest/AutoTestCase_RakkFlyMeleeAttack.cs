using System;

namespace AutoTest
{
	// Token: 0x0200061C RID: 1564
	internal class AutoTestCase_RakkFlyMeleeAttack : AutoTestCase
	{
		// Token: 0x060027EA RID: 10218 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027EB RID: 10219 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027EC RID: 10220 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027ED RID: 10221 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
