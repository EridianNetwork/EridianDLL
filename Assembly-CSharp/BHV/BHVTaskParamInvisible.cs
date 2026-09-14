using System;

namespace BHV
{
	// Token: 0x020001DD RID: 477
	public sealed class BHVTaskParamInvisible : BHVTaskParam
	{
		// Token: 0x06000A38 RID: 2616 RVA: 0x0000A1A7 File Offset: 0x000083A7
		public BHVTaskParamInvisible()
		{
			base.m_Type = BHVTaskType.Invisible;
			base.m_Layer = BHVTaskLayer.EFFECT;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x0000A1C9 File Offset: 0x000083C9
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.float_0 = this.float_0;
			}
			else
			{
				this.float_0 = data_0.float_0;
			}
		}

		// Token: 0x04000967 RID: 2407
		public float float_0 = 1f;
	}
}
