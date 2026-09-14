using System;
using Core;
using ns0;
using Photon;
using UnityEngine;

// Token: 0x0200063E RID: 1598
public class AutoTestSync : global::Photon.MonoBehaviour
{
	// Token: 0x06002884 RID: 10372 RVA: 0x0001AA74 File Offset: 0x00018C74
	private void Awake()
	{
		MonoSingleton<AutoTestManager>.Instance.m_autoTestSync = this;
		base.gameObject.transform.parent = MonoSingleton<Session>.Instance.gameObject.transform;
	}

	// Token: 0x06002885 RID: 10373 RVA: 0x000BE9C4 File Offset: 0x000BCBC4
	public void RPC_CloseCase(string caseName, bool pass)
	{
		if (MonoSingleton<Session>.Instance)
		{
			object[] array = new object[] { caseName, pass, "client" };
			if (base.photonView != null)
			{
				base.photonView.method_4("RPC_CloseCase", PhotonTargets.All, array);
			}
		}
	}

	// Token: 0x06002886 RID: 10374 RVA: 0x000BEA1C File Offset: 0x000BCC1C
	[RPC]
	private void RPC_CloseCase(string caseName, bool pass, string from, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Autotest, string.Concat(new object[] { "AutoTestSync.RPC_CloseCase#RPC#", caseName, "#", pass, "#", from }));
		MonoSingleton<AutoTestManager>.Instance.RPC_CloseCase(caseName, pass, from);
	}

	// Token: 0x06002887 RID: 10375 RVA: 0x0001AAA0 File Offset: 0x00018CA0
	[RPC]
	private void RPC_SyncResourceRequested(string testCaseName, string continentName, int playerId1, int playerId2, int playerId3, int playerId4, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Autotest, "AutoTestSync.RPC_SyncResourceRequested#RPC#" + testCaseName + "#" + continentName);
		MonoSingleton<AutoTestManager>.Instance.method_0(testCaseName, continentName, playerId1, playerId2, playerId3, playerId4);
	}
}
