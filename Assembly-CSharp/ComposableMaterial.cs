using System;
using System.Collections.Generic;

// Token: 0x0200013F RID: 319
[Serializable]
public class ComposableMaterial
{
	// Token: 0x0600074C RID: 1868 RVA: 0x00007CBB File Offset: 0x00005EBB
	public ComposableMaterial()
	{
		this.m_sTexName = new List<string>();
		this.m_sTexFileName = new List<string>();
		this.m_sShaderProperties = new List<ShaderProperty>();
	}

	// Token: 0x04000690 RID: 1680
	public string m_sMaterial;

	// Token: 0x04000691 RID: 1681
	public string m_sShader;

	// Token: 0x04000692 RID: 1682
	public List<string> m_sTexName;

	// Token: 0x04000693 RID: 1683
	public List<string> m_sTexFileName;

	// Token: 0x04000694 RID: 1684
	public List<ShaderProperty> m_sShaderProperties;
}
