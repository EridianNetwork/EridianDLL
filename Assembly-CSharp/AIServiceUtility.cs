using System;
using System.Collections.Generic;
using BHV;
using ns0;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class AIServiceUtility
{
	// Token: 0x0600007A RID: 122 RVA: 0x000384FC File Offset: 0x000366FC
	private AIServiceUtility()
	{
		this.m_curIndex = 0;
		this.m_npcLayer = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ragdoll")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600007C RID: 124 RVA: 0x000034E5 File Offset: 0x000016E5
	public static AIServiceUtility AIServiceUtility_0
	{
		get
		{
			return AIServiceUtility.s_instance;
		}
	}

	// Token: 0x0600007D RID: 125 RVA: 0x000034EC File Offset: 0x000016EC
	public void method_0(EntityProjectile entityProjectile_0)
	{
		if (this.m_destructibleObjList != null && entityProjectile_0 != null)
		{
			entityProjectile_0.m_index = this.m_curIndex;
			this.m_destructibleObjList.Add(entityProjectile_0.m_index, entityProjectile_0);
			this.m_curIndex++;
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x0000352B File Offset: 0x0000172B
	public void method_1(int int_0)
	{
		if (this.m_destructibleObjList.ContainsKey(int_0))
		{
			this.m_destructibleObjList.Remove(int_0);
		}
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_2(AttackInfo attackInfo_0)
	{
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000385B8 File Offset: 0x000367B8
	public void method_3(int int_0)
	{
		if (this.m_destructibleObjList != null && this.m_destructibleObjList.ContainsKey(int_0))
		{
			IDestructibleObj destructibleObj = this.m_destructibleObjList[int_0];
			if (destructibleObj != null)
			{
				destructibleObj.imethod_1();
			}
			return;
		}
	}

	// Token: 0x06000081 RID: 129 RVA: 0x000385F4 File Offset: 0x000367F4
	public void method_4(int int_0, int int_1)
	{
		if (this.m_destructibleObjList != null && this.m_destructibleObjList.ContainsKey(int_0))
		{
			IDestructibleObj destructibleObj = this.m_destructibleObjList[int_0];
			if (destructibleObj != null)
			{
				destructibleObj.imethod_2(int_1);
			}
			return;
		}
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00038630 File Offset: 0x00036830
	public void method_5(Vector3 vector3_0, float float_0)
	{
		if (this.m_warningZone == null)
		{
			if (this.m_warningZonePrefab == null)
			{
				this.m_warningZonePrefab = ResourcesLoader.smethod_0("Entities/Object/Effect/BossWarningZone");
			}
			if (this.m_warningZonePrefab != null)
			{
				this.m_warningZone = (GameObject)global::UnityEngine.Object.Instantiate(this.m_warningZonePrefab);
			}
			if (this.m_warningZone == null)
			{
				return;
			}
			this.m_warningZonePs = this.m_warningZone.GetComponentsInChildren<ParticleSystem>();
			this.m_warningProjector = this.m_warningZone.GetComponentInChildren<Projector>();
			if (this.m_warningZonePs == null || this.m_warningZonePs.Length == 0 || this.m_warningProjector == null)
			{
				return;
			}
		}
		this.m_warningZone.transform.position = vector3_0;
		for (int i = 0; i < this.m_warningZonePs.Length; i++)
		{
			this.m_warningZonePs[i].startSize = float_0;
		}
		this.m_warningProjector.orthographic = true;
		this.m_warningProjector.orthographicSize = float_0;
		this.m_warningZone.gameObject.SetActive(true);
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00003548 File Offset: 0x00001748
	public void method_6()
	{
		if (this.m_warningZone == null)
		{
			return;
		}
		this.m_warningZone.gameObject.SetActive(false);
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00038740 File Offset: 0x00036940
	public void method_7(List<Vector3> list_0, float float_0)
	{
		if (this.m_warningZonePrefab == null)
		{
			this.m_warningZonePrefab = ResourcesLoader.smethod_0("Entities/Object/Effect/BossWarningZone");
			if (this.m_warningZonePrefab == null)
			{
				return;
			}
		}
		int count = list_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.m_warningZoneArray[i] == null)
			{
				this.m_warningZoneArray[i] = (GameObject)global::UnityEngine.Object.Instantiate(this.m_warningZonePrefab);
			}
			this.m_warningZoneArray[i].gameObject.SetActive(true);
			this.m_warningZonePs = this.m_warningZoneArray[i].GetComponentsInChildren<ParticleSystem>();
			this.m_warningProjector = this.m_warningZoneArray[i].GetComponentInChildren<Projector>();
			if (this.m_warningZonePs == null || this.m_warningZonePs.Length == 0 || this.m_warningProjector == null)
			{
				return;
			}
			this.m_warningZoneArray[i].transform.position = list_0[i];
			for (int j = 0; j < this.m_warningZonePs.Length; j++)
			{
				this.m_warningZonePs[j].startSize = float_0;
			}
			this.m_warningProjector.orthographic = true;
			this.m_warningProjector.orthographicSize = float_0;
		}
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00038868 File Offset: 0x00036A68
	public void method_8()
	{
		for (int i = 0; i < 4; i++)
		{
			if (!(this.m_warningZoneArray[i] == null))
			{
				this.m_warningZoneArray[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000086 RID: 134 RVA: 0x000388A4 File Offset: 0x00036AA4
	public void method_9(BHVTaskManager bhvtaskManager_0)
	{
		if (bhvtaskManager_0.m_navAgent != null)
		{
			bhvtaskManager_0.m_navAgent.enabled = true;
		}
		if (bhvtaskManager_0.m_entity != null)
		{
			ns0.MonoSingleton<EntityManager>.Instance.method_4(bhvtaskManager_0.m_entity);
			(bhvtaskManager_0.m_entity as EntityNpc).method_12();
			if (bhvtaskManager_0.GetComponent<BHVBrain>().m_isDamageable)
			{
				DamageManager.DamageManager_0.method_1(bhvtaskManager_0.m_entity);
			}
		}
		NPCAnimationManagerFSM nPCAnimationManagerFSM = bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM;
		if (nPCAnimationManagerFSM != null)
		{
			nPCAnimationManagerFSM.OnNpcRespawn();
		}
		Utils.smethod_4(bhvtaskManager_0.transform, LayerMask.NameToLayer("Default"), bool_0: true);
		bhvtaskManager_0.gameObject.layer = LayerMask.NameToLayer("Npc");
		for (int i = 0; i < bhvtaskManager_0.transform.childCount; i++)
		{
			GameObject gameObject = bhvtaskManager_0.transform.GetChild(i).gameObject;
			if (gameObject.name == "BoundingBox")
			{
				gameObject.layer = LayerMask.NameToLayer("Npc");
				break;
			}
		}
		CollisionManager component = bhvtaskManager_0.GetComponent<CollisionManager>();
		if (component != null)
		{
			component.method_18();
			component.method_16();
		}
		method_10(bhvtaskManager_0, bool_0: true);
		if ((bool)bhvtaskManager_0 && (bool)bhvtaskManager_0.m_entity && bhvtaskManager_0.m_entity.vmethod_10() != null)
		{
			AIInventory aIInventory = bhvtaskManager_0.m_entity.vmethod_10();
			if (aIInventory != null && aIInventory.m_weapon != null)
			{
				aIInventory.m_weapon.gameObject.SetActive(value: true);
			}
		}
	}
	// Token: 0x06000087 RID: 135 RVA: 0x00038A2C File Offset: 0x00036C2C
	public void method_10(BHVTaskManager bhvtaskManager_0, bool bool_0)
	{
		BHVTaskUtils.smethod_10(bhvtaskManager_0.m_entity, bool_0);
		CollisionManager component = bhvtaskManager_0.GetComponent<CollisionManager>();
		if (component != null)
		{
			component.method_13().enabled = bool_0;
		}
	}

	// Token: 0x04000030 RID: 48
	private static readonly AIServiceUtility s_instance = new AIServiceUtility();

	// Token: 0x04000031 RID: 49
	private Dictionary<int, EntityProjectile> m_destructibleObjList = new Dictionary<int, EntityProjectile>();

	// Token: 0x04000032 RID: 50
	private int m_curIndex;

	// Token: 0x04000033 RID: 51
	public BHVTaskParamDestoryMissile m_destroyMissileParam = new BHVTaskParamDestoryMissile();

	// Token: 0x04000034 RID: 52
	public int m_playerCount_cheat = -1;

	// Token: 0x04000035 RID: 53
	public bool m_bPlayerNoDeath;

	// Token: 0x04000036 RID: 54
	public bool m_bShowNpcHP;

	// Token: 0x04000037 RID: 55
	public bool m_bPlayCutScene;

	// Token: 0x04000038 RID: 56
	public int m_npcLayer = -1;

	// Token: 0x04000039 RID: 57
	public List<AIServiceUtility.strTaskParam> m_taskList;

	// Token: 0x0400003A RID: 58
	private GameObject m_warningZone;

	// Token: 0x0400003B RID: 59
	private ParticleSystem[] m_warningZonePs = new ParticleSystem[3];

	// Token: 0x0400003C RID: 60
	private Projector m_warningProjector;

	// Token: 0x0400003D RID: 61
	private global::UnityEngine.Object m_warningZonePrefab;

	// Token: 0x0400003E RID: 62
	private GameObject[] m_warningZoneArray = new GameObject[4];

	// Token: 0x0200000D RID: 13
	public struct strTaskParam
	{
		// Token: 0x0400003F RID: 63
		public int index;

		// Token: 0x04000040 RID: 64
		public int hp;

		// Token: 0x04000041 RID: 65
		public BHVTaskManager taskManager;
	}
}
