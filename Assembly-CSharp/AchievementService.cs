using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000348 RID: 840
public class AchievementService : OnAccessSingleton<IAchievementService, AchievementService, AchievementServiceOffline>, IAchievementService
{
	// Token: 0x06001557 RID: 5463 RVA: 0x00079A68 File Offset: 0x00077C68
	public AchievementService()
	{
		this.mOnGotAchievements = new List<GetAchievementsCallback>();
		this.mOnAchievementUpdated = new List<OnAchievementUpdated>();
		this.mOnUpdateAchievement = new List<UpdateAchievementCallback>();
		PhotonNetwork.onlinePeer.method_5(46, new OperationResponseCallback(this.OnGetAchievementsResponse));
		PhotonNetwork.onlinePeer.method_5(45, new OperationResponseCallback(this.OnUpdateAchievementResponse));
		PhotonNetwork.onlinePeer.method_7(154, new EventCallback(this.OnAchievementUpdatedEvent));
	}

	// Token: 0x06001558 RID: 5464 RVA: 0x0000F98D File Offset: 0x0000DB8D
	public void imethod_0(GetAchievementsCallback getAchievementsCallback_0, int int_0)
	{
		if (getAchievementsCallback_0 != null)
		{
			this.mOnGotAchievements.Add(getAchievementsCallback_0);
		}
		PhotonNetwork.onlinePeer.method_3(46, new object[] { int_0 });
	}

	// Token: 0x06001559 RID: 5465 RVA: 0x00079AEC File Offset: 0x00077CEC
	private void OnGetAchievementsResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			int characterId = Convert.ToInt32(parameters[0]);
			Hashtable[] array = (Hashtable[])parameters[1];
			if (array != null)
			{
				Achievements achievements = new Achievements(array);
				mOnGotAchievements.ForEach(delegate(GetAchievementsCallback getAchievementsCallback_0)
				{
					getAchievementsCallback_0(characterId, achievements);
				});
			}
		}
		else
		{
			mOnGotAchievements.ForEach(delegate(GetAchievementsCallback getAchievementsCallback_0)
			{
				getAchievementsCallback_0(0, null);
			});
		}
		mOnGotAchievements.Clear();
	}
	// Token: 0x0600155A RID: 5466 RVA: 0x0000F9BA File Offset: 0x0000DBBA
	public void imethod_1(OnAchievementUpdated onAchievementUpdated_0)
	{
		this.mOnAchievementUpdated.Add(onAchievementUpdated_0);
	}

	// Token: 0x0600155B RID: 5467 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
	public void imethod_2(OnAchievementUpdated onAchievementUpdated_0)
	{
		this.mOnAchievementUpdated.Remove(onAchievementUpdated_0);
	}

	// Token: 0x0600155C RID: 5468 RVA: 0x00079B8C File Offset: 0x00077D8C
	private void OnAchievementUpdatedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters[0] != null)
		{
			Achievement newAchievement = new Achievement((Hashtable)parameters[0]);
			mOnAchievementUpdated.ForEach(delegate(OnAchievementUpdated onAchievementUpdated_0)
			{
				onAchievementUpdated_0(newAchievement);
			});
		}
	}
	// Token: 0x0600155D RID: 5469 RVA: 0x0000F9D7 File Offset: 0x0000DBD7
	public void method_0(UpdateAchievementCallback updateAchievementCallback_0, int int_0, int int_1, int int_2)
	{
		if (updateAchievementCallback_0 != null)
		{
			this.mOnUpdateAchievement.Add(updateAchievementCallback_0);
		}
		PhotonNetwork.onlinePeer.method_3(45, new object[] { int_0, int_1, int_2 });
	}

	// Token: 0x0600155E RID: 5470 RVA: 0x00079BD8 File Offset: 0x00077DD8
	private void OnUpdateAchievementResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.mOnUpdateAchievement.ForEach(new Action<UpdateAchievementCallback>(AchievementService.smethod_1));
		}
		else
		{
			this.mOnUpdateAchievement.ForEach(new Action<UpdateAchievementCallback>(AchievementService.smethod_2));
		}
		this.mOnUpdateAchievement.Clear();
	}

	// Token: 0x0600155F RID: 5471 RVA: 0x0000FA17 File Offset: 0x0000DC17
	[CompilerGenerated]
	private static void smethod_0(GetAchievementsCallback getAchievementsCallback_0)
	{
		getAchievementsCallback_0(0, null);
	}

	// Token: 0x06001560 RID: 5472 RVA: 0x0000FA21 File Offset: 0x0000DC21
	[CompilerGenerated]
	private static void smethod_1(UpdateAchievementCallback updateAchievementCallback_0)
	{
		updateAchievementCallback_0(true);
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x0000FA2A File Offset: 0x0000DC2A
	[CompilerGenerated]
	private static void smethod_2(UpdateAchievementCallback updateAchievementCallback_0)
	{
		updateAchievementCallback_0(false);
	}

	// Token: 0x04000E8B RID: 3723
	private List<GetAchievementsCallback> mOnGotAchievements;

	// Token: 0x04000E8C RID: 3724
	private List<OnAchievementUpdated> mOnAchievementUpdated;

	// Token: 0x04000E8D RID: 3725
	private List<UpdateAchievementCallback> mOnUpdateAchievement;
}
