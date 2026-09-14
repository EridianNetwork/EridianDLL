using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020005D2 RID: 1490
public class ObjectTrailEffectInterpolator
{
	// Token: 0x060025A2 RID: 9634 RVA: 0x00007599 File Offset: 0x00005799
	private static Vector3 smethod_0(Vector3 vector3_0)
	{
		return vector3_0;
	}

	// Token: 0x060025A3 RID: 9635 RVA: 0x0001986A File Offset: 0x00017A6A
	private static Vector3 smethod_1(Transform transform_0)
	{
		return transform_0.position;
	}

	// Token: 0x060025A4 RID: 9636 RVA: 0x000B651C File Offset: 0x000B471C
	private static IEnumerable<float> smethod_2(float float_0)
	{
		float elapsedTime = 0f;
		while (elapsedTime < float_0)
		{
			yield return elapsedTime;
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= float_0)
			{
				yield return elapsedTime;
			}
		}
	}
	// Token: 0x060025A5 RID: 9637 RVA: 0x000B6548 File Offset: 0x000B4748
	private static IEnumerable<float> smethod_3(int int_0, int int_1, int int_2)
	{
		for (int i = int_0; i <= int_1; i += int_2)
		{
			yield return i;
		}
	}
	// Token: 0x060025A6 RID: 9638 RVA: 0x000B6590 File Offset: 0x000B4790
	public static IEnumerator smethod_4(ObjectTrailEffectInterpolator.Function function_0, Vector3 vector3_0, Vector3 vector3_1, float float_0)
	{
		IEnumerable<float> enumerable = ObjectTrailEffectInterpolator.smethod_2(float_0);
		return ObjectTrailEffectInterpolator.smethod_6(function_0, vector3_0, vector3_1, float_0, enumerable);
	}

	// Token: 0x060025A7 RID: 9639 RVA: 0x000B65B0 File Offset: 0x000B47B0
	public static IEnumerator smethod_5(ObjectTrailEffectInterpolator.Function function_0, Vector3 vector3_0, Vector3 vector3_1, int int_0)
	{
		IEnumerable<float> enumerable = ObjectTrailEffectInterpolator.smethod_3(0, int_0 + 1, 1);
		return ObjectTrailEffectInterpolator.smethod_6(function_0, vector3_0, vector3_1, (float)(int_0 + 1), enumerable);
	}

	// Token: 0x060025A8 RID: 9640 RVA: 0x000B65D8 File Offset: 0x000B47D8
	private static IEnumerator smethod_6(ObjectTrailEffectInterpolator.Function function_0, Vector3 vector3_0, Vector3 vector3_1, float float_0, IEnumerable<float> ienumerable_0)
	{
		Vector3 distance = vector3_1 - vector3_0;
		foreach (float num in ienumerable_0)
		{
			float i = num;
			yield return ObjectTrailEffectInterpolator.smethod_7(function_0, vector3_0, distance, i, float_0);
		}
		yield break;
	}

	// Token: 0x060025A9 RID: 9641 RVA: 0x000B6634 File Offset: 0x000B4834
	private static Vector3 smethod_7(ObjectTrailEffectInterpolator.Function function_0, Vector3 vector3_0, Vector3 vector3_1, float float_0, float float_1)
	{
		vector3_0.x = function_0(vector3_0.x, vector3_1.x, float_0, float_1);
		vector3_0.y = function_0(vector3_0.y, vector3_1.y, float_0, float_1);
		vector3_0.z = function_0(vector3_0.z, vector3_1.z, float_0, float_1);
		return vector3_0;
	}

	// Token: 0x060025AA RID: 9642 RVA: 0x000B669C File Offset: 0x000B489C
	public static ObjectTrailEffectInterpolator.Function smethod_8(ObjectTrailEffectInterpolator.EaseType easeType_0)
	{
		ObjectTrailEffectInterpolator.Function function = null;
		switch (easeType_0)
		{
		case ObjectTrailEffectInterpolator.EaseType.Linear:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_19);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInQuad:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_20);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseOutQuad:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_21);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInOutQuad:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_22);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInCubic:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_23);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseOutCubic:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_24);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInOutCubic:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_25);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInQuart:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_26);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseOutQuart:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_27);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInOutQuart:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_28);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInQuint:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_29);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseOutQuint:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_30);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInOutQuint:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_31);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInSine:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_32);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseOutSine:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_33);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInOutSine:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_34);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInExpo:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_35);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseOutExpo:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_36);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInOutExpo:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_37);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInCirc:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_38);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseOutCirc:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_39);
			break;
		case ObjectTrailEffectInterpolator.EaseType.EaseInOutCirc:
			function = new ObjectTrailEffectInterpolator.Function(ObjectTrailEffectInterpolator.smethod_40);
			break;
		}
		return function;
	}

	// Token: 0x060025AB RID: 9643 RVA: 0x000B6880 File Offset: 0x000B4A80
	public static IEnumerable<Vector3> smethod_9(ObjectTrailEffectInterpolator.Function function_0, Transform[] transform_0, float float_0)
	{
		IEnumerable<float> enumerable = ObjectTrailEffectInterpolator.smethod_2(float_0);
		return ObjectTrailEffectInterpolator.smethod_13<Transform>(function_0, transform_0, new ObjectTrailEffectInterpolator.ToVector3<Transform>(ObjectTrailEffectInterpolator.smethod_1), float_0, enumerable);
	}

	// Token: 0x060025AC RID: 9644 RVA: 0x000B68AC File Offset: 0x000B4AAC
	public static IEnumerable<Vector3> smethod_10(ObjectTrailEffectInterpolator.Function function_0, Transform[] transform_0, int int_0)
	{
		IEnumerable<float> enumerable = ObjectTrailEffectInterpolator.smethod_3(0, int_0 + 1, 1);
		return ObjectTrailEffectInterpolator.smethod_13<Transform>(function_0, transform_0, new ObjectTrailEffectInterpolator.ToVector3<Transform>(ObjectTrailEffectInterpolator.smethod_1), (float)(int_0 + 1), enumerable);
	}

	// Token: 0x060025AD RID: 9645 RVA: 0x000B68DC File Offset: 0x000B4ADC
	public static IEnumerable<Vector3> smethod_11(ObjectTrailEffectInterpolator.Function function_0, Vector3[] vector3_0, float float_0)
	{
		IEnumerable<float> enumerable = ObjectTrailEffectInterpolator.smethod_2(float_0);
		return ObjectTrailEffectInterpolator.smethod_13<Vector3>(function_0, vector3_0, new ObjectTrailEffectInterpolator.ToVector3<Vector3>(ObjectTrailEffectInterpolator.smethod_0), float_0, enumerable);
	}

	// Token: 0x060025AE RID: 9646 RVA: 0x000B6908 File Offset: 0x000B4B08
	public static IEnumerable<Vector3> smethod_12(ObjectTrailEffectInterpolator.Function function_0, Vector3[] vector3_0, int int_0)
	{
		IEnumerable<float> enumerable = ObjectTrailEffectInterpolator.smethod_3(0, int_0 + 1, 1);
		return ObjectTrailEffectInterpolator.smethod_13<Vector3>(function_0, vector3_0, new ObjectTrailEffectInterpolator.ToVector3<Vector3>(ObjectTrailEffectInterpolator.smethod_0), (float)(int_0 + 1), enumerable);
	}

	// Token: 0x060025AF RID: 9647 RVA: 0x000B6938 File Offset: 0x000B4B38
	private static IEnumerable<Vector3> smethod_13<T>(ObjectTrailEffectInterpolator.Function function_0, IList ilist_0, ObjectTrailEffectInterpolator.ToVector3<T> toVector3_0, float float_0, IEnumerable<float> ienumerable_0)
	{
		if (ilist_0.Count >= 2)
		{
			Vector3[] points = new Vector3[ilist_0.Count];
			foreach (float num in ienumerable_0)
			{
				float step = num;
				for (int i = 0; i < ilist_0.Count; i++)
				{
					points[i] = toVector3_0((T)((object)ilist_0[i]));
				}
				yield return ObjectTrailEffectInterpolator.smethod_14(function_0, points, step, float_0);
			}
		}
		yield break;
	}

	// Token: 0x060025B0 RID: 9648 RVA: 0x000B699C File Offset: 0x000B4B9C
	private static Vector3 smethod_14(ObjectTrailEffectInterpolator.Function function_0, Vector3[] vector3_0, float float_0, float float_1)
	{
		for (int i = vector3_0.Length - 1; i > 0; i--)
		{
			for (int j = 0; j < i; j++)
			{
				vector3_0[j].x = function_0(vector3_0[j].x, vector3_0[j + 1].x - vector3_0[j].x, float_0, float_1);
				vector3_0[j].y = function_0(vector3_0[j].y, vector3_0[j + 1].y - vector3_0[j].y, float_0, float_1);
				vector3_0[j].z = function_0(vector3_0[j].z, vector3_0[j + 1].z - vector3_0[j].z, float_0, float_1);
			}
		}
		return vector3_0[0];
	}

	// Token: 0x060025B1 RID: 9649 RVA: 0x00019872 File Offset: 0x00017A72
	public static IEnumerable<Vector3> smethod_15(Transform[] transform_0, int int_0, bool bool_0)
	{
		return ObjectTrailEffectInterpolator.smethod_17<Transform>(transform_0, new ObjectTrailEffectInterpolator.ToVector3<Transform>(ObjectTrailEffectInterpolator.smethod_1), int_0, bool_0);
	}

	// Token: 0x060025B2 RID: 9650 RVA: 0x00019888 File Offset: 0x00017A88
	public static IEnumerable<Vector3> smethod_16(Vector3[] vector3_0, int int_0, bool bool_0)
	{
		return ObjectTrailEffectInterpolator.smethod_17<Vector3>(vector3_0, new ObjectTrailEffectInterpolator.ToVector3<Vector3>(ObjectTrailEffectInterpolator.smethod_0), int_0, bool_0);
	}

	// Token: 0x060025B3 RID: 9651 RVA: 0x000B6A90 File Offset: 0x000B4C90
	private static IEnumerable<Vector3> smethod_17<T>(IList ilist_0, ToVector3<T> toVector3_0, int int_0, bool bool_0)
	{
		if (ilist_0.Count < 2)
		{
			yield break;
		}
		yield return toVector3_0((T)ilist_0[0]);
		int last = ilist_0.Count - 1;
		for (int current = 0; bool_0 || current < last; current++)
		{
			if (bool_0 && current > last)
			{
				current = 0;
			}
			int previous = ((current != 0) ? (current - 1) : ((!bool_0) ? current : last));
			int start = current;
			int end = ((current != last) ? (current + 1) : ((!bool_0) ? current : 0));
			int next = ((end != last) ? (end + 1) : ((!bool_0) ? end : 0));
			int stepCount = int_0 + 1;
			for (int step = 1; step <= stepCount; step++)
			{
				yield return smethod_18(toVector3_0((T)ilist_0[previous]), toVector3_0((T)ilist_0[start]), toVector3_0((T)ilist_0[end]), toVector3_0((T)ilist_0[next]), step, stepCount);
			}
		}
	}
	// Token: 0x060025B4 RID: 9652 RVA: 0x000B6AE4 File Offset: 0x000B4CE4
	private static Vector3 smethod_18(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3, float float_0, float float_1)
	{
		float num = float_0 / float_1;
		float num2 = num * num;
		float num3 = num2 * num;
		return vector3_0 * (-0.5f * num3 + num2 - 0.5f * num) + vector3_1 * (1.5f * num3 + -2.5f * num2 + 1f) + vector3_2 * (-1.5f * num3 + 2f * num2 + 0.5f * num) + vector3_3 * (0.5f * num3 - 0.5f * num2);
	}

	// Token: 0x060025B5 RID: 9653 RVA: 0x0001989E File Offset: 0x00017A9E
	private static float smethod_19(float float_0, float float_1, float float_2, float float_3)
	{
		if (float_2 > float_3)
		{
			float_2 = float_3;
		}
		return float_1 * (float_2 / float_3) + float_0;
	}

	// Token: 0x060025B6 RID: 9654 RVA: 0x000198B0 File Offset: 0x00017AB0
	private static float smethod_20(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		return float_1 * float_2 * float_2 + float_0;
	}

	// Token: 0x060025B7 RID: 9655 RVA: 0x000198CB File Offset: 0x00017ACB
	private static float smethod_21(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		return -float_1 * float_2 * (float_2 - 2f) + float_0;
	}

	// Token: 0x060025B8 RID: 9656 RVA: 0x000B6B74 File Offset: 0x000B4D74
	private static float smethod_22(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / (float_3 / 2f)) : 2f);
		if (float_2 < 1f)
		{
			return float_1 / 2f * float_2 * float_2 + float_0;
		}
		float_2 -= 1f;
		return -float_1 / 2f * (float_2 * (float_2 - 2f) - 1f) + float_0;
	}

	// Token: 0x060025B9 RID: 9657 RVA: 0x000198ED File Offset: 0x00017AED
	private static float smethod_23(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		return float_1 * float_2 * float_2 * float_2 + float_0;
	}

	// Token: 0x060025BA RID: 9658 RVA: 0x0001990A File Offset: 0x00017B0A
	private static float smethod_24(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		float_2 -= 1f;
		return float_1 * (float_2 * float_2 * float_2 + 1f) + float_0;
	}

	// Token: 0x060025BB RID: 9659 RVA: 0x000B6BD4 File Offset: 0x000B4DD4
	private static float smethod_25(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / (float_3 / 2f)) : 2f);
		if (float_2 < 1f)
		{
			return float_1 / 2f * float_2 * float_2 * float_2 + float_0;
		}
		float_2 -= 2f;
		return float_1 / 2f * (float_2 * float_2 * float_2 + 2f) + float_0;
	}

	// Token: 0x060025BC RID: 9660 RVA: 0x00019938 File Offset: 0x00017B38
	private static float smethod_26(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		return float_1 * float_2 * float_2 * float_2 * float_2 + float_0;
	}

	// Token: 0x060025BD RID: 9661 RVA: 0x00019957 File Offset: 0x00017B57
	private static float smethod_27(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		float_2 -= 1f;
		return -float_1 * (float_2 * float_2 * float_2 * float_2 - 1f) + float_0;
	}

	// Token: 0x060025BE RID: 9662 RVA: 0x000B6C34 File Offset: 0x000B4E34
	private static float smethod_28(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / (float_3 / 2f)) : 2f);
		if (float_2 < 1f)
		{
			return float_1 / 2f * float_2 * float_2 * float_2 * float_2 + float_0;
		}
		float_2 -= 2f;
		return -float_1 / 2f * (float_2 * float_2 * float_2 * float_2 - 2f) + float_0;
	}

	// Token: 0x060025BF RID: 9663 RVA: 0x00019988 File Offset: 0x00017B88
	private static float smethod_29(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		return float_1 * float_2 * float_2 * float_2 * float_2 * float_2 + float_0;
	}

	// Token: 0x060025C0 RID: 9664 RVA: 0x000199A9 File Offset: 0x00017BA9
	private static float smethod_30(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		float_2 -= 1f;
		return float_1 * (float_2 * float_2 * float_2 * float_2 * float_2 + 1f) + float_0;
	}

	// Token: 0x060025C1 RID: 9665 RVA: 0x000B6C98 File Offset: 0x000B4E98
	private static float smethod_31(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / (float_3 / 2f)) : 2f);
		if (float_2 < 1f)
		{
			return float_1 / 2f * float_2 * float_2 * float_2 * float_2 * float_2 + float_0;
		}
		float_2 -= 2f;
		return float_1 / 2f * (float_2 * float_2 * float_2 * float_2 * float_2 + 2f) + float_0;
	}

	// Token: 0x060025C2 RID: 9666 RVA: 0x000199DB File Offset: 0x00017BDB
	private static float smethod_32(float float_0, float float_1, float float_2, float float_3)
	{
		if (float_2 > float_3)
		{
			float_2 = float_3;
		}
		return -float_1 * Mathf.Cos(float_2 / float_3 * 1.5707964f) + float_1 + float_0;
	}

	// Token: 0x060025C3 RID: 9667 RVA: 0x000199FB File Offset: 0x00017BFB
	private static float smethod_33(float float_0, float float_1, float float_2, float float_3)
	{
		if (float_2 > float_3)
		{
			float_2 = float_3;
		}
		return float_1 * Mathf.Sin(float_2 / float_3 * 1.5707964f) + float_0;
	}

	// Token: 0x060025C4 RID: 9668 RVA: 0x00019A18 File Offset: 0x00017C18
	private static float smethod_34(float float_0, float float_1, float float_2, float float_3)
	{
		if (float_2 > float_3)
		{
			float_2 = float_3;
		}
		return -float_1 / 2f * (Mathf.Cos(3.1415927f * float_2 / float_3) - 1f) + float_0;
	}

	// Token: 0x060025C5 RID: 9669 RVA: 0x00019A42 File Offset: 0x00017C42
	private static float smethod_35(float float_0, float float_1, float float_2, float float_3)
	{
		if (float_2 > float_3)
		{
			float_2 = float_3;
		}
		return float_1 * Mathf.Pow(2f, 10f * (float_2 / float_3 - 1f)) + float_0;
	}

	// Token: 0x060025C6 RID: 9670 RVA: 0x00019A6A File Offset: 0x00017C6A
	private static float smethod_36(float float_0, float float_1, float float_2, float float_3)
	{
		if (float_2 > float_3)
		{
			float_2 = float_3;
		}
		return float_1 * (-Mathf.Pow(2f, -10f * float_2 / float_3) + 1f) + float_0;
	}

	// Token: 0x060025C7 RID: 9671 RVA: 0x000B6D00 File Offset: 0x000B4F00
	private static float smethod_37(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / (float_3 / 2f)) : 2f);
		if (float_2 < 1f)
		{
			return float_1 / 2f * Mathf.Pow(2f, 10f * (float_2 - 1f)) + float_0;
		}
		float_2 -= 1f;
		return float_1 / 2f * (-Mathf.Pow(2f, -10f * float_2) + 2f) + float_0;
	}

	// Token: 0x060025C8 RID: 9672 RVA: 0x00019A93 File Offset: 0x00017C93
	private static float smethod_38(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		return -float_1 * (Mathf.Sqrt(1f - float_2 * float_2) - 1f) + float_0;
	}

	// Token: 0x060025C9 RID: 9673 RVA: 0x00019AC0 File Offset: 0x00017CC0
	private static float smethod_39(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / float_3) : 1f);
		float_2 -= 1f;
		return float_1 * Mathf.Sqrt(1f - float_2 * float_2) + float_0;
	}

	// Token: 0x060025CA RID: 9674 RVA: 0x000B6D7C File Offset: 0x000B4F7C
	private static float smethod_40(float float_0, float float_1, float float_2, float float_3)
	{
		float_2 = ((float_2 <= float_3) ? (float_2 / (float_3 / 2f)) : 2f);
		if (float_2 < 1f)
		{
			return -float_1 / 2f * (Mathf.Sqrt(1f - float_2 * float_2) - 1f) + float_0;
		}
		float_2 -= 2f;
		return float_1 / 2f * (Mathf.Sqrt(1f - float_2 * float_2) + 1f) + float_0;
	}

	// Token: 0x020005D3 RID: 1491
	public enum EaseType
	{
		// Token: 0x04001B47 RID: 6983
		Linear,
		// Token: 0x04001B48 RID: 6984
		EaseInQuad,
		// Token: 0x04001B49 RID: 6985
		EaseOutQuad,
		// Token: 0x04001B4A RID: 6986
		EaseInOutQuad,
		// Token: 0x04001B4B RID: 6987
		EaseInCubic,
		// Token: 0x04001B4C RID: 6988
		EaseOutCubic,
		// Token: 0x04001B4D RID: 6989
		EaseInOutCubic,
		// Token: 0x04001B4E RID: 6990
		EaseInQuart,
		// Token: 0x04001B4F RID: 6991
		EaseOutQuart,
		// Token: 0x04001B50 RID: 6992
		EaseInOutQuart,
		// Token: 0x04001B51 RID: 6993
		EaseInQuint,
		// Token: 0x04001B52 RID: 6994
		EaseOutQuint,
		// Token: 0x04001B53 RID: 6995
		EaseInOutQuint,
		// Token: 0x04001B54 RID: 6996
		EaseInSine,
		// Token: 0x04001B55 RID: 6997
		EaseOutSine,
		// Token: 0x04001B56 RID: 6998
		EaseInOutSine,
		// Token: 0x04001B57 RID: 6999
		EaseInExpo,
		// Token: 0x04001B58 RID: 7000
		EaseOutExpo,
		// Token: 0x04001B59 RID: 7001
		EaseInOutExpo,
		// Token: 0x04001B5A RID: 7002
		EaseInCirc,
		// Token: 0x04001B5B RID: 7003
		EaseOutCirc,
		// Token: 0x04001B5C RID: 7004
		EaseInOutCirc
	}

	// Token: 0x020005D4 RID: 1492
	// (Invoke) Token: 0x060025CC RID: 9676
	public delegate Vector3 ToVector3<T>(T v);

	// Token: 0x020005D5 RID: 1493
	// (Invoke) Token: 0x060025D0 RID: 9680
	public delegate float Function(float a, float b, float c, float d);
}
