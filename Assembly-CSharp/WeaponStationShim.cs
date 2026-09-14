using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000C55 RID: 3157
public static class WeaponStationShim
{
	// Token: 0x060052EF RID: 21231 RVA: 0x00155618 File Offset: 0x00153818
	public static void EnsureCreated()
	{
		if (GameObject.Find("WeaponcraftingCameraRoot") == null)
		{
			GameObject gameObject = new GameObject("WeaponcraftingCameraRoot");
			gameObject.transform.position = WeaponStationShim.StationPosition;
			gameObject.AddComponent<Animator>();
			GameObject gameObject2 = new GameObject("WeaponcraftingCamera");
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localPosition = new Vector3(0f, 1.5f, -2f);
			gameObject2.AddComponent<Camera>();
			gameObject2.SetActive(false);
		}
		if (GameObject.Find("PRO_WeaponUpgrade") == null)
		{
			GameObject gameObject3 = new GameObject("PRO_WeaponUpgrade");
			gameObject3.transform.position = WeaponStationShim.StationPosition + new Vector3(3f, 0f, 0f);
			GameObject gameObject4 = new GameObject("WeaponupgradeCamera");
			gameObject4.transform.parent = gameObject3.transform;
			gameObject4.transform.localPosition = new Vector3(0f, 1.5f, -2f);
			gameObject4.AddComponent<Camera>();
			gameObject4.SetActive(false);
			string[] array = new string[] { "WPN_COR_ground", "WPN_SHN_ground", "WPN_SMG_ground", "WPN_SNR_ground" };
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject5 = new GameObject(array[i]);
				gameObject5.transform.parent = gameObject3.transform;
				gameObject5.transform.localPosition = Vector3.zero;
			}
			string[] array2 = new string[] { "PTL_Weapon_Upgrade_Default", "PTL_Weapon_Upgrade_Failure", "PTL_Weapon_Upgrade_Success" };
			for (int j = 0; j < array2.Length; j++)
			{
				GameObject gameObject6 = new GameObject(array2[j]);
				gameObject6.transform.parent = gameObject3.transform;
				gameObject6.transform.localPosition = Vector3.zero;
				gameObject6.AddComponent<ParticleSystem>();
				gameObject6.SetActive(false);
			}
		}
	}

	// Token: 0x060052F1 RID: 21233 RVA: 0x001557FC File Offset: 0x001539FC
	public static bool TryForceInstanceReady()
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			if (!WeaponStationShim.s_loggedNoSession)
			{
				WeaponStationShim.s_loggedNoSession = true;
				DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] TryForceInstanceReady: Session.Instance is null");
			}
			return false;
		}
		if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
		{
			if (!WeaponStationShim.s_loggedReady)
			{
				WeaponStationShim.s_loggedReady = true;
				DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] TryForceInstanceReady: GetLocalPlayer() now non-null");
			}
			return true;
		}
		if (!WeaponStationShim.s_loggedRequested)
		{
			WeaponStationShim.s_loggedRequested = true;
			DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] TryForceInstanceReady: calling Session.OnGoToInstance()");
		}
		MonoSingleton<Session>.Instance.OnGoToInstance();
		return false;
	}

	// Token: 0x060052F2 RID: 21234 RVA: 0x00155880 File Offset: 0x00153A80
	public static bool TryPatchCraftingStation()
	{
		if (InteractionManager.InteractionManager_0 == null)
		{
			if (!WeaponStationShim.s_loggedNoInteractionMgr)
			{
				WeaponStationShim.s_loggedNoInteractionMgr = true;
				DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] TryPatchCraftingStation: InteractionManager_0 is null, retrying");
			}
			return false;
		}
		TownNpc[] array = (TownNpc[])global::UnityEngine.Object.FindObjectsOfType(typeof(TownNpc));
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].m_npcId == 12)
			{
				return true;
			}
		}
		bool flag = false;
		int num = 0;
		Transform[] array2 = (Transform[])global::UnityEngine.Object.FindObjectsOfType(typeof(Transform));
		if (!WeaponStationShim.s_loggedScan)
		{
			WeaponStationShim.s_loggedScan = true;
			DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] TryPatchCraftingStation: scanning " + array2.Length.ToString() + " transforms for \"weapon_crafting\"");
		}
		for (int j = 0; j < array2.Length; j++)
		{
			if (array2[j].gameObject.name == "weapon_crafting")
			{
				num++;
				if (array2[j].gameObject.GetComponent<TownNpc>() == null)
				{
					GameObject gameObject = array2[j].gameObject;
					if (gameObject.GetComponent<Collider>() == null)
					{
						BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
						boxCollider.size = new Vector3(2.5f, 2.5f, 2.5f);
						boxCollider.center = new Vector3(0f, 1.2f, 0f);
					}
					gameObject.AddComponent<TownNpc>().m_npcId = 12;
					flag = true;
				}
			}
		}
		if (flag && !WeaponStationShim.s_loggedPatched)
		{
			WeaponStationShim.s_loggedPatched = true;
			DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] TryPatchCraftingStation: found " + num.ToString() + " \"weapon_crafting\" object(s), patched them with TownNpc");
		}
		return flag;
	}

	// Token: 0x04003D26 RID: 15654
	private static readonly Vector3 StationPosition = new Vector3(-169.64f, -16.191f, -32.394f);

	// Token: 0x04003D27 RID: 15655
	private const int CraftingNpcId = 12;

	// Token: 0x04003D28 RID: 15656
	private static bool s_loggedNoSession;

	// Token: 0x04003D29 RID: 15657
	private static bool s_loggedRequested;

	// Token: 0x04003D2A RID: 15658
	private static bool s_loggedReady;

	// Token: 0x04003D2B RID: 15659
	private static bool s_loggedNoInteractionMgr;

	// Token: 0x04003D2C RID: 15660
	private static bool s_loggedScan;

	// Token: 0x04003D2D RID: 15661
	private static bool s_loggedPatched;
}
