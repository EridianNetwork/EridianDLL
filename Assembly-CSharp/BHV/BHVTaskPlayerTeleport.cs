using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001F4 RID: 500
	public class BHVTaskPlayerTeleport : BHVTask
	{
		// Token: 0x06000A92 RID: 2706 RVA: 0x0000A727 File Offset: 0x00008927
		public BHVTaskPlayerTeleport()
		{
			base.m_Type = BHVTaskType.PlayerTeleport;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0000A74D File Offset: 0x0000894D
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerTeleport_0 = bhvtaskParam_0 as BHVTaskParamPlayerTeleport;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0000A762 File Offset: 0x00008962
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerTeleport_0;
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x00063690 File Offset: 0x00061890
		public override void Start()
		{
			base.Start();
			this.float_0 = this.bhvtaskParamPlayerTeleport_0.float_1 + 1f;
			this.bool_1 = false;
			this.bool_2 = false;
			this.playerController_0 = this.bhvtaskParamPlayerTeleport_0.gameObject_0.GetComponent<PlayerController>();
			if (this.gameObject_0 == null)
			{
				this.gameObject_0 = GameObject.Find("BOSS_TELE_PLAYER");
				if (this.gameObject_0 != null)
				{
					this.vector3_1 = this.gameObject_0.transform.position;
				}
			}
			this.vector3_0 = this.bhvtaskParamPlayerTeleport_0.gameObject_0.transform.position;
			this.bool_3 = false;
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_10(ENPCParticleType.E_PlayerTeleportAbsorb, this.vector3_0, true);
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bAttackWarning", true);
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00063794 File Offset: 0x00061994
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			this.float_0 -= Time.deltaTime;
			if (!this.bool_1 && this.bhvtaskParamPlayerTeleport_0.gameObject_0 != null && this.playerController_0 != null)
			{
				if ((this.vector3_0 - this.bhvtaskParamPlayerTeleport_0.gameObject_0.transform.position).sqrMagnitude < this.bhvtaskParamPlayerTeleport_0.float_0 * this.bhvtaskParamPlayerTeleport_0.float_0)
				{
					if (!this.bool_2)
					{
						this.playerController_0.method_6(this.bhvtaskParamPlayerTeleport_0.float_2);
						this.bool_2 = true;
					}
				}
				else if (this.bool_2)
				{
					this.playerController_0.method_6(1f / this.bhvtaskParamPlayerTeleport_0.float_2);
					this.bool_2 = false;
				}
			}
			if (this.float_0 < 1f && !this.bool_1)
			{
				if (this.bool_2)
				{
					MovementSync component = this.bhvtaskParamPlayerTeleport_0.gameObject_0.GetComponent<MovementSync>();
					if (!(component != null))
					{
					}
				}
				this.bool_1 = true;
			}
			if (this.bool_1 && !this.bool_3 && (this.bhvtaskParamPlayerTeleport_0.gameObject_0.transform.position - this.vector3_1).sqrMagnitude < 1f)
			{
				this.method_0();
				this.bool_3 = true;
			}
			if (this.float_0 < 0f)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00063928 File Offset: 0x00061B28
		public override void vmethod_3(bool bool_4)
		{
			base.vmethod_3(bool_4);
			if (this.bool_2)
			{
				if (this.playerController_0 != null)
				{
					this.playerController_0.method_6(1f / this.bhvtaskParamPlayerTeleport_0.float_2);
				}
				if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
				{
					this.vector3_0 = this.bhvtaskParamPlayerTeleport_0.gameObject_0.transform.position;
					this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_10(ENPCParticleType.E_PlayerTeleportRelease, this.vector3_0, true);
				}
				if (!this.bool_3)
				{
					this.method_0();
				}
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bAttackWarning", false);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x000639EC File Offset: 0x00061BEC
		private void method_0()
		{
			EntityPlayer entityPlayer = this.bhvtaskManager_0.m_entity as EntityPlayer;
			if (entityPlayer != null && entityPlayer.VFXManager_0 != null)
			{
				entityPlayer.VFXManager_0.method_10(ENPCParticleType.E_PlayerRevive, this.bhvtaskManager_0.transform.position, true);
			}
		}

		// Token: 0x040009AB RID: 2475
		private BHVTaskParamPlayerTeleport bhvtaskParamPlayerTeleport_0;

		// Token: 0x040009AC RID: 2476
		private float float_0 = 4f;

		// Token: 0x040009AD RID: 2477
		private Vector3 vector3_0 = Vector3.zero;

		// Token: 0x040009AE RID: 2478
		private Vector3 vector3_1;

		// Token: 0x040009AF RID: 2479
		private GameObject gameObject_0;

		// Token: 0x040009B0 RID: 2480
		private bool bool_1;

		// Token: 0x040009B1 RID: 2481
		private bool bool_2;

		// Token: 0x040009B2 RID: 2482
		private bool bool_3;

		// Token: 0x040009B3 RID: 2483
		private PlayerController playerController_0;
	}
}
