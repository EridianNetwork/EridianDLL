using System;

namespace BHV
{
	// Token: 0x02000235 RID: 565
	public sealed class BHVTaskParamPlayerRevive : BHVTaskParam
	{
		// Token: 0x06000B9B RID: 2971 RVA: 0x0000B5DD File Offset: 0x000097DD
		public BHVTaskParamPlayerRevive()
		{
			base.m_Type = BHVTaskType.PlayerRevive;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0000B5ED File Offset: 0x000097ED
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

		// Token: 0x04000A83 RID: 2691
		public bool bool_1;
	}
}
