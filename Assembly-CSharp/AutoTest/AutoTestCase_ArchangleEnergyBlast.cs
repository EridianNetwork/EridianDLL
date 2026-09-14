using System;

namespace AutoTest
{
	// Token: 0x02000620 RID: 1568
	internal class AutoTestCase_ArchangleEnergyBlast : AutoTestCase
	{
		// Token: 0x060027FE RID: 10238 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027FF RID: 10239 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x06002800 RID: 10240 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x06002801 RID: 10241 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
