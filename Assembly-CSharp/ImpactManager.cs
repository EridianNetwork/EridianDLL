using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200057C RID: 1404
public class ImpactManager : MonoSingleton<ImpactManager>
{
	// Token: 0x06002408 RID: 9224 RVA: 0x00018A7B File Offset: 0x00016C7B
	protected override void Awake()
	{
		base.Awake();
		this.method_0();
	}

	// Token: 0x06002409 RID: 9225 RVA: 0x00018A89 File Offset: 0x00016C89
	private void OnDestroy()
	{
		global::UnityEngine.Object.DestroyImmediate(this.m_poolsContainerGO);
	}

	// Token: 0x0600240A RID: 9226 RVA: 0x00018A96 File Offset: 0x00016C96
	private void method_0()
	{
		this.m_poolsContainerGO = new GameObject();
		this.m_poolsContainerGO.name = "ImpactsPools";
		this.m_poolsContainerGO.hideFlags = HideFlags.DontSave;
	}

	// Token: 0x0600240B RID: 9227 RVA: 0x000AB308 File Offset: 0x000A9508
	private PrefabPool method_1(string string_0, GameObject gameObject_0)
	{
		gameObject_0.name = string_0;
		PrefabPool prefabPool = new PrefabPool(gameObject_0, this.m_poolsContainerGO);
		this.m_decalsPool.Add(string_0, prefabPool);
		return prefabPool;
	}

	// Token: 0x0600240C RID: 9228 RVA: 0x000AB338 File Offset: 0x000A9538
	public void method_2()
	{
		Dictionary<string, PrefabPool>.Enumerator enumerator = m_decalsPool.GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Value.Reset();
			if (m_activeObjects.TryGetValue(enumerator.Current.Key, out var value))
			{
				int count = value.Count;
				for (int i = 0; i < count; i++)
				{
					UnityEngine.Object.Destroy(value[i]);
				}
			}
		}
		m_decalsPool.Clear();
		m_activeObjects.Clear();
	}
	// Token: 0x0600240D RID: 9229 RVA: 0x000AB3C8 File Offset: 0x000A95C8
	private PrefabPool method_3(string string_0)
	{
		PrefabPool prefabPool = null;
		this.m_decalsPool.TryGetValue(string_0, out prefabPool);
		return prefabPool;
	}

	// Token: 0x0600240E RID: 9230 RVA: 0x000AB3E8 File Offset: 0x000A95E8
	private void method_4(PrefabPool prefabPool_0, Vector3 vector3_0, Vector3 vector3_1)
	{
		GameObject gameObject = prefabPool_0.method_2(this.m_poolsContainerGO);
		gameObject.transform.position = vector3_0;
		gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, -vector3_1);
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
		component.Simulate(0.0001f, true, true);
		component.Play();
		prefabPool_0.method_3(gameObject, component.startLifetime + component.duration, true);
	}

	// Token: 0x0600240F RID: 9231 RVA: 0x000AB458 File Offset: 0x000A9658
	public void method_5(Vector3 vector3_0, Vector3 vector3_1, AttackInfo.ElementalType elementalType_0)
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(vector3_0, vector3_1, out raycastHit, this.m_maxImpactDistance, TargetingService.Int32_0) && raycastHit.collider != null)
		{
			ImpactContext impactContext = default(ImpactContext);
			impactContext.m_impactType = ImpactContext.ImpactType.Terrain;
			impactContext.m_resolutionTime = Time.time + this.method_11(raycastHit.distance);
			impactContext.m_affectedObject = raycastHit.collider.gameObject;
			impactContext.m_elementalType = elementalType_0;
			impactContext.m_position = raycastHit.point;
			impactContext.m_normal = raycastHit.normal;
			impactContext.m_forward = vector3_1;
			this.m_impactBuffer.Add(impactContext);
		}
	}

	// Token: 0x06002410 RID: 9232 RVA: 0x000AB504 File Offset: 0x000A9704
	public ImpactSetup method_6(string string_0)
	{
		for (int i = 0; i < this.m_impacts.Length; i++)
		{
			if (string_0 == this.m_impacts[i].m_impactType)
			{
				return this.m_impacts[i];
			}
		}
		return null;
	}

	// Token: 0x06002411 RID: 9233 RVA: 0x000AB544 File Offset: 0x000A9744
	private ParticleSystem method_7(AttackInfo.ElementalType elementalType_0)
	{
		switch (elementalType_0)
		{
		case AttackInfo.ElementalType.Fire:
			return this.m_elementalFire;
		case AttackInfo.ElementalType.Shock:
			return this.m_elementalShock;
		case AttackInfo.ElementalType.Corrosive:
			return this.m_elementalCorrosive;
		case AttackInfo.ElementalType.Explosive:
			return this.m_elementalExplosive;
		default:
			return null;
		}
	}

	// Token: 0x06002412 RID: 9234 RVA: 0x000AB588 File Offset: 0x000A9788
	public void method_8(GameObject gameObject_0, AttackInfo.ElementalType elementalType_0, Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		ImpactSetup impactSetup = this.method_6(gameObject_0.tag);
		if (impactSetup == null)
		{
			return;
		}
		PrefabPool prefabPool = this.method_3(impactSetup.m_particuleSystem.name);
		if (prefabPool == null && impactSetup.m_particuleSystem != null)
		{
			prefabPool = this.method_1(impactSetup.m_particuleSystem.name, impactSetup.m_particuleSystem.gameObject);
		}
		this.method_4(prefabPool, vector3_0, vector3_1);
		ParticleSystem particleSystem = this.method_7(elementalType_0);
		if (particleSystem != null)
		{
			prefabPool = this.method_3(particleSystem.name);
			if (prefabPool == null)
			{
				prefabPool = this.method_1(particleSystem.name, particleSystem.gameObject);
			}
			this.method_4(prefabPool, vector3_0, vector3_1);
		}
		if (impactSetup.m_material != null)
		{
			prefabPool = this.method_3(impactSetup.m_impactType);
			GameObject gameObject;
			if (prefabPool == null)
			{
				gameObject = new GameObject("Decal_" + impactSetup.m_impactType);
				gameObject.transform.position = vector3_0;
				gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, vector3_2);
				gameObject.transform.localScale = impactSetup.m_decalSize;
				this.method_9(impactSetup, gameObject, gameObject_0);
				prefabPool = this.method_1(impactSetup.m_impactType, gameObject);
				this.m_activeObjects.Add(impactSetup.m_impactType, new List<GameObject>());
			}
			else
			{
				gameObject = prefabPool.method_2(this.m_poolsContainerGO);
				gameObject.transform.position = vector3_0;
				gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, vector3_2);
				gameObject.transform.localScale = impactSetup.m_decalSize;
			}
			this.m_activeObjects[impactSetup.m_impactType].Add(gameObject);
			if (this.m_activeObjects[impactSetup.m_impactType].Count == 150)
			{
				for (int i = 149; i > -1; i--)
				{
					prefabPool.method_4(this.m_activeObjects[impactSetup.m_impactType][i], false);
					this.m_activeObjects[impactSetup.m_impactType].RemoveAt(i);
				}
			}
		}
	}

	// Token: 0x06002413 RID: 9235 RVA: 0x000AB794 File Offset: 0x000A9994
	public void method_9(ImpactSetup impactSetup_0, GameObject gameObject_0, GameObject gameObject_1)
	{
		Decal.dCount++;
		Decal decal = gameObject_0.AddComponent<Decal>();
		decal.affectedObject = gameObject_1;
		decal.decalMode = DecalMode.MESH_FILTER;
		decal.pushDistance = this.m_tolerantDistance;
		Material material = impactSetup_0.m_material;
		if (impactSetup_0.m_texture != null && impactSetup_0.m_texture.Length > 0)
		{
			int num = global::UnityEngine.Random.Range(0, impactSetup_0.m_texture.Length);
			material.mainTexture = impactSetup_0.m_texture[num];
		}
		decal.decalMaterial = material;
		decal.method_1();
		decal.transform.parent = gameObject_1.transform;
	}

	// Token: 0x06002414 RID: 9236 RVA: 0x000AB824 File Offset: 0x000A9A24
	private void Update()
	{
		float time = Time.time;
		for (int i = this.m_impactBuffer.Count - 1; i >= 0; i--)
		{
			if (this.m_impactBuffer[i].m_resolutionTime < time)
			{
				ImpactContext.ImpactType impactType = this.m_impactBuffer[i].m_impactType;
				if (impactType != ImpactContext.ImpactType.Terrain)
				{
					if (impactType == ImpactContext.ImpactType.Entity)
					{
						this.method_13(this.m_impactBuffer[i].m_victim, this.m_impactBuffer[i].m_damageInfo, false);
					}
				}
				else
				{
					this.method_8(this.m_impactBuffer[i].m_affectedObject, this.m_impactBuffer[i].m_elementalType, this.m_impactBuffer[i].m_position, this.m_impactBuffer[i].m_forward, this.m_impactBuffer[i].m_normal);
				}
				this.m_impactBuffer.RemoveAt(i);
			}
		}
	}

	// Token: 0x06002415 RID: 9237 RVA: 0x000AB944 File Offset: 0x000A9B44
	public void method_10(bool bool_0, Entity entity_0, DamageInfo damageInfo_0)
	{
		if (bool_0)
		{
			this.method_13(entity_0, damageInfo_0, bool_0);
		}
		else
		{
			Entity entity = BadAssNetworkView.smethod_4(damageInfo_0.m_from);
			if (entity != null)
			{
				float num = Vector3.Distance(entity_0.method_1(), entity.method_1());
				ImpactContext impactContext = default(ImpactContext);
				impactContext.m_impactType = ImpactContext.ImpactType.Entity;
				impactContext.m_resolutionTime = Time.time + this.method_11(num);
				impactContext.m_victim = entity_0;
				impactContext.m_damageInfo = damageInfo_0;
				this.m_impactBuffer.Add(impactContext);
			}
		}
	}

	// Token: 0x06002416 RID: 9238 RVA: 0x00018ABF File Offset: 0x00016CBF
	private float method_11(float float_0)
	{
		return this.m_defaultImpactDelay + 1f / (this.m_bulletSpeed / float_0);
	}

	// Token: 0x06002417 RID: 9239 RVA: 0x000AB9C8 File Offset: 0x000A9BC8
	public void method_12(Entity entity_0, Entity entity_1)
	{
		if (!(entity_0 == null) && !(entity_1 == null))
		{
			Vector3 vector = entity_1.method_1() + Vector3.up * entity_1.m_entityHeight * 0.6f;
			if (entity_0.vmethod_25() != null && entity_0.vmethod_25().IsMyActor())
			{
				HUDWorldTipsView hudworldTipsView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWorldTipsView>();
				hudworldTipsView.vmethod_5(12345, WeakPoint.StrengthType.Normal, vector, AttackInfo.ElementalType.None, false, true);
			}
			return;
		}
	}

	// Token: 0x06002418 RID: 9240 RVA: 0x000ABA4C File Offset: 0x000A9C4C
	public void method_13(Entity entity_0, DamageInfo damageInfo_0, bool bool_0 = true)
	{
		if (entity_0 == null)
		{
			return;
		}
		int num = damageInfo_0.m_shieldDamagePoints + damageInfo_0.m_healthDamagePoints;
		Vector3 vector = entity_0.method_1() + Vector3.up * entity_0.m_entityHeight * 0.6f;
		WeakPoint weakPoint = entity_0.vmethod_21().method_12(damageInfo_0.m_weakPointIndex);
		VFXManager vfxmanager = entity_0.vmethod_15();
		Entity entity = BadAssNetworkView.smethod_4(damageInfo_0.m_from);
		if (entity == null)
		{
			return;
		}
		if (entity != null)
		{
			PlayerInfoSync playerInfoSync = entity.vmethod_25();
			if ((bool_0 && playerInfoSync != null && playerInfoSync.IsMyActor()) || !bool_0)
			{
				if (AttackInfo.smethod_0(damageInfo_0.m_attackSubType) == AttackInfo.AttackType.Projectile)
				{
					this.method_14(entity_0, vfxmanager, damageInfo_0, weakPoint, ref vector);
				}
				else if (AttackInfo.smethod_0(damageInfo_0.m_attackSubType) == AttackInfo.AttackType.DamageOverTime)
				{
					this.method_15(entity_0, vfxmanager, damageInfo_0);
				}
			}
			if (num > 0)
			{
				bool flag = damageInfo_0.m_attackSubType == AttackSubType.SkillTurretProjectile;
				bool flag2;
				if (((flag2 = playerInfoSync != null && playerInfoSync.IsMyActor()) && bool_0) || (flag && flag2) || (entity is EntityExplosive && entity_0 is EntityNpc))
				{
					if (entity_0.vmethod_40() <= 0 && flag2)
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_14();
					}
					if (AttackInfo.smethod_0(damageInfo_0.m_attackSubType) == AttackInfo.AttackType.DamageOverTime)
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWorldTipsView>().vmethod_5(num, weakPoint.method_3(), vector, damageInfo_0.m_elementalType, false, false);
					}
					else
					{
						WeakPoint.StrengthType strengthType = weakPoint.method_3();
						if (DamageManager.DamageManager_0.method_18(damageInfo_0.m_from, entity_0.vmethod_0()))
						{
							strengthType = ((!MonoSingleton<Session>.Instance.method_12()) ? WeakPoint.StrengthType.VeryWeak : WeakPoint.StrengthType.Weak);
							DamageManager.DamageManager_0.method_20(damageInfo_0.m_from, entity_0.vmethod_0());
						}
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWorldTipsView>().vmethod_5(num, strengthType, vector, damageInfo_0.m_elementalType, true, false);
					}
				}
			}
		}
	}

	// Token: 0x06002419 RID: 9241 RVA: 0x000ABC48 File Offset: 0x000A9E48
	private bool method_14(Entity entity_0, VFXManager vfxmanager_0, DamageInfo damageInfo_0, WeakPoint weakPoint_0, ref Vector3 vector3_0)
	{
		if (!(entity_0 == null) && !(vfxmanager_0 == null) && !(weakPoint_0 == null))
		{
			Quaternion identity = Quaternion.identity;
			Vector3 vector = this.method_16(entity_0, damageInfo_0, ref identity);
			vector3_0 = vector;
			ENPCParticleType enpcparticleType = ENPCParticleType.E_DamagedBulletNone;
			ENPCParticleType enpcparticleType2 = ENPCParticleType.E_DamagedBulletNone;
			string text = "E_DamagedBullet" + damageInfo_0.m_elementalType;
			if (Enum.IsDefined(typeof(ENPCParticleType), text))
			{
				enpcparticleType2 = (ENPCParticleType)((int)Enum.Parse(typeof(ENPCParticleType), text));
			}
			if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Head)
			{
				enpcparticleType = ENPCParticleType.E_DamageHeadShot;
			}
			enpcparticleType = entity_0.vmethod_13(enpcparticleType, weakPoint_0);
			if (enpcparticleType == ENPCParticleType.E_DamageShieldHit)
			{
				EntityNpc entityNpc = entity_0 as EntityNpc;
				if (entityNpc != null && damageInfo_0.m_shieldDamagePoints - entityNpc.vmethod_44() > 0)
				{
					enpcparticleType = ENPCParticleType.E_DamageShieldBroken;
				}
			}
			if (enpcparticleType == ENPCParticleType.E_DamageShieldBroken)
			{
				vfxmanager_0.method_7(enpcparticleType, entity_0.gameObject.transform, true);
			}
			else if (VFXManager.smethod_4(enpcparticleType))
			{
				vfxmanager_0.method_8(enpcparticleType, entity_0, vector, identity, true);
				if (enpcparticleType2 != enpcparticleType && !VFXManager.smethod_4(enpcparticleType2))
				{
					vfxmanager_0.method_5(enpcparticleType2, entity_0, weakPoint_0.gameObject.transform, weakPoint_0.gameObject.transform.InverseTransformPoint(vector), Quaternion.LookRotation(weakPoint_0.gameObject.transform.InverseTransformDirection(identity.eulerAngles)), 0f, true);
				}
			}
			else
			{
				vfxmanager_0.method_5(enpcparticleType, entity_0, weakPoint_0.gameObject.transform, weakPoint_0.gameObject.transform.InverseTransformPoint(vector), Quaternion.LookRotation(weakPoint_0.gameObject.transform.InverseTransformDirection(identity.eulerAngles)), 0f, true);
			}
			if (damageInfo_0.m_isTriggeringDamageOverTime)
			{
				this.method_15(entity_0, vfxmanager_0, damageInfo_0);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600241A RID: 9242 RVA: 0x000ABE0C File Offset: 0x000AA00C
	private bool method_15(Entity entity_0, VFXManager vfxmanager_0, DamageInfo damageInfo_0)
	{
		if (!(entity_0 == null) && !(vfxmanager_0 == null))
		{
			if (!damageInfo_0.m_isTriggeringDamageOverTime)
			{
				return false;
			}
			ENPCParticleType enpcparticleType_;
			switch (damageInfo_0.m_elementalType)
			{
			default:
				enpcparticleType_ = ENPCParticleType.E_DamageOverTimeShock;
				break;
			case AttackInfo.ElementalType.Fire:
				if (vfxmanager_0.m_audioCtl != null)
				{
					vfxmanager_0.m_audioCtl.vmethod_1(AudioEventName.Wep_Ele_Incendiary_DoT);
				}
				enpcparticleType_ = ENPCParticleType.E_DamageOverTimeFire;
				break;
			case AttackInfo.ElementalType.Shock:
				if (vfxmanager_0.m_audioCtl != null)
				{
					vfxmanager_0.m_audioCtl.vmethod_1(AudioEventName.Wep_Ele_Shock_DoT);
				}
				enpcparticleType_ = ENPCParticleType.E_DamageOverTimeShock;
				break;
			case AttackInfo.ElementalType.Corrosive:
				if (vfxmanager_0.m_audioCtl != null)
				{
					vfxmanager_0.m_audioCtl.vmethod_1(AudioEventName.Wep_Ele_Corrosive_DoT);
				}
				enpcparticleType_ = ENPCParticleType.E_DamageOverTimeCorrosive;
				break;
			}
			string value = "E_DamageOverTime" + damageInfo_0.m_elementalType;
			if (Enum.IsDefined(typeof(ENPCParticleType), value))
			{
				ENPCParticleType eNPCParticleType = (ENPCParticleType)(int)Enum.Parse(typeof(ENPCParticleType), value);
				string text = string.Empty;
				VFXforNPC[] particleList = vfxmanager_0.m_particleList;
				foreach (VFXforNPC vFXforNPC in particleList)
				{
					if (vFXforNPC.m_type == eNPCParticleType)
					{
						text = vFXforNPC.m_audioEvent;
						break;
					}
				}
				if (text != string.Empty && vfxmanager_0.m_audioCtl != null)
				{
					vfxmanager_0.m_audioCtl.TriggerEventByName(text);
				}
			}
			float float_ = DamageManager.DamageManager_0.method_5(damageInfo_0.m_elementalType, entity_0, BadAssNetworkView.smethod_4(damageInfo_0.m_from));
			WeakPoint weakPoint_ = null;
			entity_0.method_8(out weakPoint_);
			vfxmanager_0.method_5(enpcparticleType_, entity_0, weakPoint_.transform, Vector3.zero, Quaternion.identity, float_);
			if ((bool)ns0.MonoSingleton<GraphicsMgr>.Instance)
			{
				ns0.MonoSingleton<GraphicsMgr>.Instance.method_16().method_3(entity_0, float_, damageInfo_0.m_elementalType);
			}
			return true;
		}
		return false;
	}
	// Token: 0x0600241B RID: 9243 RVA: 0x000ABFD4 File Offset: 0x000AA1D4
	private Vector3 method_16(Entity entity_0, DamageInfo damageInfo_0, ref Quaternion quaternion_0)
	{
		WeakPoint weakPoint = entity_0.vmethod_21().method_12(damageInfo_0.m_weakPointIndex);
		if (AttackInfo.smethod_0(damageInfo_0.m_attackSubType) != AttackInfo.AttackType.Projectile)
		{
			return weakPoint.transform.position;
		}
		Entity entity = BadAssNetworkView.smethod_4(damageInfo_0.m_from);
		if (entity == null)
		{
			return weakPoint.transform.position;
		}
		Vector3 vector = entity.vmethod_28();
		Vector3 vector2 = entity.vmethod_27();
		EntityWeapon entityWeapon = entity.vmethod_16();
		if (entityWeapon != null)
		{
			vector = entityWeapon.vmethod_28();
			vector2 = entityWeapon.vmethod_27();
		}
		Ray ray = new Ray(vector, vector2);
		float maxValue = float.MaxValue;
		RaycastHit raycastHit;
		if (entity_0.vmethod_21().method_3(ray, out raycastHit, ref maxValue))
		{
			quaternion_0 = Quaternion.LookRotation(raycastHit.normal);
			return raycastHit.point;
		}
		Collider collider = weakPoint.collider;
		float magnitude = (collider.ClosestPointOnBounds(vector) - vector).magnitude;
		Vector3 vector3 = vector + vector2.normalized * magnitude * 0.9f;
		Vector3 vector4 = collider.ClosestPointOnBounds(vector3);
		quaternion_0 = Quaternion.LookRotation(vector - vector4);
		return vector4;
	}

	// Token: 0x0600241C RID: 9244 RVA: 0x000AC100 File Offset: 0x000AA300
	private void method_17(Entity entity_0, DamageInfo damageInfo_0)
	{
		EntityPlayer entityPlayer = entity_0 as EntityPlayer;
		BadAssFPSCamera badAssFPSCamera = entityPlayer.method_45();
		if (badAssFPSCamera == null)
		{
			return;
		}
		AttackInfo.AttackType attackType = AttackInfo.smethod_0(damageInfo_0.m_attackSubType);
		switch (attackType)
		{
		case AttackInfo.AttackType.Projectile:
			if (damageInfo_0.m_attackSubType == AttackSubType.ProjectileAxe)
			{
				badAssFPSCamera.method_6(BadAssFPSCamera.ShakeType.medium);
			}
			else
			{
				badAssFPSCamera.method_6(BadAssFPSCamera.ShakeType.low);
			}
			break;
		case AttackInfo.AttackType.Area:
			badAssFPSCamera.method_6(BadAssFPSCamera.ShakeType.high);
			break;
		case AttackInfo.AttackType.Melee:
		case AttackInfo.AttackType.Charge:
			badAssFPSCamera.method_6(BadAssFPSCamera.ShakeType.medium);
			break;
		case AttackInfo.AttackType.DamageOverTime:
			break;
		default:
			DebugUtils.LogWarning(LogCategory.Gamelogic, "No Camera Shake Feedbacks for this Attack Type [" + attackType + "]");
			break;
		}
	}

	// Token: 0x0600241D RID: 9245 RVA: 0x000AC198 File Offset: 0x000AA398
	public void method_18(Entity entity_0, DamageInfo damageInfo_0, int int_0, int int_1, bool bool_0)
	{
		PlayerInfoSync playerInfoSync = entity_0.vmethod_25();
		this.method_19(entity_0, damageInfo_0);
		if (playerInfoSync != null && playerInfoSync.IsMyActor())
		{
			this.method_17(entity_0, damageInfo_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDFeedbackView>().vmethod_6(damageInfo_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDFeedbackView>().vmethod_5(int_0, int_1, damageInfo_0);
			if (damageInfo_0.m_elementalType != AttackInfo.ElementalType.None)
			{
				CharacterFxMgr characterFxMgr = MonoSingleton<GraphicsMgr>.Instance.method_16();
				if (characterFxMgr != null)
				{
					characterFxMgr.method_3(entity_0, 1.5f, damageInfo_0.m_elementalType);
				}
			}
			return;
		}
		this.method_10(bool_0, entity_0, damageInfo_0);
	}

	// Token: 0x0600241E RID: 9246 RVA: 0x000AC230 File Offset: 0x000AA430
	public void method_19(Entity entity_0, DamageInfo damageInfo_0)
	{
		BaseEventTriggerCtl baseEventTriggerCtl = null;
		if (entity_0.vmethod_8() == Entity.EntityType.Player)
		{
			EntityPlayer entityPlayer = entity_0 as EntityPlayer;
			baseEventTriggerCtl = entityPlayer.BaseEventTriggerCtl_0;
		}
		else if (entity_0.vmethod_8() == Entity.EntityType.Npc)
		{
			baseEventTriggerCtl = entity_0.vmethod_15().m_audioCtl;
		}
		if (baseEventTriggerCtl != null)
		{
			string text = "Damage_" + damageInfo_0.m_attackSubType.ToString();
			if (!baseEventTriggerCtl.vmethod_0().Dictionary_0.ContainsKey(text))
			{
				string text2 = AttackInfo.smethod_0(damageInfo_0.m_attackSubType).ToString();
				text = "Damage_" + text2 + "Generic";
			}
			baseEventTriggerCtl.TriggerEventByName(text);
		}
	}

	// Token: 0x040018B1 RID: 6321
	private const int MAX_DECAL_PER_TYPE = 150;

	// Token: 0x040018B2 RID: 6322
	public int m_poolSize = 150;

	// Token: 0x040018B3 RID: 6323
	public float m_maxImpactDistance = 200f;

	// Token: 0x040018B4 RID: 6324
	public float m_defaultImpactDelay = 0.025f;

	// Token: 0x040018B5 RID: 6325
	public float m_bulletSpeed = 500f;

	// Token: 0x040018B6 RID: 6326
	public float m_tolerantDistance = 0.05f;

	// Token: 0x040018B7 RID: 6327
	public ParticleSystem m_elementalFire;

	// Token: 0x040018B8 RID: 6328
	public ParticleSystem m_elementalShock;

	// Token: 0x040018B9 RID: 6329
	public ParticleSystem m_elementalCorrosive;

	// Token: 0x040018BA RID: 6330
	public ParticleSystem m_elementalExplosive;

	// Token: 0x040018BB RID: 6331
	public ImpactSetup[] m_impacts = new ImpactSetup[0];

	// Token: 0x040018BC RID: 6332
	private List<ImpactContext> m_impactBuffer = new List<ImpactContext>();

	// Token: 0x040018BD RID: 6333
	private GameObject m_poolsContainerGO;

	// Token: 0x040018BE RID: 6334
	private Dictionary<string, PrefabPool> m_decalsPool = new Dictionary<string, PrefabPool>();

	// Token: 0x040018BF RID: 6335
	private Dictionary<string, List<GameObject>> m_activeObjects = new Dictionary<string, List<GameObject>>();
}
