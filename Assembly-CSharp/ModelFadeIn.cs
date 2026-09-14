using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020006DD RID: 1757
public class ModelFadeIn : MonoBehaviour
{
	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06002E52 RID: 11858 RVA: 0x0001E987 File Offset: 0x0001CB87
	public bool Boolean_0
	{
		get
		{
			return this._isPlaying;
		}
	}

	// Token: 0x06002E53 RID: 11859 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x06002E54 RID: 11860 RVA: 0x000D813C File Offset: 0x000D633C
	public void method_0()
	{
		this._isPlaying = false;
		this._startPos = base.transform.position;
		this._MaterialList = new List<Material>();
		this._OriShaderList = new List<Shader>();
		foreach (Renderer renderer in base.gameObject.GetComponentsInChildren<Renderer>())
		{
			if (renderer != null)
			{
				Material[] materials = renderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					this._MaterialList.Add(materials[j]);
					this._OriShaderList.Add(materials[j].shader);
				}
			}
		}
	}

	// Token: 0x06002E55 RID: 11861 RVA: 0x000D81E0 File Offset: 0x000D63E0
	private void Update()
	{
		if (this._isPlaying)
		{
			this._curTime += Time.deltaTime;
			if (this._curTime < this.totalTime)
			{
				using (List<Material>.Enumerator enumerator = this._MaterialList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Material material = enumerator.Current;
						float num;
						if (this.DirFromUpToDown)
						{
							num = 2.2f * (this.totalTime - this._curTime) / this.totalTime;
						}
						else
						{
							num = 2.2f * this._curTime / this.totalTime;
						}
						material.SetVector("_CenterPosTime", new Vector4(this._startPos.x, this._startPos.y, this._startPos.z, num));
					}
					return;
				}
			}
			this.vmethod_1();
		}
	}

	// Token: 0x06002E56 RID: 11862 RVA: 0x000D82D4 File Offset: 0x000D64D4
	public virtual void vmethod_0()
	{
		this._curTime = 0f;
		foreach (Material material in this._MaterialList)
		{
			if (material.shader.name == "Custom/BOL_Charactor_BRDF")
			{
				material.shader = this.characterShaderAttached;
			}
			else
			{
				material.shader = this.wpnShaderAttached;
			}
			material.SetTexture("_RoilingFlameModule", this.roilTex);
			material.SetTexture("_PyroEnergy", this.eneryTex);
			material.SetVector("_CenterPosTime", new Vector4(this._startPos.x, this._startPos.y, this._startPos.z, this._curTime));
			material.SetVector("_EmissiveHightColor", this.highLightColor);
			material.DisableKeyword("DirUpToDown");
			material.DisableKeyword("DirDownToUp");
			if (this.DirFromUpToDown)
			{
				material.EnableKeyword("DirUpToDown");
			}
			else
			{
				material.EnableKeyword("DirDownToUp");
			}
		}
		this._isPlaying = true;
	}

	// Token: 0x06002E57 RID: 11863 RVA: 0x000D8410 File Offset: 0x000D6610
	public virtual void vmethod_1()
	{
		this._isPlaying = false;
		for (int i = 0; i < this._MaterialList.Count; i++)
		{
			this._MaterialList[i].shader = this._OriShaderList[i];
		}
		this._curTime = 0f;
	}

	// Token: 0x06002E58 RID: 11864 RVA: 0x0001E98F File Offset: 0x0001CB8F
	public virtual void vmethod_2()
	{
		this._isPlaying = false;
	}

	// Token: 0x04002093 RID: 8339
	public Texture2D roilTex;

	// Token: 0x04002094 RID: 8340
	public Texture2D eneryTex;

	// Token: 0x04002095 RID: 8341
	public Color highLightColor;

	// Token: 0x04002096 RID: 8342
	public Shader characterShaderAttached;

	// Token: 0x04002097 RID: 8343
	public Shader wpnShaderAttached;

	// Token: 0x04002098 RID: 8344
	public float totalHeight = 3f;

	// Token: 0x04002099 RID: 8345
	public float totalTime = 2f;

	// Token: 0x0400209A RID: 8346
	public bool DirFromUpToDown;

	// Token: 0x0400209B RID: 8347
	public Camera sceneCamera;

	// Token: 0x0400209C RID: 8348
	private bool _isPlaying;

	// Token: 0x0400209D RID: 8349
	private List<Material> _MaterialList;

	// Token: 0x0400209E RID: 8350
	private List<Shader> _OriShaderList;

	// Token: 0x0400209F RID: 8351
	private float _curTime;

	// Token: 0x040020A0 RID: 8352
	private Vector4 _startPos = new Vector4(0f, 0f, 0f, 1f);
}
