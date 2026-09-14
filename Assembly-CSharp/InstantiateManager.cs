using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000AB4 RID: 2740
public class InstantiateManager : MonoSingleton<InstantiateManager>
{
	// Token: 0x17000780 RID: 1920
	// (get) Token: 0x06004A65 RID: 19045 RVA: 0x00030AC0 File Offset: 0x0002ECC0
	public List<GameObject> List_0
	{
		get
		{
			return this.m_instantiateObject;
		}
	}

	// Token: 0x06004A66 RID: 19046 RVA: 0x00135324 File Offset: 0x00133524
	protected override void Awake()
	{
		base.Awake();
		this.m_instantiateObject = new List<GameObject>();
		this.m_itstantiateObjectDic.Clear();
		foreach (BuildingKitTableUnit buildingKitTableUnit in BuildingKitManager.BuildingKitTable_0.bkTable)
		{
			string text = buildingKitTableUnit.filePath.Split(new char[] { '/' })[1];
			text = text.Replace('_', '|');
			this.m_itstantiateObjectDic.Add(text);
		}
		this.m_itstantiateObjectDic.Add("Entities/Object/Weapon/Weapon");
		this.m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Pack_HP_P");
		this.m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_SMG_P");
		this.m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_Sniper_P");
		this.m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_RepeaterPistol_P");
		this.m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_Grenade_P");
		this.m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Cash_P");
		this.m_itstantiateObjectDic.Add("Entities/Object/Item/Claptrap");
		this.m_itstantiateObjectDic.Add("Entities/Object/Launchable/Grenade");
		this.m_itstantiateObjectDic.Add("Session");
		this.m_itstantiateObjectDic.Add("LevelObjectManager");
		this.m_itstantiateObjectDic.Add("Player");
		this.m_itstantiateObjectDic.Add("Entities/Object/ExplosiveDestructibleObj/ExposiveDestructible_BarrelXML");
		this.m_itstantiateObjectDic.Add("Entities/Player_Mecanim/CHR_Player_Root");
		this.m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Siren/CHR_Town_Siren_Root");
		this.m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Siren/CHR_Siren_Root");
		this.m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Soldier/CHR_Town_Soldier_Root");
		this.m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Soldier/CHR_Soldier_Root");
		this.m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Berserker/CHR_Town_Berserker_Root");
		this.m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Berserker/CHR_Berserker_Root");
		this.m_itstantiateObjectDic.Sort();
	}

	// Token: 0x06004A67 RID: 19047 RVA: 0x00030AC8 File Offset: 0x0002ECC8
	public void method_0(InstantiateManager.SpawnRequest spawnRequest_0)
	{
		this.m_waitingSpawningRequest.Add(spawnRequest_0);
	}

	// Token: 0x06004A68 RID: 19048 RVA: 0x00030AD6 File Offset: 0x0002ECD6
	public void method_1(GameObject gameObject_0)
	{
		this.m_instantiateObject.Add(gameObject_0);
	}

	// Token: 0x06004A69 RID: 19049 RVA: 0x00030AE4 File Offset: 0x0002ECE4
	public void method_2(GameObject gameObject_0)
	{
		this.m_instantiateObject.Remove(gameObject_0);
	}

	// Token: 0x06004A6A RID: 19050 RVA: 0x0013550C File Offset: 0x0013370C
	public EntityWeapon method_3(WeaponDNA weaponDNA_0, Vector3 vector3_0, Quaternion quaternion_0, bool bool_0)
	{
		EntityWeapon entityWeapon;
		if (bool_0)
		{
			entityWeapon = (EntityWeapon)this.method_6(ItemDNA.smethod_2(weaponDNA_0), vector3_0, quaternion_0, Vector3.zero, -1, -1, 0, 0);
		}
		else
		{
			string text = ItemGeneratorService.smethod_1(ItemType.Weapon);
			GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text), vector3_0, quaternion_0);
			entityWeapon = gameObject.GetComponent<EntityWeapon>();
		}
		entityWeapon.method_16(weaponDNA_0);
		return entityWeapon;
	}

	// Token: 0x06004A6B RID: 19051 RVA: 0x00135568 File Offset: 0x00133768
	public EntityShield method_4(Vector3 vector3_0, Quaternion quaternion_0, bool bool_0)
	{
		EntityShield entityShield;
		if (bool_0)
		{
			entityShield = (EntityShield)this.method_6(ItemDNA.smethod_6(), vector3_0, quaternion_0, Vector3.zero, -1, -1, 0, 0);
		}
		else
		{
			string text = ItemGeneratorService.smethod_1(ItemType.Shield);
			GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text), vector3_0, quaternion_0);
			entityShield = gameObject.GetComponent<EntityShield>();
		}
		return entityShield;
	}

	// Token: 0x06004A6C RID: 19052 RVA: 0x001355BC File Offset: 0x001337BC
	public EntityClassMode method_5(ItemDNA itemDNA_0, Vector3 vector3_0, Quaternion quaternion_0, bool bool_0)
	{
		EntityClassMode entityClassMode;
		if (bool_0)
		{
			entityClassMode = (EntityClassMode)this.method_6(ItemDNA.smethod_8(itemDNA_0.method_8()), vector3_0, quaternion_0, Vector3.zero, -1, -1, 0, 0);
		}
		else
		{
			string text = ItemGeneratorService.smethod_0(itemDNA_0);
			GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text), vector3_0, quaternion_0);
			entityClassMode = gameObject.GetComponent<EntityClassMode>();
		}
		entityClassMode.method_16(itemDNA_0.method_8());
		return entityClassMode;
	}

	// Token: 0x06004A6D RID: 19053 RVA: 0x00135624 File Offset: 0x00133824
	public EntityObject method_6(ItemDNA itemDNA_0, Vector3 vector3_0, Quaternion quaternion_0, Vector3 vector3_1, int int_0 = -1, int int_1 = -1, int int_2 = 0, int int_3 = 0)
	{
		EntityObject entityObject = null;
		if (itemDNA_0 != null)
		{
			string text = ItemGeneratorService.smethod_0(itemDNA_0);
			object[] array = new object[] { itemDNA_0, vector3_1, int_0, int_1, int_2, int_3 };
			GameObject gameObject;
			if (MonoSingleton<Session>.Instance.method_16())
			{
				gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text), vector3_0, quaternion_0);
			}
			else
			{
				gameObject = PhotonNetwork.Instantiate(text, vector3_0, quaternion_0, 2, array);
			}
			entityObject = gameObject.GetComponent<EntityObject>();
		}
		return entityObject;
	}

	// Token: 0x06004A6E RID: 19054 RVA: 0x001356B0 File Offset: 0x001338B0
	public void method_7(PhotonPlayer photonPlayer_0)
	{
		object[] array = new object[]
		{
			photonPlayer_0.ActorId,
			photonPlayer_0.String_0,
			(!photonPlayer_0.customProperties.ContainsKey("AccountId")) ? (-1) : photonPlayer_0.customProperties["AccountId"],
			(!photonPlayer_0.customProperties.ContainsKey("CharacterId")) ? (-1) : photonPlayer_0.customProperties["CharacterId"],
			0
		};
		GameObject gameObject = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0, array);
		PlayerInfoSync component = gameObject.GetComponent<PlayerInfoSync>();
		component.method_3(array, photonPlayer_0);
	}

	// Token: 0x06004A6F RID: 19055 RVA: 0x00135764 File Offset: 0x00133964
	private void FixedUpdate()
	{
		if (this.m_waitingSpawningRequest.Count > 0)
		{
			InstantiateManager.SpawnRequest spawnRequest = this.m_waitingSpawningRequest[0];
			this.m_waitingSpawningRequest.Remove(spawnRequest);
			GameObject gameObject;
			if (spawnRequest.m_isNetworkInstanciate)
			{
				gameObject = PhotonNetwork.Instantiate(spawnRequest.m_prefabName, spawnRequest.m_position, spawnRequest.m_rotation, (int)spawnRequest.m_group, spawnRequest.m_spawnData);
			}
			else
			{
				global::UnityEngine.Object @object = ResourcesLoader.smethod_0(spawnRequest.m_prefabName);
				gameObject = (GameObject)global::UnityEngine.Object.Instantiate(@object, spawnRequest.m_position, spawnRequest.m_rotation);
			}
			if (spawnRequest.m_caller != null)
			{
				if (gameObject != null)
				{
					spawnRequest.m_caller.OnInstanciate(gameObject, spawnRequest);
				}
				else
				{
					DebugUtils.LogError(LogCategory.System, "We have a problem");
				}
			}
		}
	}

	// Token: 0x06004A70 RID: 19056 RVA: 0x00030AF3 File Offset: 0x0002ECF3
	public int method_8()
	{
		return this.m_waitingSpawningRequest.Count;
	}

	// Token: 0x04003621 RID: 13857
	public List<string> m_itstantiateObjectDic = new List<string>();

	// Token: 0x04003622 RID: 13858
	private List<GameObject> m_instantiateObject;

	// Token: 0x04003623 RID: 13859
	private List<InstantiateManager.SpawnRequest> m_waitingSpawningRequest = new List<InstantiateManager.SpawnRequest>();

	// Token: 0x02000AB5 RID: 2741
	public interface InstanciationClient
	{
		// Token: 0x06004A71 RID: 19057
		void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request);
	}

	// Token: 0x02000AB6 RID: 2742
	public enum NetworkReplicationGroup
	{
		// Token: 0x04003625 RID: 13861
		Lobby,
		// Token: 0x04003626 RID: 13862
		StaticSync,
		// Token: 0x04003627 RID: 13863
		DynamicSync,
		// Token: 0x04003628 RID: 13864
		InGame
	}

	// Token: 0x02000AB7 RID: 2743
	public struct SpawnRequest
	{
		// Token: 0x04003629 RID: 13865
		public bool m_isNetworkInstanciate;

		// Token: 0x0400362A RID: 13866
		public string m_prefabName;

		// Token: 0x0400362B RID: 13867
		public Vector3 m_position;

		// Token: 0x0400362C RID: 13868
		public Quaternion m_rotation;

		// Token: 0x0400362D RID: 13869
		public InstantiateManager.NetworkReplicationGroup m_group;

		// Token: 0x0400362E RID: 13870
		public object[] m_spawnData;

		// Token: 0x0400362F RID: 13871
		public object[] m_callbackData;

		// Token: 0x04003630 RID: 13872
		public InstantiateManager.InstanciationClient m_caller;
	}
}
