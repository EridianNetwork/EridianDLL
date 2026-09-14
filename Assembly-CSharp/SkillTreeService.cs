using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003E6 RID: 998
internal class SkillTreeService : OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>, ISkillTreeService
{
	// Token: 0x06001907 RID: 6407 RVA: 0x00083574 File Offset: 0x00081774
	public SkillTreeService()
	{
		PhotonNetwork.onlinePeer.method_5(173, new OperationResponseCallback(this.OnGetMySkillPoints));
		PhotonNetwork.onlinePeer.method_5(171, new OperationResponseCallback(this.OnGetInvestedSkillPoints));
		PhotonNetwork.onlinePeer.method_5(170, new OperationResponseCallback(this.OnInvestSkillPoint));
		PhotonNetwork.onlinePeer.method_5(169, new OperationResponseCallback(this.OnInvestMultipleSkillPoints));
		PhotonNetwork.onlinePeer.method_5(168, new OperationResponseCallback(this.OnResetSkillPoints));
		PhotonNetwork.onlinePeer.method_7(216, new EventCallback(this.OnSkillPointEarned));
	}

	// Token: 0x06001908 RID: 6408 RVA: 0x00012B68 File Offset: 0x00010D68
	public void imethod_0(GetSkillPointsCallback getSkillPointsCallback_0)
	{
		this.mGetSkillPointsCallback = getSkillPointsCallback_0;
		PhotonNetwork.onlinePeer.method_3(173, new object[0]);
	}

	// Token: 0x06001909 RID: 6409 RVA: 0x0008363C File Offset: 0x0008183C
	private void OnGetMySkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mGetSkillPointsCallback != null)
		{
			if (operationResponse == 0)
			{
				Hashtable[] array = (Hashtable[])parameters[3];
				List<InvestedSkill> list = new List<InvestedSkill>();
				foreach (Hashtable hashtable in array)
				{
					Hashtable hashtable2 = hashtable;
					if (hashtable2 != null)
					{
						list.Add(new InvestedSkill((int)hashtable2[0], (int)hashtable2[1]));
					}
				}
				this.mGetSkillPointsCallback((int)parameters[0], (int)parameters[1], (int)parameters[2], list);
			}
			else
			{
				this.mGetSkillPointsCallback(0, 0, 0, null);
			}
			this.mGetSkillPointsCallback = null;
		}
	}

	// Token: 0x0600190A RID: 6410 RVA: 0x00012B87 File Offset: 0x00010D87
	public void imethod_6(int int_0, GetInvestedSkillPointsCallback getInvestedSkillPointsCallback_0)
	{
		this.mGetInvestedSkillPointsCallback = getInvestedSkillPointsCallback_0;
		PhotonNetwork.onlinePeer.method_3(171, new object[] { int_0 });
	}

	// Token: 0x0600190B RID: 6411 RVA: 0x00083704 File Offset: 0x00081904
	private void OnGetInvestedSkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mGetInvestedSkillPointsCallback != null)
		{
			if (operationResponse == 0)
			{
				Hashtable[] array = (Hashtable[])parameters[1];
				List<InvestedSkill> list = new List<InvestedSkill>();
				foreach (Hashtable hashtable in array)
				{
					Hashtable hashtable2 = hashtable;
					if (hashtable2 != null)
					{
						list.Add(new InvestedSkill((int)hashtable2[0], (int)hashtable2[1]));
					}
				}
				this.mGetInvestedSkillPointsCallback((int)parameters[0], list);
			}
			else
			{
				this.mGetInvestedSkillPointsCallback(0, null);
			}
			this.mGetInvestedSkillPointsCallback = null;
		}
	}

	// Token: 0x0600190C RID: 6412 RVA: 0x00012BAF File Offset: 0x00010DAF
	public void imethod_1(int int_0, InvestSkillPointCallback investSkillPointCallback_0)
	{
		this.mInvestSkillPointCallback = investSkillPointCallback_0;
		PhotonNetwork.onlinePeer.method_3(170, new object[] { int_0 });
	}

	// Token: 0x0600190D RID: 6413 RVA: 0x000837B0 File Offset: 0x000819B0
	private void OnInvestSkillPoint(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mInvestSkillPointCallback != null)
		{
			if (operationResponse == 0)
			{
				this.mInvestSkillPointCallback((int)parameters[0], (int)parameters[1], true);
			}
			else
			{
				this.mInvestSkillPointCallback(0, 0, false);
			}
			this.mInvestSkillPointCallback = null;
		}
	}

	// Token: 0x0600190E RID: 6414 RVA: 0x00083804 File Offset: 0x00081A04
	public void imethod_2(List<InvestedSkill> list_0, InvestMultipleSkillPointsCallback investMultipleSkillPointsCallback_0)
	{
		this.mInvestMultipleSkillPointsCallback = investMultipleSkillPointsCallback_0;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		foreach (InvestedSkill investedSkill in list_0)
		{
			dictionary[num++] = new Hashtable
			{
				{ 0, investedSkill.Int32_0 },
				{ 1, investedSkill.Int32_1 }
			};
		}
		PhotonNetwork.onlinePeer.method_3(169, new object[] { dictionary });
	}

	// Token: 0x0600190F RID: 6415 RVA: 0x000838B8 File Offset: 0x00081AB8
	private void OnInvestMultipleSkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mInvestMultipleSkillPointsCallback != null)
		{
			if (operationResponse == 0)
			{
				Dictionary<int, Hashtable> dictionary = (Dictionary<int, Hashtable>)parameters[1];
				List<InvestedSkill> list = new List<InvestedSkill>();
				foreach (KeyValuePair<int, Hashtable> keyValuePair in dictionary)
				{
					list.Add(new InvestedSkill((int)keyValuePair.Value[0], (int)keyValuePair.Value[1]));
				}
				this.mInvestMultipleSkillPointsCallback((int)parameters[0], list, true);
			}
			else
			{
				this.mInvestMultipleSkillPointsCallback(0, null, false);
			}
			this.mInvestMultipleSkillPointsCallback = null;
		}
	}

	// Token: 0x06001910 RID: 6416 RVA: 0x00012BD7 File Offset: 0x00010DD7
	public void imethod_3(ResetSkillPointsCallback resetSkillPointsCallback_0)
	{
		this.mResetSkillPointsCallback = resetSkillPointsCallback_0;
		PhotonNetwork.onlinePeer.method_3(168, new object[0]);
	}

	// Token: 0x06001911 RID: 6417 RVA: 0x00012BF6 File Offset: 0x00010DF6
	private void OnResetSkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mResetSkillPointsCallback != null)
		{
			if (operationResponse == 0)
			{
				this.mResetSkillPointsCallback((int)parameters[0], true);
			}
			else
			{
				this.mResetSkillPointsCallback(0, false);
			}
			this.mResetSkillPointsCallback = null;
		}
	}

	// Token: 0x06001912 RID: 6418 RVA: 0x00012C31 File Offset: 0x00010E31
	public void imethod_4(SkillPointEarnedCallback skillPointEarnedCallback_0)
	{
		this.mSkillPointEarnedCallbacks.Add(skillPointEarnedCallback_0);
	}

	// Token: 0x06001913 RID: 6419 RVA: 0x00012C3F File Offset: 0x00010E3F
	public void imethod_5(SkillPointEarnedCallback skillPointEarnedCallback_0)
	{
		this.mSkillPointEarnedCallbacks.Remove(skillPointEarnedCallback_0);
	}

	// Token: 0x06001914 RID: 6420 RVA: 0x0008398C File Offset: 0x00081B8C
	public void OnSkillPointEarned(Dictionary<byte, object> parameters)
	{
		mSkillPointEarnedCallbacks.ForEach(delegate(SkillPointEarnedCallback skillPointEarnedCallback_0)
		{
			skillPointEarnedCallback_0((int)parameters[0], (int)parameters[1]);
		});
	}
	// Token: 0x0400110E RID: 4366
	private List<SkillPointEarnedCallback> mSkillPointEarnedCallbacks = new List<SkillPointEarnedCallback>();

	// Token: 0x0400110F RID: 4367
	private GetSkillPointsCallback mGetSkillPointsCallback;

	// Token: 0x04001110 RID: 4368
	private GetInvestedSkillPointsCallback mGetInvestedSkillPointsCallback;

	// Token: 0x04001111 RID: 4369
	private InvestSkillPointCallback mInvestSkillPointCallback;

	// Token: 0x04001112 RID: 4370
	private InvestMultipleSkillPointsCallback mInvestMultipleSkillPointsCallback;

	// Token: 0x04001113 RID: 4371
	private ResetSkillPointsCallback mResetSkillPointsCallback;
}
