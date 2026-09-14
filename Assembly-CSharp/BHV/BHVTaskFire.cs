using System;
using System.Text;
using Core;
using UnityEngine;
using XsdSettings;

namespace BHV
{
	// Token: 0x020001CB RID: 459
	public class BHVTaskFire : BHVTask
	{
		// Token: 0x060009DD RID: 2525 RVA: 0x00009D69 File Offset: 0x00007F69
		public BHVTaskFire()
		{
			base.m_Type = BHVTaskType.Fire;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00009D92 File Offset: 0x00007F92
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamFire_0 = bhvtaskParam_0 as BHVTaskParamFire;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00009DA7 File Offset: 0x00007FA7
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamFire_0;
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x000600BC File Offset: 0x0005E2BC
		public override void Start()
		{
			base.Start();
			this.int_0 = this.bhvtaskParamFire_0.int_3;
			this.fireState_0 = BHVTaskFire.FireState.const_1;
			this.float_0 = 0f;
			this.bool_1 = false;
			if (this.bhvtaskManager_0.m_animationManagerFSM == null)
			{
				return;
			}
			this.animationFireState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Fire)) as AnimationFireState;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00009DAF File Offset: 0x00007FAF
		public bool method_0()
		{
			return this.bhvtaskParamFire_0 != null && (!(this.bhvtaskParamFire_0.gameObject_0 == null) || this.bhvtaskParamFire_0.vector3_0.smethod_1());
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00060130 File Offset: 0x0005E330
		public Vector3 method_1()
		{
			if (this.bhvtaskParamFire_0.gameObject_0 != null)
			{
				Entity component = this.bhvtaskParamFire_0.gameObject_0.GetComponent<Entity>();
				global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, component.vmethod_23(), Color.yellow);
				return component.vmethod_23();
			}
			global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, this.bhvtaskParamFire_0.vector3_0, Color.red);
			return this.bhvtaskParamFire_0.vector3_0;
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x000601B8 File Offset: 0x0005E3B8
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.bhvtaskManager_0.m_entity == null)
			{
				DebugUtils.LogError(LogCategory.AI, "m_BHVTaskManager.m_entity is null");
				return;
			}
			if (this.bhvtaskManager_0.m_entity.vmethod_10() == null)
			{
				DebugUtils.LogError(LogCategory.AI, "m_BHVTaskManager.m_entity.GetAIInventory() is null");
				return;
			}
			if (this.bhvtaskManager_0.m_animationManagerFSM == null)
			{
				DebugUtils.LogError(LogCategory.AI, "mm_BHVTaskManager.m_animationManagerFSM is null");
				return;
			}
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController == null)
			{
				DebugUtils.LogError(LogCategory.AI, "m_BHVTaskManager.m_animationManagerFSM.m_animationEventController is null");
				return;
			}
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (!this.method_0())
			{
				this.fireState_0 = BHVTaskFire.FireState.const_3;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			BHVTaskFire.FireState fireState = this.fireState_0;
			switch (fireState + 1)
			{
			case BHVTaskFire.FireState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskFire.FireState.const_2:
			{
				if (this.bhvtaskParamFire_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamFire_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamFire_0.gameObject_0);
				}
				float num = this.bhvtaskManager_0.method_18(this.bhvtaskParamFire_0.bhvfireStyle_0);
				float num2 = this.bhvtaskManager_0.method_17(this.bhvtaskParamFire_0.bhvfireStyle_0);
				if (this.animationFireState_0 != null)
				{
					this.animationFireState_0.Single_0 = num;
					this.animationFireState_0.Single_1 = num2;
					this.animationFireState_0.m_stance = this.bhvtaskParamFire_0.bhvstance_0;
				}
				this.bhvtaskManager_0.m_animationManagerFSM.Boolean_0 = true;
				if (this.bhvtaskManager_0.method_15())
				{
					this.float_0 = BHVTaskUtils.smethod_1(this.method_1(), this.bhvtaskManager_0.m_entity);
					BHVTaskUtils.smethod_3(this.float_0, this.bhvtaskManager_0.m_entity, this.method_1(), ref this.bool_1);
				}
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Fire);
				this.bhvtaskFirePatternManager_0.Start(num, num2, this.bhvtaskManager_0.m_entity.vmethod_10());
				base.m_Status = BHVTaskStatus.RUNNING;
				this.fireState_0 = BHVTaskFire.FireState.const_2;
				return;
			}
			case BHVTaskFire.FireState.const_3:
			{
				if (this.bhvtaskParamFire_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamFire_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamFire_0.gameObject_0);
				}
				if (this.bhvtaskManager_0.method_15())
				{
					this.float_0 = BHVTaskUtils.smethod_1(this.method_1(), this.bhvtaskManager_0.m_entity);
					BHVTaskUtils.smethod_3(this.float_0, this.bhvtaskManager_0.m_entity, this.method_1(), ref this.bool_1);
				}
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.Fire);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.fireState_0 = BHVTaskFire.FireState.const_3;
					break;
				case AnimationStatus.SUCCESS:
					base.m_Status = BHVTaskStatus.RUNNING;
					if (this.bhvtaskFirePatternManager_0.Update(deltaTime, this.bhvtaskManager_0.m_entity.vmethod_10(), this.bhvtaskManager_0.m_entity.vmethod_10().method_5(), this.method_1()))
					{
						EntityWeapon entityWeapon = this.bhvtaskManager_0.m_entity.vmethod_16();
						if (entityWeapon != null && entityWeapon.method_99() == WeaponType.SniperRifle)
						{
							base.m_Status = BHVTaskStatus.SUCCESS;
							this.fireState_0 = BHVTaskFire.FireState.const_3;
							if (this.animationFireState_0 != null)
							{
								this.animationFireState_0.vmethod_2();
							}
						}
					}
					break;
				case AnimationStatus.PREPARE:
					this.int_0--;
					if (this.int_0 <= 0)
					{
						this.fireState_0 = BHVTaskFire.FireState.const_3;
						base.m_Status = BHVTaskStatus.SUCCESS;
					}
					else
					{
						this.fireState_0 = BHVTaskFire.FireState.const_1;
					}
					break;
				case (AnimationStatus)4:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				}
				return;
			}
			case (BHVTaskFire.FireState)3:
				this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x000605B4 File Offset: 0x0005E7B4
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			if (this.bhvtaskManager_0.m_animationManagerFSM != null && this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
			}
			if (this.animationFireState_0 != null)
			{
				this.animationFireState_0.vmethod_2();
			}
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x00060620 File Offset: 0x0005E820
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (this.bhvtaskParamFire_0 != null)
			{
				EntityWeapon entityWeapon = this.bhvtaskManager_0.m_entity.vmethod_16();
				if (entityWeapon)
				{
					stringBuilder.Append(string.Format("        State:{0} - FireStyle:{1} - Loop:{2} - Ammo:{3} - Yaw:{4:0.00}\n", new object[]
					{
						this.fireState_0,
						this.bhvtaskParamFire_0.bhvfireStyle_0,
						this.int_0,
						entityWeapon.m_ammoCount,
						this.float_0
					}));
				}
				else
				{
					stringBuilder.Append(string.Format("        State:{0} - FireStyle:{1} - Loop:{2} - No Weapon - Yaw:{3:0.00}\n", new object[]
					{
						this.fireState_0,
						this.bhvtaskParamFire_0.bhvfireStyle_0,
						this.int_0,
						this.float_0
					}));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040008FF RID: 2303
		private BHVTaskParamFire bhvtaskParamFire_0;

		// Token: 0x04000900 RID: 2304
		private BHVTaskFire.FireState fireState_0 = BHVTaskFire.FireState.const_0;

		// Token: 0x04000901 RID: 2305
		private int int_0;

		// Token: 0x04000902 RID: 2306
		private BHVTaskFirePatternManager bhvtaskFirePatternManager_0 = new BHVTaskFirePatternManager();

		// Token: 0x04000903 RID: 2307
		private float float_0;

		// Token: 0x04000904 RID: 2308
		private bool bool_1;

		// Token: 0x04000905 RID: 2309
		private AnimationFireState animationFireState_0;

		// Token: 0x020001CC RID: 460
		private enum FireState
		{
			// Token: 0x04000907 RID: 2311
			const_0 = -1,
			// Token: 0x04000908 RID: 2312
			const_1,
			// Token: 0x04000909 RID: 2313
			const_2,
			// Token: 0x0400090A RID: 2314
			const_3
		}
	}
}
