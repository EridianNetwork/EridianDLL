using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C3 RID: 451
	public class BHVTaskEnergyBlast : BHVTask
	{
		// Token: 0x060009B3 RID: 2483 RVA: 0x00009BB1 File Offset: 0x00007DB1
		public BHVTaskEnergyBlast()
		{
			base.m_Type = BHVTaskType.EnergyBlast;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00009BC1 File Offset: 0x00007DC1
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamEnergyBlast_0 = bhvtaskParam_0 as BHVTaskParamEnergyBlast;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00009BD6 File Offset: 0x00007DD6
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamEnergyBlast_0;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0005EDFC File Offset: 0x0005CFFC
		public override void Start()
		{
			base.Start();
			if (this.bhvtaskManager_0 == null)
			{
				return;
			}
			if (this.bhvtaskManager_0.m_entity == null)
			{
				return;
			}
			if (this.bhvtaskManager_0.m_animationManagerFSM != null && this.bhvtaskManager_0.m_animationManagerFSM.Animator_0 != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEnergyBlaster", true);
			}
			if (this.object_0 == null)
			{
				this.object_0 = (this.bhvtaskManager_0.m_entity as EntityNpc).m_spawnObjPrefabList[0];
			}
			this.bool_1 = false;
			if (this.bhvtaskParamEnergyBlast_0 == null)
			{
				return;
			}
			if (this.bhvtaskParamEnergyBlast_0.gameObject_0 == null)
			{
				return;
			}
			this.vector3_0 = this.bhvtaskParamEnergyBlast_0.gameObject_0.transform.position;
			if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
			{
				float num = Mathf.Clamp(this.bhvtaskParamEnergyBlast_0.float_1, 1f, this.bhvtaskParamEnergyBlast_0.float_1);
				AIServiceUtility.AIServiceUtility_0.method_5(this.vector3_0, num);
			}
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0005EF2C File Offset: 0x0005D12C
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			AnimatorStateInfo currentAnimatorStateInfo = this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.IsTag("EnergyBlast"))
			{
				if (!this.bool_1)
				{
					if (currentAnimatorStateInfo.normalizedTime > 0.5f)
					{
						if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
						{
							this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_5(ENPCParticleType.E_ArchangelOpenFace, this.bhvtaskManager_0.m_entity, (this.bhvtaskManager_0.m_entity as EntityNpc).m_headTransform, Vector3.zero, Quaternion.identity, 5f, true);
						}
						this.bool_1 = true;
						if (this.object_0 != null && this.bhvtaskParamEnergyBlast_0.gameObject_0 != null)
						{
							GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0, this.vector3_0, Quaternion.identity);
							if (gameObject != null)
							{
								EnergyBlast component = gameObject.GetComponent<EnergyBlast>();
								component.m_taskManager = this.bhvtaskManager_0;
								component.m_delayTimer = this.bhvtaskParamEnergyBlast_0.float_0;
							}
						}
					}
				}
				else if (currentAnimatorStateInfo.normalizedTime > 0.97f)
				{
					AIServiceUtility.AIServiceUtility_0.method_6();
					base.m_Status = BHVTaskStatus.SUCCESS;
				}
			}
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00009BDE File Offset: 0x00007DDE
		public override void vmethod_3(bool bool_2)
		{
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEnergyBlaster", false);
			base.vmethod_3(bool_2);
			AIServiceUtility.AIServiceUtility_0.method_6();
		}

		// Token: 0x040008C3 RID: 2243
		private BHVTaskParamEnergyBlast bhvtaskParamEnergyBlast_0;

		// Token: 0x040008C4 RID: 2244
		private bool bool_1;

		// Token: 0x040008C5 RID: 2245
		private global::UnityEngine.Object object_0;

		// Token: 0x040008C6 RID: 2246
		private Vector3 vector3_0;
	}
}
