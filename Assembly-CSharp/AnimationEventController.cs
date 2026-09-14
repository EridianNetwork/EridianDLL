using System;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200007F RID: 127
public class AnimationEventController : MonoBehaviour
{
	// Token: 0x0600029E RID: 670 RVA: 0x000048D8 File Offset: 0x00002AD8
	public void method_0(Vector3 vector3_0)
	{
		this.m_hasValidTargetPosition = true;
		this.m_targetPosition = vector3_0;
	}

	// Token: 0x0600029F RID: 671 RVA: 0x000048E8 File Offset: 0x00002AE8
	public void method_1(bool bool_0)
	{
		this.m_isAiming = bool_0;
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x000048F1 File Offset: 0x00002AF1
	public void method_2(GameObject gameObject_0)
	{
		this.m_hasValidTargetPosition = false;
		this.m_targetObject = gameObject_0;
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00004901 File Offset: 0x00002B01
	public void method_3()
	{
		this.m_hasValidTargetPosition = false;
		this.m_targetObject = null;
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x00041638 File Offset: 0x0003F838
	public void OnBanditShootStart()
	{
		this.m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
		if (this.m_entityNpc != null)
		{
			this.m_entityNpcWeapon = this.m_entityNpc.vmethod_10().m_weapon;
		}
		if (this.m_entityNpcWeapon != null)
		{
			this.m_entityNpcWeapon.method_79();
			return;
		}
		if (this.m_alreadyInFiring)
		{
			return;
		}
		this.m_alreadyInFiring = true;
		if (this.m_muzzleFlash != null)
		{
			this.m_muzzleFlash.Play();
		}
		if (this.m_coneFlash != null)
		{
			this.m_coneFlash.Play();
		}
		if (this.m_muzzleLight != null && this.m_muzzleLight.GetClip("PTL_MuzzleFlash_LightFX_01") != null)
		{
			this.m_muzzleLight.Play("PTL_MuzzleFlash_LightFX_01");
		}
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x00041718 File Offset: 0x0003F918
	public void OnBanditShootStop()
	{
		if (this.m_alreadyInFiring)
		{
			this.m_alreadyInFiring = false;
			if (this.m_muzzleFlash != null)
			{
				this.m_muzzleFlash.Stop();
				this.m_muzzleFlash.Clear();
			}
			if (this.m_coneFlash != null)
			{
				this.m_coneFlash.Stop();
				this.m_coneFlash.Clear();
			}
			if (this.m_muzzleLight != null && this.m_muzzleLight.GetClip("PTL_MuzzleFlash_LightFX_01") != null)
			{
				this.m_muzzleLight.Rewind();
				this.m_muzzleLight.Play();
				this.m_muzzleLight.Sample();
				this.m_muzzleLight.Stop();
			}
			return;
		}
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x000417D4 File Offset: 0x0003F9D4
	private void Start()
	{
		this.m_animator = base.GetComponent<Animator>();
		this.m_aimIKweight = 0f;
		this.m_isAiming = false;
		this.m_pendingLeftHandIKweight = 0f;
		if (MonoSingleton<Session>.Instance != null)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer != null && localPlayer.GetEntity() != null)
			{
				this.m_localPlayer = localPlayer.GetEntity() as EntityPlayer;
			}
			else
			{
				DebugUtils.Log(LogCategory.Gamelogic, "m_entityPlayer is not ready!");
			}
		}
		else
		{
			DebugUtils.Log(LogCategory.Gamelogic, "game session is not ready!");
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x00004911 File Offset: 0x00002B11
	public bool method_4()
	{
		return this.m_targetObject != null || this.m_hasValidTargetPosition;
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00041864 File Offset: 0x0003FA64
	protected Vector3 method_5()
	{
		if (!(this.m_targetObject != null))
		{
			return this.m_targetPosition;
		}
		EntityPlayer component = this.m_targetObject.GetComponent<EntityPlayer>();
		if (component != null)
		{
			return component.vmethod_23();
		}
		return this.m_targetObject.transform.position;
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x000418B8 File Offset: 0x0003FAB8
	private void method_6(float float_0, float float_1)
	{
		if (this.m_cameraGlow == null)
		{
			return;
		}
		if (this.m_targetObject == null)
		{
			this.m_cameraGlow.SetActive(false);
			return;
		}
		EntityPlayer component = this.m_targetObject.GetComponent<EntityPlayer>();
		if (component == this.m_localPlayer)
		{
			this.m_cameraGlow.SetActive(true);
			Color color = this.m_cameraGlow.renderer.material.GetColor("_TintColor");
			color.a = float_1 * float_0 * 0.3f;
			this.m_cameraGlow.renderer.material.SetColor("_TintColor", color);
		}
		else
		{
			this.m_cameraGlow.SetActive(false);
		}
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x0004196C File Offset: 0x0003FB6C
	private void method_7()
	{
		if (!(m_sniperLight != null) || !(m_entityNpcWeapon != null))
		{
			return;
		}
		if (m_enableSniperAim && m_animator != null && method_4() && !m_animator.GetBool("IsCasual") && m_localPlayer != null)
		{
			m_sniperLight.Play();
			float num = 1f;
			float magnitude = (m_localPlayer.method_46() - m_sniperLight.transform.position).magnitude;
			num = ((magnitude < 15f && magnitude >= 5f) ? ((magnitude - 5f) / 10f) : ((!(magnitude < 5f)) ? 1f : 0f));
			Vector3 normalized = (method_5() - m_entityNpcWeapon.transform.position).normalized;
			Vector3 normalized2 = (m_localPlayer.method_46() - m_entityNpcWeapon.transform.position).normalized;
			float num2 = Vector3.Angle(normalized, normalized2);
			float num3 = 1f;
			num3 = ((num2 < 60f && num2 >= 15f) ? ((60f - num2) / 45f) : ((!(num2 < 15f)) ? 0f : 1f));
			m_sniperLightDisapperTimer += Time.deltaTime;
			float num4 = 1f;
			RaycastHit[] array = Physics.RaycastAll(m_sniperLight.transform.position, normalized2, (m_localPlayer.method_46() - m_entityNpcWeapon.transform.position).magnitude);
			int i = 0;
			bool flag = false;
			for (; i < array.Length; i++)
			{
				RaycastHit raycastHit = array[i];
				if (m_localPlayer.collider.attachedRigidbody == raycastHit.collider.attachedRigidbody)
				{
					flag = false;
					continue;
				}
				if (raycastHit.collider.isTrigger)
				{
					flag = false;
					continue;
				}
				flag = true;
				break;
			}
			if (flag)
			{
				if (m_sniperLightDisapperTimer > 0.5f)
				{
					num4 = 0f;
				}
				else if (m_sniperLightDisapperTimer < 0.5f && m_sniperLightDisapperTimer > 0f)
				{
					num4 = (0.5f - m_sniperLightDisapperTimer) / 0.5f;
				}
			}
			else
			{
				num4 = 1f;
				m_sniperLightDisapperTimer = 0f;
			}
			Color color = m_sniperLight.renderer.material.GetColor("_TintColor");
			color.a = num * num3 * num4;
			m_sniperLight.renderer.material.SetColor("_TintColor", color);
			method_6(num4, num);
		}
		else
		{
			m_sniperLight.Stop();
			m_sniperLightDisapperTimer = 0f;
			m_cameraGlow.SetActive(value: false);
		}
	}
	// Token: 0x060002A9 RID: 681 RVA: 0x00041C84 File Offset: 0x0003FE84
	private void Update()
	{
		if (this.m_entityNpc == null && base.gameObject.transform.parent != null)
		{
			this.m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
		}
		if (this.m_entityNpcWeapon == null && this.m_entityNpc != null)
		{
			AIInventory aiinventory = this.m_entityNpc.vmethod_10();
			if (aiinventory != null)
			{
				this.m_entityNpcWeapon = aiinventory.m_weapon;
			}
		}
		this.method_7();
	}

	// Token: 0x060002AA RID: 682 RVA: 0x00041D18 File Offset: 0x0003FF18
	private void OnAnimatorIK(int layerIndex)
	{
		if (this.m_animator == null)
		{
			this.m_animator = base.GetComponent<Animator>();
		}
		if (this.m_enableAimIK)
		{
			if (this.method_4() && layerIndex == 0)
			{
				this.m_aimIKweight = Mathf.Lerp(this.m_aimIKweight, 1f, 0.2f);
				Vector3 vector = this.method_5();
				if (this.m_entityNpc == null && base.gameObject.transform.parent != null)
				{
					this.m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
					if (this.m_entityNpc != null)
					{
						AIInventory aiinventory = this.m_entityNpc.vmethod_10();
						if (aiinventory != null)
						{
							this.m_entityNpcWeapon = aiinventory.m_weapon;
						}
					}
				}
				if (this.m_entityNpc != null && this.m_entityNpc.m_subType == EntityNpc.EntitySubType.CHR_BanditScout)
				{
					if (Mathf.Abs(this.m_animator.GetFloat("fMoveSpeed")) < 1E-45f)
					{
						Vector3 vector2 = vector;
						vector2.y -= this.m_aimHightOffset;
						Vector3 ikposition = this.m_animator.GetIKPosition(AvatarIKGoal.RightHand);
						Vector3 normalized = (vector2 - ikposition).normalized;
						if (this.m_entityNpcWeapon != null)
						{
							this.m_entityNpcWeapon.transform.forward = normalized;
						}
					}
				}
				else
				{
					this.m_animator.SetLookAtWeight(1f * this.m_aimIKweight, 0.6f * this.m_aimIKweight, 0.6f * this.m_aimIKweight, 1f * this.m_aimIKweight, 0.5f);
					this.m_animator.SetLookAtPosition(vector);
				}
			}
		}
		else
		{
			this.m_aimIKweight = 0f;
		}
		if (layerIndex == 1)
		{
			if (this.m_enableLeftHandIK)
			{
				this.method_8(this.m_currentWeaponType, 1f);
				this.m_pendingLeftHandIK = false;
			}
			if (this.m_pendingLeftHandIK)
			{
				this.m_pendingLeftHandIKweight = Mathf.Lerp(this.m_pendingLeftHandIKweight, 1f, 0.3f);
				this.method_8(this.m_pendingWeaponType, this.m_pendingLeftHandIKweight);
			}
			else
			{
				this.m_pendingLeftHandIKweight = 0f;
			}
		}
	}

	// Token: 0x060002AB RID: 683 RVA: 0x00041F44 File Offset: 0x00040144
	public bool method_8(WeaponType weaponType_0, float float_0)
	{
		if (float_0 > 1f || float_0 < 0f)
		{
			float_0 = Mathf.Clamp(float_0, 0f, 1f);
		}
		if (this.m_PlayerLeftHandSmg == null)
		{
			this.method_9();
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

	// Token: 0x060002AC RID: 684 RVA: 0x00042020 File Offset: 0x00040220
	public bool method_9()
	{
		if (this.m_PlayerLeftHandSmg != null && this.m_PlayerLeftHandShotgun != null && this.m_PlayerLeftHandSniper != null)
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
		}
		return this.m_PlayerLeftHandSmg != null && this.m_PlayerLeftHandShotgun != null && this.m_PlayerLeftHandSniper != null;
	}

	// Token: 0x060002AD RID: 685 RVA: 0x0000492A File Offset: 0x00002B2A
	public GameObject method_10()
	{
		return this.m_targetObject;
	}

	// Token: 0x0400026D RID: 621
	public ParticleSystem m_muzzleFlash;

	// Token: 0x0400026E RID: 622
	public ParticleSystem m_coneFlash;

	// Token: 0x0400026F RID: 623
	public ParticleSystem m_sniperLight;

	// Token: 0x04000270 RID: 624
	public GameObject m_cameraGlow;

	// Token: 0x04000271 RID: 625
	public bool m_enableSniperAim;

	// Token: 0x04000272 RID: 626
	public Animation m_muzzleLight;

	// Token: 0x04000273 RID: 627
	public Animator m_animator;

	// Token: 0x04000274 RID: 628
	public bool m_enableAimIK;

	// Token: 0x04000275 RID: 629
	protected float m_aimIKweight;

	// Token: 0x04000276 RID: 630
	private bool m_alreadyInFiring;

	// Token: 0x04000277 RID: 631
	protected Vector3 m_targetPosition = Vector3.zero;

	// Token: 0x04000278 RID: 632
	protected GameObject m_targetObject;

	// Token: 0x04000279 RID: 633
	protected bool m_hasValidTargetPosition;

	// Token: 0x0400027A RID: 634
	public Transform m_PlayerLeftHandSmg;

	// Token: 0x0400027B RID: 635
	public Transform m_PlayerLeftHandShotgun;

	// Token: 0x0400027C RID: 636
	public Transform m_PlayerLeftHandSniper;

	// Token: 0x0400027D RID: 637
	public Transform m_PlayerLeftHandPistol;

	// Token: 0x0400027E RID: 638
	public Transform m_PlayerLeftHandCombatRifle;

	// Token: 0x0400027F RID: 639
	public WeaponType m_currentWeaponType;

	// Token: 0x04000280 RID: 640
	public bool m_enableLeftHandIK;

	// Token: 0x04000281 RID: 641
	public bool m_pendingLeftHandIK;

	// Token: 0x04000282 RID: 642
	private float m_pendingLeftHandIKweight;

	// Token: 0x04000283 RID: 643
	public WeaponType m_pendingWeaponType;

	// Token: 0x04000284 RID: 644
	protected EntityNpc m_entityNpc;

	// Token: 0x04000285 RID: 645
	protected EntityWeapon m_entityNpcWeapon;

	// Token: 0x04000286 RID: 646
	public float m_aimHightOffset = 0.4f;

	// Token: 0x04000287 RID: 647
	public bool m_isAiming;

	// Token: 0x04000288 RID: 648
	protected EntityPlayer m_localPlayer;

	// Token: 0x04000289 RID: 649
	private float m_sniperLightDisapperTimer;
}
