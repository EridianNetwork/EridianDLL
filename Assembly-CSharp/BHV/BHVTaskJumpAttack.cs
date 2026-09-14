using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001E3 RID: 483
	public class BHVTaskJumpAttack : BHVTask
	{
		// Token: 0x06000A4F RID: 2639 RVA: 0x0000A338 File Offset: 0x00008538
		public BHVTaskJumpAttack()
		{
			base.m_Type = BHVTaskType.JumpAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0000A35A File Offset: 0x0000855A
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamJumpAttack_0 = bhvtaskParam_0 as BHVTaskParamJumpAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0000A36F File Offset: 0x0000856F
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamJumpAttack_0;
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000629D8 File Offset: 0x00060BD8
		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			if (this.animationJumpAttackState_0 == null)
			{
				this.animationJumpAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("JumpAttack") as AnimationJumpAttackState;
			}
			this.entity_0 = this.bhvtaskParamJumpAttack_0.gameObject_0.GetComponent<Entity>();
			if (this.entity_0 != null)
			{
				this.transform_0 = this.entity_0.vmethod_17().method_7();
			}
			if (this.bhvjumpAttackSettings_0 == null)
			{
				this.bhvjumpAttackSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVJumpAttackSettings>();
			}
			if (this.bhvtaskParamJumpAttack_0.jumpAttackStep_0 == BHVTaskParamJumpAttack.JumpAttackStep.const_0)
			{
				if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
				{
					this.method_0();
					float num = Mathf.Clamp(this.bhvjumpAttackSettings_0.m_warningZoneRadius, 2f, this.bhvjumpAttackSettings_0.m_warningZoneRadius);
					AIServiceUtility.AIServiceUtility_0.method_5(this.curve_0.m_curveEndPosition, num);
				}
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.JumpAttack);
				return;
			}
			if (this.bhvtaskParamJumpAttack_0.jumpAttackStep_0 != BHVTaskParamJumpAttack.JumpAttackStep.const_1)
			{
				if (this.bhvtaskParamJumpAttack_0.jumpAttackStep_0 == BHVTaskParamJumpAttack.JumpAttackStep.const_2)
				{
					this.animationJumpAttackState_0.EAnimationJumpStep_0 = EAnimationJumpStep.JumpLand;
					if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
					{
						AIServiceUtility.AIServiceUtility_0.method_6();
						if ((this.bhvtaskManager_0.m_entity as EntityNpc).m_subType == EntityNpc.EntitySubType.CHR_SpiderantWidowmaker)
						{
							this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_4(ENPCParticleType.E_JumpAttack, 0f, true);
						}
					}
				}
				return;
			}
			if (!(this.bhvtaskManager_0.m_entity as EntityNpc).method_18() && !this.method_0())
			{
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			}
			this.animationJumpAttackState_0.EAnimationJumpStep_0 = EAnimationJumpStep.JumpLoop;
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bJumpAttackLoop", true);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", false);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bJumpAttackLand", false);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00062BEC File Offset: 0x00060DEC
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS || base.m_Status == BHVTaskStatus.FAILED)
			{
				return;
			}
			base.Update(deltaTime);
			if (this.bhvtaskParamJumpAttack_0.jumpAttackStep_0 == BHVTaskParamJumpAttack.JumpAttackStep.const_0)
			{
				this.method_1(this.bhvtaskParamJumpAttack_0.gameObject_0.transform.position);
				return;
			}
			if (this.bhvtaskParamJumpAttack_0.jumpAttackStep_0 == BHVTaskParamJumpAttack.JumpAttackStep.const_2 && this.animationJumpAttackState_0.EAnimationJumpStep_0 == EAnimationJumpStep.JumpFinish)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
				return;
			}
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0000A377 File Offset: 0x00008577
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
			{
				AIServiceUtility.AIServiceUtility_0.method_6();
			}
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00062C70 File Offset: 0x00060E70
		private bool method_0()
		{
			if (this.transform_0 != null)
			{
				this.vector3_0 = this.transform_0.position;
				this.vector3_0.y = this.vector3_0.y - 0.5f;
			}
			else
			{
				this.vector3_0 = this.entity_0.method_1();
				this.vector3_0.y = this.vector3_0.y + this.entity_0.m_entityHeight;
			}
			bool flag;
			if (this.bhvtaskParamJumpAttack_0.ecurveType_0 == AIServiceCurve.ECurveType.ESpiderWidommakeJumpCurve)
			{
				flag = this.curve_0.method_2(this.bhvtaskManager_0.transform.position, this.vector3_0, 1.2f);
			}
			else if (this.bhvtaskParamJumpAttack_0.ecurveType_0 == AIServiceCurve.ECurveType.EKnoxxJetAttackCurve)
			{
				flag = this.curve_0.method_5(this.bhvtaskManager_0.transform.position, this.vector3_0);
			}
			else
			{
				flag = this.curve_0.method_0(this.bhvtaskManager_0.transform.position, this.vector3_0, 1.5f);
			}
			return flag;
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00062D78 File Offset: 0x00060F78
		private void method_1(Vector3 vector3_1)
		{
			if (!(this.bhvtaskParamJumpAttack_0.gameObject_0 == null) && this.curve_0 != null)
			{
				Vector3 normalized = (vector3_1 - this.bhvtaskManager_0.transform.position).normalized;
				normalized.y = 0f;
				this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.transform.forward, normalized, Time.deltaTime * 20f);
				return;
			}
		}

		// Token: 0x0400097E RID: 2430
		private BHVTaskParamJumpAttack bhvtaskParamJumpAttack_0;

		// Token: 0x0400097F RID: 2431
		private Vector3 vector3_0;

		// Token: 0x04000980 RID: 2432
		private Entity entity_0;

		// Token: 0x04000981 RID: 2433
		private Transform transform_0;

		// Token: 0x04000982 RID: 2434
		private BHVJumpAttackSettings bhvjumpAttackSettings_0;

		// Token: 0x04000983 RID: 2435
		private AIServiceCurve.Curve curve_0 = new AIServiceCurve.Curve();

		// Token: 0x04000984 RID: 2436
		private AnimationJumpAttackState animationJumpAttackState_0;
	}
}
