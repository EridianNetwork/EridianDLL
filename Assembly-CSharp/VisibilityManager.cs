using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000566 RID: 1382
public class VisibilityManager : MonoSingleton<VisibilityManager>
{
	// Token: 0x0600238F RID: 9103 RVA: 0x000A900C File Offset: 0x000A720C
	private void Update()
	{
		this.m_removelist.Clear();
		for (int i = 0; i < this.m_meshRenders.Count; i++)
		{
			Renderer renderer = this.m_meshRenders[i];
			if (renderer == null)
			{
				this.m_removelist.Add(renderer);
			}
		}
		for (int j = 0; j < this.m_removelist.Count; j++)
		{
			Renderer renderer2 = this.m_removelist[j];
			if (renderer2 == null)
			{
				this.m_meshRenders.Remove(renderer2);
			}
		}
		int num = 0;
		List<Entity> list;
		MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Player, out list);
		this.method_5(ref list);
		this.method_6(ref list);
		for (int k = 0; k < list.Count; k++)
		{
			if (!(list[k] as EntityPlayer).vmethod_26() && (list[k] as EntityPlayer).vmethod_21())
			{
				if (!this.method_7(list[k]))
				{
					if (GroupManager.smethod_0().method_17((list[k] as EntityPlayer).method_20()))
					{
						goto IL_013D;
					}
					if (num < this.MaxVisibileNumber && !this.m_invisibles.ContainsKey(list[k]))
					{
						num++;
						goto IL_013D;
					}
				}
				this.method_3(list[k]);
			}
			IL_013D:;
		}
		if (num < this.MaxVisibileNumber)
		{
			int num2 = Mathf.Min(this.m_invisibles.Count, this.MaxVisibileNumber - num);
			int num3 = 0;
			Dictionary<Entity, List<Renderer>>.Enumerator enumerator = this.m_invisibles.GetEnumerator();
			while (enumerator.MoveNext() && num3 < num2)
			{
				KeyValuePair<Entity, List<Renderer>> keyValuePair = enumerator.Current;
				this.method_4(keyValuePair.Key);
				num++;
				if (num >= this.MaxVisibileNumber)
				{
					break;
				}
				num3++;
			}
		}
		for (int l = 0; l < this.m_invisiblesRemover.Count; l++)
		{
			this.m_invisibles.Remove(this.m_invisiblesRemover[l]);
		}
		this.m_invisiblesRemover.Clear();
	}

	// Token: 0x06002390 RID: 9104 RVA: 0x000185CD File Offset: 0x000167CD
	public void method_0(Renderer renderer_0)
	{
		this.method_1();
		if (renderer_0)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "VisibilityManager.Register[" + renderer_0.name + "]");
			this.m_meshRenders.Add(renderer_0);
		}
	}

	// Token: 0x06002391 RID: 9105 RVA: 0x000A921C File Offset: 0x000A741C
	private void method_1()
	{
		for (int i = this.m_meshRenders.Count - 1; i >= 0; i--)
		{
			if (null == this.m_meshRenders[i])
			{
				this.m_meshRenders.RemoveAt(i);
			}
		}
	}

	// Token: 0x06002392 RID: 9106 RVA: 0x000A9264 File Offset: 0x000A7464
	public void method_2(Renderer renderer_0)
	{
		if (renderer_0 == null)
		{
			return;
		}
		this.method_1();
		if (this.m_meshRenders == null)
		{
			return;
		}
		DebugUtils.Log(LogCategory.Gamelogic, "VisibilityManager.Unregister[" + renderer_0.name + "]");
		this.m_meshRenders.Remove(renderer_0);
	}

	// Token: 0x06002393 RID: 9107 RVA: 0x000A92B4 File Offset: 0x000A74B4
	private void method_3(Entity entity_0)
	{
		for (int i = 0; i < this.m_meshRenders.Count; i++)
		{
			if (!(this.m_meshRenders[i] == null))
			{
				if (this.m_meshRenders[i].transform.IsChildOf(entity_0.transform) && this.m_meshRenders[i].enabled)
				{
					List<Renderer> list;
					if (this.m_invisibles.TryGetValue(entity_0, out list))
					{
						if (list != null)
						{
							list.Add(this.m_meshRenders[i]);
						}
					}
					else
					{
						list = new List<Renderer>();
						list.Add(this.m_meshRenders[i]);
						this.m_invisibles.Add(entity_0, list);
					}
					this.m_meshRenders[i].enabled = false;
				}
				EntityPlayer entityPlayer = entity_0 as EntityPlayer;
				if (entityPlayer == null)
				{
					return;
				}
				CollisionManager collisionManager = entityPlayer.vmethod_21();
				if (collisionManager != null)
				{
					collisionManager.method_9(false);
				}
				entityPlayer.method_142(false);
			}
		}
	}

	// Token: 0x06002394 RID: 9108 RVA: 0x000A93B4 File Offset: 0x000A75B4
	private void method_4(Entity entity_0)
	{
		List<Renderer> list;
		if (entity_0 && this.m_invisibles.TryGetValue(entity_0, out list))
		{
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].enabled = true;
				}
				list.Clear();
			}
			this.m_invisiblesRemover.Add(entity_0);
			EntityPlayer entityPlayer = entity_0 as EntityPlayer;
			if (entityPlayer == null)
			{
				return;
			}
			CollisionManager collisionManager = entityPlayer.vmethod_21();
			if (collisionManager != null)
			{
				collisionManager.method_9(true);
			}
			entityPlayer.method_142(true);
		}
	}

	// Token: 0x06002395 RID: 9109 RVA: 0x000A943C File Offset: 0x000A763C
	private void method_5(ref List<Entity> list_0)
	{
		int num = 0;
		for (int i = 0; i < list_0.Count; i++)
		{
			if (FriendManager.smethod_0().method_26((list_0[i] as EntityPlayer).method_20()))
			{
				Entity entity = list_0[num];
				list_0[num] = list_0[i];
				list_0[i] = entity;
				num++;
			}
		}
	}

	// Token: 0x06002396 RID: 9110 RVA: 0x000A94A4 File Offset: 0x000A76A4
	private void method_6(ref List<Entity> list_0)
	{
		int num = 0;
		for (int i = 0; i < list_0.Count; i++)
		{
			if (GuildManager.smethod_0().method_1((list_0[i] as EntityPlayer).method_20()))
			{
				Entity entity = list_0[num];
				list_0[num] = list_0[i];
				list_0[i] = entity;
				num++;
			}
		}
	}

	// Token: 0x06002397 RID: 9111 RVA: 0x000A950C File Offset: 0x000A770C
	private bool method_7(Entity entity_0)
	{
		PlayerAnimationManagerFSM playerAnimationManagerFSM = entity_0.vmethod_12() as PlayerAnimationManagerFSM;
		return playerAnimationManagerFSM && playerAnimationManagerFSM.method_56() && Time.time - entity_0.method_9() > 2f;
	}

	// Token: 0x04001836 RID: 6198
	public int MaxVisibileNumber = 30;

	// Token: 0x04001837 RID: 6199
	public List<Renderer> m_meshRenders = new List<Renderer>();

	// Token: 0x04001838 RID: 6200
	public Dictionary<Entity, List<Renderer>> m_invisibles = new Dictionary<Entity, List<Renderer>>();

	// Token: 0x04001839 RID: 6201
	private List<Entity> m_invisiblesRemover = new List<Entity>();

	// Token: 0x0400183A RID: 6202
	private List<Renderer> m_removelist = new List<Renderer>();
}
