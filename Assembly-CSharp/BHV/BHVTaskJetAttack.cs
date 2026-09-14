using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001E0 RID: 480
	public class BHVTaskJetAttack : BHVTask
	{
		// Token: 0x06000A43 RID: 2627 RVA: 0x0000A284 File Offset: 0x00008484
		public BHVTaskJetAttack()
		{
			base.m_Type = BHVTaskType.JetAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0000A2A6 File Offset: 0x000084A6
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamJetAttack_0 = bhvtaskParam_0 as BHVTaskParamJetAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0000A2BB File Offset: 0x000084BB
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamJetAttack_0;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x000627D8 File Offset: 0x000609D8
		public override void Start()
		{
			base.Start();
			this.bool_1 = false;
			this.animationJumpAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("JumpAttack") as AnimationJumpAttackState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.JumpAttack);
			if (this.curve_0 != null)
			{
				this.curve_0.method_5(this.bhvtaskManager_0.m_entity.transform.position, this.bhvtaskParamJetAttack_0.vector3_0);
				AIServiceUtility.AIServiceUtility_0.method_5(this.curve_0.m_curveEndPosition, this.bhvtaskParamJetAttack_0.float_1);
			}
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0000A2C3 File Offset: 0x000084C3
		public override void Update(float deltaTime)
		{
			this.method_0(deltaTime);
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x00062878 File Offset: 0x00060A78
		public void method_0(float float_0)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(float_0);
			if (!this.bool_1)
			{
				Vector3 vector = this.bhvtaskManager_0.transform.position - this.bhvtaskParamJetAttack_0.vector3_0;
				vector.y = 0f;
				if (vector.sqrMagnitude < 0.25f)
				{
					this.bool_1 = true;
					AIServiceUtility.AIServiceUtility_0.method_6();
					this.animationJumpAttackState_0.EAnimationJumpStep_0 = EAnimationJumpStep.JumpLand;
				}
			}
			if (this.animationJumpAttackState_0.EAnimationJumpStep_0 == EAnimationJumpStep.JumpFinish)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
			}
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0000A2CC File Offset: 0x000084CC
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			AIServiceUtility.AIServiceUtility_0.method_6();
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x0006291C File Offset: 0x00060B1C
		private void method_1()
		{
			if (this.bhvtaskParamJetAttack_0.gameObject_0 == null)
			{
				return;
			}
			EntityPlayer component = this.bhvtaskParamJetAttack_0.gameObject_0.GetComponent<EntityPlayer>();
			if (component != null)
			{
				BadAssFPSCamera badAssFPSCamera = component.method_45();
				if (badAssFPSCamera != null)
				{
					badAssFPSCamera.method_6(BadAssFPSCamera.ShakeType.medium);
				}
			}
		}

		// Token: 0x04000971 RID: 2417
		private BHVTaskParamJetAttack bhvtaskParamJetAttack_0;

		// Token: 0x04000972 RID: 2418
		private AnimationJumpAttackState animationJumpAttackState_0;

		// Token: 0x04000973 RID: 2419
		private AIServiceCurve.Curve curve_0 = new AIServiceCurve.Curve();

		// Token: 0x04000974 RID: 2420
		private bool bool_1;
	}
}
