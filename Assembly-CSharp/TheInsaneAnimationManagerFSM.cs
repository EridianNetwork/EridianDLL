using System;
using UnityEngine;

// Token: 0x02000037 RID: 55
public class TheInsaneAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x0600016D RID: 365 RVA: 0x0003C3BC File Offset: 0x0003A5BC
	public override void Start()
	{
		base.Start();
		if (this.m_eyePrefab != null)
		{
			if (this.m_backEye != null)
			{
				this.m_backEyeObj = (Transform)global::UnityEngine.Object.Instantiate(this.m_eyePrefab, this.m_backEye.position, this.m_backEye.rotation);
				if (this.m_backEyeObj != null)
				{
					this.m_backEyeObj.parent = this.m_backEye;
				}
			}
			if (this.m_frontLeftEye != null)
			{
				this.m_leftEyeObj = (Transform)global::UnityEngine.Object.Instantiate(this.m_eyePrefab, this.m_frontLeftEye.position, this.m_frontLeftEye.rotation);
				if (this.m_leftEyeObj != null)
				{
					this.m_leftEyeObj.parent = this.m_frontLeftEye;
				}
			}
			if (this.m_frontRightEye != null)
			{
				this.m_rightEyeObj = (Transform)global::UnityEngine.Object.Instantiate(this.m_eyePrefab, this.m_frontRightEye.position, this.m_frontRightEye.rotation);
				if (this.m_rightEyeObj != null)
				{
					this.m_rightEyeObj.parent = this.m_frontRightEye;
				}
			}
		}
		this.m_equipment = base.GetComponent<EquipmentInventoryEntityNpcBoss>();
		this.m_deathLayer = 1;
	}

	// Token: 0x0600016E RID: 366 RVA: 0x0003C500 File Offset: 0x0003A700
	public Transform method_31(bool bool_0)
	{
		Transform transform = ((!(this.m_backEyeObj != null)) ? this.m_rightEyeObj : this.m_backEyeObj);
		if (transform != null)
		{
			ParticleSystem componentInChildren = transform.GetComponentInChildren<ParticleSystem>();
			if (componentInChildren != null)
			{
				if (bool_0)
				{
					componentInChildren.Play();
					this.m_AudioCtl.vmethod_1(AudioEventName.Insane_Laser_Start);
					this.m_AudioCtl.vmethod_1(AudioEventName.Insane_Laser_Loop);
				}
				else
				{
					componentInChildren.Stop();
					this.m_AudioCtl.vmethod_2(AudioEventName.Insane_Laser_Loop);
					this.m_blendFromTransform = transform;
					this.m_blendToTransform = ((!(this.m_backEyeObj != null)) ? this.m_frontRightEye : this.m_backEye);
					this.m_bBlendEye = true;
				}
			}
		}
		return transform;
	}

	// Token: 0x0600016F RID: 367 RVA: 0x0003C5B0 File Offset: 0x0003A7B0
	public Transform method_32(bool bool_0)
	{
		Transform leftEyeObj = this.m_leftEyeObj;
		if (leftEyeObj != null)
		{
			ParticleSystem componentInChildren = leftEyeObj.GetComponentInChildren<ParticleSystem>();
			if (componentInChildren != null)
			{
				if (bool_0)
				{
					componentInChildren.Play();
					this.m_AudioCtl.TriggerEventByName("Insane_Laser_Start");
					this.m_AudioCtl.TriggerEventByName("Insane_Laser_Loop");
				}
				else
				{
					componentInChildren.Stop();
					this.m_AudioCtl.ReleaseEventByName("Insane_Laser_Loop");
					this.m_blendFromTransform = leftEyeObj;
					this.m_blendToTransform = this.m_frontLeftEye;
					this.m_bBlendEye = true;
				}
			}
		}
		return leftEyeObj;
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0003C63C File Offset: 0x0003A83C
	public override void Update()
	{
		base.Update();
		if (this.m_equipment != null && this.m_backEyeObj != null && this.m_equipment.method_7() == 2)
		{
			this.m_backEyeObj.gameObject.SetActive(false);
			this.m_backEyeObj = null;
			base.Animator_0.SetInteger("phase", 2);
			if (this.m_VFXManager != null)
			{
				this.m_VFXManager.method_5(ENPCParticleType.E_TheInsaneEyeDestroy, null, this.m_backEye, Vector3.zero, Quaternion.identity, -1f, true);
			}
		}
		if (this.m_bBlendEye && this.m_blendFromTransform != null && this.m_blendToTransform != null)
		{
			this.m_blendFromTransform.position = this.m_blendToTransform.position;
			float num = Vector3.Angle(this.m_blendFromTransform.forward, this.m_blendToTransform.forward);
			if (num > 5f)
			{
				this.m_blendFromTransform.forward = Vector3.Lerp(this.m_blendFromTransform.forward, this.m_blendToTransform.forward, Time.deltaTime);
			}
			else
			{
				this.m_blendFromTransform.parent = this.m_blendToTransform;
				this.m_blendFromTransform.position = this.m_blendToTransform.position;
				this.m_blendFromTransform.rotation = this.m_blendToTransform.rotation;
				this.m_blendFromTransform.localPosition = Vector3.zero;
				this.m_blendFromTransform.localRotation = Quaternion.identity;
				this.m_bBlendEye = false;
			}
		}
	}

	// Token: 0x04000150 RID: 336
	public Transform m_eyePrefab;

	// Token: 0x04000151 RID: 337
	public Transform m_backEye;

	// Token: 0x04000152 RID: 338
	public Transform m_frontLeftEye;

	// Token: 0x04000153 RID: 339
	public Transform m_frontRightEye;

	// Token: 0x04000154 RID: 340
	private Transform m_backEyeObj;

	// Token: 0x04000155 RID: 341
	private Transform m_rightEyeObj;

	// Token: 0x04000156 RID: 342
	private Transform m_leftEyeObj;

	// Token: 0x04000157 RID: 343
	private EquipmentInventoryEntityNpcBoss m_equipment;

	// Token: 0x04000158 RID: 344
	private bool m_bBlendEye;

	// Token: 0x04000159 RID: 345
	private Transform m_blendFromTransform;

	// Token: 0x0400015A RID: 346
	private Transform m_blendToTransform;
}
