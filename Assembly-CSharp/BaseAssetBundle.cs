using System;
using UnityEngine;

// Token: 0x020000CE RID: 206
public abstract class BaseAssetBundle
{
	// Token: 0x17000031 RID: 49
	// (get) Token: 0x060004CE RID: 1230
	public abstract global::UnityEngine.Object Object_0 { get; }

	// Token: 0x060004CF RID: 1231
	public abstract bool vmethod_0(string string_0);

	// Token: 0x060004D0 RID: 1232
	public abstract global::UnityEngine.Object vmethod_1(string string_0);

	// Token: 0x060004D1 RID: 1233
	public abstract global::UnityEngine.Object vmethod_2(string string_0, Type type_0);

	// Token: 0x060004D2 RID: 1234
	public abstract global::UnityEngine.Object[] vmethod_3();

	// Token: 0x060004D3 RID: 1235
	public abstract AssetBundleRequest vmethod_4(string string_0, Type type_0);

	// Token: 0x060004D4 RID: 1236
	public abstract void vmethod_5(bool bool_0);
}
