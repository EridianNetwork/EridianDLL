using System;

namespace BHV
{
	// Token: 0x0200016F RID: 367
	public sealed class BHVTaskParamAdvanceSpawn : BHVTaskParamAnimationState
	{
		// Token: 0x0600086D RID: 2157 RVA: 0x0000873C File Offset: 0x0000693C
		public BHVTaskParamAdvanceSpawn()
		{
			base.m_Type = BHVTaskType.AdvanceSpawn;
			this.eadvanceSpawnType_0 = BHVTaskParamAdvanceSpawn.EAdvanceSpawnType.const_0;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0005B8BC File Offset: 0x00059ABC
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = (int)this.eadvanceSpawnType_0;
				data_0.string_0 = this.string_0;
			}
			else
			{
				this.eadvanceSpawnType_0 = (BHVTaskParamAdvanceSpawn.EAdvanceSpawnType)data_0.int_2;
				this.string_0 = data_0.string_0;
			}
		}

		// Token: 0x040007F6 RID: 2038
		public BHVTaskParamAdvanceSpawn.EAdvanceSpawnType eadvanceSpawnType_0;

		// Token: 0x040007F7 RID: 2039
		public string string_0;

		// Token: 0x02000170 RID: 368
		public enum EAdvanceSpawnType
		{
			// Token: 0x040007F9 RID: 2041
			const_0,
			// Token: 0x040007FA RID: 2042
			const_1
		}
	}
}
