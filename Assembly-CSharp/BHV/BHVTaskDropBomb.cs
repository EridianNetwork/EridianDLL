using System;

namespace BHV
{
	// Token: 0x02000242 RID: 578
	public class BHVTaskDropBomb : BHVTaskAnimationState
	{
		// Token: 0x06000BC3 RID: 3011 RVA: 0x0000B7D4 File Offset: 0x000099D4
		public BHVTaskDropBomb()
		{
			base.m_Type = BHVTaskType.DropBomb;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0000B7EB File Offset: 0x000099EB
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDropBomb_0 = bhvtaskParam_0 as BHVTaskParamDropBomb;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x0000B800 File Offset: 0x00009A00
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDropBomb_0;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x000091D6 File Offset: 0x000073D6
		public override void Start()
		{
			base.Start();
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0000B808 File Offset: 0x00009A08
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.DropBomb);
		}

		// Token: 0x04000A8D RID: 2701
		private BHVTaskParamDropBomb bhvtaskParamDropBomb_0;
	}
}
