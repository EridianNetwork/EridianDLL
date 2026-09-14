using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001F2 RID: 498
	public class BHVTaskMortarAttack : BHVTask
	{
		// Token: 0x06000A88 RID: 2696 RVA: 0x0000A69C File Offset: 0x0000889C
		public BHVTaskMortarAttack()
		{
			base.m_Type = BHVTaskType.MortarAttack;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0000A6AC File Offset: 0x000088AC
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamMortarAttack_0 = bhvtaskParam_0 as BHVTaskParamMortarAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0000A6C1 File Offset: 0x000088C1
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamMortarAttack_0;
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x000633B0 File Offset: 0x000615B0
		public override void Start()
		{
			base.Start();
			this.float_0 = 0f;
			this.int_0 = 0;
			this.int_1 = 0;
			this.animationMortarAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("MortarAttack") as AnimationMortarAttackState;
			this.animationMortarAttackState_0.m_attackDuration = 60f;
			this.transform_0 = (this.bhvtaskManager_0.m_entity as EntityNpcKnoxx).m_lunchPointLeft;
			this.transform_1 = (this.bhvtaskManager_0.m_entity as EntityNpcKnoxx).m_lunchPointRight;
			MonoSingleton<Session>.Instance.method_38(out this.list_0);
			this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/WPN_Missile");
			this.bhvmortarAttackSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVMortarAttackSettings>();
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.MortarAttack);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0006348C File Offset: 0x0006168C
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (this.int_0 >= this.bhvmortarAttackSettings_0.m_shellAmount)
			{
				this.animationMortarAttackState_0.m_attackDuration = 0f;
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
			this.float_0 += deltaTime;
			if (this.float_0 > 0.5f)
			{
				this.float_0 -= 0.5f;
				this.method_0();
			}
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00063504 File Offset: 0x00061704
		private void method_0()
		{
			if (this.object_0 == null)
			{
				return;
			}
			int count = this.list_0.Count;
			for (int i = 0; i < count; i++)
			{
				PlayerInfoSync playerInfoSync = this.list_0[i];
				if (!(playerInfoSync == null))
				{
					EntityPlayer entityPlayer = playerInfoSync.GetEntity() as EntityPlayer;
					if (!(entityPlayer == null))
					{
						Vector3 vector = ((this.int_1 % 2 != 0) ? this.transform_1.position : this.transform_0.position);
						GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0, vector, Quaternion.identity);
						if (gameObject != null)
						{
							KnoxxMissile component = gameObject.GetComponent<KnoxxMissile>();
							component.m_BHVTaskManager = this.bhvtaskManager_0;
							component.method_10(entityPlayer);
						}
						this.int_1++;
					}
				}
			}
			this.int_0++;
		}

		// Token: 0x0400099C RID: 2460
		private BHVTaskParamMortarAttack bhvtaskParamMortarAttack_0;

		// Token: 0x0400099D RID: 2461
		private AnimationMortarAttackState animationMortarAttackState_0;

		// Token: 0x0400099E RID: 2462
		private BHVMortarAttackSettings bhvmortarAttackSettings_0;

		// Token: 0x0400099F RID: 2463
		private Transform transform_0;

		// Token: 0x040009A0 RID: 2464
		private Transform transform_1;

		// Token: 0x040009A1 RID: 2465
		private List<PlayerInfoSync> list_0;

		// Token: 0x040009A2 RID: 2466
		private global::UnityEngine.Object object_0;

		// Token: 0x040009A3 RID: 2467
		private float float_0;

		// Token: 0x040009A4 RID: 2468
		private int int_0;

		// Token: 0x040009A5 RID: 2469
		private int int_1;
	}
}
