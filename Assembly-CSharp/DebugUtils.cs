using System;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000A90 RID: 2704
public class DebugUtils : MonoSingleton<DebugUtils>
{
	// Token: 0x0600492C RID: 18732 RVA: 0x0002FD08 File Offset: 0x0002DF08
	[Conditional("ASSERTS")]
	public static void smethod_0(LogCategory logCategory_0, bool bool_0, string string_0)
	{
		if (!bool_0)
		{
			if (MonoSingleton<WebDebugManager>.Boolean_0)
			{
				MonoSingleton<WebDebugManager>.Instance.method_1(logCategory_0, LogType.Assert, string_0);
				return;
			}
			global::UnityEngine.Debug.LogException(new DebugUtils.AssertionFailure(logCategory_0.ToString() + ": " + string_0));
		}
	}

	// Token: 0x0600492D RID: 18733 RVA: 0x0002FD44 File Offset: 0x0002DF44
	[Conditional("ASSERTS")]
	public static void smethod_1(LogCategory logCategory_0, bool bool_0)
	{
		if (!bool_0)
		{
			if (MonoSingleton<WebDebugManager>.Boolean_0)
			{
				MonoSingleton<WebDebugManager>.Instance.method_1(logCategory_0, LogType.Assert, "Assert");
				return;
			}
			global::UnityEngine.Debug.LogException(new DebugUtils.AssertionFailure(logCategory_0.ToString()));
		}
	}

	// Token: 0x0600492E RID: 18734 RVA: 0x0000311B File Offset: 0x0000131B
	[Conditional("ASSERTS")]
	public static void smethod_2(LogCategory logCategory_0, string string_0)
	{
	}

	// Token: 0x0600492F RID: 18735 RVA: 0x0000311B File Offset: 0x0000131B
	public static void smethod_3(string string_0, bool bool_0 = true)
	{
	}

	// Token: 0x06004930 RID: 18736 RVA: 0x001304F4 File Offset: 0x0012E6F4
	public static void smethod_4(float float_0, float float_1, float float_2, float float_3, string string_0, Color color_0, int int_0 = 18)
	{
		GUIStyle guistyle = new GUIStyle();
		guistyle.fontSize = int_0;
		guistyle.normal.textColor = color_0;
		float num = (float)Screen.width * Mathf.Clamp(float_0, 0f, 1f);
		float num2 = (float)Screen.height * Mathf.Clamp(float_1, 0f, 1f);
		float num3 = (float)Screen.width * Mathf.Clamp(float_2, 0f, 1f - float_0);
		float num4 = (float)Screen.height * Mathf.Clamp(float_3, 0f, 1f - float_1);
		GUI.Label(new Rect(num, num2, num3, num4), string_0, guistyle);
	}

	// Token: 0x06004931 RID: 18737 RVA: 0x0002FD79 File Offset: 0x0002DF79
	public static GameObject smethod_5(PrimitiveType primitiveType_0, Color color_0)
	{
		return DebugUtils.smethod_6(primitiveType_0, color_0, Vector3.one, Vector3.zero);
	}

	// Token: 0x06004932 RID: 18738 RVA: 0x00130590 File Offset: 0x0012E790
	public static GameObject smethod_6(PrimitiveType primitiveType_0, Color color_0, Vector3 vector3_0, Vector3 vector3_1)
	{
		if (primitiveType_0 == PrimitiveType.Plane)
		{
			return null;
		}
		GameObject gameObject = GameObject.CreatePrimitive(primitiveType_0);
		if (gameObject != null && gameObject.renderer != null)
		{
			gameObject.transform.localScale = vector3_0;
			gameObject.transform.position = vector3_1;
			gameObject.renderer.material.color = color_0;
			if (gameObject.collider != null)
			{
				gameObject.collider.enabled = false;
			}
			if (gameObject.rigidbody != null)
			{
				gameObject.rigidbody.useGravity = false;
			}
		}
		return gameObject;
	}

	// Token: 0x06004933 RID: 18739 RVA: 0x00130620 File Offset: 0x0012E820
	public static GameObject smethod_7(PrimitiveType primitiveType_0, Color color_0, Vector3 vector3_0, Vector3 vector3_1)
	{
		if (primitiveType_0 == PrimitiveType.Plane)
		{
			return null;
		}
		Vector3 vector = Vector3.one * vector3_0.x * 1.5f;
		NavMeshHit navMeshHit;
		GameObject gameObject;
		if (NavMesh.SamplePosition(vector3_1 + Vector3.up, out navMeshHit, 2f, 2147483647))
		{
			gameObject = DebugUtils.smethod_6(PrimitiveType.Sphere, Color.green, vector, navMeshHit.position);
		}
		else
		{
			gameObject = DebugUtils.smethod_6(PrimitiveType.Sphere, Color.red, vector, vector3_1);
		}
		GameObject gameObject2 = DebugUtils.smethod_6(primitiveType_0, color_0, vector3_0, vector3_1);
		if (gameObject != null)
		{
			gameObject.transform.parent = gameObject2.transform;
		}
		return gameObject2;
	}

	// Token: 0x06004934 RID: 18740 RVA: 0x0002FD8C File Offset: 0x0002DF8C
	public static void Log(LogCategory logCategory_0, string string_0)
	{
		global::UnityEngine.Debug.Log(logCategory_0.ToString() + ": " + string_0);
	}

	// Token: 0x06004935 RID: 18741 RVA: 0x0002FDAB File Offset: 0x0002DFAB
	public static void LogWarning(LogCategory logCategory_0, string string_0)
	{
		global::UnityEngine.Debug.LogWarning(logCategory_0.ToString() + ": " + string_0);
	}

	// Token: 0x06004936 RID: 18742 RVA: 0x0002FDCA File Offset: 0x0002DFCA
	public static void LogError(LogCategory logCategory_0, string string_0)
	{
		DebugUtils.LogAssert(logCategory_0, string_0, Environment.StackTrace, false);
	}

	// Token: 0x06004937 RID: 18743 RVA: 0x001306B8 File Offset: 0x0012E8B8
	public static void smethod_11(Vector3 vector3_0, float float_0, Color color_0)
	{
		float num = float_0 / 2f;
		global::UnityEngine.Debug.DrawLine(vector3_0 - Vector3.up * num, vector3_0 + Vector3.up * num, color_0);
		global::UnityEngine.Debug.DrawLine(vector3_0 - Vector3.right * num, vector3_0 + Vector3.right * num, color_0);
		global::UnityEngine.Debug.DrawLine(vector3_0 - Vector3.forward * num, vector3_0 + Vector3.forward * num, color_0);
	}

	// Token: 0x06004938 RID: 18744 RVA: 0x00130748 File Offset: 0x0012E948
	public static void smethod_12(global::UnityEngine.Object object_0)
	{
		Profiler.enabled = true;
		DebugUtils.LogWarning(LogCategory.System, "<<<Profile Memory Usage>>> time: " + Time.time.ToString());
		DebugUtils.Log(LogCategory.System, "Used Heap Size: " + Profiler.usedHeapSize.ToString());
		DebugUtils.Log(LogCategory.System, "Mono Heap Size: " + Profiler.GetMonoHeapSize().ToString());
		DebugUtils.Log(LogCategory.System, "Mono Used Size: " + Profiler.GetMonoUsedSize().ToString());
		if (object_0 != null)
		{
			DebugUtils.Log(LogCategory.System, "[" + object_0.ToString() + "] runtime memory size: " + Profiler.GetRuntimeMemorySize(object_0).ToString());
		}
	}

	// Token: 0x06004939 RID: 18745 RVA: 0x00130808 File Offset: 0x0012EA08
	public static void smethod_13(int int_0)
	{
		DebugUtils.s_ignoreList.Add(int_0);
		int i = 0;
		while (i < DebugUtils.s_blueAssertMsgList.Count)
		{
			int hashCode = DebugUtils.s_blueAssertMsgList[i].GetHashCode();
			if (DebugUtils.s_ignoreList.Contains(hashCode))
			{
				DebugUtils.s_blueAssertMsgList.RemoveAt(i);
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600493A RID: 18746 RVA: 0x0013086C File Offset: 0x0012EA6C
	public static void LogAssert(LogCategory logCategory_0, string string_0, string string_1, bool bool_0 = false)
	{
		if (MonoSingleton<AppManager>.Instance == null)
		{
			return;
		}
		if (string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_debugInfo_Version))
		{
			return;
		}
		int num = AssertInfo.smethod_1(AssertInfo.smethod_0(), logCategory_0, string_0, string_1);
		DebugInfo debugInfo = new DebugInfo();
		debugInfo.hashcode = num;
		debugInfo.isFromHost = false;
		debugInfo.isWebPlayer = false;
		debugInfo.isWarning = bool_0;
		debugInfo.type = logCategory_0;
		debugInfo.callstack = string_1;
		debugInfo.message = string_0;
		if (MonoSingleton<Session>.Instance != null)
		{
			debugInfo.gameModeName = MonoSingleton<Session>.Instance.method_6();
			debugInfo.instanceName = MonoSingleton<Session>.Instance.method_1();
			debugInfo.mapName = MonoSingleton<Session>.Instance.method_5();
			debugInfo.difficulty = MonoSingleton<Session>.Instance.method_2();
		}
		if (MonoSingleton<LevelLoadingManager>.Instance != null)
		{
			debugInfo.currentStep = MonoSingleton<LevelLoadingManager>.Instance.method_2();
		}
		if (MonoSingleton<DebugInfoManager>.Instance != null)
		{
			MonoSingleton<DebugInfoManager>.Instance.method_1(debugInfo);
		}
	}

	// Token: 0x0600493B RID: 18747 RVA: 0x00130960 File Offset: 0x0012EB60
	[Conditional("ASSERTS")]
	public static void smethod_15(LogCategory logCategory_0, string string_0, string string_1, bool bool_0 = false)
	{
		int num = AssertInfo.smethod_1(AssertInfo.smethod_0(), logCategory_0, string_0, string_1);
		if (!DebugUtils.s_ignoreList.Contains(num))
		{
			if (bool_0)
			{
				return;
			}
			if (DebugUtils.s_blueAssertMsgList.Count < 8)
			{
				DebugUtils.s_blueAssertMsgList.Add(new AssertInfo(AssertInfo.smethod_0(), logCategory_0, string_0, string_1));
			}
		}
	}

	// Token: 0x0600493C RID: 18748 RVA: 0x0002FDD9 File Offset: 0x0002DFD9
	[Conditional("ASSERTS")]
	public static void smethod_16(LogCategory logCategory_0, string string_0, string string_1)
	{
		if (DebugUtils.s_blueAssertMsgList.Count < 8)
		{
			DebugUtils.s_blueAssertMsgList.Add(new AssertInfo(AssertInfo.InfoSource.FromHost, logCategory_0, string_0, string_1));
			DebugUtils.Log(LogCategory.FromHost, string.Format("{0}\n{1}", string_0, string_1));
		}
	}

	// Token: 0x040035A4 RID: 13732
	private const int BLUE_ASSERT_MSG_BUFFER_SIZE = 8;

	// Token: 0x040035A5 RID: 13733
	public static DebugInfoSync s_debugInfoSync = null;

	// Token: 0x040035A6 RID: 13734
	private static List<AssertInfo> s_blueAssertMsgList = new List<AssertInfo>(8);

	// Token: 0x040035A7 RID: 13735
	private static HashSet<int> s_ignoreList = new HashSet<int>();

	// Token: 0x02000A91 RID: 2705
	public class AssertionFailure : Exception
	{
		// Token: 0x0600493D RID: 18749 RVA: 0x0002FE0E File Offset: 0x0002E00E
		public AssertionFailure(string string_0)
			: base(string_0)
		{
		}
	}
}
