using System;
using UnityEngine;
using XsdSettings;

// Token: 0x02000085 RID: 133
public class PlayerAnimationIkController : MonoBehaviour
{
	// Token: 0x060002C4 RID: 708 RVA: 0x00004A25 File Offset: 0x00002C25
	public void method_0(Vector3 vector3_0)
	{
		this.m_hasValidTargetPosition = true;
		this.m_targetPosition = vector3_0;
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x00004A35 File Offset: 0x00002C35
	public void method_1(GameObject gameObject_0)
	{
		this.m_hasValidTargetPosition = false;
		this.m_targetObject = gameObject_0;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x00004A45 File Offset: 0x00002C45
	public void method_2()
	{
		this.m_hasValidTargetPosition = false;
		this.m_targetObject = null;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x00004A55 File Offset: 0x00002C55
	private void Start()
	{
		this.m_animator = base.GetComponent<Animator>();
		this.m_aimIKweight = 0f;
		this.m_pendingLeftHandIKweight = 0f;
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x00004A79 File Offset: 0x00002C79
	public bool method_3()
	{
		return this.m_targetObject != null || this.m_hasValidTargetPosition;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x000425D8 File Offset: 0x000407D8
	private Vector3 method_4()
	{
		if (!(this.m_targetObject != null))
		{
			return this.m_targetPosition;
		}
		EntityPlayer component = this.m_targetObject.GetComponent<EntityPlayer>();
		if (!(component != null))
		{
			return this.m_targetObject.transform.position;
		}
		if (component.method_45() != null)
		{
			return component.method_46();
		}
		return component.vmethod_23();
	}

	// Token: 0x060002CA RID: 714 RVA: 0x00042644 File Offset: 0x00040844
	private void OnAnimatorIK(int layerIndex)
	{
		if (this.m_animator == null)
		{
			this.m_animator = base.GetComponent<Animator>();
		}
		if (this.m_enableAimIK)
		{
			if (this.method_3() && layerIndex == 0)
			{
				this.m_aimIKweight = Mathf.Lerp(this.m_aimIKweight, 1f, 0.2f);
				Vector3 vector = this.method_4();
				this.m_animator.SetLookAtWeight(1f * this.m_aimIKweight, 0.6f * this.m_aimIKweight, 0.6f * this.m_aimIKweight, 1f * this.m_aimIKweight, 0.5f);
				this.m_animator.SetLookAtPosition(vector);
			}
		}
		else
		{
			this.m_aimIKweight = 0f;
		}
		if (!this.m_enableAimIK && this.m_enableLookIK && this.method_3())
		{
			Vector3 vector2 = this.method_4();
			this.m_animator.SetLookAtWeight(1f, 0f, 0.7f, 1f, this.m_lookIKClamp);
			this.m_animator.SetLookAtPosition(vector2);
		}
		if (layerIndex == 1)
		{
			if (this.m_enableLeftHandIK)
			{
				this.method_5(this.m_currentWeaponType, 1f);
				this.m_pendingLeftHandIK = false;
			}
			if (this.m_pendingLeftHandIK)
			{
				this.m_pendingLeftHandIKweight = Mathf.Lerp(this.m_pendingLeftHandIKweight, 1f, 0.3f);
				this.method_5(this.m_pendingWeaponType, this.m_pendingLeftHandIKweight);
			}
			else
			{
				this.m_pendingLeftHandIKweight = 0f;
			}
		}
	}

	// Token: 0x060002CB RID: 715 RVA: 0x000427B4 File Offset: 0x000409B4
	public bool method_5(WeaponType weaponType_0, float float_0)
	{
		if (weaponType_0 == WeaponType.RepeaterPistol)
		{
			return true;
		}
		if (float_0 > 1f || float_0 < 0f)
		{
			float_0 = Mathf.Clamp(float_0, 0f, 1f);
		}
		if (this.m_PlayerLeftHandSmg == null)
		{
			this.method_6();
		}
		Transform transform = null;
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			transform = this.m_PlayerLeftHandSmg;
			break;
		case WeaponType.SniperRifle:
			transform = this.m_PlayerLeftHandSniper;
			break;
		case WeaponType.ShotGun:
			transform = this.m_PlayerLeftHandShotgun;
			break;
		case WeaponType.RepeaterPistol:
			transform = this.m_PlayerLeftHandPistol;
			break;
		case WeaponType.CombatRifle:
			transform = this.m_PlayerLeftHandCombatRifle;
			break;
		}
		if (transform == null)
		{
			return false;
		}
		this.m_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, float_0);
		this.m_animator.SetIKPosition(AvatarIKGoal.LeftHand, transform.position);
		this.m_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, float_0);
		this.m_animator.SetIKRotation(AvatarIKGoal.LeftHand, transform.rotation);
		return true;
	}

	// Token: 0x060002CC RID: 716 RVA: 0x00042898 File Offset: 0x00040A98
	public bool method_6()
	{
		if (this.m_PlayerLeftHandSmg != null && this.m_PlayerLeftHandShotgun != null && this.m_PlayerLeftHandSniper != null && this.m_PlayerLeftHandPistol != null && this.m_PlayerLeftHandCombatRifle != null)
		{
			return true;
		}
		foreach (Transform transform in base.gameObject.transform.GetComponentsInChildren<Transform>())
		{
			if (transform.gameObject.name.ToLower() == "export_l_hand_smg")
			{
				this.m_PlayerLeftHandSmg = transform;
			}
			else if (transform.gameObject.name.ToLower() == "export_l_hand_shotgun")
			{
				this.m_PlayerLeftHandShotgun = transform;
			}
			else if (transform.gameObject.name.ToLower() == "export_l_hand_sniper")
			{
				this.m_PlayerLeftHandSniper = transform;
			}
			else if (transform.gameObject.name.ToLower() == "export_l_hand_pistol")
			{
				this.m_PlayerLeftHandPistol = transform;
			}
			else if (transform.gameObject.name.ToLower() == "export_l_hand_combatrifle" || transform.gameObject.name.ToLower() == "export_l_hand_rifle")
			{
				this.m_PlayerLeftHandCombatRifle = transform;
			}
			if (this.m_PlayerLeftHandSmg != null && this.m_PlayerLeftHandShotgun != null && this.m_PlayerLeftHandSniper != null && this.m_PlayerLeftHandPistol != null && this.m_PlayerLeftHandCombatRifle != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00004A92 File Offset: 0x00002C92
	public GameObject method_7()
	{
		return this.m_targetObject;
	}

	// Token: 0x0400029E RID: 670
	public Animator m_animator;

	// Token: 0x0400029F RID: 671
	public bool m_enableAimIK;

	// Token: 0x040002A0 RID: 672
	public bool m_enableLookIK;

	// Token: 0x040002A1 RID: 673
	private float m_aimIKweight;

	// Token: 0x040002A2 RID: 674
	public Vector3 m_targetPosition = Vector3.zero;

	// Token: 0x040002A3 RID: 675
	public GameObject m_targetObject;

	// Token: 0x040002A4 RID: 676
	public bool m_hasValidTargetPosition;

	// Token: 0x040002A5 RID: 677
	public Transform m_PlayerLeftHandSmg;

	// Token: 0x040002A6 RID: 678
	public Transform m_PlayerLeftHandShotgun;

	// Token: 0x040002A7 RID: 679
	public Transform m_PlayerLeftHandSniper;

	// Token: 0x040002A8 RID: 680
	public Transform m_PlayerLeftHandPistol;

	// Token: 0x040002A9 RID: 681
	public Transform m_PlayerLeftHandCombatRifle;

	// Token: 0x040002AA RID: 682
	public WeaponType m_currentWeaponType;

	// Token: 0x040002AB RID: 683
	public bool m_enableLeftHandIK;

	// Token: 0x040002AC RID: 684
	public bool m_pendingLeftHandIK;

	// Token: 0x040002AD RID: 685
	private float m_pendingLeftHandIKweight;

	// Token: 0x040002AE RID: 686
	public WeaponType m_pendingWeaponType;

	// Token: 0x040002AF RID: 687
	public float m_aimHightOffset = 0.4f;

	// Token: 0x040002B0 RID: 688
	private float m_lookIKClamp = 0.7f;
}
