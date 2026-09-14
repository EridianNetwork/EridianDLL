using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200002F RID: 47
public abstract class NPCAnimationManagerFSM : AnimationManagerFSM
{
	// Token: 0x06000134 RID: 308 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool imethod_0(string string_0)
	{
		return true;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0003B314 File Offset: 0x00039514
	public void method_19(EntityNpc.EntitySubType entitySubType_0)
	{
		uint num = Utility.smethod_1(entitySubType_0.ToString());
		if (!AIServiceSetting.AIServiceSetting_0.m_npcAnimationMgrSetupList.TryGetValue(num, out this.m_setup))
		{
			DebugUtils.LogError(LogCategory.AI, "Not find setting for " + entitySubType_0);
		}
		AIServiceSetting.AIServiceSetting_0.method_33(entitySubType_0, this);
	}

	// Token: 0x06000136 RID: 310 RVA: 0x0003B36C File Offset: 0x0003956C
	protected void method_20()
	{
		if (this.m_animationHost != null)
		{
			base.Animator_0 = this.m_animationHost.GetComponent<Animator>();
		}
		if (base.Animator_0 == null)
		{
			base.Animator_0 = base.gameObject.GetComponentInChildren<Animator>();
		}
		if (base.Animator_0 != null)
		{
			this.m_animationHost = base.Animator_0.gameObject;
			for (int i = 0; i < base.Animator_0.layerCount; i++)
			{
				base.Animator_0.SetLayerWeight(i, 1f);
			}
			if (this.m_animationHost.transform.parent != null)
			{
				this.m_modelScale = this.m_animationHost.transform.parent.localScale.x;
			}
			else
			{
				this.m_modelScale = this.m_animationHost.transform.localScale.x;
			}
			this.m_VFXManager = this.m_animationHost.GetComponent<VFXManager>();
			base.Animator_0.updateMode = AnimatorUpdateMode.Normal;
			this.vmethod_6(false);
			this.m_canUseRootMotionPrevious = false;
		}
	}

	// Token: 0x06000137 RID: 311 RVA: 0x000039EF File Offset: 0x00001BEF
	private void Awake()
	{
		this.method_22();
	}

	// Token: 0x06000138 RID: 312 RVA: 0x0003B488 File Offset: 0x00039688
	public override void Start()
	{
		this.method_20();
		base.Start();
		this.method_21(this.m_animationStateMachine);
		this.method_21(this.m_upperBodyStateMachine);
		this.m_bInDazeEffect = false;
		this.m_bTeleportEnd = false;
		if (base.Animator_0 != null)
		{
			if (this.m_entity is EntityNpc)
			{
				base.Animator_0.SetInteger("iEntitySubType", (int)(this.m_entity as EntityNpc).m_subType);
			}
			this.m_mecanimEventEmitter = base.Animator_0.GetComponent<MecanimEventEmitter>();
			if (this.m_mecanimEventEmitter != null)
			{
				this.m_mecanimEventEmitter.emitType = MecanimEventEmitTypes.Upwards;
			}
		}
	}

	// Token: 0x06000139 RID: 313 RVA: 0x0003B530 File Offset: 0x00039730
	protected void method_21(AnimationStateMachine gclass12_0)
	{
		if (gclass12_0 == null)
		{
			return;
		}
		foreach (KeyValuePair<string, AnimationStateBase> keyValuePair in gclass12_0.States)
		{
			AnimationManagerState animationManagerState = keyValuePair.Value as AnimationManagerState;
			if (animationManagerState != null)
			{
				animationManagerState.vmethod_3(this);
			}
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x000039F7 File Offset: 0x00001BF7
	public override void OnTeleportMe(Vector3 teleportPos)
	{
		base.OnTeleportMe(teleportPos);
		this.m_bTeleportEnd = true;
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_13(WeakPoint.PartInfo partInfo_0)
	{
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00003A07 File Offset: 0x00001C07
	public virtual void LateUpdate()
	{
		if (this.m_animationHost == null)
		{
			return;
		}
		if (this.m_animationStateMachine.m_curState == null)
		{
		}
	}

	// Token: 0x0600013D RID: 317 RVA: 0x0003B578 File Offset: 0x00039778
	public virtual void OnTriggerAdvanceSpawn()
	{
		AnimationAdvanceSpawnState animationAdvanceSpawnState = base.method_16(Utils.smethod_23(AnimationStateFSM.AdvanceSpawn)) as AnimationAdvanceSpawnState;
		if (animationAdvanceSpawnState != null)
		{
			animationAdvanceSpawnState.m_colliderTriggered = true;
		}
		AnimationCombatSpawnState animationCombatSpawnState = base.method_16(Utils.smethod_23(AnimationStateFSM.CombatSpawn)) as AnimationCombatSpawnState;
		if (animationCombatSpawnState != null)
		{
			animationCombatSpawnState.m_colliderTriggered = true;
		}
	}

	// Token: 0x0600013E RID: 318 RVA: 0x0003B5C0 File Offset: 0x000397C0
	public void OnThrowWeapon()
	{
		AnimationThrowWeaponState animationThrowWeaponState = base.method_16(Utils.smethod_23(AnimationStateFSM.ThrowWeapon)) as AnimationThrowWeaponState;
		if (animationThrowWeaponState != null)
		{
			animationThrowWeaponState.m_readyToLaunch = true;
		}
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0003B5EC File Offset: 0x000397EC
	public void OnMeleeHit()
	{
		AnimationMeleeAttackState animationMeleeAttackState = base.method_16(Utils.smethod_23(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
		if (animationMeleeAttackState != null)
		{
			animationMeleeAttackState.m_triggetHitEvent = true;
		}
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_14()
	{
	}

	// Token: 0x06000141 RID: 321 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_15()
	{
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0003B618 File Offset: 0x00039818
	private void method_22()
	{
		if (this.m_pelvis == null)
		{
			Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
			int num = componentsInChildren.Length;
			for (int i = 0; i < num; i++)
			{
				Transform transform = componentsInChildren[i];
				if (transform.name.ToLower().Contains("pelvis"))
				{
					this.m_pelvis = transform;
					this.m_pelvisPosition = this.m_pelvis.localPosition;
					this.m_pelvisRotation = this.m_pelvis.localRotation;
					return;
				}
			}
		}
	}

	// Token: 0x06000143 RID: 323 RVA: 0x0003B698 File Offset: 0x00039898
	public void method_23(bool bool_0 = false)
	{
		if (this.m_pelvis == null)
		{
			return;
		}
		if (bool_0 || (!base.method_13(AnimationStateFSM.Die) && !base.method_13(AnimationStateFSM.Dead)))
		{
			this.m_pelvis.localPosition = this.m_pelvisPosition;
			this.m_pelvis.localRotation = this.m_pelvisRotation;
		}
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0003B6EC File Offset: 0x000398EC
	public virtual void OnNpcRespawn()
	{
		base.method_5(true);
		base.method_2(RagdollOperationType.Disable);
		this.method_23(true);
		if (base.Animator_0 != null)
		{
			base.Animator_0.SetBool("IsDying", false);
			base.Animator_0.SetTrigger("tRespawn");
			if (this.m_isHumanoid)
			{
				base.Animator_0.SetBool("IsCasual", true);
				base.Animator_0.SetFloat("FaceAngle", 0f);
				base.Animator_0.SetBool("IsMoveBackward", false);
				base.Animator_0.SetInteger("CrouchStatus", 0);
				base.Animator_0.SetBool("IsCrouching", false);
				base.Animator_0.SetInteger("StanceMode", 0);
				base.Animator_0.SetFloat("fSprintMode", 0f);
			}
			base.Animator_0.SetFloat("fMoveSpeed", 0f);
			base.Animator_0.SetBool("bMove", false);
			base.Animator_0.SetBool("bIdle", true);
			base.Animator_0.SetBool("IsTurning", false);
			base.Animator_0.SetFloat("fTurnAngle", 0f);
		}
		if (this.m_animationHost != null)
		{
			this.m_animationHost.transform.localPosition = Vector3.zero;
			this.m_animationHost.transform.localRotation = Quaternion.identity;
		}
		if (base.Transform_0 != null)
		{
			SkinnedMeshRenderer component = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
			if (component != null)
			{
				component.castShadows = true;
				component.receiveShadows = true;
				component.updateWhenOffscreen = false;
			}
		}
		this.vmethod_7(AnimationStateFSM.Idle);
	}

	// Token: 0x06000145 RID: 325 RVA: 0x0003B89C File Offset: 0x00039A9C
	public void method_24(Transform transform_0, bool bool_0)
	{
		if (transform_0 != null)
		{
			Transform transform = transform_0.FindChild("displayObj");
			if (transform != null)
			{
				MeshRenderer component = transform.gameObject.GetComponent<MeshRenderer>();
				if (component != null)
				{
					component.enabled = bool_0;
				}
			}
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0003B8E4 File Offset: 0x00039AE4
	public override void Update()
	{
		base.Update();
		if (this.m_beginDeathFading && base.Transform_0 != null)
		{
			this.m_currentTime += Time.deltaTime;
			if (this.m_currentTime >= this.m_fadingTime)
			{
				if (this.m_bRestore)
				{
					this.method_28();
				}
			}
			else
			{
				SkinnedMeshRenderer component = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
				if (component != null)
				{
					for (int i = 0; i < component.materials.Length; i++)
					{
						component.materials[i].SetFloat("_CurrentTime", this.m_currentTime);
					}
				}
			}
		}
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00003A25 File Offset: 0x00001C25
	public void method_25(bool bool_0, float float_0, bool bool_1, float float_1, bool bool_2)
	{
		this.m_bRestore = bool_2;
		this.method_27(true, bool_0, float_0, bool_1, float_1);
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00003A3B File Offset: 0x00001C3B
	public void method_26(bool bool_0, float float_0, bool bool_1, float float_1, bool bool_2)
	{
		this.m_bRestore = bool_2;
		this.method_27(false, bool_0, float_0, bool_1, float_1);
	}

	// Token: 0x06000149 RID: 329 RVA: 0x0003B980 File Offset: 0x00039B80
	protected void method_27(bool bool_0, bool bool_1, float float_0, bool bool_2, float float_1)
	{
		if (base.Transform_0 == null)
		{
			return;
		}
		SkinnedMeshRenderer component = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
		if (component == null)
		{
			return;
		}
		component.receiveShadows = false;
		component.castShadows = false;
		if (GraphicsDataMgr.CharacterDeathEffectData_FadingTexture == null)
		{
			CharacterDeathEffectData component2 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterDeathEffectData>();
			if (component2 != null)
			{
				GraphicsDataMgr.CharacterDeathEffectData_FadingTime = component2.FadingTime;
				GraphicsDataMgr.CharacterDeathEffectData_FadingTexture = component2.FadingTexture;
				this.m_fadingTime = GraphicsDataMgr.CharacterDeathEffectData_FadingTime;
			}
		}
		for (int i = 0; i < component.materials.Length; i++)
		{
			component.materials[i].SetTexture("_FadingMap", GraphicsDataMgr.CharacterDeathEffectData_FadingTexture);
			component.materials[i].EnableKeyword("FADING_VFX_ON");
			if (bool_0)
			{
				component.materials[i].DisableKeyword("REVERSE_FADING_ON");
			}
			else
			{
				component.materials[i].EnableKeyword("REVERSE_FADING_ON");
			}
			if (bool_1)
			{
				component.materials[i].SetFloat("_Fading_Time", float_0);
			}
			else
			{
				component.materials[i].SetFloat("_Fading_Time", this.m_fadingTime);
			}
			if (bool_2)
			{
				component.materials[i].SetFloat("_Fading_Scale", float_1);
			}
			else
			{
				component.materials[i].SetFloat("_Fading_Scale", 1f);
			}
		}
		this.m_currentTime = 0f;
		this.m_beginDeathFading = true;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x0003BAEC File Offset: 0x00039CEC
	protected void method_28()
	{
		if (base.Transform_0 == null)
		{
			return;
		}
		SkinnedMeshRenderer component = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
		if (component != null)
		{
			for (int i = 0; i < component.materials.Length; i++)
			{
				component.materials[i].DisableKeyword("FADING_VFX_ON");
			}
		}
		this.m_currentTime = 0f;
		this.m_beginDeathFading = false;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x0003BB54 File Offset: 0x00039D54
	public void method_29()
	{
		this.method_27(true, false, 0f, false, 1f);
		WeakPoint weakPoint = null;
		this.m_entity.method_8(out weakPoint);
		if (weakPoint != null)
		{
			this.m_VFXManager.method_5(ENPCParticleType.E_DeadEffect, null, weakPoint.transform, this.m_vZero, this.m_identityRot, -1f, true);
		}
		else
		{
			this.m_VFXManager.method_5(ENPCParticleType.E_DeadEffect, null, base.Transform_0, this.m_vZero, this.m_identityRot, -1f, true);
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x00003A51 File Offset: 0x00001C51
	public void method_30()
	{
		this.method_28();
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0003BBE0 File Offset: 0x00039DE0
	protected static void smethod_0(BaseEventTriggerCtl baseEventTriggerCtl_0, NPCAnimationManagerFSM.NPCSMGShootType npcsmgshootType_0, float float_0, ref float float_1)
	{
		if (baseEventTriggerCtl_0 == null)
		{
			return;
		}
		baseEventTriggerCtl_0.gameObject.BroadcastMessage("TriggerEffectByName", "OnAttack", SendMessageOptions.DontRequireReceiver);
		float_1 = Time.time;
		AudioEventName audioEventName = AudioEventName.INVALID;
		switch (npcsmgshootType_0)
		{
		case NPCAnimationManagerFSM.NPCSMGShootType.First:
			if (float_0 > 2f)
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Shoot_HL_Rnd;
			}
			else if (float_0 > 1f)
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Shoot_ML_Rnd;
			}
			else
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Shoot_LL_Rnd;
			}
			break;
		case NPCAnimationManagerFSM.NPCSMGShootType.Chain:
			if (float_0 > 2f)
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Shoot_HS_Rnd;
			}
			else if (float_0 > 1f)
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Shoot_MS_Rnd;
			}
			else
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Shoot_LS_Rnd;
			}
			break;
		case NPCAnimationManagerFSM.NPCSMGShootType.Last:
			if (float_0 > 2f)
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_High_Tail_Rnd;
			}
			else if (float_0 > 1f)
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Med_Tail_Rnd;
			}
			else
			{
				audioEventName = AudioEventName.Wep_SMG_NPC_Low_Tail_Rnd;
			}
			break;
		}
		if (audioEventName != AudioEventName.INVALID)
		{
			baseEventTriggerCtl_0.vmethod_1(audioEventName);
		}
	}

	// Token: 0x04000137 RID: 311
	[HideInInspector]
	public bool m_bInDazeEffect;

	// Token: 0x04000138 RID: 312
	public MecanimEventEmitter m_mecanimEventEmitter;

	// Token: 0x04000139 RID: 313
	protected Vector3 m_vZero = Vector3.zero;

	// Token: 0x0400013A RID: 314
	protected Quaternion m_identityRot = Quaternion.identity;

	// Token: 0x0400013B RID: 315
	protected Vector3 m_pelvisPosition = Vector3.zero;

	// Token: 0x0400013C RID: 316
	protected Quaternion m_pelvisRotation = Quaternion.identity;

	// Token: 0x0400013D RID: 317
	protected Transform m_pelvis;

	// Token: 0x0400013E RID: 318
	[HideInInspector]
	public bool m_bCanMoveTurn;

	// Token: 0x0400013F RID: 319
	[HideInInspector]
	public bool m_bTeleportEnd;

	// Token: 0x04000140 RID: 320
	private float m_fadingTime = 30f;

	// Token: 0x04000141 RID: 321
	private bool m_beginDeathFading;

	// Token: 0x04000142 RID: 322
	private float m_currentTime;

	// Token: 0x04000143 RID: 323
	private bool m_bRestore;

	// Token: 0x02000030 RID: 48
	protected enum NPCSMGShootType
	{
		// Token: 0x04000145 RID: 325
		First,
		// Token: 0x04000146 RID: 326
		Chain,
		// Token: 0x04000147 RID: 327
		Last
	}
}
