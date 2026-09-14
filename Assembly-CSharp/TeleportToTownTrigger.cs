using System;
using ns0;
using UnityEngine;

// Token: 0x0200051B RID: 1307
public class TeleportToTownTrigger : MonoBehaviour, InteractionClient
{
	// Token: 0x060021C6 RID: 8646 RVA: 0x0001738F File Offset: 0x0001558F
	private void Awake()
	{
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_0(this);
		}
		this.m_collisionManager = base.gameObject.AddComponent<CollisionManager>();
	}

	// Token: 0x060021C7 RID: 8647 RVA: 0x000173B9 File Offset: 0x000155B9
	private void OnDestroy()
	{
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_1(this);
		}
		this.m_collisionManager = null;
	}

	// Token: 0x060021C8 RID: 8648 RVA: 0x000A1A04 File Offset: 0x0009FC04
	private void Start()
	{
		this.m_collisionManager.method_7(base.GetComponent<Collider>());
		MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
		mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.InstanceExitOpen;
		mapObjectMark.method_0();
	}

	// Token: 0x060021C9 RID: 8649 RVA: 0x000A1A3C File Offset: 0x0009FC3C
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

	// Token: 0x060021CA RID: 8650 RVA: 0x000173D9 File Offset: 0x000155D9
	public bool imethod_3(Entity entity_0)
	{
		return MonoSingleton<Session>.Instance.GetLocalPlayer() && MonoSingleton<Session>.Instance.method_19() && !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().Boolean_1;
	}

	// Token: 0x060021CB RID: 8651 RVA: 0x000A1A7C File Offset: 0x0009FC7C
	public void imethod_5(Entity entity_0, bool bool_0 = false)
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return;
		}
		if (!MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().Boolean_1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("F2_Warning")), new Delegate_EventProc(this.method_0), new Delegate_EventProc(this.method_1));
		}
	}

	// Token: 0x060021CC RID: 8652 RVA: 0x00017414 File Offset: 0x00015614
	private void method_0()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWrapupView>().vmethod_6();
		SessionInfo.SessionInfo_0.method_3(OnlineService.s_characterId);
	}

	// Token: 0x060021CD RID: 8653 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_1()
	{
	}

	// Token: 0x060021CE RID: 8654 RVA: 0x0000311D File Offset: 0x0000131D
	public bool imethod_4()
	{
		return false;
	}

	// Token: 0x060021CF RID: 8655 RVA: 0x00017439 File Offset: 0x00015639
	public Vector3 imethod_0()
	{
		if (base.gameObject == null)
		{
			return Vector3.zero;
		}
		return base.gameObject.transform.position;
	}

	// Token: 0x060021D0 RID: 8656 RVA: 0x00013D7E File Offset: 0x00011F7E
	public E_USE_TYPE imethod_6()
	{
		return E_USE_TYPE.E_OPEN;
	}

	// Token: 0x060021D1 RID: 8657 RVA: 0x0001745F File Offset: 0x0001565F
	private void Update()
	{
		this.method_2();
	}

	// Token: 0x060021D2 RID: 8658 RVA: 0x000A1AEC File Offset: 0x0009FCEC
	private void method_2()
	{
		if (MonoSingleton<TargetingManager>.Instance == null)
		{
			return;
		}
		bool flag = false;
		E_HighlightType e_HighlightType = ((!NPC_UIFlowController.smethod_0().Boolean_0) ? MonoSingleton<TargetingManager>.Instance.method_8(this, ref flag) : E_HighlightType.None);
		this.method_3(e_HighlightType, flag);
	}

	// Token: 0x060021D3 RID: 8659 RVA: 0x000A1B30 File Offset: 0x0009FD30
	public void method_3(E_HighlightType e_HighlightType_0, bool bool_0 = false)
	{
		if (base.transform.parent != null && base.transform.parent.gameObject != null)
		{
			this.m_highlight_wrapper.method_1(base.transform.parent.gameObject, e_HighlightType_0, bool_0);
		}
	}

	// Token: 0x060021D4 RID: 8660 RVA: 0x00017467 File Offset: 0x00015667
	private void OnRenderObject()
	{
		this.m_highlight_wrapper.OnRenderObject(base.gameObject);
	}

	// Token: 0x04001679 RID: 5753
	private CollisionManager m_collisionManager;

	// Token: 0x0400167A RID: 5754
	private HighlightWrapper m_highlight_wrapper = new HighlightWrapper();
}
