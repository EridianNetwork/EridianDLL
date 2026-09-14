using System;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200023C RID: 572
	public class BHVTaskPlayerStun : BHVTask
	{
		// Token: 0x06000BB1 RID: 2993 RVA: 0x0000B6FD File Offset: 0x000098FD
		public BHVTaskPlayerStun()
		{
			base.m_Type = BHVTaskType.PlayerStun;
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0000B70D File Offset: 0x0000990D
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerStun_0 = bhvtaskParam_0 as BHVTaskParamPlayerStun;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0000B722 File Offset: 0x00009922
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerStun_0;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x00067778 File Offset: 0x00065978
		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			this.entityPlayer_0 = this.bhvtaskManager_0.m_entity as EntityPlayer;
			if (this.entityPlayer_0.vmethod_25().IsMyActor())
			{
				if (MonoSingleton<GraphicsMgr>.Instance != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_18().method_5(true);
				}
			}
			else
			{
				this.entityPlayer_0.VFXManager_0.method_10(ENPCParticleType.E_Stun, this.entityPlayer_0.transform.position + Vector3.up * (this.entityPlayer_0.method_151() + 0.5f), true);
			}
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x00008EC4 File Offset: 0x000070C4
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0006781C File Offset: 0x00065A1C
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			if (this.entityPlayer_0.vmethod_25().IsMyActor())
			{
				if (MonoSingleton<GraphicsMgr>.Instance != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_18().method_5(false);
				}
			}
			else
			{
				this.entityPlayer_0.VFXManager_0.method_13(ENPCParticleType.E_Stun);
			}
		}

		// Token: 0x04000A89 RID: 2697
		private BHVTaskParamPlayerStun bhvtaskParamPlayerStun_0;

		// Token: 0x04000A8A RID: 2698
		private EntityPlayer entityPlayer_0;
	}
}
