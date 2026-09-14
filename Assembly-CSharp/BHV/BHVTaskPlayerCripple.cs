using System;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000230 RID: 560
	public class BHVTaskPlayerCripple : BHVTask
	{
		// Token: 0x06000B82 RID: 2946 RVA: 0x0000B4E5 File Offset: 0x000096E5
		public BHVTaskPlayerCripple()
		{
			base.m_Type = BHVTaskType.PlayerCripple;
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0000B4F5 File Offset: 0x000096F5
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerCripple_0 = bhvtaskParam_0 as BHVTaskParamPlayerCripple;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0000B50A File Offset: 0x0000970A
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerCripple_0;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x000666C4 File Offset: 0x000648C4
		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			this.entityPlayer_0 = this.bhvtaskManager_0.m_entity as EntityPlayer;
			this.equipmentInventoryEntityPlayer_0 = this.entityPlayer_0.vmethod_19() as EquipmentInventoryEntityPlayer;
			int num = this.equipmentInventoryEntityPlayer_0.method_4() - 1;
			this.equipmentInventoryEntityPlayer_0.method_6(num);
			this.equipmentInventoryEntityPlayer_0.method_10(0);
			if (this.entityPlayer_0.BHVSecondWindManager_0 != null)
			{
				this.entityPlayer_0.BHVSecondWindManager_0.method_3();
			}
			this.entityPlayer_0.OnEnterPlayerCripple();
			if (this.entityPlayer_0.vmethod_26() && MonoSingleton<InputManager>.Instance)
			{
				this.playerController_0 = this.bhvtaskManager_0.GetComponent<PlayerController>();
				if (!(this.playerController_0 != null))
				{
				}
			}
			this.float_0 = this.bhvtaskParamPlayerCripple_0.float_0;
			PlayerAnimationManagerFSM playerAnimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as PlayerAnimationManagerFSM;
			if (playerAnimationManagerFSM != null)
			{
				playerAnimationManagerFSM.method_22(PlayerAnimationManagerFSM.ESecondWindMode.Crippled);
				playerAnimationManagerFSM.method_21();
			}
			this.bool_1 = false;
			if (this.entityPlayer_0 != null && this.entityPlayer_0.vmethod_26())
			{
				this.bool_1 = true;
				this.secondWindState_0 = default(SecondWindState);
				MonoSingleton<AppManager>.Instance.method_0().imethod_0("UI_HUD_NearDeath_Cripple_BloodGauge_Display");
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>().Boolean_1 = true;
				if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_18() != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_18().method_6(true);
				}
			}
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00066854 File Offset: 0x00064A54
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!(this.equipmentInventoryEntityPlayer_0 == null) && !(this.entityPlayer_0 == null))
			{
				int num = this.equipmentInventoryEntityPlayer_0.method_7();
				int num2 = this.equipmentInventoryEntityPlayer_0.method_3();
				if (this.entityPlayer_0.BHVSecondWindManager_0.method_4())
				{
					int num3 = this.entityPlayer_0.BHVSecondWindManager_0.method_2();
					int num4 = num + (int)((float)num3 * Time.deltaTime);
					if (num4 != num)
					{
						this.equipmentInventoryEntityPlayer_0.method_10(num4);
					}
				}
				else
				{
					this.equipmentInventoryEntityPlayer_0.method_10(0);
					float num5 = this.entityPlayer_0.BHVSecondWindManager_0.method_0();
					int num6 = num2 - (int)(num5 * Time.deltaTime);
					if (num6 != num2)
					{
						this.equipmentInventoryEntityPlayer_0.method_6(num6);
					}
				}
				if (this.bool_1)
				{
					this.secondWindState_0.inRevived = this.entityPlayer_0.method_149();
					this.secondWindState_0.bleedPercent = (float)this.equipmentInventoryEntityPlayer_0.method_3() / (float)this.equipmentInventoryEntityPlayer_0.method_4();
					this.secondWindState_0.revivedPercent = (float)this.equipmentInventoryEntityPlayer_0.method_7() / (float)this.equipmentInventoryEntityPlayer_0.method_8();
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>().vmethod_5(ref this.secondWindState_0);
					if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_18() != null)
					{
						MonoSingleton<GraphicsMgr>.Instance.method_18().method_7(0.4f - 0.4f * this.secondWindState_0.bleedPercent);
					}
				}
				if (this.entityPlayer_0 != null && !this.entityPlayer_0.vmethod_26() && MonoSingleton<GraphicsMgr>.Instance != null && this.equipmentInventoryEntityPlayer_0 != null)
				{
					float num7 = (float)this.equipmentInventoryEntityPlayer_0.method_3() / (float)this.equipmentInventoryEntityPlayer_0.method_4();
					MonoSingleton<GraphicsMgr>.Instance.method_21().method_30(this.entityPlayer_0.method_115(), num7);
				}
				this.float_0 -= deltaTime;
				if (this.float_0 > 0f)
				{
				}
				return;
			}
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0000B512 File Offset: 0x00009712
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			if (this.bool_1)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>().Boolean_1 = false;
			}
			if (!(this.playerController_0 != null))
			{
			}
		}

		// Token: 0x04000A63 RID: 2659
		private BHVTaskParamPlayerCripple bhvtaskParamPlayerCripple_0;

		// Token: 0x04000A64 RID: 2660
		private EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer_0;

		// Token: 0x04000A65 RID: 2661
		public float float_0;

		// Token: 0x04000A66 RID: 2662
		private PlayerController playerController_0;

		// Token: 0x04000A67 RID: 2663
		private SecondWindState secondWindState_0;

		// Token: 0x04000A68 RID: 2664
		private EntityPlayer entityPlayer_0;

		// Token: 0x04000A69 RID: 2665
		private bool bool_1;
	}
}
