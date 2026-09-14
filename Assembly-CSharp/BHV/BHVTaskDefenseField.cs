using System;

namespace BHV
{
	// Token: 0x020001BB RID: 443
	public class BHVTaskDefenseField : BHVTask
	{
		// Token: 0x06000990 RID: 2448 RVA: 0x00009985 File Offset: 0x00007B85
		public BHVTaskDefenseField()
		{
			base.m_Type = BHVTaskType.DefenseField;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x000099A0 File Offset: 0x00007BA0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDefenseField_0 = bhvtaskParam_0 as BHVTaskParamDefenseField;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x000099B5 File Offset: 0x00007BB5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDefenseField_0;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0005E50C File Offset: 0x0005C70C
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bDefense", true);
			this.float_0 = 2.5f;
			DamageManager.DamageManager_0.method_2(this.bhvtaskManager_0.m_entity);
			base.m_Status = BHVTaskStatus.RUNNING;
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_10(ENPCParticleType.E_DefenseField, this.bhvtaskManager_0.transform.position, true);
			}
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0005E5A4 File Offset: 0x0005C7A4
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			this.float_0 -= deltaTime;
			if (this.float_0 < 0f)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bDefense", false);
				DamageManager.DamageManager_0.method_1(this.bhvtaskManager_0.m_entity);
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0005E618 File Offset: 0x0005C818
		public override void vmethod_3(bool bool_1)
		{
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bDefense", false);
			DamageManager.DamageManager_0.method_1(this.bhvtaskManager_0.m_entity);
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_13(ENPCParticleType.E_DefenseField);
			}
			base.vmethod_3(bool_1);
		}

		// Token: 0x040008A7 RID: 2215
		private BHVTaskParamDefenseField bhvtaskParamDefenseField_0;

		// Token: 0x040008A8 RID: 2216
		private float float_0 = 2.5f;
	}
}
