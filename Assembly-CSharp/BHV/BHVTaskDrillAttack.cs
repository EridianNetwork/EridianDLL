using System;

namespace BHV
{
	// Token: 0x020001BF RID: 447
	public class BHVTaskDrillAttack : BHVTask
	{
		// Token: 0x060009A1 RID: 2465 RVA: 0x00009A92 File Offset: 0x00007C92
		public BHVTaskDrillAttack()
		{
			base.m_Type = BHVTaskType.DrillAttack;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00009AB8 File Offset: 0x00007CB8
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDrillAttack_0 = bhvtaskParam_0 as BHVTaskParamDrillAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x00009ACD File Offset: 0x00007CCD
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDrillAttack_0;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0005E744 File Offset: 0x0005C944
		public override void Start()
		{
			base.Start();
			if (this.bhvtaskDrillAttackSettings_0 == null)
			{
				this.bhvtaskDrillAttackSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVTaskDrillAttackSettings>();
			}
			this.float_0 = this.bhvtaskDrillAttackSettings_0.m_drillDuration;
			this.bool_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetInteger("DrillAttackStep", 1);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("IsAlert", false);
			this.entity_0 = this.bhvtaskParamDrillAttack_0.gameObject_0.GetComponent<Entity>();
			this.float_1 = 1f;
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0005E7E0 File Offset: 0x0005C9E0
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if (this.bool_1)
			{
				this.float_1 -= deltaTime;
				if (this.float_1 < 0f)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetInteger("DrillAttackStep", 2);
					if (this.bhvtaskDrillAttackSettings_0.m_bKnockback && (this.entity_0.transform.position - this.bhvtaskManager_0.transform.position).sqrMagnitude < 4f)
					{
						(this.bhvtaskManager_0.m_entity as EntityNpc).method_20(this.entity_0);
					}
					base.m_Status = BHVTaskStatus.SUCCESS;
				}
				return;
			}
			this.float_0 -= deltaTime;
			if (this.float_0 < 0f)
			{
				this.bool_1 = true;
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00009AD5 File Offset: 0x00007CD5
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetInteger("DrillAttackStep", 2);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x040008AE RID: 2222
		private BHVTaskParamDrillAttack bhvtaskParamDrillAttack_0;

		// Token: 0x040008AF RID: 2223
		private BHVTaskDrillAttackSettings bhvtaskDrillAttackSettings_0;

		// Token: 0x040008B0 RID: 2224
		private float float_0 = 3f;

		// Token: 0x040008B1 RID: 2225
		private float float_1 = 1f;

		// Token: 0x040008B2 RID: 2226
		private bool bool_1;

		// Token: 0x040008B3 RID: 2227
		private Entity entity_0;
	}
}
