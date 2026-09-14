using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001B9 RID: 441
	public class BHVTaskDeathStruggle : BHVTask
	{
		// Token: 0x06000986 RID: 2438 RVA: 0x000098B0 File Offset: 0x00007AB0
		public BHVTaskDeathStruggle()
		{
			base.m_Type = BHVTaskType.DeathStruggle;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x000098C0 File Offset: 0x00007AC0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDeathStruggle_0 = bhvtaskParam_0 as BHVTaskParamDeathStruggle;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x000098D5 File Offset: 0x00007AD5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDeathStruggle_0;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x000098DD File Offset: 0x00007ADD
		public override void Start()
		{
			this.bool_1 = false;
			this.bool_2 = false;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0005E388 File Offset: 0x0005C588
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!this.bool_1)
			{
				Vector3 vector = this.bhvtaskParamDeathStruggle_0.vector3_0 - this.bhvtaskManager_0.transform.position;
				float num = 20f;
				float sqrMagnitude = vector.sqrMagnitude;
				if (sqrMagnitude < Time.deltaTime * num * Time.deltaTime * num)
				{
					this.bhvtaskManager_0.m_entity.transform.position = this.bhvtaskParamDeathStruggle_0.vector3_0;
					this.bool_1 = true;
				}
				else
				{
					this.bhvtaskManager_0.m_entity.transform.position += vector.normalized * num * Time.deltaTime;
				}
				return;
			}
			if (!this.bool_2)
			{
				if (this.bhvtaskManager_0.m_animationManagerFSM.Animator_0 != null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bDeathStruggle", true);
				}
				this.bool_2 = true;
				int num2 = 1 << LayerMask.NameToLayer("Walkable");
				RaycastHit raycastHit;
				if (Physics.Raycast(this.bhvtaskParamDeathStruggle_0.vector3_0 + Vector3.down * 5f, Vector3.down, out raycastHit, 100f, num2) && this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_10(ENPCParticleType.E_archangelDeathStruggle, raycastHit.point, true);
				}
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x000098ED File Offset: 0x00007AED
		public override void vmethod_3(bool bool_3)
		{
			base.vmethod_3(bool_3);
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_13(ENPCParticleType.E_archangelDeathStruggle);
			}
		}

		// Token: 0x040008A2 RID: 2210
		private BHVTaskParamDeathStruggle bhvtaskParamDeathStruggle_0;

		// Token: 0x040008A3 RID: 2211
		private bool bool_1;

		// Token: 0x040008A4 RID: 2212
		private bool bool_2;
	}
}
