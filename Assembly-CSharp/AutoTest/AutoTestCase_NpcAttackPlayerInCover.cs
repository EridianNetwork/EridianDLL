using System;

namespace AutoTest
{
	// Token: 0x0200060D RID: 1549
	internal class AutoTestCase_NpcAttackPlayerInCover : AutoTestCase
	{
		// Token: 0x0600279F RID: 10143 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027A0 RID: 10144 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027A1 RID: 10145 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027A2 RID: 10146 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
