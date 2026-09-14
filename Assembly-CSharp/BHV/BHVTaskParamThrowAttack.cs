using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000218 RID: 536
	public sealed class BHVTaskParamThrowAttack : BHVTaskParam
	{
		// Token: 0x06000B26 RID: 2854 RVA: 0x0000AF6E File Offset: 0x0000916E
		public BHVTaskParamThrowAttack()
		{
			base.m_Type = BHVTaskType.ThrowAttack;
			this.ethrowWeaponType_0 = EThrowWeaponType.const_0;
			this.gameObject_0 = null;
			this.int_3 = -1;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0000AF93 File Offset: 0x00009193
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0000AFA6 File Offset: 0x000091A6
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x00065460 File Offset: 0x00063660
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_1 = (int)this.ethrowWeaponType_0;
				data_0.int_2 = this.int_3;
			}
			else
			{
				this.ethrowWeaponType_0 = (EThrowWeaponType)data_0.int_1;
				this.int_3 = data_0.int_2;
			}
		}

		// Token: 0x04000A1C RID: 2588
		public EThrowWeaponType ethrowWeaponType_0;

		// Token: 0x04000A1D RID: 2589
		public GameObject gameObject_0;

		// Token: 0x04000A1E RID: 2590
		private int int_3;
	}
}
