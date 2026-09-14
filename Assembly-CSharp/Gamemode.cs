using System;
using System.Collections.Generic;
using System.Reflection;
using ns0;
using UnityEngine;

// Token: 0x020003FC RID: 1020
public class Gamemode : MonoBehaviour, InstantiateManager.InstanciationClient
{
	// Token: 0x060019BC RID: 6588 RVA: 0x0008631C File Offset: 0x0008451C
	public static Gamemode smethod_0(string string_0)
	{
		return SessionInfo.SessionInfo_0.gameObject.AddComponent(string_0) as Gamemode;
	}

	// Token: 0x060019BD RID: 6589 RVA: 0x00086344 File Offset: 0x00084544
	public static string[] smethod_1()
	{
		Gamemode.m_modeTypes.Clear();
		Type[] types = Assembly.GetAssembly(typeof(Gamemode)).GetTypes();
		foreach (Type type in types)
		{
			if (type.IsSubclassOf(typeof(Gamemode)))
			{
				Gamemode.m_modeTypes.Add(type);
			}
		}
		Type[] array2 = Gamemode.m_modeTypes.ToArray();
		string[] array3 = new string[array2.Length];
		for (int j = 0; j < array3.Length; j++)
		{
			array3[j] = array2[j].ToString();
		}
		return array3;
	}

	// Token: 0x060019BE RID: 6590 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_0()
	{
		return false;
	}

	// Token: 0x060019BF RID: 6591 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_1()
	{
		return false;
	}

	// Token: 0x060019C0 RID: 6592 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_2()
	{
		return false;
	}

	// Token: 0x060019C1 RID: 6593 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_3()
	{
		return false;
	}

	// Token: 0x060019C2 RID: 6594 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_4()
	{
		return false;
	}

	// Token: 0x060019C3 RID: 6595 RVA: 0x00013160 File Offset: 0x00011360
	public string method_0()
	{
		return this.m_gamemodeName;
	}

	// Token: 0x060019C4 RID: 6596 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void Awake()
	{
	}

	// Token: 0x060019C5 RID: 6597 RVA: 0x000863DC File Offset: 0x000845DC
	public void method_1()
	{
		this.m_gamemodeName = base.GetType().ToString();
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].m_teamID = this.vmethod_9(list[i]);
			MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_6(list[i]);
		}
		this.vmethod_5();
	}

	// Token: 0x060019C6 RID: 6598 RVA: 0x00013168 File Offset: 0x00011368
	public void method_2()
	{
		this.vmethod_6();
	}

	// Token: 0x060019C7 RID: 6599 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5()
	{
	}

	// Token: 0x060019C8 RID: 6600 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7()
	{
	}

	// Token: 0x060019CA RID: 6602 RVA: 0x00013170 File Offset: 0x00011370
	public virtual void vmethod_8()
	{
		MonoSingleton<EntityManager>.Instance.method_8(Entity.EntityType.Npc);
	}

	// Token: 0x060019CB RID: 6603 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_9(PlayerInfoSync playerInfoSync_0)
	{
		return 0;
	}

	// Token: 0x060019CC RID: 6604 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_3(PlayerInfoSync playerInfoSync_0)
	{
	}

	// Token: 0x060019CD RID: 6605 RVA: 0x00086450 File Offset: 0x00084650
	public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		Entity component = instance.GetComponent<Entity>();
		if (component != null && component.vmethod_8() == Entity.EntityType.Player)
		{
			instance.GetComponent<MovementSync>().method_4(request.m_position, request.m_rotation);
		}
	}

	// Token: 0x060019CE RID: 6606 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnSpawn(Entity playerEntity)
	{
	}

	// Token: 0x04001143 RID: 4419
	private string m_gamemodeName;

	// Token: 0x04001144 RID: 4420
	private static List<Type> m_modeTypes = new List<Type>();
}
