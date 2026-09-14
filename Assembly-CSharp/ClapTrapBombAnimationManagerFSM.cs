using System;
using System.IO;
using System.Xml.Serialization;
using BHV_Anim;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class ClapTrapBombAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000F7 RID: 247 RVA: 0x00038AD4 File Offset: 0x00036CD4
	public override bool imethod_0(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		bool flag;
		try
		{
			using (StringReader stringReader = new StringReader(string_0))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(BHVAnimationManagerSetup));
				this.m_setup = xmlSerializer.Deserialize(stringReader) as BHVAnimationManagerSetup;
			}
			goto IL_0060;
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "Invalid Animation Manager Settings:" + ex.Message);
			flag = false;
		}
		return flag;
		IL_0060:
		for (int i = 0; i < this.m_setup.m_animationStateList.Length; i++)
		{
			string text = this.m_setup.m_animationStateList[i];
			if (!base.method_15(text, this.m_animationStateMachine))
			{
				DebugUtils.LogError(LogCategory.Animation, "Could not add State:" + text);
				return false;
			}
		}
		if (this.m_setup.m_animationUpperBodyStateList != null)
		{
			this.m_upperBodyStateMachine = new AnimationStateMachine();
			for (int j = 0; j < this.m_setup.m_animationUpperBodyStateList.Length; j++)
			{
				string text2 = this.m_setup.m_animationUpperBodyStateList[j];
				if (!base.method_15(text2, this.m_upperBodyStateMachine))
				{
					DebugUtils.LogError(LogCategory.Animation, "Could not add Upper Body State:" + text2);
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0003A45C File Offset: 0x0003865C
	private void Awake()
	{
		this.m_entity = base.GetComponent<Entity>();
		BHVTaskManager bhvtaskManager = this.m_entity.vmethod_14();
		if (bhvtaskManager != null)
		{
			bhvtaskManager.m_animationManagerFSM = this;
		}
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0003A494 File Offset: 0x00038694
	public override void Start()
	{
		base.Animator_0 = base.gameObject.GetComponentInChildren<Animator>();
		base.gameObject.transform.rotation.SetLookRotation(Vector3.forward, Vector3.up);
		if (base.Animator_0 != null)
		{
			this.m_animationHost = base.Animator_0.gameObject;
			for (int i = 0; i < base.Animator_0.layerCount; i++)
			{
				base.Animator_0.SetLayerWeight(i, 1f);
			}
			base.Animator_0.updateMode = AnimatorUpdateMode.Normal;
		}
		base.Animator_0.logWarnings = false;
		base.Boolean_1 = false;
		this.m_skeleton = base.GetComponentInChildren<Skeleton>();
		this.m_AudioCtl = base.GetComponentInChildren<BaseEventTriggerCtl>();
		this.m_validateNextMovePosition = false;
		base.Animator_0.logWarnings = false;
		for (int j = 0; j < base.Animator_0.layerCount; j++)
		{
			base.Animator_0.SetLayerWeight(j, 1f);
		}
		base.method_21(this.m_animationStateMachine);
		if (base.Animator_0 != null)
		{
			this.m_mecanimEventEmitter = base.Animator_0.GetComponent<MecanimEventEmitter>();
			if (this.m_mecanimEventEmitter != null)
			{
				this.m_mecanimEventEmitter.emitType = MecanimEventEmitTypes.Upwards;
			}
		}
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0003A5D0 File Offset: 0x000387D0
	public override void Update()
	{
		base.Update();
		if (base.Animator_0 != null && base.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("Idle") && global::UnityEngine.Random.Range(0f, 1f) < this.m_extraIdlePlayChance)
		{
			int num = global::UnityEngine.Random.Range(0, this.m_extraIdleAnimCount);
			base.Animator_0.SetFloat("fExtraIdleType", (float)num);
			base.Animator_0.SetTrigger("tExtraIdle");
		}
	}

	// Token: 0x060000FB RID: 251 RVA: 0x000038AB File Offset: 0x00001AAB
	private void OnDestroy()
	{
		if (this.m_VFXManager != null)
		{
			this.m_VFXManager.method_7(ENPCParticleType.E_Explode, base.transform, true);
		}
	}

	// Token: 0x0400011C RID: 284
	public int m_extraIdleAnimCount = 8;

	// Token: 0x0400011D RID: 285
	public float m_extraIdlePlayChance = 0.01f;
}
