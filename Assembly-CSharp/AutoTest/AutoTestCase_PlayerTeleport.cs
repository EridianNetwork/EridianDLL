using System;

namespace AutoTest
{
	// Token: 0x02000610 RID: 1552
	internal class AutoTestCase_PlayerTeleport : AutoTestCase
	{
		// Token: 0x060027AE RID: 10158 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027AF RID: 10159 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027B0 RID: 10160 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027B1 RID: 10161 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
