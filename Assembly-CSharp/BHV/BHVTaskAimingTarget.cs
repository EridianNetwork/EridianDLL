using System;

namespace BHV
{
	// Token: 0x02000173 RID: 371
	public class BHVTaskAimingTarget : BHVTask
	{
		// Token: 0x06000879 RID: 2169 RVA: 0x00008819 File Offset: 0x00006A19
		public BHVTaskAimingTarget()
		{
			base.m_Type = BHVTaskType.AimingTarget;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00008830 File Offset: 0x00006A30
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamAimingTarget_0 = bhvtaskParam_0 as BHVTaskParamAimingTarget;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00008845 File Offset: 0x00006A45
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamAimingTarget_0;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0005BA24 File Offset: 0x00059C24
		public override void Start()
		{
			base.Start();
			if (this.bhvtaskManager_0.m_animationManagerFSM != null && this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController != null)
			{
				if (this.bhvtaskParamAimingTarget_0.gameObject_0 != null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamAimingTarget_0.gameObject_0);
				}
				this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_1(this.bhvtaskParamAimingTarget_0.gameObject_0 != null);
			}
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0000884D File Offset: 0x00006A4D
		public override void Update(float deltaTime)
		{
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x040007FE RID: 2046
		private BHVTaskParamAimingTarget bhvtaskParamAimingTarget_0;
	}
}
