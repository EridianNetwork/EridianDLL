using System;
using BHV;
using ns0;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class InterpolateManager
{
	// Token: 0x06000C90 RID: 3216 RVA: 0x0000C035 File Offset: 0x0000A235
	public InterpolateManager(MovementSync movementSync_0, BHVTaskManager bhvtaskManager_0 = null)
	{
		this.m_timePosBuffer = new RingBuffer(300, true);
		this.m_BHVTaskManager = bhvtaskManager_0;
		this.m_movement = movementSync_0;
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x0000C063 File Offset: 0x0000A263
	private TimePos GetLatestTimePos()
	{
		return this.m_timePosBuffer.PeekLast() as TimePos;
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x0000C075 File Offset: 0x0000A275
	private TimePos GetPreviousTimePos()
	{
		return this.m_timePosBuffer.PeekSecondLast() as TimePos;
	}

	// Token: 0x06000C93 RID: 3219 RVA: 0x0000C087 File Offset: 0x0000A287
	public static float GetDefaultInterpolationTime()
	{
		return NetworkManager.smethod_10() * 2f;
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x0000C094 File Offset: 0x0000A294
	private float GetInterpolationFraction()
	{
		return Time.deltaTime / InterpolateManager.GetDefaultInterpolationTime();
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x0000C0A1 File Offset: 0x0000A2A1
	public void method_3(BHVTaskManager bhvtaskManager_0)
	{
		this.m_BHVTaskManager = bhvtaskManager_0;
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x0006C150 File Offset: 0x0006A350
	public void OnNewTPArrived(TimePos tp)
	{
		this.m_timePosBuffer.Enqueue(tp);
		TimePos timePos = this.m_timePosBuffer.PeekLast() as TimePos;
		if (this.m_timePosBuffer.PeekSecondLast() != null)
		{
			TimePos timePos2 = this.m_timePosBuffer.PeekSecondLast() as TimePos;
			float num = (float)(timePos.m_networkTimeStamp - timePos2.m_networkTimeStamp);
			Vector3 vector = (timePos.m_position - timePos2.m_position) / num;
			this.m_straightAcceleration = (vector.magnitude - this.m_velocity.magnitude) / 2f * num;
			this.m_velocity = vector;
			// editing how rotation is calculated to avoid sharp zig-zag movement. might not be te best way to do this as compared to how it was because of golang server shit. I have no idea
			float num2 = Mathf.DeltaAngle(timePos2.m_rotation.eulerAngles.y, timePos.m_rotation.eulerAngles.y);
			num2 /= num;
			this.m_angleAcceleration = (num2 - this.m_angleVelocity) / 2f * num;
			this.m_angleVelocity = num2;
			this.m_recvInterval = Mathf.Lerp(this.m_recvInterval, num, 0.3f);
			global::Debug.smethod_7(timePos2.m_position, this.m_velocity);
		}
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x0000C0AA File Offset: 0x0000A2AA
	public float method_4()
	{
		if (this.m_movement.lastEvaluatedPriority <= 66 && !MonoSingleton<Session>.Instance.method_16())
		{
			return InterpolateManager.GetDefaultInterpolationTime();
		}
		return 2f * this.m_recvInterval;
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x0006C28C File Offset: 0x0006A48C
	public bool method_5(ref Vector3 vector3_0, ref Quaternion quaternion_0)
	{
		bool flag = true;
		TimePos timePos = this.m_timePosBuffer.PeekLast() as TimePos;
		if (timePos != null)
		{
			if (this.m_currentTP == null)
			{
				this.m_currentTP = new TimePos((double)Time.time, vector3_0, quaternion_0, timePos.m_networkTimeStamp - (double)InterpolateManager.GetDefaultInterpolationTime(), 0);
				this.m_currentTPTime = (double)Time.time;
				if (!this.method_8(this.m_timePosBuffer, ref this.m_currentTP))
				{
					this.m_currentTP.m_position = timePos.m_position;
					this.m_currentTP.m_rotation = timePos.m_rotation;
				}
				flag = true;
			}
			else
			{
				double num = (double)Time.time - this.m_currentTPTime + this.m_currentTP.m_networkTimeStamp;
				this.m_actualInterpolateTime = (float)((double)Time.time - timePos.m_time + timePos.m_networkTimeStamp - num);
				float num2 = this.m_actualInterpolateTime - this.method_4();
				if ((double)Mathf.Abs(num2) > 0.016)
				{
					this.catchupCount++;
				}
				else
				{
					this.catchupCount = 0;
				}
				if (this.catchupCount >= this.catchupThreshold)
				{
					num += (double)num2;
					if (num < this.m_currentTP.m_networkTimeStamp)
					{
						num = this.m_currentTP.m_networkTimeStamp;
					}
					if (num > timePos.m_networkTimeStamp)
					{
						num = timePos.m_networkTimeStamp - (double)this.method_4();
					}
				}
				bool flag2;
				if (this.m_BHVTaskManager != null && this.m_BHVTaskManager.method_13(BHVTaskLayer.FULLBODY) != null)
				{
					if (!(flag2 = this.m_BHVTaskManager.method_16()))
					{
						this.method_6();
					}
				}
				else
				{
					flag2 = num - timePos.m_networkTimeStamp < (double)this.m_recvInterval;
				}
				if (num > timePos.m_networkTimeStamp)
				{
					if (flag2)
					{
						float num3 = (this.m_angleVelocity + this.m_angleAcceleration * (float)(num - this.m_currentTP.m_networkTimeStamp)) * (float)(num - this.m_currentTP.m_networkTimeStamp);
						Quaternion quaternion = Quaternion.identity;
						if (!num3.AlmostEquals(0f, 0.0001f))
						{
							quaternion = Quaternion.Euler(0f, num3, 0f);
						}
						this.m_velocity = this.m_velocity.normalized * (this.m_velocity.magnitude + this.m_straightAcceleration * (float)(num - this.m_currentTP.m_networkTimeStamp));
						Vector3 vector = this.m_currentTP.m_position;
						Vector3 vector2 = this.m_velocity * (float)(num - this.m_currentTP.m_networkTimeStamp);
						Ray ray = new Ray(this.m_currentTP.m_position, vector2);
						RaycastHit raycastHit;
						if (Physics.Raycast(ray, out raycastHit, vector2.magnitude, TargetingService.Int32_0))
						{
							vector = this.m_currentTP.m_position + (raycastHit.point - this.m_currentTP.m_position) * 0.5f;
						}
						else
						{
							vector = this.m_currentTP.m_position + vector2;
						}
						this.m_currentTP = new TimePos((double)Time.time, vector, this.m_currentTP.m_rotation * quaternion, num, 0);
						this.m_currentTPTime = (double)Time.time;
						flag = false;
					}
				}
				else
				{
					this.m_currentTP = new TimePos((double)Time.time, vector3_0, quaternion_0, num, 0);
					this.m_currentTPTime = (double)Time.time;
					if (!this.method_8(this.m_timePosBuffer, ref this.m_currentTP))
					{
					}
					flag = true;
				}
			}
			if (this.m_currentTP != null)
			{
				vector3_0 = this.m_currentTP.m_position;
				quaternion_0 = this.m_currentTP.m_rotation;
			}
		}
		return flag;
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x0000C0D9 File Offset: 0x0000A2D9
	private void method_6()
	{
		this.m_velocity = Vector3.zero;
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x0000C0E6 File Offset: 0x0000A2E6
	public void method_7()
	{
		this.m_timePosBuffer.Clear();
		this.method_6();
		this.m_currentTP = null;
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x0006C620 File Offset: 0x0006A820
	private bool method_8(RingBuffer ringBuffer_0, ref TimePos timePos_0)
	{
		bool flag = false;
		Vector3 position = timePos_0.m_position;
		Quaternion rotation = timePos_0.m_rotation;
		for (int num = ringBuffer_0.GetCount(); num >= 2; num--)
		{
			TimePos timePos = (TimePos)ringBuffer_0.PeekAt(num - 1);
			TimePos timePos2 = (TimePos)ringBuffer_0.PeekAt(num - 2);
			if (timePos != null && timePos2 != null)
			{
				if (!(Mathf.Abs((float)(timePos.m_networkTimeStamp - timePos_0.m_networkTimeStamp)) >= 0.001f))
				{
					position = timePos.m_position;
					rotation = timePos.m_rotation;
					flag = true;
					break;
				}
				if (timePos.m_networkTimeStamp > timePos_0.m_networkTimeStamp && !(timePos2.m_networkTimeStamp >= timePos_0.m_networkTimeStamp))
				{
					position = Vector3.Lerp(timePos2.m_position, timePos.m_position, (float)((timePos_0.m_networkTimeStamp - timePos2.m_networkTimeStamp) / (timePos.m_networkTimeStamp - timePos2.m_networkTimeStamp)));
					rotation = Quaternion.Lerp(timePos2.m_rotation, timePos.m_rotation, (float)((timePos_0.m_networkTimeStamp - timePos2.m_networkTimeStamp) / (timePos.m_networkTimeStamp - timePos2.m_networkTimeStamp)));
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			timePos_0.m_position = position;
			timePos_0.m_rotation = rotation;
		}
		return flag;
	}
	// Token: 0x06000C9C RID: 3228 RVA: 0x0006C748 File Offset: 0x0006A948
	public Vector3 method_9(Vector3 vector3_0, Vector3 vector3_1)
	{
		if (Utils.smethod_3(this.m_current, vector3_1))
		{
			return (Vector3)this.m_current;
		}
		if (!Utils.smethod_3(vector3_1, this.m_to))
		{
			this.m_to = vector3_1;
			this.m_from = vector3_0;
			this.m_current = this.m_from;
		}
		float interpolationFraction = this.GetInterpolationFraction();
		this.m_current = Vector3.Lerp((Vector3)this.m_current, (Vector3)this.m_to, interpolationFraction);
		return (Vector3)this.m_current;
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x0006C7E4 File Offset: 0x0006A9E4
	public Quaternion method_10(Quaternion quaternion_0, Quaternion quaternion_1)
	{
		if (Utils.smethod_3(this.m_current, quaternion_1))
		{
			return (Quaternion)this.m_current;
		}
		if (!Utils.smethod_3(quaternion_1, this.m_to))
		{
			this.m_to = quaternion_1;
			this.m_from = quaternion_0;
			this.m_current = this.m_from;
		}
		float interpolationFraction = this.GetInterpolationFraction();
		this.m_current = Quaternion.Lerp((Quaternion)this.m_current, (Quaternion)this.m_to, interpolationFraction);
		return (Quaternion)this.m_current;
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x0006C880 File Offset: 0x0006AA80
	public float method_11(float float_0, float float_1)
	{
		if (Utils.smethod_3(this.m_current, float_1))
		{
			return (float)this.m_current;
		}
		if (!Utils.smethod_3(float_1, this.m_to))
		{
			this.m_to = float_1;
			this.m_from = float_0;
			this.m_current = this.m_from;
		}
		float interpolationFraction = this.GetInterpolationFraction();
		this.m_current = Mathf.Lerp((float)this.m_current, (float)this.m_to, interpolationFraction);
		return (float)this.m_current;
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x0006C91C File Offset: 0x0006AB1C
	public Vector3 method_12()
	{
		Vector3 velocity = this.m_velocity;
		bool flag = false;
		int num = 0;
		if (this.m_currentTP != null)
		{
			for (int i = this.m_timePosBuffer.GetCount(); i >= 2; i--)
			{
				TimePos timePos = (TimePos)this.m_timePosBuffer.PeekAt(i - 1);
				TimePos timePos2 = (TimePos)this.m_timePosBuffer.PeekAt(i - 2);
				if (timePos != null && timePos2 != null)
				{
					if (Mathf.Abs((float)(timePos.m_networkTimeStamp - this.m_currentTP.m_networkTimeStamp)) < 0.001f)
					{
						flag = true;
						num = i - 1;
						break;
					}
					if (timePos.m_networkTimeStamp > this.m_currentTP.m_networkTimeStamp && timePos2.m_networkTimeStamp < this.m_currentTP.m_networkTimeStamp)
					{
						flag = true;
						num = i - 2;
						break;
					}
				}
			}
		}
		if (flag)
		{
			TimePos timePos3 = (TimePos)this.m_timePosBuffer.PeekAt(num);
			float num2 = 0.1f;
			int j = num;
			while (j < this.m_timePosBuffer.GetCount())
			{
				TimePos timePos4 = (TimePos)this.m_timePosBuffer.PeekAt(j);
				if (timePos4 == null || (j != this.m_timePosBuffer.GetCount() - 1 && timePos4.m_networkTimeStamp - timePos3.m_networkTimeStamp < (double)num2))
				{
					j++;
				}
				else
				{
					float num3 = (float)(timePos4.m_networkTimeStamp - timePos3.m_networkTimeStamp);
					if (num3 > 1E-45f)
					{
						return (timePos4.m_position - timePos3.m_position) / num3;
					}
					break;
				}
			}
		}
		return velocity;
	}

	// Token: 0x04000B84 RID: 2948
	private MovementSync m_movement;

	// Token: 0x04000B85 RID: 2949
	private RingBuffer m_timePosBuffer;

	// Token: 0x04000B86 RID: 2950
	private object m_from;

	// Token: 0x04000B87 RID: 2951
	private object m_to;

	// Token: 0x04000B88 RID: 2952
	private object m_current;

	// Token: 0x04000B89 RID: 2953
	private TimePos m_currentTP;

	// Token: 0x04000B8A RID: 2954
	private double m_currentTPTime;

	// Token: 0x04000B8B RID: 2955
	public Vector3 m_velocity;

	// Token: 0x04000B8C RID: 2956
	private float m_angleVelocity;

	// Token: 0x04000B8D RID: 2957
	private float m_straightAcceleration;

	// Token: 0x04000B8E RID: 2958
	private float m_angleAcceleration;

	// Token: 0x04000B8F RID: 2959
	private float m_actualInterpolateTime;

	// Token: 0x04000B90 RID: 2960
	public float m_recvInterval;

	// Token: 0x04000B91 RID: 2961
	private BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000B92 RID: 2962
	private int catchupThreshold = 5;

	// Token: 0x04000B93 RID: 2963
	private int catchupCount;
}
