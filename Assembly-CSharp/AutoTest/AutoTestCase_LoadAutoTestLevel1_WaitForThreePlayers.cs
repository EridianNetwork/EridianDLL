using System;

namespace AutoTest
{
	// Token: 0x0200062B RID: 1579
	internal class AutoTestCase_LoadAutoTestLevel1_WaitForThreePlayers : AutoTestCase_LoadAutoTestLevel1_WaitForPlayer
	{
		// Token: 0x0600282E RID: 10286 RVA: 0x0001A916 File Offset: 0x00018B16
		protected override void UpdateAutoTestCase()
		{
			base.Wait(3);
		}
	}
}
