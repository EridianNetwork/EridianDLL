using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000564 RID: 1380
public class TownNpc : MonoBehaviour, InteractionClient
{
	// Token: 0x0600237C RID: 9084 RVA: 0x000A8A08 File Offset: 0x000A6C08
	private void Awake()
	{
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_0(this);
		}
		this.m_collisionManager = base.gameObject.AddComponent<CollisionManager>();
		if (MonoSingleton<Session>.Instance.GetLocalPlayer() && MonoSingleton<GraphicsMgr>.Instance != null)
		{
			this.m_titleMng = MonoSingleton<GraphicsMgr>.Instance.method_21();
		}
		MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
		mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.NPC;
		mapObjectMark.iNPCID = this.m_npcId;
		mapObjectMark.layerIndex = this.m_mapIndex;
		mapObjectMark.method_0();
	}

	// Token: 0x0600237D RID: 9085 RVA: 0x00015FE4 File Offset: 0x000141E4
	private void OnDestroy()
	{
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_1(this);
		}
	}

	// Token: 0x0600237E RID: 9086 RVA: 0x00018501 File Offset: 0x00016701
	private void Start()
	{
		this.m_collisionManager.method_7(base.GetComponent<Collider>());
		this.m_animManager = base.GetComponentInChildren<TownNPCAnimationManagerFSM>();
		this.method_0();
	}

	// Token: 0x0600237F RID: 9087 RVA: 0x000A8A9C File Offset: 0x000A6C9C
	private void method_0()
	{
		this.m_questIdAsGiver.Clear();
		this.m_questIdAsReclaimer.Clear();
		List<Quest> list = new List<Quest>(ServiceWrapperBase<QuestServiceWrapper>.Instance.method_17().Values);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].mGiverIdList.Contains(this.m_npcId))
			{
				this.m_questIdAsGiver.Add(list[i].mId);
			}
			if (list[i].mReclaimerIdList.Contains(this.m_npcId))
			{
				this.m_questIdAsReclaimer.Add(list[i].mId);
			}
		}
	}

	// Token: 0x06002380 RID: 9088 RVA: 0x000A8B48 File Offset: 0x000A6D48
	private void Update()
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			return;
		}
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return;
		}
		if (MonoSingleton<TownNpcManager>.Instance == null)
		{
			return;
		}
		if (!this.m_isInitialized && MonoSingleton<TownNpcManager>.Instance != null)
		{
			this.m_npcSettings = MonoSingleton<TownNpcManager>.Instance.method_0(this.m_npcId);
			this.m_isInitialized = true;
			if (this.m_npcSettings != null && this.m_titleObj != null && this.m_titleMng != null)
			{
				this.m_titleMng.method_9(this.m_titleObj, new Vector3(0f, -0.05f, 0f), LocalizedString.smethod_0(new LocalizedString(this.m_npcSettings.m_nameId)), NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE);
			}
		}
		if (this.m_titleObj != null && this.m_npcSettings != null && this.m_titleMng != null)
		{
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = MonoSingleton<TownNpcManager>.Instance.method_1(this.m_npcId);
			if (this.m_curentIcon != npc_ICON_TYPE)
			{
				this.m_titleMng.method_2(this.m_titleObj, npc_ICON_TYPE);
				this.m_curentIcon = npc_ICON_TYPE;
			}
		}
		this.method_1();
	}

	// Token: 0x06002381 RID: 9089 RVA: 0x000A8C6C File Offset: 0x000A6E6C
	private void method_1()
	{
		if (MonoSingleton<TargetingManager>.Instance == null)
		{
			return;
		}
		bool flag = false;
		E_HighlightType e_HighlightType = ((!NPC_UIFlowController.smethod_0().Boolean_0) ? MonoSingleton<TargetingManager>.Instance.method_8(this, ref flag) : E_HighlightType.None);
		this.method_2(e_HighlightType, flag);
	}

	// Token: 0x06002382 RID: 9090 RVA: 0x000A8CB0 File Offset: 0x000A6EB0
	public bool imethod_2(Ray ray_0, ref float float_0)
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return false;
		}
		CollisionManager collisionManager = this.m_collisionManager;
		RaycastHit raycastHit;
		return collisionManager != null && collisionManager.method_2(ray_0, out raycastHit, ref float_0);
	}

	// Token: 0x06002383 RID: 9091 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool imethod_4()
	{
		return false;
	}

	// Token: 0x06002384 RID: 9092 RVA: 0x00018526 File Offset: 0x00016726
	public bool imethod_3(Entity entity_0)
	{
		return MonoSingleton<Session>.Instance.GetLocalPlayer() && (!(this.m_dialogCam != null) || !this.m_dialogCam.activeSelf);
	}

	// Token: 0x06002385 RID: 9093 RVA: 0x000A8CF0 File Offset: 0x000A6EF0
	public void imethod_5(Entity entity_0, bool bool_0 = false)
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return;
		}
		if (this.m_animManager != null)
		{
			this.m_animManager.method_0(this.m_animPending);
		}
		NPC_UIFlowController.smethod_0().method_0().CurNPCCamera = this.m_dialogCam;
		NPC_UIFlowController.smethod_0().method_0().CurNPCSetting = this.m_npcSettings;
		NPC_UIFlowController.smethod_0().method_0().CurNPCAnimaMgr = this.m_animManager;
		if (NPC_UIFlowController.smethod_0().method_0().CurNPCCamera != null)
		{
			Camera camera = NPC_UIFlowController.smethod_0().method_0().CurNPCCamera.camera;
			if (camera != null)
			{
				int num = ~(1 << LayerMask.NameToLayer("diegeticUI"));
				camera.cullingMask &= num;
			}
		}
		bool flag = false;
		if (this.m_npcSettings != null && this.m_npcSettings.m_occupations != null)
		{
			foreach (NpcOccupation npcOccupation in this.m_npcSettings.m_occupations)
			{
				if (npcOccupation == NpcOccupation.Warehouse)
				{
					flag = true;
					break;
				}
			}
		}
		NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState = ((!flag) ? NPC_UIFlowController.NPC_UIFlowState.FunctionList : NPC_UIFlowController.NPC_UIFlowState.Warehouse);
		NPC_UIFlowController.smethod_0().method_3(npc_UIFlowState);
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_11(this.m_npcId);
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_12(this.m_npcId);
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_26();
		}
	}

	// Token: 0x06002386 RID: 9094 RVA: 0x00013A41 File Offset: 0x00011C41
	public Vector3 imethod_0()
	{
		return base.transform.position;
	}

	// Token: 0x06002387 RID: 9095 RVA: 0x00018559 File Offset: 0x00016759
	public E_USE_TYPE imethod_6()
	{
		return this.m_interactionType;
	}

	// Token: 0x06002388 RID: 9096 RVA: 0x00018561 File Offset: 0x00016761
	public void method_2(E_HighlightType e_HighlightType_0, bool bool_0 = false)
	{
		this.m_highlight_wrapper.method_0(base.gameObject, e_HighlightType_0, bool_0);
	}

	// Token: 0x06002389 RID: 9097 RVA: 0x00018576 File Offset: 0x00016776
	private void OnRenderObject()
	{
		this.m_highlight_wrapper.OnRenderObject(base.gameObject);
	}

	// Token: 0x04001825 RID: 6181
	public int m_npcId;

	// Token: 0x04001826 RID: 6182
	public int m_mapIndex;

	// Token: 0x04001827 RID: 6183
	public GameObject m_dialogCam;

	// Token: 0x04001828 RID: 6184
	public GameObject m_taskMark;

	// Token: 0x04001829 RID: 6185
	public GameObject m_titleObj;

	// Token: 0x0400182A RID: 6186
	public E_USE_TYPE m_interactionType = E_USE_TYPE.E_TALK;

	// Token: 0x0400182B RID: 6187
	protected CollisionManager m_collisionManager;

	// Token: 0x0400182C RID: 6188
	private NpcTitleMgr m_titleMng;

	// Token: 0x0400182D RID: 6189
	private global::XsdSettings.TownNpc m_npcSettings;

	// Token: 0x0400182E RID: 6190
	private bool m_isInitialized;

	// Token: 0x0400182F RID: 6191
	private TownNPCAnimationManagerFSM m_animManager;

	// Token: 0x04001830 RID: 6192
	private TownNPCAnimationManagerFSM.TownNpcAnimationType m_animPending = TownNPCAnimationManagerFSM.TownNpcAnimationType.GREET;

	// Token: 0x04001831 RID: 6193
	private List<int> m_questIdAsGiver = new List<int>();

	// Token: 0x04001832 RID: 6194
	private List<int> m_questIdAsReclaimer = new List<int>();

	// Token: 0x04001833 RID: 6195
	private NpcTitleMgr.NPC_ICON_TYPE m_curentIcon;

	// Token: 0x04001834 RID: 6196
	private HighlightWrapper m_highlight_wrapper = new HighlightWrapper();
}
