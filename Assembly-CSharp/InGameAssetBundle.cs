using System;
using Core;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class InGameAssetBundle : BaseAssetBundle
{
	// Token: 0x060004D5 RID: 1237 RVA: 0x00006549 File Offset: 0x00004749
	public InGameAssetBundle(WWW www_0)
	{
		this.m_www = www_0;
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x0004BF28 File Offset: 0x0004A128
	private AssetBundle method_0()
	{
		if (null == this.m_assetBundle && this.m_www != null && null != this.m_www.assetBundle)
		{
			this.m_assetBundle = this.m_www.assetBundle;
		}
		return this.m_assetBundle;
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x0004BF78 File Offset: 0x0004A178
	private bool method_1(string string_0)
	{
		bool flag = false;
		if (this.m_www != null)
		{
			if (!string.IsNullOrEmpty(this.m_www.error))
			{
				DebugUtils.LogError(LogCategory.Framework, string_0 + " has WWW error: " + this.m_www.error);
			}
			else if (null == this.m_www.assetBundle)
			{
				DebugUtils.LogError(LogCategory.Framework, string_0 + ": not an asset bundle");
			}
			else if (null == this.method_0())
			{
				DebugUtils.LogError(LogCategory.Framework, string_0 + ": couldn't decrypt asset bundle");
			}
			else
			{
				flag = true;
			}
		}
		return flag;
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00006558 File Offset: 0x00004758
	public override global::UnityEngine.Object Object_0
	{
		get
		{
			return (!this.method_1("mainAsset")) ? null : this.method_0().mainAsset;
		}
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x00006575 File Offset: 0x00004775
	public override bool vmethod_0(string string_0)
	{
		return this.method_1("Contains") && this.method_0().Contains(string_0);
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x00006593 File Offset: 0x00004793
	public override global::UnityEngine.Object vmethod_1(string string_0)
	{
		return (!this.method_1("Load")) ? null : this.method_0().Load(string_0);
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x000065B1 File Offset: 0x000047B1
	public override global::UnityEngine.Object vmethod_2(string string_0, Type type_0)
	{
		return (!this.method_1("Load")) ? null : this.method_0().Load(string_0, type_0);
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x000065D0 File Offset: 0x000047D0
	public override global::UnityEngine.Object[] vmethod_3()
	{
		return (!this.method_1("LoadAll")) ? null : this.method_0().LoadAll();
	}

	// Token: 0x060004DD RID: 1245 RVA: 0x000065ED File Offset: 0x000047ED
	public override AssetBundleRequest vmethod_4(string string_0, Type type_0)
	{
		return (!this.method_1("LoadAsync")) ? null : this.method_0().LoadAsync(string_0, type_0);
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x0000660C File Offset: 0x0000480C
	public override void vmethod_5(bool bool_0)
	{
		if (this.method_1("Unload"))
		{
			this.method_0().Unload(bool_0);
			this.m_assetBundle = null;
			this.m_www.Dispose();
			this.m_www = null;
		}
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x00006640 File Offset: 0x00004840
	public void method_2()
	{
		if (this.m_www == null)
		{
			return;
		}
		this.vmethod_5(false);
	}

	// Token: 0x04000499 RID: 1177
	public WWW m_www;

	// Token: 0x0400049A RID: 1178
	public AssetBundle m_assetBundle;
}
