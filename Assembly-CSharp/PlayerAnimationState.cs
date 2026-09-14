using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class PlayerAnimationState : AnimationManagerState
{
	// Token: 0x17000023 RID: 35
	// (get) Token: 0x0600047C RID: 1148 RVA: 0x000061B4 File Offset: 0x000043B4
	protected Animator Animator_0
	{
		get
		{
			return this.m_playerAnimManager.m_firstPersonAnimator;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x0600047D RID: 1149 RVA: 0x000061C1 File Offset: 0x000043C1
	private Animator Animator_1
	{
		get
		{
			return this.m_playerAnimManager.Animator_0;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x0600047E RID: 1150 RVA: 0x000061CE File Offset: 0x000043CE
	// (set) Token: 0x0600047F RID: 1151 RVA: 0x000061FA File Offset: 0x000043FA
	public PlayerWeaponAnimationManagerFSM PlayerWeaponAnimationManagerFSM_0
	{
		get
		{
			if (this.m_weaponAnimationManager == null)
			{
				this.m_weaponAnimationManager = this.m_playerAnimManager.gameObject.GetComponent<PlayerWeaponAnimationManagerFSM>();
			}
			return this.m_weaponAnimationManager;
		}
		set
		{
			this.m_weaponAnimationManager = value;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000480 RID: 1152 RVA: 0x00006203 File Offset: 0x00004403
	// (set) Token: 0x06000481 RID: 1153 RVA: 0x00006222 File Offset: 0x00004422
	public bool Boolean_0
	{
		get
		{
			this.m_enableFirstPerson = this.m_playerAnimManager.m_firstPersonAnimator != null;
			return this.m_enableFirstPerson;
		}
		set
		{
			this.m_enableFirstPerson = value;
		}
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0000622B File Offset: 0x0000442B
	public override void vmethod_3(AnimationManagerFSM animationManagerFSM_0)
	{
		base.vmethod_3(animationManagerFSM_0);
		this.m_playerAnimManager = (PlayerAnimationManagerFSM)animationManagerFSM_0;
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x00006240 File Offset: 0x00004440
	protected void method_4(PlayerAnimationState.AnimationStateEventCallBack animationStateEventCallBack_0, float float_2)
	{
		this.m_eventList.Add(new PlayerAnimationState.AnimationStateEvent(animationStateEventCallBack_0, float_2));
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0004AFA4 File Offset: 0x000491A4
	protected void method_5(PlayerAnimationState.AnimationStateEventCallBack animationStateEventCallBack_0, float float_2)
	{
		for (int i = 0; i < this.m_eventList.Count; i++)
		{
			if (this.m_eventList[i].m_callback == animationStateEventCallBack_0)
			{
				this.m_eventList.Remove(this.m_eventList[i]);
				return;
			}
		}
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_4()
	{
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0004B000 File Offset: 0x00049200
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AudioCtl == null)
		{
			this.m_AudioCtl = this.m_playerAnimManager.m_AudioCtl;
		}
		if (this.m_playerAnimManager.m_animationEventController != null)
		{
			this.m_playerAnimManager.m_animationEventController.m_pendingLeftHandIK = false;
		}
		if (this.m_animInfoMgr == null)
		{
			this.m_animInfoMgr = new PlayerAnimationState.AnimatorInfoManage(this);
		}
		this.m_eventList.Add(new PlayerAnimationState.AnimationStateEvent(new PlayerAnimationState.AnimationStateEventCallBack(this.OnAnimationTimeElapsed), 1f));
		this.m_ControllorEnterCurrentState = false;
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0004B094 File Offset: 0x00049294
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM == null)
		{
			return;
		}
		if (this.m_AnimationManagerFSM.Animator_0 == null)
		{
			return;
		}
		base.vmethod_1();
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(this.m_layer);
		if (!this.m_ControllorEnterCurrentState && this.m_animatorInfo.IsTag(this.m_stateTag))
		{
			this.vmethod_4();
			this.m_ControllorEnterCurrentState = true;
		}
		if (this.m_ControllorEnterCurrentState)
		{
			for (int i = this.m_eventList.Count - 1; i >= 0; i--)
			{
				if (this.m_animatorInfo.IsTag(this.m_stateTag) && this.m_animatorInfo.normalizedTime + this.m_networkCompensationPer >= this.m_eventList[i].m_percent)
				{
					this.m_eventList[i].m_callback(this.m_stateTag);
					this.m_eventRemoveList.Add(this.m_eventList[i]);
				}
				else if (this.m_eventList[i].m_callback == new PlayerAnimationState.AnimationStateEventCallBack(this.OnAnimationTimeElapsed) && !this.m_animatorInfo.IsTag(this.m_stateTag))
				{
					DebugUtils.Log(LogCategory.Gamelogic, "OnAnimationTimeElapsed: " + this.m_animatorInfo.tagHash);
					this.m_eventList[i].m_callback(this.m_animatorInfo.tagHash.ToString());
					this.m_eventRemoveList.Add(this.m_eventList[i]);
				}
			}
			for (int j = 0; j < this.m_eventRemoveList.Count; j++)
			{
				this.m_eventList.Remove(this.m_eventRemoveList[j]);
			}
			this.m_eventRemoveList.Clear();
		}
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void OnAnimationTimeElapsed(string m_stateTag)
	{
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x0004B288 File Offset: 0x00049488
	public void method_6()
	{
		float num = 0f;
		float num2 = 0f;
		if (this.Animator_0 != null && this.Animator_1 != null)
		{
			AnimatorStateInfo animatorStateInfo = this.Animator_0.GetCurrentAnimatorStateInfo(0);
			if (animatorStateInfo.length > 0f && animatorStateInfo.IsTag(this.m_stateTag))
			{
				num = animatorStateInfo.length;
			}
			animatorStateInfo = this.Animator_1.GetCurrentAnimatorStateInfo(1);
			if (animatorStateInfo.length > 0f && animatorStateInfo.IsTag(this.m_stateTag))
			{
				num2 = animatorStateInfo.length;
			}
			if (num > 0f && num2 > 0f && !(num2 - num).AlmostEquals(0f, 1E-06f))
			{
				DebugUtils.LogWarning(LogCategory.Animation, string.Concat(new object[] { "animation state ", this.StateName, " thirdPersonAniLength ", num2, " firstPersonAniLength ", num }));
			}
		}
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x00006254 File Offset: 0x00004454
	public void method_7(MecanimAnimationID mecanimAnimationID_0)
	{
		this.m_playerAnimManager.m_AnimatorGraph.method_0(mecanimAnimationID_0);
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x00006267 File Offset: 0x00004467
	public void method_8(MecanimAnimationID mecanimAnimationID_0)
	{
		this.m_playerAnimManager.m_AnimatorGraph.method_4(mecanimAnimationID_0);
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0000627A File Offset: 0x0000447A
	public void method_9(string string_1, int int_0, float float_2)
	{
		this.m_playerAnimManager.m_AnimatorGraph.method_1(string_1, int_0, float_2);
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0000628F File Offset: 0x0000448F
	public bool method_10(string string_1, bool bool_1)
	{
		this.Animator_0.SetBool(string_1, bool_1);
		return this.Animator_0.GetBool(string_1) == bool_1;
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x000062AD File Offset: 0x000044AD
	public bool method_11(string string_1, float float_2)
	{
		this.Animator_0.SetFloat(string_1, float_2);
		return this.Animator_0.GetFloat(string_1) == float_2;
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x000062CB File Offset: 0x000044CB
	public bool method_12(string string_1, int int_0)
	{
		this.Animator_0.SetInteger(string_1, int_0);
		return this.Animator_0.GetInteger(string_1) == int_0;
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x000062E9 File Offset: 0x000044E9
	public bool method_13(int int_0, float float_2)
	{
		this.Animator_0.SetLayerWeight(int_0, float_2);
		return true;
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x000062F9 File Offset: 0x000044F9
	public bool method_14(int int_0, float float_2)
	{
		this.Animator_1.SetLayerWeight(int_0, float_2);
		return true;
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x00006309 File Offset: 0x00004509
	public AnimatorStateInfo method_15(bool bool_1, int int_0)
	{
		if (bool_1)
		{
			return this.Animator_0.GetCurrentAnimatorStateInfo(int_0);
		}
		return this.Animator_1.GetCurrentAnimatorStateInfo(int_0);
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x00006327 File Offset: 0x00004527
	public bool method_16(string string_1, bool bool_1)
	{
		if (this.Animator_1 == null)
		{
			return false;
		}
		this.Animator_1.SetBool(string_1, bool_1);
		return this.Animator_1.GetBool(string_1) == bool_1;
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00006355 File Offset: 0x00004555
	public bool method_17(string string_1, float float_2)
	{
		this.Animator_1.SetFloat(string_1, float_2);
		return this.Animator_1.GetFloat(string_1) == float_2;
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x00006373 File Offset: 0x00004573
	public bool method_18(string string_1, int int_0)
	{
		this.Animator_1.SetInteger(string_1, int_0);
		return this.Animator_1.GetInteger(string_1) == int_0;
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x00006391 File Offset: 0x00004591
	public void method_19(bool bool_1)
	{
		this.m_playerAnimManager.method_32(bool_1);
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnMecanimAnimOver(MecanimAnimationID _id)
	{
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x0000639F File Offset: 0x0000459F
	public VFXManager method_20()
	{
		return this.method_21().VFXManager_0;
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x000063AC File Offset: 0x000045AC
	public EntityPlayer method_21()
	{
		if (this.m_entityPlayer == null)
		{
			this.m_entityPlayer = this.m_playerAnimManager.m_entity as EntityPlayer;
		}
		return this.m_entityPlayer;
	}

	// Token: 0x04000450 RID: 1104
	protected int m_layer;

	// Token: 0x04000451 RID: 1105
	protected AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000452 RID: 1106
	protected float m_networkCompensationPer;

	// Token: 0x04000453 RID: 1107
	private bool m_ControllorEnterCurrentState;

	// Token: 0x04000454 RID: 1108
	protected BaseEventTriggerCtl m_AudioCtl;

	// Token: 0x04000455 RID: 1109
	protected string m_stateTag;

	// Token: 0x04000456 RID: 1110
	protected PlayerAnimationManagerFSM m_playerAnimManager;

	// Token: 0x04000457 RID: 1111
	private List<PlayerAnimationState.AnimationStateEvent> m_eventList = new List<PlayerAnimationState.AnimationStateEvent>();

	// Token: 0x04000458 RID: 1112
	private List<PlayerAnimationState.AnimationStateEvent> m_eventRemoveList = new List<PlayerAnimationState.AnimationStateEvent>();

	// Token: 0x04000459 RID: 1113
	private EntityPlayer m_entityPlayer;

	// Token: 0x0400045A RID: 1114
	protected PlayerAnimationState.AnimatorInfoManage m_animInfoMgr;

	// Token: 0x0400045B RID: 1115
	private bool m_enableFirstPerson = true;

	// Token: 0x0400045C RID: 1116
	private PlayerWeaponAnimationManagerFSM m_weaponAnimationManager;

	// Token: 0x020000C5 RID: 197
	protected struct AnimationStateEvent
	{
		// Token: 0x0600049A RID: 1178 RVA: 0x000063D8 File Offset: 0x000045D8
		public AnimationStateEvent(PlayerAnimationState.AnimationStateEventCallBack animationStateEventCallBack_0, float float_0)
		{
			this.m_callback = animationStateEventCallBack_0;
			this.m_percent = float_0;
		}

		// Token: 0x0400045D RID: 1117
		public PlayerAnimationState.AnimationStateEventCallBack m_callback;

		// Token: 0x0400045E RID: 1118
		public float m_percent;
	}

	// Token: 0x020000C6 RID: 198
	public class AnimatorInfoManage
	{
		// Token: 0x0600049B RID: 1179 RVA: 0x000063E8 File Offset: 0x000045E8
		public AnimatorInfoManage(PlayerAnimationState playerAnimationState_0)
		{
			this.m_owner = playerAnimationState_0;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x000063F7 File Offset: 0x000045F7
		public void Reset(float _netLatency)
		{
			this.m_bInited = false;
			this.m_netLatency = _netLatency;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0004B390 File Offset: 0x00049590
		public float method_0(string string_0, int int_0)
		{
			this.m_animatorInfo = this.m_owner.method_15(false, int_0);
			if (!this.m_animatorInfo.IsTag(string_0))
			{
				return -1f;
			}
			if (!this.m_bInited)
			{
				this.method_1();
			}
			return Mathf.Clamp((Time.time + this.m_netLatency - this.m_startTime) / this.m_length_anim, 0f, 1f);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00006407 File Offset: 0x00004607
		private void method_1()
		{
			this.m_bInited = true;
			this.m_startTime = Time.time;
			this.m_length_anim = this.m_animatorInfo.length;
		}

		// Token: 0x0400045F RID: 1119
		private PlayerAnimationState m_owner;

		// Token: 0x04000460 RID: 1120
		private float m_netLatency;

		// Token: 0x04000461 RID: 1121
		private AnimatorStateInfo m_animatorInfo;

		// Token: 0x04000462 RID: 1122
		private bool m_bInited;

		// Token: 0x04000463 RID: 1123
		private float m_startTime;

		// Token: 0x04000464 RID: 1124
		private float m_length_anim;
	}

	// Token: 0x020000C7 RID: 199
	public struct AnimData
	{
		// Token: 0x0600049F RID: 1183 RVA: 0x0000642C File Offset: 0x0000462C
		public AnimData(int int_0, string string_0, MecanimAnimationID mecanimAnimationID_0, string string_1)
		{
			this.m_layer = int_0;
			this.m_tag = string_0;
			this.m_param_1st = mecanimAnimationID_0;
			this.m_param_3rd = string_1;
		}

		// Token: 0x04000465 RID: 1125
		public int m_layer;

		// Token: 0x04000466 RID: 1126
		public string m_tag;

		// Token: 0x04000467 RID: 1127
		public MecanimAnimationID m_param_1st;

		// Token: 0x04000468 RID: 1128
		public string m_param_3rd;
	}

	// Token: 0x020000C8 RID: 200
	// (Invoke) Token: 0x060004A1 RID: 1185
	public delegate void AnimationStateEventCallBack(string animationName);
}
