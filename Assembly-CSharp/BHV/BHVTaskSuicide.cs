using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000211 RID: 529
	public class BHVTaskSuicide : BHVTask
	{
		// Token: 0x06000B0A RID: 2826 RVA: 0x0000AE20 File Offset: 0x00009020
		public BHVTaskSuicide()
		{
			base.m_Type = BHVTaskType.Suicide;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0000AE3E File Offset: 0x0000903E
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSuicide_0 = bhvtaskParam_0 as BHVTaskParamSuicide;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0000AE53 File Offset: 0x00009053
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSuicide_0;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x00064CBC File Offset: 0x00062EBC
		public override void Start()
		{
			base.Start();
			this.animationSuicideBombState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.SuicideBomb)) as AnimationSuicideBombState;
			if (this.animationSuicideBombState_0 != null)
			{
				this.animationSuicideBombState_0.m_fuzeDuration = this.bhvtaskParamSuicide_0.float_0;
			}
			this.suicideState_0 = BHVTaskSuicide.SuicideState.const_1;
			this.bool_1 = false;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x00064D20 File Offset: 0x00062F20
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.bhvtaskManager_0.m_animationManagerFSM == null || this.animationSuicideBombState_0 == null)
			{
				base.m_Status = BHVTaskStatus.FAILED;
				this.suicideState_0 = BHVTaskSuicide.SuicideState.const_4;
			}
			BHVTaskSuicide.SuicideState suicideState = this.suicideState_0;
			switch (suicideState + 1)
			{
			case BHVTaskSuicide.SuicideState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskSuicide.SuicideState.const_2:
				this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.SuicideBomb);
				base.m_Status = BHVTaskStatus.RUNNING;
				this.suicideState_0 = BHVTaskSuicide.SuicideState.const_2;
				return;
			case BHVTaskSuicide.SuicideState.const_3:
				switch (this.animationSuicideBombState_0.m_bombStep)
				{
				case EAnimationSuicideBombStep.BombNull:
					base.m_Status = BHVTaskStatus.FAILED;
					this.suicideState_0 = BHVTaskSuicide.SuicideState.const_4;
					break;
				case EAnimationSuicideBombStep.BombStart:
					base.m_Status = BHVTaskStatus.RUNNING;
					this.bool_1 = true;
					break;
				case EAnimationSuicideBombStep.BombIdle:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationSuicideBombStep.BombExplode:
					base.m_Status = BHVTaskStatus.RUNNING;
					this.suicideState_0 = BHVTaskSuicide.SuicideState.const_3;
					break;
				}
				return;
			case BHVTaskSuicide.SuicideState.const_4:
				if (this.bool_1)
				{
					this.method_0();
					this.bool_1 = false;
				}
				base.m_Status = BHVTaskStatus.RUNNING;
				this.suicideState_0 = BHVTaskSuicide.SuicideState.const_4;
				return;
			case (BHVTaskSuicide.SuicideState)4:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0000AE5B File Offset: 0x0000905B
		public override void vmethod_3(bool bool_2)
		{
			if (this.bool_1)
			{
				this.method_0();
				this.bool_1 = false;
			}
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00064E4C File Offset: 0x0006304C
		public void method_0()
		{
			if (this.bhvtaskManager_0 && this.bhvtaskManager_0.m_animationManagerFSM && this.bhvtaskManager_0.m_animationManagerFSM.m_weaponHolder)
			{
				ParticleEffect componentInChildren = this.bhvtaskManager_0.m_animationManagerFSM.m_weaponHolder.GetComponentInChildren<ParticleEffect>();
				if (componentInChildren != null)
				{
					ParticleSystem particleSystem = (ParticleSystem)global::UnityEngine.Object.Instantiate(componentInChildren.m_effect);
					particleSystem.transform.position = this.bhvtaskManager_0.m_animationManagerFSM.m_weaponHolder.position;
					particleSystem.transform.rotation = Quaternion.identity;
					if (!particleSystem.playOnAwake)
					{
						particleSystem.Play();
					}
					global::UnityEngine.Object.Destroy(particleSystem.gameObject, 3f);
				}
				BaseEventTriggerCtl componentInChildren2 = this.bhvtaskManager_0.m_animationManagerFSM.m_weaponHolder.GetComponentInChildren<BaseEventTriggerCtl>();
				if (componentInChildren2)
				{
					componentInChildren2.vmethod_1(AudioEventName.Grenade_Explosion_Rnd);
				}
				Renderer componentInChildren3 = this.bhvtaskManager_0.m_animationManagerFSM.m_weaponHolder.GetComponentInChildren<Renderer>();
				if (componentInChildren3 != null)
				{
					componentInChildren3.transform.position = this.bhvtaskManager_0.m_animationManagerFSM.m_weaponHolder.position;
					componentInChildren3.enabled = false;
				}
			}
		}

		// Token: 0x040009FD RID: 2557
		private BHVTaskParamSuicide bhvtaskParamSuicide_0;

		// Token: 0x040009FE RID: 2558
		private AnimationSuicideBombState animationSuicideBombState_0;

		// Token: 0x040009FF RID: 2559
		private BHVTaskSuicide.SuicideState suicideState_0 = BHVTaskSuicide.SuicideState.const_0;

		// Token: 0x04000A00 RID: 2560
		private bool bool_1;

		// Token: 0x02000212 RID: 530
		private enum SuicideState
		{
			// Token: 0x04000A02 RID: 2562
			const_0 = -1,
			// Token: 0x04000A03 RID: 2563
			const_1,
			// Token: 0x04000A04 RID: 2564
			const_2,
			// Token: 0x04000A05 RID: 2565
			const_3,
			// Token: 0x04000A06 RID: 2566
			const_4
		}
	}
}
