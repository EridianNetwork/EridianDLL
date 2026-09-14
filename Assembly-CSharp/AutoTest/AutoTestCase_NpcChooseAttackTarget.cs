using System;

namespace AutoTest
{
	// Token: 0x02000614 RID: 1556
	internal class AutoTestCase_NpcChooseAttackTarget : AutoTestCase
	{
		// Token: 0x060027C2 RID: 10178 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027C3 RID: 10179 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027C4 RID: 10180 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027C5 RID: 10181 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
