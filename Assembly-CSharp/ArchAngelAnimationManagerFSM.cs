using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class ArchAngelAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000C3 RID: 195 RVA: 0x0000375F File Offset: 0x0000195F
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x000396C8 File Offset: 0x000378C8
	public override void vmethod_14()
	{
		if (this.m_VFXManager == null)
		{
			return;
		}
		Vector3 vector;
		vector.x = 0f;
		vector.y = 2.5f;
		vector.z = 0f;
		this.m_VFXManager.method_9(ENPCParticleType.E_archangelTeleport, base.transform.position + vector, Quaternion.identity, true);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x000396C8 File Offset: 0x000378C8
	public override void vmethod_15()
	{
		if (this.m_VFXManager == null)
		{
			return;
		}
		Vector3 vector;
		vector.x = 0f;
		vector.y = 2.5f;
		vector.z = 0f;
		this.m_VFXManager.method_9(ENPCParticleType.E_archangelTeleport, base.transform.position + vector, Quaternion.identity, true);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00003776 File Offset: 0x00001976
	private void OnDestroy()
	{
		if (this.m_VFXManager != null)
		{
			this.m_VFXManager.method_13(ENPCParticleType.E_archangelDeathStruggle);
		}
	}

	// Token: 0x040000F7 RID: 247
	public Transform[] m_missileLunchPoints = new Transform[0];
}
