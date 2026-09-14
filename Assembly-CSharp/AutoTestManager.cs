using System;
using AutoTest;
using ns0;
using UnityEngine;

// Token: 0x02000639 RID: 1593
public class AutoTestManager : MonoSingleton<AutoTestManager>
{
	// Token: 0x06002876 RID: 10358 RVA: 0x000BE774 File Offset: 0x000BC974
	public void method_0(string string_0, string string_1, int int_0, int int_1, int int_2, int int_3)
	{
		AutoTestCase autoTestCase = this.m_tree.FindCase(string_0);
		if (autoTestCase.m_requestList[0] == null && !string.IsNullOrEmpty(string_1))
		{
			autoTestCase.m_requestList[0] = new AutoTestResourceRequest(new AutoTestContinentResource(GameObject.Find(string_1)));
		}
		if (autoTestCase.m_requestList[1] == null && int_0 >= 0)
		{
			autoTestCase.m_requestList[1] = new AutoTestResourceRequest(new AutoTestPlayerResource(MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(int_0).gameObject));
		}
		if (autoTestCase.m_requestList[2] == null && int_1 >= 0)
		{
			autoTestCase.m_requestList[2] = new AutoTestResourceRequest(new AutoTestPlayerResource(MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(int_1).gameObject));
		}
		if (autoTestCase.m_requestList[3] == null && int_2 >= 0)
		{
			autoTestCase.m_requestList[3] = new AutoTestResourceRequest(new AutoTestPlayerResource(MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(int_2).gameObject));
		}
		if (autoTestCase.m_requestList[4] == null && int_3 >= 0)
		{
			autoTestCase.m_requestList[4] = new AutoTestResourceRequest(new AutoTestPlayerResource(MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(int_3).gameObject));
		}
		autoTestCase.m_IHaveGotResource = true;
	}

	// Token: 0x06002877 RID: 10359 RVA: 0x000BE888 File Offset: 0x000BCA88
	public void RPC_CloseCase(string caseName, bool pass, string from)
	{
		AutoTestCase autoTestCase = this.m_tree.FindCase(caseName);
		if (from == "client")
		{
			autoTestCase.m_clientClosed++;
			autoTestCase.m_clientPass = autoTestCase.m_clientPass && pass;
		}
		else if (from == "host")
		{
			autoTestCase.m_hostClosed = true;
			autoTestCase.m_hostPass = pass;
		}
	}

	// Token: 0x06002878 RID: 10360 RVA: 0x000BE8EC File Offset: 0x000BCAEC
	public void method_1(string string_0)
	{
		string_0 = string_0.Split(new char[] { '|' })[0];
		string[] array = this.m_table.method_0(string_0);
		this.m_tree.Construct(array, this);
	}

	// Token: 0x06002879 RID: 10361 RVA: 0x0001AA0E File Offset: 0x00018C0E
	private void Update()
	{
		if (this.m_tree != null)
		{
			this.m_tree.Update();
		}
	}

	// Token: 0x04001CAC RID: 7340
	public AutoTestSync m_autoTestSync;

	// Token: 0x04001CAD RID: 7341
	private AutoTestCaseTree m_tree = new AutoTestCaseTree();

	// Token: 0x04001CAE RID: 7342
	private AutoTestTable m_table = new AutoTestTable();
}
