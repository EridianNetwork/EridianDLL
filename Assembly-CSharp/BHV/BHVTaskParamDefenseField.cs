using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001BA RID: 442
	public sealed class BHVTaskParamDefenseField : BHVTaskParam
	{
		// Token: 0x0600098C RID: 2444 RVA: 0x00009926 File Offset: 0x00007B26
		public BHVTaskParamDefenseField()
		{
			base.m_Type = BHVTaskType.DefenseField;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00009936 File Offset: 0x00007B36
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00009949 File Offset: 0x00007B49
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0000995C File Offset: 0x00007B5C
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

		// Token: 0x040008A5 RID: 2213
		public GameObject gameObject_0;

		// Token: 0x040008A6 RID: 2214
		private int int_3;
	}
}
