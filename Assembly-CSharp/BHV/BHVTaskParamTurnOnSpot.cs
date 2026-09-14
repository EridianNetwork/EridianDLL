using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200019B RID: 411
	public sealed class BHVTaskParamTurnOnSpot : BHVTaskParam
	{
		// Token: 0x0600091A RID: 2330 RVA: 0x000091E9 File Offset: 0x000073E9
		public BHVTaskParamTurnOnSpot()
		{
			base.m_Type = BHVTaskType.TurnOnSpot;
			this.gameObject_0 = null;
			this.int_3 = -1;
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00009206 File Offset: 0x00007406
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00009219 File Offset: 0x00007419
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0000922C File Offset: 0x0000742C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
			}
			else
			{
				this.int_3 = data_0.int_2;
			}
		}

		// Token: 0x0400085E RID: 2142
		public GameObject gameObject_0;

		// Token: 0x0400085F RID: 2143
		private int int_3;
	}
}
