using System;
using System.Collections.Generic;
using BHV;
using Core;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x02000448 RID: 1096
[RequireComponent(typeof(BadAssNetworkView))]
public class Entity : global::Photon.MonoBehaviour
{
	// Token: 0x06001AFE RID: 6910 RVA: 0x00013954 File Offset: 0x00011B54
	public virtual int vmethod_0()
	{
		return base.photonView.Int32_1;
	}

	// Token: 0x06001AFF RID: 6911 RVA: 0x00013961 File Offset: 0x00011B61
	public void method_0(Vector3 vector3_0)
	{
		this.m_snapOnGroundPosition = vector3_0;
	}

	// Token: 0x06001B00 RID: 6912 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual AttackInfo.ElementalType vmethod_1()
	{
		return AttackInfo.ElementalType.None;
	}

	// Token: 0x06001B01 RID: 6913 RVA: 0x0001396A File Offset: 0x00011B6A
	public virtual float vmethod_2(AttackInfo.ElementalType elementalType_0)
	{
		return 0f;
	}

	// Token: 0x06001B02 RID: 6914 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_3()
	{
		return 0;
	}

	// Token: 0x06001B03 RID: 6915 RVA: 0x00013971 File Offset: 0x00011B71
	public virtual string vmethod_4()
	{
		return LocalizedString.smethod_0(new LocalizedString(this.m_name));
	}

	// Token: 0x06001B04 RID: 6916 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_5()
	{
		return 1f;
	}

	// Token: 0x06001B05 RID: 6917 RVA: 0x00003727 File Offset: 0x00001927
	public virtual List<PassiveSkillType> vmethod_6()
	{
		return null;
	}

	// Token: 0x06001B06 RID: 6918 RVA: 0x00013983 File Offset: 0x00011B83
	public virtual object[] vmethod_7()
	{
		return base.photonView.Object_0;
	}

	// Token: 0x06001B07 RID: 6919 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual Entity.EntityType vmethod_8()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06001B08 RID: 6920 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual int vmethod_9()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06001B09 RID: 6921 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual AIInventory vmethod_10()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06001B0A RID: 6922 RVA: 0x00003727 File Offset: 0x00001927
	public virtual NavMeshAgent vmethod_11()
	{
		return null;
	}

	// Token: 0x06001B0B RID: 6923 RVA: 0x00003727 File Offset: 0x00001927
	public virtual AnimationManager vmethod_12()
	{
		return null;
	}

	// Token: 0x06001B0C RID: 6924 RVA: 0x00013990 File Offset: 0x00011B90
	public virtual ENPCParticleType vmethod_13(ENPCParticleType enpcparticleType_0, WeakPoint weakPoint_0)
	{
		return enpcparticleType_0;
	}

	// Token: 0x06001B0D RID: 6925 RVA: 0x00013993 File Offset: 0x00011B93
	public virtual BHVTaskManager vmethod_14()
	{
		return base.GetComponent<BHVTaskManager>();
	}

	// Token: 0x06001B0E RID: 6926 RVA: 0x0001399B File Offset: 0x00011B9B
	public virtual VFXManager vmethod_15()
	{
		return base.GetComponentInChildren<VFXManager>();
	}

	// Token: 0x06001B0F RID: 6927 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual EntityWeapon vmethod_16()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06001B10 RID: 6928 RVA: 0x000139A3 File Offset: 0x00011BA3
	public virtual Skeleton vmethod_17()
	{
		return this.m_skeleton;
	}

	// Token: 0x06001B11 RID: 6929 RVA: 0x00003727 File Offset: 0x00001927
	public virtual EntityShield vmethod_18()
	{
		return null;
	}

	// Token: 0x06001B12 RID: 6930 RVA: 0x00003727 File Offset: 0x00001927
	public virtual EquipmentInventoryEntity vmethod_19()
	{
		return null;
	}

	// Token: 0x06001B13 RID: 6931 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_20()
	{
		return false;
	}

	// Token: 0x06001B14 RID: 6932 RVA: 0x00003727 File Offset: 0x00001927
	public virtual CollisionManager vmethod_21()
	{
		return null;
	}

	// Token: 0x06001B15 RID: 6933 RVA: 0x000139AB File Offset: 0x00011BAB
	public virtual BHVBrain vmethod_22()
	{
		return base.GetComponent<BHVBrain>();
	}

	// Token: 0x06001B16 RID: 6934 RVA: 0x000139B3 File Offset: 0x00011BB3
	public virtual Vector3 vmethod_23()
	{
		return this.method_1() + Vector3.up * this.m_entityHeight * 0.5f;
	}

	// Token: 0x06001B17 RID: 6935 RVA: 0x000139DA File Offset: 0x00011BDA
	public Vector3 method_1()
	{
		return base.gameObject.transform.position;
	}

	// Token: 0x06001B18 RID: 6936 RVA: 0x000139EC File Offset: 0x00011BEC
	public Transform method_2()
	{
		return base.gameObject.transform;
	}

	// Token: 0x06001B19 RID: 6937 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_24()
	{
	}

	// Token: 0x06001B1A RID: 6938 RVA: 0x000896C0 File Offset: 0x000878C0
	protected virtual void Awake()
	{
		this.m_entityMng = MonoSingleton<EntityManager>.Instance;
		this.m_entityMng.method_4(this);
		base.gameObject.transform.parent = this.m_entityMng.m_entityDirectory.transform;
		if (this.m_xmlConfig != null)
		{
			PrefabManager.smethod_4(base.gameObject, this.m_xmlConfig);
		}
		this.m_ability = base.gameObject.AddComponent<EntityAbility>();
		BadAssNetworkView[] components = base.GetComponents<BadAssNetworkView>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].method_17())
			{
				this.m_networkViews.Add(components[i]);
			}
		}
	}

	// Token: 0x06001B1B RID: 6939 RVA: 0x000139F9 File Offset: 0x00011BF9
	protected virtual void OnDestroy()
	{
		if (this.m_ability)
		{
			this.m_ability.method_2();
		}
		if (this.m_entityMng)
		{
			this.m_entityMng.method_5(this);
		}
	}

	// Token: 0x06001B1C RID: 6940 RVA: 0x00003727 File Offset: 0x00001927
	public virtual PlayerInfoSync vmethod_25()
	{
		return null;
	}

	// Token: 0x06001B1D RID: 6941 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_26()
	{
		return false;
	}

	// Token: 0x06001B1E RID: 6942 RVA: 0x00089764 File Offset: 0x00087964
	public bool method_3()
	{
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		return playerInfoSync == null || !playerInfoSync.IsMyActor();
	}

	// Token: 0x06001B1F RID: 6943 RVA: 0x00089790 File Offset: 0x00087990
	protected void method_4()
	{
		if (this.m_postInitXmlConfig != null)
		{
			PrefabManager.smethod_4(base.gameObject, this.m_postInitXmlConfig);
		}
		if (this.m_xmlConfig != null)
		{
			PrefabManager.smethod_5(base.gameObject);
		}
		this.m_skeleton = base.GetComponentInChildren<Skeleton>();
	}

	// Token: 0x06001B20 RID: 6944 RVA: 0x00013A2C File Offset: 0x00011C2C
	public virtual void Start()
	{
		this.method_4();
	}

	// Token: 0x06001B21 RID: 6945 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void Update()
	{
	}

	// Token: 0x06001B22 RID: 6946 RVA: 0x00013A34 File Offset: 0x00011C34
	public virtual Vector3 vmethod_27()
	{
		return base.transform.forward;
	}

	// Token: 0x06001B23 RID: 6947 RVA: 0x00013A41 File Offset: 0x00011C41
	public virtual Vector3 vmethod_28()
	{
		return base.transform.position;
	}

	// Token: 0x06001B24 RID: 6948 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_29(AttackInfo.AttackType attackType_0)
	{
		return 1f;
	}

	// Token: 0x06001B25 RID: 6949 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_30(AttackInfo.AttackType attackType_0)
	{
		return 1f;
	}

	// Token: 0x06001B26 RID: 6950 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_31()
	{
		return 1f;
	}

	// Token: 0x06001B27 RID: 6951 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_32()
	{
		return 1f;
	}

	// Token: 0x06001B28 RID: 6952 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_33(Entity entity_0, HitInfo hitInfo_0)
	{
		return 1f;
	}

	// Token: 0x06001B29 RID: 6953 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_34()
	{
		return 1f;
	}

	// Token: 0x06001B2A RID: 6954 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_35()
	{
		return 1f;
	}

	// Token: 0x06001B2B RID: 6955 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_36(AttackInfo.AttackType attackType_0, bool bool_0, Entity entity_0)
	{
		return 1f;
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x000897E4 File Offset: 0x000879E4
	public virtual void vmethod_37(int int_0)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		if (equipmentInventoryEntity != null)
		{
			equipmentInventoryEntity.vmethod_5(int_0);
		}
	}

	// Token: 0x06001B2D RID: 6957 RVA: 0x00089808 File Offset: 0x00087A08
	public virtual void vmethod_38(int int_0)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		if (equipmentInventoryEntity != null)
		{
			equipmentInventoryEntity.vmethod_1(int_0);
		}
	}

	// Token: 0x06001B2E RID: 6958 RVA: 0x0008982C File Offset: 0x00087A2C
	public virtual void vmethod_39(int int_0)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		if (equipmentInventoryEntity != null)
		{
			equipmentInventoryEntity.vmethod_3(int_0);
		}
	}

	// Token: 0x06001B2F RID: 6959 RVA: 0x00089850 File Offset: 0x00087A50
	public virtual int vmethod_40()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		return (!(equipmentInventoryEntity != null)) ? 0 : equipmentInventoryEntity.vmethod_4();
	}

	// Token: 0x06001B30 RID: 6960 RVA: 0x00089878 File Offset: 0x00087A78
	public virtual int vmethod_41()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		return (!(equipmentInventoryEntity != null)) ? 0 : equipmentInventoryEntity.vmethod_0();
	}

	// Token: 0x06001B31 RID: 6961 RVA: 0x000898A0 File Offset: 0x00087AA0
	public virtual void vmethod_42(int int_0)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		if (equipmentInventoryEntity == null)
		{
			return;
		}
		equipmentInventoryEntity.vmethod_8(int_0);
	}

	// Token: 0x06001B32 RID: 6962 RVA: 0x000898A0 File Offset: 0x00087AA0
	public virtual void vmethod_43(int int_0)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		if (equipmentInventoryEntity == null)
		{
			return;
		}
		equipmentInventoryEntity.vmethod_8(int_0);
	}

	// Token: 0x06001B33 RID: 6963 RVA: 0x000898C8 File Offset: 0x00087AC8
	public virtual int vmethod_44()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		return (!(equipmentInventoryEntity != null)) ? 0 : equipmentInventoryEntity.vmethod_6();
	}

	// Token: 0x06001B34 RID: 6964 RVA: 0x000898F0 File Offset: 0x00087AF0
	public virtual int vmethod_45()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.vmethod_19();
		return (!(equipmentInventoryEntity != null)) ? 0 : equipmentInventoryEntity.vmethod_7();
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x00089918 File Offset: 0x00087B18
	[AudioParameterFunction]
	public string GetAudioMaterialBelow()
	{
		string text = null;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position + new Vector3(0f, 0.7f, 0.4f), Vector3.down, out raycastHit))
		{
			string tag = raycastHit.transform.tag;
			if (AudioSwitchValues.smethod_0(tag))
			{
				text = tag;
			}
		}
		return text;
	}

	// Token: 0x06001B36 RID: 6966 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual int vmethod_46()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_47()
	{
		return false;
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_48(AttackInfo attackInfo_0)
	{
		return false;
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x00013A4E File Offset: 0x00011C4E
	public virtual void vmethod_49()
	{
		base.transform.position = this.vmethod_50();
	}

	// Token: 0x06001B3A RID: 6970 RVA: 0x00089974 File Offset: 0x00087B74
	public virtual Vector3 vmethod_50()
	{
		if (Mathf.Approximately(base.transform.position.x, this.m_snapOnGroundPosition.x) && Mathf.Approximately(base.transform.position.z, this.m_snapOnGroundPosition.z))
		{
			return this.m_snapOnGroundPosition;
		}
		float entityHeight = this.m_entityHeight;
		Vector3 vector = base.transform.position + Vector3.up * entityHeight;
		RaycastHit raycastHit;
		if (Physics.Raycast(vector, Vector3.down, out raycastHit, 10f, TargetingService.Int32_0))
		{
			vector.y = raycastHit.point.y;
			this.m_snapOnGroundPosition = vector;
			return vector;
		}
		return base.transform.position;
	}

	// Token: 0x06001B3B RID: 6971 RVA: 0x00089A3C File Offset: 0x00087C3C
	public void method_5(int int_0)
	{
		Vector3 position = base.transform.position;
		Vector3 vector = base.transform.position + Vector3.up * this.m_entityHeight * 0.5f;
		RaycastHit[] array = Physics.SphereCastAll(vector, 0.1f, Vector3.down, 10f, int_0);
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].distance < num)
			{
				num2 = array[i].point.y;
				num = array[i].distance;
				flag = true;
			}
		}
		if (flag)
		{
			position.y = num2;
		}
		base.transform.position = position;
	}

	// Token: 0x06001B3C RID: 6972 RVA: 0x00013A61 File Offset: 0x00011C61
	public Bounds method_6()
	{
		if (this.vmethod_21() != null)
		{
			return this.vmethod_21().method_15();
		}
		return new Bounds(Vector3.zero, Vector3.zero);
	}

	// Token: 0x06001B3D RID: 6973 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void OnDrawGizmos()
	{
	}

	// Token: 0x06001B3E RID: 6974 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_51()
	{
		return false;
	}

	// Token: 0x06001B3F RID: 6975 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_52(bool bool_0)
	{
	}

	// Token: 0x06001B40 RID: 6976 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_53()
	{
		return false;
	}

	// Token: 0x06001B41 RID: 6977 RVA: 0x00089B0C File Offset: 0x00087D0C
	public virtual float vmethod_54(EntityWeapon entityWeapon_0, int int_0)
	{
		float num = 0f;
		if (entityWeapon_0 != null)
		{
			num = FloatAttributeValue.smethod_0(entityWeapon_0.m_attribute.method_1(AttributeType.WeaponElementalDamage) as FloatAttributeValue);
		}
		return num;
	}

	// Token: 0x06001B42 RID: 6978 RVA: 0x00089B44 File Offset: 0x00087D44
	public int method_7()
	{
		WeakPoint weakPoint = null;
		return this.method_8(out weakPoint);
	}

	// Token: 0x06001B43 RID: 6979 RVA: 0x00089B5C File Offset: 0x00087D5C
	public int method_8(out WeakPoint weakPoint_0)
	{
		WeakPoint[] array = this.vmethod_21().method_10();
		for (int i = 0; i < array.Length; i++)
		{
			WeakPoint weakPoint = array[i];
			if (weakPoint.m_isDefaultWeakPoint)
			{
				weakPoint_0 = weakPoint;
				return i;
			}
		}
		DebugUtils.LogWarning(LogCategory.Gamelogic, "No Default WeakPoint was found on Entity: " + base.gameObject.name + ". Weakpoint [0] will be used!!");
		weakPoint_0 = array[0];
		return 0;
	}

	// Token: 0x06001B44 RID: 6980 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_55(Dictionary<int, BHVTask> dictionary_0)
	{
	}

	// Token: 0x06001B45 RID: 6981 RVA: 0x00003727 File Offset: 0x00001927
	public virtual string vmethod_56()
	{
		return null;
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_57(float float_0)
	{
	}

	// Token: 0x06001B47 RID: 6983 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_58(bool bool_0)
	{
	}

	// Token: 0x06001B48 RID: 6984 RVA: 0x000039EC File Offset: 0x00001BEC
	public virtual bool vmethod_59()
	{
		return true;
	}

	// Token: 0x06001B49 RID: 6985 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_60(float float_0)
	{
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x00089BBC File Offset: 0x00087DBC
	public float method_9()
	{
		float num = 0f;
		for (int i = 0; i < this.m_networkViews.Count; i++)
		{
			if (this.m_networkViews[i].lastTimeDataRecv > num)
			{
				num = this.m_networkViews[i].lastTimeDataRecv;
			}
		}
		return num;
	}

	// Token: 0x06001B4B RID: 6987 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_61()
	{
		return 1f;
	}

	// Token: 0x040011D7 RID: 4567
	public List<PhotonView> m_networkViews = new List<PhotonView>();

	// Token: 0x040011D8 RID: 4568
	public List<Grid> m_grids = new List<Grid>();

	// Token: 0x040011D9 RID: 4569
	public float m_entityHeight = 1.8f;

	// Token: 0x040011DA RID: 4570
	public string m_name = "Invalid_Entity_Name";

	// Token: 0x040011DB RID: 4571
	public TextAsset m_xmlConfig;

	// Token: 0x040011DC RID: 4572
	public TextAsset m_postInitXmlConfig;

	// Token: 0x040011DD RID: 4573
	protected EntityManager m_entityMng;

	// Token: 0x040011DE RID: 4574
	public EntityAbility m_ability;

	// Token: 0x040011DF RID: 4575
	public EntityPlayer m_relatedPlayer;

	// Token: 0x040011E0 RID: 4576
	public Skeleton m_skeleton;

	// Token: 0x040011E1 RID: 4577
	public Entity m_killer;

	// Token: 0x040011E2 RID: 4578
	[HideInInspector]
	public bool m_bCanReceiveShootDamage = true;

	// Token: 0x040011E3 RID: 4579
	[HideInInspector]
	public bool m_bCanReceiveMeleeDamage = true;

	// Token: 0x040011E4 RID: 4580
	[HideInInspector]
	public bool m_bCanReceiveAreaDamage = true;

	// Token: 0x040011E5 RID: 4581
	[HideInInspector]
	public bool m_bReceiveNpcDamage = true;

	// Token: 0x040011E6 RID: 4582
	protected Vector3 m_snapOnGroundPosition = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

	// Token: 0x02000449 RID: 1097
	public enum EntityType
	{
		// Token: 0x040011E8 RID: 4584
		None,
		// Token: 0x040011E9 RID: 4585
		Player,
		// Token: 0x040011EA RID: 4586
		Npc,
		// Token: 0x040011EB RID: 4587
		Object,
		// Token: 0x040011EC RID: 4588
		Projectile,
		// Token: 0x040011ED RID: 4589
		Platform,
		// Token: 0x040011EE RID: 4590
		Others
	}
}
