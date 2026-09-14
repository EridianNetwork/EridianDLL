using System;

namespace BHV
{
	// Token: 0x02000192 RID: 402
	public sealed class BHVTaskParamRollBack : BHVTaskParam
	{
		// Token: 0x060008FA RID: 2298 RVA: 0x00008F5B File Offset: 0x0000715B
		public BHVTaskParamRollBack()
		{
			base.m_Type = BHVTaskType.RollBack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00008F72 File Offset: 0x00007172
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

		// Token: 0x0400084B RID: 2123
		public float float_0;
	}
}
