using System;

namespace AutoTest
{
	// Token: 0x0200062A RID: 1578
	internal class AutoTestCase_LoadAutoTestLevel1_WaitForTwoPlayers : AutoTestCase_LoadAutoTestLevel1_WaitForPlayer
	{
		// Token: 0x0600282C RID: 10284 RVA: 0x0001A90D File Offset: 0x00018B0D
		protected override void UpdateAutoTestCase()
		{
			base.Wait(2);
		}
	}
}
