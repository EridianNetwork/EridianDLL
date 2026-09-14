using System;

namespace AutoTest
{
	// Token: 0x02000617 RID: 1559
	internal class AutoTestCase_BadassBanditThrowGrenade : AutoTestCase
	{
		// Token: 0x060027D1 RID: 10193 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027D2 RID: 10194 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027D3 RID: 10195 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027D4 RID: 10196 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
