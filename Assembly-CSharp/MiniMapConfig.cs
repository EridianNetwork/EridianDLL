using System;
using UnityEngine;

// Token: 0x020006DA RID: 1754
public class MiniMapConfig : MonoBehaviour
{
	// Token: 0x06002E4D RID: 11853 RVA: 0x000D80C0 File Offset: 0x000D62C0
	private void OnDestroy()
	{
		for (int i = 0; i < this.MiniMapTexture.Length; i++)
		{
			Resources.UnloadAsset(this.MiniMapTexture[i].texture);
		}
	}

	// Token: 0x0400208C RID: 8332
	public Vector3 RectOriginPoint = new Vector3(0f, 0f, 0f);

	// Token: 0x0400208D RID: 8333
	public Vector3 RectEndPoint = new Vector3(0f, 0f, 0f);

	// Token: 0x0400208E RID: 8334
	public float Scale = 0.45f;

	// Token: 0x0400208F RID: 8335
	public MiniMapConfig.MinimapTexture[] MiniMapTexture;

	// Token: 0x04002090 RID: 8336
	public Vector3 NormalInWorldView = new Vector3(0f, 0f, 1f);

	// Token: 0x020006DB RID: 1755
	[Serializable]
	public class MinimapTexture
	{
		// Token: 0x04002091 RID: 8337
		public Texture2D texture;
	}
}
