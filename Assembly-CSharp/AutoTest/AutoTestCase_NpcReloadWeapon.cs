using System;

namespace AutoTest
{
	// Token: 0x02000619 RID: 1561
	internal class AutoTestCase_NpcReloadWeapon : AutoTestCase
	{
		// Token: 0x060027DB RID: 10203 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027DC RID: 10204 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027DD RID: 10205 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027DE RID: 10206 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
