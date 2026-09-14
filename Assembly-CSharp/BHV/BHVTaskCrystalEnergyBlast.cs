using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001B5 RID: 437
	public class BHVTaskCrystalEnergyBlast : BHVTask
	{
		// Token: 0x06000974 RID: 2420 RVA: 0x00009791 File Offset: 0x00007991
		public BHVTaskCrystalEnergyBlast()
		{
			base.m_Type = BHVTaskType.CrystalEnergyBlast;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x000097AC File Offset: 0x000079AC
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCrystalEnergyBlast_0 = bhvtaskParam_0 as BHVTaskParamCrystalEnergyBlast;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x000097C1 File Offset: 0x000079C1
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCrystalEnergyBlast_0;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0005DF38 File Offset: 0x0005C138
		public override void Start()
		{
			base.Start();
			this.float_0 = this.bhvtaskParamCrystalEnergyBlast_0.float_0;
			this.bool_1 = false;
			this.method_0();
			if (this.object_0 == null && (this.bhvtaskManager_0.m_entity as EntityNpc).m_spawnObjPrefabList.Length > 0)
			{
				this.object_0 = (this.bhvtaskManager_0.m_entity as EntityNpc).m_spawnObjPrefabList[0];
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEnergyBlast", true);
			AIServiceUtility.AIServiceUtility_0.method_7(this.list_1, this.bhvtaskParamCrystalEnergyBlast_0.float_1);
			(this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneCrystalAnimationManagerFSM).method_31(true);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0005DFFC File Offset: 0x0005C1FC
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if (!this.bool_1)
			{
				this.float_0 -= deltaTime;
				if (this.float_0 > 0f)
				{
					return;
				}
				this.bool_1 = true;
				AIServiceUtility.AIServiceUtility_0.method_8();
				(this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneCrystalAnimationManagerFSM).method_31(false);
			}
			int count = this.list_1.Count;
			if (count == 0)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
			for (int i = 0; i < count; i++)
			{
				if (this.object_0 != null)
				{
					GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0, this.list_1[i], Quaternion.identity);
					if (gameObject != null)
					{
						EnergyBlast component = gameObject.GetComponent<EnergyBlast>();
						component.m_taskManager = this.bhvtaskManager_0;
						component.m_delayTimer = 1f;
					}
				}
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0005E0E8 File Offset: 0x0005C2E8
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEnergyBlast", false);
			AIServiceUtility.AIServiceUtility_0.method_8();
			(this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneCrystalAnimationManagerFSM).method_31(false);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0005E138 File Offset: 0x0005C338
		private void method_0()
		{
			this.list_1.Clear();
			MonoSingleton<Session>.Instance.method_38(out this.list_0);
			int count = this.list_0.Count;
			for (int i = 0; i < count; i++)
			{
				PlayerInfoSync playerInfoSync = this.list_0[i];
				if (!(playerInfoSync == null) && !(playerInfoSync.GetEntity() == null))
				{
					this.list_1.Add(playerInfoSync.GetEntity().method_1());
				}
			}
		}

		// Token: 0x04000895 RID: 2197
		private BHVTaskParamCrystalEnergyBlast bhvtaskParamCrystalEnergyBlast_0;

		// Token: 0x04000896 RID: 2198
		private float float_0;

		// Token: 0x04000897 RID: 2199
		private bool bool_1;

		// Token: 0x04000898 RID: 2200
		private List<PlayerInfoSync> list_0;

		// Token: 0x04000899 RID: 2201
		private List<Vector3> list_1 = new List<Vector3>();

		// Token: 0x0400089A RID: 2202
		private global::UnityEngine.Object object_0;
	}
}
