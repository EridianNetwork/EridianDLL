using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x02000541 RID: 1345
public class MarkTitleController
{
	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x060022C5 RID: 8901 RVA: 0x00017E04 File Offset: 0x00016004
	private NpcTitleMgr NpcTitleMgr_0
	{
		get
		{
			if (this.m_uimgr == null)
			{
				this.m_uimgr = MonoSingleton<GraphicsMgr>.Instance.method_21();
			}
			return this.m_uimgr;
		}
	}

	// Token: 0x060022C6 RID: 8902 RVA: 0x00017E24 File Offset: 0x00016024
	public void method_0()
	{
		this.m_uiResource.method_0();
	}

	// Token: 0x060022C7 RID: 8903 RVA: 0x000A507C File Offset: 0x000A327C
	public void OnGetTitleInfo(MarkManager.BroadcastMarkedInfo _newInfo)
	{
		if (_newInfo.m_entity_id == -1)
		{
			MarkManager.MarkManager_0.m_markProgress_client = _newInfo.m_mark_level;
			return;
		}
		if (_newInfo != null && !(_newInfo.method_0() == null) && !_newInfo.method_0().vmethod_53() && this.m_titleList != null)
		{
			int entity_id = _newInfo.m_entity_id;
			if (!this.m_titleList.ContainsKey(entity_id))
			{
				this.m_titleList[entity_id] = new MarkTitleController.TitleInfo(null);
			}
			MarkTitleController.TitleInfo titleInfo = this.m_titleList[entity_id];
			int mark_level = titleInfo.m_markedInfo.m_mark_level;
			int mark_level2 = _newInfo.m_mark_level;
			if (mark_level != mark_level2)
			{
				this.m_uiResource.method_1(_newInfo.method_0(), mark_level2);
				if (mark_level2 > mark_level)
				{
					this.method_5(_newInfo.method_0());
				}
			}
			titleInfo.m_markedInfo = _newInfo;
			return;
		}
	}

	// Token: 0x060022C8 RID: 8904 RVA: 0x000A5144 File Offset: 0x000A3344
	public void OnLateUpdate()
	{
		Dictionary<int, TitleInfo>.Enumerator enumerator = m_titleList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value != null)
			{
				enumerator.Current.Value.method_0();
			}
		}
		enumerator = m_titleList.GetEnumerator();
		m_toRemoveList.Clear();
		while (enumerator.MoveNext())
		{
			TitleInfo value = enumerator.Current.Value;
			if (value != null && value.m_markedInfo != null)
			{
				Entity entity = value.m_markedInfo.method_0();
				if (!(entity == null) && entity.vmethod_53())
				{
					m_toRemoveList.Add(value);
				}
			}
		}
		for (int i = 0; i < m_toRemoveList.Count; i++)
		{
			TitleInfo titleInfo = m_toRemoveList[i];
			if (titleInfo != null && titleInfo.m_markedInfo != null)
			{
				Entity entity2 = titleInfo.m_markedInfo.method_0();
				if (!(entity2 == null))
				{
					m_uiResource.method_1(titleInfo.m_markedInfo.method_0(), 0);
					m_titleList.Remove(titleInfo.m_markedInfo.m_entity_id);
				}
			}
		}
	}
	// Token: 0x060022C9 RID: 8905 RVA: 0x000A5270 File Offset: 0x000A3470
	public bool method_1(Entity entity_0)
	{
		bool flag = false;
		int num = entity_0.vmethod_0();
		MarkTitleController.TitleInfo titleInfo;
		if (this.m_titleList.TryGetValue(num, out titleInfo))
		{
			MarkManager.BroadcastMarkedInfo markedInfo = titleInfo.m_markedInfo;
			flag = markedInfo.m_mark_level > 0;
		}
		return flag;
	}

	// Token: 0x060022CA RID: 8906 RVA: 0x000A52A8 File Offset: 0x000A34A8
	public bool method_2(int int_0)
	{
		bool flag = false;
		MarkTitleController.TitleInfo titleInfo;
		if (this.m_titleList.TryGetValue(int_0, out titleInfo))
		{
			MarkManager.BroadcastMarkedInfo markedInfo = titleInfo.m_markedInfo;
			flag = markedInfo.m_mark_level > 0;
		}
		return flag;
	}

	// Token: 0x060022CB RID: 8907 RVA: 0x000A52DC File Offset: 0x000A34DC
	public List<Entity> method_3()
	{
		m_temp_marked_list.Clear();
		Dictionary<int, TitleInfo>.Enumerator enumerator = m_titleList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value.m_markedInfo.m_mark_level > 0)
			{
				m_temp_marked_list.Add(enumerator.Current.Value.m_markedInfo.method_0());
			}
		}
		return m_temp_marked_list;
	}
	// Token: 0x060022CC RID: 8908 RVA: 0x000A5354 File Offset: 0x000A3554
	public bool method_4(Entity entity_0)
	{
		EntityPlayer entityPlayer = entity_0 as EntityPlayer;
		return entityPlayer != null && entityPlayer.vmethod_25().IsMyActor();
	}

	// Token: 0x060022CD RID: 8909 RVA: 0x000A5380 File Offset: 0x000A3580
	private void method_5(Entity entity_0)
	{
		WeakPoint weakPoint = null;
		entity_0.method_8(out weakPoint);
		entity_0.vmethod_15().method_5(ENPCParticleType.E_Marked_Slag, entity_0, weakPoint.transform, Vector3.zero, Quaternion.identity, 0f, true);
		MarkCollect.MarkCollect_0.OnMarkLevelChanged(entity_0);
	}

	// Token: 0x0400171C RID: 5916
	private Dictionary<int, MarkTitleController.TitleInfo> m_titleList = new Dictionary<int, MarkTitleController.TitleInfo>();

	// Token: 0x0400171D RID: 5917
	private List<MarkTitleController.TitleInfo> m_toRemoveList = new List<MarkTitleController.TitleInfo>();

	// Token: 0x0400171E RID: 5918
	private NpcTitleMgr m_uimgr;

	// Token: 0x0400171F RID: 5919
	private MarkUIResources m_uiResource = new MarkUIResources();

	// Token: 0x04001720 RID: 5920
	private List<Entity> m_temp_marked_list = new List<Entity>();

	// Token: 0x02000542 RID: 1346
	public class TitleInfo
	{
		// Token: 0x060022CE RID: 8910 RVA: 0x00017E31 File Offset: 0x00016031
		public TitleInfo(MarkManager.BroadcastMarkedInfo broadcastMarkedInfo_0)
		{
			if (broadcastMarkedInfo_0 == null)
			{
				this.m_markedInfo = new MarkManager.BroadcastMarkedInfo(0, 0);
			}
			else
			{
				this.m_markedInfo = broadcastMarkedInfo_0;
			}
		}

		// Token: 0x060022CF RID: 8911 RVA: 0x000A53C8 File Offset: 0x000A35C8
		public void method_0()
		{
			if (this.m_markedInfo != null && !(MonoSingleton<GraphicsMgr>.Instance == null) && MonoSingleton<GraphicsMgr>.Instance.method_16() != null)
			{
				if (this.m_markedInfo.m_mark_level > 0 && this.level_lasttick == 0)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_16().method_4(this.m_markedInfo.method_0(), 99999f, CharacterFxMgr.FX_TYPE.FX_HUNTER_MARK);
				}
				else if (this.m_markedInfo.m_mark_level == 0 && this.level_lasttick > 0)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_16().method_5(this.m_markedInfo.method_0());
				}
				this.level_lasttick = this.m_markedInfo.m_mark_level;
				return;
			}
		}

		// Token: 0x04001721 RID: 5921
		public MarkManager.BroadcastMarkedInfo m_markedInfo;

		// Token: 0x04001722 RID: 5922
		private int level_lasttick;
	}
}
