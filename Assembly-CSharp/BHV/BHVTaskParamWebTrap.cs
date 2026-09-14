using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200021C RID: 540
	public sealed class BHVTaskParamWebTrap : BHVTaskParam
	{
		// Token: 0x06000B3D RID: 2877 RVA: 0x0000B058 File Offset: 0x00009258
		public BHVTaskParamWebTrap()
		{
			base.m_Type = BHVTaskType.WebTrap;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0000B06F File Offset: 0x0000926F
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

		// Token: 0x04000A2A RID: 2602
		public Vector3 vector3_0;
	}
}
