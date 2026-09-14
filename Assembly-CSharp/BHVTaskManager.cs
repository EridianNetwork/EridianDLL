using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BHV;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000160 RID: 352
public class BHVTaskManager : MonoBehaviour, IPrefabManagerXmlGenericSetup, IPhotonSerializeView
{
	// Token: 0x17000070 RID: 112
	// (get) Token: 0x0600081C RID: 2076 RVA: 0x0000840A File Offset: 0x0000660A
	// (set) Token: 0x0600081D RID: 2077 RVA: 0x00008412 File Offset: 0x00006612
	public Entity m_entity { get; private set; }

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x0600081E RID: 2078 RVA: 0x0000841B File Offset: 0x0000661B
	// (set) Token: 0x0600081F RID: 2079 RVA: 0x00008423 File Offset: 0x00006623
	public AnimationManagerFSM m_animationManagerFSM { get; set; }

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x06000820 RID: 2080 RVA: 0x0000842C File Offset: 0x0000662C
	// (set) Token: 0x06000821 RID: 2081 RVA: 0x00008434 File Offset: 0x00006634
	public NavMeshAgent m_navAgent { get; private set; }

	// Token: 0x06000822 RID: 2082 RVA: 0x0005A854 File Offset: 0x00058A54
	public virtual T vmethod_0<T>() where T : BHVTaskSettings
	{
		BHVTaskSettings bhvtaskSettings = null;
		this.m_settingsLUT.TryGetValue(typeof(T), out bhvtaskSettings);
		return (T)((object)bhvtaskSettings);
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x0000843D File Offset: 0x0000663D
	public void method_0(BHVTaskLayer bhvtaskLayer_0)
	{
		this.m_layerMask |= 1 << (int)bhvtaskLayer_0;
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x00008455 File Offset: 0x00006655
	public bool method_1(BHVTaskLayer bhvtaskLayer_0)
	{
		return (this.m_layerMask & (1 << (int)bhvtaskLayer_0)) != 0;
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x000039EC File Offset: 0x00001BEC
	public bool method_2(EntityNpc.EntitySubType entitySubType_0)
	{
		return true;
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x0005A884 File Offset: 0x00058A84
	public void method_3(EntityNpc.EntitySubType entitySubType_0)
	{
		this.m_npcSubTypeHashCode = Utility.smethod_1(entitySubType_0.ToString());
		if (!AIServiceSetting.AIServiceSetting_0.m_settingList.TryGetValue(this.m_npcSubTypeHashCode, out this.m_settingsLUT))
		{
			DebugUtils.LogError(LogCategory.AI, "Not find setting for " + entitySubType_0);
		}
		AIServiceSetting.AIServiceSetting_0.method_3(entitySubType_0, this.m_tasksLUT);
		this.method_4();
		if (this.m_entity == null)
		{
			this.m_entity = base.GetComponent<Entity>();
		}
		if (this.m_animationManagerFSM == null)
		{
			if (this.m_entity.vmethod_8() == Entity.EntityType.Npc)
			{
				this.m_animationManagerFSM = base.GetComponent<AnimationManagerFSM>();
			}
			else if (this.m_entity.vmethod_8() == Entity.EntityType.Player)
			{
				this.m_animationManagerFSM = base.GetComponent<PlayerAnimationManagerFSM>();
			}
		}
		this.m_movement = this.m_entity.GetComponent<MovementSync>();
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x0005A960 File Offset: 0x00058B60
	public bool imethod_0(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		Entity component = base.GetComponent<Entity>();
		if (component is EntityNpc)
		{
			return true;
		}
		StringReader stringReader = new StringReader(string_0);
		this.m_setup = AIServiceSetting.AIServiceSetting_0.m_taskSerializer.Deserialize(stringReader) as BHVTaskManagerSetup;
		if (this.m_setup == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "Invalid Task Manager Settings:");
			return false;
		}
		this.m_setup.method_0();
		component.vmethod_55(this.m_tasksLUT);
		this.m_settingsLUT = this.m_setup.dictionary_0;
		this.method_4();
		return true;
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x0005A9F0 File Offset: 0x00058BF0
	private void OnSpawnCompleted()
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.m_entity == null)
		{
			this.m_entity = base.GetComponent<Entity>();
		}
		if (this.m_animationManagerFSM == null)
		{
			if (this.m_entity.vmethod_8() == Entity.EntityType.Npc)
			{
				this.m_animationManagerFSM = base.GetComponent<AnimationManagerFSM>();
			}
			else if (this.m_entity.vmethod_8() == Entity.EntityType.Player)
			{
				this.m_animationManagerFSM = base.GetComponent<PlayerAnimationManagerFSM>();
			}
		}
		this.m_movement = this.m_entity.GetComponent<MovementSync>();
		this.m_navAgent = null;
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x0005AA7C File Offset: 0x00058C7C
	public void method_4()
	{
		this.method_0(BHVTaskLayer.FULLBODY);
		this.method_0(BHVTaskLayer.TOPBODY);
		this.method_0(BHVTaskLayer.ADDITIVE);
		this.method_0(BHVTaskLayer.EFFECT);
		this.m_layers = new BHVTaskManagerLayer[4];
		for (int i = 0; i < this.m_layers.Length; i++)
		{
			if (this.method_1((BHVTaskLayer)i))
			{
				this.m_layers[i] = new BHVTaskManagerLayer();
			}
			else
			{
				this.m_layers[i] = null;
			}
		}
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x0000846A File Offset: 0x0000666A
	public int method_5()
	{
		this.m_UIDCounter++;
		if (this.m_UIDCounter >= 126)
		{
			this.m_UIDCounter = 0;
		}
		return this.m_UIDCounter;
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x000039EC File Offset: 0x00001BEC
	public BHVTaskManagerResult Awake()
	{
		return BHVTaskManagerResult.SUCCESS;
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x0005AAE8 File Offset: 0x00058CE8
	public BHVTaskManagerResult Start()
	{
		if (this.m_entity == null)
		{
			this.m_entity = base.GetComponent<Entity>();
		}
		this.m_navAgentSettings = this.vmethod_0<BHVNavAgentSettings>();
		this.m_fireStyleSettings = this.vmethod_0<BHVFireStyleSettings>();
		this.m_passiveSkillSpeedModifier = this.m_entity.vmethod_5();
		return BHVTaskManagerResult.SUCCESS;
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x0005AB3C File Offset: 0x00058D3C
	public void Update()
	{
		if (!MonoSingleton<Session>.Instance.method_23())
		{
			return;
		}
		if (this.m_movement != null)
		{
			int count = this.m_networkBHVTaskList.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				NetworkTaskStruct networkTaskStruct = this.m_networkBHVTaskList[i];
				if ((double)Time.time - networkTaskStruct.m_time > (double)this.m_movement.Single_0)
				{
					this.method_14(networkTaskStruct.m_taskParam);
					this.m_networkBHVTaskList.Remove(networkTaskStruct);
				}
			}
		}
		for (int j = 0; j < this.m_layers.Length; j++)
		{
			if (this.m_layers[j] != null)
			{
				if (this.m_layers[j].m_currentTaskParamQueue != null)
				{
					this.method_9(this.m_layers[j].m_currentTaskParamQueue, true, false);
					this.m_layers[j].m_currentTaskParamQueue = null;
				}
				if (this.m_layers[j].m_currentTask != null)
				{
					this.m_layers[j].m_currentTask.Update(Time.deltaTime);
				}
			}
		}
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x0005AC38 File Offset: 0x00058E38
	public BHVTaskManagerResult method_6()
	{
		for (int i = 0; i < this.m_layers.Length; i++)
		{
			if (this.m_layers[i] != null && this.m_layers[i].m_currentTask != null)
			{
				this.m_layers[i].m_currentTask.vmethod_3(true);
			}
		}
		return BHVTaskManagerResult.SUCCESS;
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x00008491 File Offset: 0x00006691
	public BHVTaskManagerResult method_7(BHVTaskParam bhvtaskParam_0)
	{
		return this.method_9(bhvtaskParam_0, false, false);
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x0000849C File Offset: 0x0000669C
	private bool method_8(BHVTaskLayer bhvtaskLayer_0)
	{
		return this.m_layers != null && (BHVTaskLayer)this.m_layers.Length > bhvtaskLayer_0 && this.m_layers[(int)bhvtaskLayer_0] != null;
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x0005AC88 File Offset: 0x00058E88
	public BHVTaskManagerResult method_9(BHVTaskParam bhvtaskParam_0, bool bool_0, bool bool_1 = false)
	{
		if (this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTask != null)
		{
			if (BHVTask.smethod_0(bhvtaskParam_0, this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTask) && !bool_0)
			{
				return BHVTaskManagerResult.ERROR_TASK_ALREADY_RUNNING;
			}
			this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTask.vmethod_3(false);
			this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTask = null;
		}
		if (bhvtaskParam_0.bool_0 && this.method_8(BHVTaskLayer.TOPBODY) && this.m_layers[1].m_currentTask != null)
		{
			this.m_layers[1].m_currentTask.vmethod_3(true);
			this.m_layers[1].m_currentTask = null;
		}
		this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTask = this.vmethod_1(bhvtaskParam_0);
		if (this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTask == null)
		{
			return BHVTaskManagerResult.ERROR_FAILED_TO_CREATE_TASK;
		}
		this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTask.Start();
		return BHVTaskManagerResult.SUCCESS;
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x000084C2 File Offset: 0x000066C2
	public BHVTaskStatus method_10()
	{
		return this.method_11(BHVTaskLayer.FULLBODY);
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x000084CB File Offset: 0x000066CB
	public BHVTaskStatus method_11(BHVTaskLayer bhvtaskLayer_0)
	{
		if (this.m_layers[(int)bhvtaskLayer_0].m_currentTask != null)
		{
			return this.m_layers[(int)bhvtaskLayer_0].m_currentTask.m_Status;
		}
		return BHVTaskStatus.INVALID;
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x000084F0 File Offset: 0x000066F0
	public BHVTask method_12()
	{
		return this.method_13(BHVTaskLayer.FULLBODY);
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x000084F9 File Offset: 0x000066F9
	public BHVTask method_13(BHVTaskLayer bhvtaskLayer_0)
	{
		if (this.m_layers[(int)bhvtaskLayer_0].m_currentTask != null)
		{
			return this.m_layers[(int)bhvtaskLayer_0].m_currentTask;
		}
		return null;
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x0005AD7C File Offset: 0x00058F7C
	public virtual BHVTask vmethod_1(BHVTaskParam bhvtaskParam_0)
	{
		BHVTask bhvtask = null;
		if (!this.m_tasksLUT.TryGetValue((int)bhvtaskParam_0.m_Type, out bhvtask))
		{
			DebugUtils.LogError(LogCategory.AI, bhvtaskParam_0.m_Type.ToString() + " is not part of the possible tasks for " + this.m_entity.m_name);
			return null;
		}
		bhvtask.vmethod_1(this);
		if (!bhvtask.vmethod_2(bhvtaskParam_0))
		{
			DebugUtils.LogError(LogCategory.AI, bhvtaskParam_0.m_Type.ToString() + " cannot set tasks parmeters for " + this.m_entity.m_name);
			return null;
		}
		return bhvtask;
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x0005AE0C File Offset: 0x0005900C
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			int num = 0;
			for (int i = 0; i < this.m_layers.Length; i++)
			{
				if (this.m_layers[i] != null && this.m_layers[i].m_currentTask != null)
				{
					num++;
				}
			}
			stream.SendNext(num);
			for (int j = 0; j < this.m_layers.Length; j++)
			{
				if (this.m_layers[j] != null && this.m_layers[j].m_currentTask != null)
				{
					BHVTaskParam bhvtaskParam = this.m_layers[j].m_currentTask.vmethod_0();
					bhvtaskParam.vmethod_2(ref this.m_synchedParams.data_0, true);
					this.m_synchedParams.method_1(stream);
					this.m_layers[j].m_currentTask.bool_0 = true;
				}
			}
		}
		else
		{
			int num2 = (int)stream.ReceiveNext();
			for (int k = 0; k < num2; k++)
			{
				this.m_synchedParams.method_1(stream);
				if (this.m_synchedParams.method_0())
				{
					BHVTask bhvtask = this.m_tasksLUT[(int)this.m_synchedParams.data_0.bhvtaskType_0];
					BHVTaskParam bhvtaskParam2 = bhvtask.vmethod_0();
					if (bhvtaskParam2 == null)
					{
						bhvtaskParam2 = this.m_synchedParams.method_2();
						bhvtask.vmethod_2(bhvtaskParam2);
					}
					else
					{
						if (bhvtaskParam2.m_UID == this.m_synchedParams.data_0.int_0)
						{
							goto IL_01B4;
						}
						bhvtaskParam2.vmethod_2(ref this.m_synchedParams.data_0, false);
						bhvtaskParam2.vmethod_0();
					}
					if (this.m_movement != null && this.m_movement.Single_0 > 0.15f)
					{
						NetworkTaskStruct networkTaskStruct;
						networkTaskStruct.m_taskParam = bhvtaskParam2;
						networkTaskStruct.m_time = (double)Time.time;
						this.m_networkBHVTaskList.Add(networkTaskStruct);
					}
					else
					{
						this.method_14(bhvtaskParam2);
					}
				}
				IL_01B4:;
			}
		}
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x00008519 File Offset: 0x00006719
	private void method_14(BHVTaskParam bhvtaskParam_0)
	{
		if (bhvtaskParam_0 != null)
		{
			this.m_layers[(int)bhvtaskParam_0.m_Layer].m_currentTaskParamQueue = bhvtaskParam_0;
		}
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x00008531 File Offset: 0x00006731
	public bool method_15()
	{
		return this.m_layers[0].m_currentTask != null && this.m_layers[0].m_currentTask.m_Type == BHVTaskType.Idle;
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x0005AFDC File Offset: 0x000591DC
	public bool method_16()
	{
		return this.method_13(BHVTaskLayer.FULLBODY).m_Type == BHVTaskType.MoveTo || this.method_13(BHVTaskLayer.FULLBODY).m_Type == BHVTaskType.ChargeAttack || this.method_13(BHVTaskLayer.FULLBODY).m_Type == BHVTaskType.JumpAttack || this.method_13(BHVTaskLayer.FULLBODY).m_Type == BHVTaskType.Roll || this.method_13(BHVTaskLayer.FULLBODY).m_Type == BHVTaskType.SlideMoveTo;
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x0005B03C File Offset: 0x0005923C
	public override string ToString()
	{
		if (this.m_layers == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder("BHVTaskManager:\n");
		if (this.method_8(BHVTaskLayer.FULLBODY))
		{
			if (this.m_layers[0].m_currentTask != null)
			{
				stringBuilder.Append(this.m_layers[0].m_currentTask.ToString());
			}
			else
			{
				stringBuilder.Append(string.Format("    FullBody: -\n", new object[0]));
			}
		}
		if (this.method_8(BHVTaskLayer.TOPBODY))
		{
			if (this.m_layers[1].m_currentTask != null)
			{
				stringBuilder.Append(this.m_layers[1].m_currentTask.ToString());
			}
			else
			{
				stringBuilder.Append(string.Format("    TopBody: -\n", new object[0]));
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x0005B0FC File Offset: 0x000592FC
	public float method_17(BHVFireStyle bhvfireStyle_0)
	{
		if (this.m_fireStyleSettings != null)
		{
			switch (bhvfireStyle_0)
			{
			case BHVFireStyle.BURST_SINGLE:
				return 0f;
			case BHVFireStyle.BURST_CHAINED:
				return global::UnityEngine.Random.Range(this.m_fireStyleSettings.m_burstChained_IdleTimeMin, this.m_fireStyleSettings.m_burstChained_IdleTimeMax);
			case BHVFireStyle.BURST_AUTO:
				return 0f;
			}
		}
		return 0f;
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x0005B154 File Offset: 0x00059354
	public float method_18(BHVFireStyle bhvfireStyle_0)
	{
		if (this.m_fireStyleSettings != null)
		{
			switch (bhvfireStyle_0)
			{
			case BHVFireStyle.BURST_SINGLE:
				return global::UnityEngine.Random.Range(this.m_fireStyleSettings.m_burstSingle_FireTimeMin, this.m_fireStyleSettings.m_burstSingle_FireTimeMax);
			case BHVFireStyle.BURST_CHAINED:
				return global::UnityEngine.Random.Range(this.m_fireStyleSettings.m_burstChained_FireTimeMin, this.m_fireStyleSettings.m_burstChained_FireTimeMax);
			case BHVFireStyle.BURST_AUTO:
				return float.MaxValue;
			}
		}
		return 0f;
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x0005B1C4 File Offset: 0x000593C4
	public float method_19(BHVMovementSpeed bhvmovementSpeed_0, BHVStressLevel bhvstressLevel_0)
	{
		if (this.m_navAgentSettings == null)
		{
			this.m_navAgentSettings = this.vmethod_0<BHVNavAgentSettings>();
		}
		if (this.m_navAgentSettings == null)
		{
			return 0f;
		}
		switch (bhvmovementSpeed_0)
		{
		case BHVMovementSpeed.WALK:
			return (bhvstressLevel_0 != BHVStressLevel.RELAX) ? (this.m_navAgentSettings.m_walkCombatSpeed * this.m_passiveSkillSpeedModifier) : (this.m_navAgentSettings.m_walkSpeed * this.m_passiveSkillSpeedModifier);
		case BHVMovementSpeed.RUN:
			return this.m_navAgentSettings.m_runSpeed * this.m_passiveSkillSpeedModifier;
		case BHVMovementSpeed.SPRINT:
			return this.m_navAgentSettings.m_sprintSpeed * this.m_passiveSkillSpeedModifier;
		case BHVMovementSpeed.JUMP:
			return this.m_navAgentSettings.m_jumpSpeed * this.m_passiveSkillSpeedModifier;
		case BHVMovementSpeed.CHARGE:
			return this.m_navAgentSettings.m_chargeSpeed * this.m_passiveSkillSpeedModifier;
		}
		DebugUtils.LogError(LogCategory.AI, "Movement Speed is invalid!");
		return 0f;
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x0000311D File Offset: 0x0000131D
	public bool method_20(Vector3 vector3_0)
	{
		return false;
	}

	// Token: 0x04000723 RID: 1827
	private List<NetworkTaskStruct> m_networkBHVTaskList = new List<NetworkTaskStruct>();

	// Token: 0x04000724 RID: 1828
	public BHVTaskManagerSetup m_setup;

	// Token: 0x04000725 RID: 1829
	public BHVTaskManagerLayer[] m_layers;

	// Token: 0x04000726 RID: 1830
	private int m_UIDCounter = -1;

	// Token: 0x04000727 RID: 1831
	public BHVTaskActionParameters m_actionParameters = new BHVTaskActionParameters();

	// Token: 0x04000728 RID: 1832
	public Dictionary<int, BHVTask> m_tasksLUT = new Dictionary<int, BHVTask>();

	// Token: 0x04000729 RID: 1833
	public Dictionary<Type, BHVTaskSettings> m_settingsLUT;

	// Token: 0x0400072A RID: 1834
	public int m_layerMask;

	// Token: 0x0400072B RID: 1835
	public uint m_npcSubTypeHashCode;

	// Token: 0x0400072C RID: 1836
	private MovementSync m_movement;

	// Token: 0x0400072D RID: 1837
	private BHVTaskParamSync m_synchedParams = new BHVTaskParamSync();

	// Token: 0x0400072E RID: 1838
	private BHVNavAgentSettings m_navAgentSettings;

	// Token: 0x0400072F RID: 1839
	private BHVFireStyleSettings m_fireStyleSettings;

	// Token: 0x04000730 RID: 1840
	private float m_passiveSkillSpeedModifier = 1f;
}
