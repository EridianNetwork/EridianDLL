using System;

namespace BHV
{
	// Token: 0x02000197 RID: 407
	public sealed class BHVTaskParamSpawn : BHVTaskParamAnimationState
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x000090ED File Offset: 0x000072ED
		public BHVTaskParamSpawn()
		{
			base.m_Type = BHVTaskType.Spawn;
			this.float_0 = -1f;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00009113 File Offset: 0x00007313
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.float_0 = this.float_0;
			}
			else
			{
				this.float_0 = data_0.float_0;
			}
		}

		// Token: 0x0400085B RID: 2139
		public float float_0 = -1f;
	}
}
