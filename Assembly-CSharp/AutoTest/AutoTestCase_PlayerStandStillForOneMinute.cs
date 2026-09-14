using System;

namespace AutoTest
{
	// Token: 0x02000623 RID: 1571
	internal class AutoTestCase_PlayerStandStillForOneMinute : AutoTestCase
	{
		// Token: 0x0600280D RID: 10253 RVA: 0x0001A859 File Offset: 0x00018A59
		protected override void UpdateAutoTestCase()
		{
			if (base.m_timeElapsed >= 60f)
			{
				base.Close(true, string.Empty);
			}
		}
	}
}
