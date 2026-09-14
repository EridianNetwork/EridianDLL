using System;

namespace BHV
{
	// Token: 0x02000241 RID: 577
	public sealed class BHVTaskParamDropBomb : BHVTaskParamAnimationState
	{
		// Token: 0x06000BC2 RID: 3010 RVA: 0x0000B7BD File Offset: 0x000099BD
		public BHVTaskParamDropBomb()
		{
			base.m_Type = BHVTaskType.DropBomb;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}
	}
}
