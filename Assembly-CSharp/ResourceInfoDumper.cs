using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns0;
using UnityEngine;

// Token: 0x02000658 RID: 1624
public class ResourceInfoDumper
{
	// Token: 0x06002902 RID: 10498 RVA: 0x000C17DC File Offset: 0x000BF9DC
	public static void smethod_0(string string_0 = "", string string_1 = "ResourceInfo.txt")
	{
		ResourceInfoDumper.s_includePrefab = !ResourceInfoDumper.s_includePrefab;
		StringBuilder stringBuilder = new StringBuilder(1024);
		if (MonoSingleton<Session>.Instance != null && !string.IsNullOrEmpty(MonoSingleton<Session>.Instance.method_5()))
		{
			stringBuilder.AppendLine("CurrentScene:" + MonoSingleton<Session>.Instance.method_5());
		}
		uint num;
		uint num2;
		WindowsDLLHandler.smethod_1(out num, out num2);
		stringBuilder.AppendLine("Cur:" + num / 1048576f + "Mb");
		stringBuilder.AppendLine("Peak:" + num2 / 1048576f + "Mb");
		stringBuilder.AppendLine("usedHeapSize:" + Profiler.usedHeapSize / 1048576f + "Mb");
		stringBuilder.AppendLine("GetMonoHeapSize:" + Profiler.GetMonoHeapSize() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetMonoUsedSize:" + Profiler.GetMonoUsedSize() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetTotalAllocatedMemory:" + Profiler.GetTotalAllocatedMemory() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetTotalReservedMemory:" + Profiler.GetTotalReservedMemory() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetTotalUnusedReservedMemory:" + Profiler.GetTotalUnusedReservedMemory() / 1048576f + "Mb");
		if (MonoSingleton<AssetBundleManager>.Instance != null)
		{
			foreach (KeyValuePair<string, BaseAssetBundle> keyValuePair in MonoSingleton<AssetBundleManager>.Instance.Dictionary_0)
			{
				stringBuilder.AppendLine("Assetbundle:" + keyValuePair.Key);
			}
		}
		HashSet<global::UnityEngine.Object> hashSet = new HashSet<global::UnityEngine.Object>();
		global::UnityEngine.Object[] array = ResourceInfoDumper.smethod_1(typeof(Texture));
		hashSet.UnionWith(array);
		ResourceInfoDumper.smethod_3("Texture:", array, stringBuilder);
		global::UnityEngine.Object[] array2 = ResourceInfoDumper.smethod_1(typeof(AudioClip));
		hashSet.UnionWith(array2);
		ResourceInfoDumper.smethod_3("AudioClip:", array2, stringBuilder);
		global::UnityEngine.Object[] array3 = ResourceInfoDumper.smethod_1(typeof(Mesh));
		hashSet.UnionWith(array3);
		ResourceInfoDumper.smethod_3("Mesh:", array3, stringBuilder);
		global::UnityEngine.Object[] array4 = ResourceInfoDumper.smethod_1(typeof(Material));
		hashSet.UnionWith(array4);
		ResourceInfoDumper.smethod_3("Material:", array4, stringBuilder);
		global::UnityEngine.Object[] array5 = ResourceInfoDumper.smethod_1(typeof(GameObject));
		hashSet.UnionWith(array5);
		ResourceInfoDumper.smethod_3("GameObject:", array5, stringBuilder);
		global::UnityEngine.Object[] array6 = ResourceInfoDumper.smethod_1(typeof(Component));
		hashSet.UnionWith(array6);
		ResourceInfoDumper.smethod_3("Component:", array6, stringBuilder);
		global::UnityEngine.Object[] array7 = ResourceInfoDumper.smethod_1(typeof(AnimationClip));
		hashSet.UnionWith(array7);
		ResourceInfoDumper.smethod_3("Animation:", array7, stringBuilder);
		global::UnityEngine.Object[] array8 = ResourceInfoDumper.smethod_1(typeof(global::UnityEngine.Object));
		List<global::UnityEngine.Object> list = new List<global::UnityEngine.Object>();
		for (int i = 0; i < array8.Length; i++)
		{
			if (!hashSet.Contains(array8[i]))
			{
				list.Add(array8[i]);
			}
		}
		ResourceInfoDumper.smethod_3("Object:", list.ToArray(), stringBuilder);
		ResourceInfoDumper.smethod_4(string_0, string_1, stringBuilder);
	}

	// Token: 0x06002903 RID: 10499 RVA: 0x0001AF16 File Offset: 0x00019116
	private static global::UnityEngine.Object[] smethod_1(Type type_0)
	{
		if (ResourceInfoDumper.s_includePrefab)
		{
			return Resources.FindObjectsOfTypeAll(type_0);
		}
		return global::UnityEngine.Object.FindObjectsOfType(type_0);
	}

	// Token: 0x06002904 RID: 10500 RVA: 0x000C1B5C File Offset: 0x000BFD5C
	private static void smethod_2(string string_0, string[] string_1, StringBuilder stringBuilder_0)
	{
		for (int i = 0; i < string_1.Length; i++)
		{
			stringBuilder_0.AppendLine(string_0 + string_1[i]);
		}
	}

	// Token: 0x06002905 RID: 10501 RVA: 0x000C1B88 File Offset: 0x000BFD88
	public static void smethod_3(string string_0, global::UnityEngine.Object[] object_0, StringBuilder stringBuilder_0)
	{
		float num = 0f;
		List<string> list = new List<string>();
		for (int i = 0; i < object_0.Length; i++)
		{
			string text = string.Empty;
			if (global::Debug.Boolean_0)
			{
				float num2 = (float)Profiler.GetRuntimeMemorySize(object_0[i]) / 1048576f;
				text = string.Empty + num2 + "mb ";
				num += num2;
				text += " ";
				text += object_0[i].name;
				text += " ";
				text += object_0[i].GetType().ToString();
				if (object_0[i] is Material)
				{
					if (((Material)object_0[i]).mainTexture == null)
					{
						text += " null";
					}
					else
					{
						text += " tex:";
						text += ((Material)object_0[i]).mainTexture.GetType().ToString();
						text += " ";
						text += ((Material)object_0[i]).mainTexture.name;
					}
				}
			}
			list.Add(text);
		}
		list.Sort();
		ResourceInfoDumper.smethod_2(string_0, list.ToArray(), stringBuilder_0);
		stringBuilder_0.AppendLine(string.Format("total of {0}: {1}", string_0, num));
	}

	// Token: 0x06002906 RID: 10502 RVA: 0x000C1CDC File Offset: 0x000BFEDC
	private static void smethod_4(string string_0, string string_1, StringBuilder stringBuilder_0)
	{
		string text = DateTime.Now.ToString("yy_MM_dd_H_mm_ss_");
		string text2 = ((!ResourceInfoDumper.s_includePrefab) ? "SceneObjects_" : "AllObjects_");
		StreamWriter streamWriter = new StreamWriter(string.Concat(new string[] { string_0, text2, text, "_client_", string_1 }));
		streamWriter.Write(stringBuilder_0.ToString());
		streamWriter.Close();
	}

	// Token: 0x04001D5A RID: 7514
	public static bool s_includePrefab = true;
}
