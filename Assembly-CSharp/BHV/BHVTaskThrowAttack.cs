using System;
using Core;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000219 RID: 537
	public class BHVTaskThrowAttack : BHVTaskAnimationState, InstantiateManager.InstanciationClient
	{
		// Token: 0x06000B2A RID: 2858 RVA: 0x0000AFB9 File Offset: 0x000091B9
		public BHVTaskThrowAttack()
		{
			base.m_Type = BHVTaskType.ThrowAttack;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0000AFD0 File Offset: 0x000091D0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamThrowAttack_0 = bhvtaskParam_0 as BHVTaskParamThrowAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0000AFE5 File Offset: 0x000091E5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamThrowAttack_0;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x000654B0 File Offset: 0x000636B0
		public override void Start()
		{
			base.Start();
			this.animationThrowWeaponState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.ThrowWeapon)) as AnimationThrowWeaponState;
			this.bool_1 = false;
			this.bool_2 = true;
			this.vector3_0 = new Vector3(10f, 0f, 0f);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00065514 File Offset: 0x00063714
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.ThrowWeapon);
			if (this.animationThrowWeaponState_0 != null && !this.bool_1 && this.animationThrowWeaponState_0.m_readyToLaunch)
			{
				if (this.bhvtaskParamThrowAttack_0.ethrowWeaponType_0 == EThrowWeaponType.const_0)
				{
					this.method_1();
				}
				else if (this.bhvtaskParamThrowAttack_0.ethrowWeaponType_0 == EThrowWeaponType.const_2)
				{
					this.method_2();
				}
				else
				{
					this.method_1();
				}
				this.bool_1 = true;
			}
			this.method_3();
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00065588 File Offset: 0x00063788
		public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
		{
			Vector3 vector = (this.bhvtaskParamThrowAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			vector = (vector + Vector3.up * 0.7f).normalized;
			float magnitude = (this.bhvtaskManager_0.m_entity.transform.position - this.bhvtaskParamThrowAttack_0.gameObject_0.transform.position).magnitude;
			float num = Mathf.Lerp(250f, 900f, magnitude / 25f);
			instance.rigidbody.AddForce(vector * num);
			instance.rigidbody.AddTorque(this.vector3_0);
			EntityExplosive component = instance.GetComponent<EntityExplosive>();
			if (component != null)
			{
				component.method_15(this.bhvtaskManager_0.m_entity);
			}
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0000311B File Offset: 0x0000131B
		public void method_1()
		{
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x00065684 File Offset: 0x00063884
		public void method_2()
		{
			if (this.object_0 == null)
			{
				if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_17())
				{
					this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/WPN_Axe_BadassNPC");
				}
				else
				{
					this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/WPN_Axe_NPC");
				}
			}
			if (this.object_0 == null)
			{
				return;
			}
			if (this.gameObject_0 == null)
			{
				this.gameObject_0 = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0);
			}
			else
			{
				this.gameObject_0.SetActive(true);
			}
			if (this.gameObject_0 != null)
			{
				Vector3 vector = this.bhvtaskParamThrowAttack_0.gameObject_0.transform.position + Vector3.up * 1.4f;
				GameObject weaponNPC = (this.bhvtaskManager_0.m_animationManagerFSM as BanditPsychoAnimationManagerFSM).m_weaponNPC;
				if (!(weaponNPC != null))
				{
					DebugUtils.LogError(LogCategory.AI, "Spawn axe failed!");
					return;
				}
				this.gameObject_0.transform.position = weaponNPC.transform.position;
				Vector3 vector2 = vector - this.gameObject_0.transform.position;
				this.gameObject_0.transform.forward = vector2.normalized;
				this.bool_2 = false;
				weaponNPC.SetActive(false);
				PsychoThrowAxe component = this.gameObject_0.GetComponent<PsychoThrowAxe>();
				if (component != null)
				{
					component.m_BHVTaskManager = this.bhvtaskManager_0;
					component.m_attackObject = this.bhvtaskParamThrowAttack_0.gameObject_0;
					float magnitude = (vector - this.gameObject_0.transform.position).magnitude;
					Vector3 normalized = (vector - this.gameObject_0.transform.position).normalized;
					RaycastHit raycastHit;
					if (Physics.Raycast(this.gameObject_0.transform.position - normalized * 1f, normalized, out raycastHit, magnitude, TargetingService.Int32_0))
					{
						vector = raycastHit.point;
					}
					component.m_flyingCurve = AIServiceCurve.AIServiceCurve_0.method_1(AIServiceCurve.ECurveType.EThrowAxeCurve, this.gameObject_0.transform.position, vector, 2f);
					component.method_0();
				}
			}
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x000658BC File Offset: 0x00063ABC
		private void method_3()
		{
			if (!this.bool_2 && this.animationThrowWeaponState_0.m_spawnNewWeapon)
			{
				GameObject weaponNPC = (this.bhvtaskManager_0.m_animationManagerFSM as BanditPsychoAnimationManagerFSM).m_weaponNPC;
				if (weaponNPC != null)
				{
					this.bool_2 = true;
					weaponNPC.SetActive(true);
				}
			}
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0006590C File Offset: 0x00063B0C
		public override void vmethod_3(bool bool_3)
		{
			base.vmethod_3(bool_3);
			if (!this.bool_2)
			{
				GameObject weaponNPC = (this.bhvtaskManager_0.m_animationManagerFSM as BanditPsychoAnimationManagerFSM).m_weaponNPC;
				if (weaponNPC != null)
				{
					this.bool_2 = true;
					weaponNPC.SetActive(true);
				}
			}
		}

		// Token: 0x04000A1F RID: 2591
		private BHVTaskParamThrowAttack bhvtaskParamThrowAttack_0;

		// Token: 0x04000A20 RID: 2592
		private AnimationThrowWeaponState animationThrowWeaponState_0;

		// Token: 0x04000A21 RID: 2593
		private bool bool_1;

		// Token: 0x04000A22 RID: 2594
		private bool bool_2 = true;

		// Token: 0x04000A23 RID: 2595
		private Vector3 vector3_0;

		// Token: 0x04000A24 RID: 2596
		private global::UnityEngine.Object object_0;

		// Token: 0x04000A25 RID: 2597
		private GameObject gameObject_0;
	}
}
