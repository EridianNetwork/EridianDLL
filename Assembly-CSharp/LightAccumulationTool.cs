using System;
using UnityEngine;

// Token: 0x02000B3B RID: 2875
public class LightAccumulationTool : MonoBehaviour
{
	// Token: 0x06004E6C RID: 20076 RVA: 0x000330C1 File Offset: 0x000312C1
	private void Start()
	{
		this.m_camera = base.GetComponent<Camera>();
		this.m_accumShader = Shader.Find("Custom/LightAccumTool");
		this.m_camera.SetReplacementShader(this.m_accumShader, string.Empty);
	}

	// Token: 0x06004E6D RID: 20077 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x04003A82 RID: 14978
	private Camera m_camera;

	// Token: 0x04003A83 RID: 14979
	private Shader m_accumShader;
}
