using System;

namespace BHV
{
	// Token: 0x020001FF RID: 511
	public sealed class BHVTaskParamReload : BHVTaskParamAnimationState
	{
		// Token: 0x06000AC6 RID: 2758 RVA: 0x0000A9F1 File Offset: 0x00008BF1
		public BHVTaskParamReload()
		{
			base.m_Type = BHVTaskType.Reload;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}
	}
}
