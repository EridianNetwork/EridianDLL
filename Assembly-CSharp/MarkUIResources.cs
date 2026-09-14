using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000543 RID: 1347
public class MarkUIResources
{
	// Token: 0x060022D1 RID: 8913 RVA: 0x00017E65 File Offset: 0x00016065
	public void method_0()
	{
		this.m_vfxDict.Clear();
		this.method_4();
	}

	// Token: 0x060022D2 RID: 8914 RVA: 0x000A5478 File Offset: 0x000A3678
	public void method_1(Entity entity_0, int int_0)
	{
		if (Utils.smethod_25(entity_0))
		{
			return;
		}
		MarkUIResources.MarkVFXContainer markVFXContainer = this.method_2(entity_0, this.method_3(entity_0));
		markVFXContainer.method_1(int_0);
	}

	// Token: 0x060022D3 RID: 8915 RVA: 0x000A54A4 File Offset: 0x000A36A4
	private MarkUIResources.MarkVFXContainer method_2(Entity entity_0, MarkUIResources.EUIType euitype_0)
	{
		MarkUIResources.MarkVFXContainer markVFXContainer = null;
		this.m_vfxDict.TryGetValue(entity_0, out markVFXContainer);
		if (markVFXContainer == null)
		{
			GameObject gameObject = this.method_5(entity_0, euitype_0);
			markVFXContainer = new MarkUIResources.MarkVFXContainer();
			markVFXContainer.method_0(gameObject);
			this.m_vfxDict.Add(entity_0, markVFXContainer);
		}
		return markVFXContainer;
	}

	// Token: 0x060022D4 RID: 8916 RVA: 0x000A54EC File Offset: 0x000A36EC
	private MarkUIResources.EUIType method_3(Entity entity_0)
	{
		EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		return (entityPlayer.vmethod_9() != entity_0.vmethod_9()) ? MarkUIResources.EUIType.Enemy : MarkUIResources.EUIType.Friend;
	}

	// Token: 0x060022D5 RID: 8917 RVA: 0x00017E78 File Offset: 0x00016078
	private void method_4()
	{
		this.m_vfx_enemy_prefab = Resources.Load("Particles/PTL_HunterSkillDiminutionBillboard/PTL_HunterSkillDiminutionBillboard", typeof(global::UnityEngine.Object));
		this.m_vfx_friend_prefab = Resources.Load("Particles/PTL_HunterSkillDiminutionBillboard/PTL_HunterSkillDiminutionFriend", typeof(global::UnityEngine.Object));
	}

	// Token: 0x060022D6 RID: 8918 RVA: 0x000A5524 File Offset: 0x000A3724
	private GameObject method_5(Entity entity_0, MarkUIResources.EUIType euitype_0)
	{
		GameObject gameObject;
		if (euitype_0 == MarkUIResources.EUIType.Enemy)
		{
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.m_vfx_enemy_prefab);
		}
		else
		{
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.m_vfx_friend_prefab);
		}
		gameObject.transform.parent = entity_0.transform;
		gameObject.transform.localPosition = this.method_6(entity_0);
		return gameObject;
	}

	// Token: 0x060022D7 RID: 8919 RVA: 0x000A5580 File Offset: 0x000A3780
	private Vector3 method_6(Entity entity_0)
	{
		Vector3 up = Vector3.up;
		EntityNpc entityNpc = entity_0 as EntityNpc;
		if (entityNpc != null)
		{
			up.y = entityNpc.method_21();
		}
		if (entity_0 is EntityPlayer)
		{
			up.y += 1.2f;
		}
		else if (entity_0 is EntityNpc)
		{
			up.y += 0.4f;
		}
		return up;
	}

	// Token: 0x04001723 RID: 5923
	private global::UnityEngine.Object m_vfx_friend_prefab;

	// Token: 0x04001724 RID: 5924
	private global::UnityEngine.Object m_vfx_enemy_prefab;

	// Token: 0x04001725 RID: 5925
	private Dictionary<Entity, MarkUIResources.MarkVFXContainer> m_vfxDict = new Dictionary<Entity, MarkUIResources.MarkVFXContainer>();

	// Token: 0x02000544 RID: 1348
	public enum EUIType
	{
		// Token: 0x04001727 RID: 5927
		Friend,
		// Token: 0x04001728 RID: 5928
		Enemy
	}

	// Token: 0x02000545 RID: 1349
	public class MarkVFXContainer
	{
		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060022D9 RID: 8921 RVA: 0x00017EC1 File Offset: 0x000160C1
		// (set) Token: 0x060022DA RID: 8922 RVA: 0x00017EC9 File Offset: 0x000160C9
		public GameObject m_root { get; private set; }

		// Token: 0x060022DB RID: 8923 RVA: 0x000A55EC File Offset: 0x000A37EC
		public void method_0(GameObject gameObject_0)
		{
			this.m_root = gameObject_0;
			ParticleSystem[] componentsInChildren = gameObject_0.GetComponentsInChildren<ParticleSystem>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				string name = componentsInChildren[i].gameObject.name;
				if (name[name.Length - 2] == '_')
				{
					int num = int.Parse(name[name.Length - 1].ToString());
					this.m_vfxList.Add(num, componentsInChildren[i].gameObject);
				}
			}
			this.method_2();
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x000A5670 File Offset: 0x000A3870
		public void method_1(int int_0)
		{
			if (int_0 < 0 || int_0 > 9)
			{
				return;
			}
			this.m_root.SetActive(int_0 > 0);
			if (int_0 == 0)
			{
				return;
			}
			this.method_2();
			GameObject gameObject = null;
			this.m_vfxList.TryGetValue(int_0, out gameObject);
			if (gameObject != null)
			{
				gameObject.gameObject.SetActive(true);
			}
			else
			{
				DebugUtils.LogError(LogCategory.Gamelogic, string.Format("Can not find child particle index is {0}", int_0));
			}
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x000A56E4 File Offset: 0x000A38E4
		private void method_2()
		{
			foreach (GameObject gameObject in this.m_vfxList.Values)
			{
				gameObject.SetActive(false);
			}
		}

		// Token: 0x04001729 RID: 5929
		private Dictionary<int, GameObject> m_vfxList = new Dictionary<int, GameObject>();
	}
}
