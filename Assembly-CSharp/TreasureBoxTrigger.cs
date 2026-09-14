using System;
using UnityEngine;

// Token: 0x0200051C RID: 1308
public class TreasureBoxTrigger : InteractiveTrigger
{
	// Token: 0x060021D6 RID: 8662 RVA: 0x00017482 File Offset: 0x00015682
	protected override void Start()
	{
		this.m_render = base.GetComponentInChildren<SkinnedMeshRenderer>();
		base.Start();
		this.m_looting = base.GetComponent<LootingTable>();
		this.m_collider = base.GetComponent<Collider>();
		this.m_useOnce = true;
	}

	// Token: 0x060021D7 RID: 8663 RVA: 0x000174B5 File Offset: 0x000156B5
	public override void OnActivate()
	{
		base.OnActivate();
		if (this.m_render != null)
		{
			this.m_render.material.SetFloat("_Illum", 0f);
		}
	}

	// Token: 0x060021D8 RID: 8664 RVA: 0x000174E5 File Offset: 0x000156E5
	public override void imethod_5(Entity entity_0, bool bool_0 = false)
	{
		this.m_triggerPlayer = entity_0 as EntityPlayer;
		base.imethod_5(entity_0, bool_0);
	}

	// Token: 0x0400167B RID: 5755
	private LootingTable m_looting;

	// Token: 0x0400167C RID: 5756
	private Collider m_collider;

	// Token: 0x0400167D RID: 5757
	private SkinnedMeshRenderer m_render;

	// Token: 0x0400167E RID: 5758
	public EntityPlayer m_triggerPlayer;
}
