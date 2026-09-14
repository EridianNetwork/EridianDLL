using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class EntityAbility : MonoBehaviour
{
	// Token: 0x06001B4D RID: 6989 RVA: 0x00013AAA File Offset: 0x00011CAA
	private void Awake()
	{
		this.m_entity = base.GetComponent<Entity>();
	}

	// Token: 0x06001B4E RID: 6990 RVA: 0x00013AB8 File Offset: 0x00011CB8
	public void method_0(global::Action action_0)
	{
		this.m_Actions.Add(action_0.method_5(), action_0);
		this.m_ActionNames.Add(action_0.GetType().Name, action_0);
		action_0.Start(this.m_entity);
	}

	// Token: 0x06001B4F RID: 6991 RVA: 0x00013AEF File Offset: 0x00011CEF
	public void method_1(global::Action action_0)
	{
		this.m_Actions.Remove(action_0.method_5());
		this.m_ActionNames.Remove(action_0.GetType().Name);
		action_0.vmethod_0(this.m_entity);
	}

	// Token: 0x06001B50 RID: 6992 RVA: 0x00089C0C File Offset: 0x00087E0C
	public void method_2()
	{
		foreach (global::Action action in this.m_Actions.Values)
		{
			action.vmethod_0(this.m_entity);
		}
		this.m_Actions.Clear();
		this.m_ActionNames.Clear();
	}

	// Token: 0x06001B51 RID: 6993 RVA: 0x00013B26 File Offset: 0x00011D26
	public global::Action method_3(int int_0)
	{
		if (this.m_Actions.ContainsKey(int_0))
		{
			return this.m_Actions[int_0];
		}
		return null;
	}

	// Token: 0x06001B52 RID: 6994 RVA: 0x00013B44 File Offset: 0x00011D44
	public global::Action method_4(string string_0)
	{
		return this.m_ActionNames[string_0];
	}

	// Token: 0x06001B53 RID: 6995 RVA: 0x00013B52 File Offset: 0x00011D52
	public void method_5(string string_0, bool bool_0 = true, int int_0 = 0)
	{
		if (bool_0)
		{
			this.m_ActionNames[string_0].vmethod_1(int_0);
		}
		else
		{
			this.m_ActionNames[string_0].method_2(int_0);
		}
	}

	// Token: 0x06001B54 RID: 6996 RVA: 0x00013B7D File Offset: 0x00011D7D
	public void method_6(string string_0, bool bool_0, Vector3 vector3_0)
	{
		if (bool_0)
		{
			this.m_ActionNames[string_0].vmethod_2(vector3_0);
		}
		else
		{
			this.m_ActionNames[string_0].method_3(vector3_0);
		}
	}

	// Token: 0x040011EF RID: 4591
	private Dictionary<int, global::Action> m_Actions = new Dictionary<int, global::Action>();

	// Token: 0x040011F0 RID: 4592
	private Dictionary<string, global::Action> m_ActionNames = new Dictionary<string, global::Action>();

	// Token: 0x040011F1 RID: 4593
	private Entity m_entity;
}
