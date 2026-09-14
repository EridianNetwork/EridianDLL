using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

namespace AutoTest
{
	// Token: 0x02000624 RID: 1572
	internal class AutoTestCase_InvulnerablePlayerStandStillForOneMinute : AutoTestCase
	{
		// Token: 0x0600280F RID: 10255 RVA: 0x000BD2E8 File Offset: 0x000BB4E8
		private bool AnyNpcSpawnPoint()
		{
			foreach (GameObject gameObject in global::UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
			{
				if (gameObject.GetComponent<Cluster>() != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002810 RID: 10256 RVA: 0x000BD330 File Offset: 0x000BB530
		protected override void OpenAutoTestCase()
		{
			MonoSingleton<InputManager>.Instance.method_0(this.m_inputReader);
			PhotonStatsGui componentInChildren = MonoSingleton<AppManager>.Instance.GetComponentInChildren<PhotonStatsGui>();
			componentInChildren.statsOn = true;
			componentInChildren.statsWindowOn = true;
			componentInChildren.trafficDetailStatsOn = true;
			MonoSingleton<AppManager>.Instance.m_logNetworkProfile = true;
			PhotonNetwork.NetworkStatisticsEnabled = true;
		}

		// Token: 0x06002811 RID: 10257 RVA: 0x000BD380 File Offset: 0x000BB580
		protected override void UpdateAutoTestCase()
		{
			if (this.m_npc == null)
			{
				if (MonoSingleton<EntityManager>.Instance.method_9(Entity.EntityType.Npc) > 0)
				{
					List<Entity> list;
					MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Npc, out list);
					this.m_npc = list[0];
					this.m_firstNpcPosition = this.m_npc.transform.position;
				}
			}
			else if (this.m_firstNpcPosition != this.m_npc.transform.position)
			{
				this.m_npcMoved = true;
			}
			if (this.m_player == null)
			{
				if (MonoSingleton<EntityManager>.Instance.method_9(Entity.EntityType.Player) > 0)
				{
					List<Entity> list2;
					MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Player, out list2);
					this.m_player = list2[0];
					this.m_firstPlayerPosition = this.m_player.transform.position;
				}
			}
			else if (this.m_firstPlayerPosition != this.m_player.transform.position)
			{
				this.m_playerMoved = true;
			}
			this.m_inputReader.m_timeElapsed = base.m_timeElapsed;
			if (base.m_timeElapsed >= 60f)
			{
				PhotonStatsGui componentInChildren = MonoSingleton<AppManager>.Instance.GetComponentInChildren<PhotonStatsGui>();
				DebugUtils.Log(LogCategory.Autotest, componentInChildren.lastStats);
				if (this.AnyNpcSpawnPoint() && !this.m_npcMoved)
				{
					base.Close(false, "NPC not moving");
					return;
				}
				if (!this.m_playerMoved)
				{
					base.Close(false, "Player not moving");
					return;
				}
				base.Close(true, string.Empty);
			}
		}

		// Token: 0x04001C7B RID: 7291
		private AutoTestBandWidthInputReader m_inputReader = new AutoTestBandWidthInputReader();

		// Token: 0x04001C7C RID: 7292
		private Entity m_npc;

		// Token: 0x04001C7D RID: 7293
		private Vector3 m_firstNpcPosition = default(Vector3);

		// Token: 0x04001C7E RID: 7294
		private bool m_npcMoved;

		// Token: 0x04001C7F RID: 7295
		private Entity m_player;

		// Token: 0x04001C80 RID: 7296
		private Vector3 m_firstPlayerPosition = default(Vector3);

		// Token: 0x04001C81 RID: 7297
		private bool m_playerMoved;
	}
}
