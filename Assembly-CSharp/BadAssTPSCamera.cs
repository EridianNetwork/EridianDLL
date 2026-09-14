using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
[RequireComponent(typeof(Camera))]
public class BadAssTPSCamera : MonoBehaviour
{
	// Token: 0x06000C88 RID: 3208 RVA: 0x0006BBF0 File Offset: 0x00069DF0
	private void Start()
	{
		GameObject gameObject = new GameObject();
		this.mTarget = gameObject.transform;
		this.mTarget.name = "ForCamera";
		this.mTarget.parent = this.mCharacter;
		this.standingCamDir = new Vector3(-1f, 0f, 0.3f);
		this.aimingCamDir = new Vector3(-1f, 0f, 0.5f);
		this.camTransform = base.transform;
		this.targetHeight = this.standingTargetHeight;
		this.targetDistance = this.standingTargetDistance;
		Vector3 eulerAngles = this.camTransform.eulerAngles;
		this.xCamera = eulerAngles.y;
		this.yCamera = eulerAngles.x;
	}

	// Token: 0x06000C89 RID: 3209 RVA: 0x0006BCB0 File Offset: 0x00069EB0
	private void Update()
	{
		if (this.orbit && (Input.GetKeyDown(KeyCode.O) || (double)Input.GetAxis("Horizontal") != 0.0 || (double)Input.GetAxis("Vertical") != 0.0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
		{
			this.method_0(false);
		}
		if (!this.orbit && this.idleTime > 0.1f)
		{
			this.method_0(true);
		}
		if (Input.GetMouseButton(1))
		{
			this.bAiming = true;
		}
		else
		{
			this.bAiming = false;
		}
		this.idleTime += Time.deltaTime;
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x0000BFDD File Offset: 0x0000A1DD
	private void LateUpdate()
	{
		this.method_2();
		this.method_3();
		this.method_1();
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x0000BFF1 File Offset: 0x0000A1F1
	private void method_0(bool bool_0)
	{
		this.orbit = bool_0;
		this.idleTime = 0f;
	}

	// Token: 0x06000C8C RID: 3212 RVA: 0x0006BD58 File Offset: 0x00069F58
	private void method_1()
	{
		if (this.bAiming)
		{
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, (float)this.aimingFOV, Time.deltaTime * this.lerpFOVSpeed);
			this.camDir = this.aimingCamDir.x * this.mTarget.forward + this.aimingCamDir.z * this.mTarget.right;
			this.targetHeight = this.aimingTargetHeight;
			this.targetDistance = this.aimingTargetDistance;
		}
		else
		{
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, (float)this.standingFOV, Time.deltaTime * this.lerpFOVSpeed);
			this.camDir = this.standingCamDir.x * this.mTarget.forward + this.standingCamDir.z * this.mTarget.right;
			this.targetHeight = this.standingTargetHeight;
			this.targetDistance = this.standingTargetDistance;
		}
		this.camDir = this.camDir.normalized;
		this.tPos = this.mCharacter.position + new Vector3(0f, this.targetHeight, 0f);
		RaycastHit raycastHit;
		if (Physics.Raycast(this.tPos, this.camDir, out raycastHit, this.targetDistance + 0.2f))
		{
			float num = raycastHit.distance - 0.1f;
			num -= this.minDistance;
			num /= this.targetDistance - this.minDistance;
			this.targetHeight = Mathf.Lerp(this.maxHeight, this.targetHeight, Mathf.Clamp(num, 0f, 1f));
			this.tPos = this.mCharacter.position + new Vector3(0f, this.targetHeight, 0f);
		}
		if (Physics.Raycast(this.tPos, this.camDir, out raycastHit, this.targetDistance + 0.2f))
		{
			this.targetDistance = raycastHit.distance - 0.1f;
		}
		Vector3 vector = this.tPos;
		vector += this.mTarget.right * Vector3.Dot(this.camDir * this.targetDistance, this.mTarget.right);
		this.camTransform.position = this.tPos + this.camDir * this.targetDistance;
		this.camTransform.LookAt(vector);
		this.mTarget.position = this.tPos;
		this.mTarget.rotation = Quaternion.Euler(this.yCamera, this.xCamera, 0f);
	}

	// Token: 0x06000C8D RID: 3213 RVA: 0x0006C030 File Offset: 0x0006A230
	private void method_2()
	{
		float num = ((!this.bAiming) ? this.cameraSpeed : this.aimCameraSpeed);
		this.xCamera += Mathf.Clamp(Input.GetAxis("Mouse X") * num, -this.maxCameraSpeed, this.maxCameraSpeed) * Time.deltaTime;
		this.yCamera -= Mathf.Clamp(Input.GetAxis("Mouse Y") * num, -this.maxCameraSpeed, this.maxCameraSpeed) * Time.deltaTime;
		this.yCamera = this.method_4(this.yCamera, -85f, 85f);
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x0006C0D4 File Offset: 0x0006A2D4
	private void method_3()
	{
		if (this.orbit)
		{
			return;
		}
		float y = this.mCharacter.transform.rotation.eulerAngles.y;
		float num = Mathf.Repeat(this.xCamera - y, 360f);
		if (num > 180f)
		{
			num -= 360f;
		}
		this.mCharacter.transform.Rotate(new Vector3(0f, num, 0f), Space.World);
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x0000C005 File Offset: 0x0000A205
	private float method_4(float float_0, float float_1, float float_2)
	{
		if (float_0 < -360f)
		{
			float_0 += 360f;
		}
		if (float_0 > 360f)
		{
			float_0 -= 360f;
		}
		return Mathf.Clamp(float_0, float_1, float_2);
	}

	// Token: 0x04000B6A RID: 2922
	public Transform mCharacter;

	// Token: 0x04000B6B RID: 2923
	private Vector3 tPos;

	// Token: 0x04000B6C RID: 2924
	private Transform mTarget;

	// Token: 0x04000B6D RID: 2925
	private Transform camTransform;

	// Token: 0x04000B6E RID: 2926
	private float xCamera;

	// Token: 0x04000B6F RID: 2927
	private float yCamera;

	// Token: 0x04000B70 RID: 2928
	private Vector3 camDir;

	// Token: 0x04000B71 RID: 2929
	private Vector3 standingCamDir;

	// Token: 0x04000B72 RID: 2930
	private Vector3 aimingCamDir;

	// Token: 0x04000B73 RID: 2931
	private int standingFOV = 60;

	// Token: 0x04000B74 RID: 2932
	private int aimingFOV = 30;

	// Token: 0x04000B75 RID: 2933
	private float lerpFOVSpeed = 8f;

	// Token: 0x04000B76 RID: 2934
	private float cameraSpeed = 2700f;

	// Token: 0x04000B77 RID: 2935
	private float aimCameraSpeed = 1400f;

	// Token: 0x04000B78 RID: 2936
	private float maxCameraSpeed = 2000f;

	// Token: 0x04000B79 RID: 2937
	private float standingTargetHeight = 1.5f;

	// Token: 0x04000B7A RID: 2938
	private float standingTargetDistance = 2.5f;

	// Token: 0x04000B7B RID: 2939
	private float aimingTargetHeight = 1.8f;

	// Token: 0x04000B7C RID: 2940
	private float aimingTargetDistance = 1.5f;

	// Token: 0x04000B7D RID: 2941
	private float targetHeight;

	// Token: 0x04000B7E RID: 2942
	private float targetDistance;

	// Token: 0x04000B7F RID: 2943
	private float minDistance = 0.2f;

	// Token: 0x04000B80 RID: 2944
	private float maxHeight = 2f;

	// Token: 0x04000B81 RID: 2945
	private bool bAiming;

	// Token: 0x04000B82 RID: 2946
	private bool orbit;

	// Token: 0x04000B83 RID: 2947
	private float idleTime;
}
