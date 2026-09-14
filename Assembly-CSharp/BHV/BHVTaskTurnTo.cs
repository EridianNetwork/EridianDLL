using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200019E RID: 414
	public class BHVTaskTurnTo : BHVTask
	{
		// Token: 0x06000928 RID: 2344 RVA: 0x000092E5 File Offset: 0x000074E5
		public BHVTaskTurnTo()
		{
			base.m_Type = BHVTaskType.TurnTo;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x000092FB File Offset: 0x000074FB
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamTurnTo_0 = bhvtaskParam_0 as BHVTaskParamTurnTo;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00009310 File Offset: 0x00007510
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamTurnTo_0;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00009318 File Offset: 0x00007518
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.TurnTo);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0005D550 File Offset: 0x0005B750
		public override void Update(float deltaTime)
		{
			Vector3 vector;
			if (this.bhvtaskParamTurnTo_0.gameObject_0 != null)
			{
				vector = (this.bhvtaskParamTurnTo_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			}
			else
			{
				vector = (this.bhvtaskParamTurnTo_0.vector3_0 - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			}
			vector.y = 0f;
			float num = Vector3.Angle(vector, this.bhvtaskManager_0.m_entity.transform.forward);
			if (num < 5f)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, vector, deltaTime * 15f);
		}

		// Token: 0x04000865 RID: 2149
		private BHVTaskParamTurnTo bhvtaskParamTurnTo_0;
	}
}
