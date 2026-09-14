using System;
using UnityEngine;

// Token: 0x0200070F RID: 1807
public class DNAPortraitData
{
	// Token: 0x06002FF4 RID: 12276 RVA: 0x000DAFCC File Offset: 0x000D91CC
	public DNAPortraitData()
	{
		this.method_0(this.TEXTURE_WIDTH, this.TEXTURE_HIGHT);
		this.tex = new Texture2D(this.TEXTURE_WIDTH, this.TEXTURE_HIGHT, TextureFormat.ARGB32, false);
		this.tex.name = "DNAPortraitData_tex";
		this.tex.SetPixels32(DNAPortraitData.defaultColor);
		this.tex.Apply();
	}

	// Token: 0x06002FF5 RID: 12277 RVA: 0x000DB048 File Offset: 0x000D9248
	public DNAPortraitData(int int_0, int int_1)
	{
		this.method_0(int_0, int_1);
		this.TEXTURE_WIDTH = int_0;
		this.TEXTURE_HIGHT = int_1;
		this.tex = new Texture2D(this.TEXTURE_WIDTH, this.TEXTURE_HIGHT, TextureFormat.ARGB32, false);
		this.tex.name = "DNAPortraitData_tex";
		this.tex.SetPixels32(DNAPortraitData.defaultColor);
		this.tex.Apply();
	}

	// Token: 0x06002FF6 RID: 12278 RVA: 0x000DB0C8 File Offset: 0x000D92C8
	protected void method_0(int int_0, int int_1)
	{
		int num = int_0 * int_1;
		if (DNAPortraitData.defaultColor == null || this.TEXTURE_WIDTH * this.TEXTURE_HIGHT != num)
		{
			DNAPortraitData.defaultColor = new Color32[num];
			for (int i = 0; i < num; i++)
			{
				DNAPortraitData.defaultColor[i] = Color.clear;
			}
		}
	}

	// Token: 0x0400214A RID: 8522
	public Texture2D tex;

	// Token: 0x0400214B RID: 8523
	public ItemDNA dna;

	// Token: 0x0400214C RID: 8524
	public GameObject model;

	// Token: 0x0400214D RID: 8525
	private int TEXTURE_WIDTH = 258;

	// Token: 0x0400214E RID: 8526
	private int TEXTURE_HIGHT = 80;

	// Token: 0x0400214F RID: 8527
	public TexPostEffectMgr.POST_EFFECT_TYPE boundPostEffect;

	// Token: 0x04002150 RID: 8528
	protected static Color32[] defaultColor;
}
