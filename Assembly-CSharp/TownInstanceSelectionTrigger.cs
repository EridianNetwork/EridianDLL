using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000533 RID: 1331
public class TownInstanceSelectionTrigger : MonoBehaviour, IQuestServiceNotificationListerner, InteractionClient, IQuestUINotificationListerner
{
	// Token: 0x06002238 RID: 8760 RVA: 0x00017919 File Offset: 0x00015B19
	private void Awake()
	{
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_0(this);
		}
		this.m_collisionManager = base.gameObject.AddComponent<CollisionManager>();
	}

	// Token: 0x06002239 RID: 8761 RVA: 0x00017943 File Offset: 0x00015B43
	private void Start()
	{
		this.m_collisionManager.method_7(base.GetComponent<Collider>());
		this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
		this.m_rvControl = base.GetComponent<RVControl>();
	}

	// Token: 0x0600223A RID: 8762 RVA: 0x000A2F2C File Offset: 0x000A112C
	private void OnLevelWasLoaded(int iLevel)
	{
		if (!(MonoSingleton<Session>.Instance == null) && MonoSingleton<Session>.Instance.method_16())
		{
			if (this.m_selectionView == TownInstanceSelectionTrigger.SelectionView.Instance)
			{
				this.m_iInstanceIDList = InstanceMapSelectControl.smethod_7(MatchmakingService.MatchmakingService_0.method_0().m_id);
				this.m_childEyeIcon = base.transform.Find("PRO_Quest_eye_catch_icon");
				QuestUIDataManager.smethod_0().method_0(this);
				this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
			}
			return;
		}
	}

	// Token: 0x0600223B RID: 8763 RVA: 0x00017973 File Offset: 0x00015B73
	private void OnDestroy()
	{
		QuestUIDataManager.smethod_0().method_1(this);
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_1(this);
		}
	}

	// Token: 0x0600223C RID: 8764 RVA: 0x000A2FA8 File Offset: 0x000A11A8
	public bool imethod_2(Ray ray_0, ref float float_0)
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return false;
		}
		CollisionManager collisionManager = this.m_collisionManager;
		RaycastHit raycastHit;
		return collisionManager != null && collisionManager.method_2(ray_0, out raycastHit, ref float_0);
	}

	// Token: 0x0600223D RID: 8765 RVA: 0x000A2FE8 File Offset: 0x000A11E8
	public bool imethod_3(Entity entity_0)
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return false;
		}
		if (WorldMapSelectionController.smethod_0())
		{
			return false;
		}
		switch (this.m_selectionView)
		{
		case TownInstanceSelectionTrigger.SelectionView.Instance:
			return MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceView>() != null && !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceView>().Boolean_1;
		case TownInstanceSelectionTrigger.SelectionView.Town:
			return true;
		case TownInstanceSelectionTrigger.SelectionView.RV:
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer != null)
			{
				bool flag = LevelingManager.RV_UNLOCK_LEVEL <= MonoSingleton<LevelingManager>.Instance.method_3(localPlayer.m_avatarDna.method_5(), localPlayer.m_exp);
				if (this.m_rvControl != null)
				{
					this.m_rvControl.method_0(flag);
				}
				return flag;
			}
			break;
		}
		}
		return false;
	}

	// Token: 0x0600223E RID: 8766 RVA: 0x000A30B4 File Offset: 0x000A12B4
	public void imethod_5(Entity entity_0, bool bool_0 = false)
	{
		if (this.m_cooldown.method_6() && !this.m_cooldown.method_7())
		{
			return;
		}
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return;
		}
		switch (this.m_selectionView)
		{
		case TownInstanceSelectionTrigger.SelectionView.Instance:
			if (!GroupManager.smethod_0().method_20())
			{
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("80004");
			}
			if (GroupManager.smethod_0().method_18())
			{
				if (GroupManager.smethod_0().method_19())
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.System, string.Empty, LocalizedString.smethod_0(new LocalizedString("GroupMember_LevelLocked")), 0, string.Empty);
				}
				else
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.System, string.Empty, LocalizedString.smethod_0(new LocalizedString("GroupMember_CannotUse")), 0, string.Empty);
				}
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>().Boolean_1 = true;
			break;
		case TownInstanceSelectionTrigger.SelectionView.Town:
			MonoSingleton<GameFlowManager>.Instance.method_7();
			this.m_cooldown.Start(1f);
			break;
		case TownInstanceSelectionTrigger.SelectionView.RV:
			MonoSingleton<GameFlowManager>.Instance.method_6();
			this.m_cooldown.Start(1f);
			break;
		}
	}

	// Token: 0x0600223F RID: 8767 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_0()
	{
	}

	// Token: 0x06002240 RID: 8768 RVA: 0x0000311D File Offset: 0x0000131D
	public bool imethod_4()
	{
		return false;
	}

	// Token: 0x06002241 RID: 8769 RVA: 0x00013A41 File Offset: 0x00011C41
	public Vector3 imethod_0()
	{
		return base.transform.position;
	}

	// Token: 0x06002242 RID: 8770 RVA: 0x00017997 File Offset: 0x00015B97
	public E_USE_TYPE imethod_6()
	{
		return (this.m_selectionView != TownInstanceSelectionTrigger.SelectionView.RV) ? E_USE_TYPE.E_OPEN : E_USE_TYPE.E_ENTER;
	}

	// Token: 0x06002243 RID: 8771 RVA: 0x000179A7 File Offset: 0x00015BA7
	private void Update()
	{
		this.method_1();
	}

	// Token: 0x06002244 RID: 8772 RVA: 0x000A31EC File Offset: 0x000A13EC
	private void method_1()
	{
		if (MonoSingleton<TargetingManager>.Instance == null)
		{
			return;
		}
		bool flag = false;
		E_HighlightType e_HighlightType = ((!NPC_UIFlowController.smethod_0().Boolean_0) ? MonoSingleton<TargetingManager>.Instance.method_8(this, ref flag) : E_HighlightType.None);
		this.method_2(e_HighlightType, flag);
	}

	// Token: 0x06002245 RID: 8773 RVA: 0x000A3230 File Offset: 0x000A1430
	public void method_2(E_HighlightType e_HighlightType_0, bool bool_0 = false)
	{
		if (base.transform.parent != null && base.transform.parent.gameObject != null)
		{
			this.m_highlight_wrapper.method_1(base.transform.parent.gameObject, e_HighlightType_0, bool_0);
		}
	}

	// Token: 0x06002246 RID: 8774 RVA: 0x000179AF File Offset: 0x00015BAF
	private void OnRenderObject()
	{
		this.m_highlight_wrapper.OnRenderObject(base.gameObject);
	}

	// Token: 0x06002247 RID: 8775 RVA: 0x000A3288 File Offset: 0x000A1488
	protected void method_3(Dictionary<int, QuestProgress> dictionary_0)
	{
		if (m_iInstanceIDList == null || dictionary_0 == null)
		{
			return;
		}
		bool flag = false;
		foreach (QuestProgress value in dictionary_0.Values)
		{
			if (value.mStatus != QuestState.InProgress)
			{
				continue;
			}
			Quest quest = ns0.ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(value.mQuestId);
			if (quest == null)
			{
				continue;
			}
			if (quest.mIsBoundInstance)
			{
				int[] mBoundInstanceList = quest.mBoundInstanceList;
				foreach (int item in mBoundInstanceList)
				{
					if (m_iInstanceIDList.Contains(item))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				break;
			}
			flag = true;
			break;
		}
		if (m_childEyeIcon != null && m_childEyeIcon.gameObject.activeInHierarchy != flag)
		{
			m_childEyeIcon.gameObject.SetActive(flag);
		}
	}
	// Token: 0x06002248 RID: 8776 RVA: 0x000179C2 File Offset: 0x00015BC2
	public void OnQuestUpdate(int characterId, int questId, QuestState questState)
	{
		this.method_3(QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x06002249 RID: 8777 RVA: 0x000179C2 File Offset: 0x00015BC2
	public void OnQuestAccepted(int characterId, int questId)
	{
		this.method_3(QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x0600224A RID: 8778 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestAbandoned(int characterId, int questId)
	{
	}

	// Token: 0x0600224B RID: 8779 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards)
	{
	}

	// Token: 0x0600224C RID: 8780 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
	}

	// Token: 0x0600224D RID: 8781 RVA: 0x000179D4 File Offset: 0x00015BD4
	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> playerQuestProgress)
	{
		this.method_3(playerQuestProgress);
	}

	// Token: 0x0600224E RID: 8782 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnTaskProgressUpgrade(int questID, int taskID, int count)
	{
	}

	// Token: 0x040016D1 RID: 5841
	public TownInstanceSelectionTrigger.SelectionView m_selectionView;

	// Token: 0x040016D2 RID: 5842
	protected CollisionManager m_collisionManager;

	// Token: 0x040016D3 RID: 5843
	protected List<int> m_iInstanceIDList = new List<int>();

	// Token: 0x040016D4 RID: 5844
	protected Transform m_childEyeIcon;

	// Token: 0x040016D5 RID: 5845
	protected RVControl m_rvControl;

	// Token: 0x040016D6 RID: 5846
	private Utils.Timer m_cooldown = new Utils.Timer();

	// Token: 0x040016D7 RID: 5847
	private HighlightWrapper m_highlight_wrapper = new HighlightWrapper();

	// Token: 0x02000534 RID: 1332
	public enum SelectionView
	{
		// Token: 0x040016D9 RID: 5849
		Instance,
		// Token: 0x040016DA RID: 5850
		Town,
		// Token: 0x040016DB RID: 5851
		RV
	}
}
