using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001EB RID: 491
	public class BHVTaskLavaStrike : BHVTask
	{
		// Token: 0x06000A6D RID: 2669 RVA: 0x0000A4FE File Offset: 0x000086FE
		public BHVTaskLavaStrike()
		{
			base.m_Type = BHVTaskType.LavaStrike;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0000A520 File Offset: 0x00008720
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamLavaStrike_0 = bhvtaskParam_0 as BHVTaskParamLavaStrike;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0000A535 File Offset: 0x00008735
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamLavaStrike_0;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00062F34 File Offset: 0x00061134
		public override void Start()
		{
			base.Start();
			this.animationLavaStrikeState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("LavaStrike") as AnimationLavaStrikeState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.LavaStrike);
			this.bool_1 = false;
			if (!this.curve_0.method_8(this.bhvtaskManager_0.m_entity.transform.position, this.bhvtaskParamLavaStrike_0.vector3_0, 1f))
			{
				base.m_Status = BHVTaskStatus.FAILED;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.m_validateNextMovePosition = false;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00062FCC File Offset: 0x000611CC
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status != BHVTaskStatus.FAILED)
			{
				if (base.m_Status != BHVTaskStatus.SUCCESS)
				{
					if (!this.bool_1 && this.animationLavaStrikeState_0.m_bJumpLoop)
					{
						Vector3 vector;
						this.bool_1 = this.curve_0.Update(deltaTime, 12f, out vector);
						this.bhvtaskManager_0.transform.position = vector;
						if (this.bool_1)
						{
							this.animationLavaStrikeState_0.OnLanded();
						}
					}
					else if (this.animationLavaStrikeState_0.m_bLavaStrikeEnd)
					{
						base.m_Status = BHVTaskStatus.SUCCESS;
					}
					return;
				}
			}
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0000A53D File Offset: 0x0000873D
		public override void vmethod_3(bool bool_2)
		{
			this.bhvtaskManager_0.m_entity.vmethod_49();
			base.vmethod_3(bool_2);
		}

		// Token: 0x0400098A RID: 2442
		private BHVTaskParamLavaStrike bhvtaskParamLavaStrike_0;

		// Token: 0x0400098B RID: 2443
		private AnimationLavaStrikeState animationLavaStrikeState_0;

		// Token: 0x0400098C RID: 2444
		private AIServiceCurve.Curve curve_0 = new AIServiceCurve.Curve();

		// Token: 0x0400098D RID: 2445
		private bool bool_1;
	}
}
