using System;

namespace BHV
{
	// Token: 0x0200017D RID: 381
	public sealed class BHVTaskParamDeployAidStation : BHVTaskParam
	{
		// Token: 0x0600089B RID: 2203 RVA: 0x00008A4B File Offset: 0x00006C4B
		public BHVTaskParamDeployAidStation()
		{
			base.m_Type = BHVTaskType.DeployAidStation;
			this.float_0 = 10f;
			this.float_1 = 10f;
			this.int_3 = 300;
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0005BDDC File Offset: 0x00059FDC
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_0.y = this.float_1;
			}
			else
			{
				this.float_0 = data_0.vector3_0.x;
				this.float_1 = data_0.vector3_0.y;
			}
		}

		// Token: 0x0400080C RID: 2060
		public float float_0;

		// Token: 0x0400080D RID: 2061
		public float float_1;

		// Token: 0x0400080E RID: 2062
		public int int_3;
	}
}
