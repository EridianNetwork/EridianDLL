using System;

namespace BHV
{
	// Token: 0x0200022F RID: 559
	public sealed class BHVTaskParamPlayerCripple : BHVTaskParam
	{
		// Token: 0x06000B80 RID: 2944 RVA: 0x0000B4BD File Offset: 0x000096BD
		public BHVTaskParamPlayerCripple()
		{
			base.m_Type = BHVTaskType.PlayerCripple;
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0000B4D8 File Offset: 0x000096D8
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (!bool_1)
			{
			}
		}

		// Token: 0x04000A62 RID: 2658
		public float float_0 = 10f;
	}
}
