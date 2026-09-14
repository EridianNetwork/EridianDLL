using System;
using ns0;
using UnityEngine;
using XsdSettings;

namespace AutoTest
{
	// Token: 0x02000626 RID: 1574
	internal class AutoTestCase_LoadLevel : AutoTestCase
	{
		// Token: 0x06002820 RID: 10272 RVA: 0x000BD4E8 File Offset: 0x000BB6E8
		protected override void OpenAutoTestCase()
		{
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(avatarType, -1));
		}

		// Token: 0x06002821 RID: 10273 RVA: 0x0001A8C1 File Offset: 0x00018AC1
		protected override void RequestResource()
		{
			this.m_IHaveGotResource = true;
		}
	}
}
