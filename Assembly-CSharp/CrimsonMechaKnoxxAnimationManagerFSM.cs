using System;
using UnityEngine;

// Token: 0x0200002B RID: 43
public class CrimsonMechaKnoxxAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x0600011C RID: 284 RVA: 0x0003AC68 File Offset: 0x00038E68
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = false;
		this.m_deathLayer = 1;
		this.m_bCanMoveTurn = true;
		AnimationSpacingState animationSpacingState = base.method_16("Spacing") as AnimationSpacingState;
		if (animationSpacingState != null)
		{
			animationSpacingState.m_normalizeTurnAngle = true;
		}
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		this.m_animEventHandlerList.Add("RightLaserSweepStart", new AnimationManagerFSM.OnAnimEventHandler(this.method_31));
		this.m_animEventHandlerList.Add("RightLaserSweepEnd", new AnimationManagerFSM.OnAnimEventHandler(this.method_32));
		this.m_animEventHandlerList.Add("LeftLaserSweepStart", new AnimationManagerFSM.OnAnimEventHandler(this.method_33));
		this.m_animEventHandlerList.Add("LeftLaserSweepEnd", new AnimationManagerFSM.OnAnimEventHandler(this.method_34));
		this.m_bShowRightLaser = false;
		this.m_bShowLeftLaser = false;
		this.m_bLaserSweepStart = false;
		this.m_laserRender = this.m_entity.GetComponent<LineRenderer>();
	}

	// Token: 0x0600011D RID: 285 RVA: 0x00003966 File Offset: 0x00001B66
	public override void Update()
	{
		base.Update();
		this.method_35();
	}

	// Token: 0x0600011E RID: 286 RVA: 0x0003AD6C File Offset: 0x00038F6C
	public void method_31()
	{
		if (!this.m_bLaserSweepStart)
		{
			return;
		}
		this.m_bShowRightLaser = true;
		this.m_vLaserDir = -this.m_entity.transform.right;
		this.m_vLaserDir_Pre = this.m_vLaserDir;
		this.m_laserTransform = (this.m_entity as EntityNpc).m_rightHandWeaponSlot;
		this.m_VFXManager.method_5(ENPCParticleType.E_KnoxxLaserGuns, this.m_entity, this.m_laserTransform, this.m_vZero, this.m_rotIdentity, 2f, true);
	}

	// Token: 0x0600011F RID: 287 RVA: 0x0003ADF4 File Offset: 0x00038FF4
	public void method_32()
	{
		this.m_bShowRightLaser = false;
		if (this.m_laserTransform != null)
		{
			this.m_laserRender.SetPosition(0, this.m_laserTransform.position);
			this.m_laserRender.SetPosition(1, this.m_laserTransform.position);
		}
	}

	// Token: 0x06000120 RID: 288 RVA: 0x0003AE44 File Offset: 0x00039044
	public void method_33()
	{
		if (!this.m_bLaserSweepStart)
		{
			return;
		}
		this.m_bShowLeftLaser = true;
		this.m_vLaserDir = this.m_entity.transform.right;
		this.m_vLaserDir_Pre = this.m_vLaserDir;
		this.m_laserTransform = (this.m_entity as EntityNpc).m_leftHandWeaponSlot;
		this.m_VFXManager.method_5(ENPCParticleType.E_KnoxxLaserGuns, this.m_entity, this.m_laserTransform, this.m_vZero, this.m_rotIdentity, 2f, true);
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0003AEC8 File Offset: 0x000390C8
	public void method_34()
	{
		this.m_bShowLeftLaser = false;
		if (this.m_laserTransform != null)
		{
			this.m_laserRender.SetPosition(0, this.m_laserTransform.position);
			this.m_laserRender.SetPosition(1, this.m_laserTransform.position);
		}
	}

	// Token: 0x06000122 RID: 290 RVA: 0x0003AF18 File Offset: 0x00039118
	public void method_35()
	{
		if (!this.m_bLaserSweepStart || this.m_laserRender == null || this.m_laserTransform == null)
		{
			return;
		}
		if (!this.m_bShowLeftLaser && !this.m_bShowRightLaser)
		{
			this.m_laserRender.SetPosition(0, this.m_laserTransform.position);
			this.m_laserRender.SetPosition(1, this.m_laserTransform.position);
			this.m_laserTransform = null;
			return;
		}
		this.m_vLaserDir_Pre = this.m_vLaserDir;
		this.m_laserRender.SetPosition(0, this.m_laserTransform.position);
		if (this.m_bShowRightLaser)
		{
			this.m_vLaserDir = Quaternion.Euler(0f, this.m_sweepSpeed * Time.deltaTime, 0f) * this.m_vLaserDir;
		}
		else
		{
			this.m_vLaserDir = Quaternion.Euler(0f, -this.m_sweepSpeed * Time.deltaTime, 0f) * this.m_vLaserDir;
		}
		this.m_vLaserDir.y = 0f;
		this.m_laserRender.SetPosition(1, this.m_laserTransform.position + this.m_vLaserDir * 100f);
	}

	// Token: 0x04000128 RID: 296
	public LineRenderer m_laserRender;

	// Token: 0x04000129 RID: 297
	public Transform m_laserTransform;

	// Token: 0x0400012A RID: 298
	public bool m_bShowRightLaser;

	// Token: 0x0400012B RID: 299
	public bool m_bShowLeftLaser;

	// Token: 0x0400012C RID: 300
	public bool m_bLaserSweepStart;

	// Token: 0x0400012D RID: 301
	public float m_sweepSpeed = 180f;

	// Token: 0x0400012E RID: 302
	public Vector3 m_vLaserDir;

	// Token: 0x0400012F RID: 303
	public Vector3 m_vLaserDir_Pre;

	// Token: 0x04000130 RID: 304
	private Quaternion m_rotIdentity = Quaternion.identity;
}
