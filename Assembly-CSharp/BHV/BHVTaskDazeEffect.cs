using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001B7 RID: 439
	public class BHVTaskDazeEffect : BHVTask
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x0000981E File Offset: 0x00007A1E
		public BHVTaskDazeEffect()
		{
			base.m_Type = BHVTaskType.DazeEffect;
			base.m_Layer = BHVTaskLayer.EFFECT;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0000984B File Offset: 0x00007A4B
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDazeEffect_0 = bhvtaskParam_0 as BHVTaskParamDazeEffect;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00009860 File Offset: 0x00007A60
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDazeEffect_0;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0005E1B4 File Offset: 0x0005C3B4
		public override void Start()
		{
			base.Start();
			if (this.transform_0 == null)
			{
				this.transform_0 = (this.bhvtaskManager_0.m_entity as EntityNpc).m_headTransform;
			}
			this.float_0 = 0f;
			if (this.bhvtaskManager_0.m_animationManagerFSM != null)
			{
				NPCAnimationManagerFSM npcanimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM;
				if (npcanimationManagerFSM != null)
				{
					npcanimationManagerFSM.m_bInDazeEffect = true;
				}
				if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_5(ENPCParticleType.E_Stun, this.bhvtaskManager_0.m_entity, this.transform_0, this.vector3_0, this.quaternion_0, -1f, true);
				}
				if (this.bhvtaskManager_0.m_animationManagerFSM.Animator_0 != null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.method_7(this.bhvtaskManager_0.vmethod_0<BHVDazeEffectSettings>().m_speedRate);
				}
			}
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0005E2C4 File Offset: 0x0005C4C4
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 += deltaTime;
			float num = this.bhvtaskParamDazeEffect_0.float_0 * this.bhvtaskManager_0.vmethod_0<BHVDazeEffectSettings>().m_dazeDuration;
			if (this.float_0 > num)
			{
				this.OnSuccessOrTerminate();
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0005E31C File Offset: 0x0005C51C
		public void OnSuccessOrTerminate()
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).m_bInDazeEffect = false;
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_13(ENPCParticleType.E_Stun);
			}
			this.bhvtaskManager_0.m_animationManagerFSM.method_6();
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00009868 File Offset: 0x00007A68
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.OnSuccessOrTerminate();
		}

		// Token: 0x0400089C RID: 2204
		private BHVTaskParamDazeEffect bhvtaskParamDazeEffect_0;

		// Token: 0x0400089D RID: 2205
		private float float_0;

		// Token: 0x0400089E RID: 2206
		private Transform transform_0;

		// Token: 0x0400089F RID: 2207
		private Vector3 vector3_0 = Vector3.zero;

		// Token: 0x040008A0 RID: 2208
		private Quaternion quaternion_0 = Quaternion.identity;
	}
}
