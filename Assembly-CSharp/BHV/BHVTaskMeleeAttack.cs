using System;
using XsdSettings;

namespace BHV
{
	// Token: 0x020001EF RID: 495
	public class BHVTaskMeleeAttack : BHVTask
	{
		// Token: 0x06000A7E RID: 2686 RVA: 0x0000A63E File Offset: 0x0000883E
		public BHVTaskMeleeAttack()
		{
			base.m_Type = BHVTaskType.MeleeAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0000A663 File Offset: 0x00008863
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamMeleeAttack_0 = bhvtaskParam_0 as BHVTaskParamMeleeAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x0000A678 File Offset: 0x00008878
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamMeleeAttack_0;
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00063120 File Offset: 0x00061320
		public override void Start()
		{
			base.Start();
			BHVMeleeAttackSettings bhvmeleeAttackSettings = this.bhvtaskManager_0.vmethod_0<BHVMeleeAttackSettings>();
			if (bhvmeleeAttackSettings != null && bhvmeleeAttackSettings.m_attackSubTypeList != null && bhvmeleeAttackSettings.m_attackSubTypeList.Length > 0)
			{
				this.int_0 = this.bhvtaskManager_0.vmethod_0<BHVMeleeAttackSettings>().m_attackSubTypeList.Length;
			}
			this.meleeState_0 = BHVTaskMeleeAttack.MeleeState.const_1;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_11(false);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0000A680 File Offset: 0x00008880
		private int method_0(float float_0)
		{
			return (int)(float_0 * (float)this.int_0);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00063188 File Offset: 0x00061388
		private AttackSubType method_1(float float_0)
		{
			int num = this.method_0(float_0);
			return this.bhvtaskManager_0.vmethod_0<BHVMeleeAttackSettings>().m_attackSubTypeList[num];
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x000631B0 File Offset: 0x000613B0
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.bhvtaskParamMeleeAttack_0.gameObject_0 == null)
			{
				this.meleeState_0 = BHVTaskMeleeAttack.MeleeState.const_3;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			BHVTaskMeleeAttack.MeleeState meleeState = this.meleeState_0;
			switch (meleeState + 1)
			{
			case BHVTaskMeleeAttack.MeleeState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskMeleeAttack.MeleeState.const_2:
			{
				AnimationMeleeAttackState animationMeleeAttackState = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
				if (animationMeleeAttackState != null)
				{
					animationMeleeAttackState.m_meleeAttackID = this.method_0(this.bhvtaskParamMeleeAttack_0.float_0);
				}
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.MeleeAttack);
				this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
				base.m_Status = BHVTaskStatus.RUNNING;
				this.meleeState_0 = BHVTaskMeleeAttack.MeleeState.const_2;
				return;
			}
			case BHVTaskMeleeAttack.MeleeState.const_3:
			{
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.MeleeAttack);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.meleeState_0 = BHVTaskMeleeAttack.MeleeState.const_3;
					break;
				case AnimationStatus.SUCCESS:
				{
					base.m_Status = BHVTaskStatus.RUNNING;
					this.method_2();
					AnimationMeleeAttackState animationMeleeAttackState2 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
					if (animationMeleeAttackState2 != null && animationMeleeAttackState2.m_triggetHitEvent)
					{
						animationMeleeAttackState2.m_triggetHitEvent = false;
						this.method_3();
					}
					break;
				}
				case AnimationStatus.PREPARE:
					this.meleeState_0 = BHVTaskMeleeAttack.MeleeState.const_3;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				return;
			}
			case (BHVTaskMeleeAttack.MeleeState)3:
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x0000311B File Offset: 0x0000131B
		private void method_2()
		{
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0006330C File Offset: 0x0006150C
		private void method_3()
		{
			if (this.bhvtaskManager_0 == null || this.bhvtaskManager_0.m_entity == null || this.bhvtaskParamMeleeAttack_0.gameObject_0 == null)
			{
				return;
			}
			BHVMeleeAttackSettings bhvmeleeAttackSettings = this.bhvtaskManager_0.vmethod_0<BHVMeleeAttackSettings>();
			if (bhvmeleeAttackSettings == null)
			{
				return;
			}
			if (bhvmeleeAttackSettings.m_canShakeCamera && this.bhvtaskParamMeleeAttack_0.gameObject_0 != null)
			{
				EntityPlayer component = this.bhvtaskParamMeleeAttack_0.gameObject_0.GetComponent<EntityPlayer>();
				if (component != null)
				{
					BadAssFPSCamera badAssFPSCamera = component.method_45();
					if (badAssFPSCamera != null)
					{
						badAssFPSCamera.method_6(BadAssFPSCamera.ShakeType.medium);
					}
				}
			}
		}

		// Token: 0x04000994 RID: 2452
		private BHVTaskParamMeleeAttack bhvtaskParamMeleeAttack_0;

		// Token: 0x04000995 RID: 2453
		private BHVTaskMeleeAttack.MeleeState meleeState_0 = BHVTaskMeleeAttack.MeleeState.const_0;

		// Token: 0x04000996 RID: 2454
		private int int_0 = 1;

		// Token: 0x020001F0 RID: 496
		private enum MeleeState
		{
			// Token: 0x04000998 RID: 2456
			const_0 = -1,
			// Token: 0x04000999 RID: 2457
			const_1,
			// Token: 0x0400099A RID: 2458
			const_2,
			// Token: 0x0400099B RID: 2459
			const_3
		}
	}
}
