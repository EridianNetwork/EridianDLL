using System;

namespace BHV
{
	// Token: 0x0200023F RID: 575
	public sealed class BHVTaskParamAttachBomb : BHVTaskParamAnimationState
	{
		// Token: 0x06000BBD RID: 3005 RVA: 0x0000B767 File Offset: 0x00009967
		public BHVTaskParamAttachBomb()
		{
			base.m_Type = BHVTaskType.AttachBomb;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}
	}
}
