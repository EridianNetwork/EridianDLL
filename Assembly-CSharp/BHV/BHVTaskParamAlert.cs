using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001A3 RID: 419
	public sealed class BHVTaskParamAlert : BHVTaskParamAnimationState
	{
		// Token: 0x0600093E RID: 2366 RVA: 0x00009413 File Offset: 0x00007613
		public BHVTaskParamAlert()
		{
			base.m_Type = BHVTaskType.Alert;
			this.bool_1 = false;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0005D830 File Offset: 0x0005BA30
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.bool_1 = this.bool_1;
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.bool_1 = data_0.bool_1;
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x0400086A RID: 2154
		public bool bool_1;

		// Token: 0x0400086B RID: 2155
		public Vector3 vector3_0;
	}
}
