using System;

namespace BHV
{
	// Token: 0x020001EC RID: 492
	public sealed class BHVTaskParamLightHurt : BHVTaskParam
	{
		// Token: 0x06000A73 RID: 2675 RVA: 0x0000A556 File Offset: 0x00008756
		public BHVTaskParamLightHurt()
		{
			base.m_Type = BHVTaskType.LightHurt;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
			this.edamageType_0 = EDamageType.DT_Light;
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0000A574 File Offset: 0x00008774
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_1 = (int)this.edamageType_0;
			}
			else
			{
				this.edamageType_0 = (EDamageType)data_0.int_1;
			}
		}

		// Token: 0x0400098E RID: 2446
		public EDamageType edamageType_0;
	}
}
