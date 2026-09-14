using System;
using System.Collections;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000B11 RID: 2833
public static class Extensions
{
	// Token: 0x06004CB7 RID: 19639 RVA: 0x00031E53 File Offset: 0x00030053
	public static PhotonView[] GetPhotonViewsInChildren(this GameObject gameObject_0)
	{
		return gameObject_0.GetComponentsInChildren<PhotonView>(true);
	}

	// Token: 0x06004CB8 RID: 19640 RVA: 0x00031E00 File Offset: 0x00030000
	public static PhotonView GetPhotonView(this GameObject gameObject_0)
	{
		return gameObject_0.GetComponent<PhotonView>();
	}

	// Token: 0x06004CB9 RID: 19641 RVA: 0x00142828 File Offset: 0x00140A28
	public static bool AlmostEquals(this Vector3 vector3_0, Vector3 vector3_1, float float_0)
	{
		return vector3_0.x.AlmostEquals(vector3_1.x, float_0) && vector3_0.y.AlmostEquals(vector3_1.y, float_0) && vector3_0.z.AlmostEquals(vector3_1.z, float_0);
	}

	// Token: 0x06004CBA RID: 19642 RVA: 0x00031E5C File Offset: 0x0003005C
	public static bool AlmostEquals(this Vector2 vector2_0, Vector2 vector2_1, float float_0)
	{
		return vector2_0.x.AlmostEquals(vector2_1.x, float_0) && vector2_0.y.AlmostEquals(vector2_1.y, float_0);
	}

	// Token: 0x06004CBB RID: 19643 RVA: 0x00142878 File Offset: 0x00140A78
	public static bool AlmostEquals(this Quaternion quaternion_0, Quaternion quaternion_1, float float_0)
	{
		return quaternion_0.x.AlmostEquals(quaternion_1.x, float_0) && quaternion_0.y.AlmostEquals(quaternion_1.y, float_0) && quaternion_0.z.AlmostEquals(quaternion_1.z, float_0) && quaternion_0.w.AlmostEquals(quaternion_1.w, float_0);
	}

	// Token: 0x06004CBC RID: 19644 RVA: 0x00031E8B File Offset: 0x0003008B
	public static bool AlmostEquals(this float float_0, float float_1, float float_2)
	{
		return Mathf.Abs(float_0 - float_1) < float_2;
	}

	// Token: 0x06004CBD RID: 19645 RVA: 0x001428E0 File Offset: 0x00140AE0
	public static void Merge(this IDictionary idictionary_0, IDictionary idictionary_1)
	{
		if (idictionary_1 != null && !idictionary_0.Equals(idictionary_1))
		{
			foreach (object obj in idictionary_1.Keys)
			{
				idictionary_0[obj] = idictionary_1[obj];
			}
			return;
		}
	}

	// Token: 0x06004CBE RID: 19646 RVA: 0x0014294C File Offset: 0x00140B4C
	public static void MergeStringKeys(this IDictionary idictionary_0, IDictionary idictionary_1)
	{
		if (idictionary_1 != null && !idictionary_0.Equals(idictionary_1))
		{
			foreach (object obj in idictionary_1.Keys)
			{
				if (obj is string)
				{
					idictionary_0[obj] = idictionary_1[obj];
				}
			}
			return;
		}
	}

	// Token: 0x06004CBF RID: 19647 RVA: 0x00031E98 File Offset: 0x00030098
	public static string ToStringFull(this IDictionary idictionary_0)
	{
		return SupportClass.DictionaryToString(idictionary_0, false);
	}

	// Token: 0x06004CC0 RID: 19648 RVA: 0x001429C0 File Offset: 0x00140BC0
	public static Hashtable StripToStringKeys(this IDictionary idictionary_0)
	{
		Hashtable hashtable = new Hashtable();
		foreach (object obj in idictionary_0)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			if (dictionaryEntry.Key is string)
			{
				hashtable[dictionaryEntry.Key] = dictionaryEntry.Value;
			}
		}
		return hashtable;
	}

	// Token: 0x06004CC1 RID: 19649 RVA: 0x00142A38 File Offset: 0x00140C38
	public static void StripKeysWithNullValues(this IDictionary idictionary_0)
	{
		object[] array = new object[idictionary_0.Count];
		idictionary_0.Keys.CopyTo(array, 0);
		foreach (object obj in array)
		{
			if (idictionary_0[obj] == null)
			{
				idictionary_0.Remove(obj);
			}
		}
	}

	// Token: 0x06004CC2 RID: 19650 RVA: 0x00142A80 File Offset: 0x00140C80
	public static bool Contains(this int[] int_0, int int_1)
	{
		for (int i = 0; i < int_0.Length; i++)
		{
			if (int_0[i] == int_1)
			{
				return true;
			}
		}
		return false;
	}
}
