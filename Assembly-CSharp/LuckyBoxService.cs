using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XsdSettings;

// Token: 0x020003AD RID: 941
internal class LuckyBoxService : OnAccessSingleton<ILuckyBoxService, LuckyBoxService, LuckyBoxServiceOffline>, ILuckyBoxService
{
	// Token: 0x060017DD RID: 6109 RVA: 0x00080094 File Offset: 0x0007E294
	public LuckyBoxService()
	{
		this.mLuckyBoxAwardedCallbacks = new List<OnLuckyBoxAwarded>();
		this.mLuckyBoxOpenedCallbacks = new List<OnLuckyBoxOpened>();
		PhotonNetwork.onlinePeer.method_5(71, new OperationResponseCallback(this.OnOpenLuckyBox));
		PhotonNetwork.onlinePeer.method_5(70, new OperationResponseCallback(this.OnAwardLuckyBox));
	}

	// Token: 0x060017DE RID: 6110 RVA: 0x00011BDC File Offset: 0x0000FDDC
	public void imethod_0(OnLuckyBoxOpened onLuckyBoxOpened_0, int int_0, bool bool_0)
	{
		if (onLuckyBoxOpened_0 != null)
		{
			this.mLuckyBoxOpenedCallbacks.Add(onLuckyBoxOpened_0);
		}
		PhotonNetwork.onlinePeer.method_3(71, new object[] { int_0, bool_0 });
	}

	// Token: 0x060017DF RID: 6111 RVA: 0x000800F0 File Offset: 0x0007E2F0
	private void OnOpenLuckyBox(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			bool locked = (bool)parameters[0];
			int index = (int)parameters[1];
			ItemDNA rewardedItem = ItemDNA.smethod_12((Hashtable)parameters[2]);
			ItemDNA dummyItem1 = ItemDNA.smethod_12((Hashtable)parameters[3]);
			ItemDNA dummyItem2 = ItemDNA.smethod_12((Hashtable)parameters[4]);
			mLuckyBoxOpenedCallbacks.ForEach(delegate(OnLuckyBoxOpened onLuckyBoxOpened_0)
			{
				onLuckyBoxOpened_0(locked, index, rewardedItem, dummyItem1, dummyItem2);
			});
		}
		else
		{
			mLuckyBoxOpenedCallbacks.ForEach(delegate(OnLuckyBoxOpened onLuckyBoxOpened_0)
			{
				onLuckyBoxOpened_0(locked: false, 0, null, null, null);
			});
		}
		mLuckyBoxOpenedCallbacks.Clear();
	}
	// Token: 0x060017E0 RID: 6112 RVA: 0x000801C0 File Offset: 0x0007E3C0
	public void method_0(OnLuckyBoxAwarded onLuckyBoxAwarded_0, int int_0, int int_1, ELevelDifficulty elevelDifficulty_0, InstanceGrade instanceGrade_0, int int_2)
	{
		if (onLuckyBoxAwarded_0 != null)
		{
			this.mLuckyBoxAwardedCallbacks.Add(onLuckyBoxAwarded_0);
		}
		PhotonNetwork.onlinePeer.method_3(70, new object[]
		{
			int_0,
			int_1,
			(int)elevelDifficulty_0,
			(int)instanceGrade_0,
			int_2
		});
	}

	// Token: 0x060017E1 RID: 6113 RVA: 0x00080220 File Offset: 0x0007E420
	private void OnAwardLuckyBox(short operationResponse, Dictionary<byte, object> parameters)
	{
		mLuckyBoxAwardedCallbacks.ForEach(delegate(OnLuckyBoxAwarded onLuckyBoxAwarded_0)
		{
			onLuckyBoxAwarded_0(operationResponse == 0);
		});
		mLuckyBoxAwardedCallbacks.Clear();
	}
	// Token: 0x060017E2 RID: 6114 RVA: 0x00011C12 File Offset: 0x0000FE12
	[CompilerGenerated]
	private static void smethod_0(OnLuckyBoxOpened onLuckyBoxOpened_0)
	{
		onLuckyBoxOpened_0(false, 0, null, null, null);
	}

	// Token: 0x04001024 RID: 4132
	private List<OnLuckyBoxOpened> mLuckyBoxOpenedCallbacks;

	// Token: 0x04001025 RID: 4133
	private List<OnLuckyBoxAwarded> mLuckyBoxAwardedCallbacks;
}
