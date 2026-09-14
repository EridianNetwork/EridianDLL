using System;

namespace BHV
{
	// Token: 0x02000181 RID: 385
	public sealed class BHVTaskParamDisabled : BHVTaskParam
	{
		// Token: 0x060008AB RID: 2219 RVA: 0x00008B6A File Offset: 0x00006D6A
		public BHVTaskParamDisabled()
		{
			base.m_Type = BHVTaskType.Disabled;
			this.bool_1 = false;
			this.bool_2 = false;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0005BFEC File Offset: 0x0005A1EC
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_3)
		{
			base.vmethod_2(ref data_0, bool_3);
			if (bool_3)
			{
				data_0.bool_1 = this.bool_1;
				data_0.bool_2 = this.bool_2;
			}
			else
			{
				this.bool_1 = data_0.bool_1;
				this.bool_2 = data_0.bool_2;
			}
		}

		// Token: 0x04000817 RID: 2071
		public bool bool_1;

		// Token: 0x04000818 RID: 2072
		public bool bool_2;
	}
}
