using System;

namespace BHV
{
	// Token: 0x020001FC RID: 508
	public class BHVTaskRadiusAttack : BHVTaskAnimationState
	{
		// Token: 0x06000AB5 RID: 2741 RVA: 0x0000A971 File Offset: 0x00008B71
		public BHVTaskRadiusAttack()
		{
			base.m_Type = BHVTaskType.RadiusAttack;
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0000A981 File Offset: 0x00008B81
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamRadiusAttack_0 = bhvtaskParam_0 as BHVTaskParamRadiusAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0000A996 File Offset: 0x00008B96
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamRadiusAttack_0;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00063F3C File Offset: 0x0006213C
		public override void Start()
		{
			base.Start();
			this.animationRadiusAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("RadiusAttack") as AnimationRadiusAttackState;
			this.bool_1 = false;
			if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
			{
				AIServiceUtility.AIServiceUtility_0.method_5(this.bhvtaskManager_0.transform.position, this.bhvtaskParamRadiusAttack_0.float_0);
			}
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x00063FB4 File Offset: 0x000621B4
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.RadiusAttack);
			if (this.animationRadiusAttackState_0.m_bDoDamage && !this.bool_1 && this.bhvtaskManager_0.vmethod_0<BHVRadiusAttackSettings>() != null)
			{
				if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
				{
					AIServiceUtility.AIServiceUtility_0.method_6();
				}
				this.bool_1 = true;
			}
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0000A377 File Offset: 0x00008577
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
			{
				AIServiceUtility.AIServiceUtility_0.method_6();
			}
		}

		// Token: 0x040009C6 RID: 2502
		private BHVTaskParamRadiusAttack bhvtaskParamRadiusAttack_0;

		// Token: 0x040009C7 RID: 2503
		private bool bool_1;

		// Token: 0x040009C8 RID: 2504
		private AnimationRadiusAttackState animationRadiusAttackState_0;
	}
}
