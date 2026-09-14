using System;
using ns0;
using UnityEngine;

// Token: 0x020005E8 RID: 1512
public class TransferEffect : MonoBehaviour
{
	// Token: 0x0600262F RID: 9775 RVA: 0x00019D75 File Offset: 0x00017F75
	private void Awake()
	{
		this.mStartTransfer = false;
	}

	// Token: 0x06002630 RID: 9776 RVA: 0x000B868C File Offset: 0x000B688C
	private void TriggerEffectByName(string name)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (name == "TransferPlayerStart")
		{
			this.method_0();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_12(false);
		}
		else if (name == "TransferPlayerEnd")
		{
			this.method_6();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
		}
	}

	// Token: 0x06002631 RID: 9777 RVA: 0x000B86F0 File Offset: 0x000B68F0
	private void method_0()
	{
		Camera camera = MonoSingleton<GraphicsMgr>.Instance.method_17();
		GameObject gameObject = camera.gameObject;
		this.mFpsCamObj = gameObject;
		this.mFpsCam = camera;
		TransferEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<TransferEffectData>();
		this.mTransferBackground = global::UnityEngine.Object.Instantiate(component.mTransferBackground) as GameObject;
		this.mTransferBackground.SetActive(true);
		this.mTransferBackground.transform.parent = this.mFpsCamObj.transform;
		this.mTransferBackground.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		this.mTransferBackground.transform.localPosition = new Vector3(0f, 0f, 10f);
		this.mNormalToWhiteTime = component.mNormalToWhiteTime;
		this.mNormalToWhiteTimeStep = 1f / this.mNormalToWhiteTime;
		this.mWhiteToBlackTime = component.mWhiteToBlackTime;
		this.mWhiteToBlackTimeStep = 1f / this.mWhiteToBlackTime;
		this.mHoldBlackTime = component.mHoldBlackTime;
		this.mBlackToWhiteTime = this.mNormalToWhiteTime;
		this.mBlackToWhiteTimeStep = this.mNormalToWhiteTimeStep;
		this.mWhiteToNormalTimeStep = this.mWhiteToBlackTimeStep;
		this.mCurPhaseTime = 0f;
		this.mStartTransfer = true;
		this.mOriCameraCullMasking = camera.cullingMask;
		this.mOriClearFlag = camera.clearFlags;
		this.mTransEffect = gameObject.AddComponent<TransferImageEffect>();
		this.mTransEffect.shader = Shader.Find("Custom/FX/TransferEffect");
		this.mPhase1NeddInit = true;
		this.mCurPhase = TransferEffect.TRANSFER_PHASE.NORMAL_TO_WHITE;
	}

	// Token: 0x06002632 RID: 9778 RVA: 0x000B887C File Offset: 0x000B6A7C
	private void method_1()
	{
		float num = this.mNormalToWhiteTimeStep * this.mCurPhaseTime;
		this.mTransEffect.method_0(num);
		if (this.mCurPhaseTime > this.mNormalToWhiteTime)
		{
			this.mCurPhase = TransferEffect.TRANSFER_PHASE.WHITE_TO_BLACK;
			this.mCurPhaseTime = 0f;
		}
	}

	// Token: 0x06002633 RID: 9779 RVA: 0x000B88C4 File Offset: 0x000B6AC4
	private void method_2()
	{
		if (this.mPhase1NeddInit)
		{
			this.mFpsCam.cullingMask = 8192;
			this.mFpsCam.clearFlags = CameraClearFlags.Color;
			this.mFpsCam.backgroundColor = new Color((float)0.13333334121853113, (float)0.21568628726527095, (float)0.3176470776088536, 1f);
			MonoSingleton<GraphicsMgr>.Instance.method_18().method_0(this.mFpsCam, false);
			this.mParticleComp = this.mTransferBackground.GetComponent<ParticleSystem>();
			if (this.mParticleComp != null)
			{
				this.mParticleComp.Play();
			}
			this.mPhase1NeddInit = false;
		}
		float num = this.mWhiteToBlackTimeStep * this.mCurPhaseTime;
		this.mTransEffect.method_0(1f - num);
		if (this.mCurPhaseTime > this.mWhiteToBlackTime)
		{
			this.mCurPhase = TransferEffect.TRANSFER_PHASE.HOLD_BLACK;
			this.mCurPhaseTime = 0f;
		}
	}

	// Token: 0x06002634 RID: 9780 RVA: 0x00019D7E File Offset: 0x00017F7E
	private void method_3()
	{
		if (this.mCurPhaseTime > this.mHoldBlackTime)
		{
			this.mCurPhase = TransferEffect.TRANSFER_PHASE.BLACK_TO_WHITE;
			this.mCurPhaseTime = 0f;
		}
	}

	// Token: 0x06002635 RID: 9781 RVA: 0x000B89B0 File Offset: 0x000B6BB0
	private void method_4()
	{
		float num = this.mBlackToWhiteTimeStep * this.mCurPhaseTime;
		this.mTransEffect.method_0(num);
		if (this.mCurPhaseTime > this.mBlackToWhiteTime)
		{
			this.mCurPhase = TransferEffect.TRANSFER_PHASE.WHITE_TO_NORMAL;
			this.mCurPhaseTime = 0f;
		}
	}

	// Token: 0x06002636 RID: 9782 RVA: 0x000B89F8 File Offset: 0x000B6BF8
	private void method_5()
	{
		float num = this.mWhiteToNormalTimeStep * this.mCurPhaseTime;
		if (num < 1f)
		{
			this.mTransEffect.method_0(1f - num);
		}
	}

	// Token: 0x06002637 RID: 9783 RVA: 0x000B8A30 File Offset: 0x000B6C30
	private void FixedUpdate()
	{
		if (this.mStartTransfer)
		{
			this.mCurPhaseTime += Time.deltaTime;
			switch (this.mCurPhase)
			{
			case TransferEffect.TRANSFER_PHASE.NORMAL_TO_WHITE:
				this.method_1();
				break;
			case TransferEffect.TRANSFER_PHASE.WHITE_TO_BLACK:
				this.method_2();
				break;
			case TransferEffect.TRANSFER_PHASE.HOLD_BLACK:
				this.method_3();
				break;
			case TransferEffect.TRANSFER_PHASE.BLACK_TO_WHITE:
				this.method_4();
				break;
			case TransferEffect.TRANSFER_PHASE.WHITE_TO_NORMAL:
				this.method_5();
				break;
			}
		}
	}

	// Token: 0x06002638 RID: 9784 RVA: 0x000B8AA0 File Offset: 0x000B6CA0
	private void method_6()
	{
		MonoSingleton<GraphicsMgr>.Instance.method_18().method_0(this.mFpsCam, true);
		this.mFpsCam.cullingMask = this.mOriCameraCullMasking;
		this.mFpsCam.clearFlags = this.mOriClearFlag;
		global::UnityEngine.Object.Destroy(this.mTransferBackground);
		global::UnityEngine.Object.Destroy(this.mTransEffect);
	}

	// Token: 0x04001BD9 RID: 7129
	private GameObject mTransferBackground;

	// Token: 0x04001BDA RID: 7130
	private int mOriCameraCullMasking;

	// Token: 0x04001BDB RID: 7131
	private CameraClearFlags mOriClearFlag;

	// Token: 0x04001BDC RID: 7132
	private TransferImageEffect mTransEffect;

	// Token: 0x04001BDD RID: 7133
	private bool mStartTransfer;

	// Token: 0x04001BDE RID: 7134
	private float mCurPhaseTime;

	// Token: 0x04001BDF RID: 7135
	private float mNormalToWhiteTime;

	// Token: 0x04001BE0 RID: 7136
	private float mNormalToWhiteTimeStep;

	// Token: 0x04001BE1 RID: 7137
	private float mWhiteToBlackTime;

	// Token: 0x04001BE2 RID: 7138
	private float mWhiteToBlackTimeStep;

	// Token: 0x04001BE3 RID: 7139
	private float mHoldBlackTime;

	// Token: 0x04001BE4 RID: 7140
	private float mBlackToWhiteTime;

	// Token: 0x04001BE5 RID: 7141
	private float mBlackToWhiteTimeStep;

	// Token: 0x04001BE6 RID: 7142
	private float mWhiteToNormalTimeStep;

	// Token: 0x04001BE7 RID: 7143
	private GameObject mFpsCamObj;

	// Token: 0x04001BE8 RID: 7144
	private Camera mFpsCam;

	// Token: 0x04001BE9 RID: 7145
	private bool mPhase1NeddInit;

	// Token: 0x04001BEA RID: 7146
	private ParticleSystem mParticleComp;

	// Token: 0x04001BEB RID: 7147
	private TransferEffect.TRANSFER_PHASE mCurPhase;

	// Token: 0x020005E9 RID: 1513
	private enum TRANSFER_PHASE
	{
		// Token: 0x04001BED RID: 7149
		NORMAL_TO_WHITE,
		// Token: 0x04001BEE RID: 7150
		WHITE_TO_BLACK,
		// Token: 0x04001BEF RID: 7151
		HOLD_BLACK,
		// Token: 0x04001BF0 RID: 7152
		BLACK_TO_WHITE,
		// Token: 0x04001BF1 RID: 7153
		WHITE_TO_NORMAL,
		// Token: 0x04001BF2 RID: 7154
		PHASE_NUM
	}
}
