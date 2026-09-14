using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000B95 RID: 2965
[ExecuteInEditMode]
public class CustomTerrainScriptColorMapUltra : MonoBehaviour
{
	// Token: 0x06005011 RID: 20497 RVA: 0x00154D7C File Offset: 0x00152F7C
	private void Awake()
	{
		Terrain terrain = (Terrain)base.GetComponent(typeof(Terrain));
		terrain.basemapDistance = 100000f;
		this.method_0();
	}

	// Token: 0x06005012 RID: 20498 RVA: 0x00154D7C File Offset: 0x00152F7C
	private void Start()
	{
		Terrain terrain = (Terrain)base.GetComponent(typeof(Terrain));
		terrain.basemapDistance = 100000f;
		this.method_0();
	}

	// Token: 0x06005013 RID: 20499 RVA: 0x00154DB0 File Offset: 0x00152FB0
	public void method_0()
	{
		Terrain terrain = (Terrain)base.GetComponent(typeof(Terrain));
		float x = terrain.terrainData.size.x;
		if (this.CustomColorMap)
		{
			Shader.SetGlobalTexture("_CustomColorMap", this.CustomColorMap);
		}
		if (this.TerrainNormalMap)
		{
			Shader.SetGlobalTexture("_TerrainNormalMap", this.TerrainNormalMap);
		}
		if (this.SplatMap1)
		{
			Shader.SetGlobalTexture("_Control", this.SplatMap1);
		}
		if (this.SplatMap2)
		{
			Shader.SetGlobalTexture("_Control2nd", this.SplatMap2);
			if (this.blankTexture != null)
			{
				global::UnityEngine.Object.DestroyImmediate(this.blankTexture, true);
			}
		}
		else
		{
			if (!this.blankTexture)
			{
				this.method_1();
			}
			Shader.SetGlobalTexture("_Control2nd", this.blankTexture);
		}
		Shader.SetGlobalColor("_SpecularColor", this.SpecularColor);
		if (this.CombinedNormal12)
		{
			Shader.SetGlobalTexture("_CombinedNormal12", this.CombinedNormal12);
		}
		if (this.CombinedNormal34)
		{
			Shader.SetGlobalTexture("_CombinedNormal34", this.CombinedNormal34);
		}
		if (this.CombinedNormal56)
		{
			Shader.SetGlobalTexture("_CombinedNormal56", this.CombinedNormal56);
		}
		Shader.SetGlobalVector("_terrainCombinedFloats", new Vector4(this.MultiUv, this.DesMultiUvFac, this.SplattingDistance, this.SpecPower));
		if (this.BlendMultiUv)
		{
			Shader.EnableKeyword("USE_BLENDMULTIUV");
			Shader.DisableKeyword("USE_ADDDMULTIUV");
		}
		else
		{
			Shader.DisableKeyword("USE_BLENDMULTIUV");
			Shader.EnableKeyword("USE_ADDDMULTIUV");
		}
		if (this.TerrainFresnel)
		{
			Shader.EnableKeyword("USE_FRESNEL");
			Shader.DisableKeyword("NO_FRESNEL");
		}
		else
		{
			Shader.EnableKeyword("NO_FRESNEL");
			Shader.DisableKeyword("USE_FRESNEL");
		}
		if (this.AdvancedNormalBlending)
		{
			Shader.DisableKeyword("USE_STANDARDNORMALBLENDING");
			Shader.EnableKeyword("USE_ADVANCEDNORMALBLENDING");
		}
		else
		{
			Shader.EnableKeyword("USE_STANDARDNORMALBLENDING");
			Shader.DisableKeyword("USE_ADVANCEDNORMALBLENDING");
		}
		Shader.SetGlobalVector("_Elev", new Vector4(this.Elev1, this.Elev2, this.Elev3, this.Elev4));
		Shader.SetGlobalVector("_Elev1", new Vector4(this.Elev5, this.Elev6, 1f, 1f));
		Shader.SetGlobalFloat("_Spec1", this.Spec1);
		Shader.SetGlobalFloat("_Spec2", this.Spec2);
		Shader.SetGlobalFloat("_Spec3", this.Spec3);
		Shader.SetGlobalFloat("_Spec4", this.Spec4);
		Shader.SetGlobalFloat("_Spec5", this.Spec5);
		Shader.SetGlobalFloat("_Spec6", this.Spec6);
		Shader.SetGlobalVector("_Fresnel", new Vector4(this.FresnelIntensity, this.FresnelPower, this.FresnelBias, 0f));
		Shader.SetGlobalFloat("_Spec2", this.Spec2);
		Shader.SetGlobalFloat("_Spec3", this.Spec3);
		Shader.SetGlobalColor("_ReflectionColor", this.ReflectionColor);
		Shader.SetGlobalColor("_ColTex1", this.ColTex1);
		Shader.SetGlobalColor("_ColTex2", this.ColTex2);
		Shader.SetGlobalColor("_ColTex3", this.ColTex3);
		Shader.SetGlobalColor("_ColTex4", this.ColTex4);
		Shader.SetGlobalColor("_ColTex5", this.ColTex5);
		Shader.SetGlobalColor("_ColTex6", this.ColTex6);
		Shader.SetGlobalVector("_DecalCombinedFloats", new Vector4(this.Decal1_ColorCorrectionStrenght, this.Decal2_ColorCorrectionStrenght, this.Decal1_Sharpness, this.Decal2_Sharpness));
		for (int i = 0; i < terrain.terrainData.splatPrototypes.Length; i++)
		{
			Shader.SetGlobalTexture("_Splat" + i.ToString(), terrain.terrainData.splatPrototypes[i].texture);
			Shader.SetGlobalFloat("_Splat" + i.ToString() + "Tiling", x / terrain.terrainData.splatPrototypes[i].tileSize.x);
		}
	}

	// Token: 0x06005014 RID: 20500 RVA: 0x001551C0 File Offset: 0x001533C0
	public void method_1()
	{
		this.blankTexture = new Texture2D(64, 64, TextureFormat.ARGB32, true);
		this.blankTexture.name = "createBlankTexture_blankTexture";
		Color[] array = new Color[4096];
		Color color = new Color(0f, 0f, 0f, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = color;
		}
		this.blankTexture.SetPixels(array, 0);
		this.blankTexture.Apply(false, true);
	}

	// Token: 0x04003CBA RID: 15546
	public float SplattingDistance = 600f;

	// Token: 0x04003CBB RID: 15547
	public Texture2D CustomColorMap;

	// Token: 0x04003CBC RID: 15548
	public Texture2D TerrainNormalMap;

	// Token: 0x04003CBD RID: 15549
	public Texture2D SplatMap1;

	// Token: 0x04003CBE RID: 15550
	public Texture2D SplatMap2;

	// Token: 0x04003CBF RID: 15551
	public Color SpecularColor = Color.gray;

	// Token: 0x04003CC0 RID: 15552
	public Texture2D customSplatMap1;

	// Token: 0x04003CC1 RID: 15553
	public Texture2D customSplatMap2;

	// Token: 0x04003CC2 RID: 15554
	public Texture2D blankTexture;

	// Token: 0x04003CC3 RID: 15555
	public Color ColTex1 = Color.gray;

	// Token: 0x04003CC4 RID: 15556
	public Color ColTex2 = Color.gray;

	// Token: 0x04003CC5 RID: 15557
	public Color ColTex3 = Color.gray;

	// Token: 0x04003CC6 RID: 15558
	public Color ColTex4 = Color.gray;

	// Token: 0x04003CC7 RID: 15559
	public Color ColTex5 = Color.gray;

	// Token: 0x04003CC8 RID: 15560
	public Color ColTex6 = Color.gray;

	// Token: 0x04003CC9 RID: 15561
	public float Elev1 = 1f;

	// Token: 0x04003CCA RID: 15562
	public float Elev2 = 1f;

	// Token: 0x04003CCB RID: 15563
	public float Elev3 = 1f;

	// Token: 0x04003CCC RID: 15564
	public float Elev4 = 1f;

	// Token: 0x04003CCD RID: 15565
	public float Elev5 = 1f;

	// Token: 0x04003CCE RID: 15566
	public float Elev6 = 1f;

	// Token: 0x04003CCF RID: 15567
	public float MultiUv = 0.5f;

	// Token: 0x04003CD0 RID: 15568
	public bool BlendMultiUv = true;

	// Token: 0x04003CD1 RID: 15569
	public float DesMultiUvFac = 0.5f;

	// Token: 0x04003CD2 RID: 15570
	public float SpecPower = 1f;

	// Token: 0x04003CD3 RID: 15571
	public float Spec1 = 0.078125f;

	// Token: 0x04003CD4 RID: 15572
	public float Spec2 = 0.078125f;

	// Token: 0x04003CD5 RID: 15573
	public float Spec3 = 0.078125f;

	// Token: 0x04003CD6 RID: 15574
	public float Spec4 = 0.078125f;

	// Token: 0x04003CD7 RID: 15575
	public float Spec5 = 0.078125f;

	// Token: 0x04003CD8 RID: 15576
	public float Spec6 = 0.078125f;

	// Token: 0x04003CD9 RID: 15577
	public bool TerrainFresnel;

	// Token: 0x04003CDA RID: 15578
	public float FresnelIntensity = 1f;

	// Token: 0x04003CDB RID: 15579
	public float FresnelPower = 1f;

	// Token: 0x04003CDC RID: 15580
	public float FresnelBias = -0.5f;

	// Token: 0x04003CDD RID: 15581
	public Color ReflectionColor = Color.white;

	// Token: 0x04003CDE RID: 15582
	public bool AdvancedNormalBlending;

	// Token: 0x04003CDF RID: 15583
	public Texture2D SourceNormal1;

	// Token: 0x04003CE0 RID: 15584
	public Texture2D SourceNormal2;

	// Token: 0x04003CE1 RID: 15585
	public Texture2D SourceNormal3;

	// Token: 0x04003CE2 RID: 15586
	public Texture2D SourceNormal4;

	// Token: 0x04003CE3 RID: 15587
	public Texture2D SourceNormal5;

	// Token: 0x04003CE4 RID: 15588
	public Texture2D SourceNormal6;

	// Token: 0x04003CE5 RID: 15589
	public Texture2D CombinedNormal12;

	// Token: 0x04003CE6 RID: 15590
	public Texture2D CombinedNormal34;

	// Token: 0x04003CE7 RID: 15591
	public Texture2D CombinedNormal56;

	// Token: 0x04003CE8 RID: 15592
	public float Decal1_ColorCorrectionStrenght = 0.5f;

	// Token: 0x04003CE9 RID: 15593
	public float Decal2_ColorCorrectionStrenght = 0.5f;

	// Token: 0x04003CEA RID: 15594
	public float Decal1_Sharpness = 16f;

	// Token: 0x04003CEB RID: 15595
	public float Decal2_Sharpness = 16f;

	// Token: 0x04003CEC RID: 15596
	[HideInInspector]
	public bool showNewInspector = true;

	// Token: 0x04003CED RID: 15597
	public List<Material> blendedMaterials = new List<Material>();

	// Token: 0x04003CEE RID: 15598
	[HideInInspector]
	public bool detailsIntro;

	// Token: 0x04003CEF RID: 15599
	[HideInInspector]
	public bool detailsBase = true;

	// Token: 0x04003CF0 RID: 15600
	[HideInInspector]
	public bool detailsMultiuv;

	// Token: 0x04003CF1 RID: 15601
	[HideInInspector]
	public bool detailsImportSplat = true;

	// Token: 0x04003CF2 RID: 15602
	[HideInInspector]
	public bool detailsComNormals = true;

	// Token: 0x04003CF3 RID: 15603
	[HideInInspector]
	public bool detailsCreateComNormals = true;

	// Token: 0x04003CF4 RID: 15604
	[HideInInspector]
	public bool detailsColCor = true;

	// Token: 0x04003CF5 RID: 15605
	[HideInInspector]
	public bool detailsSpecVal = true;

	// Token: 0x04003CF6 RID: 15606
	[HideInInspector]
	public bool detailsMeshMat = true;
}
