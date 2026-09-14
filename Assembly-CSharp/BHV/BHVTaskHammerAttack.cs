using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D3 RID: 467
	public class BHVTaskHammerAttack : BHVTask
	{
		// Token: 0x06000A07 RID: 2567 RVA: 0x00009F9E File Offset: 0x0000819E
		public BHVTaskHammerAttack()
		{
			base.m_Type = BHVTaskType.HammerAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00009FB5 File Offset: 0x000081B5
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamHammerAttack_0 = bhvtaskParam_0 as BHVTaskParamHammerAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00009FCA File Offset: 0x000081CA
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamHammerAttack_0;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x000615B0 File Offset: 0x0005F7B0
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.MeleeAttack);
			this.bool_1 = false;
			this.float_0 = 0.7f;
			this.bool_2 = false;
			(this.bhvtaskManager_0.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit = false;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00061604 File Offset: 0x0005F804
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if (!this.bool_1)
			{
				if ((this.bhvtaskManager_0.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit)
				{
					(this.bhvtaskManager_0.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit = false;
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
			AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.MeleeAttack);
			if (animationStatus == AnimationStatus.SUCCESS)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000616D8 File Offset: 0x0005F8D8
		private void method_0()
		{
			this.bool_1 = true;
			if (this.bhvtaskParamHammerAttack_0.gameObject_0 != null)
			{
				EntityPlayer component = this.bhvtaskParamHammerAttack_0.gameObject_0.GetComponent<EntityPlayer>();
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

		// Token: 0x04000935 RID: 2357
		private BHVTaskParamHammerAttack bhvtaskParamHammerAttack_0;

		// Token: 0x04000936 RID: 2358
		private bool bool_1;

		// Token: 0x04000937 RID: 2359
		private float float_0;

		// Token: 0x04000938 RID: 2360
		private bool bool_2;
	}
}
