using System;

namespace BHV
{
	// Token: 0x020001B6 RID: 438
	public sealed class BHVTaskParamDazeEffect : BHVTaskParam
	{
		// Token: 0x0600097B RID: 2427 RVA: 0x000097C9 File Offset: 0x000079C9
		public BHVTaskParamDazeEffect()
		{
			base.m_Type = BHVTaskType.DazeEffect;
			base.m_Layer = BHVTaskLayer.EFFECT;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x000097EB File Offset: 0x000079EB
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_0;
			}
			else
			{
				this.float_0 = data_0.vector3_0.x;
			}
		}

		// Token: 0x0400089B RID: 2203
		public float float_0 = 1f;
	}
}
