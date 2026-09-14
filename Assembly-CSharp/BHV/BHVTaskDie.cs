using System;
using ns0;

namespace BHV
{
	// Token: 0x02000180 RID: 384
	public class BHVTaskDie : BHVTaskAnimationState
	{
		// Token: 0x060008A6 RID: 2214 RVA: 0x00008B3E File Offset: 0x00006D3E
		public BHVTaskDie()
		{
			base.m_Type = BHVTaskType.Die;
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00008B4D File Offset: 0x00006D4D
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDie_0 = bhvtaskParam_0 as BHVTaskParamDie;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00008B62 File Offset: 0x00006D62
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDie_0;
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0005BEC4 File Offset: 0x0005A0C4
		public override void Start()
		{
			base.Start();
			this.animationDieState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("Die") as AnimationDieState;
			if (this.animationDieState_0 != null)
			{
				this.animationDieState_0.m_force = this.bhvtaskParamDie_0.float_0;
				this.animationDieState_0.m_explosionOrigin = this.bhvtaskParamDie_0.vector3_0;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.m_damageType = ((!this.bhvtaskParamDie_0.bool_1) ? DamageType.None : DamageType.Death_Head);
			this.bhvtaskManager_0.m_animationManagerFSM.m_iDeathAnimIndex = this.bhvtaskParamDie_0.int_3;
			DamageManager.DamageManager_0.method_2(this.bhvtaskManager_0.m_entity);
			EquipmentInventoryEntityNpcBoss equipmentInventoryEntityNpcBoss = this.bhvtaskManager_0.m_entity.vmethod_19() as EquipmentInventoryEntityNpcBoss;
			if (equipmentInventoryEntityNpcBoss != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_17();
			}
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0005BFB0 File Offset: 0x0005A1B0
		public override void Update(float deltaTime)
		{
			BHVTaskAnimationState.State state_ = this.state_0;
			base.Update(deltaTime, AnimationStateFSM.Die);
			if (state_ == BHVTaskAnimationState.State.const_1 && this.state_0 == BHVTaskAnimationState.State.const_2)
			{
				AIServiceUtility.AIServiceUtility_0.method_10(this.bhvtaskManager_0, false);
			}
		}

		// Token: 0x04000815 RID: 2069
		private BHVTaskParamDie bhvtaskParamDie_0;

		// Token: 0x04000816 RID: 2070
		private AnimationDieState animationDieState_0;
	}
}
