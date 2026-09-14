using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class BanditApollyonAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000CD RID: 205 RVA: 0x00039794 File Offset: 0x00037994
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = true;
		this.m_canUseFacingLogic = true;
		this.m_bHammerHit = false;
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
		}
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(this.OnHammerAttackHit));
		this.m_animEventHandlerList.Add("TakeOutHammer", new AnimationManagerFSM.OnAnimEventHandler(this.OnTakeOutHammer));
		this.m_animEventHandlerList.Add("PutBackHammer", new AnimationManagerFSM.OnAnimEventHandler(this.OnPutBackHammer));
		this.method_31();
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00039848 File Offset: 0x00037A48
	public void method_31()
	{
		this.m_hammerObj = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Entities/Object/Weapon/WPN_Hammer_Apollyon"));
		if (this.m_hammerObj != null)
		{
			Transform[] componentsInChildren = this.m_hammerObj.transform.GetComponentsInChildren<Transform>();
			int num = componentsInChildren.Length;
			for (int i = 0; i < num; i++)
			{
				Transform transform = componentsInChildren[i];
				if (transform.gameObject.name == "PTL_Smash_Point")
				{
					this.m_hammerVFXTransform = transform;
					break;
				}
			}
		}
		this.method_32(true);
	}

	// Token: 0x060000CF RID: 207 RVA: 0x000037E4 File Offset: 0x000019E4
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 4;
		}
		return 0;
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x000398CC File Offset: 0x00037ACC
	public void OnStartShoot()
	{
		if (this.m_entity == null)
		{
			return;
		}
		EntityWeapon weapon = this.m_entity.vmethod_10().m_weapon;
		if (weapon != null)
		{
			weapon.method_79();
		}
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00039908 File Offset: 0x00037B08
	public void method_32(bool bool_0)
	{
		EntityNpc component = base.GetComponent<EntityNpc>();
		if (component.m_rightHandWeaponSlot == null)
		{
			return;
		}
		if (this.m_hammerObj != null)
		{
			if (bool_0)
			{
				this.m_hammerObj.transform.parent = this.m_backHammerTransform;
			}
			else
			{
				this.m_hammerObj.transform.parent = component.m_leftHandWeaponSlot;
			}
			this.m_hammerObj.transform.localPosition = Vector3.zero;
			this.m_hammerObj.transform.localRotation = Quaternion.identity;
			this.m_hammerObj.SetActive(true);
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x000037FB File Offset: 0x000019FB
	public void OnTakeOutHammer()
	{
		this.method_32(false);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00003804 File Offset: 0x00001A04
	public void OnPutBackHammer()
	{
		this.method_32(true);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x0000380D File Offset: 0x00001A0D
	public void OnHammerAttackHit()
	{
		this.m_bHammerHit = true;
	}

	// Token: 0x040000FA RID: 250
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x040000FB RID: 251
	public float m_lastShotSoundTime;

	// Token: 0x040000FC RID: 252
	public GameObject m_hammerObj;

	// Token: 0x040000FD RID: 253
	public bool m_bHammerHit;

	// Token: 0x040000FE RID: 254
	public Transform m_hammerVFXTransform;

	// Token: 0x040000FF RID: 255
	public Transform m_backHammerTransform;
}
