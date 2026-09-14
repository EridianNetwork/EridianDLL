using System;
using System.Collections;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200013B RID: 315
public class AvatarGeneratorService : MonoBehaviour
{
	// Token: 0x06000742 RID: 1858 RVA: 0x000560EC File Offset: 0x000542EC
	public IEnumerator method_0(GameObject gameObject_0, WeaponDNA weaponDNA_0, byte byte_0 = 0, bool bool_0 = false)
	{
		BuildingKitRender kitRender = weaponDNA_0.method_1() switch
		{
			WeaponType.SMG => new BuildingKitRender("WPN", "SMG"), 
			WeaponType.SniperRifle => new BuildingKitRender("WPN", "SniperRifle"), 
			WeaponType.ShotGun => new BuildingKitRender("WPN", "ShotGun"), 
			WeaponType.RepeaterPistol => new BuildingKitRender("WPN", "RepeaterPistol"), 
			WeaponType.CombatRifle => new BuildingKitRender("WPN", "CombatRifle"), 
			_ => new BuildingKitRender("WPN", "SMG"), 
		};
		kitRender.BuildingUnit_0 = weaponDNA_0.method_14();
		if (kitRender.BuildingUnit_0.mMats != null && kitRender.BuildingUnit_0.mMats.Count > 0)
		{
			byte_0 = kitRender.BuildingUnit_0.mMats[kitRender.BuildingUnit_0.mMats.Count - 1];
		}
		for (int j = 0; j < kitRender.method_9(); j++)
		{
			kitRender.method_13(j, byte_0);
		}
		yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(kitRender.method_16()));
		GameObject myWeapon = kitRender.method_6();
		EntityWeapon.smethod_2(myWeapon, EntityWeapon.smethod_1(weaponDNA_0.m_attribute));
		Rigidbody body = myWeapon.GetComponent<Rigidbody>();
		if (body != null)
		{
			UnityEngine.Object.Destroy(body);
		}
		Collider coll = GetComponent<Collider>();
		if (coll != null)
		{
			coll.enabled = false;
		}
		Transform weaponNode = null;
		Transform[] allBones = gameObject_0.gameObject.transform.GetComponentsInChildren<Transform>();
		for (int i = 0; i < allBones.Length; i++)
		{
			if (method_1(allBones[i].gameObject.name.ToLower(), weaponDNA_0.m_type, bool_0))
			{
				weaponNode = allBones[i];
				break;
			}
		}
		if (weaponNode != null)
		{
			myWeapon.transform.parent = weaponNode;
			myWeapon.transform.localPosition = Vector3.zero;
			myWeapon.transform.localRotation = Quaternion.identity;
			myWeapon.transform.localScale = Vector3.one;
			myWeapon.transform.Rotate(new Vector3(90f, 0f, 0f));
		}
		else
		{
			DebugUtils.LogError(LogCategory.Framework, "Weapon Node Not Find!");
		}
	}
	// Token: 0x06000743 RID: 1859 RVA: 0x00056144 File Offset: 0x00054344
	private bool method_1(string string_0, WeaponType weaponType_0, bool bool_0)
	{
		string text = string.Empty;
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			text = "smg";
			break;
		case WeaponType.SniperRifle:
			text = "sniper";
			if (bool_0)
			{
				text += "_ui";
			}
			break;
		case WeaponType.ShotGun:
			text = "shotgun";
			break;
		case WeaponType.RepeaterPistol:
			text = "rep";
			break;
		case WeaponType.CombatRifle:
			text = "rifle";
			break;
		}
		return string_0 == "bip01 r hand_" + text || string_0 == "export_ r_hand_" + text || string_0 == "export_r_hand_" + text;
	}
}
