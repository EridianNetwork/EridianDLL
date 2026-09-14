using System;
using System.IO;
using Core;
using UnityEngine;

namespace pumpkin.swf
{
	// Token: 0x020007C2 RID: 1986
	public class BadAssSWFResourceLoader : BuiltinResourceLoader
	{
		// Token: 0x06003542 RID: 13634 RVA: 0x00022F9A File Offset: 0x0002119A
		public void AllowSceneLoader()
		{
			this.enableSceneAssetLoader = true;
			this.sceneAssets = UniSWFSharedAssetManagerBehaviour.getInstance().assets;
		}

		// Token: 0x06003543 RID: 13635 RVA: 0x000F1960 File Offset: 0x000EFB60
		public static SwfAssetContext loadFromTextAsset(ISwfResourceLoader loader, TextAsset swfInfoAsset, string swfUri, string swfUriTmp, AssetBundle useAssetBundle)
		{
			SwfBinaryReader swfBinaryReader = new SwfBinaryReader(swfInfoAsset.bytes);
			MovieClipReader movieClipReader = new MovieClipReader();
			SwfAssetContext swfAssetContext = null;
			SwfAssetContext swfAssetContext3;
			try
			{
				swfAssetContext = movieClipReader.readSwfAssetContext(swfBinaryReader, swfUriTmp + "_");
				goto IL_0072;
			}
			catch (EndOfStreamException)
			{
				DebugUtils.LogError(LogCategory.GUI, "MovieClip() SwfSerializerException, corrupt swf '" + swfUri + "'");
				SwfAssetContext swfAssetContext2 = null;
				swfAssetContext3 = swfAssetContext2;
			}
			catch (SwfSerializerException ex)
			{
				DebugUtils.LogError(LogCategory.GUI, "MovieClip() SwfSerializerException, corrupt swf '" + swfUri + "', " + ex.Message);
				SwfAssetContext swfAssetContext4 = null;
				swfAssetContext3 = swfAssetContext4;
			}
			return swfAssetContext3;
			IL_0072:
			if (swfAssetContext == null)
			{
				DebugUtils.LogError(LogCategory.GUI, "MovieClip() assetContext == null, Invalid swf '" + swfUri + "'");
				return null;
			}
			if (UniTextureManager.instance == null)
			{
				new UniTextureManager();
			}
			swfAssetContext.textureManager = UniTextureManager.instance;
			swfAssetContext.resourceLoader = loader;
			swfAssetContext.assetBundle = useAssetBundle;
			MovieClipPlayer.getGlobalContextCache()[swfUri] = swfAssetContext;
			if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.SwfLoad) == MovieClipProfiler.SwfLoad)
			{
				DebugUtils.LogError(LogCategory.GUI, string.Concat(new object[]
				{
					"SwfProfile->SwfLoad: ",
					swfUri,
					", ",
					MovieClipPlayer.profilerSettings
				}));
			}
			BadAssSWFResourceLoader.cacheAssetContext(swfAssetContext);
			return swfAssetContext;
		}

		// Token: 0x06003544 RID: 13636 RVA: 0x000F1A8C File Offset: 0x000EFC8C
		protected static void cacheAssetContext(SwfAssetContext swfAssetContext)
		{
			string[] stringTable = swfAssetContext.stringTable;
			for (int i = 0; i < stringTable.Length; i++)
			{
				if (i > 0)
				{
					Material material = null;
					if (swfAssetContext.assetBundle != null)
					{
						material = UniTextureManager.instance.getBitmapData(swfAssetContext.assetBundle, BuiltinResourceLoader.fixAssetBundleUri(swfAssetContext.swfPrefix + stringTable[i]));
					}
					if (material == null)
					{
						material = UniTextureManager.instance.getBitmapData(swfAssetContext.swfPrefix + stringTable[i]);
					}
					if (material == null)
					{
						DebugUtils.LogWarning(LogCategory.GUI, "Missing texture : " + stringTable[i] + "in flash file:" + swfAssetContext.swfPrefix);
					}
				}
			}
		}

		// Token: 0x06003545 RID: 13637 RVA: 0x00022FB3 File Offset: 0x000211B3
		public override Material getCharMaterial(BitmapTextField txt, SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, BitmapFontCharInfo charInfo, BitmapAssetInfo bmpInfo)
		{
			return base.getCharMaterial(txt, assetContext, fontInfo, charInfo, bmpInfo);
		}

		// Token: 0x06003546 RID: 13638 RVA: 0x00022FC2 File Offset: 0x000211C2
		public override Material getMaterial(MovieClipPlayer player, SwfAssetContext assetContext, DisplayObjectInfo dispInfo, BitmapAssetInfo bmpInfo)
		{
			return base.getMaterial(player, assetContext, dispInfo, bmpInfo);
		}

		// Token: 0x06003547 RID: 13639 RVA: 0x00022FCF File Offset: 0x000211CF
		public virtual void removeOnlyAssetBundle(AssetBundle bundle)
		{
			this.enableAssetBundleResorceLoader = true;
			this.bundles.Remove(bundle);
		}

		// Token: 0x06003548 RID: 13640 RVA: 0x000F1B38 File Offset: 0x000EFD38
		public override SwfAssetContext loadSWF(string swfUri)
		{
			if (MovieClipPlayer.getGlobalContextCache().ContainsKey(swfUri))
			{
				return MovieClipPlayer.getGlobalContextCache()[swfUri];
			}
			string text = BuiltinResourceLoader.swfPrefix(swfUri, MovieClipPlayer.swfProfile);
			TextAsset textAsset = null;
			if (this.enableSceneAssetLoader && this.sceneAssets != null)
			{
				for (int i = 0; i < this.sceneAssets.Length; i++)
				{
					if (this.sceneAssets[i].resourceUri == text)
					{
						textAsset = this.sceneAssets[i].textAsset;
						if (textAsset != null)
						{
							break;
						}
					}
				}
			}
			AssetBundle assetBundle = null;
			if (textAsset == null && this.enableAssetBundleResorceLoader)
			{
				string text2 = BuiltinResourceLoader.fixAssetBundleUri(text);
				for (int j = 0; j < this.bundles.Count; j++)
				{
					AssetBundle assetBundle2 = this.bundles[j];
					if (MovieClipPlayer.swfProfile != null)
					{
						textAsset = (TextAsset)assetBundle2.Load(text2, typeof(TextAsset));
					}
					if (textAsset == null)
					{
						textAsset = (TextAsset)assetBundle2.Load(text2, typeof(TextAsset));
					}
					if (textAsset != null)
					{
						assetBundle = assetBundle2;
						break;
					}
				}
			}
			if (textAsset == null && this.enableLocalResorceLoader)
			{
				if (MovieClipPlayer.swfProfile != null)
				{
					textAsset = Resources.Load<TextAsset>("UI_uniSWF/SwfAssets/" + text);
					if (textAsset == null)
					{
						textAsset = Resources.Load<TextAsset>(text);
					}
				}
				if (textAsset == null)
				{
					text = BuiltinResourceLoader.swfPrefix(swfUri, null);
					textAsset = Resources.Load<TextAsset>("UI_uniSWF/SwfAssets/" + text);
					if (textAsset == null)
					{
						textAsset = Resources.Load<TextAsset>(text);
					}
				}
			}
			if (textAsset == null)
			{
				DebugUtils.LogError(LogCategory.GUI, string.Concat(new string[] { "MovieClip() Invalid asset url '", swfUri, "' actual url loaded '", text, "'" }));
				return null;
			}
			return BadAssSWFResourceLoader.loadFromTextAsset(this, textAsset, swfUri, text, assetBundle);
		}

		// Token: 0x040024C3 RID: 9411
		public const string Path_UI_IN_ASSETS = "Assets/ArtResources/UI_uniSWF/SwfAssets/";

		// Token: 0x040024C4 RID: 9412
		public const string Path_UI_IN_RESOURCES = "UI_uniSWF/SwfAssets/";

		// Token: 0x040024C5 RID: 9413
		private const string TYPE_NAME = ".bytes";
	}
}
