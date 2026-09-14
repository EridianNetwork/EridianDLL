using System;
using BHV;
using Core;
using UnityEngine;

// Token: 0x0200008C RID: 140
public class TurretAnimationEventController : AnimationEventController
{
	// Token: 0x060002F6 RID: 758 RVA: 0x00004C36 File Offset: 0x00002E36
	private void Start()
	{
		this.m_weaponInitPending = true;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x000437C0 File Offset: 0x000419C0
	public bool method_11()
	{
		if (base.gameObject.transform.parent == null)
		{
			return false;
		}
		this.m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
		if (this.m_entityNpc == null)
		{
			return false;
		}
		if (this.m_entityNpc.vmethod_10() == null)
		{
			return false;
		}
		this.m_entityNpcWeapon = this.m_entityNpc.vmethod_10().m_weapon;
		if (this.m_entityNpcWeapon == null)
		{
			return false;
		}
		SkinnedMeshRenderer componentInChildren = this.m_entityNpcWeapon.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			componentInChildren.enabled = false;
		}
		this.m_weaponAnimator = this.m_entityNpcWeapon.GetComponentInChildren<Animator>();
		if (this.m_weaponAnimator != null)
		{
			this.m_weaponAnimator.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
			this.m_weaponAnimator.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
		}
		foreach (Transform transform in base.gameObject.GetComponentsInChildren<Transform>(true))
		{
			if (this.m_pitchFulcrum != null && this.m_yawFulcrum != null && this.m_missleLeft != null && this.m_missleRight != null)
			{
				break;
			}
			if (transform.name == "Export_Gun_Lower")
			{
				this.m_yawFulcrum = transform;
				this.m_pitchFulcrum = transform;
			}
			if (!(transform.name == "Missle_Launch_L") && !(transform.name == "Export_MissleL"))
			{
				if (transform.name == "Missle_Launch_R" || transform.name == "Export_MissleR")
				{
					this.m_missleRight = transform;
				}
			}
			else
			{
				this.m_missleLeft = transform;
			}
		}
		return true;
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x00004C3F File Offset: 0x00002E3F
	private void Update()
	{
		if (this.m_weaponInitPending)
		{
			this.m_weaponInitPending = !this.method_11();
		}
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x00004C58 File Offset: 0x00002E58
	private void LateUpdate()
	{
		this.method_12();
	}

	// Token: 0x060002FA RID: 762 RVA: 0x00004C60 File Offset: 0x00002E60
	[ContextMenu("Start Shoot")]
	public void OnShootStart()
	{
		if (this.m_entityNpcWeapon != null)
		{
			this.m_entityNpcWeapon.method_79();
			return;
		}
	}

	// Token: 0x060002FB RID: 763 RVA: 0x000439B0 File Offset: 0x00041BB0
	private void method_12()
	{
		if (!base.method_4())
		{
			DebugUtils.Log(LogCategory.Gamelogic, "[TURRETAIM] method_4()=false (no target set)");
			return;
		}
		if (this.m_entityNpcWeapon == null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "[TURRETAIM] m_entityNpcWeapon=null, m_pitchFulcrum=" + (this.m_pitchFulcrum != null).ToString());
			return;
		}
		if (this.m_pitchFulcrum == null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "[TURRETAIM] m_pitchFulcrum=null");
			return;
		}
		Vector3 vector = this.m_targetPosition;
		if (!this.m_hasValidTargetPosition && this.m_targetObject != null)
		{
			vector = this.m_targetObject.transform.position;
			Entity component = this.m_targetObject.GetComponent<Entity>();
			if (component != null)
			{
				vector += new Vector3(0f, component.m_entityHeight / 2f, 0f);
			}
		}
		Vector3 normalized = (vector - this.m_entityNpcWeapon.transform.position).normalized;
		Vector3 normalized2 = base.transform.forward.normalized;
		global::Debug.smethod_4(this.m_entityNpcWeapon.transform.position, vector, Color.red);
		global::Debug.smethod_4(this.m_entityNpcWeapon.transform.position, this.m_entityNpcWeapon.transform.position + normalized2, Color.blue);
		float num = BHVTaskUtils.smethod_8(normalized2, normalized);
		float num2 = BHVTaskUtils.smethod_7(-this.m_entityNpcWeapon.transform.right, normalized);
		num2 = Mathf.Clamp(num2, -80f, 40f);
		this.m_yawAnglePrevious = Mathf.Lerp(this.m_yawAnglePrevious, num, 0.3f);
		if (Mathf.Abs(this.m_pitchAnglePrevious - num2) > this.m_pitchAngleThreshold)
		{
			this.m_pitchAnglePrevious = Mathf.Lerp(this.m_pitchAnglePrevious, num2, 0.1f);
		}
		else
		{
			this.m_pitchAnglePrevious = Mathf.Lerp(this.m_pitchAnglePrevious, num2, 0.01f);
		}
		DebugUtils.Log(LogCategory.Gamelogic, "[TURRETAIM] rotating: yaw=" + this.m_yawAnglePrevious.ToString() + " pitch=" + this.m_pitchAnglePrevious.ToString());
		this.m_pitchFulcrum.localRotation = Quaternion.Euler(0f, this.m_yawAnglePrevious, this.m_pitchAnglePrevious);
	}

	// Token: 0x040002CD RID: 717
	private bool m_weaponInitPending;

	// Token: 0x040002CE RID: 718
	private Animator m_weaponAnimator;

	// Token: 0x040002CF RID: 719
	public Transform m_yawFulcrum;

	// Token: 0x040002D0 RID: 720
	public Transform m_pitchFulcrum;

	// Token: 0x040002D1 RID: 721
	public Transform m_missleLeft;

	// Token: 0x040002D2 RID: 722
	public Transform m_missleRight;

	// Token: 0x040002D3 RID: 723
	[SerializeField]
	private float m_yawAnglePrevious;

	// Token: 0x040002D4 RID: 724
	[SerializeField]
	private float m_pitchAnglePrevious;

	// Token: 0x040002D5 RID: 725
	private float m_pitchAngleThreshold = 50f;
}
