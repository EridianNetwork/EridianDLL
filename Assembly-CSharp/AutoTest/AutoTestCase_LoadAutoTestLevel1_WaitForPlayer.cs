using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

namespace AutoTest
{
	// Token: 0x02000627 RID: 1575
	internal class AutoTestCase_LoadAutoTestLevel1_WaitForPlayer : AutoTestCase
	{
		// Token: 0x06002823 RID: 10275 RVA: 0x000BD4E8 File Offset: 0x000BB6E8
		protected override void OpenAutoTestCase()
		{
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(avatarType, -1));
		}

		// Token: 0x06002824 RID: 10276 RVA: 0x0001A8C1 File Offset: 0x00018AC1
		protected override void RequestResource()
		{
			this.m_IHaveGotResource = true;
		}

		// Token: 0x06002825 RID: 10277 RVA: 0x000BD510 File Offset: 0x000BB710
		protected void Wait(int playersToWait)
		{
			if (this.m_count++ % 10 == 0)
			{
				Session prop_ = MonoSingleton<Session>.Instance;
				if (prop_ != null)
				{
					List<PlayerInfoSync> list;
					prop_.method_38(out list);
					if (list.Count >= playersToWait)
					{
						GameObject gameObject = GameObject.Find("/AppManager/Entities");
						GameObject gameObject2 = GameObject.Find("FpsCamera(Clone)");
						if (gameObject2 != null && gameObject != null)
						{
							base.Close(true, string.Empty);
						}
					}
				}
				if (base.m_timeElapsed >= 180f)
				{
					base.Close(false, string.Empty);
				}
			}
		}

		// Token: 0x04001C84 RID: 7300
		private int m_count;
	}
}
