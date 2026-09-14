using System;
using XsdSettings;

// Token: 0x02000004 RID: 4
public class SoldierTurretAIInventory : AIInventory
{
	// Token: 0x06000012 RID: 18 RVA: 0x00003189 File Offset: 0x00001389
	public override void Start()
	{
		this.method_9();
		base.Start();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000344BC File Offset: 0x000326BC
	public void method_9()
	{
		EntityNpc component = base.gameObject.GetComponent<EntityNpc>();
		if (component.m_relatedPlayer != null)
		{
			float num = component.m_relatedPlayer.PlayerEffectManager_0.method_0(EffectType.ElementDamage);
			this.m_weaponID[0] = ((num <= 1f) ? 5 : 6);
		}
	}
}
