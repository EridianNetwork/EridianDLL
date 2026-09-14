using System;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200017A RID: 378
	public class BHVTaskDead : BHVTask
	{
		// Token: 0x06000890 RID: 2192 RVA: 0x000089D7 File Offset: 0x00006BD7
		public BHVTaskDead()
		{
			base.m_Type = BHVTaskType.Dead;
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x000089F1 File Offset: 0x00006BF1
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDead_0 = bhvtaskParam_0 as BHVTaskParamDead;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00008A06 File Offset: 0x00006C06
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDead_0;
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0005BBB0 File Offset: 0x00059DB0
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
			this.float_0 = this.bhvtaskParamDead_0.float_0;
			(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).method_29();
			EquipmentInventoryEntityNpc equipmentInventoryEntityNpc = this.bhvtaskManager_0.m_entity.vmethod_19() as EquipmentInventoryEntityNpc;
			if (equipmentInventoryEntityNpc != null && !string.IsNullOrEmpty(equipmentInventoryEntityNpc.m_npcNameFromCluster))
			{
				equipmentInventoryEntityNpc.m_npcNameFromCluster = null;
			}
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0005BC30 File Offset: 0x00059E30
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 -= deltaTime;
			if (this.float_0 < 0f)
			{
				AIServiceUtility.AIServiceUtility_0.method_10(this.bhvtaskManager_0, false);
				if (this.bhvtaskManager_0 && this.bhvtaskManager_0.m_entity && this.bhvtaskManager_0.m_entity.vmethod_10() != null)
				{
					this.bhvtaskManager_0.m_entity.vmethod_10().method_6();
				}
				MonoSingleton<EntityManager>.Instance.method_5(this.bhvtaskManager_0.m_entity);
				BHVTaskUtils.smethod_16(this.bhvtaskManager_0.m_entity, true);
				MapObjectMark component = this.bhvtaskManager_0.GetComponent<MapObjectMark>();
				if (component != null)
				{
					global::UnityEngine.Object.Destroy(component);
				}
				(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).method_30();
				if (MonoSingleton<GraphicsMgr>.Instance != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_16().method_5(this.bhvtaskManager_0.m_entity);
				}
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0005BD48 File Offset: 0x00059F48
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			if (this.float_0 > 0f || base.m_Status != BHVTaskStatus.SUCCESS)
			{
				MapObjectMark component = this.bhvtaskManager_0.GetComponent<MapObjectMark>();
				if (component != null)
				{
					global::UnityEngine.Object.Destroy(component);
				}
				(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).method_30();
				if (MonoSingleton<GraphicsMgr>.Instance != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_16().method_5(this.bhvtaskManager_0.m_entity);
				}
			}
			AIServiceUtility.AIServiceUtility_0.method_9(this.bhvtaskManager_0);
		}

		// Token: 0x04000809 RID: 2057
		private BHVTaskParamDead bhvtaskParamDead_0;

		// Token: 0x0400080A RID: 2058
		private float float_0 = 1f;
	}
}
