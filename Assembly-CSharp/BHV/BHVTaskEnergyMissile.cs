using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C5 RID: 453
	public class BHVTaskEnergyMissile : BHVTask
	{
		// Token: 0x060009BB RID: 2491 RVA: 0x00009C1C File Offset: 0x00007E1C
		public BHVTaskEnergyMissile()
		{
			base.m_Type = BHVTaskType.EnergyMissile;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00009C56 File Offset: 0x00007E56
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamEnergyMissile_0 = bhvtaskParam_0 as BHVTaskParamEnergyMissile;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00009C6B File Offset: 0x00007E6B
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamEnergyMissile_0;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0005F11C File Offset: 0x0005D31C
		public override void Start()
		{
			base.Start();
			this.float_0 = 4f;
			this.float_1 = 0f;
			MonoSingleton<Session>.Instance.method_38(out this.list_0);
			this.int_1 = this.list_0.Count;
			this.int_2 = this.bhvtaskParamEnergyMissile_0.int_3;
			this.int_0 = this.bhvtaskParamEnergyMissile_0.int_4;
			this.bool_1 = false;
			this.float_2 = 4f;
			if (this.object_0 == null)
			{
				this.object_0 = (this.bhvtaskManager_0.m_entity as EntityNpc).m_spawnObjPrefabList[1];
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEnergyMissile", true);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0005F1E0 File Offset: 0x0005D3E0
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 -= deltaTime;
			if (this.float_0 > 0f)
			{
				return;
			}
			if (this.bool_1)
			{
				this.float_2 -= Time.deltaTime;
				if (this.float_2 < 0f)
				{
					base.m_Status = BHVTaskStatus.SUCCESS;
				}
				return;
			}
			base.Update(deltaTime);
			this.float_1 -= Time.deltaTime;
			if (this.float_1 > 0f)
			{
				return;
			}
			this.int_1 = this.list_0.Count;
			for (int i = 0; i < this.int_1; i++)
			{
				PlayerInfoSync playerInfoSync = this.list_0[i];
				if (!(playerInfoSync == null))
				{
					int num = this.int_3[this.int_0];
					Transform transform = (this.bhvtaskManager_0.m_animationManagerFSM as ArchAngelAnimationManagerFSM).m_missileLunchPoints[num];
					this.int_0++;
					if (this.int_0 >= 12)
					{
						this.int_0 = 0;
					}
					this.method_0(transform, playerInfoSync);
				}
			}
			this.float_1 = this.bhvtaskParamEnergyMissile_0.float_1;
			this.int_2--;
			if (this.int_2 <= 0)
			{
				this.bool_1 = true;
			}
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x00009C73 File Offset: 0x00007E73
		public override void vmethod_3(bool bool_2)
		{
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEnergyMissile", false);
			base.vmethod_3(bool_2);
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0005F320 File Offset: 0x0005D520
		private void method_0(Transform transform_0, PlayerInfoSync playerInfoSync_0)
		{
			EntityPlayer entityPlayer = playerInfoSync_0.GetEntity() as EntityPlayer;
			if (entityPlayer == null)
			{
				return;
			}
			if (this.object_0 != null)
			{
				GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0, transform_0.position, Quaternion.identity);
				if (gameObject != null)
				{
					EnergyMissile component = gameObject.GetComponent<EnergyMissile>();
					if (component != null)
					{
						component.method_0(this.bhvtaskManager_0, entityPlayer, this.bhvtaskParamEnergyMissile_0.float_0);
					}
				}
			}
		}

		// Token: 0x040008CB RID: 2251
		private BHVTaskParamEnergyMissile bhvtaskParamEnergyMissile_0;

		// Token: 0x040008CC RID: 2252
		private float float_0;

		// Token: 0x040008CD RID: 2253
		private float float_1;

		// Token: 0x040008CE RID: 2254
		private float float_2 = 4f;

		// Token: 0x040008CF RID: 2255
		private int int_0;

		// Token: 0x040008D0 RID: 2256
		private int int_1 = 1;

		// Token: 0x040008D1 RID: 2257
		private int int_2;

		// Token: 0x040008D2 RID: 2258
		private bool bool_1;

		// Token: 0x040008D3 RID: 2259
		private List<PlayerInfoSync> list_0;

		// Token: 0x040008D4 RID: 2260
		private int[] int_3 = new int[]
		{
			2, 5, 1, 4, 0, 3, 1, 4, 0, 2,
			5, 3
		};

		// Token: 0x040008D5 RID: 2261
		private global::UnityEngine.Object object_0;
	}
}
