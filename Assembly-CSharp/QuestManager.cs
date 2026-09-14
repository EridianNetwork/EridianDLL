using System;
using System.Collections.Generic;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x020004C8 RID: 1224
public class QuestManager : global::Photon.MonoBehaviour, IDamageListener
{
	// Token: 0x170001BC RID: 444
	// (get) Token: 0x0600210A RID: 8458 RVA: 0x00016E05 File Offset: 0x00015005
	public static QuestManager QuestManager_0
	{
		get
		{
			return QuestManager.s_instance;
		}
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x00016E0C File Offset: 0x0001500C
	private void Awake()
	{
		QuestManager.s_instance = this;
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x00016E14 File Offset: 0x00015014
	protected void Start()
	{
		this.method_2(OnlineService.s_characterId, ServiceWrapperBase<QuestServiceWrapper>.Instance.method_7(true));
	}

	// Token: 0x0600210D RID: 8461 RVA: 0x00016E2C File Offset: 0x0001502C
	private void OnDestroy()
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_23();
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x000A0078 File Offset: 0x0009E278
	protected void method_0(int int_0)
	{
		Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_19(MonoSingleton<AppManager>.Instance.m_playlistId);
		if (quest != null)
		{
			QuestProgress questProgress = new QuestProgress();
			questProgress.mQuestId = quest.mId;
			questProgress.mStatus = QuestState.InProgress;
			questProgress.mCurrentTask = 999;
			for (int i = 0; i < quest.mTasks.Length; i++)
			{
				questProgress.mCurrentTask = Mathf.Min(questProgress.mCurrentTask, quest.mTasks[i].mTaskId);
				questProgress.mTaskProgress = 0;
			}
			this.method_1(int_0, quest, questProgress);
		}
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x000A0104 File Offset: 0x0009E304
	private void method_1(int int_0, Quest quest_0, QuestProgress questProgress_0)
	{
		if (questProgress_0.mStatus != QuestState.InProgress)
		{
			return;
		}
		if (quest_0.mRequiredDifficulty != (int)MonoSingleton<Session>.Instance.method_2() && quest_0.mRequiredDifficulty != -1)
		{
			return;
		}
		QuestManager.QuestProgression questProgression = new QuestManager.QuestProgression();
		questProgression.m_characterId = int_0;
		questProgression.m_progress = questProgress_0;
		questProgression.method_0(questProgress_0.mStatus);
		this.m_questProgressionList.Add(questProgression);
		for (int i = 0; i < quest_0.mTasks.Length; i++)
		{
			QuestManager.TaskProgress taskProgress = new QuestManager.TaskProgress();
			taskProgress.m_questId = quest_0.mId;
			taskProgress.m_characterId = int_0;
			taskProgress.m_progression = questProgression;
			taskProgress.m_task = new QuestTask
			{
				mAttackId = quest_0.mTasks[i].mAttackId,
				mTarget = quest_0.mTasks[i].mTarget,
				mTargetId = quest_0.mTasks[i].mTargetId,
				mTaskId = quest_0.mTasks[i].mTaskId,
				mTimeLimit = quest_0.mTasks[i].mTimeLimit,
				mType = quest_0.mTasks[i].mType,
				mItemType = quest_0.mTasks[i].mItemType,
				mItemID = quest_0.mTasks[i].mItemID,
				mPVPModeList = quest_0.mTasks[i].mPVPModeList
			};
			if (quest_0.mTasks[i].mTaskId < questProgress_0.mCurrentTask)
			{
				taskProgress.Int32_0 = taskProgress.m_task.mTarget;
				taskProgress.m_isDone = true;
				taskProgress.m_isSuccess = true;
			}
			else if (quest_0.mTasks[i].mTaskId == questProgress_0.mCurrentTask)
			{
				taskProgress.Int32_0 = questProgress_0.mTaskProgress;
			}
			taskProgress.m_isDirty = true;
			this.m_taskList.Add(taskProgress);
		}
	}

	// Token: 0x06002110 RID: 8464 RVA: 0x000A02C0 File Offset: 0x0009E4C0
	public void method_2(int int_0, Dictionary<int, QuestProgress> dictionary_0)
	{
		if (dictionary_0 == null)
		{
			return;
		}
		foreach (QuestProgress questProgress in dictionary_0.Values)
		{
			int mQuestId = questProgress.mQuestId;
			Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(mQuestId);
			if (quest != null && (quest.mBoundInstanceList.Contains(MonoSingleton<AppManager>.Instance.m_playlistId) || !quest.mIsBoundInstance))
			{
				this.method_1(int_0, quest, questProgress);
			}
		}
	}

	// Token: 0x06002111 RID: 8465 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x06002112 RID: 8466 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnEntityKill(KillContext context)
	{
	}

	// Token: 0x06002113 RID: 8467 RVA: 0x000A0350 File Offset: 0x0009E550
	[RPC]
	private void RPC_H2C_UpdateTaskProgress(int questId, int taskId, int count, PhotonMessageInfo info)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer != null)
		{
			this.method_3(questId, taskId, count);
		}
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x000A037C File Offset: 0x0009E57C
	[RPC]
	private void RPC_H2C_UpdateQuestProgress(int questId, int state, PhotonMessageInfo info)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer != null)
		{
			this.method_4(questId, state);
		}
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x000A03A8 File Offset: 0x0009E5A8
	private void method_3(int int_0, int int_1, int int_2)
	{
		Dictionary<int, QuestProgress> dictionary = ns0.ServiceWrapperBase<QuestServiceWrapper>.Instance.method_7();
		bool flag = false;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < m_taskList.Count; i++)
		{
			if (m_taskList[i].m_questId == int_0 && m_taskList[i].m_task.mTaskId == int_1 && m_taskList[i].m_progression.m_progress.mCurrentTask == int_1)
			{
				num = m_taskList[i].m_progression.m_progress.mCurrentTask;
				m_taskList[i].Int32_0 = int_2;
				num2 = m_taskList[i].m_progression.m_progress.mCurrentTask;
				flag = num != num2;
				dictionary[int_0] = m_taskList[i].m_progression.m_progress;
				break;
			}
		}
		ns0.ServiceWrapperBase<QuestServiceWrapper>.Instance.OnTaskProgressUpgrade(int_0, int_1, int_2);
		if (flag)
		{
			ns0.ServiceWrapperBase<QuestServiceWrapper>.Instance.OnNewTask(OnlineService.s_characterId, int_0, num2);
		}
		if (dictionary.Count > 0)
		{
			ns0.ServiceWrapperBase<QuestServiceWrapper>.Instance.OnQuestProgress(OnlineService.s_characterId, dictionary);
		}
	}
	// Token: 0x06002116 RID: 8470 RVA: 0x000A04E0 File Offset: 0x0009E6E0
	private void method_4(int int_0, int int_1)
	{
		Dictionary<int, QuestProgress> dictionary = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_7(true);
		bool flag = false;
		for (int i = 0; i < this.m_questProgressionList.Count; i++)
		{
			if (this.m_questProgressionList[i].m_progress.mQuestId == int_0)
			{
				flag = true;
				this.m_questProgressionList[i].method_0((QuestState)int_1);
				if (dictionary.ContainsKey(this.m_questProgressionList[i].m_progress.mQuestId))
				{
					dictionary[this.m_questProgressionList[i].m_progress.mQuestId].mStatus = (QuestState)int_1;
				}
				else
				{
					dictionary.Add(this.m_questProgressionList[i].m_progress.mQuestId, this.m_questProgressionList[i].m_progress);
				}
			}
		}
		if (!flag)
		{
			Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(int_0);
			QuestProgress questProgress = new QuestProgress();
			questProgress.mQuestId = int_0;
			questProgress.mStatus = QuestState.InProgress;
			questProgress.mCurrentTask = 999;
			for (int j = 0; j < quest.mTasks.Length; j++)
			{
				questProgress.mCurrentTask = Mathf.Min(questProgress.mCurrentTask, quest.mTasks[j].mTaskId);
				questProgress.mTaskProgress = 0;
			}
			this.method_1(OnlineService.s_characterId, quest, questProgress);
			dictionary[int_0] = questProgress;
		}
		if (dictionary.Count > 0)
		{
			ServiceWrapperBase<QuestServiceWrapper>.Instance.OnQuestProgress(OnlineService.s_characterId, dictionary);
		}
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x00016E38 File Offset: 0x00015038
	private static EntityNpc.EntitySubType smethod_0(QuestEnemyType questEnemyType_0)
	{
		return (EntityNpc.EntitySubType)((int)Enum.Parse(typeof(EntityNpc.EntitySubType), "CHR_" + questEnemyType_0.ToString()));
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x00016E63 File Offset: 0x00015063
	private static EntityNpc.EntityNpcFamilly smethod_1(QuestEnemyType questEnemyType_0)
	{
		return (EntityNpc.EntityNpcFamilly)((int)Enum.Parse(typeof(EntityNpc.EntityNpcFamilly), questEnemyType_0.ToString().Substring(3)));
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x000A065C File Offset: 0x0009E85C
	private static QuestAttackType smethod_2(AttackInfo.ElementalType elementalType_0, AttackSubType attackSubType_0)
	{
		switch (elementalType_0)
		{
		case AttackInfo.ElementalType.Fire:
			return QuestAttackType.Fire;
		case AttackInfo.ElementalType.Shock:
			return QuestAttackType.Shock;
		case AttackInfo.ElementalType.Corrosive:
			return QuestAttackType.Corrosive;
		case AttackInfo.ElementalType.Explosive:
			return QuestAttackType.Explosive;
		default:
			switch (AttackInfo.smethod_0(attackSubType_0))
			{
			case AttackInfo.AttackType.Projectile:
				return QuestAttackType.Any;
			case AttackInfo.AttackType.Area:
				return QuestAttackType.Any;
			case AttackInfo.AttackType.Melee:
				return QuestAttackType.Melee;
			case AttackInfo.AttackType.DamageOverTime:
				switch (AttackInfo.smethod_1(attackSubType_0))
				{
				case AttackInfo.ElementalType.Fire:
					return QuestAttackType.Fire;
				case AttackInfo.ElementalType.Shock:
					return QuestAttackType.Shock;
				case AttackInfo.ElementalType.Corrosive:
					return QuestAttackType.Corrosive;
				case AttackInfo.ElementalType.Explosive:
					return QuestAttackType.Explosive;
				}
				break;
			}
			return QuestAttackType.Any;
		}
	}

	// Token: 0x04001592 RID: 5522
	private static QuestManager s_instance;

	// Token: 0x04001593 RID: 5523
	private List<QuestManager.TaskProgress> m_taskList = new List<QuestManager.TaskProgress>();

	// Token: 0x04001594 RID: 5524
	private List<QuestManager.QuestProgression> m_questProgressionList = new List<QuestManager.QuestProgression>();

	// Token: 0x020004C9 RID: 1225
	private class TaskProgress
	{
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600211B RID: 8475 RVA: 0x00016E8A File Offset: 0x0001508A
		// (set) Token: 0x0600211C RID: 8476 RVA: 0x000A06DC File Offset: 0x0009E8DC
		public int Int32_0
		{
			get
			{
				return this.m_count;
			}
			set
			{
				this.m_isDirty = value != this.m_count;
				this.m_bNeedSave = this.m_bNeedSave || this.m_isDirty;
				this.m_count = value;
				this.m_progression.m_progress.mTaskProgress = this.m_count;
				this.m_isDone = this.m_count >= this.m_task.mTarget;
				if (this.m_isDone)
				{
					this.m_progression.method_1(this.m_task);
				}
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600211D RID: 8477 RVA: 0x00016E92 File Offset: 0x00015092
		public bool Boolean_0
		{
			get
			{
				return this.m_bNeedSave;
			}
		}

		// Token: 0x04001595 RID: 5525
		public int m_characterId;

		// Token: 0x04001596 RID: 5526
		public int m_questId;

		// Token: 0x04001597 RID: 5527
		private int m_count;

		// Token: 0x04001598 RID: 5528
		public bool m_isDirty;

		// Token: 0x04001599 RID: 5529
		public bool m_isDone;

		// Token: 0x0400159A RID: 5530
		public bool m_isSuccess;

		// Token: 0x0400159B RID: 5531
		public QuestTask m_task;

		// Token: 0x0400159C RID: 5532
		public QuestManager.QuestProgression m_progression;

		// Token: 0x0400159D RID: 5533
		private bool m_bNeedSave;
	}

	// Token: 0x020004CA RID: 1226
	private class QuestProgression
	{
		// Token: 0x0600211F RID: 8479 RVA: 0x00016E9A File Offset: 0x0001509A
		public void method_0(QuestState questState_0)
		{
			this.m_progress.mStatus = questState_0;
			this.m_isDirty = true;
		}

		// Token: 0x06002120 RID: 8480 RVA: 0x000A0764 File Offset: 0x0009E964
		public void method_1(QuestTask questTask_0)
		{
			if (this.m_progress.mCurrentTask == questTask_0.mTaskId)
			{
				Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(this.m_progress.mQuestId);
				if (questTask_0.mTimeLimit != 0 && (double)questTask_0.mTimeLimit < MonoSingleton<Session>.Instance.method_8())
				{
					this.method_0(QuestState.Failed);
				}
				else if (questTask_0.mTaskId + 1 < quest.mTasks.Length)
				{
					this.m_progress.mCurrentTask = questTask_0.mTaskId + 1;
					this.m_progress.mTaskProgress = 0;
				}
				else
				{
					this.method_0(QuestState.Completed);
				}
			}
		}

		// Token: 0x0400159E RID: 5534
		public int m_characterId;

		// Token: 0x0400159F RID: 5535
		public QuestProgress m_progress;

		// Token: 0x040015A0 RID: 5536
		public bool m_isDirty;
	}
}
