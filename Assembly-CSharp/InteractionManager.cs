using System;
using System.Collections.Generic;
using Core;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x02000486 RID: 1158
public class InteractionManager : global::Photon.MonoBehaviour
{
	// Token: 0x17000195 RID: 405
	// (get) Token: 0x06001E5B RID: 7771 RVA: 0x0001543C File Offset: 0x0001363C
	public static InteractionManager InteractionManager_0
	{
		get
		{
			return InteractionManager.s_instance;
		}
	}

	// Token: 0x06001E5C RID: 7772 RVA: 0x00015443 File Offset: 0x00013643
	private void Awake()
	{
		InteractionManager.s_instance = this;
	}

	// Token: 0x06001E5D RID: 7773 RVA: 0x0001544B File Offset: 0x0001364B
	public void method_0(InteractionClient interactionClient_0)
	{
		this.m_interactionClinets.Add(interactionClient_0);
	}

	// Token: 0x06001E5E RID: 7774 RVA: 0x00015459 File Offset: 0x00013659
	public void method_1(InteractionClient interactionClient_0)
	{
		this.m_interactionClinets.Remove(interactionClient_0);
	}

	// Token: 0x06001E5F RID: 7775 RVA: 0x00015468 File Offset: 0x00013668
	public List<InteractionClient> method_2()
	{
		return this.m_interactionClinets;
	}

	// Token: 0x06001E60 RID: 7776 RVA: 0x00096D18 File Offset: 0x00094F18
	public bool method_3(Entity entity_0, ref InteractionClient interactionClient_0, ref InteractionClient interactionClient_1, ref float float_0)
	{
		interactionClient_0 = null;
		interactionClient_1 = null;
		float num = ns0.MonoSingleton<AppManager>.Instance.m_globalSettings.m_visualInteractionDistance;
		Ray ray_ = new Ray(entity_0.vmethod_28(), entity_0.vmethod_27());
		List<InteractionClient> list = InteractionManager_0.method_2();
		for (int i = 0; i < list.Count; i++)
		{
			InteractionClient interactionClient = list[i];
			if (!interactionClient.imethod_3(entity_0))
			{
				continue;
			}
			Entity entity = interactionClient as Entity;
			if (entity != null && entity == entity_0)
			{
				interactionClient_0 = interactionClient;
				if (interactionClient.imethod_4())
				{
					interactionClient_1 = interactionClient;
				}
				else
				{
					interactionClient_1 = null;
				}
				continue;
			}
			float float_ = ((!interactionClient.imethod_4()) ? ns0.MonoSingleton<AppManager>.Instance.m_globalSettings.m_interactionDistance : ns0.MonoSingleton<AppManager>.Instance.m_globalSettings.m_visualInteractionDistance);
			if (!interactionClient.imethod_2(ray_, ref float_))
			{
				continue;
			}
			if (!(interactionClient is TownNpc))
			{
				if (float_ <= num && (interactionClient.imethod_4() || float_ <= ns0.MonoSingleton<AppManager>.Instance.m_globalSettings.m_interactionDistance))
				{
					num = float_;
					if (float_ <= ns0.MonoSingleton<AppManager>.Instance.m_globalSettings.m_interactionDistance)
					{
						interactionClient_0 = interactionClient;
					}
					else
					{
						interactionClient_0 = null;
					}
					if (interactionClient.imethod_4())
					{
						interactionClient_1 = interactionClient;
					}
					else
					{
						interactionClient_1 = null;
					}
				}
				continue;
			}
			if (float_ <= ns0.MonoSingleton<AppManager>.Instance.m_globalSettings.m_interactionDistance)
			{
				interactionClient_0 = interactionClient;
				float_0 = float_;
				interactionClient_1 = null;
			}
			else
			{
				interactionClient_0 = null;
			}
			break;
		}
		return interactionClient_0 != null;
	}
	// Token: 0x06001E61 RID: 7777 RVA: 0x00096E84 File Offset: 0x00095084
	public void method_4(InteractionClient interactionClient_0, ref List<InteractionClient> list_0)
	{
		list_0.Clear();
		list_0.Add(interactionClient_0);
		List<InteractionClient> list = InteractionManager.InteractionManager_0.method_2();
		for (int i = 0; i < list.Count; i++)
		{
			if (interactionClient_0 != list[i])
			{
				if (Vector3.Distance(interactionClient_0.imethod_0(), list[i].imethod_0()) < 0.3f)
				{
					list_0.Add(list[i]);
				}
			}
		}
	}

	// Token: 0x06001E62 RID: 7778 RVA: 0x00096EF4 File Offset: 0x000950F4
	public bool method_5(Entity entity_0, ItemDNA itemDNA_0)
	{
		bool flag = true;
		if (itemDNA_0.method_3(ItemType.Ammo))
		{
			AmmoType ammoType = itemDNA_0.m_ammoType;
			if (ammoType != AmmoType.Grenade)
			{
				flag = entity_0.vmethod_19().vmethod_13(itemDNA_0.m_ammoType) < entity_0.vmethod_19().vmethod_10(itemDNA_0.m_ammoType);
			}
			else
			{
				flag = entity_0.vmethod_19().vmethod_19() < entity_0.vmethod_19().vmethod_18();
			}
		}
		else if (!itemDNA_0.method_3(ItemType.Material))
		{
		}
		return flag;
	}

	// Token: 0x06001E63 RID: 7779 RVA: 0x00096F64 File Offset: 0x00095164
	public void method_6(int int_0, byte byte_0)
	{
		object[] array = new object[] { int_0, byte_0 };
		base.photonView.method_4("RPC_C2H_DropItem", PhotonTargets.MasterClient, array);
	}

	// Token: 0x06001E64 RID: 7780 RVA: 0x0000311B File Offset: 0x0000131B
	[RPC]
	private void RPC_C2H_DropItem(int droperId, byte slot, PhotonMessageInfo info)
	{
	}

	// Token: 0x06001E65 RID: 7781 RVA: 0x00096F9C File Offset: 0x0009519C
	[RPC]
	private void RPC_H2C_OnDropItem(int droperId, int itemId, PhotonMessageInfo info)
	{
		EntityPlayer component = BadAssNetworkView.smethod_3(droperId).GetComponent<EntityPlayer>();
		if (component != null)
		{
			base.StartCoroutine(component.method_58(itemId));
		}
	}

	// Token: 0x06001E66 RID: 7782 RVA: 0x00096FCC File Offset: 0x000951CC
	[RPC]
	public void RPC_H2C_OnPickUpItem(int pickerId, int itemId, PhotonMessageInfo info)
	{
		Entity entity = BadAssNetworkView.smethod_4(pickerId);
		EntityObject entityObject = BadAssNetworkView.smethod_4(itemId) as EntityObject;
		if (entityObject)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "BOL_DIAG RPC_H2C_OnPickUpItem: itemId=" + itemId.ToString() + " resolved, claiming, pickerNull=" + (entity == null).ToString());
			entityObject.m_pickable.method_6(entity as EntityPlayer);
			return;
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "BOL_DIAG RPC_H2C_OnPickUpItem: itemId=" + itemId.ToString() + " NOT resolved, claim dropped");
	}

	// Token: 0x040013D6 RID: 5078
	private static InteractionManager s_instance;

	// Token: 0x040013D7 RID: 5079
	private List<InteractionClient> m_interactionClinets = new List<InteractionClient>();
}
