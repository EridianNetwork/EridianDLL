using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

// Token: 0x02000516 RID: 1302
public class SupplyStation : MonoBehaviour
{
	// Token: 0x060021B2 RID: 8626 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_0()
	{
	}

	// Token: 0x060021B3 RID: 8627 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_1()
	{
	}

	// Token: 0x060021B4 RID: 8628 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_2()
	{
	}

	// Token: 0x060021B5 RID: 8629 RVA: 0x000A185C File Offset: 0x0009FA5C
	private void OnPlayerEnter(EntityPlayer _player)
	{
		if (!this.m_playerInZoneList.Contains(_player))
		{
			PlayerAnimationManagerFSM component = _player.GetComponent<PlayerAnimationManagerFSM>();
			if (component != null && component.m_AudioCtl != null)
			{
				component.m_AudioCtl.vmethod_1(AudioEventName.Itm_Pickup_Ammo);
			}
		}
		if (this.m_playerInZoneList.Count == 0 && this.m_vfx_supplying_light != null)
		{
			this.m_vfx_supplying_light.gameObject.SetActive(true);
		}
		this.m_playerInZoneList.Add(_player);
	}

	// Token: 0x060021B6 RID: 8630 RVA: 0x000172C8 File Offset: 0x000154C8
	private void OnPlayerExit(EntityPlayer _player)
	{
		this.m_playerInZoneList.Remove(_player);
		if (this.m_playerInZoneList.Count == 0 && this.m_vfx_supplying_light != null)
		{
			this.m_vfx_supplying_light.gameObject.SetActive(false);
		}
	}

	// Token: 0x060021B7 RID: 8631 RVA: 0x000A18DC File Offset: 0x0009FADC
	private void method_3()
	{
		this.m_playerInZoneList.Clear();
		Dictionary<SupplyStation.ESupplyType, SupplyStation.SupplyData> dictionary = new Dictionary<SupplyStation.ESupplyType, SupplyStation.SupplyData>
		{
			{
				SupplyStation.ESupplyType.Ammo,
				new SupplyStation.SupplyData
				{
					m_icon = this.m_ammo_icon,
					m_update_function = new SupplyStation.Update_Regen(this.method_0)
				}
			},
			{
				SupplyStation.ESupplyType.Health,
				new SupplyStation.SupplyData
				{
					m_icon = this.m_health_icon,
					m_update_function = new SupplyStation.Update_Regen(this.method_1)
				}
			},
			{
				SupplyStation.ESupplyType.AmmoHealth,
				new SupplyStation.SupplyData
				{
					m_icon = this.m_ammoHealth_icon,
					m_update_function = new SupplyStation.Update_Regen(this.method_2)
				}
			}
		};
		this.m_data = dictionary[this.m_type];
		if (this.m_data.m_icon != null)
		{
			this.m_data.m_icon.gameObject.SetActive(true);
		}
	}

	// Token: 0x060021B8 RID: 8632 RVA: 0x00017303 File Offset: 0x00015503
	private void method_4(EntityPlayer entityPlayer_0)
	{
		if (!this.m_timer_ammoRegen_Dict.ContainsKey(entityPlayer_0))
		{
			this.m_timer_ammoRegen_Dict.Add(entityPlayer_0, new Utils.Timer());
		}
	}

	// Token: 0x060021B9 RID: 8633 RVA: 0x00017324 File Offset: 0x00015524
	private void method_5(EntityPlayer entityPlayer_0)
	{
		if (this.m_timer_ammoRegen_Dict.ContainsKey(entityPlayer_0))
		{
			this.m_timer_ammoRegen_Dict.Remove(entityPlayer_0);
		}
	}

	// Token: 0x060021BA RID: 8634 RVA: 0x00017341 File Offset: 0x00015541
	private void method_6()
	{
		if (!(this.m_vfx_supplying_light == null) && this.m_interval_ammoRegen != 0f && this.m_HealthRegenPerSecond != 0f && this.m_ammoRegenDataList != null)
		{
			return;
		}
	}

	// Token: 0x060021BB RID: 8635 RVA: 0x00017374 File Offset: 0x00015574
	private void Start()
	{
		this.method_3();
	}

	// Token: 0x060021BC RID: 8636 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x060021BD RID: 8637 RVA: 0x000A19BC File Offset: 0x0009FBBC
	private void OnTriggerEnter(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (component != null)
		{
			this.OnPlayerEnter(component);
		}
	}

	// Token: 0x060021BE RID: 8638 RVA: 0x000A19E0 File Offset: 0x0009FBE0
	private void OnTriggerExit(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (component != null)
		{
			this.OnPlayerExit(component);
		}
	}

	// Token: 0x04001666 RID: 5734
	[SerializeField]
	private SupplyStation.ESupplyType m_type;

	// Token: 0x04001667 RID: 5735
	[SerializeField]
	private Transform m_ammo_icon;

	// Token: 0x04001668 RID: 5736
	[SerializeField]
	private Transform m_health_icon;

	// Token: 0x04001669 RID: 5737
	[SerializeField]
	private Transform m_ammoHealth_icon;

	// Token: 0x0400166A RID: 5738
	[SerializeField]
	private Transform m_vfx_supplying_light;

	// Token: 0x0400166B RID: 5739
	[SerializeField]
	private float m_HealthRegenPerSecond = 0.1f;

	// Token: 0x0400166C RID: 5740
	[SerializeField]
	private float m_interval_ammoRegen = 1f;

	// Token: 0x0400166D RID: 5741
	private List<EntityPlayer> m_playerInZoneList = new List<EntityPlayer>();

	// Token: 0x0400166E RID: 5742
	private SupplyStation.SupplyData m_data;

	// Token: 0x0400166F RID: 5743
	private Dictionary<EntityPlayer, Utils.Timer> m_timer_ammoRegen_Dict = new Dictionary<EntityPlayer, Utils.Timer>();

	// Token: 0x04001670 RID: 5744
	[SerializeField]
	private SupplyStation.AmmoRegenData[] m_ammoRegenDataList;

	// Token: 0x02000517 RID: 1303
	public enum ESupplyType
	{
		// Token: 0x04001672 RID: 5746
		Ammo,
		// Token: 0x04001673 RID: 5747
		Health,
		// Token: 0x04001674 RID: 5748
		AmmoHealth
	}

	// Token: 0x02000518 RID: 1304
	public class SupplyData
	{
		// Token: 0x04001675 RID: 5749
		public Transform m_icon;

		// Token: 0x04001676 RID: 5750
		public SupplyStation.Update_Regen m_update_function;
	}

	// Token: 0x02000519 RID: 1305
	[Serializable]
	public class AmmoRegenData
	{
		// Token: 0x04001677 RID: 5751
		public AmmoType m_type;

		// Token: 0x04001678 RID: 5752
		public int m_increace;
	}

	// Token: 0x0200051A RID: 1306
	// (Invoke) Token: 0x060021C2 RID: 8642
	public delegate void Update_Regen();
}
