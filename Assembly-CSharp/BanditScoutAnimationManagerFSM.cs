using System;
using BHV;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class BanditScoutAnimationManagerFSM : NPCAnimationManagerFSM, IDamageListener
{
	// Token: 0x060000E7 RID: 231 RVA: 0x00039DD4 File Offset: 0x00037FD4
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = true;
		this.m_canUseFacingLogic = true;
		this.m_bHide = false;
		this.m_bIsCasual = false;
		this.m_bShieldFull = false;
		this.m_hideCooldownTime = 5f;
		this.m_hideTime = 5f;
		this.m_lastAimingObject = null;
		this.m_lastAimingEntityPlayer = null;
		this.m_laserRender = this.m_entity.GetComponent<LineRenderer>();
		if (this.m_entity != null)
		{
			this.m_enetiyRenders = this.m_entity.gameObject.GetComponentsInChildren<Renderer>();
		}
		if (this.m_weapon != null)
		{
			this.m_enetiyWeaponRenders = this.m_weapon.gameObject.GetComponentsInChildren<Renderer>();
		}
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
		}
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		if (DamageManager.DamageManager_0)
		{
			DamageManager.DamageManager_0.method_3(this);
		}
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00003850 File Offset: 0x00001A50
	public override void Update()
	{
		base.Update();
		this.method_32();
		this.method_31();
		this.method_35();
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x0000386A File Offset: 0x00001A6A
	public override void LateUpdate()
	{
		base.LateUpdate();
		this.method_33();
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00039AB0 File Offset: 0x00037CB0
	public void method_31()
	{
		if (base.Animator_0 != null && base.Animator_0.GetInteger("StanceMode") != 0 && (base.method_13(AnimationStateFSM.Alert) || base.method_13(AnimationStateFSM.Warning) || base.method_13(AnimationStateFSM.MeleeAttack) || base.method_13(AnimationStateFSM.Move) || base.method_13(AnimationStateFSM.Die)))
		{
			base.Animator_0.SetInteger("StanceMode", 0);
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00039EEC File Offset: 0x000380EC
	public void method_32()
	{
		if (this.m_animationEventController == null)
		{
			return;
		}
		if (!base.method_13(AnimationStateFSM.Fire) && !base.method_13(AnimationStateFSM.CoverFire) && (!base.method_13(AnimationStateFSM.Idle) || base.BHVStressLevel_0 != BHVStressLevel.COMBAT || !this.m_animationEventController.m_isAiming) && (!base.method_13(AnimationStateFSM.Move) || base.BHVStressLevel_0 != BHVStressLevel.COMBAT || base.Animator_0.GetFloat("fSprintMode") >= 0.5f) && !base.method_13(AnimationStateFSM.CoverIdleBeforeFire))
		{
			this.m_animationEventController.m_enableAimIK = false;
		}
		else
		{
			this.m_animationEventController.m_enableAimIK = true;
		}
		if (!base.method_13(AnimationStateFSM.Fire) && !base.method_13(AnimationStateFSM.CoverFire))
		{
			this.m_animationEventController.m_enableSniperAim = false;
		}
		else
		{
			this.m_animationEventController.m_enableSniperAim = true;
		}
	}

	// Token: 0x060000EC RID: 236 RVA: 0x000037E4 File Offset: 0x000019E4
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 4;
		}
		return 0;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00039FB8 File Offset: 0x000381B8
	private void method_33()
	{
		if (this.m_laserTransform == null)
		{
			AIInventory aiinventory = this.m_entity.vmethod_10();
			if (aiinventory == null)
			{
				return;
			}
			this.m_weapon = aiinventory.m_weapon;
			if (this.m_weapon == null)
			{
				if (this.m_laserRender != null)
				{
					this.m_laserRender.SetPosition(0, this.m_vZero);
					this.m_laserRender.SetPosition(1, this.m_vZero);
				}
				return;
			}
			this.m_laserTransform = aiinventory.m_weapon.method_46();
			if (this.m_laserTransform == null)
			{
				return;
			}
		}
		this.m_laserRender.SetPosition(0, this.m_laserTransform.position);
		Vector3 vector = this.m_laserTransform.position;
		GameObject gameObject = null;
		if (this.m_animationEventController != null && base.Animator_0 != null && !base.Animator_0.GetBool("IsCasual"))
		{
			gameObject = this.m_animationEventController.method_10();
			if (gameObject != null)
			{
				Entity component = gameObject.GetComponent<Entity>();
				if (component != null)
				{
					int num = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
					Vector3 position = component.vmethod_17().method_7().position;
					Vector3 vector2 = position - this.m_laserTransform.position;
					vector2.Normalize();
					if (Vector3.Dot(vector2, this.m_weapon.transform.forward) > 0.5f && (gameObject.transform.position - this.m_laserTransform.position).sqrMagnitude > 9f)
					{
						RaycastHit raycastHit;
						if (Physics.Raycast(this.m_laserTransform.position, vector2, out raycastHit, float.PositiveInfinity, num))
						{
							vector = raycastHit.point;
							vector += vector2 * 2f;
						}
						else
						{
							float num2 = (gameObject.transform.position - this.m_laserTransform.position).magnitude + 0.25f;
							vector = this.m_laserTransform.position + vector2 * num2;
						}
					}
				}
			}
		}
		this.m_laserRender.SetPosition(1, vector);
		if (gameObject != null)
		{
			if (this.m_lastAimingObject != gameObject)
			{
				this.method_34(gameObject, true);
				if (this.m_lastAimingObject != null)
				{
					this.method_34(this.m_lastAimingObject, false);
				}
			}
			else if (this.m_lastAimingEntityPlayer != null && this.m_lastAimingEntityPlayer.vmethod_40() <= 0)
			{
				this.method_34(this.m_lastAimingObject, false);
			}
		}
		else
		{
			this.method_34(this.m_lastAimingObject, false);
		}
		this.m_lastAimingObject = gameObject;
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0003A278 File Offset: 0x00038478
	private void method_34(GameObject gameObject_0, bool bool_0)
	{
		if (gameObject_0 != null)
		{
			EntityPlayer component = gameObject_0.GetComponent<EntityPlayer>();
			if (component != null && ((bool_0 && component.vmethod_40() > 0) || !bool_0))
			{
				component.method_132(bool_0);
				this.m_lastAimingEntityPlayer = ((!bool_0) ? null : component);
			}
		}
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0003A2C4 File Offset: 0x000384C4
	private void method_35()
	{
		if (this.m_bHide)
		{
			this.m_hideTime -= Time.deltaTime;
			if (this.m_hideTime < 0f)
			{
				this.vmethod_17(false);
			}
		}
		else if (this.m_hideCooldownTime > 0f)
		{
			this.m_hideCooldownTime -= Time.deltaTime;
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0003A320 File Offset: 0x00038520
	protected virtual void vmethod_16(bool bool_0)
	{
		if (this.m_enetiyRenders == null)
		{
			this.m_enetiyRenders = this.m_entity.gameObject.GetComponentsInChildren<Renderer>();
		}
		int num = this.m_enetiyRenders.Length;
		for (int i = 0; i < num; i++)
		{
			Renderer renderer = this.m_enetiyRenders[i];
			if (renderer as LineRenderer == null)
			{
				renderer.enabled = !bool_0;
			}
		}
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_17(bool bool_0)
	{
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x000398CC File Offset: 0x00037ACC
	public void OnStartShoot()
	{
		if (this.m_entity == null)
		{
			return;
		}
		EntityWeapon weapon = this.m_entity.vmethod_10().m_weapon;
		if (weapon != null)
		{
			weapon.method_79();
		}
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0003A384 File Offset: 0x00038584
	public void OnDamaged(DamageContext context)
	{
		if (base.method_13(AnimationStateFSM.Dead) || base.method_13(AnimationStateFSM.Die))
		{
			return;
		}
		if (!(context.m_victim == null) && !(context.m_victim.gameObject == null))
		{
			if (!this.m_bHide && context.m_victim.gameObject == base.gameObject)
			{
				this.vmethod_17(true);
			}
			return;
		}
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0003A3F0 File Offset: 0x000385F0
	public void OnEntityKill(KillContext context)
	{
		if (base.method_13(AnimationStateFSM.Dead) || base.method_13(AnimationStateFSM.Die))
		{
			return;
		}
		if (!(context.m_victim == null) && !(context.m_victim.gameObject == null))
		{
			if (this.m_bHide && context.m_victim.gameObject == base.gameObject)
			{
				this.vmethod_17(false);
			}
			return;
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00003878 File Offset: 0x00001A78
	private void OnDestroy()
	{
		if (DamageManager.DamageManager_0)
		{
			DamageManager.DamageManager_0.method_4(this);
		}
	}

	// Token: 0x0400010F RID: 271
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x04000110 RID: 272
	protected Transform m_laserTransform;

	// Token: 0x04000111 RID: 273
	protected LineRenderer m_laserRender;

	// Token: 0x04000112 RID: 274
	protected EntityWeapon m_weapon;

	// Token: 0x04000113 RID: 275
	protected bool m_bHide;

	// Token: 0x04000114 RID: 276
	protected bool m_bIsCasual;

	// Token: 0x04000115 RID: 277
	protected bool m_bShieldFull;

	// Token: 0x04000116 RID: 278
	protected float m_hideCooldownTime = 5f;

	// Token: 0x04000117 RID: 279
	protected float m_hideTime = 5f;

	// Token: 0x04000118 RID: 280
	protected Renderer[] m_enetiyRenders;

	// Token: 0x04000119 RID: 281
	protected Renderer[] m_enetiyWeaponRenders;

	// Token: 0x0400011A RID: 282
	protected GameObject m_lastAimingObject;

	// Token: 0x0400011B RID: 283
	protected EntityPlayer m_lastAimingEntityPlayer;
}
