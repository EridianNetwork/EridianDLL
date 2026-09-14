using System;

namespace AutoTest
{
	// Token: 0x0200061D RID: 1565
	internal class AutoTestCase_HurtZone : AutoTestCase
	{
		// Token: 0x060027EF RID: 10223 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027F0 RID: 10224 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027F1 RID: 10225 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027F2 RID: 10226 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
