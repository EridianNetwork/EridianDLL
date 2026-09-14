using System;
using UnityEngine;

// Token: 0x020005BB RID: 1467
[AddComponentMenu("Image Effects/Second Wind Down Effect")]
[RequireComponent(typeof(Camera))]
public class SecondWindDownEffect : MonoBehaviour
{
	// Token: 0x0600253D RID: 9533 RVA: 0x000194D5 File Offset: 0x000176D5
	private void Start()
	{
		this.method_2();
	}

	// Token: 0x0600253E RID: 9534 RVA: 0x000194D5 File Offset: 0x000176D5
	private void OnEnable()
	{
		this.method_2();
	}

	// Token: 0x0600253F RID: 9535 RVA: 0x000194DD File Offset: 0x000176DD
	private void OnDestroy()
	{
		if (this.m_matSecondWindDownEffect)
		{
			global::UnityEngine.Object.DestroyImmediate(this.m_matSecondWindDownEffect);
		}
	}

	// Token: 0x06002540 RID: 9536 RVA: 0x000194F7 File Offset: 0x000176F7
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, this.m_matSecondWindDownEffect);
	}

	// Token: 0x06002541 RID: 9537 RVA: 0x00019506 File Offset: 0x00017706
	private bool method_0()
	{
		return SystemInfo.supportsImageEffects && this.ShaderSecondWindDownEffect != null && this.ShaderSecondWindDownEffect.isSupported;
	}

	// Token: 0x06002542 RID: 9538 RVA: 0x0001952B File Offset: 0x0001772B
	private void method_1()
	{
		if (this.m_matSecondWindDownEffect)
		{
			return;
		}
		this.m_matSecondWindDownEffect = new Material(this.ShaderSecondWindDownEffect);
		this.m_matSecondWindDownEffect.hideFlags = HideFlags.HideAndDontSave;
	}

	// Token: 0x06002543 RID: 9539 RVA: 0x00019559 File Offset: 0x00017759
	private void method_2()
	{
		if (!this.method_0())
		{
			base.enabled = false;
			return;
		}
		this.method_1();
	}

	// Token: 0x04001AA3 RID: 6819
	public Shader ShaderSecondWindDownEffect;

	// Token: 0x04001AA4 RID: 6820
	private Material m_matSecondWindDownEffect;
}
