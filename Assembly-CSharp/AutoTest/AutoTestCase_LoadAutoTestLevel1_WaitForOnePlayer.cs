using System;

namespace AutoTest
{
	// Token: 0x02000629 RID: 1577
	internal class AutoTestCase_LoadAutoTestLevel1_WaitForOnePlayer : AutoTestCase_LoadAutoTestLevel1_WaitForPlayer
	{
		// Token: 0x0600282A RID: 10282 RVA: 0x0001A904 File Offset: 0x00018B04
		protected override void UpdateAutoTestCase()
		{
			base.Wait(1);
		}
	}
}
