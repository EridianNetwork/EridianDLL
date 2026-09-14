using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001CA RID: 458
	public sealed class BHVTaskParamFire : BHVTaskParam
	{
		// Token: 0x060009D9 RID: 2521 RVA: 0x0005FF94 File Offset: 0x0005E194
		public BHVTaskParamFire()
		{
			base.m_Type = BHVTaskType.Fire;
			base.m_Layer = BHVTaskLayer.TOPBODY;
			this.bhvfireStyle_0 = BHVFireStyle.INVALID;
			this.int_3 = 1;
			this.gameObject_0 = null;
			this.vector3_0 = Vector3.zero;
			this.vector3_0.smethod_0();
			this.int_4 = -1;
			this.float_0 = 100f;
			this.bhvstance_0 = BHVStance.STAND;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00009D43 File Offset: 0x00007F43
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00009D56 File Offset: 0x00007F56
		public override void vmethod_1()
		{
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0005FFFC File Offset: 0x0005E1FC
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.bhvfireStyle_0 = this.bhvfireStyle_0;
				data_0.int_1 = this.int_3;
				data_0.int_2 = this.int_4;
				data_0.vector3_0 = this.vector3_0;
				data_0.bhvstance_0 = this.bhvstance_0;
				data_0.vector3_0.x = this.float_0;
			}
			else
			{
				this.bhvfireStyle_0 = data_0.bhvfireStyle_0;
				this.int_3 = data_0.int_1;
				this.int_4 = data_0.int_2;
				this.vector3_0 = data_0.vector3_0;
				this.bhvstance_0 = data_0.bhvstance_0;
				this.float_0 = data_0.vector3_0.x;
			}
		}

		// Token: 0x040008F8 RID: 2296
		public BHVFireStyle bhvfireStyle_0;

		// Token: 0x040008F9 RID: 2297
		public int int_3;

		// Token: 0x040008FA RID: 2298
		public BHVStance bhvstance_0;

		// Token: 0x040008FB RID: 2299
		public GameObject gameObject_0;

		// Token: 0x040008FC RID: 2300
		public Vector3 vector3_0;

		// Token: 0x040008FD RID: 2301
		public float float_0;

		// Token: 0x040008FE RID: 2302
		private int int_4;
	}
}
