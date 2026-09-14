using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000201 RID: 513
	public sealed class BHVTaskParamRocketAttack : BHVTaskParam
	{
		// Token: 0x06000ACC RID: 2764 RVA: 0x0000AA3C File Offset: 0x00008C3C
		public BHVTaskParamRocketAttack()
		{
			base.m_Type = BHVTaskType.RocketAttack;
			this.gameObject_0 = null;
			this.int_3 = -1;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x0000AA61 File Offset: 0x00008C61
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0000AA74 File Offset: 0x00008C74
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0000AA87 File Offset: 0x00008C87
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

		// Token: 0x040009D4 RID: 2516
		public GameObject gameObject_0;

		// Token: 0x040009D5 RID: 2517
		private int int_3;
	}
}
