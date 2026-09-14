using System;

namespace BHV
{
	// Token: 0x0200023B RID: 571
	public sealed class BHVTaskParamPlayerStun : BHVTaskParam
	{
		// Token: 0x06000BAF RID: 2991 RVA: 0x0000B6ED File Offset: 0x000098ED
		public BHVTaskParamPlayerStun()
		{
			base.m_Type = BHVTaskType.PlayerStun;
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0000B4D8 File Offset: 0x000096D8
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (!bool_1)
			{
			}
		}
	}
}
