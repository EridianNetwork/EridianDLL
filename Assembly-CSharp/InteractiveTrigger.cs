using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class InteractiveTrigger : LevelTrigger, InteractionClient
{
	// Token: 0x060021A5 RID: 8613 RVA: 0x00017204 File Offset: 0x00015404
	protected override void Awake()
	{
		base.Awake();
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_0(this);
		}
		this.m_collisionManager = base.gameObject.AddComponent<CollisionManager>();
	}

	// Token: 0x060021A6 RID: 8614 RVA: 0x00015FE4 File Offset: 0x000141E4
	private void OnDestroy()
	{
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_1(this);
		}
	}

	// Token: 0x060021A7 RID: 8615 RVA: 0x00017234 File Offset: 0x00015434
	protected override void Start()
	{
		base.Start();
		this.m_collisionManager.method_7(base.GetComponent<Collider>());
	}

	// Token: 0x060021A8 RID: 8616 RVA: 0x0001724D File Offset: 0x0001544D
	public override void OnActivate()
	{
		base.OnActivate();
		if (string.IsNullOrEmpty(this.m_enableNavmeshLayerOnActivate))
		{
		}
	}

	// Token: 0x060021A9 RID: 8617 RVA: 0x000A17E8 File Offset: 0x0009F9E8
	public bool imethod_2(Ray ray_0, ref float float_0)
	{
		CollisionManager collisionManager = this.m_collisionManager;
		RaycastHit raycastHit;
		return collisionManager != null && collisionManager.method_2(ray_0, out raycastHit, ref float_0);
	}

	// Token: 0x060021AA RID: 8618 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool imethod_4()
	{
		return false;
	}

	// Token: 0x060021AB RID: 8619 RVA: 0x00017262 File Offset: 0x00015462
	public bool imethod_3(Entity entity_0)
	{
		return !this.m_useOnce || !this.m_used;
	}

	// Token: 0x060021AC RID: 8620 RVA: 0x00017277 File Offset: 0x00015477
	public virtual void imethod_5(Entity entity_0, bool bool_0 = false)
	{
		this.vmethod_0((base.method_2() != LevelObjectSync.LevelObjectSyncState.Activated) ? LevelObjectSync.LevelObjectSyncState.Activated : LevelObjectSync.LevelObjectSyncState.Deactivated);
	}

	// Token: 0x060021AD RID: 8621 RVA: 0x00013A41 File Offset: 0x00011C41
	public Vector3 imethod_0()
	{
		return base.transform.position;
	}

	// Token: 0x060021AE RID: 8622 RVA: 0x00013D7E File Offset: 0x00011F7E
	public E_USE_TYPE imethod_6()
	{
		return E_USE_TYPE.E_OPEN;
	}

	// Token: 0x04001662 RID: 5730
	protected CollisionManager m_collisionManager;

	// Token: 0x04001663 RID: 5731
	public string m_enableNavmeshLayerOnActivate;
}
