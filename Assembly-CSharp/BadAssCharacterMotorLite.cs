using System;
using BHV;
using Core;
using UnityEngine;

// Token: 0x0200025C RID: 604
[AddComponentMenu("Character/BadAss Character Motor Lite")]
[Serializable]
public class BadAssCharacterMotorLite : MonoBehaviour, IBadAssCharacterMotor
{
	// Token: 0x06000C5C RID: 3164 RVA: 0x0000BE8F File Offset: 0x0000A08F
	public BadAssCharacterMotorMovement imethod_8()
	{
		return this.movement;
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x0006A354 File Offset: 0x00068554
	protected void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(base.transform.position, this.m_desiredVelocity);
		Gizmos.color = Color.red;
		Gizmos.DrawRay(base.transform.position, this.m_groundNormal);
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x0006A3A4 File Offset: 0x000685A4
	private void Start()
	{
		this.m_entityPlayer = base.GetComponent<EntityPlayer>();
		this.m_taskManager = base.GetComponent<BHVTaskManager>();
		this.m_gravityAcceleration = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_gravityAcceleration;
		this.jumping.baseHeight = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_jumpHeight;
		this.m_characterTransform = base.transform;
		this.m_collider = base.GetComponent<CapsuleCollider>();
		this.m_initHeight = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_standHeight;
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x0000BE97 File Offset: 0x0000A097
	private float method_0()
	{
		return this.m_deltaTime;
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x0000BE9F File Offset: 0x0000A09F
	public void imethod_3(float float_0)
	{
		this.m_deltaTime = float_0;
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x0000BEA8 File Offset: 0x0000A0A8
	public void imethod_2(Vector3 vector3_0)
	{
		this.m_desiredVelocity = vector3_0;
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x0000BEB1 File Offset: 0x0000A0B1
	public void imethod_0(bool bool_0)
	{
		this.m_inputJump = bool_0;
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x0000BEBA File Offset: 0x0000A0BA
	public void imethod_1(bool bool_0)
	{
		this.m_knockingBack = bool_0;
	}

	// Token: 0x06000C64 RID: 3172 RVA: 0x0006A428 File Offset: 0x00068628
	private void Update()
	{
		this.m_frameMoveOffset += this.m_accumMovement;
		this.m_frameMoveOffset -= this.m_lastMovementOffset;
		Vector3 vector = this.m_lastMovementOffset * (Time.fixedDeltaTime - (this.m_TimeFragment + (float)this.m_frameUpdateCount * Time.fixedDeltaTime - Time.deltaTime)) / Time.fixedDeltaTime;
		this.m_frameMoveOffset += vector;
		this.movement.frameVelocity = this.m_frameMoveOffset / Time.deltaTime;
		this.m_frameMoveOffset = this.m_lastMovementOffset - vector;
		this.movement.frameOffset = this.m_frameMoveOffset;
		this.m_TimeFragment = Time.fixedTime - Time.time + Time.fixedDeltaTime;
		this.m_frameUpdateCount = 0;
		this.m_accumMovement = Vector3.zero;
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x0006A514 File Offset: 0x00068714
	public void imethod_4()
	{
		this.m_frameUpdateCount++;
		if (this.method_0() < 1E-45f)
		{
			return;
		}
		this.m_stepOver = this.m_collider.height * this.m_stepOverScale * (this.m_collider.height / this.m_initHeight);
		this.m_onLand = false;
		if (this.m_isGrounded && !this.method_8())
		{
			this.m_isGrounded = false;
		}
		if (!this.m_isGrounded && this.method_8())
		{
			PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
			component.OnLand();
			this.m_isGrounded = true;
			this.jumping.jumping = false;
			this.m_lastLandingTimeStamp = Time.fixedTime;
			this.m_onLand = true;
		}
		Vector3 vector = this.movement.velocity;
		Vector3 vector2 = vector;
		vector2.x = 0f;
		vector2.z = 0f;
		vector2 = this.method_3(vector2);
		vector = this.method_2(vector, vector2);
		if (this.m_entityPlayer.PlayerSkillManage_0 != null)
		{
			vector = this.m_entityPlayer.PlayerSkillManage_0.vmethod_5(vector);
		}
		Vector3 vector3 = vector * this.method_0();
		global::Debug.smethod_7(this.m_characterTransform.position, vector3);
		float num = 0f;
		if (this.m_isGrounded)
		{
			float num2 = 2f * this.m_stepOver;
			RaycastHit raycastHit = default(RaycastHit);
			Ray ray = new Ray(this.m_characterTransform.position + new Vector3(vector3.x, vector3.y + this.m_stepOver, vector3.z), Vector3.down);
			Vector3 vector4 = Vector3.zero;
			if (Physics.Raycast(ray, out raycastHit, num2, TargetingService.Int32_1))
			{
				vector4 = raycastHit.normal;
				if (vector4.y < 0f)
				{
					DebugUtils.LogError(LogCategory.Gamelogic, "invalid ground normal at:" + raycastHit.point);
				}
				if (raycastHit.distance < this.m_stepOver - this.m_skin)
				{
					num = this.m_stepOver - raycastHit.distance - this.m_skin;
				}
				else if (raycastHit.distance > this.m_stepOver + this.m_skin)
				{
					num = this.m_stepOver - raycastHit.distance + this.m_skin;
				}
			}
			if (this.method_11(vector4))
			{
				num = 0f;
				this.m_groundNormal = this.movement.lastHitNormal;
			}
			else
			{
				this.m_groundNormal = vector4;
			}
		}
		else if (!this.jumping.jumping || Time.fixedTime >= this.jumping.lastStartTime + this.jumping.extraHeight / this.method_10(this.jumping.baseHeight))
		{
			float num3 = 2f * this.m_skin;
			RaycastHit raycastHit2 = default(RaycastHit);
			Ray ray2 = new Ray(this.m_characterTransform.position + new Vector3(vector3.x, vector3.y + this.m_skin, vector3.z), Vector3.down);
			Vector3 vector5 = Vector3.zero;
			if (Physics.Raycast(ray2, out raycastHit2, num3, TargetingService.Int32_1))
			{
				vector5 = raycastHit2.normal;
				if (vector5.y < 0f)
				{
					DebugUtils.LogError(LogCategory.Gamelogic, "invalid ground normal at:" + raycastHit2.point);
				}
			}
			if (this.method_11(vector5))
			{
				this.m_groundNormal = this.movement.lastHitNormal;
			}
			else
			{
				this.m_groundNormal = vector5;
			}
		}
		if (this.method_11(this.m_groundNormal))
		{
			this.m_groundNormal = Vector3.zero;
		}
		vector3 += new Vector3(0f, num, 0f);
		if (!vector3.magnitude.AlmostEquals(0f, 1E-45f))
		{
			this.m_characterTransform.position += vector3;
		}
		this.m_accumMovement += vector3;
		this.m_lastMovementOffset = vector3;
		this.movement.collisionFlags = CollisionFlags.None;
		if (!this.m_onLand)
		{
			this.m_groundLiftVel = new Vector3(0f, num / this.method_0(), 0f);
		}
		this.movement.velocity = vector;
	}

	// Token: 0x06000C66 RID: 3174 RVA: 0x0006A94C File Offset: 0x00068B4C
	private Vector3 method_1(Vector3 vector3_0)
	{
		Vector3 vector = vector3_0;
		Vector3 vector2 = this.m_characterTransform.position + this.m_collider.center + Vector3.up * (-this.m_collider.height * 0.5f + this.m_collider.radius + this.m_stepOver);
		Vector3 vector3 = this.m_characterTransform.position + this.m_collider.center + Vector3.up * (-this.m_collider.height * 0.5f + this.m_collider.radius + this.m_skin);
		Vector3 vector4 = this.m_characterTransform.position + this.m_collider.center + Vector3.up * (this.m_collider.height * 0.5f - this.m_collider.radius + 0.2f);
		if (this.m_isGrounded)
		{
			this.m_airCapsuleSize = false;
		}
		if (!this.m_isGrounded && (this.m_airCapsuleSize || !this.method_12(vector3, vector4)))
		{
			this.m_airCapsuleSize = true;
			vector2 = vector3;
		}
		float num = float.MaxValue;
		if ((double)vector3_0.magnitude > 0.001)
		{
			RaycastHit raycastHit;
			if (Physics.CapsuleCast(vector2, vector4, this.m_collider.radius + 0.01f, vector3_0.normalized, out raycastHit, vector3_0.magnitude, TargetingService.Int32_1))
			{
				float num2 = Vector3.Angle(raycastHit.normal, Vector3.up);
				if (num2 < num)
				{
					this.movement.lastHitNormal = raycastHit.normal;
					this.movement.lastHitPoint = raycastHit.point;
					num = num2;
				}
				float num3 = raycastHit.distance;
				float num4 = num3 - this.m_skin;
				if (num4 < 0f)
				{
					num4 = 0f;
				}
				float num5 = this.m_skin - num3;
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				Vector3 normal = raycastHit.normal;
				Vector3 vector5 = vector3_0.normalized * num4;
				Vector3 vector6 = vector3_0 - vector5;
				float num6 = vector6.y;
				float num7 = vector6.magnitude;
				num7 -= this.m_skin;
				if (num7 < 0f)
				{
					num7 = 0f;
				}
				vector6 = vector6.normalized * num7;
				if (!this.m_isGrounded)
				{
					vector6 += num5 * normal;
				}
				vector6.y = num6;
				vector6.x *= 0.8f;
				vector6.z *= 0.8f;
				global::Debug.smethod_9(raycastHit.point, normal, Color.blue, 1f);
				Vector3 vector7 = -1f * Vector3.Dot(vector6, normal) * normal;
				vector3_0 = vector6 + vector7;
				global::Debug.smethod_8(this.m_characterTransform.position, vector3_0, Color.yellow);
				if (this.m_isGrounded)
				{
					Vector3 vector8 = this.method_7(this.m_groundNormal, normal);
					vector3_0 -= Vector3.Dot(vector6, vector8.normalized) * vector8.normalized;
				}
				if ((double)vector3_0.magnitude > 0.001)
				{
					global::Debug.smethod_9(vector2, vector5, Color.gray, 1f);
					global::Debug.smethod_9(vector4, vector5, Color.gray, 1f);
					vector2 += vector5;
					vector4 += vector5;
					if (Physics.CapsuleCast(vector2, vector4, this.m_collider.radius + 0.01f, vector3_0, out raycastHit, vector3_0.magnitude, TargetingService.Int32_1))
					{
						num2 = Vector3.Angle(raycastHit.normal, Vector3.up);
						if (num2 < num)
						{
							this.movement.lastHitNormal = raycastHit.normal;
							this.movement.lastHitPoint = raycastHit.point;
							num = num2;
						}
						num3 = raycastHit.distance;
						num3 -= this.m_skin;
						if (num3 < 0f)
						{
							num3 = 0f;
						}
						Vector3 vector9 = vector3_0.normalized * num3;
						Vector3 normal2 = raycastHit.normal;
						global::Debug.smethod_9(raycastHit.point, normal2, Color.red, 1f);
						if (this.m_isGrounded)
						{
							if (Vector3.Dot(normal, normal2) <= 0f)
							{
								global::Debug.smethod_8(raycastHit.point, normal, Color.cyan);
								global::Debug.smethod_8(raycastHit.point, normal2, Color.magenta);
								vector = vector5 + vector9;
							}
							else
							{
								vector6 = vector3_0 - vector9;
								num6 = vector6.y;
								num7 = vector6.magnitude;
								num7 -= this.m_skin;
								if (num7 < 0f)
								{
									num7 = 0f;
								}
								vector6 = vector6.normalized * num7;
								vector6.y = num6;
								vector6.x *= 0.8f;
								vector6.z *= 0.8f;
								Vector3 vector10 = -1f * Vector3.Dot(vector6, normal2) * normal2;
								Vector3 vector11 = vector6 + vector10;
								if (this.m_isGrounded)
								{
									Vector3 vector8 = this.method_7(this.m_groundNormal, normal2);
									vector11 -= Vector3.Dot(vector11, vector8.normalized) * vector8.normalized;
								}
								global::Debug.smethod_9(raycastHit.point, normal, Color.cyan, 10f);
								global::Debug.smethod_9(raycastHit.point, normal2, Color.magenta, 10f);
								vector = vector5 + vector9 + vector11;
							}
						}
						else
						{
							vector6 = vector3_0 - vector9;
							vector6.x *= 0.8f;
							vector6.z *= 0.8f;
							Vector3 vector12 = -1f * Vector3.Dot(vector6, normal2) * normal2;
							vector3_0 = vector6 + vector12;
							Vector3 vector8 = this.method_7(normal, normal2);
							vector3_0 -= Vector3.Dot(vector3_0, vector8.normalized) * vector8.normalized;
							vector = vector5 + vector9 + vector3_0;
							if ((double)vector3_0.magnitude > 0.001)
							{
								vector2 += vector9;
								vector4 += vector9;
								if (Physics.CapsuleCast(vector2, vector4, this.m_collider.radius + 0.01f, vector3_0, out raycastHit, vector3_0.magnitude, TargetingService.Int32_1))
								{
									global::Debug.smethod_9(raycastHit.point, raycastHit.normal, Color.green, 1f);
									num2 = Vector3.Angle(raycastHit.normal, Vector3.up);
									if (num2 < num)
									{
										this.movement.lastHitNormal = raycastHit.normal;
										this.movement.lastHitPoint = raycastHit.point;
									}
									num3 = raycastHit.distance;
									num3 -= this.m_skin;
									if (num3 < 0f)
									{
										num3 = 0f;
									}
									Vector3 vector13 = vector3_0.normalized * num3;
									vector = vector5 + vector9 + vector13;
								}
							}
							else
							{
								vector3_0 = Vector3.zero;
							}
						}
					}
					else
					{
						vector = vector5 + vector3_0;
						global::Debug.smethod_9(this.m_characterTransform.position, vector5 + vector3_0, Color.white, 10f);
					}
				}
				else
				{
					vector = vector5;
				}
			}
			else
			{
				this.movement.lastHitNormal = Vector3.zero;
				this.movement.lastHitPoint = Vector3.zero;
			}
		}
		else
		{
			vector = Vector3.zero;
		}
		return vector;
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x0006B0F0 File Offset: 0x000692F0
	private Vector3 method_2(Vector3 vector3_0, Vector3 vector3_1)
	{
		Vector3 vector = this.method_4();
		if (this.m_isGrounded)
		{
			vector = this.method_6(vector, this.m_groundNormal);
			if (this.m_groundLiftVel.y > 0f)
			{
				this.m_groundLiftVel.y = this.m_groundLiftVel.y - this.m_gravityAcceleration * this.method_0();
				if (this.m_groundLiftVel.y < 0f)
				{
					this.m_groundLiftVel.y = 0f;
				}
			}
			if (this.m_groundLiftVel.y < 0f)
			{
				this.m_groundLiftVel.y = this.m_groundLiftVel.y + this.m_gravityAcceleration * this.method_0();
				if (this.m_groundLiftVel.y > 0f)
				{
					this.m_groundLiftVel.y = 0f;
				}
			}
			vector += this.m_groundLiftVel;
		}
		else
		{
			vector.y = 0f;
			vector = vector3_0 + vector * 0.05f;
			vector.y = 0f;
		}
		Vector3 vector2 = vector3_0;
		vector2.y = 0f;
		float num = this.method_9(this.m_isGrounded);
		Vector3 vector3 = vector - vector2;
		if (vector3.sqrMagnitude > num * num)
		{
			vector3 = vector3.normalized * num;
			vector = vector3 + vector2;
		}
		if (vector3_1.y != 0f)
		{
			vector.y = vector3_1.y;
		}
		Vector3 vector4 = vector * this.method_0();
		vector4 = this.method_1(vector4);
		vector = vector4 / this.method_0();
		vector3_0 = vector;
		return vector3_0;
	}

	// Token: 0x06000C68 RID: 3176 RVA: 0x0006B294 File Offset: 0x00069494
	private Vector3 method_3(Vector3 vector3_0)
	{
		if (!this.m_inputJump)
		{
			this.jumping.holdingJumpButton = false;
			this.jumping.lastButtonDownTime = -100f;
		}
		else if (this.jumping.lastButtonDownTime < 0f)
		{
			this.jumping.lastButtonDownTime = Time.fixedTime;
		}
		if (this.m_isGrounded)
		{
			vector3_0.y = 0f;
		}
		else
		{
			vector3_0.y -= this.m_gravityAcceleration * this.method_0();
			if (this.jumping.jumping && this.jumping.holdingJumpButton && Time.fixedTime < this.jumping.lastStartTime + this.jumping.extraHeight / this.method_10(this.jumping.baseHeight))
			{
				vector3_0 += this.jumping.jumpDir * this.m_gravityAcceleration * this.method_0();
			}
			vector3_0.y = Mathf.Max(vector3_0.y, -this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_velocityFallMax);
		}
		if (this.m_isGrounded && Time.fixedTime - this.m_lastLandingTimeStamp > this.m_JumpCoolDown)
		{
			if (this.jumping.enabled && Time.fixedTime - this.jumping.lastButtonDownTime < 0.2f)
			{
				this.m_isGrounded = false;
				this.m_groundNormal = Vector3.zero;
				this.jumping.jumping = true;
				this.jumping.lastStartTime = Time.fixedTime;
				this.jumping.lastButtonDownTime = -100f;
				this.jumping.holdingJumpButton = true;
				this.jumping.jumpDir = Vector3.up;
				vector3_0.y = 0f;
				if (this.m_knockingBack)
				{
					vector3_0 += this.method_5();
				}
				else
				{
					vector3_0 += this.jumping.jumpDir * this.method_10(this.jumping.baseHeight);
				}
			}
			else
			{
				this.jumping.holdingJumpButton = false;
			}
		}
		return vector3_0;
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x0006B4C0 File Offset: 0x000696C0
	private Vector3 method_4()
	{
		Vector3 vector = new Vector3(this.m_desiredVelocity.x, 0f, this.m_desiredVelocity.z);
		return vector;
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x0006B4F0 File Offset: 0x000696F0
	private Vector3 method_5()
	{
		Vector3 vector = new Vector3(0f, this.m_desiredVelocity.y, 0f);
		return vector;
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x0006A0FC File Offset: 0x000682FC
	private Vector3 method_6(Vector3 vector3_0, Vector3 vector3_1)
	{
		Vector3 vector = Vector3.Cross(Vector3.up, vector3_0);
		return Vector3.Cross(vector, vector3_1).normalized * vector3_0.magnitude;
	}

	// Token: 0x06000C6C RID: 3180 RVA: 0x0006B51C File Offset: 0x0006971C
	private Vector3 method_7(Vector3 vector3_0, Vector3 vector3_1)
	{
		Vector3 vector = Vector3.Cross(vector3_0, vector3_1);
		return Vector3.Cross(vector, vector3_1);
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x0000BEC3 File Offset: 0x0000A0C3
	private bool method_8()
	{
		return this.m_groundNormal.y > 0.01f;
	}

	// Token: 0x06000C6E RID: 3182 RVA: 0x0000BED7 File Offset: 0x0000A0D7
	private float method_9(bool bool_0)
	{
		if (bool_0)
		{
			return this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_velocityChangeGroundMax;
		}
		return this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_velocityChangeAirMax;
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x0000BEFD File Offset: 0x0000A0FD
	private float method_10(float float_0)
	{
		return Mathf.Sqrt(2f * float_0 * this.m_gravityAcceleration);
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x0000BF12 File Offset: 0x0000A112
	public bool imethod_7()
	{
		return this.m_ceil;
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x0000BF1A File Offset: 0x0000A11A
	private bool method_11(Vector3 vector3_0)
	{
		return vector3_0.y <= Mathf.Cos(this.m_slopeLimit * 0.017453292f);
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x0000BF39 File Offset: 0x0000A139
	public bool imethod_5()
	{
		return this.m_isGrounded;
	}

	// Token: 0x06000C73 RID: 3187 RVA: 0x0000BF41 File Offset: 0x0000A141
	public bool imethod_6()
	{
		return this.jumping.jumping;
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x0006B538 File Offset: 0x00069738
	public bool imethod_9(Vector3 vector3_0, Vector3 vector3_1, float float_0, out RaycastHit raycastHit_0)
	{
		Vector3 vector = vector3_0 + this.m_collider.center + Vector3.up * (-this.m_collider.height * 0.5f + this.m_collider.radius + this.m_stepOver);
		Vector3 vector2 = this.m_characterTransform.position + this.m_collider.center + Vector3.up * (this.m_collider.height * 0.5f - this.m_collider.radius + 0.2f);
		return Physics.CapsuleCast(vector, vector2, this.m_collider.radius, vector3_1.normalized, out raycastHit_0, float_0, TargetingService.Int32_1);
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x0006B5FC File Offset: 0x000697FC
	public bool imethod_11(Vector3 vector3_0, float float_0)
	{
		Vector3 vector = vector3_0 + new Vector3(0f, float_0 * 0.5f, 0f) + Vector3.up * (-float_0 * 0.5f + this.m_collider.radius + this.m_initHeight * this.m_stepOverScale);
		Vector3 vector2 = this.m_characterTransform.position + new Vector3(0f, float_0 * 0.5f, 0f) + Vector3.up * (float_0 * 0.5f - this.m_collider.radius + 0.2f);
		return !Physics.CheckCapsule(vector, vector2, this.m_collider.radius, TargetingService.Int32_1);
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x0000BF4E File Offset: 0x0000A14E
	private bool method_12(Vector3 vector3_0, Vector3 vector3_1)
	{
		return Physics.CheckCapsule(vector3_0, vector3_1, this.m_collider.radius, TargetingService.Int32_1);
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x0000BF67 File Offset: 0x0000A167
	public void imethod_10(float float_0)
	{
		this.m_collider.height = float_0;
		this.m_collider.center = new Vector3(0f, float_0 * 0.5f, 0f);
	}

	// Token: 0x04000B30 RID: 2864
	public BadAssCharacterMotorMovement movement = new BadAssCharacterMotorMovement();

	// Token: 0x04000B31 RID: 2865
	public BadAssCharacterMotorLite.CharacterMotorJumping jumping = new BadAssCharacterMotorLite.CharacterMotorJumping();

	// Token: 0x04000B32 RID: 2866
	private bool m_inputJump;

	// Token: 0x04000B33 RID: 2867
	private bool m_knockingBack;

	// Token: 0x04000B34 RID: 2868
	private Vector3 m_desiredVelocity = Vector3.zero;

	// Token: 0x04000B35 RID: 2869
	private bool m_isGrounded = true;

	// Token: 0x04000B36 RID: 2870
	private Vector3 m_groundNormal = Vector3.zero;

	// Token: 0x04000B37 RID: 2871
	private Transform m_characterTransform;

	// Token: 0x04000B38 RID: 2872
	private EntityPlayer m_entityPlayer;

	// Token: 0x04000B39 RID: 2873
	private BHVTaskManager m_taskManager;

	// Token: 0x04000B3A RID: 2874
	private float m_gravityAcceleration;

	// Token: 0x04000B3B RID: 2875
	private float m_deltaTime;

	// Token: 0x04000B3C RID: 2876
	private float m_slopeLimit = 45f;

	// Token: 0x04000B3D RID: 2877
	private CapsuleCollider m_collider;

	// Token: 0x04000B3E RID: 2878
	private GameObject m_grounded;

	// Token: 0x04000B3F RID: 2879
	public float m_stepOverScale = 0.27f;

	// Token: 0x04000B40 RID: 2880
	public float m_skin = 0.05f;

	// Token: 0x04000B41 RID: 2881
	private float m_stepOver;

	// Token: 0x04000B42 RID: 2882
	private float m_initHeight;

	// Token: 0x04000B43 RID: 2883
	private bool m_ceil;

	// Token: 0x04000B44 RID: 2884
	private float m_JumpCoolDown = 0.1f;

	// Token: 0x04000B45 RID: 2885
	private float m_lastLandingTimeStamp;

	// Token: 0x04000B46 RID: 2886
	private Vector3 m_frameMoveOffset;

	// Token: 0x04000B47 RID: 2887
	private Vector3 m_accumMovement;

	// Token: 0x04000B48 RID: 2888
	private float m_TimeFragment;

	// Token: 0x04000B49 RID: 2889
	private int m_frameUpdateCount;

	// Token: 0x04000B4A RID: 2890
	private Vector3 m_lastMovementOffset;

	// Token: 0x04000B4B RID: 2891
	private Vector3 m_groundLiftVel;

	// Token: 0x04000B4C RID: 2892
	private bool m_onLand;

	// Token: 0x04000B4D RID: 2893
	private bool m_airCapsuleSize;

	// Token: 0x0200025D RID: 605
	public enum MovementTransferOnJump
	{
		// Token: 0x04000B4F RID: 2895
		None,
		// Token: 0x04000B50 RID: 2896
		InitTransfer,
		// Token: 0x04000B51 RID: 2897
		PermaTransfer,
		// Token: 0x04000B52 RID: 2898
		PermaLocked
	}

	// Token: 0x0200025E RID: 606
	[Serializable]
	public class CharacterMotorJumping
	{
		// Token: 0x04000B53 RID: 2899
		public bool enabled = true;

		// Token: 0x04000B54 RID: 2900
		public float baseHeight = 1.4f;

		// Token: 0x04000B55 RID: 2901
		public float extraHeight = 1f;

		// Token: 0x04000B56 RID: 2902
		public float perpAmount = 1f;

		// Token: 0x04000B57 RID: 2903
		public float steepPerpAmount = 0.5f;

		// Token: 0x04000B58 RID: 2904
		[NonSerialized]
		public bool jumping;

		// Token: 0x04000B59 RID: 2905
		[NonSerialized]
		public bool holdingJumpButton;

		// Token: 0x04000B5A RID: 2906
		[NonSerialized]
		public float lastStartTime;

		// Token: 0x04000B5B RID: 2907
		[NonSerialized]
		public float lastButtonDownTime = -100f;

		// Token: 0x04000B5C RID: 2908
		[NonSerialized]
		public Vector3 jumpDir = Vector3.up;
	}
}
