using System;

namespace BHV
{
	// Token: 0x020001F7 RID: 503
	public sealed class BHVTaskParamPoisonDash : BHVTaskParam
	{
		// Token: 0x06000AA1 RID: 2721 RVA: 0x0000A7BA File Offset: 0x000089BA
		public BHVTaskParamPoisonDash()
		{
			base.m_Type = BHVTaskType.PoisonDash;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0000A7D2 File Offset: 0x000089D2
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_4 = this.int_3;
			}
			else
			{
				this.int_3 = data_0.int_4;
			}
		}

		// Token: 0x040009B9 RID: 2489
		public int int_3 = 20;
	}
}
