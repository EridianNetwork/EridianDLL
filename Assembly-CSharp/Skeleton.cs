using System;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x02000539 RID: 1337
public class Skeleton : MonoBehaviour
{
	// Token: 0x0600227D RID: 8829 RVA: 0x00017B5B File Offset: 0x00015D5B
	public void Awake()
	{
		this.method_3();
	}

	// Token: 0x0600227E RID: 8830 RVA: 0x000A3A54 File Offset: 0x000A1C54
	private string method_0(WeaponType weaponType_0)
	{
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			return "smg";
		case WeaponType.SniperRifle:
			return "sniper";
		case WeaponType.ShotGun:
			return "shotgun";
		case WeaponType.RepeaterPistol:
			return "rep";
		case WeaponType.CombatRifle:
			return "rifle";
		default:
			DebugUtils.LogError(LogCategory.Animation, "Invalid Weapon Node Type: " + weaponType_0.ToString());
			return "Invalid";
		}
	}

	// Token: 0x0600227F RID: 8831 RVA: 0x000A3ABC File Offset: 0x000A1CBC
	private string method_1(WeaponType weaponType_0)
	{
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			return "smg";
		case WeaponType.SniperRifle:
			return "sniper";
		case WeaponType.ShotGun:
			return "shotgun";
		case WeaponType.RepeaterPistol:
			return "pistol";
		case WeaponType.CombatRifle:
			return "rifle";
		default:
			DebugUtils.LogError(LogCategory.Animation, "Invalid Weapon Node Type: " + weaponType_0.ToString());
			return "Invalid";
		}
	}

	// Token: 0x06002280 RID: 8832 RVA: 0x000A3B24 File Offset: 0x000A1D24
	private void method_2(EntityNpc entityNpc_0)
	{
		this.m_head = entityNpc_0.m_headTransform;
		if (entityNpc_0.m_rightHandWeaponSlot != null)
		{
			this.m_weapons[0] = entityNpc_0.m_rightHandWeaponSlot;
			if (entityNpc_0.m_leftHandWeaponSlot != null)
			{
				this.m_weapons[1] = entityNpc_0.m_leftHandWeaponSlot;
			}
			return;
		}
	}

	// Token: 0x06002281 RID: 8833 RVA: 0x000A3B78 File Offset: 0x000A1D78
	private void method_3()
	{
		if (base.transform == null)
		{
			return;
		}
		m_npcEntity = GetComponent<EntityNpc>();
		if (m_npcEntity != null)
		{
			method_2(m_npcEntity);
			return;
		}
		Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			string text = transform.gameObject.name.ToLower();
			if (m_head == null)
			{
				switch (text)
				{
				case "bip01 head":
				case "export_head":
				case "out_head":
					m_head = transform;
					continue;
				}
			}
			if (text.ToLower().Contains("classmode_host_"))
			{
				string s = text.ToLower().Substring(text.ToLower().LastIndexOf("_") + 1);
				int num = int.Parse(s) - 1;
				if (num >= 0 && num < m_classModeNode.Length)
				{
					m_classModeNode[num] = transform;
					continue;
				}
			}
			for (int j = 0; j < 5; j++)
			{
				if (m_offhandWeapons[j] == null)
				{
					string text2 = method_1((WeaponType)j);
					if (text == "export_" + text2 + "placehold")
					{
						m_offhandWeapons[j] = transform;
						break;
					}
				}
			}
			int k;
			for (k = 0; k < 5; k++)
			{
				if (m_weapons[k] == null)
				{
					string text3 = method_0((WeaponType)k);
					if (text == "bip01 r hand_" + text3 || text == "export_ r_hand_" + text3 || text == "export_r_hand_" + text3)
					{
						m_weapons[k] = transform;
						break;
					}
				}
			}
			if (k >= 5)
			{
				if (m_firstPersonCamera == null && text == "camera")
				{
					m_firstPersonCamera = transform;
				}
				else if (m_firstPersonPitch == null && text.Contains("hands_chr_"))
				{
					m_firstPersonPitch = transform;
				}
				else if (m_firstPersonRealPitch == null && text == "export_hips")
				{
					m_firstPersonRealPitch = transform;
				}
				else if (m_firstPersonPitchAdjuster == null && text == "hipsadjuster")
				{
					m_firstPersonPitchAdjuster = transform;
				}
			}
		}
	}
	// Token: 0x06002282 RID: 8834 RVA: 0x000A3DE8 File Offset: 0x000A1FE8
	public Transform method_4(WeaponType weaponType_0)
	{
		if (this.m_npcEntity != null)
		{
			EntityNpcSoldierTurret entityNpcSoldierTurret = this.m_npcEntity as EntityNpcSoldierTurret;
			if (entityNpcSoldierTurret != null)
			{
				return entityNpcSoldierTurret.method_22(weaponType_0);
			}
			if (this.m_npcEntity.m_rightHandWeaponSlot != null)
			{
				return this.m_weapons[0];
			}
		}
		return this.m_weapons[(int)weaponType_0];
	}

	// Token: 0x06002283 RID: 8835 RVA: 0x00017B63 File Offset: 0x00015D63
	public Transform method_5(WeaponType weaponType_0)
	{
		if (weaponType_0 < (WeaponType)this.m_offhandWeapons.Length)
		{
			return this.m_offhandWeapons[(int)weaponType_0];
		}
		return null;
	}

	// Token: 0x06002284 RID: 8836 RVA: 0x00017B7A File Offset: 0x00015D7A
	public Transform method_6(ClassModeType classModeType_0)
	{
		if ((int)classModeType_0 % 2 < m_classModeNode.Length)
		{
			return m_classModeNode[(int)classModeType_0 % 2];
		}
		return null;
	}
	// Token: 0x06002285 RID: 8837 RVA: 0x00017B95 File Offset: 0x00015D95
	public Transform method_7()
	{
		return this.m_head;
	}

	// Token: 0x06002286 RID: 8838 RVA: 0x00017B9D File Offset: 0x00015D9D
	public Transform method_8()
	{
		return this.m_firstPersonCamera;
	}

	// Token: 0x06002287 RID: 8839 RVA: 0x00017BA5 File Offset: 0x00015DA5
	public Transform method_9()
	{
		return this.m_firstPersonPitch;
	}

	// Token: 0x06002288 RID: 8840 RVA: 0x00017BAD File Offset: 0x00015DAD
	public Transform method_10()
	{
		return this.m_firstPersonPitchAdjuster;
	}

	// Token: 0x06002289 RID: 8841 RVA: 0x00017BB5 File Offset: 0x00015DB5
	public Transform method_11()
	{
		return this.m_firstPersonRealPitch;
	}

	// Token: 0x040016E0 RID: 5856
	private Transform m_head;

	// Token: 0x040016E1 RID: 5857
	private Transform[] m_weapons = new Transform[5];

	// Token: 0x040016E2 RID: 5858
	private EntityNpc m_npcEntity;

	// Token: 0x040016E3 RID: 5859
	private Transform[] m_offhandWeapons = new Transform[5];

	// Token: 0x040016E4 RID: 5860
	private Transform[] m_classModeNode = new Transform[2];

	// Token: 0x040016E5 RID: 5861
	private Transform m_firstPersonCamera;

	// Token: 0x040016E6 RID: 5862
	private Transform m_firstPersonPitch;

	// Token: 0x040016E7 RID: 5863
	private Transform m_firstPersonRealPitch;

	// Token: 0x040016E8 RID: 5864
	private Transform m_firstPersonPitchAdjuster;
}
