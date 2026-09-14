using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001EA RID: 490
	public sealed class BHVTaskParamLavaStrike : BHVTaskParam
	{
		// Token: 0x06000A6B RID: 2667 RVA: 0x0000A4BE File Offset: 0x000086BE
		public BHVTaskParamLavaStrike()
		{
			base.m_Type = BHVTaskType.LavaStrike;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0000A4D5 File Offset: 0x000086D5
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x04000989 RID: 2441
		public Vector3 vector3_0;
	}
}
