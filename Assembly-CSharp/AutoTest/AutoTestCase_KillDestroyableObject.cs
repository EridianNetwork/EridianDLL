using System;

namespace AutoTest
{
	// Token: 0x0200061E RID: 1566
	internal class AutoTestCase_KillDestroyableObject : AutoTestCase
	{
		// Token: 0x060027F4 RID: 10228 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027F5 RID: 10229 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027F6 RID: 10230 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027F7 RID: 10231 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
