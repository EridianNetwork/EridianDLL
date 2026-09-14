using System;
using UnityEngine;
using XsdSettings;

// Token: 0x02000034 RID: 52
public class SoldierTurretBasicAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x0600015F RID: 351 RVA: 0x0003BFD8 File Offset: 0x0003A1D8
	public override void Start()
	{
		base.Start();
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
		}
		this.method_31();
		try
		{
			if (base.Animator_0 != null)
			{
				base.Animator_0.speed = 5f;
				this.m_deploySpeedUpUntil = Time.time + 1f;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000160 RID: 352 RVA: 0x0003C05C File Offset: 0x0003A25C
	public override void Update()
	{
		base.Update();
		if (this.m_firstTick)
		{
			this.m_firstTick = false;
			this.method_32();
		}
		try
		{
			if (this.m_deploySpeedUpUntil > 0f && Time.time >= this.m_deploySpeedUpUntil)
			{
				this.m_deploySpeedUpUntil = 0f;
				if (base.Animator_0 != null)
				{
					base.Animator_0.speed = 1f;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0003C0E0 File Offset: 0x0003A2E0
	public void OnStartShoot()
	{
		if (this.m_entity == null)
		{
			return;
		}
		EntityWeapon weapon = (this.m_entity as EntityNpc).vmethod_10().m_weapon;
		if (weapon != null)
		{
			weapon.method_79();
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0003C124 File Offset: 0x0003A324
	private void method_31()
	{
		int num = (int)this.m_entity.photonView.Object_0[1];
		this.m_entity.m_relatedPlayer = BadAssNetworkView.smethod_4(num) as EntityPlayer;
	}

	// Token: 0x06000163 RID: 355 RVA: 0x0003C160 File Offset: 0x0003A360
	private void method_32()
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		if (this.m_vfx_shield == null)
		{
			VFXManager vfxmanager = this.m_entity.vmethod_15();
			if (vfxmanager != null && vfxmanager.m_particleList != null)
			{
				for (int i = 0; i < vfxmanager.m_particleList.Length; i++)
				{
					VFXforNPC vfxforNPC = vfxmanager.m_particleList[i];
					if (vfxforNPC.m_type == ENPCParticleType.E_TurretShield)
					{
						this.m_vfx_shield = vfxforNPC.m_particleGameObject;
						break;
					}
				}
			}
		}
		if (this.m_vfx_shield != null)
		{
			bool flag = this.m_entity.m_relatedPlayer.PlayerEffectManager_0.method_0(EffectType.TurretShield) > 0f;
			this.m_vfx_shield.SetActive(flag);
		}
	}

	// Token: 0x0400014C RID: 332
	private bool m_firstTick = true;

	// Token: 0x0400014D RID: 333
	private GameObject m_vfx_shield;

	// Token: 0x0400014E RID: 334
	private float m_deploySpeedUpUntil;
}
