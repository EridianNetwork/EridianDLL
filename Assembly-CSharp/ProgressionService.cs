using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003CB RID: 971
internal class ProgressionService : OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>, IProgressionService
{
	// Token: 0x06001886 RID: 6278 RVA: 0x00081EA8 File Offset: 0x000800A8
	public ProgressionService()
	{
		PhotonNetwork.onlinePeer.method_5(180, new OperationResponseCallback(this.OnGetUnlockedInstances));
		PhotonNetwork.onlinePeer.method_5(179, new OperationResponseCallback(this.OnCompleteInstance));
		PhotonNetwork.onlinePeer.method_7(205, new EventCallback(this.OnInstanceUnlockedEvent));
		PhotonNetwork.onlinePeer.method_7(219, new EventCallback(this.OnCompleteInstance));
	}

	// Token: 0x06001887 RID: 6279 RVA: 0x000124DC File Offset: 0x000106DC
	public void imethod_0(GetUnlockedInstancesCallback getUnlockedInstancesCallback_0 = null)
	{
		if (getUnlockedInstancesCallback_0 != null)
		{
			this.mUnlockedInstancesCallback.Add(getUnlockedInstancesCallback_0);
		}
		if (this.mUnlockedInstancesCallback.Count <= 1)
		{
			PhotonNetwork.onlinePeer.method_3(180, new object[0]);
		}
	}

	// Token: 0x06001888 RID: 6280 RVA: 0x00012511 File Offset: 0x00010711
	public Dictionary<int, int> imethod_1()
	{
		return this.mMyCachedUnlockedInstances;
	}

	// Token: 0x06001889 RID: 6281 RVA: 0x00081F4C File Offset: 0x0008014C
	public void OnGetUnlockedInstances(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.mMyCachedUnlockedInstances = (Dictionary<int, int>)parameters[0];
		}
		if (this.mUnlockedInstancesCallback != null)
		{
			this.mUnlockedInstancesCallback.ForEach(new Action<GetUnlockedInstancesCallback>(this.method_2));
			this.mUnlockedInstancesCallback.Clear();
		}
	}

	// Token: 0x0600188A RID: 6282 RVA: 0x00012519 File Offset: 0x00010719
	public void imethod_2(InstanceInfo instanceInfo_0)
	{
		this.mMyCachedUnlockedInstances = instanceInfo_0.UnlockedInstances;
		if (this.mUnlockedInstancesCallback != null)
		{
			this.mUnlockedInstancesCallback.ForEach(new Action<GetUnlockedInstancesCallback>(this.method_3));
			this.mUnlockedInstancesCallback.Clear();
		}
	}

	// Token: 0x0600188B RID: 6283 RVA: 0x00012551 File Offset: 0x00010751
	public void method_0(int int_0, int int_1)
	{
		PhotonNetwork.onlinePeer.method_3(178, new object[] { int_0, int_1 });
	}

	// Token: 0x0600188C RID: 6284 RVA: 0x0001257B File Offset: 0x0001077B
	public void method_1(int int_0, int int_1, int int_2)
	{
		PhotonNetwork.onlinePeer.method_3(179, new object[] { int_0, int_1, int_2 });
	}

	// Token: 0x0600188D RID: 6285 RVA: 0x000125AE File Offset: 0x000107AE
	public void OnCompleteInstance(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0 || parameters == null || parameters.Count <= 0)
		{
		}
	}

	// Token: 0x0600188E RID: 6286 RVA: 0x00081F98 File Offset: 0x00080198
	public void OnCompleteInstance(Dictionary<byte, object> parameters)
	{
		int num = (int)parameters[0];
		int num2 = (int)parameters[1];
		this.mMyCachedUnlockedInstances[num] = num2;
	}

	// Token: 0x0600188F RID: 6287 RVA: 0x000125BF File Offset: 0x000107BF
	public void imethod_3(InstanceUnlockedCallback instanceUnlockedCallback_0)
	{
		this.mInstanceUnlockedCallbacks.Add(instanceUnlockedCallback_0);
	}

	// Token: 0x06001890 RID: 6288 RVA: 0x000125CD File Offset: 0x000107CD
	public void imethod_4(InstanceUnlockedCallback instanceUnlockedCallback_0)
	{
		this.mInstanceUnlockedCallbacks.Remove(instanceUnlockedCallback_0);
	}

	// Token: 0x06001891 RID: 6289 RVA: 0x00081FCC File Offset: 0x000801CC
	public void OnInstanceUnlockedEvent(Dictionary<byte, object> parameters)
	{
		int instanceid = (int)parameters[0];
		if (!mMyCachedUnlockedInstances.ContainsKey(instanceid))
		{
			mMyCachedUnlockedInstances[instanceid] = 0;
		}
		mInstanceUnlockedCallbacks.ForEach(delegate(InstanceUnlockedCallback instanceUnlockedCallback_0)
		{
			instanceUnlockedCallback_0(instanceid);
		});
	}
	// Token: 0x06001892 RID: 6290 RVA: 0x000125DC File Offset: 0x000107DC
	[CompilerGenerated]
	private void method_2(GetUnlockedInstancesCallback getUnlockedInstancesCallback_0)
	{
		getUnlockedInstancesCallback_0(this.mMyCachedUnlockedInstances);
	}

	// Token: 0x06001893 RID: 6291 RVA: 0x000125DC File Offset: 0x000107DC
	[CompilerGenerated]
	private void method_3(GetUnlockedInstancesCallback getUnlockedInstancesCallback_0)
	{
		getUnlockedInstancesCallback_0(this.mMyCachedUnlockedInstances);
	}

	// Token: 0x040010AE RID: 4270
	private Dictionary<int, int> mMyCachedUnlockedInstances = new Dictionary<int, int>();

	// Token: 0x040010AF RID: 4271
	private List<InstanceUnlockedCallback> mInstanceUnlockedCallbacks = new List<InstanceUnlockedCallback>();

	// Token: 0x040010B0 RID: 4272
	private List<GetUnlockedInstancesCallback> mUnlockedInstancesCallback = new List<GetUnlockedInstancesCallback>();
}
