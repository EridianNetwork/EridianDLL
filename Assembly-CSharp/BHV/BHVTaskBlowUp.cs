using System;
using System.Text;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001A6 RID: 422
	public class BHVTaskBlowUp : BHVTask
	{
		// Token: 0x06000946 RID: 2374 RVA: 0x00009472 File Offset: 0x00007672
		public BHVTaskBlowUp()
		{
			base.m_Type = BHVTaskType.BlowUp;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00009491 File Offset: 0x00007691
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamBlowUp_0 = bhvtaskParam_0 as BHVTaskParamBlowUp;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x000094A6 File Offset: 0x000076A6
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamBlowUp_0;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x000094AE File Offset: 0x000076AE
		public override void Start()
		{
			base.Start();
			this.state_0 = BHVTaskBlowUp.State.const_1;
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0005D8DC File Offset: 0x0005BADC
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			this.int_0--;
			BHVTaskBlowUp.State state = this.state_0;
			switch (state + 1)
			{
			case BHVTaskBlowUp.State.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case (BHVTaskBlowUp.State)1:
			{
				this.state_0 = BHVTaskBlowUp.State.const_2;
				this.bhvtaskManager_0.GetComponent<VFXManager>().method_4(ENPCParticleType.E_Explode, 0f, true);
				Transform transform = this.bhvtaskManager_0.m_entity.transform.Find("Point light");
				if (transform != null)
				{
					Animation component = transform.gameObject.GetComponent<Animation>();
					if (component != null)
					{
						component.CrossFade("PTL_Grenade_Light");
					}
				}
				Renderer componentInChildren = this.bhvtaskManager_0.m_entity.gameObject.GetComponentInChildren<Renderer>();
				if (componentInChildren != null)
				{
					componentInChildren.enabled = false;
				}
				EntityExplosive entityExplosive = this.bhvtaskManager_0.m_entity as EntityExplosive;
				if (entityExplosive != null)
				{
					entityExplosive.method_16();
				}
				return;
			}
			}
			if (this.int_0 == 0)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0005D9E8 File Offset: 0x0005BBE8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (this.bhvtaskParamBlowUp_0 != null)
			{
				stringBuilder.Append(string.Format("        State:{0}\n", this.state_0));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0400086E RID: 2158
		private BHVTaskParamBlowUp bhvtaskParamBlowUp_0;

		// Token: 0x0400086F RID: 2159
		private BHVTaskBlowUp.State state_0 = BHVTaskBlowUp.State.const_0;

		// Token: 0x04000870 RID: 2160
		private int int_0 = 10;

		// Token: 0x020001A7 RID: 423
		private enum State
		{
			// Token: 0x04000872 RID: 2162
			const_0 = -1,
			// Token: 0x04000873 RID: 2163
			const_1,
			// Token: 0x04000874 RID: 2164
			const_2 = 2
		}
	}
}
