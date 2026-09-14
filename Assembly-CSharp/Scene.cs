using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x0200052B RID: 1323
public class Scene : MonoBehaviour
{
	// Token: 0x06002207 RID: 8711 RVA: 0x0001775A File Offset: 0x0001595A
	public Scene.SceneState method_0()
	{
		return this.m_state;
	}

	// Token: 0x06002208 RID: 8712 RVA: 0x000A22E4 File Offset: 0x000A04E4
	protected void method_1(Scene.SceneState sceneState_0)
	{
		if (sceneState_0 == Scene.SceneState.Active && this.m_state != sceneState_0)
		{
			for (int i = 0; i < this.m_onActiveActions.Length; i++)
			{
				this.m_onActiveActions[i].vmethod_0(this);
			}
		}
		this.m_state = sceneState_0;
	}

	// Token: 0x06002209 RID: 8713 RVA: 0x00017762 File Offset: 0x00015962
	public void method_2()
	{
		this.m_resetOnNextUpdate = true;
	}

	// Token: 0x0600220A RID: 8714 RVA: 0x0001776B File Offset: 0x0001596B
	private void OnLevelWasLoaded()
	{
		Scene.m_allclusters = global::UnityEngine.Object.FindObjectsOfType(typeof(Scene));
	}

	// Token: 0x0600220B RID: 8715 RVA: 0x000A2328 File Offset: 0x000A0528
	protected virtual void Awake()
	{
		base.enabled = false;
		if (base.transform.parent != null)
		{
			Act component = base.transform.parent.gameObject.GetComponent<Act>();
			if (!(component != null))
			{
			}
		}
		base.gameObject.layer = 2;
	}

	// Token: 0x0600220C RID: 8716 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnClusterCompleted(Scene cluster)
	{
	}

	// Token: 0x0600220D RID: 8717 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_0()
	{
	}

	// Token: 0x0600220E RID: 8718 RVA: 0x000A237C File Offset: 0x000A057C
	protected virtual void vmethod_1()
	{
		for (int i = 0; i < this.m_completionActions.Length; i++)
		{
			this.m_completionActions[i].vmethod_0(this);
		}
		this.vmethod_2();
	}

	// Token: 0x0600220F RID: 8719 RVA: 0x000A23B0 File Offset: 0x000A05B0
	protected virtual void vmethod_2()
	{
		for (int i = 0; i < Scene.m_allclusters.Length; i++)
		{
			Scene scene = Scene.m_allclusters[i] as Scene;
			if (scene.method_4())
			{
				scene.OnClusterCompleted(this);
			}
		}
	}

	// Token: 0x06002210 RID: 8720 RVA: 0x000039EC File Offset: 0x00001BEC
	protected virtual bool vmethod_3()
	{
		return true;
	}

	// Token: 0x06002211 RID: 8721 RVA: 0x000A23EC File Offset: 0x000A05EC
	protected virtual void vmethod_4()
	{
		bool flag = this.m_conditionLogic == Scene.LogicOperator.AND;
		for (int i = 0; i < this.m_clusterConditions.Length; i++)
		{
			if (this.m_clusterConditions[i])
			{
				bool flag2 = this.m_clusterConditions[i].vmethod_0();
				if (this.m_conditionLogic == Scene.LogicOperator.AND)
				{
					flag = flag && flag2;
				}
				else
				{
					flag = flag || flag2;
				}
				if (flag2)
				{
					this.method_1(Scene.SceneState.Alerted);
				}
			}
		}
		if (flag)
		{
			int num = global::UnityEngine.Random.Range(this.m_minDelay, this.m_maxDelay);
			if (!this.m_showDelayCountDown)
			{
			}
			this.m_activationTimer.Start((float)num);
			this.method_1(Scene.SceneState.Awake);
		}
	}

	// Token: 0x06002212 RID: 8722 RVA: 0x00017781 File Offset: 0x00015981
	protected void method_3()
	{
		if (this.m_activationTimer.method_7())
		{
			this.vmethod_0();
			this.method_1(Scene.SceneState.Active);
		}
	}

	// Token: 0x06002213 RID: 8723 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5()
	{
	}

	// Token: 0x06002214 RID: 8724 RVA: 0x0001779D File Offset: 0x0001599D
	protected bool method_4()
	{
		return this.m_state == Scene.SceneState.Sleeping || this.m_state == Scene.SceneState.Alerted;
	}

	// Token: 0x06002215 RID: 8725 RVA: 0x000A2488 File Offset: 0x000A0688
	private void Update()
	{
		if (this.m_resetOnNextUpdate)
		{
			this.method_1(Scene.SceneState.Sleeping);
			for (int i = 0; i < this.m_clusterConditions.Length; i++)
			{
				if (this.m_clusterConditions[i])
				{
					this.m_clusterConditions[i].Reset();
				}
			}
			this.m_resetOnNextUpdate = false;
		}
		switch (this.method_0())
		{
		case Scene.SceneState.Sleeping:
		case Scene.SceneState.Alerted:
			this.vmethod_4();
			break;
		case Scene.SceneState.Awake:
			this.method_3();
			break;
		case Scene.SceneState.Active:
			this.vmethod_5();
			if (this.vmethod_3())
			{
				this.method_1(Scene.SceneState.Completed);
				this.vmethod_1();
			}
			break;
		}
	}

	// Token: 0x06002216 RID: 8726 RVA: 0x000177B3 File Offset: 0x000159B3
	protected void method_5(bool bool_0)
	{
		this.method_1(Scene.SceneState.Completed);
		this.vmethod_1();
	}

	// Token: 0x06002217 RID: 8727 RVA: 0x000A2524 File Offset: 0x000A0724
	public bool method_6()
	{
		for (int i = 0; i < this.m_clusterConditions.Length; i++)
		{
			if (this.m_clusterConditions[i] is ClusterCondition_TriggerZone)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002218 RID: 8728 RVA: 0x000A2558 File Offset: 0x000A0758
	private void OnTriggerEnter(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (component != null)
		{
			PlayerInfoSync playerInfoSync = component.vmethod_25();
			if (playerInfoSync)
			{
				this.m_playerIdsInTrigger.Add(playerInfoSync.m_id);
			}
			this.m_playerInTriggerCount++;
		}
	}

	// Token: 0x06002219 RID: 8729 RVA: 0x000A25A4 File Offset: 0x000A07A4
	private void OnTriggerExit(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (component != null)
		{
			PlayerInfoSync playerInfoSync = component.vmethod_25();
			if (playerInfoSync)
			{
				this.m_playerIdsInTrigger.Remove(playerInfoSync.m_id);
				if (component.m_claptrap)
				{
					MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().m_claptrapScore = MonoSingleton<ClaptrapZone>.Instance.m_score;
				}
			}
			this.m_playerInTriggerCount--;
		}
	}

	// Token: 0x0600221A RID: 8730 RVA: 0x000A2618 File Offset: 0x000A0818
	private void OnTriggerStay(Collider other)
	{
		for (int i = 0; i < this.m_clusterConditions.Length; i++)
		{
			if (this.m_clusterConditions[i] is ClusterCondition_TriggerZone)
			{
				ClusterCondition_TriggerZone clusterCondition_TriggerZone = this.m_clusterConditions[i] as ClusterCondition_TriggerZone;
				if (!clusterCondition_TriggerZone.vmethod_0())
				{
					if (!clusterCondition_TriggerZone.claptrapCheck)
					{
						int num = MonoSingleton<EntityManager>.Instance.method_9(Entity.EntityType.Player);
						switch (clusterCondition_TriggerZone.m_triggeringCondition)
						{
						case ClusterCondition_TriggerZone.TriggerCondition.OnePlayer:
							if (this.m_playerInTriggerCount > 0)
							{
								if (clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow)
								{
									this.m_linkedPlayers.Clear();
									foreach (int num2 in this.m_playerIdsInTrigger)
									{
										this.m_linkedPlayers.Add(MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(num2));
									}
								}
								clusterCondition_TriggerZone.method_1();
							}
							break;
						case ClusterCondition_TriggerZone.TriggerCondition.AtLeastHalfPlayers:
							if ((double)(num / this.m_playerInTriggerCount) >= 0.5)
							{
								if (clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow)
								{
									this.m_linkedPlayers.Clear();
									foreach (int num3 in this.m_playerIdsInTrigger)
									{
										this.m_linkedPlayers.Add(MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(num3));
									}
								}
								clusterCondition_TriggerZone.method_1();
							}
							break;
						case ClusterCondition_TriggerZone.TriggerCondition.AllPlayers:
							if (num == this.m_playerInTriggerCount)
							{
								if (clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow)
								{
									this.m_linkedPlayers.Clear();
									foreach (int num4 in this.m_playerIdsInTrigger)
									{
										this.m_linkedPlayers.Add(MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(num4));
									}
								}
								clusterCondition_TriggerZone.method_1();
							}
							break;
						}
					}
					else
					{
						EntityPlayer component = other.GetComponent<EntityPlayer>();
						if (component && component.m_claptrap)
						{
							MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().m_claptrapTeamID = (int)clusterCondition_TriggerZone.teamID;
							MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().m_claptrapScore = clusterCondition_TriggerZone.score;
							if (clusterCondition_TriggerZone.teamID != (ClusterCondition_TriggerZone.TeamID)component.vmethod_9())
							{
								clusterCondition_TriggerZone.method_1();
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600221B RID: 8731 RVA: 0x000177C2 File Offset: 0x000159C2
	public void method_7(out List<PlayerInfoSync> list_0)
	{
		if (this.m_linkedPlayers.Count > 0)
		{
			list_0 = this.m_linkedPlayers;
			return;
		}
		MonoSingleton<Session>.Instance.method_38(out list_0);
	}

	// Token: 0x0600221C RID: 8732 RVA: 0x000177E6 File Offset: 0x000159E6
	public void method_8(Scene scene_0)
	{
		if (scene_0.m_linkedPlayers.Count > 0)
		{
			this.m_linkedPlayers = scene_0.m_linkedPlayers;
		}
	}

	// Token: 0x0600221D RID: 8733 RVA: 0x000A2820 File Offset: 0x000A0A20
	public bool method_9(PlayerInfoSync playerInfoSync_0)
	{
		if (playerInfoSync_0 == null)
		{
			return false;
		}
		if (this.m_linkedPlayers.Count > 0)
		{
			for (int i = 0; i < this.m_linkedPlayers.Count; i++)
			{
				if (this.m_linkedPlayers[i].m_id == playerInfoSync_0.m_id)
				{
					return true;
				}
			}
		}
		else
		{
			List<PlayerInfoSync> list;
			MonoSingleton<Session>.Instance.method_38(out list);
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].m_id == playerInfoSync_0.m_id)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x040016A7 RID: 5799
	[HideInInspector]
	public bool m_showStartConditions;

	// Token: 0x040016A8 RID: 5800
	[HideInInspector]
	public bool m_showOnActiveActions;

	// Token: 0x040016A9 RID: 5801
	[HideInInspector]
	public bool m_showCompletionActions;

	// Token: 0x040016AA RID: 5802
	[HideInInspector]
	public HashSet<int> m_playerIds = new HashSet<int>();

	// Token: 0x040016AB RID: 5803
	public List<PlayerInfoSync> m_linkedPlayers = new List<PlayerInfoSync>();

	// Token: 0x040016AC RID: 5804
	public Scene.LogicOperator m_conditionLogic;

	// Token: 0x040016AD RID: 5805
	[HideInInspector]
	public ClusterCompletionCondition[] m_completionConditions = new ClusterCompletionCondition[0];

	// Token: 0x040016AE RID: 5806
	public ClusterCondition[] m_clusterConditions = new ClusterCondition[0];

	// Token: 0x040016AF RID: 5807
	public int m_minDelay;

	// Token: 0x040016B0 RID: 5808
	public int m_maxDelay;

	// Token: 0x040016B1 RID: 5809
	public bool m_showDelayCountDown;

	// Token: 0x040016B2 RID: 5810
	[HideInInspector]
	private Scene.SceneState m_state;

	// Token: 0x040016B3 RID: 5811
	private int m_playerInTriggerCount;

	// Token: 0x040016B4 RID: 5812
	public HashSet<int> m_playerIdsInTrigger = new HashSet<int>();

	// Token: 0x040016B5 RID: 5813
	private Utils.Timer m_activationTimer = new Utils.Timer();

	// Token: 0x040016B6 RID: 5814
	public ClusterAction[] m_onActiveActions = new ClusterAction[0];

	// Token: 0x040016B7 RID: 5815
	public ClusterAction[] m_completionActions = new ClusterAction[0];

	// Token: 0x040016B8 RID: 5816
	protected bool m_resetOnNextUpdate;

	// Token: 0x040016B9 RID: 5817
	protected static global::UnityEngine.Object[] m_allclusters;

	// Token: 0x0200052C RID: 1324
	public enum SceneState
	{
		// Token: 0x040016BB RID: 5819
		Sleeping,
		// Token: 0x040016BC RID: 5820
		Alerted,
		// Token: 0x040016BD RID: 5821
		Awake,
		// Token: 0x040016BE RID: 5822
		Active,
		// Token: 0x040016BF RID: 5823
		Completed
	}

	// Token: 0x0200052D RID: 1325
	public enum LogicOperator
	{
		// Token: 0x040016C1 RID: 5825
		AND,
		// Token: 0x040016C2 RID: 5826
		OR
	}

	// Token: 0x0200052E RID: 1326
	public enum TargetType
	{
		// Token: 0x040016C4 RID: 5828
		None,
		// Token: 0x040016C5 RID: 5829
		EntityNPC,
		// Token: 0x040016C6 RID: 5830
		StaticObject
	}
}
