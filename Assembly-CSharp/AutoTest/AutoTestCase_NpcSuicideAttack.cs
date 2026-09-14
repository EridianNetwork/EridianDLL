using System;

namespace AutoTest
{
	// Token: 0x02000618 RID: 1560
	internal class AutoTestCase_NpcSuicideAttack : AutoTestCase
	{
		// Token: 0x060027D6 RID: 10198 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027D7 RID: 10199 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027D8 RID: 10200 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027D9 RID: 10201 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
