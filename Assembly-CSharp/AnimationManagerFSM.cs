using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using BHV;
using BHV_Anim;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000019 RID: 25
public class AnimationManagerFSM : AnimationManager, IPrefabManagerXmlGenericSetup
{
	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600008A RID: 138 RVA: 0x0000357A File Offset: 0x0000177A
	// (set) Token: 0x0600008B RID: 139 RVA: 0x00003582 File Offset: 0x00001782
	public Animator Animator_0
	{
		get
		{
			return this.m_animator;
		}
		set
		{
			this.m_animator = value;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x0600008C RID: 140 RVA: 0x0000358B File Offset: 0x0000178B
	// (set) Token: 0x0600008D RID: 141 RVA: 0x00003593 File Offset: 0x00001793
	public BHVStressLevel BHVStressLevel_0
	{
		get
		{
			return this.m_stressLevel;
		}
		set
		{
			this.m_stressLevel = value;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x0600008E RID: 142 RVA: 0x0000359C File Offset: 0x0000179C
	// (set) Token: 0x0600008F RID: 143 RVA: 0x000035A4 File Offset: 0x000017A4
	public Transform Transform_0
	{
		get
		{
			return this.m_displayTransform;
		}
		private set
		{
			this.m_displayTransform = value;
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000090 RID: 144 RVA: 0x000035AD File Offset: 0x000017AD
	// (set) Token: 0x06000091 RID: 145 RVA: 0x000035B5 File Offset: 0x000017B5
	public float Single_0
	{
		get
		{
			return this.m_lookAroundDuration;
		}
		set
		{
			this.m_lookAroundDuration = value;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000092 RID: 146 RVA: 0x000035BE File Offset: 0x000017BE
	// (set) Token: 0x06000093 RID: 147 RVA: 0x000035C6 File Offset: 0x000017C6
	public bool Boolean_0
	{
		get
		{
			return this.m_isFacingDifferentFromMovement;
		}
		set
		{
			this.m_isFacingDifferentFromMovement = value;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000094 RID: 148 RVA: 0x000035CF File Offset: 0x000017CF
	// (set) Token: 0x06000095 RID: 149 RVA: 0x000035D7 File Offset: 0x000017D7
	public float Single_1
	{
		get
		{
			return this.m_angleBetweenFacingAndMovement;
		}
		set
		{
			this.m_angleBetweenFacingAndMovement = value;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000096 RID: 150 RVA: 0x000035E0 File Offset: 0x000017E0
	// (set) Token: 0x06000097 RID: 151 RVA: 0x000035E8 File Offset: 0x000017E8
	public bool Boolean_1
	{
		get
		{
			return this.m_canUseRootMotion;
		}
		set
		{
			this.m_canUseRootMotion = value;
		}
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00038AD4 File Offset: 0x00036CD4
	public virtual bool imethod_0(string string_0)
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
			if (!this.method_15(text, this.m_animationStateMachine))
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
				if (!this.method_15(text2, this.m_upperBodyStateMachine))
				{
					DebugUtils.LogError(LogCategory.Animation, "Could not add Upper Body State:" + text2);
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00038C18 File Offset: 0x00036E18
	public AnimationStatus method_0(AnimationStateFSM animationStateFSM_0)
	{
		AnimationStateBase animationStateBase = null;
		if (this.m_animationStateMachine.States.TryGetValue(Utils.smethod_23(animationStateFSM_0), out animationStateBase))
		{
			return (animationStateBase as AnimationManagerState).m_status;
		}
		if (this.m_upperBodyStateMachine != null && this.m_upperBodyStateMachine.States.TryGetValue(Utils.smethod_23(animationStateFSM_0), out animationStateBase))
		{
			return (animationStateBase as AnimationManagerState).m_status;
		}
		return AnimationStatus.INVALID;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_1(AudioEventName audioEventName_0)
	{
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_2()
	{
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00038C7C File Offset: 0x00036E7C
	public virtual void vmethod_3()
	{
		if (this.m_rigidbodyTransforms == null)
		{
			this.m_rigidbodyTransforms = new List<Transform>();
		}
		else
		{
			this.m_rigidbodyTransforms.Clear();
		}
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>();
		int num = componentsInChildren.Length;
		for (int i = 0; i < num; i++)
		{
			Transform transform = componentsInChildren[i];
			if (!(componentsInChildren[i] == base.transform))
			{
				if (transform.gameObject.name == "displayObj")
				{
					this.m_displayTransform = transform;
				}
				if (transform.rigidbody != null)
				{
					if (this.m_rigidbodyTransforms != null)
					{
						this.m_rigidbodyTransforms.Add(transform);
					}
				}
				else if (this.m_setup != null && this.m_setup.m_settings != null && !string.IsNullOrEmpty(this.m_setup.m_settings.m_weaponHolderName) && transform.gameObject.name == this.m_setup.m_settings.m_weaponHolderName)
				{
					this.m_weaponHolder = transform;
					this.m_hasWeapon = true;
				}
			}
		}
		if (this.m_rigidbodyVelocity == null)
		{
			this.m_rigidbodyVelocity = new List<Vector3>();
		}
		else
		{
			this.m_rigidbodyVelocity.Clear();
		}
		for (int j = 0; j < this.m_rigidbodyTransforms.Count; j++)
		{
			this.m_rigidbodyVelocity.Add(Vector3.zero);
		}
		this.method_1(this.m_rigidbodyTransforms, this.m_rigidbodyVelocity, RagdollOperationType.Disable);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00038DE4 File Offset: 0x00036FE4
	public virtual void vmethod_4(GameObject gameObject_0)
	{
		this.m_animationHost = gameObject_0;
		this.m_animator = this.m_animationHost.GetComponent<Animator>();
		if (this.m_animator != null)
		{
			for (int i = 0; i < this.m_animator.layerCount; i++)
			{
				this.m_animator.SetLayerWeight(i, 1f);
			}
		}
		this.m_modelScale = this.m_animationHost.transform.localScale.x;
		this.m_VFXManager = this.m_animationHost.GetComponent<VFXManager>();
		this.vmethod_3();
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00038E74 File Offset: 0x00037074
	public void method_1(List<Transform> list_0, List<Vector3> list_1, RagdollOperationType ragdollOperationType_0)
	{
		if (list_0 == null || list_1 == null)
		{
			return;
		}
		int count = list_0.Count;
		if (count <= 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			if (ragdollOperationType_0 == RagdollOperationType.Disable)
			{
				if (list_0[i].rigidbody)
				{
					list_0[i].rigidbody.isKinematic = true;
					list_0[i].rigidbody.useGravity = false;
				}
				if (list_0[i].collider)
				{
					list_0[i].collider.enabled = false;
				}
			}
			else if (ragdollOperationType_0 == RagdollOperationType.Enable)
			{
				if (list_0[i].rigidbody)
				{
					list_0[i].rigidbody.isKinematic = false;
					list_0[i].rigidbody.useGravity = true;
				}
				if (list_0[i].collider)
				{
					list_0[i].collider.enabled = true;
				}
			}
			else if (ragdollOperationType_0 == RagdollOperationType.Save_Position)
			{
				list_1[i] = list_0[i].position;
			}
			else if (ragdollOperationType_0 == RagdollOperationType.Compute_Velocity)
			{
				list_0[i].rigidbody.velocity = (list_0[i].position - list_1[i]) / Time.deltaTime;
			}
			else if (ragdollOperationType_0 == RagdollOperationType.SetRagdollLayer)
			{
				list_0[i].gameObject.layer = LayerMask.NameToLayer("Ragdoll");
			}
			else if (ragdollOperationType_0 == RagdollOperationType.SetDefaultLayer)
			{
				list_0[i].gameObject.layer = LayerMask.NameToLayer("Default");
			}
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x000035F1 File Offset: 0x000017F1
	public void method_2(RagdollOperationType ragdollOperationType_0)
	{
		this.method_1(this.m_rigidbodyTransforms, this.m_rigidbodyVelocity, ragdollOperationType_0);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00003606 File Offset: 0x00001806
	public void method_3(bool bool_0)
	{
		this.m_entity.vmethod_21().method_17(false);
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00039010 File Offset: 0x00037210
	public void method_4()
	{
		if (this.m_animator != null)
		{
			MecanimEventEmitter component = this.m_animator.GetComponent<MecanimEventEmitter>();
			if (component != null)
			{
				global::UnityEngine.Object.DestroyImmediate(component);
			}
			global::UnityEngine.Object.DestroyImmediate(this.m_animator);
		}
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00039054 File Offset: 0x00037254
	public void method_5(bool bool_0)
	{
		if (this.m_animator != null)
		{
			MecanimEventEmitter component = this.m_animator.GetComponent<MecanimEventEmitter>();
			if (component != null)
			{
				component.enabled = bool_0;
			}
			this.m_animator.enabled = bool_0;
		}
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00003619 File Offset: 0x00001819
	public virtual void vmethod_5()
	{
		if (this.m_VFXManager)
		{
			this.m_VFXManager.method_15();
		}
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00039098 File Offset: 0x00037298
	public virtual void Start()
	{
		this.m_entity = base.GetComponent<Entity>();
		this.m_skeleton = base.GetComponentInChildren<Skeleton>();
		this.m_AudioCtl = base.GetComponentInChildren<BaseEventTriggerCtl>();
		this.m_validateNextMovePosition = true;
		this.vmethod_3();
		this.method_7(this.m_setup.m_settings.m_animationSpeedFactor * this.m_entity.vmethod_5());
		this.m_animator.logWarnings = false;
		for (int i = 0; i < this.Animator_0.layerCount; i++)
		{
			this.Animator_0.SetLayerWeight(i, 1f);
		}
		this.m_bPlayNormalDeathAnim = false;
		this.m_iDeathAnimIndex = 0;
		this.m_deathLayer = 3;
		this.m_movementSync = base.GetComponent<MovementSync>();
		if (this.m_additiveStateMachine != null)
		{
			this.method_15("LightHurt", this.m_additiveStateMachine);
		}
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00003633 File Offset: 0x00001833
	public void method_6()
	{
		if (this.Animator_0 != null)
		{
			this.Animator_0.speed = this.m_setup.m_settings.m_animationSpeedFactor * this.m_entity.vmethod_5();
		}
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0000366A File Offset: 0x0000186A
	public void method_7(float float_0)
	{
		if (this.Animator_0 != null)
		{
			this.Animator_0.speed = float_0;
			Mathf.Clamp(this.m_animator.speed, 0.1f, 10f);
		}
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00039168 File Offset: 0x00037368
	public virtual void Update()
	{
		this.m_animationStateMachine.Update();
		if (this.m_upperBodyStateMachine != null)
		{
			this.m_upperBodyStateMachine.Update();
		}
		if (this.m_additiveStateMachine != null)
		{
			this.m_additiveStateMachine.Update();
		}
		if (this.m_disableMovementAnimation && this.Animator_0 != null)
		{
			this.Animator_0.SetFloat("fMoveSpeed", 0f);
			this.Animator_0.SetBool("bMove", false);
			this.m_disableMovementAnimation = false;
		}
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x000036A1 File Offset: 0x000018A1
	public virtual void vmethod_6(bool bool_0)
	{
		if (this.m_animator != null)
		{
			this.m_animator.applyRootMotion = bool_0;
		}
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void FixedUpdate()
	{
	}

	// Token: 0x060000AA RID: 170 RVA: 0x000036BD File Offset: 0x000018BD
	public AnimationStatus method_8(string string_0, float float_0)
	{
		return this.method_9(this.m_animator, 0, string_0, float_0);
	}

	// Token: 0x060000AB RID: 171 RVA: 0x000391EC File Offset: 0x000373EC
	public AnimationStatus method_9(Animator animator_0, int int_0, string string_0, float float_0)
	{
		if (animator_0 == null)
		{
			return AnimationStatus.INVALID;
		}
		if (int_0 < 0 || int_0 >= animator_0.layerCount)
		{
			return AnimationStatus.INVALID;
		}
		if (string.IsNullOrEmpty(string_0))
		{
			return AnimationStatus.INVALID;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator_0.GetCurrentAnimatorStateInfo(int_0);
		if (!currentAnimatorStateInfo.IsTag(string_0))
		{
			return AnimationStatus.INVALID;
		}
		float normalizedTime = currentAnimatorStateInfo.normalizedTime;
		if (normalizedTime >= float_0)
		{
			return AnimationStatus.SUCCESS;
		}
		return AnimationStatus.RUNNING;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x000036CE File Offset: 0x000018CE
	public void method_10(string string_0)
	{
		this.m_animationStateMachine.method_0(string_0);
	}

	// Token: 0x060000AD RID: 173 RVA: 0x000036DC File Offset: 0x000018DC
	public void method_11(string string_0, AnimationStateMachine gclass12_0)
	{
		gclass12_0.method_1(string_0);
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00039244 File Offset: 0x00037444
	public virtual void vmethod_7(AnimationStateFSM animationStateFSM_0)
	{
		string text = Utils.smethod_23(animationStateFSM_0);
		if (this.m_animationStateMachine.States.ContainsKey(text))
		{
			this.m_fullBodyNextState = animationStateFSM_0;
			this.method_11(text, this.m_animationStateMachine);
			return;
		}
		if (this.m_upperBodyStateMachine != null && this.m_upperBodyStateMachine.States.ContainsKey(text))
		{
			this.m_upperBodyNextState = animationStateFSM_0;
			this.method_11(text, this.m_upperBodyStateMachine);
			return;
		}
		if (this.m_additiveStateMachine != null && this.m_additiveStateMachine.States.ContainsKey(text))
		{
			this.method_11(text, this.m_additiveStateMachine);
			return;
		}
	}

	// Token: 0x060000AF RID: 175 RVA: 0x000036E5 File Offset: 0x000018E5
	public bool method_12(string string_0)
	{
		return this.m_animationStateMachine.method_3(string_0);
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x000036F3 File Offset: 0x000018F3
	public bool method_13(AnimationStateFSM animationStateFSM_0)
	{
		return this.method_14(this.method_16(Utils.smethod_23(animationStateFSM_0)));
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x000392DC File Offset: 0x000374DC
	public bool method_14(AnimationStateBase gclass11_0)
	{
		if (gclass11_0 == null)
		{
			return false;
		}
		bool flag = this.m_animationStateMachine.method_4(gclass11_0);
		if (this.m_upperBodyStateMachine != null)
		{
			return flag || this.m_upperBodyStateMachine.method_4(gclass11_0) || this.m_additiveStateMachine.method_4(gclass11_0);
		}
		return flag;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00039328 File Offset: 0x00037528
	public bool method_15(string string_0, AnimationStateMachine gclass12_0)
	{
		try
		{
			string text = "Animation" + string_0 + "State";
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType(text);
			AnimationManagerState animationManagerState = (AnimationManagerState)Activator.CreateInstance(type);
			animationManagerState.vmethod_3(this);
			if (animationManagerState == null)
			{
				return false;
			}
			if (!gclass12_0.States.ContainsKey(text))
			{
				gclass12_0.States.Add(string_0, animationManagerState);
				animationManagerState.method_0(gclass12_0, string_0);
				return true;
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.AI, ex.ToString());
		}
		return false;
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x000393C0 File Offset: 0x000375C0
	public AnimationManagerState method_16(string string_0)
	{
		if (this.m_animationStateMachine != null && this.m_animationStateMachine.States.ContainsKey(string_0))
		{
			return this.m_animationStateMachine.States[string_0] as AnimationManagerState;
		}
		if (this.m_upperBodyStateMachine != null && this.m_upperBodyStateMachine.States.ContainsKey(string_0))
		{
			return this.m_upperBodyStateMachine.States[string_0] as AnimationManagerState;
		}
		if (this.m_additiveStateMachine != null && this.m_additiveStateMachine.States.ContainsKey(string_0))
		{
			return this.m_additiveStateMachine.States[string_0] as AnimationManagerState;
		}
		return null;
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_8(string string_0)
	{
		return 0;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00039464 File Offset: 0x00037664
	public override string ToString()
	{
		if (this.m_animator == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("AnimManager rootMotion " + this.m_canUseRootMotionPrevious);
		if (this.m_animationStateMachine != null && this.m_animationStateMachine.m_curState != null)
		{
			AnimationManagerState animationManagerState = this.m_animationStateMachine.m_curState as AnimationManagerState;
			if (animationManagerState != null)
			{
				stringBuilder.AppendLine(" " + this.method_17(animationManagerState) + ": " + animationManagerState.m_status.ToString());
			}
		}
		if (this.m_upperBodyStateMachine != null && this.m_upperBodyStateMachine.m_curState != null)
		{
			AnimationManagerState animationManagerState2 = this.m_upperBodyStateMachine.m_curState as AnimationManagerState;
			if (animationManagerState2 != null)
			{
				stringBuilder.AppendLine(" " + this.method_17(animationManagerState2) + ": " + animationManagerState2.m_status.ToString());
			}
		}
		if (this.m_additiveStateMachine != null && this.m_additiveStateMachine.m_curState != null)
		{
			AnimationManagerState animationManagerState3 = this.m_additiveStateMachine.m_curState as AnimationManagerState;
			if (animationManagerState3 != null)
			{
				stringBuilder.AppendLine(" " + this.method_17(animationManagerState3) + ": " + animationManagerState3.m_status.ToString());
			}
		}
		stringBuilder.AppendLine("Clips");
		for (int i = 0; i < this.m_animator.layerCount; i++)
		{
			foreach (AnimationInfo animationInfo in this.m_animator.GetCurrentAnimationClipState(i))
			{
				if (animationInfo.clip != null && !string.IsNullOrEmpty(animationInfo.clip.name) && animationInfo.weight > 0f)
				{
					stringBuilder.AppendLine(string.Concat(new object[]
					{
						" ",
						animationInfo.clip.name,
						": ",
						animationInfo.weight
					}));
				}
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00039680 File Offset: 0x00037880
	private string method_17(AnimationManagerState animationManagerState_0)
	{
		if (animationManagerState_0 == null)
		{
			return null;
		}
		string name = animationManagerState_0.GetType().Name;
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		return name.Replace("Animation", string.Empty).Replace("State", string.Empty);
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00003707 File Offset: 0x00001907
	public void method_18(ENPCParticleType enpcparticleType_0, Transform transform_0)
	{
		if (this.m_VFXManager == null)
		{
			return;
		}
		this.m_VFXManager.method_7(enpcparticleType_0, transform_0, true);
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00003727 File Offset: 0x00001927
	public virtual GameObject vmethod_9()
	{
		return null;
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00003727 File Offset: 0x00001927
	public virtual GameObject vmethod_10(int int_0)
	{
		return null;
	}

	// Token: 0x060000BA RID: 186 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_11(bool bool_0)
	{
	}

	// Token: 0x060000BB RID: 187 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_12()
	{
		return false;
	}

	// Token: 0x060000BC RID: 188 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnDeath()
	{
	}

	// Token: 0x060000BD RID: 189 RVA: 0x0000372A File Offset: 0x0000192A
	public void TriggerAnimationEventMecanim(string eventName)
	{
		if (this.m_animEventHandlerList.ContainsKey(eventName))
		{
			this.m_animEventHandlerList[eventName]();
		}
	}

	// Token: 0x040000D3 RID: 211
	public Dictionary<string, AnimationManagerFSM.OnAnimEventHandler> m_animEventHandlerList = new Dictionary<string, AnimationManagerFSM.OnAnimEventHandler>();

	// Token: 0x040000D4 RID: 212
	[HideInInspector]
	public GameObject m_animationHost;

	// Token: 0x040000D5 RID: 213
	private Animator m_animator;

	// Token: 0x040000D6 RID: 214
	[HideInInspector]
	public BaseEventTriggerCtl m_AudioCtl;

	// Token: 0x040000D7 RID: 215
	[HideInInspector]
	public AnimationStateMachine m_animationStateMachine = new AnimationStateMachine();

	// Token: 0x040000D8 RID: 216
	[HideInInspector]
	public AnimationStateMachine m_upperBodyStateMachine;

	// Token: 0x040000D9 RID: 217
	[HideInInspector]
	public AnimationStateFSM m_fullBodyNextState = AnimationStateFSM.Invalid;

	// Token: 0x040000DA RID: 218
	[HideInInspector]
	public AnimationStateFSM m_upperBodyNextState = AnimationStateFSM.Invalid;

	// Token: 0x040000DB RID: 219
	[HideInInspector]
	public AnimationStateMachine m_additiveStateMachine = new AnimationStateMachine();

	// Token: 0x040000DC RID: 220
	private BHVStressLevel m_stressLevel = BHVStressLevel.INVALID;

	// Token: 0x040000DD RID: 221
	public MovementSync m_movementSync;

	// Token: 0x040000DE RID: 222
	[HideInInspector]
	public bool m_disableMovementAnimation;

	// Token: 0x040000DF RID: 223
	protected float m_modelScale = 1f;

	// Token: 0x040000E0 RID: 224
	protected int m_maxFrameNumberPerAnimation = 1000;

	// Token: 0x040000E1 RID: 225
	public Entity m_entity;

	// Token: 0x040000E2 RID: 226
	private Transform m_displayTransform;

	// Token: 0x040000E3 RID: 227
	private float m_lookAroundDuration;

	// Token: 0x040000E4 RID: 228
	private bool m_isFacingDifferentFromMovement;

	// Token: 0x040000E5 RID: 229
	private float m_angleBetweenFacingAndMovement;

	// Token: 0x040000E6 RID: 230
	private bool m_canUseRootMotion;

	// Token: 0x040000E7 RID: 231
	protected bool m_canUseRootMotionPrevious;

	// Token: 0x040000E8 RID: 232
	public BHVAnimationManagerSetup m_setup;

	// Token: 0x040000E9 RID: 233
	[HideInInspector]
	public DamageType m_damageType;

	// Token: 0x040000EA RID: 234
	[HideInInspector]
	public int m_iDeathAnimIndex;

	// Token: 0x040000EB RID: 235
	public AnimationEventController m_animationEventController;

	// Token: 0x040000EC RID: 236
	[HideInInspector]
	public Transform m_weaponHolder;

	// Token: 0x040000ED RID: 237
	[HideInInspector]
	public bool m_hasWeapon;

	// Token: 0x040000EE RID: 238
	[HideInInspector]
	public bool m_isHumanoid;

	// Token: 0x040000EF RID: 239
	[HideInInspector]
	public List<Transform> m_rigidbodyTransforms;

	// Token: 0x040000F0 RID: 240
	protected List<Vector3> m_rigidbodyVelocity;

	// Token: 0x040000F1 RID: 241
	[HideInInspector]
	public bool m_canUseFacingLogic;

	// Token: 0x040000F2 RID: 242
	[HideInInspector]
	public bool m_bPlayNormalDeathAnim;

	// Token: 0x040000F3 RID: 243
	[HideInInspector]
	public bool m_validateNextMovePosition = true;

	// Token: 0x040000F4 RID: 244
	public VFXManager m_VFXManager;

	// Token: 0x040000F5 RID: 245
	public int m_deathLayer = 3;

	// Token: 0x040000F6 RID: 246
	protected Skeleton m_skeleton;

	// Token: 0x0200001A RID: 26
	// (Invoke) Token: 0x060000BF RID: 191
	public delegate void OnAnimEventHandler();
}
