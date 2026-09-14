using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000214 RID: 532
	public class BHVTaskSwordSlash : BHVTask
	{
		// Token: 0x06000B15 RID: 2837 RVA: 0x0000AEBE File Offset: 0x000090BE
		public BHVTaskSwordSlash()
		{
			base.m_Type = BHVTaskType.SwordSlash;
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0000AECE File Offset: 0x000090CE
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSwordSlash_0 = bhvtaskParam_0 as BHVTaskParamSwordSlash;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0000AEE3 File Offset: 0x000090E3
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSwordSlash_0;
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x00064FEC File Offset: 0x000631EC
		public override void Start()
		{
			this.bool_1 = false;
			if (this.object_0 == null)
			{
				this.object_0 = (this.bhvtaskManager_0.m_entity as EntityNpc).m_spawnObjPrefabList[0];
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bSwordSlash", true);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetInteger("SwordSlashID", this.bhvtaskParamSwordSlash_0.int_3);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0000AEEB File Offset: 0x000090EB
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if (this.bool_1)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0000AF0D File Offset: 0x0000910D
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bSwordSlash", false);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x00065074 File Offset: 0x00063274
		public void method_0(bool bool_2)
		{
			Quaternion rotation = this.bhvtaskManager_0.transform.rotation;
			if (this.object_0 != null && this.bhvtaskParamSwordSlash_0.gameObject_0 != null)
			{
				Vector3 vector;
				if (bool_2)
				{
					vector = (this.bhvtaskManager_0.m_entity as EntityNpc).m_leftHandWeaponSlot.position;
				}
				else
				{
					vector = (this.bhvtaskManager_0.m_entity as EntityNpc).m_rightHandWeaponSlot.position;
				}
				Vector3 eulerAngles = rotation.eulerAngles;
				eulerAngles.z = global::UnityEngine.Random.Range(eulerAngles.z - 30f, eulerAngles.z + 30f);
				rotation.eulerAngles = eulerAngles;
				GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0, vector, rotation);
				if (gameObject != null)
				{
					SwordSlash component = gameObject.GetComponent<SwordSlash>();
					if (component != null)
					{
						component.m_BHVTaskManager = this.bhvtaskManager_0;
						component.m_attackObject = this.bhvtaskParamSwordSlash_0.gameObject_0;
						component.m_damagePoint = this.bhvtaskParamSwordSlash_0.int_4;
					}
				}
			}
		}

		// Token: 0x04000A0B RID: 2571
		public bool bool_1;

		// Token: 0x04000A0C RID: 2572
		private BHVTaskParamSwordSlash bhvtaskParamSwordSlash_0;

		// Token: 0x04000A0D RID: 2573
		private global::UnityEngine.Object object_0;
	}
}
