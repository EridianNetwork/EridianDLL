using System;

namespace BHV
{
	// Token: 0x02000203 RID: 515
	public sealed class BHVTaskParamRoll : BHVTaskParamAnimationState
	{
		// Token: 0x06000AD7 RID: 2775 RVA: 0x0000AAF4 File Offset: 0x00008CF4
		public BHVTaskParamRoll()
		{
			base.m_Type = BHVTaskType.Roll;
			this.bool_1 = false;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0000AB0B File Offset: 0x00008D0B
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

		// Token: 0x040009DD RID: 2525
		public bool bool_1;
	}
}
