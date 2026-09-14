using System;
using UnityEngine;

// Token: 0x0200040B RID: 1035
[Serializable]
public class SpawnInfo
{
	// Token: 0x04001160 RID: 4448
	public Entity.EntityType m_entity;

	// Token: 0x04001161 RID: 4449
	public NpcSpawningSettings m_settings;

	// Token: 0x04001162 RID: 4450
	public ItemSpawningSettings m_itemSpwan;

	// Token: 0x04001163 RID: 4451
	[HideInInspector]
	public PlayerSpawningSettings m_playerSettings;
}
