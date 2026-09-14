using System;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class BadassBanditKillerAnimationManagerFSM : BanditKillerAnimationManagerFSM
{
	// Token: 0x060000C8 RID: 200 RVA: 0x0000379C File Offset: 0x0000199C
	public void Awake()
	{
		this.method_34();
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00039730 File Offset: 0x00037930
	public override void vmethod_13(WeakPoint.PartInfo partInfo_0)
	{
		if (partInfo_0 == WeakPoint.PartInfo.ExtraPart && this.m_backPackFlame != null && this.m_backPackFlameBroken != null)
		{
			base.method_24(this.m_backPackFlame, false);
			base.method_24(this.m_backPackFlameBroken, true);
			this.m_VFXManager.method_10(ENPCParticleType.E_DamageOverTimeFire, this.m_backPackFlame.position, true);
		}
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_33(Transform transform_0)
	{
	}

	// Token: 0x060000CB RID: 203 RVA: 0x000037A4 File Offset: 0x000019A4
	public void method_34()
	{
		if (this.m_backPackFlame != null && this.m_backPackFlameBroken != null)
		{
			base.method_24(this.m_backPackFlame, true);
			base.method_24(this.m_backPackFlameBroken, false);
		}
	}

	// Token: 0x040000F8 RID: 248
	public Transform m_backPackFlame;

	// Token: 0x040000F9 RID: 249
	public Transform m_backPackFlameBroken;
}
