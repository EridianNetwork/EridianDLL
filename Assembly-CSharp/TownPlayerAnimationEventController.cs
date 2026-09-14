using System;
using UnityEngine;
using XsdSettings;

// Token: 0x0200008B RID: 139
public class TownPlayerAnimationEventController : AnimationEventController
{
	// Token: 0x17000019 RID: 25
	// (get) Token: 0x060002EF RID: 751 RVA: 0x00004BE8 File Offset: 0x00002DE8
	// (set) Token: 0x060002F0 RID: 752 RVA: 0x00004BF0 File Offset: 0x00002DF0
	public bool Boolean_0
	{
		get
		{
			return this.m_initWeaponPending;
		}
		set
		{
			this.m_initWeaponPending = value;
			this.m_initPendingTime = Mathf.Max(this.m_initPendingTime, 1f);
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x00004C0F File Offset: 0x00002E0F
	private void Start()
	{
		this.m_initPendingTime = 5f;
		this.m_initWeaponPending = true;
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x00043620 File Offset: 0x00041820
	private void Update()
	{
		if (this.m_initPendingTime >= 0f)
		{
			this.m_initPendingTime -= Time.deltaTime;
		}
		else if (this.m_initWeaponPending)
		{
			this.m_initWeaponPending = !this.method_11();
		}
		if (this.m_animator == null)
		{
			this.m_animator = base.GetComponent<Animator>();
		}
		if (this.m_localPlayer == null)
		{
			this.m_localPlayer = base.GetComponentInParent<EntityPlayer>();
		}
		if (this.m_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
		{
			this.m_enableLeftHandIK = true;
		}
		else
		{
			this.m_enableLeftHandIK = false;
		}
		if (!this.m_animator.GetCurrentAnimatorStateInfo(1).IsTag("Empty"))
		{
			this.m_enableLeftHandIK = false;
		}
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x000436E8 File Offset: 0x000418E8
	private bool method_11()
	{
		if (this.m_localPlayer == null || this.m_animator == null)
		{
			return false;
		}
		EntityWeapon entityWeapon = this.m_localPlayer.vmethod_16();
		if (entityWeapon == null)
		{
			return false;
		}
		this.m_currentWeaponType = entityWeapon.method_99();
		this.m_animator.SetInteger("iWeaponType", (int)this.m_currentWeaponType);
		return true;
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00043750 File Offset: 0x00041950
	private void OnAnimatorIK(int layerIndex)
	{
		if (this.m_animator == null)
		{
			return;
		}
		if (this.m_enableLeftHandIK)
		{
			int integer = this.m_animator.GetInteger("iWeaponType");
			if (Enum.IsDefined(typeof(WeaponType), integer))
			{
				this.m_currentWeaponType = (WeaponType)integer;
			}
			if (this.m_currentWeaponType != WeaponType.RepeaterPistol)
			{
				base.method_8(this.m_currentWeaponType, 1f);
			}
		}
	}

	// Token: 0x040002CB RID: 715
	private float m_initPendingTime;

	// Token: 0x040002CC RID: 716
	private bool m_initWeaponPending;
}
