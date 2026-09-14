using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200018F RID: 399
	public class BHVTaskRecharge : BHVTask
	{
		// Token: 0x060008EC RID: 2284 RVA: 0x00008E97 File Offset: 0x00007097
		public BHVTaskRecharge()
		{
			base.m_Type = BHVTaskType.Recharge;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00008EA7 File Offset: 0x000070A7
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamRecharge_0 = bhvtaskParam_0 as BHVTaskParamRecharge;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00008EBC File Offset: 0x000070BC
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamRecharge_0;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0005CF08 File Offset: 0x0005B108
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
			this.animationIdleState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("Idle") as AnimationIdleState;
			if (this.animationIdleState_0 != null)
			{
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bTurnOnSpot", false);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", false);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLoop", false);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLand", false);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bMortarAttack", false);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bRailgunAttack", false);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bLaserSweep", false);
				this.animationIdleState_0.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", false);
			}
			this.bhvtaskManager_0.m_animationManagerFSM.m_validateNextMovePosition = false;
			Renderer[] componentsInChildren = this.bhvtaskManager_0.m_entity.gameObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = true;
			}
			Collider[] componentsInChildren2 = this.bhvtaskManager_0.m_entity.gameObject.GetComponentsInChildren<Collider>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].enabled = true;
			}
			DamageManager.DamageManager_0.method_2(this.bhvtaskManager_0.m_entity);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00008EC4 File Offset: 0x000070C4
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00008ECD File Offset: 0x000070CD
		public override void vmethod_3(bool bool_1)
		{
			DamageManager.DamageManager_0.method_1(this.bhvtaskManager_0.m_entity);
			this.bhvtaskManager_0.m_animationManagerFSM.m_validateNextMovePosition = true;
		}

		// Token: 0x04000846 RID: 2118
		private BHVTaskParamRecharge bhvtaskParamRecharge_0;

		// Token: 0x04000847 RID: 2119
		private AnimationIdleState animationIdleState_0;
	}
}
