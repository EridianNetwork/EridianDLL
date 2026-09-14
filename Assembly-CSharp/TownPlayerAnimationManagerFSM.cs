using System;
using System.Collections.Generic;
using BHV;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x0200009D RID: 157
public class TownPlayerAnimationManagerFSM : PlayerAnimationManagerFSM
{
	// Token: 0x060003AA RID: 938 RVA: 0x00047FAC File Offset: 0x000461AC
	public override void vmethod_13()
	{
		string text = "Entities/Player_Mecanim/Siren_1st_Controller_Town";
		this.m_firstPersonControllerTown = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/Siren_3rd_Controller_Town";
		this.m_thirdPersonControllerTown = (RuntimeAnimatorController)Resources.Load(text);
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00047FE8 File Offset: 0x000461E8
	public override void vmethod_14(int int_0)
	{
		if (base.Animator_0 != null && this.m_animationEventController != null && this.m_animationEventController as TownPlayerAnimationEventController != null)
		{
			(this.m_animationEventController as TownPlayerAnimationEventController).Boolean_0 = true;
		}
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00005427 File Offset: 0x00003627
	public override void vmethod_15(WeaponType weaponType_0)
	{
		if (this.m_firstPersonAnimator == null)
		{
			return;
		}
		this.m_firstPersonAnimator.runtimeAnimatorController = this.m_firstPersonControllerTown;
		this.m_firstPersonAnimator.SetFloat("fWeaponType", (float)weaponType_0);
		base.method_54();
		base.method_24();
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00048038 File Offset: 0x00046238
	public override void vmethod_4(GameObject gameObject_0)
	{
		this.m_animationHost = gameObject_0;
		base.Animator_0 = this.m_animationHost.GetComponent<Animator>();
		base.Animator_0.runtimeAnimatorController = this.m_thirdPersonControllerTown;
		for (int i = 0; i < base.Animator_0.layerCount; i++)
		{
			base.Animator_0.SetLayerWeight(i, 1f);
		}
		this.m_modelScale = this.m_animationHost.transform.localScale.x;
		this.m_VFXManager = this.m_animationHost.GetComponent<VFXManager>();
		this.vmethod_3();
	}

	// Token: 0x060003AE RID: 942 RVA: 0x000480CC File Offset: 0x000462CC
	public override void Start()
	{
		DebugUtils.Log(LogCategory.Animation, "PlayerTHirdPersonAnimationManager isPlayerLocal: " + this.m_isPlayerLocal);
		this.m_entity = base.GetComponent<EntityPlayer>();
		this.m_AudioCtl = base.GetComponent<BaseEventTriggerCtl>();
		base.vmethod_3();
		this.m_canUseFacingLogic = true;
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.vmethod_13();
		this.m_isSetDefaultWeaponPending = true;
		this.m_taskManager = base.GetComponent<BHVTaskManager>();
		this.m_AnimatorGraph = new MecanimAnimatorGraph(this);
		this.m_priorityMgr = new StatePriorityManage(this);
		this.m_transitionHistoryMgr = new TransitionHistoryManage(this);
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00048164 File Offset: 0x00046364
	protected override void vmethod_16()
	{
		if (base.Animator_0 == null || base.method_13(AnimationStateFSM.PlayerDie))
		{
			return;
		}
		if (this.m_movementSync == null)
		{
			this.m_movementSync = base.GetComponent<MovementSync>();
		}
		if (this.vmethod_17(this.m_inputFrameFlag))
		{
			return;
		}
		if (this.vmethod_18(this.m_inputFrameFlag))
		{
			return;
		}
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x000481C4 File Offset: 0x000463C4
	protected bool method_60(bool bool_0, float float_0)
	{
		if (this.m_jumpTimeQueue == null)
		{
			this.m_jumpTimeQueue = new List<float>();
		}
		if (bool_0)
		{
			float num = Time.time + float_0;
			this.m_jumpTimeQueue.Add(num);
		}
		bool flag = false;
		for (int i = 0; i < this.m_jumpTimeQueue.Count; i++)
		{
			if (Time.time - this.m_jumpTimeQueue[i] >= 0f)
			{
				flag = true;
				this.m_jumpTimeQueue.RemoveAt(i);
			}
		}
		return flag;
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x0004823C File Offset: 0x0004643C
	protected override bool vmethod_17(byte byte_0)
	{
		bool flag = (byte_0 & 2) != 0;
		if (this.method_60(flag, this.m_movementSync.Single_0))
		{
			if (!base.method_20())
			{
				this.vmethod_7(AnimationStateFSM.PlayerJumpStart);
				this.m_jumpStep = EAnimationJumpStep.JumpPre;
			}
			return true;
		}
		if (base.method_20())
		{
			return true;
		}
		this.m_jumpStep = EAnimationJumpStep.JumpNull;
		return false;
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00005467 File Offset: 0x00003667
	protected override float vmethod_20(bool bool_0, float float_0)
	{
		if (bool_0)
		{
			return 0.6f;
		}
		if (float_0 > 0.01f)
		{
			return 0.4f;
		}
		return 0f;
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00048294 File Offset: 0x00046494
	public override void vmethod_21(BHVMovementSpeed bhvmovementSpeed_0, Vector3 vector3_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (base.method_13(AnimationStateFSM.PlayerDie) && base.method_0(AnimationStateFSM.PlayerDie) == AnimationStatus.RUNNING)
		{
			return;
		}
		float num;
		switch (bhvmovementSpeed_0)
		{
		case BHVMovementSpeed.WALK:
			num = 0.2f;
			goto IL_0054;
		case BHVMovementSpeed.RUN:
			num = 0.4f;
			goto IL_0054;
		case BHVMovementSpeed.SPRINT:
			num = 0.6f;
			goto IL_0054;
		}
		num = 0f;
		IL_0054:
		if (bool_1)
		{
			if (!base.method_20())
			{
				this.vmethod_7(AnimationStateFSM.PlayerJumpStart);
				this.m_jumpStep = EAnimationJumpStep.JumpPre;
			}
		}
		else if (!base.method_20())
		{
			if (this.m_AnimatorGraph.method_3(MecanimAnimationID.ID_1st_JumpLand))
			{
				this.m_AnimatorGraph.method_4(MecanimAnimationID.ID_1st_JumpLand);
			}
			if (num > 0.1f)
			{
				AnimationPlayerMoveState animationPlayerMoveState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
				float num2 = BHVTaskUtils.smethod_8(Vector3.forward, vector3_0);
				animationPlayerMoveState.method_22(num, num2);
				if (!base.method_13(AnimationStateFSM.PlayerMove))
				{
					this.vmethod_7(AnimationStateFSM.PlayerMove);
				}
			}
			else if (!base.method_13(AnimationStateFSM.PlayerIdle) || !this.m_AnimatorGraph.method_3(MecanimAnimationID.ID_1st_StandIdle))
			{
				this.vmethod_7(AnimationStateFSM.PlayerIdle);
			}
		}
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_22()
	{
		return false;
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_23()
	{
		return false;
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_24()
	{
		return false;
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_25()
	{
		return false;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_26()
	{
		return false;
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_27()
	{
		return false;
	}

	// Token: 0x060003BA RID: 954 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_28()
	{
		return false;
	}

	// Token: 0x060003BB RID: 955 RVA: 0x000483A0 File Offset: 0x000465A0
	public override void vmethod_29()
	{
		PlayerInfoSync playerInfoSync = base.GetComponent<EntityPlayer>().vmethod_25();
		AvatarType avatarType = playerInfoSync.m_avatarDna.method_5();
		base.Animator_0.SetInteger("iAvatarType", (int)avatarType);
		base.Animator_0.SetBool("bLocalPlayer", playerInfoSync.IsMyActor());
		base.Animator_0.SetFloat("fDefaultPose", (float)avatarType);
	}

	// Token: 0x040003AC RID: 940
	private RuntimeAnimatorController m_firstPersonControllerTown;
}
