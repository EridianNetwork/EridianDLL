using System;
using System.Collections.Generic;
using System.Linq;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000719 RID: 1817
public class UIMapDataManager : IGroupServiceNotificationListerner, IMailServiceNotificationListener, IQuestServiceNotificationListerner, IDamageListener, IQuestUINotificationListerner
{
	// Token: 0x0600302E RID: 12334 RVA: 0x000DBA94 File Offset: 0x000D9C94
	protected UIMapDataManager()
	{
	}

	// Token: 0x0600302F RID: 12335 RVA: 0x0001F956 File Offset: 0x0001DB56
	public static UIMapDataManager smethod_0()
	{
		if (UIMapDataManager._instance == null)
		{
			UIMapDataManager._instance = new UIMapDataManager();
		}
		return UIMapDataManager._instance;
	}

	// Token: 0x17000255 RID: 597
	// (get) Token: 0x06003030 RID: 12336 RVA: 0x0001F96E File Offset: 0x0001DB6E
	public UIMapDataManager.MapContext MapContext_0
	{
		get
		{
			return this._curMapContext;
		}
	}

	// Token: 0x06003031 RID: 12337 RVA: 0x000DBB3C File Offset: 0x000D9D3C
	public void method_0()
	{
		GameObject gameObject = GameObject.Find("PRE_MiniMap");
		this._curStatus = UIMapDataManager.MinimapStatus.Loading;
		if (gameObject != null)
		{
			this._curMapContext = new UIMapDataManager.MapContext();
			this._curMapContext.curMiniMapConfig = gameObject.GetComponent<MiniMapConfig>();
			if (this._curMapContext.curMiniMapConfig != null)
			{
				Vector2 vector = new Vector3(0f, 0f);
				vector.x = this._curMapContext.curMiniMapConfig.NormalInWorldView.x;
				vector.y = this._curMapContext.curMiniMapConfig.NormalInWorldView.z;
				Vector2 vector2 = new Vector2(0f, 1f);
				float num = vector.x * vector2.y - vector.y * vector2.x;
				this._fOffsetAngle = Vector2.Angle(vector2, vector);
				if (num < 0f)
				{
					this._fOffsetAngle = 360f - this._fOffsetAngle;
				}
				this._curMapContext.curMiniMapConfig.RectEndPoint = Quaternion.Euler(0f, this._fOffsetAngle, 0f) * this._curMapContext.curMiniMapConfig.RectEndPoint;
				this._curMapContext.curMiniMapConfig.RectOriginPoint = Quaternion.Euler(0f, this._fOffsetAngle, 0f) * this._curMapContext.curMiniMapConfig.RectOriginPoint;
				this._v3DisplayAreaWorldSize.x = Math.Abs(this._curMapContext.curMiniMapConfig.RectEndPoint.x - this._curMapContext.curMiniMapConfig.RectOriginPoint.x);
				this._v3DisplayAreaWorldSize.z = Math.Abs(this._curMapContext.curMiniMapConfig.RectEndPoint.z - this._curMapContext.curMiniMapConfig.RectOriginPoint.z);
				this._curMapContext.v2DisplayAreaLocalSize.x = this._v3DisplayAreaWorldSize.x;
				this._curMapContext.v2DisplayAreaLocalSize.y = this._v3DisplayAreaWorldSize.z;
				if (this._curMapContext.curMiniMapConfig.MiniMapTexture != null && this._curMapContext.curMiniMapConfig.MiniMapTexture.Length > 0)
				{
					this._curMapContext.defaultTexture = this._curMapContext.curMiniMapConfig.MiniMapTexture[0].texture;
				}
				ServiceWrapperBase<GroupServiceWrapper>.Instance.method_0(this);
				GroupManager.smethod_0().method_30(new GroupManager.DeleOnGetGroupInfo(this.method_10));
				for (int i = 0; i < GroupManager.smethod_0().m_GroupInfoMap.Count; i++)
				{
					this.method_23(GroupManager.smethod_0().m_GroupInfoMap.ElementAt<KeyValuePair<int, Presence>>(i).Value.mCharacterId);
				}
				if (DamageManager.DamageManager_0 != null)
				{
					DamageManager.DamageManager_0.method_3(this);
				}
				QuestUIDataManager.smethod_0().method_0(this);
				ServiceWrapperBase<MailServiceWrapper>.Instance.method_1(this);
				this._curMapContext.strInstanceName = MonoSingleton<Session>.Instance.method_1();
				this._curMapContext.iMapIndex = (int)MonoSingleton<Session>.Instance.method_4();
				this._curMapContext.bIsPVP = MonoSingleton<Session>.Instance.method_12();
				Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(MonoSingleton<AppManager>.Instance.m_playlistId);
				if (playlist != null)
				{
					this._curMapContext.iMapSubPartCnt = playlist.m_sceneToPlay.Length;
				}
			}
		}
		else
		{
			this._curStatus = UIMapDataManager.MinimapStatus.LoadConfigFailure;
		}
	}

	// Token: 0x06003032 RID: 12338 RVA: 0x000DBEB0 File Offset: 0x000DA0B0
	public void method_1()
	{
		this._curStatus = UIMapDataManager.MinimapStatus.None;
		this._teamMateIdList.Clear();
		this._curMapContext = null;
		this._dicOnStageObjects.Clear();
		this._onFiredEnemyList.Clear();
		this._listeners.Clear();
		this._mapObjCache.Clear();
		ServiceWrapperBase<GroupServiceWrapper>.Instance.method_1(this);
		GroupManager.smethod_0().method_31(new GroupManager.DeleOnGetGroupInfo(this.method_10));
		ServiceWrapperBase<MailServiceWrapper>.Instance.method_3(this);
		QuestUIDataManager.smethod_0().method_1(this);
		if (DamageManager.DamageManager_0 != null)
		{
			DamageManager.DamageManager_0.method_4(this);
		}
	}

	// Token: 0x06003033 RID: 12339 RVA: 0x000DBF54 File Offset: 0x000DA154
	protected void method_2()
	{
		if (this._localPlayer != null && this._localPlayer.GetEntity() != null)
		{
			GameObject gameObject = null;
			float num = -1f;
			Entity entity = this._localPlayer.GetEntity();
			foreach (WorldCenter worldCenter in global::UnityEngine.Object.FindObjectsOfType<WorldCenter>())
			{
				float magnitude = (worldCenter.transform.position - entity.method_2().position).magnitude;
				if (num > magnitude || num < 0f)
				{
					num = magnitude;
					gameObject = worldCenter.gameObject;
				}
			}
			if (gameObject != null)
			{
				this._v3RelativeOriginPt = gameObject.transform.position;
			}
			this._curStatus = UIMapDataManager.MinimapStatus.Normal;
			this.method_4();
		}
	}

	// Token: 0x06003034 RID: 12340 RVA: 0x000DC020 File Offset: 0x000DA220
	protected Vector2 method_3(Vector3 vector3_0)
	{
		Vector2 vector = new Vector2(0f, 0f);
		Vector3 vector2 = vector3_0 - this._v3RelativeOriginPt;
		Vector3 vector3 = Quaternion.Euler(0f, this._fOffsetAngle, 0f) * vector2;
		if (this._curMapContext != null && this._curMapContext.curMiniMapConfig != null)
		{
			vector.x = Math.Abs(vector3.x - this._curMapContext.curMiniMapConfig.RectOriginPoint.x) / this._v3DisplayAreaWorldSize.x;
			vector.y = Math.Abs(vector3.z - this._curMapContext.curMiniMapConfig.RectOriginPoint.z) / this._v3DisplayAreaWorldSize.z;
		}
		return vector;
	}

	// Token: 0x06003035 RID: 12341 RVA: 0x000DC0F0 File Offset: 0x000DA2F0
	protected void method_4()
	{
		this.currentMapIndex = ((this.candidateMapIndex <= 0) ? 0 : this.candidateMapIndex);
		this.candidateMapIndex = 0;
		foreach (UIMapDataManager.MinimapNotificationListener minimapNotificationListener in this._listeners)
		{
			minimapNotificationListener.OnMapSetup();
		}
		this.method_21();
		this.method_18();
	}

	// Token: 0x06003036 RID: 12342 RVA: 0x000DC16C File Offset: 0x000DA36C
	public void method_5(int int_0)
	{
		if (this._curMapContext.curMiniMapConfig != null && this._curMapContext.curMiniMapConfig.MiniMapTexture != null && this._curMapContext.curMiniMapConfig.MiniMapTexture.Length > int_0)
		{
			this.currentMapIndex = int_0;
			this.candidateMapIndex = int_0;
			this.method_6();
			this.method_14(int_0);
		}
	}

	// Token: 0x06003037 RID: 12343 RVA: 0x000DC1D0 File Offset: 0x000DA3D0
	protected void method_6()
	{
		foreach (KeyValuePair<int, UIMapDataManager.UIMapObject> keyValuePair in this._dicOnStageObjects)
		{
			UIMapDataManager.UIMapObject value = keyValuePair.Value;
			if (value != null && !(value.objInfo == null))
			{
				value.bIsOnSameLayer = value.objInfo.layerIndex == this.currentMapIndex || value.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer || value.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.Badass || value.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.Enemy || value.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.Boss || value.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.Trigger || value.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.RvEnterence_New;
			}
		}
	}

	// Token: 0x06003038 RID: 12344 RVA: 0x000DC290 File Offset: 0x000DA490
	public void Update()
	{
		this._localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (this._curStatus == UIMapDataManager.MinimapStatus.Loading)
		{
			this.method_2();
		}
		if (this._curStatus == UIMapDataManager.MinimapStatus.Normal)
		{
			if (this._curMapContext == null || this._curMapContext.curMiniMapConfig == null)
			{
				return;
			}
			if (this._localPlayer != null && this._localPlayer.GetEntity() != null)
			{
				this.method_7();
				this.vmethod_0();
				this.vmethod_1();
			}
			if (this._curMapContext.bIsPVP)
			{
				int i = 0;
				while (i < this._onFiredEnemyList.Count)
				{
					this._onFiredEnemyList[i].fOnFireTime += Time.deltaTime;
					if (this._onFiredEnemyList[i].fOnFireTime > 5f)
					{
						this._onFiredEnemyList[i].bIsOnFire = false;
						this.method_13(this._onFiredEnemyList[i]);
						this._onFiredEnemyList.RemoveAt(i);
					}
					else
					{
						i++;
					}
				}
			}
		}
	}

	// Token: 0x06003039 RID: 12345 RVA: 0x000DC3AC File Offset: 0x000DA5AC
	protected void method_7()
	{
		Vector3 vector = this._localPlayer.GetEntity().method_1();
		if (this._curMapContext.curMiniMapConfig)
		{
			this._curMapContext.v2PlayerPosInProportion = this.method_3(vector);
		}
	}

	// Token: 0x0600303A RID: 12346 RVA: 0x000DC3F0 File Offset: 0x000DA5F0
	protected virtual void vmethod_0()
	{
		Vector3 vector = this._localPlayer.GetEntity().vmethod_27();
		Vector2 vector2 = new Vector2(vector.x, vector.z);
		Vector2 vector3 = new Vector2(0f, 1f);
		float num = Vector2.Angle(vector3, vector2);
		float num2 = vector2.x * vector3.y - vector2.y * vector3.x;
		if (num2 < 0f)
		{
			num = 360f - num;
		}
		num -= this._fOffsetAngle;
		this._curMapContext.fPlayerDirAngle = num;
	}

	// Token: 0x0600303B RID: 12347 RVA: 0x000DC484 File Offset: 0x000DA684
	protected virtual void vmethod_1()
	{
		foreach (KeyValuePair<int, UIMapDataManager.UIMapObject> keyValuePair in this._dicOnStageObjects)
		{
			UIMapDataManager.UIMapObject value = keyValuePair.Value;
			if (value != null && !(value.objInfo == null) && !(value.objInfo.gameObject == null))
			{
				value.v2LocalPosInProportion = this.method_3(value.objInfo.gameObject.transform.position);
			}
		}
	}

	// Token: 0x0600303C RID: 12348 RVA: 0x000DC500 File Offset: 0x000DA700
	public void OnDamaged(DamageContext damageContext)
	{
		if (this._curMapContext == null)
		{
			return;
		}
		if (this._curMapContext.bIsPVP && damageContext.m_victim != null && this._localPlayer != null && damageContext.m_killer != null)
		{
			PlayerInfoSync playerInfoSync = damageContext.m_killer.vmethod_25();
			PlayerInfoSync playerInfoSync2 = damageContext.m_victim.vmethod_25();
			if (playerInfoSync != null && playerInfoSync2 != null && playerInfoSync.m_teamID == this._localPlayer.m_teamID)
			{
				foreach (KeyValuePair<int, UIMapDataManager.UIMapObject> keyValuePair in this._dicOnStageObjects)
				{
					UIMapDataManager.UIMapObject value = keyValuePair.Value;
					if (value != null && !(value.objInfo == null) && value.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer && value.objInfo.iCharacterID == playerInfoSync2.m_characterId)
					{
						value.fOnFireTime = 0f;
						value.bIsOnFire = true;
						this.method_13(value);
						if (this._onFiredEnemyList != null && !this._onFiredEnemyList.Contains(value))
						{
							this._onFiredEnemyList.Add(value);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600303D RID: 12349 RVA: 0x000DC640 File Offset: 0x000DA840
	public virtual void OnEntityKill(KillContext killContext)
	{
		if (killContext.m_victim == null)
		{
			return;
		}
		if (killContext.m_victim.vmethod_8() == Entity.EntityType.Npc)
		{
			MapObjectMark component = killContext.m_victim.GetComponent<MapObjectMark>();
			if (component != null)
			{
				global::UnityEngine.Object.Destroy(component);
			}
		}
		if (this._curMapContext.bIsPVP && killContext.m_victim != null && this._localPlayer != null && killContext.m_killer != null && killContext.m_killer.vmethod_25() != null && killContext.m_victim.vmethod_25() != null && (killContext.m_killer.vmethod_25().m_teamID == this._localPlayer.m_teamID || killContext.m_victim.vmethod_25().m_teamID == this._localPlayer.m_teamID || killContext.m_killer.vmethod_25().m_characterId == this._localPlayer.m_characterId))
		{
			foreach (UIMapDataManager.UIMapObject uimapObject in this._dicOnStageObjects.Values)
			{
				if ((uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer || uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.TeamMate) && uimapObject.objInfo.iCharacterID == killContext.m_victim.vmethod_25().m_characterId)
				{
					uimapObject.fOnFireTime = 0f;
					uimapObject.bIsOnFire = false;
					uimapObject.bIsDead = true;
					this.method_13(uimapObject);
				}
			}
		}
	}

	// Token: 0x0600303E RID: 12350 RVA: 0x000DC7F8 File Offset: 0x000DA9F8
	public void OnPlayerPvEStatusUpdate(EntityPlayer revivedPlayer)
	{
		if (revivedPlayer != null)
		{
			foreach (UIMapDataManager.UIMapObject uimapObject in this._dicOnStageObjects.Values)
			{
				if ((uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer || uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.TeamMate) && uimapObject.objInfo.iCharacterID == revivedPlayer.vmethod_25().m_characterId)
				{
					uimapObject.bIsRevived = revivedPlayer.method_149();
					uimapObject.bIsCripple = !uimapObject.bIsRevived && revivedPlayer.method_67();
					uimapObject.bIsDeadInPvE = !uimapObject.bIsRevived && revivedPlayer.vmethod_53();
					uimapObject.bIsDown = !uimapObject.bIsRevived && revivedPlayer.method_65();
					this.method_13(uimapObject);
				}
			}
		}
	}

	// Token: 0x0600303F RID: 12351 RVA: 0x000DC8E8 File Offset: 0x000DAAE8
	public void OnPlayerRevive(EntityPlayer revivedPlayer)
	{
		if (revivedPlayer != null)
		{
			foreach (UIMapDataManager.UIMapObject uimapObject in this._dicOnStageObjects.Values)
			{
				if ((uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer || uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.TeamMate) && uimapObject.objInfo.iCharacterID == revivedPlayer.vmethod_25().m_characterId)
				{
					uimapObject.bIsDead = false;
					this.method_13(uimapObject);
				}
			}
		}
	}

	// Token: 0x06003040 RID: 12352 RVA: 0x0001F976 File Offset: 0x0001DB76
	public void OnQuestUpdate(int characterId, int questId, QuestState questState)
	{
		this.method_8();
	}

	// Token: 0x06003041 RID: 12353 RVA: 0x0001F976 File Offset: 0x0001DB76
	public void OnQuestAbandoned(int characterId, int questId)
	{
		this.method_8();
	}

	// Token: 0x06003042 RID: 12354 RVA: 0x0001F976 File Offset: 0x0001DB76
	public void OnQuestAccepted(int characterId, int questId)
	{
		this.method_8();
	}

	// Token: 0x06003043 RID: 12355 RVA: 0x0001F976 File Offset: 0x0001DB76
	public void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards)
	{
		this.method_8();
	}

	// Token: 0x06003044 RID: 12356 RVA: 0x0001F976 File Offset: 0x0001DB76
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
		this.method_8();
	}

	// Token: 0x06003045 RID: 12357 RVA: 0x0001F976 File Offset: 0x0001DB76
	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> playerQuestProgress)
	{
		this.method_8();
	}

	// Token: 0x06003046 RID: 12358 RVA: 0x0001F976 File Offset: 0x0001DB76
	public void OnTaskProgressUpgrade(int questID, int taskID, int count)
	{
		this.method_8();
	}

	// Token: 0x06003047 RID: 12359 RVA: 0x000DC984 File Offset: 0x000DAB84
	protected void method_8()
	{
		foreach (UIMapDataManager.UIMapObject uimapObject in this._dicOnStageObjects.Values)
		{
			if (uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
			{
				NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
				if (MonoSingleton<TownNpcManager>.Instance != null)
				{
					npc_ICON_TYPE = MonoSingleton<TownNpcManager>.Instance.method_1(uimapObject.objInfo.iNPCID);
				}
				if (npc_ICON_TYPE != uimapObject.npcIconType)
				{
					uimapObject.npcIconType = npc_ICON_TYPE;
					this.method_13(uimapObject);
				}
			}
			else if (uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.RvEnterence || uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.RvEnterence_New)
			{
				bool flag;
				UIMapDataManager.MiniMapObjectType miniMapObjectType = ((!(flag = this.method_9())) ? UIMapDataManager.MiniMapObjectType.RvEnterence : UIMapDataManager.MiniMapObjectType.RvEnterence_New);
				if (miniMapObjectType != uimapObject.objInfo.ObjType)
				{
					uimapObject.objInfo.ObjType = miniMapObjectType;
					uimapObject.objInfo.bAlwaysOnMap = flag;
					this.method_13(uimapObject);
				}
			}
		}
	}

	// Token: 0x06003048 RID: 12360 RVA: 0x000DCA88 File Offset: 0x000DAC88
	private bool method_9()
	{
		if (QuestUIDataManager.smethod_0() != null)
		{
			int[] array = new int[] { 13301, 13302 };
			foreach (int num in array)
			{
				QuestProgress questProgress = QuestUIDataManager.smethod_0().method_4(num);
				if (questProgress != null)
				{
					if (questProgress.mStatus != QuestState.Completed && questProgress.mStatus != QuestState.InProgress)
					{
						if (questProgress.mStatus != QuestState.Available)
						{
							goto IL_0059;
						}
					}
					return true;
				}
				IL_0059:;
			}
		}
		return false;
	}

	// Token: 0x06003049 RID: 12361 RVA: 0x000DCB00 File Offset: 0x000DAD00
	protected void method_10(int int_0, List<Presence> list_0)
	{
		this.method_25();
		for (int i = 0; i < list_0.Count; i++)
		{
			this.method_23(list_0[i].mCharacterId);
		}
	}

	// Token: 0x0600304A RID: 12362 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGroupMatchmakingStarted()
	{
	}

	// Token: 0x0600304B RID: 12363 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId)
	{
	}

	// Token: 0x0600304C RID: 12364 RVA: 0x000DCB38 File Offset: 0x000DAD38
	public void OnKickedFromGroup()
	{
		foreach (int num in this._teamMateIdList)
		{
			this.method_24(num);
		}
		this._teamMateIdList.Clear();
	}

	// Token: 0x0600304D RID: 12365 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnNewGroupLeader(int characterId)
	{
	}

	// Token: 0x0600304E RID: 12366 RVA: 0x0001F97E File Offset: 0x0001DB7E
	public void OnNewGroupMember(Presence characterinfo)
	{
		if (this._localPlayer != null && characterinfo != null && characterinfo.mCharacterId != this._localPlayer.m_characterId)
		{
			this.method_23(characterinfo.mCharacterId);
		}
	}

	// Token: 0x0600304F RID: 12367 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGroupInviteRejected(int characterId, string characterName)
	{
	}

	// Token: 0x06003050 RID: 12368 RVA: 0x0001F9B0 File Offset: 0x0001DBB0
	public void OnGroupMemberLeft(int characterId)
	{
		this.method_24(characterId);
	}

	// Token: 0x06003051 RID: 12369 RVA: 0x000DCB38 File Offset: 0x000DAD38
	public void OnGroupDisbanded()
	{
		foreach (int num in this._teamMateIdList)
		{
			this.method_24(num);
		}
		this._teamMateIdList.Clear();
	}

	// Token: 0x06003052 RID: 12370 RVA: 0x000DCB98 File Offset: 0x000DAD98
	protected void method_11(UIMapDataManager.UIMapObject uimapObject_0)
	{
		foreach (UIMapDataManager.MinimapNotificationListener minimapNotificationListener in this._listeners)
		{
			minimapNotificationListener.OnAddNewMapObject(uimapObject_0);
		}
	}

	// Token: 0x06003053 RID: 12371 RVA: 0x000DCBEC File Offset: 0x000DADEC
	protected void method_12(UIMapDataManager.UIMapObject uimapObject_0)
	{
		foreach (UIMapDataManager.MinimapNotificationListener minimapNotificationListener in this._listeners)
		{
			minimapNotificationListener.OnRemoveMapObject(uimapObject_0);
		}
	}

	// Token: 0x06003054 RID: 12372 RVA: 0x000DCC40 File Offset: 0x000DAE40
	protected void method_13(UIMapDataManager.UIMapObject uimapObject_0)
	{
		foreach (UIMapDataManager.MinimapNotificationListener minimapNotificationListener in this._listeners)
		{
			minimapNotificationListener.OnMapObjectUpdate(uimapObject_0);
		}
	}

	// Token: 0x06003055 RID: 12373 RVA: 0x000DCC94 File Offset: 0x000DAE94
	protected void method_14(int int_0)
	{
		foreach (UIMapDataManager.MinimapNotificationListener minimapNotificationListener in this._listeners)
		{
			minimapNotificationListener.OnSwitchMapTexture(int_0);
		}
	}

	// Token: 0x06003056 RID: 12374 RVA: 0x0001F9B9 File Offset: 0x0001DBB9
	public void method_15(UIMapDataManager.MinimapNotificationListener minimapNotificationListener_0)
	{
		this._listeners.Add(minimapNotificationListener_0);
	}

	// Token: 0x06003057 RID: 12375 RVA: 0x0001F9C7 File Offset: 0x0001DBC7
	public void method_16(UIMapDataManager.MinimapNotificationListener minimapNotificationListener_0)
	{
		this._listeners.Remove(minimapNotificationListener_0);
	}

	// Token: 0x06003058 RID: 12376 RVA: 0x0001F9D6 File Offset: 0x0001DBD6
	public Dictionary<int, UIMapDataManager.UIMapObject> method_17()
	{
		return this._dicOnStageObjects;
	}

	// Token: 0x06003059 RID: 12377 RVA: 0x0001F9DE File Offset: 0x0001DBDE
	public void OnGetNewMail(MailInfo newmail)
	{
		this.method_18();
	}

	// Token: 0x0600305A RID: 12378 RVA: 0x0001F9DE File Offset: 0x0001DBDE
	public void OnGetMailList(List<MailInfo> mailList)
	{
		this.method_18();
	}

	// Token: 0x0600305B RID: 12379 RVA: 0x0001F9DE File Offset: 0x0001DBDE
	public void OnSendMail(int iResult)
	{
		this.method_18();
	}

	// Token: 0x0600305C RID: 12380 RVA: 0x0001F9DE File Offset: 0x0001DBDE
	public void OnReadMail(int mailID)
	{
		this.method_18();
	}

	// Token: 0x0600305D RID: 12381 RVA: 0x0001F9DE File Offset: 0x0001DBDE
	public void OnDeleteMail(int mailID)
	{
		this.method_18();
	}

	// Token: 0x0600305E RID: 12382 RVA: 0x0001F9DE File Offset: 0x0001DBDE
	public void OnGetmailItem(short result, int mailID)
	{
		this.method_18();
	}

	// Token: 0x0600305F RID: 12383 RVA: 0x000DCCE8 File Offset: 0x000DAEE8
	protected void method_18()
	{
		foreach (UIMapDataManager.UIMapObject uimapObject in this._dicOnStageObjects.Values)
		{
			if (uimapObject.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC && MonoSingleton<TownNpcManager>.Instance)
			{
				NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = MonoSingleton<TownNpcManager>.Instance.method_1(uimapObject.objInfo.iNPCID);
				if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL || npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL_NEW)
				{
					uimapObject.iUnreadMailCnt = ServiceWrapperBase<MailServiceWrapper>.Instance.method_2();
					uimapObject.objInfo.bAlwaysOnMap = uimapObject.iUnreadMailCnt > 0;
					uimapObject.npcIconType = npc_ICON_TYPE;
					this.method_13(uimapObject);
				}
			}
		}
	}

	// Token: 0x06003060 RID: 12384 RVA: 0x000DCDA4 File Offset: 0x000DAFA4
	public void method_19(MapObjectMark mapObjectMark_0)
	{
		if (this._curStatus != UIMapDataManager.MinimapStatus.None)
		{
			if (this._curStatus != UIMapDataManager.MinimapStatus.Loading)
			{
				if (this._curStatus == UIMapDataManager.MinimapStatus.Normal && this.method_20(mapObjectMark_0) && mapObjectMark_0.ObjType != UIMapDataManager.MiniMapObjectType.None)
				{
					UIMapDataManager.UIMapObject uimapObject = new UIMapDataManager.UIMapObject();
					uimapObject.objInfo = mapObjectMark_0;
					uimapObject.v2LocalPosInProportion = this.method_3(mapObjectMark_0.gameObject.transform.position);
					uimapObject.bIsOnSameLayer = mapObjectMark_0.layerIndex == this.currentMapIndex || mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer || mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.Badass || mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.Enemy || mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.Boss || mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.Trigger || mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.RvEnterence_New;
					this._dicOnStageObjects.Add(mapObjectMark_0.GetInstanceID(), uimapObject);
					if (mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
					{
						if (MonoSingleton<TownNpcManager>.Instance != null)
						{
							uimapObject.npcIconType = MonoSingleton<TownNpcManager>.Instance.method_1(mapObjectMark_0.iNPCID);
						}
					}
					else if (mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.RvEnterence || mapObjectMark_0.ObjType == UIMapDataManager.MiniMapObjectType.RvEnterence_New)
					{
						bool flag;
						UIMapDataManager.MiniMapObjectType miniMapObjectType = ((!(flag = this.method_9())) ? UIMapDataManager.MiniMapObjectType.RvEnterence : UIMapDataManager.MiniMapObjectType.RvEnterence_New);
						if (miniMapObjectType != mapObjectMark_0.ObjType)
						{
							uimapObject.objInfo.ObjType = miniMapObjectType;
							uimapObject.objInfo.bAlwaysOnMap = flag;
						}
					}
					this.method_11(uimapObject);
					return;
				}
				return;
			}
		}
		this._mapObjCache.Add(mapObjectMark_0.GetInstanceID(), mapObjectMark_0);
	}

	// Token: 0x06003061 RID: 12385 RVA: 0x000DCF0C File Offset: 0x000DB10C
	protected bool method_20(MapObjectMark mapObjectMark_0)
	{
		Vector2 vector = this.method_3(mapObjectMark_0.gameObject.transform.position);
		return this._rectDisplayArea.Contains(vector);
	}

	// Token: 0x06003062 RID: 12386 RVA: 0x000DCF3C File Offset: 0x000DB13C
	protected void method_21()
	{
		List<MapObjectMark> list = new List<MapObjectMark>(this._mapObjCache.Values);
		this._mapObjCache.Clear();
		foreach (MapObjectMark mapObjectMark in list)
		{
			this.method_19(mapObjectMark);
		}
		list.Clear();
	}

	// Token: 0x06003063 RID: 12387 RVA: 0x000DCFAC File Offset: 0x000DB1AC
	public void method_22(MapObjectMark mapObjectMark_0)
	{
		if (this._curStatus == UIMapDataManager.MinimapStatus.Normal)
		{
			UIMapDataManager.UIMapObject uimapObject = null;
			this._dicOnStageObjects.TryGetValue(mapObjectMark_0.GetInstanceID(), out uimapObject);
			if (uimapObject != null)
			{
				this._dicOnStageObjects.Remove(mapObjectMark_0.GetInstanceID());
				this.method_12(uimapObject);
			}
		}
		else if (this._mapObjCache.ContainsKey(mapObjectMark_0.GetInstanceID()))
		{
			this._mapObjCache.Remove(mapObjectMark_0.GetInstanceID());
		}
	}

	// Token: 0x06003064 RID: 12388 RVA: 0x000DD01C File Offset: 0x000DB21C
	protected void method_23(int int_0)
	{
		if (this._localPlayer == null)
		{
			return;
		}
		if (int_0 == -1 || int_0 == this._localPlayer.m_characterId || this._teamMateIdList.Contains(int_0))
		{
			return;
		}
		PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.method_36(int_0);
		if (!(playerInfoSync == null) && !(playerInfoSync.GetEntity() == null))
		{
			GameObject gameObject = playerInfoSync.GetEntity().gameObject;
			if (gameObject != null)
			{
				MapObjectMark component = gameObject.GetComponent<MapObjectMark>();
				if (component == null)
				{
					MapObjectMark mapObjectMark = playerInfoSync.GetEntity().gameObject.AddComponent<MapObjectMark>();
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.TeamMate;
					mapObjectMark.bAlwaysOnMap = true;
					mapObjectMark.method_0();
					this._teamMateIdList.Add(int_0);
				}
				else if (component.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer)
				{
					component.ObjType = UIMapDataManager.MiniMapObjectType.TeamMate;
					UIMapDataManager.UIMapObject uimapObject = null;
					if (this._dicOnStageObjects.TryGetValue(component.GetInstanceID(), out uimapObject))
					{
						this.method_13(uimapObject);
					}
					this._teamMateIdList.Add(int_0);
				}
				else if (component.ObjType == UIMapDataManager.MiniMapObjectType.TeamMate)
				{
					component.method_0();
					this._teamMateIdList.Add(int_0);
				}
			}
			return;
		}
	}

	// Token: 0x06003065 RID: 12389 RVA: 0x000DD140 File Offset: 0x000DB340
	protected void method_24(int int_0)
	{
		if (this._teamMateIdList.Contains(int_0))
		{
			PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.method_36(int_0);
			if (playerInfoSync != null && playerInfoSync.GetEntity() != null)
			{
				MapObjectMark component = playerInfoSync.GetEntity().gameObject.GetComponent<MapObjectMark>();
				if (component != null)
				{
					global::UnityEngine.Object.Destroy(component);
				}
			}
		}
	}

	// Token: 0x06003066 RID: 12390 RVA: 0x000DCB38 File Offset: 0x000DAD38
	protected void method_25()
	{
		foreach (int num in this._teamMateIdList)
		{
			this.method_24(num);
		}
		this._teamMateIdList.Clear();
	}

	// Token: 0x04002176 RID: 8566
	protected static UIMapDataManager _instance;

	// Token: 0x04002177 RID: 8567
	protected UIMapDataManager.MapContext _curMapContext = new UIMapDataManager.MapContext();

	// Token: 0x04002178 RID: 8568
	protected Vector3 _v3DisplayAreaWorldSize = new Vector3(0f, 0f, 0f);

	// Token: 0x04002179 RID: 8569
	protected Vector3 _v3RelativeOriginPt = new Vector3(0f, 0f, 0f);

	// Token: 0x0400217A RID: 8570
	protected Rect _rectDisplayArea = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x0400217B RID: 8571
	protected PlayerInfoSync _localPlayer;

	// Token: 0x0400217C RID: 8572
	protected Dictionary<int, UIMapDataManager.UIMapObject> _dicOnStageObjects = new Dictionary<int, UIMapDataManager.UIMapObject>();

	// Token: 0x0400217D RID: 8573
	protected Dictionary<int, MapObjectMark> _mapObjCache = new Dictionary<int, MapObjectMark>();

	// Token: 0x0400217E RID: 8574
	protected List<int> _teamMateIdList = new List<int>();

	// Token: 0x0400217F RID: 8575
	protected List<UIMapDataManager.UIMapObject> _onFiredEnemyList = new List<UIMapDataManager.UIMapObject>();

	// Token: 0x04002180 RID: 8576
	protected List<UIMapDataManager.MinimapNotificationListener> _listeners = new List<UIMapDataManager.MinimapNotificationListener>();

	// Token: 0x04002181 RID: 8577
	protected float _fOffsetAngle;

	// Token: 0x04002182 RID: 8578
	protected int currentMapIndex;

	// Token: 0x04002183 RID: 8579
	protected int candidateMapIndex;

	// Token: 0x04002184 RID: 8580
	public UIMapDataManager.MinimapStatus _curStatus;

	// Token: 0x0200071A RID: 1818
	public class UIMapObject
	{
		// Token: 0x04002185 RID: 8581
		public MapObjectMark objInfo;

		// Token: 0x04002186 RID: 8582
		public Vector2 v2LocalPosInProportion = new Vector2(0f, 0f);

		// Token: 0x04002187 RID: 8583
		public NpcTitleMgr.NPC_ICON_TYPE npcIconType;

		// Token: 0x04002188 RID: 8584
		public float fOnFireTime;

		// Token: 0x04002189 RID: 8585
		public bool bIsOnFire;

		// Token: 0x0400218A RID: 8586
		public bool bIsDead;

		// Token: 0x0400218B RID: 8587
		public bool bIsDeadInPvE;

		// Token: 0x0400218C RID: 8588
		public bool bIsCripple;

		// Token: 0x0400218D RID: 8589
		public bool bIsRevived;

		// Token: 0x0400218E RID: 8590
		public bool bIsDown;

		// Token: 0x0400218F RID: 8591
		public bool bIsOnSameLayer = true;

		// Token: 0x04002190 RID: 8592
		public int iUnreadMailCnt;
	}

	// Token: 0x0200071B RID: 1819
	public interface MinimapNotificationListener
	{
		// Token: 0x06003068 RID: 12392
		void OnAddNewMapObject(UIMapDataManager.UIMapObject tarObj);

		// Token: 0x06003069 RID: 12393
		void OnRemoveMapObject(UIMapDataManager.UIMapObject tarObj);

		// Token: 0x0600306A RID: 12394
		void OnMapObjectUpdate(UIMapDataManager.UIMapObject tarObj);

		// Token: 0x0600306B RID: 12395
		void OnSwitchMapTexture(int iNewIdx);

		// Token: 0x0600306C RID: 12396
		void OnMapSetup();
	}

	// Token: 0x0200071C RID: 1820
	public enum MiniMapObjectType
	{
		// Token: 0x04002192 RID: 8594
		None,
		// Token: 0x04002193 RID: 8595
		NPC,
		// Token: 0x04002194 RID: 8596
		TeamMate,
		// Token: 0x04002195 RID: 8597
		Enemy,
		// Token: 0x04002196 RID: 8598
		EnemyPlayer,
		// Token: 0x04002197 RID: 8599
		Boss,
		// Token: 0x04002198 RID: 8600
		Badass,
		// Token: 0x04002199 RID: 8601
		TownExit,
		// Token: 0x0400219A RID: 8602
		WorldMapDevice,
		// Token: 0x0400219B RID: 8603
		Trigger,
		// Token: 0x0400219C RID: 8604
		InstanceExitOpen,
		// Token: 0x0400219D RID: 8605
		InstanceExitClose,
		// Token: 0x0400219E RID: 8606
		RvEnterence,
		// Token: 0x0400219F RID: 8607
		RvEnterence_New
	}

	// Token: 0x0200071D RID: 1821
	public enum MinimapStatus
	{
		// Token: 0x040021A1 RID: 8609
		None,
		// Token: 0x040021A2 RID: 8610
		Loading,
		// Token: 0x040021A3 RID: 8611
		Normal,
		// Token: 0x040021A4 RID: 8612
		LoadConfigFailure,
		// Token: 0x040021A5 RID: 8613
		LocalCoordinateSetupFailed
	}

	// Token: 0x0200071E RID: 1822
	public class MapContext
	{
		// Token: 0x040021A6 RID: 8614
		public MiniMapConfig curMiniMapConfig;

		// Token: 0x040021A7 RID: 8615
		public Vector2 v2DisplayAreaLocalSize;

		// Token: 0x040021A8 RID: 8616
		public Vector2 v2PlayerPosInProportion;

		// Token: 0x040021A9 RID: 8617
		public string strInstanceName;

		// Token: 0x040021AA RID: 8618
		public int iMapIndex;

		// Token: 0x040021AB RID: 8619
		public int iMapSubPartCnt;

		// Token: 0x040021AC RID: 8620
		public float fPlayerDirAngle;

		// Token: 0x040021AD RID: 8621
		public bool bIsPVP;

		// Token: 0x040021AE RID: 8622
		public Texture2D defaultTexture;
	}
}
