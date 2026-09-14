using System;

namespace AutoTest
{
	// Token: 0x02000611 RID: 1553
	internal class AutoTestCase_NpcChooseCover : AutoTestCase
	{
		// Token: 0x060027B3 RID: 10163 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027B4 RID: 10164 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027B5 RID: 10165 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027B6 RID: 10166 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
