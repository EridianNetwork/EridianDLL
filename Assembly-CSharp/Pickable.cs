using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020004A2 RID: 1186
[RequireComponent(typeof(EntityObject))]
public class Pickable : MonoBehaviour, InteractionClient
{
	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x06001FB5 RID: 8117 RVA: 0x00015FAB File Offset: 0x000141AB
	// (set) Token: 0x06001FB6 RID: 8118 RVA: 0x00015FB3 File Offset: 0x000141B3
	public bool m_spinningToOwner { get; private set; }

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x06001FB7 RID: 8119 RVA: 0x00015FBC File Offset: 0x000141BC
	// (set) Token: 0x06001FB8 RID: 8120 RVA: 0x00015FC4 File Offset: 0x000141C4
	public EntityObject m_entity { get; private set; }

	// Token: 0x06001FB9 RID: 8121 RVA: 0x00015FCD File Offset: 0x000141CD
	private void Awake()
	{
		this.m_isReady = false;
		this.m_isPickable = false;
		this.m_isPicked = false;
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x0009B62C File Offset: 0x0009982C
	private void Start()
	{
		this.m_entity = base.GetComponent<EntityObject>();
		if (this.m_entity == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "m_entity should not be null in Pickable");
		}
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_0(this);
		}
		this.m_entity.tag = "Item";
		object[] array = this.m_entity.vmethod_7();
		if (array != null)
		{
			this.m_dna = array[0] as ItemDNA;
			this.m_velocity = (Vector3)array[1];
			this.m_attachId = (int)array[3];
			this.m_numWeaponSpawned = (int)array[4];
			this.m_numItemSpawned = (int)array[5];
		}
		else
		{
			EntityWeapon entityWeapon = this.m_entity as EntityWeapon;
			if (entityWeapon)
			{
				this.m_dna = ItemDNA.smethod_2(entityWeapon.method_17());
			}
		}
		if (this.m_dna == null && this.m_entity.m_subType == EntityObject.EntitySubType.Claptrap)
		{
			this.m_dna = ItemDNA.smethod_10();
		}
	}

	// Token: 0x06001FBB RID: 8123 RVA: 0x0009B724 File Offset: 0x00099924
	private void Update()
	{
		if (!this.m_isReady)
		{
			if (this.m_entity.vmethod_62())
			{
				this.m_isReady = true;
				this.OnReady();
			}
		}
		else if (this.m_spinningToOwner)
		{
			this.method_7();
		}
		if (this.m_pickableTimer > 0f)
		{
			this.m_pickableTimer -= Time.deltaTime;
			if (this.m_pickableTimer <= 0f)
			{
				this.method_1(true);
			}
		}
		if (this.m_lightPillarTimer > 0f)
		{
			this.m_lightPillarTimer -= Time.deltaTime;
			if (this.m_lightPillarTimer <= 0f)
			{
				this.method_2();
			}
		}
	}

	// Token: 0x06001FBC RID: 8124 RVA: 0x0009B7C8 File Offset: 0x000999C8
	private void OnReady()
	{
		if (this.m_entity.m_owner == null)
		{
			if (this.m_attachId == -1)
			{
				this.m_entity.vmethod_66(this.m_entity.transform.position, this.m_entity.transform.rotation, this.m_velocity);
			}
			else
			{
				this.method_4();
				if (this.m_lightPillarTimer == 0f)
				{
					this.method_2();
				}
				if (this.m_pickableTimer == 0f)
				{
					this.method_1(true);
				}
			}
		}
	}

	// Token: 0x06001FBD RID: 8125 RVA: 0x00015FE4 File Offset: 0x000141E4
	private void OnDestroy()
	{
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_1(this);
		}
	}

	// Token: 0x06001FBE RID: 8126 RVA: 0x00015FFD File Offset: 0x000141FD
	private void OnCollisionEnter(Collision collision)
	{
		if (!this.m_isPickable && this.m_pickableTimer <= 0f)
		{
			this.method_1(true);
		}
	}

	// Token: 0x06001FBF RID: 8127 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnOwnerChanged()
	{
	}

	// Token: 0x06001FC0 RID: 8128 RVA: 0x0001601B File Offset: 0x0001421B
	public ItemDNA method_0()
	{
		return this.m_dna;
	}

	// Token: 0x06001FC1 RID: 8129 RVA: 0x00016023 File Offset: 0x00014223
	private void method_1(bool bool_0)
	{
		if (bool_0 != this.m_isPickable)
		{
			this.m_isPickable = bool_0;
		}
	}

	// Token: 0x06001FC2 RID: 8130 RVA: 0x00016035 File Offset: 0x00014235
	private void method_2()
	{
		if (MonoSingleton<Session>.Instance && MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			Pickable.LightPillarManager.LightPillarManager_0.method_5(this.m_entity);
		}
	}

	// Token: 0x06001FC3 RID: 8131 RVA: 0x00016064 File Offset: 0x00014264
	private void method_3()
	{
		if (MonoSingleton<Session>.Instance && MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			Pickable.LightPillarManager.LightPillarManager_0.method_4(this.m_entity);
		}
	}

	// Token: 0x06001FC4 RID: 8132 RVA: 0x0009B854 File Offset: 0x00099A54
	public void method_4()
	{
		LevelObjectSync levelObjectSync = LevelObjectSyncManager.LevelObjectSyncManager_0.method_4(this.m_attachId);
		if (levelObjectSync != null)
		{
			LootingTable component = levelObjectSync.GetComponent<LootingTable>();
			if (component)
			{
				GameObject gameObject = component.method_1(this.method_0().m_type, this.m_numWeaponSpawned, this.m_numItemSpawned);
				if (gameObject != null)
				{
					base.transform.parent = gameObject.transform;
					base.transform.localPosition = Vector3.zero;
					base.transform.localRotation = Quaternion.identity;
					LootingSlot component2 = gameObject.GetComponent<LootingSlot>();
					this.m_lightPillarTimer = component2.m_lootLightPillarDelay;
					this.m_pickableTimer = component2.m_lootPickableDelay;
				}
			}
		}
	}

	// Token: 0x06001FC5 RID: 8133 RVA: 0x00016093 File Offset: 0x00014293
	public void OnDrop()
	{
		this.method_2();
	}

	// Token: 0x06001FC6 RID: 8134 RVA: 0x0001609B File Offset: 0x0001429B
	public void OnPick()
	{
		this.method_3();
	}

	// Token: 0x06001FC7 RID: 8135 RVA: 0x0009B904 File Offset: 0x00099B04
	public bool method_5()
	{
		return this.m_isPickable && this.m_entity != null && this.m_entity.vmethod_62() && this.m_entity.gameObject.activeSelf && this.m_entity.m_owner == null;
	}

	// Token: 0x06001FC8 RID: 8136 RVA: 0x000160A3 File Offset: 0x000142A3
	public Vector3 imethod_0()
	{
		return this.m_entity.gameObject.transform.position;
	}

	// Token: 0x06001FC9 RID: 8137 RVA: 0x0009B95C File Offset: 0x00099B5C
	public bool imethod_2(Ray ray_0, ref float float_0)
	{
		CollisionManager collisionManager = this.m_entity.vmethod_21();
		if (collisionManager != null)
		{
			RaycastHit raycastHit;
			if (collisionManager.method_2(ray_0, out raycastHit, ref float_0))
			{
				return true;
			}
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "No interaction possible with " + base.name + " as it has no CollisionManager component!");
		}
		return false;
	}

	// Token: 0x06001FCA RID: 8138 RVA: 0x000039EC File Offset: 0x00001BEC
	public virtual bool imethod_4()
	{
		return true;
	}

	// Token: 0x06001FCB RID: 8139 RVA: 0x000160BA File Offset: 0x000142BA
	public virtual E_USE_TYPE imethod_6()
	{
		if (this.m_autoPickup)
		{
			return E_USE_TYPE.E_NONE;
		}
		return E_USE_TYPE.E_PICKUP;
	}

	// Token: 0x06001FCC RID: 8140 RVA: 0x000160C7 File Offset: 0x000142C7
	public virtual bool imethod_3(Entity entity_0)
	{
		return this.method_5();
	}

	// Token: 0x06001FCD RID: 8141 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void imethod_5(Entity entity_0, bool bool_0 = false)
	{
	}

	// Token: 0x06001FCE RID: 8142 RVA: 0x000160CF File Offset: 0x000142CF
	public void method_6(EntityPlayer entityPlayer_0)
	{
		this.m_spinningToOwner = true;
		this.m_entity.method_15(entityPlayer_0);
		this.m_entity.method_12(false);
		this.method_3();
	}

	// Token: 0x06001FCF RID: 8143 RVA: 0x0009B9A8 File Offset: 0x00099BA8
	public void method_7()
	{
		if ((this.m_entity.m_owner as EntityPlayer).vmethod_16() != this.m_entity)
		{
			if (this.m_entity.gameObject == null)
			{
				return;
			}
			if (this.m_entity.m_owner == null)
			{
				return;
			}
			if (this.m_entity.m_owner.gameObject == null)
			{
				return;
			}
			Vector3 vector = default(Vector3);
			vector = this.m_entity.m_owner.transform.position;
			vector.y += MonoSingleton<AppManager>.Instance.m_globalSettings.m_lootSpinningHeightOffset;
			vector -= this.m_entity.transform.position;
			float num = MonoSingleton<AppManager>.Instance.m_globalSettings.m_lootSpinningMoveSpeed * Time.deltaTime;
			this.m_entity.transform.position += vector.normalized * num;
			this.m_entity.transform.Rotate(Vector3.up, MonoSingleton<AppManager>.Instance.m_globalSettings.m_lootSpinningRotateSpeed * Time.deltaTime, Space.World);
			if (num >= vector.magnitude)
			{
				this.OnSpinningToOwnerFinished();
			}
		}
		else
		{
			this.m_spinningToOwner = false;
		}
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x0009BAF0 File Offset: 0x00099CF0
	public void OnSpinningToOwnerFinished()
	{
		BaseEventTriggerCtl component = this.m_entity.m_owner.GetComponent<BaseEventTriggerCtl>();
		if (component != null)
		{
			switch (this.m_entity.m_subType)
			{
			case EntityObject.EntitySubType.None:
			{
				ItemDNA itemDNA = this.method_0();
				if (itemDNA != null)
				{
					DebugUtils.LogError(LogCategory.System, "invalid Entity's \"Sub Type\": " + itemDNA.m_materialType.ToString());
				}
				else
				{
					DebugUtils.LogError(LogCategory.System, "invalid Entity's \"Sub Type\"");
				}
				break;
			}
			case EntityObject.EntitySubType.Weapon:
				component.vmethod_1(AudioEventName.Itm_Pickup_Gun);
				break;
			case EntityObject.EntitySubType.AmmoPack:
				component.vmethod_1(AudioEventName.Itm_Pickup_Ammo);
				break;
			case EntityObject.EntitySubType.HealthPack:
				component.vmethod_1(AudioEventName.Itm_Pickup_Hp);
				break;
			case EntityObject.EntitySubType.MoneyPack:
				component.vmethod_1(AudioEventName.Itm_Pickup_Cash);
				break;
			case EntityObject.EntitySubType.Shield:
				component.vmethod_1(AudioEventName.Itm_Pickup_Shield);
				break;
			case EntityObject.EntitySubType.Material:
			{
				ItemDNA itemDNA2 = this.method_0();
				component.TriggerEventByName("Itm_Pickup_" + itemDNA2.m_materialType.ToString().Substring(3));
				break;
			}
			case EntityObject.EntitySubType.ClassMode:
				component.vmethod_1(AudioEventName.Itm_Pickup_Class_Mod);
				break;
			}
		}
		this.m_spinningToOwner = false;
	}

	// Token: 0x0400147B RID: 5243
	public bool m_autoPickup;

	// Token: 0x0400147C RID: 5244
	private bool m_isReady;

	// Token: 0x0400147D RID: 5245
	private bool m_isPickable;

	// Token: 0x0400147E RID: 5246
	private Vector3 m_velocity = Vector3.zero;

	// Token: 0x0400147F RID: 5247
	private int m_attachId = -1;

	// Token: 0x04001480 RID: 5248
	private int m_numWeaponSpawned;

	// Token: 0x04001481 RID: 5249
	private int m_numItemSpawned;

	// Token: 0x04001482 RID: 5250
	private ItemDNA m_dna;

	// Token: 0x04001483 RID: 5251
	private float m_lightPillarTimer;

	// Token: 0x04001484 RID: 5252
	private float m_pickableTimer;

	// Token: 0x04001485 RID: 5253
	public bool m_isPicked;

	// Token: 0x020004A3 RID: 1187
	public class LightPillarManager
	{
		// Token: 0x06001FD1 RID: 8145 RVA: 0x0009BC10 File Offset: 0x00099E10
		protected LightPillarManager()
		{
			Pickable.LightPillarManager._mapItemColor = new Dictionary<ItemRarity, string>();
			Pickable.LightPillarManager._mapItemColor.Add(ItemRarity.Common, "White");
			Pickable.LightPillarManager._mapItemColor.Add(ItemRarity.Uncommon, "Green");
			Pickable.LightPillarManager._mapItemColor.Add(ItemRarity.Rare, "Blue");
			Pickable.LightPillarManager._mapItemColor.Add(ItemRarity.VeryRare, "Purple");
			Pickable.LightPillarManager._mapItemColor.Add(ItemRarity.Epic, "Pink");
			Pickable.LightPillarManager._mapItemColor.Add(ItemRarity.MetaEpic, "Orange");
			this._mapResources = new Dictionary<string, global::UnityEngine.Object>();
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06001FD2 RID: 8146 RVA: 0x000160F6 File Offset: 0x000142F6
		public static Pickable.LightPillarManager LightPillarManager_0
		{
			get
			{
				if (Pickable.LightPillarManager.s_instance == null)
				{
					Pickable.LightPillarManager.s_instance = new Pickable.LightPillarManager();
				}
				return Pickable.LightPillarManager.s_instance;
			}
		}

		// Token: 0x06001FD3 RID: 8147 RVA: 0x0001610E File Offset: 0x0001430E
		public void method_0()
		{
			this._mapResources.Clear();
		}

		// Token: 0x06001FD4 RID: 8148 RVA: 0x0009BC98 File Offset: 0x00099E98
		public static string smethod_0(EntityObject entityObject_0)
		{
			string empty = string.Empty;
			switch (entityObject_0.method_13().m_type)
			{
			case ItemType.HealthPack:
				return "Red";
			case ItemType.Weapon:
			{
				ItemRarity rarity = (ItemRarity)(entityObject_0 as EntityWeapon).method_17().m_rarity;
				return Pickable.LightPillarManager._mapItemColor[rarity];
			}
			case ItemType.Ammo:
			case ItemType.Material:
			case ItemType.AmmoPack:
				return "White";
			case ItemType.Shield:
				return Pickable.LightPillarManager._mapItemColor[(entityObject_0 as EntityShield).method_19().m_rarity];
			case ItemType.ClassMode:
				return Pickable.LightPillarManager._mapItemColor[(entityObject_0 as EntityClassMode).method_17().m_rarity];
			}
			return "Yellow";
		}

		// Token: 0x06001FD5 RID: 8149 RVA: 0x0001611B File Offset: 0x0001431B
		public void method_1(object object_0 = null)
		{
			this._mapResources.Clear();
			if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				this.method_2("light_pillar_cl.assetbundle");
			}
			this.method_2("light_pillar.assetbundle");
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x0009BD54 File Offset: 0x00099F54
		private void method_2(string string_0)
		{
			BaseAssetBundle baseAssetBundle = MonoSingleton<AssetBundleManager>.Instance.method_8(string_0);
			if (baseAssetBundle == null)
			{
				return;
			}
			global::UnityEngine.Object[] array = baseAssetBundle.vmethod_3();
			if (array == null)
			{
				return;
			}
			foreach (global::UnityEngine.Object @object in array)
			{
				if (@object is GameObject)
				{
					this._mapResources.Add(@object.name, @object);
				}
			}
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x0001614A File Offset: 0x0001434A
		protected global::UnityEngine.Object method_3(string string_0)
		{
			if (!this._mapResources.ContainsKey(string_0))
			{
				DebugUtils.LogError(LogCategory.GUI, "Light pillor resource doesn't exist! Name: " + string_0);
				return null;
			}
			return this._mapResources[string_0];
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x0009BDA8 File Offset: 0x00099FA8
		public void method_4(EntityObject entityObject_0)
		{
			if (entityObject_0 == null)
			{
				return;
			}
			Transform transform = entityObject_0.gameObject.transform.FindChild("LightPillor");
			if (transform == null)
			{
				return;
			}
			transform.parent = null;
			CollisionManager collisionManager = entityObject_0.vmethod_21();
			if (collisionManager)
			{
				collisionManager.method_8(transform.GetComponent<Collider>());
			}
			global::UnityEngine.Object.DestroyObject(transform.gameObject);
		}

		// Token: 0x06001FD9 RID: 8153 RVA: 0x0009BE0C File Offset: 0x0009A00C
		public void method_5(EntityObject entityObject_0)
		{
			if (entityObject_0 == null)
			{
				return;
			}
			GameObject gameObject = null;
			Transform transform = entityObject_0.gameObject.transform.FindChild("LightPillor");
			if (transform != null)
			{
				gameObject = transform.gameObject;
			}
			else
			{
				string text = Pickable.LightPillarManager.smethod_0(entityObject_0);
				string text2 = "PTL_Light_Pillar_" + text;
				global::UnityEngine.Object @object = this.method_3(text2);
				if (@object)
				{
					gameObject = global::UnityEngine.Object.Instantiate(@object) as GameObject;
				}
				else
				{
					DebugUtils.Log(LogCategory.GUI, "Could Not load Light Pillar: " + text2);
				}
			}
			if (gameObject)
			{
				gameObject.layer = LayerMask.NameToLayer("diegeticUI");
				gameObject.name = "LightPillor";
				gameObject.transform.parent = entityObject_0.gameObject.transform;
				gameObject.transform.transform.localPosition = Vector3.zero;
				gameObject.transform.transform.localRotation = Quaternion.identity;
				gameObject.transform.transform.localScale = Vector3.one;
				gameObject.AddComponent<FixRotator>();
				CollisionManager collisionManager = entityObject_0.vmethod_21();
				if (collisionManager)
				{
					collisionManager.method_7(gameObject.GetComponent<Collider>());
				}
			}
		}

		// Token: 0x04001488 RID: 5256
		protected const string LP_RES_PREFIX_NAME = "PTL_Light_Pillar_";

		// Token: 0x04001489 RID: 5257
		protected const string Resource_AssetBundle_Name = "light_pillar.assetbundle";

		// Token: 0x0400148A RID: 5258
		protected const string Client_Resource_AssetBundle_Name = "light_pillar_cl.assetbundle";

		// Token: 0x0400148B RID: 5259
		private static Pickable.LightPillarManager s_instance;

		// Token: 0x0400148C RID: 5260
		protected Dictionary<string, global::UnityEngine.Object> _mapResources;

		// Token: 0x0400148D RID: 5261
		protected static Dictionary<ItemRarity, string> _mapItemColor;
	}
}
