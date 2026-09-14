using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001A2 RID: 418
	public class BHVTaskWarning : BHVTaskAnimationState
	{
		// Token: 0x06000939 RID: 2361 RVA: 0x000093D5 File Offset: 0x000075D5
		public BHVTaskWarning()
		{
			base.m_Type = BHVTaskType.Warning;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x000093E5 File Offset: 0x000075E5
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamWarning_0 = bhvtaskParam_0 as BHVTaskParamWarning;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x000093FA File Offset: 0x000075FA
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamWarning_0;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00009402 File Offset: 0x00007602
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Warning);
			this.method_1();
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0005D794 File Offset: 0x0005B994
		private void method_1()
		{
			if (this.bhvtaskParamWarning_0.gameObject_0 == null)
			{
				return;
			}
			Vector3 normalized = (this.bhvtaskParamWarning_0.gameObject_0.transform.position - this.bhvtaskManager_0.transform.position).normalized;
			normalized.y = 0f;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		// Token: 0x04000869 RID: 2153
		private BHVTaskParamWarning bhvtaskParamWarning_0;
	}
}
