using System;
using ns0;
using UnityEngine;
using XsdSettings;

namespace BHV
{
	// Token: 0x02000232 RID: 562
	public class BHVTaskPlayerDead : BHVTask
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x0000B546 File Offset: 0x00009746
		public BHVTaskPlayerDead()
		{
			base.m_Type = BHVTaskType.PlayerDead;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0000B556 File Offset: 0x00009756
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerDead_0 = bhvtaskParam_0 as BHVTaskParamPlayerDead;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x0000B56B File Offset: 0x0000976B
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerDead_0;
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x00066B84 File Offset: 0x00064D84
		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			this.float_0 = this.bhvtaskParamPlayerDead_0.float_1;
			this.bool_1 = false;
			this.bool_2 = false;
			EntityPlayer entityPlayer = this.bhvtaskManager_0.m_entity as EntityPlayer;
			entityPlayer.OnEnterPlayerDead();
			if (entityPlayer.vmethod_26() && MonoSingleton<InputManager>.Instance)
			{
				MonoSingleton<InputManager>.Instance.method_1(true);
				if (MonoSingleton<Session>.Instance.method_12())
				{
					Entity entity = BadAssNetworkView.smethod_4(this.bhvtaskParamPlayerDead_0.int_4);
					ServiceWrapperBase<DeathCamManager>.Instance.method_3(entity, entityPlayer);
					this.method_1();
				}
				else
				{
					if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_18() != null)
					{
						MonoSingleton<GraphicsMgr>.Instance.method_18().method_6(true);
						MonoSingleton<GraphicsMgr>.Instance.method_18().method_7(0.7f);
					}
					if (this.float_0 >= 1f)
					{
						EchoMessage echoMessage = new EchoMessage();
						echoMessage.m_displayTargets = new DisplayTarget[] { DisplayTarget.Countdown };
						echoMessage.m_localizedText = this.float_0.ToString();
						MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_7(echoMessage);
						this.bool_1 = true;
					}
					else
					{
						this.method_0();
					}
				}
			}
			else
			{
				this.method_1();
				this.bool_2 = true;
			}
			PlayerAnimationManagerFSM playerAnimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as PlayerAnimationManagerFSM;
			if (playerAnimationManagerFSM != null)
			{
				playerAnimationManagerFSM.method_22(PlayerAnimationManagerFSM.ESecondWindMode.Disabled);
				playerAnimationManagerFSM.method_21();
			}
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00066CF0 File Offset: 0x00064EF0
		private void method_0()
		{
			EntityPlayer entityPlayer = this.bhvtaskManager_0.m_entity as EntityPlayer;
			if (entityPlayer != null)
			{
				entityPlayer.BroadcastMessage("TriggerEffectByName", "PlayDeath", SendMessageOptions.DontRequireReceiver);
				BaseEventTriggerCtl component = entityPlayer.GetComponent<BaseEventTriggerCtl>();
				if (component != null)
				{
					component.vmethod_1(AudioEventName.Chr_Shr_Respawn);
				}
			}
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x00066D40 File Offset: 0x00064F40
		private void method_1()
		{
			this.animationPlayerDieState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("PlayerDie") as AnimationPlayerDieState;
			this.animationPlayerDieState_0.m_force = this.bhvtaskParamPlayerDead_0.float_0;
			this.animationPlayerDieState_0.m_explosionOrigin = this.bhvtaskParamPlayerDead_0.vector3_0;
			this.animationPlayerDieState_0.m_isHeadShot = this.bhvtaskParamPlayerDead_0.bool_1;
			this.animationPlayerDieState_0.m_deathAnimIndex = this.bhvtaskParamPlayerDead_0.int_3;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.PlayerDie);
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x00066DD8 File Offset: 0x00064FD8
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.float_0 > 0f)
			{
				this.float_0 -= Time.deltaTime;
				if (this.bool_1)
				{
					if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_18() != null)
					{
						MonoSingleton<GraphicsMgr>.Instance.method_18().method_7(1f - 0.3f * this.float_0 / this.bhvtaskParamPlayerDead_0.float_1);
					}
					if (this.float_0 <= 0f)
					{
						this.method_0();
					}
				}
			}
			else if (this.bool_2)
			{
				(this.bhvtaskManager_0.m_animationManagerFSM as PlayerAnimationManagerFSM).method_58();
				this.bool_2 = false;
			}
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x00066E98 File Offset: 0x00065098
		public override void vmethod_3(bool bool_3)
		{
			base.vmethod_3(bool_3);
			if (this.animationPlayerDieState_0 != null)
			{
				this.animationPlayerDieState_0.vmethod_2();
			}
			EntityPlayer entityPlayer = this.bhvtaskManager_0.m_entity as EntityPlayer;
			if (entityPlayer.vmethod_26())
			{
				if (MonoSingleton<Session>.Instance.method_12())
				{
					ServiceWrapperBase<DeathCamManager>.Instance.method_4(entityPlayer);
				}
				entityPlayer.BroadcastMessage("TriggerEffectByName", "PlayRevive", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				(this.bhvtaskManager_0.m_animationManagerFSM as PlayerAnimationManagerFSM).method_59();
				if (this.bhvtaskManager_0.m_animationManagerFSM)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.PlayerIdle);
				}
			}
		}

		// Token: 0x04000A70 RID: 2672
		private BHVTaskParamPlayerDead bhvtaskParamPlayerDead_0;

		// Token: 0x04000A71 RID: 2673
		private AnimationPlayerDieState animationPlayerDieState_0;

		// Token: 0x04000A72 RID: 2674
		private float float_0;

		// Token: 0x04000A73 RID: 2675
		private bool bool_1;

		// Token: 0x04000A74 RID: 2676
		private bool bool_2;
	}
}
