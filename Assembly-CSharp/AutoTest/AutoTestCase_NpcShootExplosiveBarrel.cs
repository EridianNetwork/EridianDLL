using System;

namespace AutoTest
{
	// Token: 0x0200060E RID: 1550
	internal class AutoTestCase_NpcShootExplosiveBarrel : AutoTestCase
	{
		// Token: 0x060027A4 RID: 10148 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027A5 RID: 10149 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027A6 RID: 10150 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027A7 RID: 10151 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
