using System;
using Core;
using UnityEngine;

namespace pumpkin.swf
{
	// Token: 0x020007C3 RID: 1987
	public class UniTextureManager : ITextureManager
	{
		// Token: 0x06003549 RID: 13641 RVA: 0x00022FE5 File Offset: 0x000211E5
		public UniTextureManager()
		{
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
			UniTextureManager.instance = this;
		}

		// Token: 0x0600354A RID: 13642 RVA: 0x000F1D08 File Offset: 0x000EFF08
		public virtual Material getBitmapData(string uri)
		{
			if (!TextureManager.instance.materials.ContainsKey(uri) || (TextureManager.instance.materials.ContainsKey(uri) && TextureManager.instance.materials[uri] == null))
			{
				if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.TextureLoad) == MovieClipProfiler.TextureLoad)
				{
					DebugUtils.Log(LogCategory.GUI, "SwfProfile->TextureLoad: " + uri);
				}
				Texture texture = (Texture)Resources.Load("UI_uniSWF/SwfAssets/" + uri);
				if (texture == null)
				{
					texture = Resources.Load<Texture>(uri);
				}
				if (texture == null)
				{
					DebugUtils.Log(LogCategory.GUI, "Shit! Failed to load texture: " + uri);
					return null;
				}
				Material material = new Material(TextureManager.baseBitmapShader);
				material.color = new Color(1f, 1f, 1f, 1f);
				material.name = uri;
				texture.name = uri;
				material.mainTexture = texture;
				TextureManager.instance.materials[uri] = material;
				TextureManager.instance.textures[uri] = texture;
			}
			return TextureManager.instance.materials[uri];
		}

		// Token: 0x0600354B RID: 13643 RVA: 0x00023000 File Offset: 0x00021200
		public virtual void clearTextureCache()
		{
			TextureManager.instance.clearTextureCache();
		}

		// Token: 0x0600354C RID: 13644 RVA: 0x0002300C File Offset: 0x0002120C
		public virtual void clearTextureMatchingPrefix(string swfPrefix)
		{
			TextureManager.instance.clearTextureMatchingPrefix(swfPrefix);
		}

		// Token: 0x0600354D RID: 13645 RVA: 0x00023019 File Offset: 0x00021219
		public virtual Material createBitmapDataFromTexture(string uri, Texture tex)
		{
			return TextureManager.instance.createBitmapDataFromTexture(uri, tex);
		}

		// Token: 0x0600354E RID: 13646 RVA: 0x000F1E28 File Offset: 0x000F0028
		public virtual Material getBitmapData(AssetBundle assetBundle, string uri)
		{
			if (!TextureManager.instance.materials.ContainsKey(uri) || (TextureManager.instance.materials.ContainsKey(uri) && TextureManager.instance.materials[uri] == null))
			{
				if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.TextureLoad) == MovieClipProfiler.TextureLoad)
				{
					DebugUtils.Log(LogCategory.GUI, "SwfProfile->TextureLoad: " + uri);
				}
				Texture texture = (Texture)assetBundle.Load(uri);
				if (texture == null)
				{
					DebugUtils.Log(LogCategory.GUI, string.Concat(new object[] { "Failed to load texture: ", uri, " from bundle: ", assetBundle }));
					return null;
				}
				Material material = new Material(TextureManager.baseBitmapShader);
				material.color = new Color(1f, 1f, 1f, 1f);
				material.name = uri;
				texture.name = uri;
				material.mainTexture = texture;
				TextureManager.instance.materials[uri] = material;
				TextureManager.instance.textures[uri] = texture;
			}
			return TextureManager.instance.materials[uri];
		}

		// Token: 0x0600354F RID: 13647 RVA: 0x00023027 File Offset: 0x00021227
		public virtual Material getBitmapDataFromSceneTexture(string uri, Texture tex)
		{
			return TextureManager.instance.getBitmapDataFromSceneTexture(uri, tex);
		}

		// Token: 0x06003550 RID: 13648 RVA: 0x00023035 File Offset: 0x00021235
		public virtual int getTotalTextures()
		{
			return TextureManager.instance.getTotalTextures();
		}

		// Token: 0x040024C6 RID: 9414
		public static UniTextureManager instance;
	}
}
