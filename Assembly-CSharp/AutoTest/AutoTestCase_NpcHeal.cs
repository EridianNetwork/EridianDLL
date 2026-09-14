using System;

namespace AutoTest
{
	// Token: 0x0200061B RID: 1563
	internal class AutoTestCase_NpcHeal : AutoTestCase
	{
		// Token: 0x060027E5 RID: 10213 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027E6 RID: 10214 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027E7 RID: 10215 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027E8 RID: 10216 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
