using System;

namespace AutoTest
{
	// Token: 0x02000615 RID: 1557
	internal class AutoTestCase_NpcIceMeteorAttack : AutoTestCase
	{
		// Token: 0x060027C7 RID: 10183 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027C8 RID: 10184 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027C9 RID: 10185 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027CA RID: 10186 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
