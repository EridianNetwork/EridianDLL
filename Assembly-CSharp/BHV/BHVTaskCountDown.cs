using System;
using System.Text;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200016E RID: 366
	public class BHVTaskCountDown : BHVTask
	{
		// Token: 0x06000866 RID: 2150 RVA: 0x000086B7 File Offset: 0x000068B7
		public BHVTaskCountDown()
		{
			base.m_Type = BHVTaskType.CountDown;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x000086C7 File Offset: 0x000068C7
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCountDown_0 = bhvtaskParam_0 as BHVTaskParamCountDown;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x000086DC File Offset: 0x000068DC
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCountDown_0;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x000086E4 File Offset: 0x000068E4
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.GetComponent<VFXManager>().method_4(ENPCParticleType.E_Fuse, 0f, true);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00008705 File Offset: 0x00006905
		public override void vmethod_3(bool bool_1)
		{
			this.bhvtaskManager_0.GetComponent<VFXManager>().method_13(ENPCParticleType.E_Fuse);
			base.vmethod_3(bool_1);
			global::UnityEngine.Object.Destroy(this.gameObject_0);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0000872C File Offset: 0x0000692C
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x0005B87C File Offset: 0x00059A7C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (this.bhvtaskParamCountDown_0 != null)
			{
				stringBuilder.Append(string.Format("        State:BHVTaskCountDown\n", new object[0]));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040007F4 RID: 2036
		private BHVTaskParamCountDown bhvtaskParamCountDown_0;

		// Token: 0x040007F5 RID: 2037
		private GameObject gameObject_0;
	}
}
