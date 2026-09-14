using System;
using UnityEngine;

// Token: 0x020006D6 RID: 1750
public class LobbyCameraController : MonoBehaviour
{
	// Token: 0x06002E39 RID: 11833 RVA: 0x000D78A8 File Offset: 0x000D5AA8
	private void Awake()
	{
		if (this.ANIMATION_NAME != string.Empty)
		{
			this.ANIM_NAME = this.ANIMATION_NAME;
		}
		if (this.TEXT_ANIM == string.Empty)
		{
			this.TEXT_ANIM = "_anim";
		}
		if (this.TEXT_ANIM_IDLE == string.Empty)
		{
			this.TEXT_ANIM_IDLE = "_idle";
		}
		if (base.camera == null)
		{
			return;
		}
		base.camera.animation.wrapMode = WrapMode.ClampForever;
		base.camera.animation[this.ANIM_NAME].speed = 0f;
		base.camera.animation.Play(this.ANIM_NAME);
		for (int i = 0; i < this._arrTextObject.Length; i++)
		{
			if (this._arrTextObject[i] != null)
			{
				string text = this._arrTextObject[i].name + this.TEXT_ANIM;
				this._arrTextObject[i].animation[text].speed = 0f;
				this._arrTextObject[i].animation.Play(text);
			}
		}
		this.method_3(this._targetIndex - 1, 1f);
	}

	// Token: 0x06002E3A RID: 11834 RVA: 0x0001E8B9 File Offset: 0x0001CAB9
	public void method_0(int int_0)
	{
		if (int_0 == this._targetIndex && !this._bPlaying)
		{
			return;
		}
		this.method_3(this._targetIndex - 1, -1f);
		this._targetIndex = int_0;
		this.method_1();
	}

	// Token: 0x06002E3B RID: 11835 RVA: 0x000D79E4 File Offset: 0x000D5BE4
	private void method_1()
	{
		float num;
		if (this._targetIndex == this._curIndex)
		{
			num = -base.camera.animation[this.ANIM_NAME].speed;
		}
		else if (this._targetIndex > this._curIndex)
		{
			num = 1f + (float)(this._targetIndex - this._curIndex - 1) * 0.3f;
		}
		else
		{
			num = -1f - (float)(this._curIndex - this._targetIndex - 1) * 0.3f;
		}
		base.camera.animation[this.ANIM_NAME].speed = num;
		this._bPlaying = true;
	}

	// Token: 0x06002E3C RID: 11836 RVA: 0x000D7A8C File Offset: 0x000D5C8C
	private void method_2(int int_0)
	{
		this._curIndex = int_0;
		if (this._curIndex == this._targetIndex)
		{
			base.camera.animation[this.ANIM_NAME].speed = 0f;
			this._bPlaying = false;
			this.method_3(this._targetIndex - 1, 1f);
		}
	}

	// Token: 0x06002E3D RID: 11837 RVA: 0x000D7AE8 File Offset: 0x000D5CE8
	private void method_3(int int_0, float float_0 = 1f)
	{
		if (this._arrTextObject[int_0] != null)
		{
			string text = this._arrTextObject[int_0].name + this.TEXT_ANIM;
			this._arrTextObject[int_0].animation[text].normalizedTime = -Mathf.Min(0f, float_0);
			this._arrTextObject[int_0].animation[text].speed = float_0;
			this._arrTextObject[int_0].animation.wrapMode = WrapMode.ClampForever;
			this._arrTextObject[int_0].animation.Play(text);
			if (float_0 > 0f)
			{
				this._updateFunc = new LobbyCameraController.AnimationUpdateFunc(this.method_4);
			}
			else
			{
				this._updateFunc = null;
			}
		}
	}

	// Token: 0x06002E3E RID: 11838 RVA: 0x0001E8ED File Offset: 0x0001CAED
	private void Update()
	{
		if (this._updateFunc != null)
		{
			this._updateFunc();
		}
	}

	// Token: 0x06002E3F RID: 11839 RVA: 0x000D7BA8 File Offset: 0x000D5DA8
	private void method_4()
	{
		int num = this._targetIndex - 1;
		if (this._arrTextObject[num] != null && this._arrTextObject[num].animation[this._arrTextObject[num].name + this.TEXT_ANIM].normalizedTime > 1f)
		{
			string text = this._arrTextObject[num].name + this.TEXT_ANIM_IDLE;
			this._arrTextObject[num].animation[text].speed = 1f;
			this._arrTextObject[num].animation.wrapMode = WrapMode.Loop;
			this._arrTextObject[num].animation.Play(text);
		}
	}

	// Token: 0x04002074 RID: 8308
	private int _curIndex = 1;

	// Token: 0x04002075 RID: 8309
	private int _targetIndex = 1;

	// Token: 0x04002076 RID: 8310
	private string ANIM_NAME = "Floasm_Lobby_camera01";

	// Token: 0x04002077 RID: 8311
	public string ANIMATION_NAME = string.Empty;

	// Token: 0x04002078 RID: 8312
	public GameObject[] _arrTextObject;

	// Token: 0x04002079 RID: 8313
	public string TEXT_ANIM = "_anim";

	// Token: 0x0400207A RID: 8314
	public string TEXT_ANIM_IDLE = "_idle";

	// Token: 0x0400207B RID: 8315
	private LobbyCameraController.AnimationUpdateFunc _updateFunc;

	// Token: 0x0400207C RID: 8316
	private bool _bPlaying;

	// Token: 0x020006D7 RID: 1751
	// (Invoke) Token: 0x06002E41 RID: 11841
	private delegate void AnimationUpdateFunc();
}
