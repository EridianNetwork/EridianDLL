using System;
using BHV;
using UnityEngine;

// Token: 0x02000257 RID: 599
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Character/BadAss Character Motor")]
[Serializable]
public class BadAssCharacterMotor : MonoBehaviour, IBadAssCharacterMotor
{
	// Token: 0x06000C36 RID: 3126 RVA: 0x0000BD4D File Offset: 0x00009F4D
	public BadAssCharacterMotorMovement imethod_8()
	{
		return this.movement;
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x00069A50 File Offset: 0x00067C50
	private void Start()
	{
		this.m_characterController = base.GetComponent<CharacterController>();
		this.m_entityPlayer = base.GetComponent<EntityPlayer>();
		this.m_taskManager = base.GetComponent<BHVTaskManager>();
		this.m_gravityAcceleration = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_gravityAcceleration;
		this.jumping.baseHeight = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_jumpHeight;
		this.m_characterTransform = base.transform;
	}

	// Token: 0x06000C38 RID: 3128 RVA: 0x0000BD55 File Offset: 0x00009F55
	private float method_0()
	{
		return this.m_deltaTime;
	}

	// Token: 0x06000C39 RID: 3129 RVA: 0x0000BD5D File Offset: 0x00009F5D
	public void imethod_3(float float_0)
	{
		this.m_deltaTime = float_0;
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x0000BD66 File Offset: 0x00009F66
	public void imethod_2(Vector3 vector3_0)
	{
		this.m_desiredVelocity = vector3_0;
	}

	// Token: 0x06000C3B RID: 3131 RVA: 0x0000BD6F File Offset: 0x00009F6F
	public void imethod_0(bool bool_0)
	{
		this.m_inputJump = bool_0;
	}

	// Token: 0x06000C3C RID: 3132 RVA: 0x00069AC0 File Offset: 0x00067CC0
	public void imethod_4()
	{
		if (this.method_0() < 1E-45f)
		{
			return;
		}
		Vector3 vector = this.movement.velocity;
		vector = this.method_1(vector);
		vector = this.method_2(vector);
		vector = this.m_entityPlayer.PlayerSkillManage_0.vmethod_5(vector);
		Vector3 position = this.m_characterTransform.position;
		Vector3 vector2 = vector * this.method_0();
		float stepOffset = this.m_characterController.stepOffset;
		Vector3 vector3 = new Vector3(vector2.x, 0f, vector2.z);
		float num = Mathf.Max(stepOffset, vector3.magnitude);
		if (this.m_isGrounded)
		{
			vector2 -= num * Vector3.up;
		}
		this.m_groundNormal = Vector3.zero;
		this.movement.collisionFlags = this.m_characterController.Move(vector2);
		this.movement.lastHitPoint = this.movement.hitPoint;
		this.m_lastGroundNormal = this.m_groundNormal;
		Vector3 vector4 = new Vector3(vector.x, 0f, vector.z);
		this.movement.velocity = (this.m_characterTransform.position - position) / this.method_0();
		Vector3 vector5 = new Vector3(this.movement.velocity.x, 0f, this.movement.velocity.z);
		if (vector4 == Vector3.zero)
		{
			this.movement.velocity = new Vector3(0f, this.movement.velocity.y, 0f);
		}
		else
		{
			float num2 = Vector3.Dot(vector5, vector4) / vector4.sqrMagnitude;
			this.movement.velocity = vector4 * Mathf.Clamp01(num2) + this.movement.velocity.y * Vector3.up;
		}
		if (this.movement.velocity.y < vector.y - 0.001f)
		{
			if (this.movement.velocity.y < 0f)
			{
				this.movement.velocity.y = vector.y;
			}
			else
			{
				this.jumping.holdingJumpButton = false;
			}
		}
		if (this.m_isGrounded && !this.method_5())
		{
			this.m_isGrounded = false;
			base.SendMessage("OnFall", SendMessageOptions.DontRequireReceiver);
			this.m_characterTransform.position += num * Vector3.up;
		}
		else if (!this.m_isGrounded && this.method_5())
		{
			this.m_isGrounded = true;
			this.jumping.jumping = false;
			base.SendMessage("OnLand", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x00069D74 File Offset: 0x00067F74
	private Vector3 method_1(Vector3 vector3_0)
	{
		Vector3 vector = this.method_3();
		if (this.m_isGrounded)
		{
			vector = this.method_4(vector, this.m_groundNormal);
		}
		else
		{
			vector3_0.y = 0f;
		}
		float num = this.method_6(this.m_isGrounded) * this.method_0();
		Vector3 vector2 = vector - vector3_0;
		if (vector2.sqrMagnitude > num * num)
		{
			vector2 = vector2.normalized * num;
		}
		vector3_0 += vector2;
		if (this.m_isGrounded)
		{
			vector3_0.y = Mathf.Min(vector3_0.y, 0f);
		}
		return vector3_0;
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x00069E10 File Offset: 0x00068010
	private Vector3 method_2(Vector3 vector3_0)
	{
		if (!this.m_inputJump)
		{
			this.jumping.holdingJumpButton = false;
			this.jumping.lastButtonDownTime = -100f;
		}
		else if (this.jumping.lastButtonDownTime < 0f)
		{
			this.jumping.lastButtonDownTime = Time.time;
		}
		if (this.m_isGrounded)
		{
			vector3_0.y = Mathf.Min(0f, vector3_0.y) - this.m_gravityAcceleration * this.method_0();
		}
		else
		{
			vector3_0.y = this.movement.velocity.y - this.m_gravityAcceleration * this.method_0();
			if (this.jumping.jumping && this.jumping.holdingJumpButton && Time.time < this.jumping.lastStartTime + this.jumping.extraHeight / this.method_7(this.jumping.baseHeight))
			{
				vector3_0 += this.jumping.jumpDir * this.m_gravityAcceleration * this.method_0();
			}
			vector3_0.y = Mathf.Max(vector3_0.y, -this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_velocityFallMax);
		}
		if (this.m_isGrounded)
		{
			if (this.jumping.enabled && Time.time - this.jumping.lastButtonDownTime < 0.2f)
			{
				this.m_isGrounded = false;
				this.jumping.jumping = true;
				this.jumping.lastStartTime = Time.time;
				this.jumping.lastButtonDownTime = -100f;
				this.jumping.holdingJumpButton = true;
				this.jumping.jumpDir = Vector3.up;
				vector3_0.y = 0f;
				vector3_0 += this.jumping.jumpDir * this.method_7(this.jumping.baseHeight);
				base.SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				this.jumping.holdingJumpButton = false;
			}
		}
		return vector3_0;
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x0006A030 File Offset: 0x00068230
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.normal.y > 0f && hit.normal.y > this.m_groundNormal.y && hit.moveDirection.y < 0f)
		{
			if ((hit.point - this.movement.lastHitPoint).sqrMagnitude <= 0.001f && !(this.m_lastGroundNormal == Vector3.zero))
			{
				this.m_groundNormal = this.m_lastGroundNormal;
			}
			else
			{
				this.m_groundNormal = hit.normal;
			}
			this.movement.hitPoint = hit.point;
			this.movement.frameVelocity = Vector3.zero;
		}
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x0000BD78 File Offset: 0x00009F78
	private Vector3 method_3()
	{
		return this.m_desiredVelocity;
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x0006A0FC File Offset: 0x000682FC
	private Vector3 method_4(Vector3 vector3_0, Vector3 vector3_1)
	{
		Vector3 vector = Vector3.Cross(Vector3.up, vector3_0);
		return Vector3.Cross(vector, vector3_1).normalized * vector3_0.magnitude;
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x0000BD80 File Offset: 0x00009F80
	private bool method_5()
	{
		return this.m_groundNormal.y > 0.01f;
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x0000BD94 File Offset: 0x00009F94
	private float method_6(bool bool_0)
	{
		if (bool_0)
		{
			return this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_velocityChangeGroundMax;
		}
		return this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_velocityChangeAirMax;
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x0000BDBA File Offset: 0x00009FBA
	private float method_7(float float_0)
	{
		return Mathf.Sqrt(2f * float_0 * this.m_gravityAcceleration);
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x0000BDCF File Offset: 0x00009FCF
	public bool imethod_7()
	{
		return (this.movement.collisionFlags & CollisionFlags.Above) != CollisionFlags.None;
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x0000BDE4 File Offset: 0x00009FE4
	private bool method_8()
	{
		return this.m_groundNormal.y <= Mathf.Cos(this.m_characterController.slopeLimit * 0.017453292f);
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x0000BE0C File Offset: 0x0000A00C
	public bool imethod_5()
	{
		return this.m_isGrounded;
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x0000BE14 File Offset: 0x0000A014
	public bool imethod_6()
	{
		return this.jumping.jumping;
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x0006A130 File Offset: 0x00068330
	public bool imethod_9(Vector3 vector3_0, Vector3 vector3_1, float float_0, out RaycastHit raycastHit_0)
	{
		Vector3 vector = vector3_0 + this.m_characterController.center + Vector3.up * (-this.m_characterController.height * 0.5f + this.m_characterController.radius + this.m_characterController.stepOffset);
		Vector3 vector2 = vector + Vector3.up * (this.m_characterController.height - 2f * this.m_characterController.radius);
		return Physics.CapsuleCast(vector, vector2, this.m_characterController.radius, vector3_1.normalized, out raycastHit_0, float_0, TargetingService.Int32_0);
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x0006A1D8 File Offset: 0x000683D8
	public bool imethod_11(Vector3 vector3_0, float float_0)
	{
		Vector3 vector = vector3_0 + this.m_characterController.center + Vector3.up * (-float_0 * 0.5f + this.m_characterController.radius + this.m_characterController.stepOffset);
		Vector3 vector2 = this.m_characterTransform.position + this.m_characterController.center + Vector3.up * (float_0 * 0.5f - this.m_characterController.radius + 0.2f);
		return !Physics.CheckCapsule(vector, vector2, this.m_characterController.radius, TargetingService.Int32_1);
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x0000BE21 File Offset: 0x0000A021
	public void imethod_10(float float_0)
	{
		this.m_characterController.height = float_0;
		this.m_characterController.center = new Vector3(0f, float_0 * 0.5f, 0f);
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1(bool bool_0)
	{
	}

	// Token: 0x04000B0D RID: 2829
	public BadAssCharacterMotorMovement movement = new BadAssCharacterMotorMovement();

	// Token: 0x04000B0E RID: 2830
	public BadAssCharacterMotor.CharacterMotorJumping jumping = new BadAssCharacterMotor.CharacterMotorJumping();

	// Token: 0x04000B0F RID: 2831
	private bool m_inputJump;

	// Token: 0x04000B10 RID: 2832
	private Vector3 m_desiredVelocity = Vector3.zero;

	// Token: 0x04000B11 RID: 2833
	private bool m_isGrounded = true;

	// Token: 0x04000B12 RID: 2834
	private Vector3 m_groundNormal = Vector3.zero;

	// Token: 0x04000B13 RID: 2835
	private Vector3 m_lastGroundNormal = Vector3.zero;

	// Token: 0x04000B14 RID: 2836
	private Transform m_characterTransform;

	// Token: 0x04000B15 RID: 2837
	private CharacterController m_characterController;

	// Token: 0x04000B16 RID: 2838
	private EntityPlayer m_entityPlayer;

	// Token: 0x04000B17 RID: 2839
	private BHVTaskManager m_taskManager;

	// Token: 0x04000B18 RID: 2840
	private float m_gravityAcceleration;

	// Token: 0x04000B19 RID: 2841
	private float m_deltaTime;

	// Token: 0x02000258 RID: 600
	public enum MovementTransferOnJump
	{
		// Token: 0x04000B1B RID: 2843
		None,
		// Token: 0x04000B1C RID: 2844
		InitTransfer,
		// Token: 0x04000B1D RID: 2845
		PermaTransfer,
		// Token: 0x04000B1E RID: 2846
		PermaLocked
	}

	// Token: 0x02000259 RID: 601
	[Serializable]
	public class CharacterMotorJumping
	{
		// Token: 0x04000B1F RID: 2847
		public bool enabled = true;

		// Token: 0x04000B20 RID: 2848
		public float baseHeight = 1f;

		// Token: 0x04000B21 RID: 2849
		public float extraHeight = 0.6f;

		// Token: 0x04000B22 RID: 2850
		public float perpAmount = 1f;

		// Token: 0x04000B23 RID: 2851
		public float steepPerpAmount = 0.5f;

		// Token: 0x04000B24 RID: 2852
		[NonSerialized]
		public bool jumping;

		// Token: 0x04000B25 RID: 2853
		[NonSerialized]
		public bool holdingJumpButton;

		// Token: 0x04000B26 RID: 2854
		[NonSerialized]
		public float lastStartTime;

		// Token: 0x04000B27 RID: 2855
		[NonSerialized]
		public float lastButtonDownTime = -100f;

		// Token: 0x04000B28 RID: 2856
		[NonSerialized]
		public Vector3 jumpDir = Vector3.up;
	}
}
