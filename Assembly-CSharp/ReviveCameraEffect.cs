using System;
using ns0;
using UnityEngine;

// Token: 0x020005DC RID: 1500
public class ReviveCameraEffect : MonoBehaviour
{
	// Token: 0x060025FD RID: 9725 RVA: 0x00019BB1 File Offset: 0x00017DB1
	private void TriggerEffectByName(string name)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (name == "PlayerReviveStart")
		{
			this.method_0();
		}
		else if (name == "PlayerReviveEnd")
		{
			this.method_1();
		}
	}

	// Token: 0x060025FE RID: 9726 RVA: 0x000B7730 File Offset: 0x000B5930
	private void method_0()
	{
		this.mRootObj = base.gameObject.transform.parent.gameObject;
		this.mReviveEffect = this.mRootObj.AddComponent<ReviveEffect>();
		this.mReviveEffect.shader = Shader.Find("Custom/ReviveEffect");
		this.mRevieUpdateTime = 0f;
	}

	// Token: 0x060025FF RID: 9727 RVA: 0x00019BE8 File Offset: 0x00017DE8
	private void method_1()
	{
		if (this.mReviveEffect)
		{
			global::UnityEngine.Object.Destroy(this.mReviveEffect);
			this.mReviveEffect = null;
		}
	}

	// Token: 0x06002600 RID: 9728 RVA: 0x00019C09 File Offset: 0x00017E09
	private void FixedUpdate()
	{
		if (this.mReviveEffect)
		{
			this.mRevieUpdateTime += Time.fixedDeltaTime;
			this.mReviveEffect.mLerpVal = this.mSaturationCurve.Evaluate(this.mRevieUpdateTime);
		}
	}

	// Token: 0x04001B9F RID: 7071
	public AnimationCurve mSaturationCurve;

	// Token: 0x04001BA0 RID: 7072
	private ReviveEffect mReviveEffect;

	// Token: 0x04001BA1 RID: 7073
	private GameObject mRootObj;

	// Token: 0x04001BA2 RID: 7074
	private float mRevieUpdateTime;
}
