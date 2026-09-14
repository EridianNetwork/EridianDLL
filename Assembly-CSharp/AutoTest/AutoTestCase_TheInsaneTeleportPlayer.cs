using System;

namespace AutoTest
{
	// Token: 0x02000622 RID: 1570
	internal class AutoTestCase_TheInsaneTeleportPlayer : AutoTestCase
	{
		// Token: 0x06002808 RID: 10248 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x06002809 RID: 10249 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x0600280A RID: 10250 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x0600280B RID: 10251 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
