using System;
using UnityEngine;

// Token: 0x0200002A RID: 42
public class CrimsonLanceSniperAnimationManagerFSM : BanditScoutAnimationManagerFSM
{
	// Token: 0x06000118 RID: 280 RVA: 0x0003AB40 File Offset: 0x00038D40
	public override void Start()
	{
		base.Start();
		this.m_sniperStealEffect = base.gameObject.GetComponent<SniperStealthEffect>();
		if (base.Transform_0 != null)
		{
			this.m_displayObjRender = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
		}
		if (this.m_sniperStealEffect != null && this.m_displayObjRender != null)
		{
			this.m_sniperStealEffect.m_sniperMaterials = this.m_displayObjRender.materials;
		}
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00003913 File Offset: 0x00001B13
	protected override void vmethod_16(bool bool_0)
	{
		if (this.m_sniperStealEffect != null && this.m_displayObjRender != null)
		{
			this.m_sniperStealEffect.method_0(this.m_bHide, this.m_displayObjRender);
		}
	}

	// Token: 0x0600011A RID: 282 RVA: 0x0003ABB8 File Offset: 0x00038DB8
	protected override void vmethod_17(bool bool_0)
	{
		if (this.m_bHide == bool_0)
		{
			return;
		}
		if (bool_0 && this.m_hideCooldownTime > 0f)
		{
			return;
		}
		this.m_bHide = bool_0;
		this.vmethod_16(bool_0);
		if (this.m_weapon != null)
		{
			if (this.m_enetiyWeaponRenders == null)
			{
				this.m_enetiyWeaponRenders = this.m_weapon.gameObject.GetComponentsInChildren<Renderer>();
			}
			int num = this.m_enetiyWeaponRenders.Length;
			for (int i = 0; i < num; i++)
			{
				Renderer renderer = this.m_enetiyWeaponRenders[i];
				if (renderer != null)
				{
					renderer.enabled = !bool_0;
				}
			}
		}
		if (bool_0)
		{
			this.m_hideTime = 5f;
		}
		else
		{
			this.m_hideCooldownTime = 5f;
		}
	}

	// Token: 0x04000126 RID: 294
	private SniperStealthEffect m_sniperStealEffect;

	// Token: 0x04000127 RID: 295
	private SkinnedMeshRenderer m_displayObjRender;
}
