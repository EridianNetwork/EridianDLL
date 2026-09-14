using System;
using ns0;
using UnityEngine;

// Token: 0x02000581 RID: 1409
[AddComponentMenu("Physics/WeakPoint")]
[Serializable]
public class WeakPoint : MonoBehaviour
{
	// Token: 0x06002443 RID: 9283 RVA: 0x00018BCE File Offset: 0x00016DCE
	public Collider method_0()
	{
		return this.m_collider;
	}

	// Token: 0x06002444 RID: 9284 RVA: 0x00018BD6 File Offset: 0x00016DD6
	public bool method_1()
	{
		return this.m_partInfo == WeakPoint.PartInfo.Armor_Back || this.m_partInfo == WeakPoint.PartInfo.Armor_Front || this.m_partInfo == WeakPoint.PartInfo.Armor_Left || this.m_partInfo == WeakPoint.PartInfo.Armor_Right;
	}

	// Token: 0x06002445 RID: 9285 RVA: 0x00018BFF File Offset: 0x00016DFF
	private void Awake()
	{
		this.m_vInitPos = base.transform.localPosition;
		this.m_initRotation = base.transform.localRotation;
		this.m_collider = base.GetComponent<Collider>();
	}

	// Token: 0x06002446 RID: 9286 RVA: 0x00018C2F File Offset: 0x00016E2F
	public void method_2()
	{
		base.transform.localPosition = this.m_vInitPos;
		base.transform.localRotation = this.m_initRotation;
	}

	// Token: 0x06002447 RID: 9287 RVA: 0x00018C53 File Offset: 0x00016E53
	public WeakPoint.StrengthType method_3()
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			return this.m_strengthType;
		}
		if (!MonoSingleton<Session>.Instance.method_12())
		{
			return this.m_strengthType;
		}
		return this.m_strengthTypeForPvP;
	}

	// Token: 0x040018DF RID: 6367
	public WeakPoint.DamagePropagationType m_damagePropagationType;

	// Token: 0x040018E0 RID: 6368
	public WeakPoint.StrengthType m_strengthType = WeakPoint.StrengthType.Normal;

	// Token: 0x040018E1 RID: 6369
	public WeakPoint.StrengthType m_strengthTypeForPvP = WeakPoint.StrengthType.Normal;

	// Token: 0x040018E2 RID: 6370
	public WeakPoint.MatterType m_matterType;

	// Token: 0x040018E3 RID: 6371
	public WeakPoint.PartInfo m_partInfo;

	// Token: 0x040018E4 RID: 6372
	public bool m_isDefaultWeakPoint;

	// Token: 0x040018E5 RID: 6373
	private Collider m_collider;

	// Token: 0x040018E6 RID: 6374
	private Vector3 m_vInitPos;

	// Token: 0x040018E7 RID: 6375
	private Quaternion m_initRotation;

	// Token: 0x02000582 RID: 1410
	public enum MatterType
	{
		// Token: 0x040018E9 RID: 6377
		INVALID = -1,
		// Token: 0x040018EA RID: 6378
		Flesh,
		// Token: 0x040018EB RID: 6379
		Armor,
		// Token: 0x040018EC RID: 6380
		MAX
	}

	// Token: 0x02000583 RID: 1411
	public enum StrengthType
	{
		// Token: 0x040018EE RID: 6382
		INVALID = -1,
		// Token: 0x040018EF RID: 6383
		VeryWeak,
		// Token: 0x040018F0 RID: 6384
		Weak,
		// Token: 0x040018F1 RID: 6385
		Normal,
		// Token: 0x040018F2 RID: 6386
		Strong,
		// Token: 0x040018F3 RID: 6387
		VeryStrong,
		// Token: 0x040018F4 RID: 6388
		Indestructible,
		// Token: 0x040018F5 RID: 6389
		MAX
	}

	// Token: 0x02000584 RID: 1412
	public enum DamagePropagationType
	{
		// Token: 0x040018F7 RID: 6391
		INVALID = -1,
		// Token: 0x040018F8 RID: 6392
		ApplyToOwner,
		// Token: 0x040018F9 RID: 6393
		ApplyToSelf,
		// Token: 0x040018FA RID: 6394
		MAX
	}

	// Token: 0x02000585 RID: 1413
	public enum PartInfo
	{
		// Token: 0x040018FC RID: 6396
		None,
		// Token: 0x040018FD RID: 6397
		Head,
		// Token: 0x040018FE RID: 6398
		Body,
		// Token: 0x040018FF RID: 6399
		Hand,
		// Token: 0x04001900 RID: 6400
		Foot,
		// Token: 0x04001901 RID: 6401
		Armor_Left,
		// Token: 0x04001902 RID: 6402
		Armor_Right,
		// Token: 0x04001903 RID: 6403
		Armor_Back,
		// Token: 0x04001904 RID: 6404
		Armor_Front,
		// Token: 0x04001905 RID: 6405
		ExtraPart
	}
}
