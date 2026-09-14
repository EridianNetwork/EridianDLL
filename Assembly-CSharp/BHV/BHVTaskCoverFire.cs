using System;
using System.Text;
using UnityEngine;
using XsdSettings;

namespace BHV
{
	// Token: 0x0200021F RID: 543
	public class BHVTaskCoverFire : BHVTask
	{
		// Token: 0x06000B49 RID: 2889 RVA: 0x0000B0F2 File Offset: 0x000092F2
		public BHVTaskCoverFire()
		{
			base.m_Type = BHVTaskType.CoverFire;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0000B11B File Offset: 0x0000931B
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCoverFire_0 = bhvtaskParam_0 as BHVTaskParamCoverFire;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x0000B130 File Offset: 0x00009330
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCoverFire_0;
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00065C88 File Offset: 0x00063E88
		public override void Start()
		{
			base.Start();
			this.int_0 = this.bhvtaskParamCoverFire_0.int_3;
			this.coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_1;
			this.float_0 = 0f;
			this.bool_1 = false;
			this.animationCoverFireState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.CoverFire)) as AnimationCoverFireState;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0000B138 File Offset: 0x00009338
		public bool method_0()
		{
			return this.bhvtaskParamCoverFire_0 != null && (!(this.bhvtaskParamCoverFire_0.gameObject_0 == null) || this.bhvtaskParamCoverFire_0.vector3_0.smethod_1());
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x00065CE8 File Offset: 0x00063EE8
		public Vector3 method_1()
		{
			if (this.bhvtaskParamCoverFire_0.gameObject_0 != null)
			{
				Entity component = this.bhvtaskParamCoverFire_0.gameObject_0.GetComponent<Entity>();
				global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, component.vmethod_23(), Color.yellow);
				return component.vmethod_23();
			}
			global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, this.bhvtaskParamCoverFire_0.vector3_0, Color.red);
			return this.bhvtaskParamCoverFire_0.vector3_0;
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x00065D70 File Offset: 0x00063F70
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS || base.m_Status == BHVTaskStatus.FAILED)
			{
				return;
			}
			base.Update(deltaTime);
			if (!this.method_0())
			{
				this.coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_3;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			BHVTaskCoverFire.CoverFireState coverFireState = this.coverFireState_0;
			switch (coverFireState + 1)
			{
			case BHVTaskCoverFire.CoverFireState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskCoverFire.CoverFireState.const_2:
			{
				if (this.bhvtaskParamCoverFire_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamCoverFire_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamCoverFire_0.gameObject_0);
				}
				float num = this.bhvtaskManager_0.method_18(this.bhvtaskParamCoverFire_0.bhvfireStyle_0);
				float num2 = this.bhvtaskManager_0.method_17(this.bhvtaskParamCoverFire_0.bhvfireStyle_0);
				if (this.animationCoverFireState_0 != null)
				{
					this.animationCoverFireState_0.Single_0 = num;
					this.animationCoverFireState_0.Single_1 = num2;
				}
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.CoverFire);
				this.bhvtaskFirePatternManager_0.Start(num, num2, this.bhvtaskManager_0.m_entity.vmethod_10());
				base.m_Status = BHVTaskStatus.RUNNING;
				this.coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_2;
				return;
			}
			case BHVTaskCoverFire.CoverFireState.const_3:
			{
				if (this.bhvtaskParamCoverFire_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamCoverFire_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamCoverFire_0.gameObject_0);
				}
				this.float_0 = BHVTaskUtils.smethod_1(this.method_1(), this.bhvtaskManager_0.m_entity);
				BHVTaskUtils.smethod_3(this.float_0, this.bhvtaskManager_0.m_entity, this.method_1(), ref this.bool_1);
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.CoverFire);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_3;
					break;
				case AnimationStatus.SUCCESS:
					base.m_Status = BHVTaskStatus.RUNNING;
					if (this.bhvtaskFirePatternManager_0.Update(deltaTime, this.bhvtaskManager_0.m_entity.vmethod_10(), this.bhvtaskManager_0.m_entity.vmethod_10().method_5(), this.method_1()))
					{
						EntityWeapon entityWeapon = this.bhvtaskManager_0.m_entity.vmethod_16();
						if (entityWeapon != null && entityWeapon.method_99() == WeaponType.SniperRifle)
						{
							base.m_Status = BHVTaskStatus.SUCCESS;
							this.coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_3;
							if (this.animationCoverFireState_0 != null)
							{
								this.animationCoverFireState_0.vmethod_2();
							}
						}
					}
					break;
				case AnimationStatus.PREPARE:
					this.int_0--;
					if (this.int_0 <= 0)
					{
						this.coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_3;
						base.m_Status = BHVTaskStatus.SUCCESS;
					}
					else
					{
						this.coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_1;
					}
					break;
				}
				return;
			}
			case (BHVTaskCoverFire.CoverFireState)3:
				this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0000B16C File Offset: 0x0000936C
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			if (!bool_2)
			{
			}
			this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x00066068 File Offset: 0x00064268
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (this.bhvtaskParamCoverFire_0 != null)
			{
				EntityWeapon entityWeapon = this.bhvtaskManager_0.m_entity.vmethod_16();
				if (entityWeapon)
				{
					stringBuilder.Append(string.Format("        State:{0} - FireStyle:{1} - Loop:{2} - Ammo:{3} - Yaw:{4:0.00}\n", new object[]
					{
						this.coverFireState_0,
						this.bhvtaskParamCoverFire_0.bhvfireStyle_0,
						this.int_0,
						entityWeapon.m_ammoCount,
						this.float_0
					}));
				}
				else
				{
					stringBuilder.Append(string.Format("        State:{0} - FireStyle:{1} - Loop:{2} - No Weapon - Yaw:{3:0.00}\n", new object[]
					{
						this.coverFireState_0,
						this.bhvtaskParamCoverFire_0.bhvfireStyle_0,
						this.int_0,
						this.float_0
					}));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000A35 RID: 2613
		private BHVTaskParamCoverFire bhvtaskParamCoverFire_0;

		// Token: 0x04000A36 RID: 2614
		private BHVTaskCoverFire.CoverFireState coverFireState_0 = BHVTaskCoverFire.CoverFireState.const_0;

		// Token: 0x04000A37 RID: 2615
		private int int_0;

		// Token: 0x04000A38 RID: 2616
		private BHVTaskFirePatternManager bhvtaskFirePatternManager_0 = new BHVTaskFirePatternManager();

		// Token: 0x04000A39 RID: 2617
		private float float_0;

		// Token: 0x04000A3A RID: 2618
		private bool bool_1;

		// Token: 0x04000A3B RID: 2619
		private AnimationCoverFireState animationCoverFireState_0;

		// Token: 0x02000220 RID: 544
		private enum CoverFireState
		{
			// Token: 0x04000A3D RID: 2621
			const_0 = -1,
			// Token: 0x04000A3E RID: 2622
			const_1,
			// Token: 0x04000A3F RID: 2623
			const_2,
			// Token: 0x04000A40 RID: 2624
			const_3
		}
	}
}
