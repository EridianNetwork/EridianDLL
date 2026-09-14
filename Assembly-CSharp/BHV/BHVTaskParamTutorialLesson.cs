using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000245 RID: 581
	public sealed class BHVTaskParamTutorialLesson : BHVTaskParamAnimationState
	{
		// Token: 0x06000BD1 RID: 3025 RVA: 0x0000B88C File Offset: 0x00009A8C
		public BHVTaskParamTutorialLesson()
		{
			base.m_Type = BHVTaskType.TutorialLesson;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.gameObject_0 = null;
			this.int_3 = -1;
			this.string_0 = null;
			this.float_0 = 1f;
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0000B8C3 File Offset: 0x00009AC3
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0000B8D6 File Offset: 0x00009AD6
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0000B8E9 File Offset: 0x00009AE9
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

		// Token: 0x04000A94 RID: 2708
		public GameObject gameObject_0;

		// Token: 0x04000A95 RID: 2709
		private int int_3;

		// Token: 0x04000A96 RID: 2710
		public string string_0;

		// Token: 0x04000A97 RID: 2711
		public float float_0;
	}
}
