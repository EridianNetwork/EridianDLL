using System;

namespace AutoTest
{
	// Token: 0x02000613 RID: 1555
	internal class AutoTestCase_NpcChargeAttack : AutoTestCase
	{
		// Token: 0x060027BD RID: 10173 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027BE RID: 10174 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027BF RID: 10175 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027C0 RID: 10176 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
