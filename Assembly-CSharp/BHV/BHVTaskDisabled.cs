using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000182 RID: 386
	public class BHVTaskDisabled : BHVTask
	{
		// Token: 0x060008AD RID: 2221 RVA: 0x00008B88 File Offset: 0x00006D88
		public BHVTaskDisabled()
		{
			base.m_Type = BHVTaskType.Disabled;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00008B98 File Offset: 0x00006D98
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDisabled_0 = bhvtaskParam_0 as BHVTaskParamDisabled;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00008BAD File Offset: 0x00006DAD
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDisabled_0;
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0005C03C File Offset: 0x0005A23C
		public override void Start()
		{
			base.Start();
			Renderer[] componentsInChildren = this.bhvtaskManager_0.m_entity.gameObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = this.bhvtaskParamDisabled_0.bool_1;
			}
			Collider[] componentsInChildren2 = this.bhvtaskManager_0.m_entity.gameObject.GetComponentsInChildren<Collider>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].enabled = this.bhvtaskParamDisabled_0.bool_1;
			}
			AIServiceUtility.AIServiceUtility_0.m_bPlayCutScene = this.bhvtaskParamDisabled_0.bool_2;
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0000872C File Offset: 0x0000692C
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0005C0D4 File Offset: 0x0005A2D4
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			Collider[] componentsInChildren = this.bhvtaskManager_0.m_entity.gameObject.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = true;
			}
			DamageManager.DamageManager_0.method_1(this.bhvtaskManager_0.m_entity);
		}

		// Token: 0x04000819 RID: 2073
		private BHVTaskParamDisabled bhvtaskParamDisabled_0;
	}
}
