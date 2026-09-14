using System;
using System.Text;
using Core;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001CE RID: 462
	public class BHVTaskFireFullBody : BHVTask
	{
		// Token: 0x060009EB RID: 2539 RVA: 0x00009E09 File Offset: 0x00008009
		public BHVTaskFireFullBody()
		{
			base.m_Type = BHVTaskType.FireFullBody;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x00009E32 File Offset: 0x00008032
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamFireFullBody_0 = bhvtaskParam_0 as BHVTaskParamFireFullBody;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x00009E47 File Offset: 0x00008047
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamFireFullBody_0;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x000608E4 File Offset: 0x0005EAE4
		public override void Start()
		{
			base.Start();
			this.float_1 = Time.time;
			this.int_0 = this.bhvtaskParamFireFullBody_0.int_3;
			this.fireState_0 = BHVTaskFireFullBody.FireState.const_1;
			this.float_0 = 0f;
			this.bool_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = true;
			this.animationFireFullBodyState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.FireFullBody)) as AnimationFireFullBodyState;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x00009E4F File Offset: 0x0000804F
		public bool method_0()
		{
			return this.bhvtaskParamFireFullBody_0 != null && (!(this.bhvtaskParamFireFullBody_0.gameObject_0 == null) || this.bhvtaskParamFireFullBody_0.vector3_0.smethod_1());
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00060960 File Offset: 0x0005EB60
		public Vector3 method_1()
		{
			if (this.bhvtaskParamFireFullBody_0.gameObject_0 != null)
			{
				Entity component = this.bhvtaskParamFireFullBody_0.gameObject_0.GetComponent<Entity>();
				global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, component.vmethod_23(), Color.yellow);
				return component.vmethod_23();
			}
			global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, this.bhvtaskParamFireFullBody_0.vector3_0, Color.red);
			return this.bhvtaskParamFireFullBody_0.vector3_0;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x000609E8 File Offset: 0x0005EBE8
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.bhvtaskManager_0.m_entity.vmethod_49();
			if (!this.method_0())
			{
				DebugUtils.LogError(LogCategory.AI, "FireState NO valid tareget: " + Time.time);
				this.fireState_0 = BHVTaskFireFullBody.FireState.const_3;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			if (this.aiinventory_0 == null)
			{
				this.aiinventory_0 = this.bhvtaskManager_0.m_entity.vmethod_10();
			}
			BHVTaskFireFullBody.FireState fireState = this.fireState_0;
			switch (fireState + 1)
			{
			case BHVTaskFireFullBody.FireState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskFireFullBody.FireState.const_2:
			{
				if (this.bhvtaskParamFireFullBody_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamFireFullBody_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamFireFullBody_0.gameObject_0);
				}
				float num = this.bhvtaskManager_0.method_18(this.bhvtaskParamFireFullBody_0.bhvfireStyle_0);
				float num2 = this.bhvtaskManager_0.method_17(this.bhvtaskParamFireFullBody_0.bhvfireStyle_0);
				if (this.animationFireFullBodyState_0 != null)
				{
					this.animationFireFullBodyState_0.Single_0 = num;
					this.animationFireFullBodyState_0.Single_1 = num2;
					this.animationFireFullBodyState_0.m_stance = this.bhvtaskParamFireFullBody_0.bhvstance_0;
					this.animationFireFullBodyState_0.m_fallBackAfterShot = this.bhvtaskParamFireFullBody_0.bool_1;
				}
				this.bhvtaskManager_0.m_animationManagerFSM.Boolean_0 = true;
				if (this.bhvtaskManager_0.method_15())
				{
					this.float_0 = BHVTaskUtils.smethod_1(this.method_1(), this.bhvtaskManager_0.m_entity);
					BHVTaskUtils.smethod_3(this.float_0, this.bhvtaskManager_0.m_entity, this.method_1(), ref this.bool_1);
				}
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.FireFullBody);
				this.bhvtaskFirePatternManager_0.Start(num, num2, this.aiinventory_0);
				base.m_Status = BHVTaskStatus.RUNNING;
				this.fireState_0 = BHVTaskFireFullBody.FireState.const_2;
				return;
			}
			case BHVTaskFireFullBody.FireState.const_3:
			{
				if (this.bhvtaskParamFireFullBody_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamFireFullBody_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamFireFullBody_0.gameObject_0);
				}
				if (this.bhvtaskManager_0.method_15())
				{
					this.float_0 = BHVTaskUtils.smethod_1(this.method_1(), this.bhvtaskManager_0.m_entity);
					BHVTaskUtils.smethod_3(this.float_0, this.bhvtaskManager_0.m_entity, this.method_1(), ref this.bool_1);
				}
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.FireFullBody);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.fireState_0 = BHVTaskFireFullBody.FireState.const_3;
					break;
				case AnimationStatus.SUCCESS:
					base.m_Status = BHVTaskStatus.RUNNING;
					if (this.entityWeapon_0 == null)
					{
						this.entityWeapon_0 = this.bhvtaskManager_0.m_entity.vmethod_16();
					}
					if (this.entityWeapon_0 != null)
					{
						if (this.entityWeapon_0.method_23())
						{
							this.bhvtaskFirePatternManager_0.Update(deltaTime, this.aiinventory_0, this.aiinventory_0.method_5(), this.method_1());
						}
						else if (this.animationFireFullBodyState_0 != null && this.animationFireFullBodyState_0.m_shotPending)
						{
							this.bhvtaskFirePatternManager_0.method_0(this.aiinventory_0, this.aiinventory_0.method_5(), this.method_1());
							this.animationFireFullBodyState_0.m_shotPending = false;
						}
					}
					break;
				case AnimationStatus.PREPARE:
					this.int_0--;
					if (this.int_0 <= 0)
					{
						this.fireState_0 = BHVTaskFireFullBody.FireState.const_3;
						base.m_Status = BHVTaskStatus.SUCCESS;
					}
					else
					{
						this.fireState_0 = BHVTaskFireFullBody.FireState.const_1;
					}
					break;
				case (AnimationStatus)4:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				}
				return;
			}
			case (BHVTaskFireFullBody.FireState)3:
				this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00060DE0 File Offset: 0x0005EFE0
		public override void vmethod_3(bool bool_2)
		{
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
			base.vmethod_3(bool_2);
			string text = "Terminate taskFire: " + Time.time;
			if (Time.time - this.float_1 < 1.5f)
			{
				text = text + ">>>>> duration: " + (Time.time - this.float_1);
			}
			if (!bool_2)
			{
			}
			this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
			this.animationFireFullBodyState_0.vmethod_2();
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00060E70 File Offset: 0x0005F070
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (this.bhvtaskParamFireFullBody_0 != null)
			{
				EntityWeapon entityWeapon = this.bhvtaskManager_0.m_entity.vmethod_16();
				if (entityWeapon)
				{
					stringBuilder.Append(string.Format("        State:{0} - FireStyle:{1} - Loop:{2} - Ammo:{3} - Yaw:{4:0.00}\n", new object[]
					{
						this.fireState_0,
						this.bhvtaskParamFireFullBody_0.bhvfireStyle_0,
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
						this.bhvtaskParamFireFullBody_0.bhvfireStyle_0,
						this.int_0,
						this.float_0
					}));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000913 RID: 2323
		private BHVTaskParamFireFullBody bhvtaskParamFireFullBody_0;

		// Token: 0x04000914 RID: 2324
		private BHVTaskFireFullBody.FireState fireState_0 = BHVTaskFireFullBody.FireState.const_0;

		// Token: 0x04000915 RID: 2325
		private int int_0;

		// Token: 0x04000916 RID: 2326
		private BHVTaskFirePatternManager bhvtaskFirePatternManager_0 = new BHVTaskFirePatternManager();

		// Token: 0x04000917 RID: 2327
		private float float_0;

		// Token: 0x04000918 RID: 2328
		private bool bool_1;

		// Token: 0x04000919 RID: 2329
		private float float_1;

		// Token: 0x0400091A RID: 2330
		private AnimationFireFullBodyState animationFireFullBodyState_0;

		// Token: 0x0400091B RID: 2331
		private EntityWeapon entityWeapon_0;

		// Token: 0x0400091C RID: 2332
		private AIInventory aiinventory_0;

		// Token: 0x020001CF RID: 463
		private enum FireState
		{
			// Token: 0x0400091E RID: 2334
			const_0 = -1,
			// Token: 0x0400091F RID: 2335
			const_1,
			// Token: 0x04000920 RID: 2336
			const_2,
			// Token: 0x04000921 RID: 2337
			const_3
		}
	}
}
