using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000B42 RID: 2882
public abstract class ClonableEffectBase : EffectBase
{
	// Token: 0x06004E84 RID: 20100 RVA: 0x0014CE48 File Offset: 0x0014B048
	public void method_0(Transform transform_0, EffectTrigger effectTrigger_0)
	{
		if (transform_0 != null && effectTrigger_0 != null)
		{
			Transform transform = effectTrigger_0.m_gameObject.transform;
			if (effectTrigger_0.m_location == EffectLocationType.GameObject)
			{
				if (this.m_usingClone && this.m_rotateClone)
				{
					transform_0.rotation = transform.rotation;
				}
				transform_0.parent = transform;
				if (this.m_usingClone)
				{
					transform_0.Rotate(this.m_eulerAnglesToRotateClone, Space.Self);
					transform_0.localPosition = this.m_offsetToMoveClone;
				}
			}
			else if (effectTrigger_0.m_location == EffectLocationType.Raycast)
			{
				Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, effectTrigger_0.m_raycastHit.normal);
				transform_0.position = effectTrigger_0.m_raycastHit.point + quaternion * this.m_offsetToMoveClone;
				if (this.m_rotateClone)
				{
					Vector3 vector = Vector3.Reflect(effectTrigger_0.m_specifiedRaycastDirection, effectTrigger_0.m_raycastHit.normal);
					transform_0.rotation = Quaternion.FromToRotation(Vector3.up, vector);
				}
				if (effectTrigger_0.m_raycastHit.collider != null)
				{
					transform_0.Rotate(this.m_eulerAnglesToRotateClone, Space.Self);
				}
			}
		}
	}

	// Token: 0x06004E85 RID: 20101 RVA: 0x0014CF64 File Offset: 0x0014B164
	public override void PlayEffect(EffectTrigger trigger)
	{
		if (this.vmethod_0() == null)
		{
			return;
		}
		this.m_clone = null;
		if (!this.m_useCloneWhenPlayEffect && this.vmethod_0().activeSelf)
		{
			this.m_usingClone = false;
			this.vmethod_2();
			this.method_0(this.vmethod_0().transform, trigger);
		}
		else
		{
			this.m_usingClone = true;
			if (this.m_delay > 0f)
			{
				this.m_needUpdate = true;
				ClonableEffectBase.NextEffectToPlay nextEffectToPlay = default(ClonableEffectBase.NextEffectToPlay);
				nextEffectToPlay.trigger = trigger;
				nextEffectToPlay.timeToPlay = Time.realtimeSinceStartup + this.m_delay;
				this.m_nextToPlay.Add(nextEffectToPlay);
			}
			else
			{
				this.method_1(trigger);
			}
		}
	}

	// Token: 0x06004E86 RID: 20102 RVA: 0x0003319D File Offset: 0x0003139D
	private void method_1(EffectTrigger effectTrigger_0)
	{
		this.vmethod_1(effectTrigger_0);
		if (this.m_clone != null && this.m_destroyCloneAfterEffect)
		{
			global::UnityEngine.Object.Destroy(this.m_clone, (float)this.m_durationForDestroyClone);
		}
	}

	// Token: 0x06004E87 RID: 20103 RVA: 0x0014D010 File Offset: 0x0014B210
	private void Update()
	{
		if (!this.m_needUpdate)
		{
			return;
		}
		while (this.m_nextToPlay.Count > 0)
		{
			ClonableEffectBase.NextEffectToPlay nextEffectToPlay = this.m_nextToPlay[0];
			if (Time.realtimeSinceStartup <= nextEffectToPlay.timeToPlay)
			{
				break;
			}
			this.method_1(nextEffectToPlay.trigger);
			this.m_nextToPlay.Remove(nextEffectToPlay);
			if (this.m_nextToPlay.Count == 0)
			{
				this.m_needUpdate = false;
			}
		}
	}

	// Token: 0x06004E88 RID: 20104
	public abstract GameObject vmethod_0();

	// Token: 0x06004E89 RID: 20105
	public abstract void vmethod_1(EffectTrigger effectTrigger_0);

	// Token: 0x06004E8A RID: 20106
	public abstract void vmethod_2();

	// Token: 0x04003A9C RID: 15004
	public bool m_useCloneWhenPlayEffect;

	// Token: 0x04003A9D RID: 15005
	public bool m_rotateClone = true;

	// Token: 0x04003A9E RID: 15006
	public bool m_destroyCloneAfterEffect = true;

	// Token: 0x04003A9F RID: 15007
	public int m_durationForDestroyClone = 5;

	// Token: 0x04003AA0 RID: 15008
	public float m_delay;

	// Token: 0x04003AA1 RID: 15009
	public Vector3 m_offsetToMoveClone = new Vector3(0f, 0f, 0f);

	// Token: 0x04003AA2 RID: 15010
	public Vector3 m_eulerAnglesToRotateClone = new Vector3(0f, 0f, 0f);

	// Token: 0x04003AA3 RID: 15011
	protected bool m_usingClone;

	// Token: 0x04003AA4 RID: 15012
	protected GameObject m_clone;

	// Token: 0x04003AA5 RID: 15013
	private bool m_needUpdate;

	// Token: 0x04003AA6 RID: 15014
	private List<ClonableEffectBase.NextEffectToPlay> m_nextToPlay = new List<ClonableEffectBase.NextEffectToPlay>();

	// Token: 0x02000B43 RID: 2883
	private struct NextEffectToPlay
	{
		// Token: 0x04003AA7 RID: 15015
		public EffectTrigger trigger;

		// Token: 0x04003AA8 RID: 15016
		public float timeToPlay;
	}
}
