using System;

namespace BHV
{
	// Token: 0x02000207 RID: 519
	public sealed class BHVTaskParamSideStep : BHVTaskParamAnimationState
	{
		// Token: 0x06000AE4 RID: 2788 RVA: 0x0000ABEC File Offset: 0x00008DEC
		public BHVTaskParamSideStep()
		{
			base.m_Type = BHVTaskType.SideStep;
			this.bool_1 = false;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0000AC03 File Offset: 0x00008E03
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.bool_1 = this.bool_1;
			}
			else
			{
				this.bool_1 = data_0.bool_1;
			}
		}

		// Token: 0x040009E1 RID: 2529
		public bool bool_1;
	}
}
