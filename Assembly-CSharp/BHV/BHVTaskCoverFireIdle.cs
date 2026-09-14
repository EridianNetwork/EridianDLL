using System;
using System.Text;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000222 RID: 546
	public class BHVTaskCoverFireIdle : BHVTask
	{
		// Token: 0x06000B56 RID: 2902 RVA: 0x0000B1B3 File Offset: 0x000093B3
		public BHVTaskCoverFireIdle()
		{
			base.m_Type = BHVTaskType.CoverFireIdle;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0000B1D1 File Offset: 0x000093D1
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCoverFireIdle_0 = bhvtaskParam_0 as BHVTaskParamCoverFireIdle;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0000B1E6 File Offset: 0x000093E6
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCoverFireIdle_0;
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0000B1EE File Offset: 0x000093EE
		public override void Start()
		{
			base.Start();
			this.coverFireIdleState_0 = BHVTaskCoverFireIdle.CoverFireIdleState.const_1;
			this.float_0 = this.bhvtaskParamCoverFireIdle_0.float_0;
			this.bool_1 = false;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0000B215 File Offset: 0x00009415
		public bool method_0()
		{
			return this.bhvtaskParamCoverFireIdle_0 != null && (!(this.bhvtaskParamCoverFireIdle_0.gameObject_0 == null) || this.bhvtaskParamCoverFireIdle_0.vector3_0.smethod_1());
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00066240 File Offset: 0x00064440
		public Vector3 method_1()
		{
			if (this.bhvtaskParamCoverFireIdle_0.gameObject_0 != null)
			{
				Entity component = this.bhvtaskParamCoverFireIdle_0.gameObject_0.GetComponent<Entity>();
				global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, component.vmethod_23(), Color.yellow);
				return component.vmethod_23();
			}
			global::Debug.smethod_4(this.bhvtaskManager_0.transform.position, this.bhvtaskParamCoverFireIdle_0.vector3_0, Color.red);
			return this.bhvtaskParamCoverFireIdle_0.vector3_0;
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x000662C8 File Offset: 0x000644C8
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!this.method_0())
			{
				this.coverFireIdleState_0 = BHVTaskCoverFireIdle.CoverFireIdleState.const_3;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			BHVTaskCoverFireIdle.CoverFireIdleState coverFireIdleState = this.coverFireIdleState_0;
			switch (coverFireIdleState + 1)
			{
			case BHVTaskCoverFireIdle.CoverFireIdleState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskCoverFireIdle.CoverFireIdleState.const_2:
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.CoverIdleBeforeFire);
				base.m_Status = BHVTaskStatus.RUNNING;
				this.coverFireIdleState_0 = BHVTaskCoverFireIdle.CoverFireIdleState.const_2;
				if (this.bhvtaskParamCoverFireIdle_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamCoverFireIdle_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamCoverFireIdle_0.gameObject_0);
				}
				return;
			case BHVTaskCoverFireIdle.CoverFireIdleState.const_3:
			{
				float num = BHVTaskUtils.smethod_1(this.method_1(), this.bhvtaskManager_0.m_entity);
				BHVTaskUtils.smethod_3(num, this.bhvtaskManager_0.m_entity, this.method_1(), ref this.bool_1);
				if (this.bhvtaskParamCoverFireIdle_0.gameObject_0 == null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_0(this.bhvtaskParamCoverFireIdle_0.vector3_0);
				}
				else
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamCoverFireIdle_0.gameObject_0);
				}
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.CoverIdleBeforeFire);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.coverFireIdleState_0 = BHVTaskCoverFireIdle.CoverFireIdleState.const_3;
					break;
				case AnimationStatus.SUCCESS:
					this.float_0 -= deltaTime;
					if (this.float_0 <= 0f)
					{
						this.coverFireIdleState_0 = BHVTaskCoverFireIdle.CoverFireIdleState.const_3;
						base.m_Status = BHVTaskStatus.SUCCESS;
					}
					else
					{
						base.m_Status = BHVTaskStatus.RUNNING;
					}
					break;
				case AnimationStatus.PREPARE:
					this.coverFireIdleState_0 = BHVTaskCoverFireIdle.CoverFireIdleState.const_3;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				return;
			}
			case (BHVTaskCoverFireIdle.CoverFireIdleState)3:
				this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0000B249 File Offset: 0x00009449
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_3();
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x000664B8 File Offset: 0x000646B8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append(string.Format("        State:{0} - Time:{1}\n", this.coverFireIdleState_0, this.float_0));
			return stringBuilder.ToString();
		}

		// Token: 0x04000A46 RID: 2630
		private BHVTaskParamCoverFireIdle bhvtaskParamCoverFireIdle_0;

		// Token: 0x04000A47 RID: 2631
		private BHVTaskCoverFireIdle.CoverFireIdleState coverFireIdleState_0 = BHVTaskCoverFireIdle.CoverFireIdleState.const_0;

		// Token: 0x04000A48 RID: 2632
		private float float_0;

		// Token: 0x04000A49 RID: 2633
		private bool bool_1;

		// Token: 0x02000223 RID: 547
		private enum CoverFireIdleState
		{
			// Token: 0x04000A4B RID: 2635
			const_0 = -1,
			// Token: 0x04000A4C RID: 2636
			const_1,
			// Token: 0x04000A4D RID: 2637
			const_2,
			// Token: 0x04000A4E RID: 2638
			const_3
		}
	}
}
