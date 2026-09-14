using System;

namespace BHV
{
	// Token: 0x02000187 RID: 391
	public sealed class BHVTaskParamIdle : BHVTaskParam
	{
		// Token: 0x060008C7 RID: 2247 RVA: 0x00008CA6 File Offset: 0x00006EA6
		public BHVTaskParamIdle()
		{
			base.m_Type = BHVTaskType.Idle;
			this.bhvstance_0 = BHVStance.STAND;
			this.bhvstressLevel_0 = BHVStressLevel.RELAX;
			this.float_0 = -1f;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0005C7C0 File Offset: 0x0005A9C0
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.bhvstance_0 = this.bhvstance_0;
				data_0.float_0 = this.float_0;
				data_0.bhvstressLevel_0 = this.bhvstressLevel_0;
			}
			else
			{
				this.bhvstance_0 = data_0.bhvstance_0;
				this.float_0 = data_0.float_0;
				this.bhvstressLevel_0 = data_0.bhvstressLevel_0;
			}
		}

		// Token: 0x04000828 RID: 2088
		public BHVStance bhvstance_0;

		// Token: 0x04000829 RID: 2089
		public BHVStressLevel bhvstressLevel_0;

		// Token: 0x0400082A RID: 2090
		public float float_0;
	}
}
