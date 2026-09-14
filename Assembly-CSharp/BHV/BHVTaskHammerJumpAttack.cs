using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D5 RID: 469
	public class BHVTaskHammerJumpAttack : BHVTask
	{
		// Token: 0x06000A11 RID: 2577 RVA: 0x0000A024 File Offset: 0x00008224
		public BHVTaskHammerJumpAttack()
		{
			base.m_Type = BHVTaskType.HammerJumpAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0000A046 File Offset: 0x00008246
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamHammerJumpAttack_0 = bhvtaskParam_0 as BHVTaskParamHammerJumpAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x0000A05B File Offset: 0x0000825B
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamHammerJumpAttack_0;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x000617D0 File Offset: 0x0005F9D0
		public override void Start()
		{
			base.Start();
			this.animationJumpAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("JumpAttack") as AnimationJumpAttackState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.JumpAttack);
			this.bhvhammerJumpSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVHammerJumpSettings>();
			this.bool_1 = false;
			this.float_0 = 0.7f;
			this.bool_2 = false;
			if (!this.curve_0.method_7(this.bhvtaskManager_0.m_entity.transform.position, this.bhvtaskParamHammerJumpAttack_0.vector3_0, 1f))
			{
				base.m_Status = BHVTaskStatus.FAILED;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.m_validateNextMovePosition = false;
			AIServiceUtility.AIServiceUtility_0.method_5(this.curve_0.m_curveEndPosition, this.bhvhammerJumpSettings_0.m_hammerDamageRange);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x000618AC File Offset: 0x0005FAAC
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status != BHVTaskStatus.FAILED)
			{
				if (base.m_Status != BHVTaskStatus.SUCCESS)
				{
					if (this.animationJumpAttackState_0.EAnimationJumpStep_0 == EAnimationJumpStep.JumpLoop)
					{
						Vector3 vector;
						bool flag = this.curve_0.Update(deltaTime, this.bhvhammerJumpSettings_0.m_jumpSpeed, out vector);
						this.bhvtaskManager_0.transform.position = vector;
						if (flag)
						{
							this.bhvtaskManager_0.m_entity.vmethod_49();
							this.animationJumpAttackState_0.EAnimationJumpStep_0 = EAnimationJumpStep.JumpLand;
							AIServiceUtility.AIServiceUtility_0.method_6();
						}
					}
					else if (this.animationJumpAttackState_0.EAnimationJumpStep_0 == EAnimationJumpStep.JumpFinish)
					{
						this.bhvtaskManager_0.m_entity.vmethod_49();
						base.m_Status = BHVTaskStatus.SUCCESS;
					}
					if (!this.bool_1)
					{
						if ((this.bhvtaskManager_0.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit)
						{
							(this.bhvtaskManager_0.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit = false;
							this.bool_1 = true;
							this.method_0();
						}
					}
					else
					{
						this.float_0 -= deltaTime;
						if (this.float_0 < 0f && !this.bool_2)
						{
							this.bool_2 = true;
							if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
							{
								this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_13(ENPCParticleType.E_HammerHitVFX);
							}
						}
					}
					return;
				}
			}
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0000A063 File Offset: 0x00008263
		public override void vmethod_3(bool bool_3)
		{
			this.bhvtaskManager_0.m_entity.vmethod_49();
			AIServiceUtility.AIServiceUtility_0.method_6();
			base.vmethod_3(bool_3);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00061A04 File Offset: 0x0005FC04
		private void method_0()
		{
			if (this.bhvtaskParamHammerJumpAttack_0.gameObject_0 != null)
			{
				EntityPlayer component = this.bhvtaskParamHammerJumpAttack_0.gameObject_0.GetComponent<EntityPlayer>();
				if (component != null)
				{
					BadAssFPSCamera badAssFPSCamera = component.method_45();
					if (badAssFPSCamera != null)
					{
						badAssFPSCamera.method_6(BadAssFPSCamera.ShakeType.medium);
					}
				}
			}
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				Vector3 position = (this.bhvtaskManager_0.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_hammerVFXTransform.position;
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_10(ENPCParticleType.E_HammerHitVFX, position, true);
			}
		}

		// Token: 0x0400093D RID: 2365
		private BHVTaskParamHammerJumpAttack bhvtaskParamHammerJumpAttack_0;

		// Token: 0x0400093E RID: 2366
		private AnimationJumpAttackState animationJumpAttackState_0;

		// Token: 0x0400093F RID: 2367
		private BHVHammerJumpSettings bhvhammerJumpSettings_0;

		// Token: 0x04000940 RID: 2368
		private AIServiceCurve.Curve curve_0 = new AIServiceCurve.Curve();

		// Token: 0x04000941 RID: 2369
		private bool bool_1;

		// Token: 0x04000942 RID: 2370
		private float float_0;

		// Token: 0x04000943 RID: 2371
		private bool bool_2;
	}
}
