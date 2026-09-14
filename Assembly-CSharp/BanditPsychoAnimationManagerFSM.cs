using System;
using System.Text;
using UnityEngine;

// Token: 0x02000021 RID: 33
public class BanditPsychoAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000E2 RID: 226 RVA: 0x00039C04 File Offset: 0x00037E04
	public void method_31()
	{
		if (this.m_weaponHolder == null)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("Entities/Object/Weapon/");
		if (this.m_setup.m_settings.m_weaponHolderName == "Bip01 R Hand_AXE")
		{
			stringBuilder.Append(this.m_setup.m_settings.m_weaponPrefabName);
		}
		else if (this.m_setup.m_settings.m_weaponHolderName == "Bip01 L Hand_GRENADE")
		{
			stringBuilder.Append("WPN_Grenade_Dummy");
		}
		this.m_weaponNPC = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(stringBuilder.ToString()));
		if (this.m_weaponNPC != null)
		{
			PsychoThrowAxe component = this.m_weaponNPC.GetComponent<PsychoThrowAxe>();
			if (component != null)
			{
				global::UnityEngine.Object.Destroy(component);
			}
			this.m_weaponNPC.transform.parent = this.m_weaponHolder;
			this.m_weaponNPC.transform.localPosition = Vector3.zero;
			this.m_weaponNPC.transform.localRotation = Quaternion.identity;
			this.m_weaponNPC.SetActive(true);
		}
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00039D18 File Offset: 0x00037F18
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = true;
		this.m_canUseFacingLogic = false;
		this.m_deathLayer = 2;
		this.method_31();
		this.m_animEventHandlerList.Add("ThrowWeapon", new AnimationManagerFSM.OnAnimEventHandler(base.OnThrowWeapon));
		this.m_animEventHandlerList.Add("SpawnWeapon", new AnimationManagerFSM.OnAnimEventHandler(this.OnSpawnWeapon));
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000375F File Offset: 0x0000195F
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00039DA8 File Offset: 0x00037FA8
	public void OnSpawnWeapon()
	{
		AnimationThrowWeaponState animationThrowWeaponState = base.method_16(Utils.smethod_23(AnimationStateFSM.ThrowWeapon)) as AnimationThrowWeaponState;
		if (animationThrowWeaponState != null)
		{
			animationThrowWeaponState.m_spawnNewWeapon = true;
		}
	}

	// Token: 0x0400010D RID: 269
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x0400010E RID: 270
	public GameObject m_weaponNPC;
}
