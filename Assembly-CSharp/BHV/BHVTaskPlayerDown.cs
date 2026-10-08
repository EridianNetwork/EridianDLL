using System;
using Core;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000234 RID: 564
	public class BHVTaskPlayerDown : BHVTask
	{
		// Token: 0x06000B94 RID: 2964 RVA: 0x0000B595 File Offset: 0x00009795
		public BHVTaskPlayerDown()
		{
			base.m_Type = BHVTaskType.PlayerDown;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0000B5A5 File Offset: 0x000097A5
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerDown_0 = bhvtaskParam_0 as BHVTaskParamPlayerDown;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0000B5BA File Offset: 0x000097BA
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerDown_0;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00066F8C File Offset: 0x0006518C
		private bool method_0()
		{
			if (this.bhvtaskManager_0 == null)
			{
				return false;
			}
			this.entityPlayer_0 = this.bhvtaskManager_0.m_entity as EntityPlayer;
			if (this.entityPlayer_0 == null)
			{
				return false;
			}
			this.equipmentInventoryEntityPlayer_0 = this.bhvtaskManager_0.gameObject.GetComponent<EquipmentInventoryEntityPlayer>();
			if (this.equipmentInventoryEntityPlayer_0 == null)
			{
				return false;
			}
			if (this.bhvtaskParamPlayerDown_0 == null)
			{
				return false;
			}
			PlayerAnimationManagerFSM playerAnimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as PlayerAnimationManagerFSM;
			if (playerAnimationManagerFSM == null)
			{
				return false;
			}
			if (MonoSingleton<AppManager>.Instance == null || MonoSingleton<AppManager>.Instance.method_0() == null)
			{
				return false;
			}
			this.secondWindView_0 = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>();
			if (this.secondWindView_0 == null)
			{
				return false;
			}
			if (MonoSingleton<GraphicsMgr>.Instance == null)
			{
				return false;
			}
			this.cameraEffectMgr_0 = MonoSingleton<GraphicsMgr>.Instance.method_18();
			if (this.cameraEffectMgr_0 == null)
			{
				return false;
			}
			this.entityPlayer_0.OnEnterPlayerDown();
			this.float_0 = this.bhvtaskParamPlayerDown_0.float_0;
			this.float_1 = this.bhvtaskParamPlayerDown_0.float_0;
			playerAnimationManagerFSM.method_22(PlayerAnimationManagerFSM.ESecondWindMode.Down);
			this.bool_2 = false;
			if (this.entityPlayer_0.vmethod_26())
			{
				this.bool_2 = true;
				this.secondWindState_0 = default(SecondWindState);
				this.secondWindView_0.Boolean_1 = true;
				this.cameraEffectMgr_0.method_6(true);
				this.cameraEffectMgr_0.method_7(0.4f);
				//this.entityPlayer_0.method_59(true);
			}
			DebugUtils.Log(LogCategory.AI, "BHVtaskPlayerDown InitTask() finished: true");
			return true;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0000B5C2 File Offset: 0x000097C2
		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			this.bool_1 = this.method_0();
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00067128 File Offset: 0x00065328
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!this.bool_1)
			{
				this.bool_1 = this.method_0();
			}
			if (!this.bool_1)
			{
				return;
			}
			int num = this.equipmentInventoryEntityPlayer_0.method_7();
			if (this.entityPlayer_0.BHVSecondWindManager_0 != null && this.entityPlayer_0.BHVSecondWindManager_0.method_4())
			{
				int num2 = this.entityPlayer_0.BHVSecondWindManager_0.method_2();
				int num3 = num + (int)((float)num2 * Time.deltaTime);
				if (num3 != num)
				{
					this.equipmentInventoryEntityPlayer_0.method_10(num3);
				}
			}
			else
			{
				this.equipmentInventoryEntityPlayer_0.method_10(0);
				this.float_0 -= deltaTime;
			}
			if (this.float_0 <= 0f)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				this.float_0 = 0f;
			}
			if (this.bool_2)
			{
				this.secondWindState_0.deathPercent = this.float_0;
				this.secondWindState_0.inRevived = this.entityPlayer_0.method_149();
				this.secondWindState_0.inDeath = !this.secondWindState_0.inRevived;
				this.secondWindState_0.bleedPercent = (float)this.equipmentInventoryEntityPlayer_0.method_3() / (float)this.equipmentInventoryEntityPlayer_0.method_4();
				this.secondWindState_0.revivedPercent = (float)this.equipmentInventoryEntityPlayer_0.method_7() / (float)this.equipmentInventoryEntityPlayer_0.method_8();
				if (this.secondWindView_0 != null)
				{
					this.secondWindView_0.vmethod_5(ref this.secondWindState_0);
				}
				if (this.cameraEffectMgr_0 != null)
				{
					float num4 = 0.7f - 0.3f * this.float_0 / this.float_1;
					this.cameraEffectMgr_0.method_7(num4);
				}
			}
			if (this.entityPlayer_0 != null && !this.entityPlayer_0.vmethod_26())
			{
				float num5 = this.float_0 / this.float_1;
				if (MonoSingleton<GraphicsMgr>.Instance != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_21().method_30(this.entityPlayer_0.method_115(), num5);
				}
			}
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0006731C File Offset: 0x0006551C
		public override void vmethod_3(bool bool_3)
		{
			base.vmethod_3(bool_3);
			if (!(this.playerController_0 != null))
			{
			}
			if (this.bool_2)
			{
				if (this.secondWindView_0 != null)
				{
					this.secondWindView_0.Boolean_1 = false;
				}
				if (this.entityPlayer_0 != null)
				{
					this.entityPlayer_0.method_59(false);
				}
			}
		}

		// Token: 0x04000A77 RID: 2679
		private BHVTaskParamPlayerDown bhvtaskParamPlayerDown_0;

		// Token: 0x04000A78 RID: 2680
		public float float_0;

		// Token: 0x04000A79 RID: 2681
		public float float_1;

		// Token: 0x04000A7A RID: 2682
		private PlayerController playerController_0;

		// Token: 0x04000A7B RID: 2683
		private float float_2;

		// Token: 0x04000A7C RID: 2684
		private SecondWindState secondWindState_0;

		// Token: 0x04000A7D RID: 2685
		private EntityPlayer entityPlayer_0;

		// Token: 0x04000A7E RID: 2686
		private bool bool_1;

		// Token: 0x04000A7F RID: 2687
		private EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer_0;

		// Token: 0x04000A80 RID: 2688
		private SecondWindView secondWindView_0;

		// Token: 0x04000A81 RID: 2689
		private CameraEffectMgr cameraEffectMgr_0;

		// Token: 0x04000A82 RID: 2690
		private bool bool_2;
	}
}
