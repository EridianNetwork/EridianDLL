using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ns0;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class AuthoritativeActionManager : MonoBehaviour, IPhotonView
{
	// Token: 0x17000166 RID: 358
	// (get) Token: 0x06001A65 RID: 6757 RVA: 0x000134EF File Offset: 0x000116EF
	// (set) Token: 0x06001A66 RID: 6758 RVA: 0x000134F7 File Offset: 0x000116F7
	public PhotonView photonView { get; set; }

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x06001A67 RID: 6759 RVA: 0x00013500 File Offset: 0x00011700
	public static AuthoritativeActionManager AuthoritativeActionManager_0
	{
		get
		{
			return AuthoritativeActionManager.s_instance;
		}
	}

	// Token: 0x06001A68 RID: 6760 RVA: 0x00087284 File Offset: 0x00085484
	private void Awake()
	{
		s_instance = this;
		Type baseType = typeof(Action);
		Assembly assembly = baseType.Assembly;
		IEnumerable<Type> enumerable = from type_0 in assembly.GetTypes()
			where type_0.IsSubclassOf(baseType)
			select type_0;
		foreach (Type item in enumerable)
		{
			if (m_ActionDic.ContainsKey(item))
			{
				continue;
			}
			m_ActionDic[item] = 0;
			m_ActionNameList.Clear();
			foreach (Type key in m_ActionDic.Keys)
			{
				m_ActionNameList.Add(key.Name);
			}
			m_ActionNameList.Sort();
			int count = m_ActionNameList.Count;
			for (int i = 0; i < count; i++)
			{
				m_ActionDic[Type.GetType(m_ActionNameList[i])] = i;
			}
		}
	}
	// Token: 0x06001A69 RID: 6761 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06001A6A RID: 6762 RVA: 0x000873D8 File Offset: 0x000855D8
	private void Update()
	{
		foreach (KeyValuePair<global::Action, Entity> keyValuePair in this.m_ActionModulesToEntity)
		{
			global::Action key = keyValuePair.Key;
			key.method_0();
		}
		if (!MonoSingleton<Session>.Instance.method_16() && MonoSingleton<AttackManager>.Instance)
		{
			MonoSingleton<AttackManager>.Instance.method_0();
		}
	}

	// Token: 0x06001A6B RID: 6763 RVA: 0x00013507 File Offset: 0x00011707
	public void method_0(global::Action action_0, Entity entity_0)
	{
		this.m_ActionModulesToEntity.Add(action_0, entity_0);
	}

	// Token: 0x06001A6C RID: 6764 RVA: 0x00013516 File Offset: 0x00011716
	public void method_1(global::Action action_0)
	{
		this.m_ActionModulesToEntity.Remove(action_0);
	}

	// Token: 0x06001A6D RID: 6765 RVA: 0x00013525 File Offset: 0x00011725
	public int method_2(global::Action action_0)
	{
		return this.m_ActionDic[action_0.GetType()];
	}

	// Token: 0x06001A6E RID: 6766 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_3(Entity entity_0)
	{
	}

	// Token: 0x06001A6F RID: 6767 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_4(Entity entity_0)
	{
	}

	// Token: 0x06001A70 RID: 6768 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_5(Entity entity_0)
	{
	}

	// Token: 0x06001A71 RID: 6769 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_6(Entity entity_0)
	{
	}

	// Token: 0x06001A72 RID: 6770 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_7(EntityWeapon entityWeapon_0)
	{
	}

	// Token: 0x06001A73 RID: 6771 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_8(EntityWeapon entityWeapon_0)
	{
	}

	// Token: 0x06001A74 RID: 6772 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_9(EntityWeapon entityWeapon_0)
	{
	}

	// Token: 0x06001A75 RID: 6773 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_10(EntityWeapon entityWeapon_0)
	{
	}

	// Token: 0x06001A76 RID: 6774 RVA: 0x00087434 File Offset: 0x00085634
	public void method_11(int int_0, Entity entity_0, int int_1)
	{
		object[] array = new object[3];
		array[0] = int_1 * 1000 + int_0;
		array[1] = entity_0.vmethod_0();
		int num = Time.frameCount;
		if (entity_0.m_relatedPlayer != null)
		{
			EntityPlayer relatedPlayer = entity_0.m_relatedPlayer;
			if (relatedPlayer.method_43() != null)
			{
				num = relatedPlayer.method_43().currentInput.m_frameNum;
			}
		}
		array[2] = num;
		if (!NetworkManager.smethod_3())
		{
			this.photonView.method_4("RPC_SA", PhotonTargets.All, array);
		}
		else
		{
			this.photonView.method_4("RPC_SA", PhotonTargets.MasterClient, array);
		}
	}

	// Token: 0x06001A77 RID: 6775 RVA: 0x000874D8 File Offset: 0x000856D8
	public void method_12(int int_0, Entity entity_0, Vector3 vector3_0)
	{
		object[] array = new object[4];
		array[0] = int_0;
		array[1] = entity_0.vmethod_0();
		int num = Time.frameCount;
		if (entity_0.m_relatedPlayer != null)
		{
			EntityPlayer relatedPlayer = entity_0.m_relatedPlayer;
			if (relatedPlayer.method_43() != null)
			{
				num = relatedPlayer.method_43().currentInput.m_frameNum;
			}
		}
		array[2] = num;
		array[3] = vector3_0;
		if (!NetworkManager.smethod_3())
		{
			this.photonView.method_4("RPC_SA_P", PhotonTargets.All, array);
		}
		else
		{
			this.photonView.method_4("RPC_SA_P", PhotonTargets.MasterClient, array);
		}
	}

	// Token: 0x06001A78 RID: 6776 RVA: 0x0008757C File Offset: 0x0008577C
	[RPC]
	private void RPC_SA(int type, int entityID, int frameCount, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(entityID);
		if (badAssNetworkView)
		{
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (component)
			{
				int num = type / 1000;
				type -= num * 1000;
				global::Action action = component.method_3(type);
				if (action != null)
				{
					if (info.sender.ActorId == NetworkManager.GetActorId())
					{
						action.OnStartAction(true, info.Double_0, 0.0, frameCount, num, info.sender);
					}
					else
					{
						action.OnStartAction(false, info.Double_0, NetworkManager.smethod_6() - info.Double_0, frameCount, num, info.sender);
					}
				}
			}
		}
	}

	// Token: 0x06001A79 RID: 6777 RVA: 0x00087624 File Offset: 0x00085824
	[RPC]
	private void RPC_SA_P(int type, int entityID, int frameCount, Vector3 param, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(entityID);
		if (badAssNetworkView)
		{
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (component)
			{
				global::Action action = component.method_3(type);
				if (action != null)
				{
					if (info.sender.ActorId == NetworkManager.GetActorId())
					{
						action.OnStartAction(true, info.Double_0, 0.0, frameCount, param, info.sender);
					}
					else
					{
						action.OnStartAction(false, info.Double_0, NetworkManager.smethod_6() - info.Double_0, frameCount, param, info.sender);
					}
				}
			}
		}
	}

	// Token: 0x06001A7A RID: 6778 RVA: 0x000876B8 File Offset: 0x000858B8
	public void method_13(int int_0, Entity entity_0, int int_1)
	{
		object[] array = new object[3];
		array[0] = int_1 * 1000 + int_0;
		array[1] = entity_0.vmethod_0();
		int num = Time.frameCount;
		if (entity_0.m_relatedPlayer != null)
		{
			EntityPlayer relatedPlayer = entity_0.m_relatedPlayer;
			if (relatedPlayer.method_43() != null)
			{
				num = relatedPlayer.method_43().currentInput.m_frameNum;
			}
		}
		array[2] = num;
		if (!NetworkManager.smethod_3())
		{
			this.photonView.method_4("RPC_SO", PhotonTargets.All, array);
		}
		else
		{
			this.photonView.method_4("RPC_SO", PhotonTargets.MasterClient, array);
		}
	}

	// Token: 0x06001A7B RID: 6779 RVA: 0x0008775C File Offset: 0x0008595C
	[RPC]
	private void RPC_SO(int type, int entityID, int frameCount, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(entityID);
		if (badAssNetworkView)
		{
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (component)
			{
				int num = type / 1000;
				type -= num * 1000;
				global::Action action = component.method_3(type);
				if (action != null)
				{
					if (info.sender.ActorId == NetworkManager.GetActorId())
					{
						action.OnStopAction(true, info.Double_0, 0.0, frameCount, num, info.sender);
					}
					else
					{
						action.OnStopAction(false, info.Double_0, NetworkManager.smethod_6() - info.Double_0, frameCount, num, info.sender);
					}
				}
			}
		}
	}

	// Token: 0x06001A7C RID: 6780 RVA: 0x00087804 File Offset: 0x00085A04
	public void method_14(int int_0, Entity entity_0, int int_1, int int_2 = 0)
	{
		object[] array = new object[3];
		array[0] = int_1 * 1000 + int_0;
		array[1] = entity_0.vmethod_0();
		int num = Time.frameCount;
		if (entity_0.m_relatedPlayer != null)
		{
			EntityPlayer relatedPlayer = entity_0.m_relatedPlayer;
			if (relatedPlayer.method_43() != null)
			{
				num = relatedPlayer.method_43().currentInput.m_frameNum + int_2;
			}
		}
		array[2] = num;
		if (!NetworkManager.smethod_3())
		{
			this.photonView.method_4("RPC_SI", PhotonTargets.All, array);
		}
		else
		{
			this.photonView.method_4("RPC_SI", PhotonTargets.MasterClient, array);
		}
	}

	// Token: 0x06001A7D RID: 6781 RVA: 0x000878AC File Offset: 0x00085AAC
	public void method_15(int int_0, Entity entity_0, Vector3 vector3_0, int int_1 = 0)
	{
		object[] array = new object[4];
		array[0] = int_0;
		array[1] = entity_0.vmethod_0();
		int num = Time.frameCount;
		if (entity_0.m_relatedPlayer != null)
		{
			EntityPlayer relatedPlayer = entity_0.m_relatedPlayer;
			if (relatedPlayer.method_43() != null)
			{
				num = relatedPlayer.method_43().currentInput.m_frameNum + int_1;
			}
		}
		array[2] = num;
		array[3] = vector3_0;
		if (!NetworkManager.smethod_3())
		{
			this.photonView.method_4("RPC_SI_P", PhotonTargets.All, array);
		}
		else
		{
			this.photonView.method_4("RPC_SI_P", PhotonTargets.MasterClient, array);
		}
	}

	// Token: 0x06001A7E RID: 6782 RVA: 0x00087954 File Offset: 0x00085B54
	[RPC]
	private void RPC_SI(int type, int entityID, int frameCount, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(entityID);
		if (badAssNetworkView)
		{
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (component)
			{
				int num = type / 1000;
				type -= num * 1000;
				global::Action action = component.method_3(type);
				if (action != null)
				{
					if (info.sender.ActorId == NetworkManager.GetActorId())
					{
						action.OnSingleAction(true, info.Double_0, 0.0, frameCount, num, info.sender);
					}
					else
					{
						action.OnSingleAction(false, info.Double_0, NetworkManager.smethod_6() - info.Double_0, frameCount, num, info.sender);
					}
				}
			}
		}
	}

	// Token: 0x06001A7F RID: 6783 RVA: 0x000879FC File Offset: 0x00085BFC
	[RPC]
	private void RPC_SI_P(int type, int entityID, int frameCount, Vector3 param, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(entityID);
		if (badAssNetworkView)
		{
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (component)
			{
				global::Action action = component.method_3(type);
				if (action != null)
				{
					if (info.sender.ActorId == NetworkManager.GetActorId())
					{
						action.OnSingleAction(true, info.Double_0, 0.0, frameCount, param, info.sender);
					}
					else
					{
						action.OnSingleAction(false, info.Double_0, NetworkManager.smethod_6() - info.Double_0, frameCount, param, info.sender);
					}
				}
			}
		}
	}

	// Token: 0x06001A80 RID: 6784 RVA: 0x00087A90 File Offset: 0x00085C90
	public void method_16(int int_0, Entity entity_0, int int_1)
	{
		object[] array = new object[]
		{
			int_1 * 1000 + int_0,
			entity_0.vmethod_0()
		};
		this.photonView.method_4("RPC_Echo", PhotonTargets.All, array);
	}

	// Token: 0x06001A81 RID: 6785 RVA: 0x00087AD8 File Offset: 0x00085CD8
	public void method_17(int int_0, Entity entity_0, Vector3 vector3_0)
	{
		object[] array = new object[]
		{
			int_0,
			entity_0.vmethod_0(),
			vector3_0
		};
		this.photonView.method_4("RPC_EchoV", PhotonTargets.All, array);
	}

	// Token: 0x06001A82 RID: 6786 RVA: 0x00087B20 File Offset: 0x00085D20
	[RPC]
	private void RPC_Echo(int type, int entityID, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(entityID);
		if (badAssNetworkView)
		{
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (component)
			{
				int num = type / 1000;
				type -= num * 1000;
				global::Action action = component.method_3(type);
				if (action != null)
				{
					if (info.sender.ActorId == NetworkManager.GetActorId())
					{
						action.OnEchoCall(true, info.Double_0, 0.0, 0, num, info.sender);
					}
					else
					{
						action.OnEchoCall(false, info.Double_0, NetworkManager.smethod_6() - info.Double_0, 0, num, info.sender);
					}
				}
			}
		}
	}

	// Token: 0x06001A83 RID: 6787 RVA: 0x00087BC4 File Offset: 0x00085DC4
	[RPC]
	private void RPC_EchoV(int type, int entityID, Vector3 param, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(entityID);
		if (badAssNetworkView)
		{
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (component)
			{
				global::Action action = component.method_3(type);
				if (action != null)
				{
					if (info.sender.ActorId == NetworkManager.GetActorId())
					{
						action.OnEchoCall(true, info.Double_0, 0.0, 0, param, info.sender);
					}
					else
					{
						action.OnEchoCall(false, info.Double_0, NetworkManager.smethod_6() - info.Double_0, 0, param, info.sender);
					}
				}
			}
		}
	}

	// Token: 0x04001185 RID: 4485
	private Dictionary<global::Action, Entity> m_ActionModulesToEntity = new Dictionary<global::Action, Entity>();

	// Token: 0x04001186 RID: 4486
	private Dictionary<Type, int> m_ActionDic = new Dictionary<Type, int>();

	// Token: 0x04001187 RID: 4487
	private List<string> m_ActionNameList = new List<string>();

	// Token: 0x04001188 RID: 4488
	private static AuthoritativeActionManager s_instance;
}
