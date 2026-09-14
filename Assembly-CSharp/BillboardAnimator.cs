using System;
using UnityEngine;

// Token: 0x0200058B RID: 1419
public class BillboardAnimator : MonoBehaviour
{
	// Token: 0x06002456 RID: 9302 RVA: 0x00018CED File Offset: 0x00016EED
	private void Start()
	{
		this.mOriginalPosition = base.gameObject.transform.localPosition;
		this.SpeedDirection.Normalize();
	}

	// Token: 0x06002457 RID: 9303 RVA: 0x000ADEA4 File Offset: 0x000AC0A4
	private void Update()
	{
		if (this.mState == BillboardAnimator.EBillboardState.EBS_Stopping || this.mState == BillboardAnimator.EBillboardState.EBS_Play)
		{
			this.mCurrentVelocity += this.mCurrentAcceleration * Time.deltaTime;
			if (this.mCurrentVelocity >= this.Velocity)
			{
				this.mCurrentVelocity = this.Velocity;
				this.mCurrentAcceleration = -this.mCurrentAcceleration;
			}
			else if (this.mCurrentVelocity <= 0f)
			{
				this.mCurrentVelocity = 0f;
				this.mCurrentAcceleration = -this.mCurrentAcceleration;
				this.mCurrentSpeedDirection = -this.mCurrentSpeedDirection;
				if (this.mState == BillboardAnimator.EBillboardState.EBS_Stopping && Vector3.Dot(this.mCurrentSpeedDirection, this.SpeedDirection) < 0f)
				{
					base.gameObject.transform.localPosition = this.mOriginalPosition;
					this.OnStateChanged(BillboardAnimator.EBillboardState.EBS_Stop);
				}
			}
			else
			{
				base.gameObject.transform.localPosition += this.mCurrentVelocity * Time.deltaTime * this.mCurrentSpeedDirection;
			}
		}
	}

	// Token: 0x06002458 RID: 9304 RVA: 0x000ADFB4 File Offset: 0x000AC1B4
	private void OnStateChanged(BillboardAnimator.EBillboardState eState)
	{
		if (eState == BillboardAnimator.EBillboardState.EBS_Play)
		{
			this.mCurrentAcceleration = this.Velocity / this.TotalTime / 2f;
			this.mCurrentVelocity = 0f;
			this.mCurrentSpeedDirection = this.SpeedDirection;
		}
		else if (eState == BillboardAnimator.EBillboardState.EBS_Stop)
		{
			this.mCurrentAcceleration = 0f;
			this.mCurrentVelocity = 0f;
		}
		this.mState = eState;
	}

	// Token: 0x06002459 RID: 9305 RVA: 0x00018D10 File Offset: 0x00016F10
	public void method_0()
	{
		this.OnStateChanged(BillboardAnimator.EBillboardState.EBS_Play);
	}

	// Token: 0x0600245A RID: 9306 RVA: 0x00018D19 File Offset: 0x00016F19
	public void method_1()
	{
		if (this.mState == BillboardAnimator.EBillboardState.EBS_Stop)
		{
			return;
		}
		this.OnStateChanged(BillboardAnimator.EBillboardState.EBS_Stopping);
	}

	// Token: 0x04001920 RID: 6432
	public Vector3 SpeedDirection = new Vector3(0f, 1f, 0f);

	// Token: 0x04001921 RID: 6433
	public float Amplitude = 1f;

	// Token: 0x04001922 RID: 6434
	public float Velocity = 2.5f;

	// Token: 0x04001923 RID: 6435
	public float TotalTime = 0.1f;

	// Token: 0x04001924 RID: 6436
	private Vector3 mOriginalPosition = new Vector3(0f, 0f, 0f);

	// Token: 0x04001925 RID: 6437
	private BillboardAnimator.EBillboardState mState;

	// Token: 0x04001926 RID: 6438
	private float mCurrentAcceleration;

	// Token: 0x04001927 RID: 6439
	private float mCurrentVelocity;

	// Token: 0x04001928 RID: 6440
	private Vector3 mCurrentSpeedDirection = new Vector3(0f, 0f, 0f);

	// Token: 0x0200058C RID: 1420
	private enum EBillboardState
	{
		// Token: 0x0400192A RID: 6442
		EBS_Stop,
		// Token: 0x0400192B RID: 6443
		EBS_Play,
		// Token: 0x0400192C RID: 6444
		EBS_Stopping
	}
}
