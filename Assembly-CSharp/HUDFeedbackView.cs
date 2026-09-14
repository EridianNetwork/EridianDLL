using System;
using ns0;
using UnityEngine;

// Token: 0x020006FD RID: 1789
public class HUDFeedbackView : BaseView
{
	// Token: 0x06002F38 RID: 12088 RVA: 0x0001DC48 File Offset: 0x0001BE48
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
	}

	// Token: 0x06002F39 RID: 12089 RVA: 0x0001DC60 File Offset: 0x0001BE60
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
	}

	// Token: 0x06002F3A RID: 12090 RVA: 0x000D9724 File Offset: 0x000D7924
	public virtual void vmethod_5(int int_0, int int_1, DamageInfo damageInfo_0)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(damageInfo_0.m_from);
		GameObject gameObject = null;
		if (badAssNetworkView != null)
		{
			gameObject = badAssNetworkView.gameObject;
		}
		if (gameObject == null)
		{
			return;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		Entity entity = localPlayer.GetEntity();
		if (entity == null)
		{
			return;
		}
		Vector3 forward = entity.transform.forward;
		Vector3 vector = gameObject.transform.position - entity.transform.position;
		float num = 0f;
		float num2 = 0f;
		vector.y = num;
		forward.y = num2;
		float num3 = Vector3.Angle(vector, forward);
		HUDFeedbackView.Direction direction;
		if ((double)num3 < 45.0)
		{
			direction = HUDFeedbackView.Direction.Front;
		}
		else if ((double)num3 > 135.0)
		{
			direction = HUDFeedbackView.Direction.Back;
		}
		else
		{
			Vector3 right = entity.transform.right;
			float num4 = Vector3.Angle(vector, right);
			direction = ((num4 >= 90f) ? HUDFeedbackView.Direction.Left : HUDFeedbackView.Direction.Right);
		}
		if (vector.sqrMagnitude < 1E-45f)
		{
			direction = HUDFeedbackView.Direction.Back;
		}
		if (int_0 > 0)
		{
			this.vmethod_7(direction);
		}
		if (int_1 > 0)
		{
			this.vmethod_8(direction);
		}
	}

	// Token: 0x06002F3B RID: 12091 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(DamageInfo damageInfo_0)
	{
	}

	// Token: 0x06002F3C RID: 12092 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7(HUDFeedbackView.Direction direction_0)
	{
	}

	// Token: 0x06002F3D RID: 12093 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_8(HUDFeedbackView.Direction direction_0)
	{
	}

	// Token: 0x020006FE RID: 1790
	public enum Direction
	{
		// Token: 0x04002102 RID: 8450
		Front,
		// Token: 0x04002103 RID: 8451
		Back,
		// Token: 0x04002104 RID: 8452
		Left,
		// Token: 0x04002105 RID: 8453
		Right
	}
}
