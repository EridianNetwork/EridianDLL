using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using XsdSettings;

// Token: 0x02000090 RID: 144
public class FireTiming
{
	// Token: 0x06000319 RID: 793 RVA: 0x00004D42 File Offset: 0x00002F42
	public FireTiming(PlayerAnimationManagerFSM playerAnimationManagerFSM_0)
	{
		this.m_Owner = playerAnimationManagerFSM_0;
	}

	// Token: 0x14000001 RID: 1
	// (add) Token: 0x0600031A RID: 794 RVA: 0x00004D5C File Offset: 0x00002F5C
	// (remove) Token: 0x0600031B RID: 795 RVA: 0x00004D75 File Offset: 0x00002F75
	public event FireTiming.Handler_BurstFire Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.burstfire_handler = (FireTiming.Handler_BurstFire)Delegate.Combine(this.burstfire_handler, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.burstfire_handler = (FireTiming.Handler_BurstFire)Delegate.Remove(this.burstfire_handler, value);
		}
	}

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x0600031C RID: 796 RVA: 0x00004D8E File Offset: 0x00002F8E
	// (remove) Token: 0x0600031D RID: 797 RVA: 0x00004DA7 File Offset: 0x00002FA7
	public event FireTiming.Handler_SingleFire Event_1
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.singlefire_handler = (FireTiming.Handler_SingleFire)Delegate.Combine(this.singlefire_handler, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.singlefire_handler = (FireTiming.Handler_SingleFire)Delegate.Remove(this.singlefire_handler, value);
		}
	}

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x0600031E RID: 798 RVA: 0x00004DC0 File Offset: 0x00002FC0
	// (remove) Token: 0x0600031F RID: 799 RVA: 0x00004DD9 File Offset: 0x00002FD9
	public event FireTiming.Handler_NoFire Event_2
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.nofire_handler = (FireTiming.Handler_NoFire)Delegate.Combine(this.nofire_handler, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.nofire_handler = (FireTiming.Handler_NoFire)Delegate.Remove(this.nofire_handler, value);
		}
	}

	// Token: 0x06000320 RID: 800 RVA: 0x00004DF2 File Offset: 0x00002FF2
	public void OnTriggerFire(float fireSpeed)
	{
		this.m_weapon_firefrequency = fireSpeed;
		this.m_weapon_fireperiod = 1f / this.m_weapon_firefrequency;
		this.m_ShotPending_current = true;
	}

	// Token: 0x06000321 RID: 801 RVA: 0x000450BC File Offset: 0x000432BC
	public void Update()
	{
		EntityWeapon entityWeapon = this.m_Owner.m_entity.vmethod_16();
		if (entityWeapon == null)
		{
			return;
		}
		WeaponType weaponType = entityWeapon.method_99();
		if (weaponType != WeaponType.SMG && weaponType != WeaponType.CombatRifle)
		{
			if (weaponType != WeaponType.RepeaterPistol)
			{
				this.method_1();
				return;
			}
		}
		bool flag = this.method_2();
		if (this.m_firedInPreviousCycle)
		{
			if (!flag && !this.method_0())
			{
				this.m_Owner.method_53();
				this.m_firedInPreviousCycle = false;
			}
		}
		else
		{
			this.m_firedInPreviousCycle = flag;
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x00004E14 File Offset: 0x00003014
	public bool method_0()
	{
		return Time.time - this.m_weapon_firestarttime < this.m_weapon_fireperiod;
	}

	// Token: 0x06000323 RID: 803 RVA: 0x00045138 File Offset: 0x00043338
	private void method_1()
	{
		if (!this.method_0())
		{
			if (!this.m_ShotPending_last && !this.m_ShotPending_current)
			{
				if (this.nofire_handler != null)
				{
					this.nofire_handler();
				}
			}
			else
			{
				this.m_weapon_firestarttime = Time.time;
				if (this.singlefire_handler != null)
				{
					this.singlefire_handler(this.m_weapon_firefrequency);
				}
				this.m_Owner.method_52(false);
			}
		}
		this.m_ShotPending_last = this.m_ShotPending_current;
		this.m_ShotPending_current = false;
	}

	// Token: 0x06000324 RID: 804 RVA: 0x000451B8 File Offset: 0x000433B8
	private bool method_2()
	{
		bool flag = false;
		if (!this.method_0())
		{
			if (this.m_ShotPending_last)
			{
				this.m_weapon_firestarttime = Time.time;
				if (this.burstfire_handler != null)
				{
					this.burstfire_handler();
				}
				this.m_Owner.method_52(true);
				flag = true;
			}
			else if (this.m_ShotPending_current)
			{
				if (this.m_Owner.m_entity != null)
				{
					EntityWeapon entityWeapon = ((EntityPlayer)this.m_Owner.m_entity).vmethod_16();
					if (entityWeapon != null && entityWeapon.method_17().m_type != WeaponType.ShotGun && entityWeapon.method_17().m_type != WeaponType.SniperRifle)
					{
						this.m_weapon_firestarttime = Time.time;
						if (this.singlefire_handler != null)
						{
							this.singlefire_handler(this.m_weapon_firefrequency);
						}
						this.m_Owner.method_52(false);
						flag = true;
					}
				}
			}
			else if (this.nofire_handler != null)
			{
				this.nofire_handler();
			}
		}
		this.m_ShotPending_last = this.m_ShotPending_current;
		this.m_ShotPending_current = false;
		return flag;
	}

	// Token: 0x0400033B RID: 827
	private PlayerAnimationManagerFSM m_Owner;

	// Token: 0x0400033C RID: 828
	private float m_weapon_fireperiod;

	// Token: 0x0400033D RID: 829
	private float m_weapon_firefrequency = 1f;

	// Token: 0x0400033E RID: 830
	private float m_weapon_firestarttime;

	// Token: 0x0400033F RID: 831
	private bool m_ShotPending_last;

	// Token: 0x04000340 RID: 832
	private bool m_ShotPending_current;

	// Token: 0x04000341 RID: 833
	private bool m_firedInPreviousCycle;

	// Token: 0x04000342 RID: 834
	private FireTiming.Handler_BurstFire burstfire_handler;

	// Token: 0x04000343 RID: 835
	private FireTiming.Handler_SingleFire singlefire_handler;

	// Token: 0x04000344 RID: 836
	private FireTiming.Handler_NoFire nofire_handler;

	// Token: 0x02000091 RID: 145
	// (Invoke) Token: 0x06000326 RID: 806
	public delegate void Handler_BurstFire();

	// Token: 0x02000092 RID: 146
	// (Invoke) Token: 0x0600032A RID: 810
	public delegate void Handler_SingleFire(float _freq);

	// Token: 0x02000093 RID: 147
	// (Invoke) Token: 0x0600032E RID: 814
	public delegate void Handler_NoFire();
}
