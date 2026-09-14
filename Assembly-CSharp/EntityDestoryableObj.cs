using System;
using System.Collections.Generic;
using BHV;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class EntityDestoryableObj : EntityObject, IDamageListener
{
	// Token: 0x06001B5F RID: 7007 RVA: 0x00013BF4 File Offset: 0x00011DF4
	public override void vmethod_55(Dictionary<int, BHVTask> dictionary_0)
	{
		if (dictionary_0 == null)
		{
			return;
		}
		dictionary_0.Add(35, new BHVTaskDefault());
	}

	// Token: 0x06001B60 RID: 7008 RVA: 0x00089DD4 File Offset: 0x00087FD4
	public override void Start()
	{
		base.Start();
		this.m_destorySetting = base.GetComponentInChildren<DestoryableObjSetting>();
		this.m_collisionManager = base.GetComponentInChildren<CollisionManager>();
		if (this.m_collisionManager != null)
		{
			this.m_collisionManager.method_0(false);
		}
		if (this.m_destorySetting != null)
		{
			this.m_uiName = LocalizedString.smethod_0(new LocalizedString(this.m_destorySetting.m_name));
			this.m_bHideUI = this.m_destorySetting.m_bHideUI;
		}
		DamageManager.DamageManager_0.method_3(this);
	}

	// Token: 0x06001B61 RID: 7009 RVA: 0x00013C07 File Offset: 0x00011E07
	public override string vmethod_4()
	{
		return this.m_uiName;
	}

	// Token: 0x06001B62 RID: 7010 RVA: 0x00089E60 File Offset: 0x00088060
	public override void Update()
	{
		if (this.m_collisionManager == null)
		{
			this.m_collisionManager = base.GetComponentInChildren<CollisionManager>();
			if (this.m_collisionManager != null)
			{
				this.m_collisionManager.method_0(false);
			}
		}
		if (this.m_destorySetting == null)
		{
			this.m_destorySetting = base.GetComponentInChildren<DestoryableObjSetting>();
			if (this.m_destorySetting != null)
			{
				this.m_uiName = LocalizedString.smethod_0(new LocalizedString(this.m_destorySetting.m_name));
				this.m_bHideUI = this.m_destorySetting.m_bHideUI;
			}
		}
		base.Update();
	}

	// Token: 0x06001B63 RID: 7011 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x06001B64 RID: 7012 RVA: 0x00089EFC File Offset: 0x000880FC
	public void OnEntityKill(KillContext context)
	{
		if (context.m_victim != null && context.m_victim.gameObject != base.gameObject)
		{
			return;
		}
		if (base.gameObject != null)
		{
			foreach (Renderer renderer in base.gameObject.GetComponentsInChildren<Renderer>())
			{
				if (renderer != null)
				{
					renderer.enabled = false;
				}
			}
			foreach (Collider collider in base.gameObject.GetComponentsInChildren<Collider>())
			{
				if (collider != null)
				{
					collider.enabled = false;
				}
			}
		}
		DamageManager.DamageManager_0.method_4(this);
	}

	// Token: 0x040011F4 RID: 4596
	private DestoryableObjSetting m_destorySetting;

	// Token: 0x040011F5 RID: 4597
	private string m_uiName;

	// Token: 0x040011F6 RID: 4598
	public bool m_bHideUI;
}
