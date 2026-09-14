using System;
using UnityEngine;

// Token: 0x020005EB RID: 1515
public class UVAnimator : MonoBehaviour
{
	// Token: 0x0600264C RID: 9804 RVA: 0x00019E2E File Offset: 0x0001802E
	private void Start()
	{
		this.offset = Vector2.zero;
	}

	// Token: 0x0600264D RID: 9805 RVA: 0x000B9174 File Offset: 0x000B7374
	private void Update()
	{
		this.offset.x = this.offset.x + Time.fixedDeltaTime * this.XSpeed;
		this.offset.y = this.offset.y + Time.fixedDeltaTime * this.YSpeed;
		if (this.PropertyNames != null)
		{
			for (int i = 0; i < this.PropertyNames.Length; i++)
			{
				string text = this.PropertyNames[i];
				for (int j = 0; j < base.renderer.materials.Length; j++)
				{
					Material material = base.renderer.materials[j];
					if (material.HasProperty(text))
					{
						material.SetTextureOffset(text, this.offset);
					}
				}
			}
		}
	}

	// Token: 0x04001C06 RID: 7174
	public float XSpeed;

	// Token: 0x04001C07 RID: 7175
	public float YSpeed;

	// Token: 0x04001C08 RID: 7176
	public string[] PropertyNames;

	// Token: 0x04001C09 RID: 7177
	private Vector2 offset = Vector2.zero;
}
