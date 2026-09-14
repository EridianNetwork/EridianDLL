using System;

namespace BHV
{
	// Token: 0x020001FB RID: 507
	public sealed class BHVTaskParamRadiusAttack : BHVTaskParamAnimationState
	{
		// Token: 0x06000AB3 RID: 2739 RVA: 0x0000A923 File Offset: 0x00008B23
		public BHVTaskParamRadiusAttack()
		{
			this.float_0 = 5f;
			base.m_Type = BHVTaskType.RadiusAttack;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0000A93E File Offset: 0x00008B3E
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_0;
			}
			else
			{
				this.float_0 = data_0.vector3_0.x;
			}
		}

		// Token: 0x040009C5 RID: 2501
		public float float_0;
	}
}
