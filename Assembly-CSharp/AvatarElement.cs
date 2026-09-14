using System;
using System.Collections;
using ns0;
using UnityEngine;

// Token: 0x02000139 RID: 313
public class AvatarElement
{
	// Token: 0x06000737 RID: 1847 RVA: 0x00007C57 File Offset: 0x00005E57
	public AvatarElement(string string_0 = null, string string_1 = null, Material material_0 = null)
	{
		this.m_materialName = string_1;
		this.m_bundleName = string_0;
		this.m_externalMaterial = material_0;
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x00055EFC File Offset: 0x000540FC
	public IEnumerator method_0()
	{
		m_gameObjectRequest = ns0.MonoSingleton<AssetBundleManager>.Instance.method_8(m_bundleName).vmethod_4("rendererobject", typeof(GameObject));
		yield return m_gameObjectRequest;
		if (!m_externalMaterial)
		{
			m_materialRequest = ns0.MonoSingleton<AssetBundleManager>.Instance.method_8(m_bundleName).vmethod_4(m_materialName, typeof(Material));
			yield return m_materialRequest;
		}
		m_boneNameRequest = ns0.MonoSingleton<AssetBundleManager>.Instance.method_8(m_bundleName).vmethod_4("bonenames", typeof(StringHolder));
		yield return m_boneNameRequest;
	}
	// Token: 0x06000739 RID: 1849 RVA: 0x00055F18 File Offset: 0x00054118
	public SkinnedMeshRenderer method_1()
	{
		GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.m_gameObjectRequest.asset);
		if (this.m_externalMaterial)
		{
			gameObject.renderer.material = this.m_externalMaterial;
		}
		else
		{
			gameObject.renderer.material = (Material)this.m_materialRequest.asset;
		}
		return (SkinnedMeshRenderer)gameObject.renderer;
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x00055F84 File Offset: 0x00054184
	public string[] method_2()
	{
		StringHolder stringHolder = (StringHolder)this.m_boneNameRequest.asset;
		return stringHolder.m_content;
	}

	// Token: 0x0400066A RID: 1642
	public string m_materialName;

	// Token: 0x0400066B RID: 1643
	public string m_bundleName;

	// Token: 0x0400066C RID: 1644
	public Material m_externalMaterial;

	// Token: 0x0400066D RID: 1645
	private AssetBundleRequest m_gameObjectRequest;

	// Token: 0x0400066E RID: 1646
	private AssetBundleRequest m_materialRequest;

	// Token: 0x0400066F RID: 1647
	private AssetBundleRequest m_boneNameRequest;
}
