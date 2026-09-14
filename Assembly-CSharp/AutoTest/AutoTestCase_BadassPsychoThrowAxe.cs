using System;

namespace AutoTest
{
	// Token: 0x02000616 RID: 1558
	internal class AutoTestCase_BadassPsychoThrowAxe : AutoTestCase
	{
		// Token: 0x060027CC RID: 10188 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x060027CD RID: 10189 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void SpawnAndTeleport()
		{
		}

		// Token: 0x060027CE RID: 10190 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void OpenAutoTestCase()
		{
		}

		// Token: 0x060027CF RID: 10191 RVA: 0x0001A84B File Offset: 0x00018A4B
		protected override void UpdateAutoTestCase()
		{
			base.Close(true, string.Empty);
		}
	}
}
