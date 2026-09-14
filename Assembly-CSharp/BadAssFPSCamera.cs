using System;
using BHV;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200025F RID: 607
[RequireComponent(typeof(Camera))]
public class BadAssFPSCamera : MonoBehaviour
{
	// Token: 0x06000C7A RID: 3194 RVA: 0x0006B71C File Offset: 0x0006991C
	public void method_0(EntityPlayer entityPlayer_0, Transform transform_0)
	{
		this.m_entityPlayer = entityPlayer_0;
		this.m_Animator_1st = this.m_entityPlayer.GetComponent<PlayerAnimationManagerFSM>().m_firstPersonAnimator;
		base.transform.parent = transform_0;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.Euler(0f, 270f, 270f);
		this.m_taskManager = entityPlayer_0.vmethod_14();
		base.camera.fieldOfView = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_FOVDefault;
		base.gameObject.AddComponent<TargetingManager>();
		this.m_instanceInput = entityPlayer_0.GetComponent<InstanceInput>();
		this.m_pitchNode = this.m_entityPlayer.vmethod_17().method_9();
		this.m_toPitchOffset = base.transform.position - this.m_pitchNode.position;
		this.m_toPitchOffset = this.m_pitchNode.InverseTransformDirection(this.m_toPitchOffset);
	}

	// Token: 0x06000C7B RID: 3195 RVA: 0x0000311D File Offset: 0x0000131D
	public bool method_1()
	{
		return false;
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x0000311D File Offset: 0x0000131D
	public bool method_2()
	{
		return false;
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x0006B810 File Offset: 0x00069A10
	private void Update()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (this.m_instanceInput == null)
		{
			return;
		}
		float num = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_FOVDefault;
		num *= this.method_4();
		num *= this.method_5();
		base.camera.fieldOfView = num;
	}

	// Token: 0x06000C7E RID: 3198 RVA: 0x0006B868 File Offset: 0x00069A68
	private void OnDestroy()
	{
		AntialiasingAsPostEffect component = base.GetComponent<AntialiasingAsPostEffect>();
		if (component != null)
		{
			int length = Enum.GetValues(typeof(AAMode)).Length;
			for (int i = 0; i < length; i++)
			{
				component.mode = (AAMode)i;
				Material material = component.CurrentAAMaterial();
				global::UnityEngine.Object.Destroy(material);
			}
		}
	}

	// Token: 0x06000C7F RID: 3199 RVA: 0x0006B8BC File Offset: 0x00069ABC
	private void LateUpdate()
	{
		if (this.m_pitchNode != null)
		{
			Vector3 vector = base.transform.position - this.m_pitchNode.position;
			vector = this.m_pitchNode.InverseTransformDirection(vector);
			if (vector.AlmostEquals(this.m_toPitchOffset, 0.0001f))
			{
			}
			this.m_toPitchOffset = this.m_pitchNode.InverseTransformDirection(base.transform.position - this.m_pitchNode.position);
		}
		this.m_pos = base.transform.position;
	}

	// Token: 0x06000C80 RID: 3200 RVA: 0x0000BF96 File Offset: 0x0000A196
	public BHVFirstPersonSettings method_3()
	{
		return this.m_taskManager.vmethod_0<BHVFirstPersonSettings>();
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x0006B950 File Offset: 0x00069B50
	private float method_4()
	{
		if (this.m_instanceInput.IsRunning())
		{
			this.m_FOVSprintFactor += this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_FOVDefaultToSprintTransitionSpeed * Time.deltaTime;
			if (this.m_FOVSprintFactor > 1f)
			{
				this.m_FOVSprintFactor = 1f;
			}
		}
		else
		{
			this.m_FOVSprintFactor -= this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_FOVSprintToDefaultTransitionSpeed * Time.deltaTime;
			if (this.m_FOVSprintFactor <= 0f)
			{
				this.m_FOVSprintFactor = 0f;
			}
		}
		return Mathf.Lerp(1f, this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_FOVSprintMultiplier, this.m_FOVSprintFactor);
	}

	// Token: 0x06000C82 RID: 3202 RVA: 0x0006BA04 File Offset: 0x00069C04
	public float method_5()
	{
		EntityWeapon entityWeapon = this.m_entityPlayer.vmethod_16();
		if (entityWeapon != null)
		{
			float num = FloatAttributeValue.smethod_0(entityWeapon.m_attribute.method_1(AttributeType.ZoomTime) as FloatAttributeValue);
			if (this.m_entityPlayer.method_108())
			{
				if (num <= 0f)
				{
					this.m_FOVAimFactor = 1f;
				}
				else
				{
					this.m_FOVAimFactor += Time.deltaTime / num;
					if (this.m_FOVAimFactor > 1f)
					{
						this.m_FOVAimFactor = 1f;
					}
				}
			}
			else if (num <= 0f)
			{
				this.m_FOVAimFactor = 0f;
			}
			else
			{
				this.m_FOVAimFactor -= Time.deltaTime / num;
				if (this.m_FOVAimFactor < 0f)
				{
					this.m_FOVAimFactor = 0f;
				}
			}
			float num2 = FloatAttributeValue.smethod_0(entityWeapon.m_attribute.method_1(AttributeType.ZoomEndFOV) as FloatAttributeValue) / this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_FOVDefault;
			return Mathf.Lerp(1f, num2, this.m_FOVAimFactor);
		}
		return 1f;
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x0000BFA3 File Offset: 0x0000A1A3
	public void method_6(BadAssFPSCamera.ShakeType shakeType_0)
	{
		if (!this.method_8() && !this.m_entityPlayer.vmethod_53())
		{
			this.method_7((int)shakeType_0);
			return;
		}
	}

	// Token: 0x06000C84 RID: 3204 RVA: 0x0000BFC2 File Offset: 0x0000A1C2
	public void method_7(int int_0)
	{
		this.m_Animator_1st.SetInteger("iCameraShake", int_0);
	}

	// Token: 0x06000C85 RID: 3205 RVA: 0x0006BB14 File Offset: 0x00069D14
	private bool method_8()
	{
		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator_1st.GetCurrentAnimatorStateInfo(1);
		return currentAnimatorStateInfo.IsTag("CameraShake_Low") || currentAnimatorStateInfo.IsTag("CameraShake_Medium") || currentAnimatorStateInfo.IsTag("CameraShake_High");
	}

	// Token: 0x06000C86 RID: 3206 RVA: 0x0000BFD5 File Offset: 0x0000A1D5
	public Vector3 GetPosition()
	{
		return this.m_pos;
	}

	// Token: 0x04000B5D RID: 2909
	private float m_FOVSprintFactor;

	// Token: 0x04000B5E RID: 2910
	private float m_FOVAimFactor;

	// Token: 0x04000B5F RID: 2911
	public EntityPlayer m_entityPlayer;

	// Token: 0x04000B60 RID: 2912
	private InstanceInput m_instanceInput;

	// Token: 0x04000B61 RID: 2913
	private BHVTaskManager m_taskManager;

	// Token: 0x04000B62 RID: 2914
	private Animator m_Animator_1st;

	// Token: 0x04000B63 RID: 2915
	private Vector3 m_pos;

	// Token: 0x04000B64 RID: 2916
	private Vector3 m_toPitchOffset;

	// Token: 0x04000B65 RID: 2917
	private Transform m_pitchNode;

	// Token: 0x02000260 RID: 608
	public enum ShakeType
	{
		// Token: 0x04000B67 RID: 2919
		low,
		// Token: 0x04000B68 RID: 2920
		medium,
		// Token: 0x04000B69 RID: 2921
		high
	}
}
