using System;
using BHV;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020004B4 RID: 1204
public class PlayerController : MonoBehaviour
{
	// Token: 0x0600204A RID: 8266 RVA: 0x0001660F File Offset: 0x0001480F
	public virtual void Awake()
	{
		this.m_pitchNode = new GameObject("DefaultPitchNode").transform;
		this.m_pitchNode.parent = base.transform;
	}

	// Token: 0x0600204B RID: 8267 RVA: 0x0009E10C File Offset: 0x0009C30C
	public virtual void Start()
	{
		this.m_entity = base.GetComponent<EntityPlayer>();
		if (this.m_entity == null)
		{
			return;
		}
		if (this.m_entity.vmethod_25() == null)
		{
			return;
		}
		AvatarType avatarType = this.m_entity.vmethod_25().m_avatarDna.method_5();
		AvatarType avatarType2 = avatarType;
		if (avatarType2 != AvatarType.SIREN)
		{
			if (avatarType2 == AvatarType.SOLDIER)
			{
				this.m_retargetScaleMultiplier = 0.92f;
			}
		}
		else
		{
			this.m_retargetScaleMultiplier = 1f;
		}
		this.m_inInput = base.GetComponent<InstanceInput>();
		this.m_motor = (IBadAssCharacterMotor)base.GetComponent(typeof(IBadAssCharacterMotor));
		this.m_playerThirdPersonAnimationManagerFSM = base.GetComponent<PlayerAnimationManagerFSM>();
		this.m_playerBehavior = (PlayerBehavior)base.GetComponent(typeof(PlayerBehavior));
		BHVTaskManager bhvtaskManager = this.m_entity.vmethod_14();
		this.m_firstPersonSettings = bhvtaskManager.vmethod_0<BHVFirstPersonSettings>();
		this.m_pitchNodeBuffer = new RingBuffer(3, true);
		this.method_0();
	}

	// Token: 0x0600204C RID: 8268 RVA: 0x0009E1FC File Offset: 0x0009C3FC
	public virtual void Update()
	{
		if (this.m_entity == null)
		{
			return;
		}
		if (this.m_entity.vmethod_25() == null)
		{
			return;
		}
		if (this.m_motor == null)
		{
			this.Start();
		}
		if (this.m_motor == null)
		{
			return;
		}
		this.method_15(Time.deltaTime);
		this.method_16();
	}

	// Token: 0x0600204D RID: 8269 RVA: 0x0009E254 File Offset: 0x0009C454
	private void LateUpdate()
	{
		if (this.m_entity == null)
		{
			return;
		}
		if (this.m_entity.vmethod_25() == null)
		{
			return;
		}
		if (this.m_motor == null)
		{
			this.Start();
		}
		if (this.m_motor == null)
		{
			return;
		}
		if (this.adjustpitchNode)
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.method_28());
			this.m_pitchNode.localPosition -= vector;
		}
		Quaternion quaternion = this.m_pitchNode.rotation;
		if (this.m_pitchNodeBuffer.GetCount() == 2)
		{
			PlayerController.TimeRotation timeRotation = (PlayerController.TimeRotation)this.m_pitchNodeBuffer.PeekAt(0);
			PlayerController.TimeRotation timeRotation2 = (PlayerController.TimeRotation)this.m_pitchNodeBuffer.PeekLast();
			quaternion = Quaternion.Slerp(timeRotation.rotation, timeRotation2.rotation, (Time.time - 0.03333f - timeRotation.time) / (timeRotation2.time - timeRotation.time));
		}
		else if (this.m_pitchNodeBuffer.GetCount() == 3)
		{
			PlayerController.TimeRotation timeRotation3 = (PlayerController.TimeRotation)this.m_pitchNodeBuffer.PeekAt(0);
			PlayerController.TimeRotation timeRotation4 = (PlayerController.TimeRotation)this.m_pitchNodeBuffer.PeekAt(1);
			PlayerController.TimeRotation timeRotation5 = (PlayerController.TimeRotation)this.m_pitchNodeBuffer.PeekAt(2);
			Vector3 eulerAngles = timeRotation3.rotation.eulerAngles;
			Vector3 eulerAngles2 = timeRotation4.rotation.eulerAngles;
			Vector3 eulerAngles3 = timeRotation5.rotation.eulerAngles;
			float num = Utility.smethod_15(eulerAngles.x, eulerAngles2.x, eulerAngles3.x, timeRotation3.time, timeRotation4.time, timeRotation5.time, Time.time - 0.03333f);
			float num2 = Utility.smethod_15(eulerAngles.y, eulerAngles2.y, eulerAngles3.y, timeRotation3.time, timeRotation4.time, timeRotation5.time, Time.time - 0.03333f);
			float num3 = Utility.smethod_15(eulerAngles.z, eulerAngles2.z, eulerAngles3.z, timeRotation3.time, timeRotation4.time, timeRotation5.time, Time.time - 0.03333f);
			quaternion = Quaternion.Euler(num, num2, num3);
		}
		this.m_pitchNode.rotation = quaternion;
	}

	// Token: 0x0600204E RID: 8270 RVA: 0x0009E47C File Offset: 0x0009C67C
	private void method_0()
	{
		if (MonoSingleton<Session>.Instance.method_16())
		{
			this.m_authorizedActions = (PlayerAction)4199;
		}
		else if (!MonoSingleton<Session>.Instance.method_13())
		{
			if (MonoSingleton<Session>.Instance.method_15())
			{
				this.m_authorizedActions = (PlayerAction)0;
			}
			else
			{
				this.m_authorizedActions = (PlayerAction)8191;
			}
		}
		else
		{
			this.m_authorizedActions = (PlayerAction)3;
		}
	}

	// Token: 0x0600204F RID: 8271 RVA: 0x00016637 File Offset: 0x00014837
	public PlayerAction method_1()
	{
		return this.m_authorizedActions;
	}

	// Token: 0x06002050 RID: 8272 RVA: 0x0001663F File Offset: 0x0001483F
	public void method_2(PlayerAction playerAction_0)
	{
		this.m_authorizedActions = playerAction_0;
	}

	// Token: 0x06002051 RID: 8273 RVA: 0x00016648 File Offset: 0x00014848
	public bool method_3(PlayerAction playerAction_0)
	{
		return (this.m_authorizedActions & playerAction_0) != (PlayerAction)0;
	}

	// Token: 0x06002052 RID: 8274 RVA: 0x00016658 File Offset: 0x00014858
	private void method_4(Vector3 vector3_0)
	{
		this.m_desiredVelocity = vector3_0;
	}

	// Token: 0x06002053 RID: 8275 RVA: 0x00016661 File Offset: 0x00014861
	private void method_5(float float_0)
	{
		this.m_desiredVelocityDeltaTime = float_0;
	}

	// Token: 0x06002054 RID: 8276 RVA: 0x0009E4D8 File Offset: 0x0009C6D8
	public void method_6(float float_0)
	{
		bool flag = this.m_webSlowFactor > 0;
		if (float_0 < 1f)
		{
			this.m_webSlowFactor++;
		}
		else
		{
			this.m_webSlowFactor--;
		}
		if ((flag && this.m_webSlowFactor == 0) || (!flag && this.m_webSlowFactor > 0))
		{
			float num = this.m_moveSpeedMultiplier * float_0;
			this.m_moveSpeedMultiplier = Mathf.Clamp(num, 0.01f, 1f);
		}
	}

	// Token: 0x06002055 RID: 8277 RVA: 0x0001666A File Offset: 0x0001486A
	public void method_7(float float_0)
	{
		this.m_moveSpeedMultiplier = float_0;
	}

	// Token: 0x06002056 RID: 8278 RVA: 0x00016673 File Offset: 0x00014873
	public float method_8()
	{
		return this.m_moveSpeedMultiplier;
	}

	// Token: 0x06002057 RID: 8279 RVA: 0x0001667B File Offset: 0x0001487B
	public void method_9()
	{
		this.m_moveSpeedMultiplier = 1f;
		this.m_webSlowFactor = 0;
	}

	// Token: 0x06002058 RID: 8280 RVA: 0x0001668F File Offset: 0x0001488F
	public void method_10(Transform transform_0, Transform transform_1, Transform transform_2)
	{
		this.m_pitchNode = transform_0;
		this.m_pitchNodeRaw = transform_2;
		this.m_pitchNodeAdjuster = transform_1;
	}

	// Token: 0x06002059 RID: 8281 RVA: 0x0009E550 File Offset: 0x0009C750
	protected void method_11()
	{
		if (this.m_pitchNodeAdjuster != null && this.m_pitchNodeRaw != null)
		{
			this.m_pitchNodeAdjuster.localPosition = new Vector3(this.m_pitchNodeRaw.localPosition.y, -this.m_pitchNodeRaw.localPosition.z, this.m_pitchNodeRaw.localPosition.x);
			this.m_pitchNodeAdjuster.localRotation = Quaternion.Euler(270f, 90f, 0f);
		}
	}

	// Token: 0x0600205A RID: 8282 RVA: 0x000166A6 File Offset: 0x000148A6
	public Transform method_12()
	{
		return this.m_pitchNode;
	}

	// Token: 0x0600205B RID: 8283 RVA: 0x0009E5E4 File Offset: 0x0009C7E4
	protected virtual void FixedUpdate()
	{
		if (this.m_entity == null)
		{
			return;
		}
		if (this.m_entity.vmethod_25() == null)
		{
			return;
		}
		if (this.m_motor == null)
		{
			this.Start();
		}
		if (this.m_motor == null)
		{
			return;
		}
		this.method_13();
		this.method_14();
		this.method_19();
	}

	// Token: 0x0600205C RID: 8284 RVA: 0x0009E640 File Offset: 0x0009C840
	private void method_13()
	{
		if (this.m_motor == null)
		{
			return;
		}
		if (!this.m_inInput.IsCrouching() && !this.m_entity.method_67() && !this.m_entity.method_65())
		{
			this.m_motor.imethod_10(this.m_entity.CharacterSetting_0.m_standHeight);
		}
		else
		{
			this.m_motor.imethod_10(this.m_entity.CharacterSetting_0.m_crouchHeight);
		}
	}

	// Token: 0x0600205D RID: 8285 RVA: 0x0009E6B8 File Offset: 0x0009C8B8
	private void method_14()
	{
		if (this.m_motor == null)
		{
			return;
		}
		if (this.m_knockingBack)
		{
			this.m_motor.imethod_0(true);
			this.m_motor.imethod_1(true);
			this.m_motor.imethod_2(this.m_knockBackDir * this.m_retargetScaleMultiplier * this.m_moveSpeedMultiplier);
			this.m_motor.imethod_3(Time.fixedDeltaTime);
			if (Time.fixedTime - this.m_knockStartTime > 1f)
			{
				this.m_motor.imethod_0(false);
				this.m_motor.imethod_1(false);
				this.m_knockingBack = false;
			}
		}
		else if (this.m_bBerserkDash)
		{
			this.m_motor.imethod_0(false);
			this.m_motor.imethod_2(this.method_58() * this.m_retargetScaleMultiplier * this.m_moveSpeedMultiplier);
			this.m_motor.imethod_3(Time.fixedDeltaTime);
		}
		else
		{
			this.m_motor.imethod_0(this.m_inInput.IsJumping());
			this.m_motor.imethod_2(this.method_26() * this.m_retargetScaleMultiplier * this.m_moveSpeedMultiplier);
			this.m_motor.imethod_3(Time.fixedDeltaTime);
		}
		this.m_motor.imethod_4();
	}

	// Token: 0x0600205E RID: 8286 RVA: 0x0009E808 File Offset: 0x0009CA08
	private void method_15(float float_0)
	{
		if (!this.m_inInput.IsCrouching() && !this.m_entity.method_67() && !this.m_entity.method_65())
		{
			this.m_firstPersonHeightFactor += float_0 * this.m_firstPersonSettings.m_standUpSpeed;
			if (this.m_firstPersonHeightFactor > 1f)
			{
				this.m_firstPersonHeightFactor = 1f;
			}
		}
		else
		{
			this.m_firstPersonHeightFactor -= float_0 * this.m_firstPersonSettings.m_crouchDownSpeed;
			if (this.m_firstPersonHeightFactor < 0f)
			{
				this.m_firstPersonHeightFactor = 0f;
			}
		}
		this.m_entity.m_entityHeight = this.method_25();
	}

	// Token: 0x0600205F RID: 8287 RVA: 0x0009E8B4 File Offset: 0x0009CAB4
	private void method_16()
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null)
		{
			return;
		}
		if (!playerInfoSync.IsMyActor())
		{
			return;
		}
		BHVMovementSpeed bhvmovementSpeed = BHVMovementSpeed.INVALID;
		if (this.m_inInput.IsRunning())
		{
			bhvmovementSpeed = BHVMovementSpeed.SPRINT;
		}
		else if (this.m_inInput.IsMoving())
		{
			if (this.m_inInput.IsAiming())
			{
				bhvmovementSpeed = BHVMovementSpeed.WALK;
			}
			else
			{
				bhvmovementSpeed = BHVMovementSpeed.RUN;
			}
		}
		this.m_playerThirdPersonAnimationManagerFSM.vmethod_21(bhvmovementSpeed, this.m_inInput.GetMovementDirection(), this.m_inInput.IsCrouching(), this.m_inInput.IsJumping(), this.m_inInput.IsAiming());
	}

	// Token: 0x06002060 RID: 8288 RVA: 0x000166AE File Offset: 0x000148AE
	private Quaternion method_17()
	{
		return Quaternion.Euler(0f, this.m_inInput.GetYaw(), 0f);
	}

	// Token: 0x06002061 RID: 8289 RVA: 0x000166CA File Offset: 0x000148CA
	private Quaternion method_18()
	{
		return Quaternion.Euler(this.m_inInput.GetPitch(), 0f, 0f);
	}

	// Token: 0x06002062 RID: 8290 RVA: 0x0009E95C File Offset: 0x0009CB5C
	private void method_19()
	{
		if (!this.m_entity.vmethod_25().IsMyActor())
		{
			if (this.m_pitchNode != null)
			{
				this.m_pitchNode.localRotation = Quaternion.Euler(0f, 270f, 270f - this.m_playerThirdPersonAnimationManagerFSM.method_39());
				this.m_pitchNode.localPosition = Vector3.up * this.method_25();
				this.m_pitchNode.localPosition += this.method_21() * Vector3.back;
				if (this.m_playerThirdPersonAnimationManagerFSM.m_animationEventController != null)
				{
					this.m_playerThirdPersonAnimationManagerFSM.m_animationEventController.method_0(this.method_12().position + this.method_22());
				}
			}
			return;
		}
		this.m_entity.transform.rotation = this.method_17();
		if (this.m_pitchNode == null)
		{
			return;
		}
		this.m_pitchNode.localRotation = Quaternion.Euler(0f, 270f, 270f - this.m_inInput.GetPitch());
		this.m_pitchNode.localRotation *= this.m_playerBehavior.method_25();
		this.m_pitchNodeBuffer.Enqueue(new PlayerController.TimeRotation(Time.time, this.m_pitchNode.rotation));
		this.m_pitchNode.localPosition = Vector3.up * this.method_25();
		this.m_pitchNode.localPosition += this.method_21() * (this.m_pitchNode.localRotation * Vector3.down);
		this.m_pitchUpDelta = this.m_pitchNode.up - this.m_lastPitchUp;
		this.m_lastPitchUp = this.m_pitchNode.up;
	}

	// Token: 0x06002063 RID: 8291 RVA: 0x0009EB48 File Offset: 0x0009CD48
	public void method_20(Quaternion quaternion_0, float float_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null)
		{
			return;
		}
		if (!playerInfoSync.IsMyActor())
		{
			return;
		}
		this.m_pitchNode.localRotation = Quaternion.Euler(0f, 270f, 270f - this.m_inInput.GetPitch());
		this.m_pitchNode.localRotation *= quaternion_0;
		this.m_pitchNode.localPosition = Vector3.up * this.method_25();
		this.m_pitchUpDelta = this.m_pitchNode.up - this.m_lastPitchUp;
		this.m_lastPitchUp = this.m_pitchNode.up;
	}

	// Token: 0x06002064 RID: 8292 RVA: 0x000166E6 File Offset: 0x000148E6
	private float method_21()
	{
		return this.m_playerBehavior.method_24();
	}

	// Token: 0x06002065 RID: 8293 RVA: 0x000166F3 File Offset: 0x000148F3
	public Vector3 method_22()
	{
		return this.m_pitchNode.up;
	}

	// Token: 0x06002066 RID: 8294 RVA: 0x00016700 File Offset: 0x00014900
	public Vector3 method_23()
	{
		return this.m_pitchUpDelta;
	}

	// Token: 0x06002067 RID: 8295 RVA: 0x00016708 File Offset: 0x00014908
	public Vector3 method_24()
	{
		return base.transform.position + Vector3.up * this.method_25();
	}

	// Token: 0x06002068 RID: 8296 RVA: 0x0001672A File Offset: 0x0001492A
	public float method_25()
	{
		if (this.m_entity.CharacterSetting_0 != null)
		{
			return Mathf.Lerp(this.m_entity.CharacterSetting_0.m_crouchHeight, this.m_entity.CharacterSetting_0.m_standHeight, this.m_firstPersonHeightFactor);
		}
		return 0f;
	}

	// Token: 0x06002069 RID: 8297 RVA: 0x0009EC10 File Offset: 0x0009CE10
	private Vector3 method_26()
	{
		Vector3 vector = this.m_inInput.GetMovementDirection();
		vector = base.transform.TransformDirection(vector).normalized;
		vector *= this.method_27();
		global::Debug.smethod_8(base.transform.position, vector, Color.magenta);
		return vector;
	}

	// Token: 0x0600206A RID: 8298 RVA: 0x0009EC64 File Offset: 0x0009CE64
	private float method_27()
	{
		if (!MonoSingleton<Session>.Instance.method_16() && !MonoSingleton<Session>.Instance.method_17() && this.m_entity != null && this.m_entity.vmethod_16() != null)
		{
			this.m_weaponMoveAdjust = this.m_entity.vmethod_16().method_78(this.m_inInput);
		}
		if (this.m_entity != null && this.m_entity.method_67())
		{
			return this.m_firstPersonSettings.m_crippleWalkSpeed;
		}
		if (this.m_entity != null && this.m_entity.method_69())
		{
			return this.m_entity.CharacterSetting_0.m_walkSpeed_stun;
		}
		if (this.m_inInput.IsJumping())
		{
			return 1f;
		}
		if (this.m_inInput.IsCrouching())
		{
			return this.m_firstPersonSettings.m_crouchWalkSpeed * this.m_weaponMoveAdjust;
		}
		if (this.m_inInput.IsAiming())
		{
			return this.m_firstPersonSettings.m_standWalkSpeed * this.m_weaponMoveAdjust;
		}
		if (this.m_inInput.IsRunning())
		{
			return this.m_firstPersonSettings.m_standSprintSpeed * this.m_weaponMoveAdjust;
		}
		return this.m_firstPersonSettings.m_standRunSpeed * this.m_weaponMoveAdjust;
	}

	// Token: 0x0600206B RID: 8299 RVA: 0x0001676A File Offset: 0x0001496A
	private Vector3 method_28()
	{
		return this.m_motor.imethod_8().frameOffset;
	}

	// Token: 0x0600206C RID: 8300 RVA: 0x0001677C File Offset: 0x0001497C
	private Vector3 method_29()
	{
		return this.m_motor.imethod_8().frameVelocity;
	}

	// Token: 0x0600206D RID: 8301 RVA: 0x0001678E File Offset: 0x0001498E
	public void method_30(Vector3 vector3_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "KnockBack->" + vector3_0);
		this.m_knockStartTime = Time.fixedTime;
		this.m_knockingBack = true;
		this.m_knockBackDir = vector3_0;
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x000167BF File Offset: 0x000149BF
	public bool method_31()
	{
		return this.method_3(PlayerAction.Move);
	}

	// Token: 0x0600206F RID: 8303 RVA: 0x000167C8 File Offset: 0x000149C8
	public bool method_32()
	{
		return this.method_3(PlayerAction.Run);
	}

	// Token: 0x06002070 RID: 8304 RVA: 0x000167D1 File Offset: 0x000149D1
	public bool method_33()
	{
		return this.method_3(PlayerAction.Fire) && !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.vmethod_24();
	}

	// Token: 0x06002071 RID: 8305 RVA: 0x000167FD File Offset: 0x000149FD
	public bool method_34()
	{
		return this.method_33() && this.method_35();
	}

	// Token: 0x06002072 RID: 8306 RVA: 0x0009EDA0 File Offset: 0x0009CFA0
	protected bool method_35()
	{
		TargetingManager prop_ = MonoSingleton<TargetingManager>.Instance;
		if (prop_ != null)
		{
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			if (prop_.m_aimedEntity != null)
			{
				TargetingService.smethod_4(prop_.m_aimedEntity, out zero, out zero2);
			}
			EntityWeapon entityWeapon = this.m_entity.vmethod_16();
			if (entityWeapon != null)
			{
				if (this.m_playerThirdPersonAnimationManagerFSM != null)
				{
					float num = entityWeapon.method_92();
					this.m_playerThirdPersonAnimationManagerFSM.method_51(num);
				}
				entityWeapon.method_30();
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002073 RID: 8307 RVA: 0x0009EE28 File Offset: 0x0009D028
	public bool method_36()
	{
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		return entityWeapon != null && entityWeapon.m_ammoCount <= 0;
	}

	// Token: 0x06002074 RID: 8308 RVA: 0x0001680F File Offset: 0x00014A0F
	public bool method_37()
	{
		return !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.method_13(AnimationStateFSM.PlayerReload);
	}

	// Token: 0x06002075 RID: 8309 RVA: 0x0009EE58 File Offset: 0x0009D058
	public bool method_38()
	{
		if (!this.method_3(PlayerAction.ReloadWeapon))
		{
			return false;
		}
		EquipmentInventoryEntity equipmentInventoryEntity = this.m_entity.vmethod_19();
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (equipmentInventoryEntity == null || entityWeapon == null)
		{
			return false;
		}
		if (equipmentInventoryEntity.vmethod_15(entityWeapon.method_99()) <= 0)
		{
			return false;
		}
		bool flag = true;
		if (this.m_playerThirdPersonAnimationManagerFSM != null)
		{
			flag = this.m_playerThirdPersonAnimationManagerFSM.vmethod_25();
		}
		if (entityWeapon != null)
		{
			flag = flag && !entityWeapon.method_27();
		}
		return flag;
	}

	// Token: 0x06002076 RID: 8310 RVA: 0x0009EEE8 File Offset: 0x0009D0E8
	protected void method_39()
	{
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (entityWeapon != null)
		{
			entityWeapon.method_29();
		}
	}

	// Token: 0x06002077 RID: 8311 RVA: 0x0001682E File Offset: 0x00014A2E
	public bool method_40(byte byte_0)
	{
		return this.method_3(PlayerAction.SwitchWeapon) && ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(byte_0) != null && !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.method_49();
	}

	// Token: 0x06002078 RID: 8312 RVA: 0x00016866 File Offset: 0x00014A66
	public void method_41(byte byte_0)
	{
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_29(byte_0);
	}

	// Token: 0x06002079 RID: 8313 RVA: 0x00016873 File Offset: 0x00014A73
	public bool method_42()
	{
		return this.method_3(PlayerAction.Crouch) && !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.vmethod_22();
	}

	// Token: 0x0600207A RID: 8314 RVA: 0x0001689B File Offset: 0x00014A9B
	public bool method_43()
	{
		return this.method_3(PlayerAction.Crouch) && this.m_motor.imethod_11(base.transform.position, this.m_entity.CharacterSetting_0.m_standHeight);
	}

	// Token: 0x0600207B RID: 8315 RVA: 0x000168CE File Offset: 0x00014ACE
	public bool method_44()
	{
		return this.method_3(PlayerAction.Jump) && this.m_motor.imethod_5() && !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.method_47();
	}

	// Token: 0x0600207C RID: 8316 RVA: 0x00016905 File Offset: 0x00014B05
	public bool method_45()
	{
		return !this.m_motor.imethod_5() && !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.method_13(AnimationStateFSM.PlayerJump);
	}

	// Token: 0x0600207D RID: 8317 RVA: 0x00016933 File Offset: 0x00014B33
	public bool method_46()
	{
		return this.method_3(PlayerAction.Aim) && !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.vmethod_23();
	}

	// Token: 0x0600207E RID: 8318 RVA: 0x0009EF10 File Offset: 0x0009D110
	protected void method_47(bool bool_0)
	{
		if (this.m_playerThirdPersonAnimationManagerFSM == null)
		{
			return;
		}
		if (bool_0)
		{
			this.m_playerThirdPersonAnimationManagerFSM.method_31(AnimationStateFSM.PlayerAim);
		}
		else if (this.m_playerThirdPersonAnimationManagerFSM.method_13(AnimationStateFSM.PlayerAim))
		{
			this.m_playerThirdPersonAnimationManagerFSM.method_16("PlayerAim").vmethod_2();
		}
	}

	// Token: 0x0600207F RID: 8319 RVA: 0x0001695F File Offset: 0x00014B5F
	public bool method_48()
	{
		return this.method_3(PlayerAction.LaunchSkill) && !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.vmethod_28();
	}

	// Token: 0x06002080 RID: 8320 RVA: 0x00016990 File Offset: 0x00014B90
	protected void method_49()
	{
		this.m_entity.method_78();
	}

	// Token: 0x06002081 RID: 8321 RVA: 0x0001699D File Offset: 0x00014B9D
	public bool method_50()
	{
		return this.method_3(PlayerAction.Interact) && MonoSingleton<TargetingManager>.Instance.method_4();
	}

	// Token: 0x06002082 RID: 8322 RVA: 0x000169B5 File Offset: 0x00014BB5
	protected void method_51()
	{
		this.m_entity.method_79();
	}

	// Token: 0x06002083 RID: 8323 RVA: 0x0009EF64 File Offset: 0x0009D164
	public bool method_52()
	{
		if (!this.method_3(PlayerAction.ThrowGrenade))
		{
			return false;
		}
		bool flag = true;
		if (this.m_playerThirdPersonAnimationManagerFSM != null)
		{
			flag = this.m_playerThirdPersonAnimationManagerFSM.vmethod_27();
		}
		return flag && this.m_entity.vmethod_19().vmethod_19() > 0;
	}

	// Token: 0x06002084 RID: 8324 RVA: 0x0009EFB8 File Offset: 0x0009D1B8
	protected void method_53()
	{
		if (this.m_entity is EntityPlayer)
		{
			EntityPlayer entity = this.m_entity;
			entity.method_76();
		}
	}

	// Token: 0x06002085 RID: 8325 RVA: 0x0009EFE0 File Offset: 0x0009D1E0
	public bool method_54()
	{
		if (!this.method_3(PlayerAction.Melee))
		{
			return false;
		}
		if (this.m_playerThirdPersonAnimationManagerFSM == null)
		{
			return false;
		}
		EntityPlayer entity = this.m_entity;
		return !(entity == null) && !entity.m_pending_melee && this.m_playerThirdPersonAnimationManagerFSM.vmethod_26();
	}

	// Token: 0x06002086 RID: 8326 RVA: 0x0009F034 File Offset: 0x0009D234
	protected void method_55()
	{
		if (this.m_entity is EntityPlayer)
		{
			EntityPlayer entity = this.m_entity;
			entity.method_77();
		}
	}

	// Token: 0x06002087 RID: 8327 RVA: 0x000169C2 File Offset: 0x00014BC2
	public bool method_56()
	{
		return !(this.m_playerThirdPersonAnimationManagerFSM == null) && this.m_playerThirdPersonAnimationManagerFSM.method_13(AnimationStateFSM.PlayerMelee);
	}

	// Token: 0x06002088 RID: 8328 RVA: 0x000169E1 File Offset: 0x00014BE1
	public void method_57(bool bool_0)
	{
		this.m_bBerserkDash = bool_0;
	}

	// Token: 0x06002089 RID: 8329 RVA: 0x0009F05C File Offset: 0x0009D25C
	private Vector3 method_58()
	{
		float num = 10f;
		if (this.m_entity != null && this.m_entity.PlayerSkillManage_0 is BerserkManage)
		{
			num = (this.m_entity.PlayerSkillManage_0 as BerserkManage).method_33();
		}
		return base.transform.TransformDirection(Vector3.forward).normalized * num;
	}

	// Token: 0x04001502 RID: 5378
	protected EntityPlayer m_entity;

	// Token: 0x04001503 RID: 5379
	protected PlayerAnimationManagerFSM m_playerThirdPersonAnimationManagerFSM;

	// Token: 0x04001504 RID: 5380
	protected InstanceInput m_inInput;

	// Token: 0x04001505 RID: 5381
	protected PlayerBehavior m_playerBehavior;

	// Token: 0x04001506 RID: 5382
	protected float m_retargetScaleMultiplier = 1f;

	// Token: 0x04001507 RID: 5383
	protected float m_moveSpeedMultiplier = 1f;

	// Token: 0x04001508 RID: 5384
	protected int m_webSlowFactor;

	// Token: 0x04001509 RID: 5385
	private float m_firstPersonHeightFactor = 1f;

	// Token: 0x0400150A RID: 5386
	private IBadAssCharacterMotor m_motor;

	// Token: 0x0400150B RID: 5387
	private Vector3 m_desiredVelocity = Vector3.zero;

	// Token: 0x0400150C RID: 5388
	private float m_desiredVelocityDeltaTime;

	// Token: 0x0400150D RID: 5389
	private Transform m_pitchNode;

	// Token: 0x0400150E RID: 5390
	private Vector3 m_lastPitchUp;

	// Token: 0x0400150F RID: 5391
	private Vector3 m_pitchUpDelta;

	// Token: 0x04001510 RID: 5392
	private BHVFirstPersonSettings m_firstPersonSettings;

	// Token: 0x04001511 RID: 5393
	private PlayerAction m_authorizedActions;

	// Token: 0x04001512 RID: 5394
	private Transform m_pitchNodeRaw;

	// Token: 0x04001513 RID: 5395
	private Transform m_pitchNodeAdjuster;

	// Token: 0x04001514 RID: 5396
	private bool m_knockingBack;

	// Token: 0x04001515 RID: 5397
	private float m_knockStartTime;

	// Token: 0x04001516 RID: 5398
	private Vector3 m_knockBackDir;

	// Token: 0x04001517 RID: 5399
	private float m_weaponMoveAdjust = 1f;

	// Token: 0x04001518 RID: 5400
	private bool m_bBerserkDash;

	// Token: 0x04001519 RID: 5401
	public bool adjustpitchNode = true;

	// Token: 0x0400151A RID: 5402
	private Vector3 realPos;

	// Token: 0x0400151B RID: 5403
	private RingBuffer m_pitchNodeBuffer;

	// Token: 0x020004B5 RID: 1205
	private class TimeRotation
	{
		// Token: 0x0600208A RID: 8330 RVA: 0x000169EA File Offset: 0x00014BEA
		public TimeRotation(float float_0, Quaternion quaternion_0)
		{
			this.time = float_0;
			this.rotation = quaternion_0;
		}

		// Token: 0x0400151C RID: 5404
		public float time;

		// Token: 0x0400151D RID: 5405
		public Quaternion rotation;
	}
}
