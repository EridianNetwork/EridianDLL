using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using ns0;

using XsdSettings;
// Token: 0x020003D2 RID: 978
internal class QuestService : OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>, IQuestService
{
	// Token: 0x0600189A RID: 6298 RVA: 0x00082030 File Offset: 0x00080230
	public QuestService()
	{
		PhotonNetwork.onlinePeer.method_5(185, new OperationResponseCallback(this.OnGetPlayerQuests));
		PhotonNetwork.onlinePeer.method_5(181, new OperationResponseCallback(this.OnClaimQuestRewards));
		PhotonNetwork.onlinePeer.method_5(183, new OperationResponseCallback(this.OnGetPlayerQuests));
		PhotonNetwork.onlinePeer.method_5(184, new OperationResponseCallback(this.OnAcceptQuest));
		PhotonNetwork.onlinePeer.method_5(150, new OperationResponseCallback(this.OnTalkToNPC));
		PhotonNetwork.onlinePeer.method_5(145, new OperationResponseCallback(this.OnBringToNPC));
		PhotonNetwork.onlinePeer.method_5(215, new OperationResponseCallback(this.OnRejectQuest));
		PhotonNetwork.onlinePeer.method_5(141, new OperationResponseCallback(this.OnGetDailyQuestContents));
		PhotonNetwork.onlinePeer.method_7(220, new EventCallback(this.OnQuestStatusUpdated));
		PhotonNetwork.onlinePeer.method_7(217, new EventCallback(this.OnQuestTaskCompleted));
		PhotonNetwork.onlinePeer.method_7(170, new EventCallback(this.OnQuestClearDailyQuest));
		PhotonNetwork.onlinePeer.method_7(169, new EventCallback(this.OnQuestTaskUpdated));
		PhotonNetwork.networkingPeer.method_77(215, new EventCallback(this.OnQuestRewardClaimed));
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x00082204 File Offset: 0x00080404
	public Dictionary<int, QuestProgress> imethod_0(int int_0, GetPlayerQuestsCallback getPlayerQuestsCallback_0 = null)
	{
		if (getPlayerQuestsCallback_0 != null)
		{
			this.mGetPlayerQuestsCallback = getPlayerQuestsCallback_0;
		}
		PhotonNetwork.onlinePeer.method_3(185, new object[] { int_0 });
		if (this.mCachedPlayerQuests.ContainsKey(int_0))
		{
			return this.mCachedPlayerQuests[int_0];
		}
		return null;
	}

	// Token: 0x0600189C RID: 6300 RVA: 0x00082258 File Offset: 0x00080458
	public void OnGetPlayerQuests(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			int num = (int)parameters[0];
			Hashtable hashtable = (Hashtable)parameters[1];
			this.mCachedPlayerQuests[num] = new Dictionary<int, QuestProgress>();
			foreach (object obj in hashtable)
			{
				Hashtable hashtable2 = (Hashtable)((DictionaryEntry)obj).Value;
				if (hashtable2[1] != null)
				{
					int num2 = (int)hashtable2[0];
					int num3 = (int)hashtable2[1];
					int num4 = (int)hashtable2[2];
					int num5 = (int)hashtable2[3];
					this.mCachedPlayerQuests[num][num2] = new QuestProgress
					{
						mQuestId = num2,
						mStatus = (QuestState)num3,
						mCurrentTask = num4,
						mTaskProgress = num5
					};
				}
			}
			if (this.mGetPlayerQuestsCallback != null)
			{
				this.mGetPlayerQuestsCallback(num, this.mCachedPlayerQuests[num]);
				this.mGetPlayerQuestsCallback = null;
			}
		}
	}

	// Token: 0x0600189D RID: 6301 RVA: 0x00012638 File Offset: 0x00010838
	public void imethod_2(int int_0, int int_1)
	{
		PhotonNetwork.onlinePeer.method_3(184, new object[] { int_0, int_1 });
	}

	// Token: 0x0600189E RID: 6302 RVA: 0x000823B8 File Offset: 0x000805B8
	public void OnAcceptQuest(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			int num = (int)parameters[0];
			int num2 = (int)parameters[1];
			if ((bool)parameters[2])
			{
				if (this.mCachedPlayerQuests.ContainsKey(num) && this.mCachedPlayerQuests[num].ContainsKey(num2))
				{
				}
			}
			else
			{
				DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new object[] { "On accept quest fail, accountId : ", num, "  questId ", num2 }));
			}
			using (List<QuestAcceptedCallback>.Enumerator enumerator = this.mQuestAcceptedCallbacks.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					QuestAcceptedCallback questAcceptedCallback = enumerator.Current;
					questAcceptedCallback(num, num2);
				}
				return;
			}
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "On accept quest request fail, operationResponse : " + operationResponse);
	}

	// Token: 0x0600189F RID: 6303 RVA: 0x00012662 File Offset: 0x00010862
	public void imethod_4(int int_0, int int_1)
	{
		PhotonNetwork.onlinePeer.method_3(215, new object[] { int_0, int_1 });
	}

	// Token: 0x060018A0 RID: 6304 RVA: 0x000824A8 File Offset: 0x000806A8
	public void OnRejectQuest(short operationResponse, Dictionary<byte, object> parameters)
	{
		short num = (short)parameters[0];
		int num2 = (int)parameters[1];
		foreach (RejectQuestCallback rejectQuestCallback in this.mRejectQuestCallbacks)
		{
			rejectQuestCallback(num, num2);
		}
	}

	// Token: 0x060018A1 RID: 6305 RVA: 0x0001268C File Offset: 0x0001088C
	public void method_0(int int_0, int int_1, int int_2, int int_3)
	{
		PhotonNetwork.onlinePeer.method_3(183, new object[] { int_0, int_1, int_2, int_3 });
	}

	// Token: 0x060018A2 RID: 6306 RVA: 0x00082518 File Offset: 0x00080718
	private void OnQuestStatusUpdated(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int questId = (int)parameters[1];
		QuestState questStatus = (QuestState)(int)parameters[2];
		if (mCachedPlayerQuests.ContainsKey(accountId) && mCachedPlayerQuests[accountId].ContainsKey(questId))
		{
			mCachedPlayerQuests[accountId][questId].mStatus = questStatus;
		}
		mQuestStatusCallbacks.ForEach(delegate(QuestStatusCallback questStatusCallback_0)
		{
			questStatusCallback_0(accountId, questId, questStatus);
		});
	}
	// Token: 0x060018A3 RID: 6307 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnQuestRewardClaimed(Dictionary<byte, object> parameters)
	{
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000825D0 File Offset: 0x000807D0
	private void OnQuestTaskCompleted(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int questId = (int)parameters[1];
		if (mCachedPlayerQuests.ContainsKey(accountId) && mCachedPlayerQuests[accountId].ContainsKey(questId))
		{
			mCachedPlayerQuests[accountId][questId].mCurrentTask++;
			mCachedPlayerQuests[accountId][questId].mTaskProgress = 0;
		}
		mQuestStatusCallbacks.ForEach(delegate(QuestStatusCallback questStatusCallback_0)
		{
			questStatusCallback_0(accountId, questId, QuestState.InProgress);
		});
	}
	// Token: 0x060018A5 RID: 6309 RVA: 0x0008269C File Offset: 0x0008089C
	private void OnQuestTaskUpdated(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int questId = (int)parameters[1];
		int progress = (int)parameters[2];
		if (mCachedPlayerQuests.ContainsKey(accountId) && mCachedPlayerQuests[accountId].ContainsKey(questId))
		{
			mCachedPlayerQuests[accountId][questId].mTaskProgress = progress;
		}
		mQuestTaskUpdatedCallbacks.ForEach(delegate(QuestTaskUpdatedCallback questTaskUpdatedCallback_0)
		{
			questTaskUpdatedCallback_0(accountId, questId, progress);
		});
	}
	// Token: 0x060018A6 RID: 6310 RVA: 0x000126C9 File Offset: 0x000108C9
	public void imethod_21(int int_0, int int_1)
	{
		PhotonNetwork.onlinePeer.method_3(142, new object[] { int_0, int_1 });
	}

	// Token: 0x060018A7 RID: 6311 RVA: 0x000126F3 File Offset: 0x000108F3
	public void imethod_1(int int_0, int int_1, byte[] byte_0)
	{
		PhotonNetwork.onlinePeer.method_3(181, new object[] { int_0, int_1, byte_0 });
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x00012721 File Offset: 0x00010921
	public void imethod_7(QuestAcceptedCallback questAcceptedCallback_0)
	{
		this.mQuestAcceptedCallbacks.Add(questAcceptedCallback_0);
	}

	// Token: 0x060018A9 RID: 6313 RVA: 0x0001272F File Offset: 0x0001092F
	public void imethod_8(QuestAcceptedCallback questAcceptedCallback_0)
	{
		this.mQuestAcceptedCallbacks.Remove(questAcceptedCallback_0);
	}

	// Token: 0x060018AA RID: 6314 RVA: 0x0001273E File Offset: 0x0001093E
	public void imethod_13(QuestStatusCallback questStatusCallback_0)
	{
		this.mQuestStatusCallbacks.Add(questStatusCallback_0);
	}

	// Token: 0x060018AB RID: 6315 RVA: 0x0001274C File Offset: 0x0001094C
	public void imethod_14(QuestStatusCallback questStatusCallback_0)
	{
		this.mQuestStatusCallbacks.Remove(questStatusCallback_0);
	}

	// Token: 0x060018AC RID: 6316 RVA: 0x0001275B File Offset: 0x0001095B
	public void imethod_11(QuestRewardClaimedCallback questRewardClaimedCallback_0)
	{
		this.mQuestRewardsClaimedCallbacks.Add(questRewardClaimedCallback_0);
	}

	// Token: 0x060018AD RID: 6317 RVA: 0x00012769 File Offset: 0x00010969
	public void imethod_12(QuestRewardClaimedCallback questRewardClaimedCallback_0)
	{
		this.mQuestRewardsClaimedCallbacks.Remove(questRewardClaimedCallback_0);
	}

	// Token: 0x060018AE RID: 6318 RVA: 0x00082754 File Offset: 0x00080954
	private void OnClaimQuestRewards(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0 && (bool)parameters[0])
		{
			int characterId = (int)parameters[1];
			int questId = (int)parameters[2];
			Quest quest = ns0.ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(questId);
			if (parameters.ContainsKey(3))
			{
				OnGetPlayerQuests(operationResponse, new Dictionary<byte, object>
				{
					{ 0, characterId },
					{
						1,
						parameters[3]
					}
				});
			}
			if (mCachedPlayerQuests.ContainsKey(characterId) && mCachedPlayerQuests[characterId].ContainsKey(questId))
			{
				mCachedPlayerQuests[characterId][questId].mStatus = QuestState.RewardClaimed;
			}
			mQuestRewardsClaimedCallbacks.ForEach(delegate(QuestRewardClaimedCallback questRewardClaimedCallback_0)
			{
				questRewardClaimedCallback_0(characterId, questId, quest.mRewards);
			});
			PhotonNetwork.networkingPeer.vmethod_10(215, new Hashtable
			{
				{ 0, characterId },
				{ 1, questId }
			}, bool_0: true, 0);
		}
	}
	// Token: 0x060018AF RID: 6319 RVA: 0x00012778 File Offset: 0x00010978
	public void imethod_5(TalkToNPCCallback talkToNPCCallback_0, int int_0, int int_1)
	{
		this.mTalkToNPCCallback = talkToNPCCallback_0;
		PhotonNetwork.onlinePeer.method_3(150, new object[] { int_0, int_1 });
	}

	// Token: 0x060018B0 RID: 6320 RVA: 0x000828A0 File Offset: 0x00080AA0
	private void OnTalkToNPC(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mTalkToNPCCallback != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				Hashtable hashtable = (Hashtable)parameters[1];
				this.mCachedPlayerQuests[num] = new Dictionary<int, QuestProgress>();
				foreach (object obj in hashtable)
				{
					Hashtable hashtable2 = (Hashtable)((DictionaryEntry)obj).Value;
					if (hashtable2[1] != null)
					{
						int num2 = (int)hashtable2[0];
						int num3 = (int)hashtable2[1];
						int num4 = (int)hashtable2[2];
						int num5 = (int)hashtable2[3];
						this.mCachedPlayerQuests[num][num2] = new QuestProgress
						{
							mQuestId = num2,
							mStatus = (QuestState)num3,
							mCurrentTask = num4,
							mTaskProgress = num5
						};
					}
				}
				this.mTalkToNPCCallback(true, this.mCachedPlayerQuests[num]);
			}
			else
			{
				this.mTalkToNPCCallback(false, null);
			}
			this.mTalkToNPCCallback = null;
		}
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x000127A9 File Offset: 0x000109A9
	public void imethod_6(BringToNPCCallback bringToNPCCallback_0, int int_0, int int_1)
	{
		this.mBringToNPCCallback = bringToNPCCallback_0;
		PhotonNetwork.onlinePeer.method_3(145, new object[] { int_0, int_1 });
	}

	// Token: 0x060018B2 RID: 6322 RVA: 0x00082A14 File Offset: 0x00080C14
	private void OnBringToNPC(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mBringToNPCCallback != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				Hashtable hashtable = (Hashtable)parameters[1];
				this.mCachedPlayerQuests[num] = new Dictionary<int, QuestProgress>();
				foreach (object obj in hashtable)
				{
					Hashtable hashtable2 = (Hashtable)((DictionaryEntry)obj).Value;
					if (hashtable2[1] != null)
					{
						int num2 = (int)hashtable2[0];
						int num3 = (int)hashtable2[1];
						int num4 = (int)hashtable2[2];
						int num5 = (int)hashtable2[3];
						this.mCachedPlayerQuests[num][num2] = new QuestProgress
						{
							mQuestId = num2,
							mStatus = (QuestState)num3,
							mCurrentTask = num4,
							mTaskProgress = num5
						};
					}
				}
				this.mBringToNPCCallback(true, this.mCachedPlayerQuests[num]);
			}
			else
			{
				this.mBringToNPCCallback(false, null);
			}
			this.mBringToNPCCallback = null;
		}
	}

	// Token: 0x060018B3 RID: 6323 RVA: 0x000127DA File Offset: 0x000109DA
	private void OnQuestClearDailyQuest(Dictionary<byte, object> parameters)
	{
		this.mClearDailyQuestCallbacks.ForEach(new Action<ClearPlayerDailyQuestCallback>(QuestService.smethod_0));
	}

	// Token: 0x060018B4 RID: 6324 RVA: 0x00012804 File Offset: 0x00010A04
	public void imethod_3()
	{
		PhotonNetwork.onlinePeer.method_3(141, new object[0]);
	}

	// Token: 0x060018B5 RID: 6325 RVA: 0x00082B88 File Offset: 0x00080D88
	private void OnGetDailyQuestContents(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
		{
			return;
		}
		Hashtable hashtable = (Hashtable)parameters[0];
		Dictionary<int, DailyQuestInfo> dailyquestinfo = new Dictionary<int, DailyQuestInfo>();
		foreach (DictionaryEntry item in hashtable)
		{
			Hashtable hashtable2 = (Hashtable)item.Value;
			if (hashtable2[0] != null)
			{
				int key = (int)hashtable2[0];
				int mQuestId = (int)hashtable2[1];
				dailyquestinfo[key] = new DailyQuestInfo
				{
					mQuestId = mQuestId
				};
			}
		}
		mPlayerDailyQuestsContentCallbacks.ForEach(delegate(GetPlayerDailyQuestsContentCallback getPlayerDailyQuestsContentCallback_0)
		{
			getPlayerDailyQuestsContentCallback_0(dailyquestinfo);
		});
	}
	// Token: 0x060018B6 RID: 6326 RVA: 0x0001281C File Offset: 0x00010A1C
	public void imethod_19(ClearPlayerDailyQuestCallback clearPlayerDailyQuestCallback_0)
	{
		this.mClearDailyQuestCallbacks.Add(clearPlayerDailyQuestCallback_0);
	}

	// Token: 0x060018B7 RID: 6327 RVA: 0x0001282A File Offset: 0x00010A2A
	public void imethod_20(ClearPlayerDailyQuestCallback clearPlayerDailyQuestCallback_0)
	{
		this.mClearDailyQuestCallbacks.Remove(clearPlayerDailyQuestCallback_0);
	}

	// Token: 0x060018B8 RID: 6328 RVA: 0x00012839 File Offset: 0x00010A39
	public void imethod_17(GetPlayerDailyQuestsContentCallback getPlayerDailyQuestsContentCallback_0)
	{
		this.mPlayerDailyQuestsContentCallbacks.Add(getPlayerDailyQuestsContentCallback_0);
	}

	// Token: 0x060018B9 RID: 6329 RVA: 0x00012847 File Offset: 0x00010A47
	public void imethod_18(GetPlayerDailyQuestsContentCallback getPlayerDailyQuestsContentCallback_0)
	{
		this.mPlayerDailyQuestsContentCallbacks.Remove(getPlayerDailyQuestsContentCallback_0);
	}

	// Token: 0x060018BA RID: 6330 RVA: 0x00012856 File Offset: 0x00010A56
	public void imethod_15(QuestTaskUpdatedCallback questTaskUpdatedCallback_0)
	{
		this.mQuestTaskUpdatedCallbacks.Add(questTaskUpdatedCallback_0);
	}

	// Token: 0x060018BB RID: 6331 RVA: 0x00012864 File Offset: 0x00010A64
	public void imethod_16(QuestTaskUpdatedCallback questTaskUpdatedCallback_0)
	{
		this.mQuestTaskUpdatedCallbacks.Remove(questTaskUpdatedCallback_0);
	}

	// Token: 0x060018BC RID: 6332 RVA: 0x00012873 File Offset: 0x00010A73
	public void imethod_9(RejectQuestCallback rejectQuestCallback_0)
	{
		this.mRejectQuestCallbacks.Add(rejectQuestCallback_0);
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x00012881 File Offset: 0x00010A81
	public void imethod_10(RejectQuestCallback rejectQuestCallback_0)
	{
		this.mRejectQuestCallbacks.Remove(rejectQuestCallback_0);
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x00012890 File Offset: 0x00010A90
	[CompilerGenerated]
	private static void smethod_0(ClearPlayerDailyQuestCallback clearPlayerDailyQuestCallback_0)
	{
		clearPlayerDailyQuestCallback_0();
	}

	// Token: 0x040010C5 RID: 4293
	private Dictionary<int, Dictionary<int, QuestProgress>> mCachedPlayerQuests = new Dictionary<int, Dictionary<int, QuestProgress>>();

	// Token: 0x040010C6 RID: 4294
	private List<QuestAcceptedCallback> mQuestAcceptedCallbacks = new List<QuestAcceptedCallback>();

	// Token: 0x040010C7 RID: 4295
	private List<RejectQuestCallback> mRejectQuestCallbacks = new List<RejectQuestCallback>();

	// Token: 0x040010C8 RID: 4296
	private List<QuestStatusCallback> mQuestStatusCallbacks = new List<QuestStatusCallback>();

	// Token: 0x040010C9 RID: 4297
	private List<QuestTaskUpdatedCallback> mQuestTaskUpdatedCallbacks = new List<QuestTaskUpdatedCallback>();

	// Token: 0x040010CA RID: 4298
	private List<QuestRewardClaimedCallback> mQuestRewardsClaimedCallbacks = new List<QuestRewardClaimedCallback>();

	// Token: 0x040010CB RID: 4299
	private List<ClearPlayerDailyQuestCallback> mClearDailyQuestCallbacks = new List<ClearPlayerDailyQuestCallback>();

	// Token: 0x040010CC RID: 4300
	private List<GetPlayerDailyQuestsContentCallback> mPlayerDailyQuestsContentCallbacks = new List<GetPlayerDailyQuestsContentCallback>();

	// Token: 0x040010CD RID: 4301
	private GetPlayerQuestsCallback mGetPlayerQuestsCallback;

	// Token: 0x040010CE RID: 4302
	private TalkToNPCCallback mTalkToNPCCallback;

	// Token: 0x040010CF RID: 4303
	private BringToNPCCallback mBringToNPCCallback;

	// Token: 0x020003D3 RID: 979
	private class QuestRequirementInfo
	{
		// Token: 0x040010D1 RID: 4305
		public const int Type = 0;

		// Token: 0x040010D2 RID: 4306
		public const int Value = 1;

		// Token: 0x040010D3 RID: 4307
		public const int TargetId = 2;

		// Token: 0x040010D4 RID: 4308
		public const int AttackId = 3;

		// Token: 0x040010D5 RID: 4309
		public const int Progress = 4;

		// Token: 0x040010D6 RID: 4310
		public const int TaskId = 5;

		// Token: 0x040010D7 RID: 4311
		public const int Id = 6;

		// Token: 0x040010D8 RID: 4312
		public const int TimeLimit = 7;
	}

	// Token: 0x020003D4 RID: 980
	// (Invoke) Token: 0x060018C1 RID: 6337
	public delegate void QuestProgressCallback(int characterId, Dictionary<int, QuestProgress> progress);
}
