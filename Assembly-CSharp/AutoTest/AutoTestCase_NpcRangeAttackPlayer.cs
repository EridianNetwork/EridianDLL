using System;

namespace AutoTest
{
	// Token: 0x0200060A RID: 1546
	internal class AutoTestCase_NpcRangeAttackPlayer : AutoTestCase
	{
		// Token: 0x06002790 RID: 10128 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x06002791 RID: 10129 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x06002792 RID: 10130 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x06002793 RID: 10131 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
