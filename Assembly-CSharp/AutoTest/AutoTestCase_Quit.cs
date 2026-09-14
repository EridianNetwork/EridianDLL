using System;
using Core;
using ns0;

namespace AutoTest
{
	// Token: 0x02000628 RID: 1576
	internal class AutoTestCase_Quit : AutoTestCase
	{
		// Token: 0x06002827 RID: 10279 RVA: 0x0001A8CA File Offset: 0x00018ACA
		protected override void UpdateAutoTestCase()
		{
			if (base.m_timeElapsed > 3f)
			{
				base.Close(true, string.Empty);
			}
		}

		// Token: 0x06002828 RID: 10280 RVA: 0x0001A8E5 File Offset: 0x00018AE5
		protected override void CloseAutoTestCase()
		{
			DebugUtils.Log(LogCategory.Framework, "AutoTest Finished");
			MonoSingleton<AppManager>.Instance.method_8();
		}
	}
}
