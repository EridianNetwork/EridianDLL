using System;
using UnityEngine;
using XsdSettings;

// Token: 0x020005EC RID: 1516
public class WeaponElementalManager : MonoBehaviour
{
	// Token: 0x0600264F RID: 9807 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06002650 RID: 9808 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x04001C0A RID: 7178
	public WeaponElementalManager.ElementalConfig[] elementalConfigs = new WeaponElementalManager.ElementalConfig[25];

	// Token: 0x020005ED RID: 1517
	[Serializable]
	public class ElementalConfig
	{
		// Token: 0x04001C0B RID: 7179
		public WeaponType weapontype;

		// Token: 0x04001C0C RID: 7180
		public AttackInfo.ElementalType elementaltype;

		// Token: 0x04001C0D RID: 7181
		public string muzzleRescource;

		// Token: 0x04001C0E RID: 7182
		public string lightRescource;
	}
}
