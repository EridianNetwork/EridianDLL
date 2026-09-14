using System;
using Core;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200023A RID: 570
	public class BHVTaskPlayerSpawn : BHVTask
	{
		// Token: 0x06000BAA RID: 2986 RVA: 0x0000B6C0 File Offset: 0x000098C0
		public BHVTaskPlayerSpawn()
		{
			base.m_Type = BHVTaskType.PlayerSpawn;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0000B6D0 File Offset: 0x000098D0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerSpawn_0 = bhvtaskParam_0 as BHVTaskParamPlayerSpawn;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0000B6E5 File Offset: 0x000098E5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerSpawn_0;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x000674A4 File Offset: 0x000656A4
		public override void Start()
		{
			base.Start();
			Entity entity = this.bhvtaskManager_0.m_entity;
			if (entity == null)
			{
				return;
			}
			if (entity.vmethod_26() && MonoSingleton<InputManager>.Instance)
			{
				Camera[] allCameras = Camera.allCameras;
				for (int i = 0; i < allCameras.Length; i++)
				{
					if (allCameras[i].GetComponent<EstablishingShotCam>() != null)
					{
						allCameras[i].enabled = false;
					}
				}
				MonoSingleton<InputManager>.Instance.method_2(true);
				if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_18() != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_18().method_6(false);
				}
				if (MonoSingleton<Session>.Instance.method_16())
				{
					UIMessage uimessage = new UIMessage();
					uimessage.m_type = UIMessage.GEnum1.const_0;
					uimessage.m_text = LocalizedString.smethod_0(new LocalizedString(MatchmakingService.MatchmakingService_0.method_0().m_name));
					uimessage.m_displayCountDown = false;
					uimessage.m_duration = 5f;
					MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_2(uimessage);
					if (FriendManager.smethod_0().m_bNewMessageUnread && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_13();
					}
					if (AchievementManager.AchievementManager_0.bNewAchievementUnread && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_16();
					}
					GroupManager.smethod_0().method_26();
				}
				AchievementManager.AchievementManager_0.method_11();
			}
			this.bhvtaskManager_0.m_entity.BroadcastMessage("TriggerEffectByName", "PlayerReviveStart", SendMessageOptions.DontRequireReceiver);
			EntityPlayer entityPlayer = entity as EntityPlayer;
			if (entityPlayer)
			{
				entityPlayer.PlayerSkillManage_0.OnPlayerRespawn();
				UIMapDataManager.smethod_0().OnPlayerRevive(entityPlayer);
				entityPlayer.OnPlayerRespawn();
				entityPlayer.method_133();
				if (entityPlayer.VFXManager_0 != null)
				{
					entityPlayer.VFXManager_0.method_10(ENPCParticleType.E_PlayerRevive, this.bhvtaskManager_0.transform.position, true);
				}
			}
			base.m_Status = BHVTaskStatus.RUNNING;
			PlayerAnimationManagerFSM playerAnimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as PlayerAnimationManagerFSM;
			if (playerAnimationManagerFSM != null)
			{
				playerAnimationManagerFSM.method_22(PlayerAnimationManagerFSM.ESecondWindMode.Disabled);
				playerAnimationManagerFSM.method_21();
			}
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x000676D4 File Offset: 0x000658D4
		public override void vmethod_3(bool bool_1)
		{
			if (this.bhvtaskManager_0 == null)
			{
				return;
			}
			if (this.bhvtaskManager_0.m_entity == null)
			{
				return;
			}
			this.bhvtaskManager_0.m_entity.BroadcastMessage("TriggerEffectByName", "PlayerReviveEnd", SendMessageOptions.DontRequireReceiver);
			if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				EntityPlayer entityPlayer = this.bhvtaskManager_0.m_entity as EntityPlayer;
				if (entityPlayer != null)
				{
					entityPlayer.OnPlayerRespawnFinish();
					if (MonoSingleton<GraphicsMgr>.Instance != null)
					{
						MonoSingleton<GraphicsMgr>.Instance.method_16().method_5(entityPlayer);
						MonoSingleton<GraphicsMgr>.Instance.method_20().method_5();
					}
				}
			}
		}

		// Token: 0x04000A88 RID: 2696
		private BHVTaskParamPlayerSpawn bhvtaskParamPlayerSpawn_0;
	}
}
