using System;

namespace AutoTest
{
	// Token: 0x0200062C RID: 1580
	internal class AutoTestCase_LoadAutoTestLevel1_WaitForFourPlayers : AutoTestCase_LoadAutoTestLevel1_WaitForPlayer
	{
		// Token: 0x06002830 RID: 10288 RVA: 0x0001A91F File Offset: 0x00018B1F
		protected override void UpdateAutoTestCase()
		{
			base.Wait(4);
		}
	}
}
