using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001A1 RID: 417
	public sealed class BHVTaskParamWarning : BHVTaskParamAnimationState
	{
		// Token: 0x06000935 RID: 2357 RVA: 0x0000936F File Offset: 0x0000756F
		public BHVTaskParamWarning()
		{
			base.m_Type = BHVTaskType.Warning;
			this.gameObject_0 = null;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00009386 File Offset: 0x00007586
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00009399 File Offset: 0x00007599
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x000093AC File Offset: 0x000075AC
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

		// Token: 0x04000867 RID: 2151
		public GameObject gameObject_0;

		// Token: 0x04000868 RID: 2152
		private int int_3;
	}
}
