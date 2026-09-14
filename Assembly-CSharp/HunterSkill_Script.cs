using System;
using System.Collections;
using UnityEngine;

// Token: 0x020002BE RID: 702
public class HunterSkill_Script : MonoBehaviour
{
	// Token: 0x06000F20 RID: 3872 RVA: 0x0007482C File Offset: 0x00072A2C
	public void method_0()
	{
		base.gameObject.SetActive(true);
		float num = global::UnityEngine.Random.Range(this.m_lifeTimeMin, this.m_lifeTimeMax);
		base.StartCoroutine(this.method_1(num));
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x00074868 File Offset: 0x00072A68
	private IEnumerator method_1(float float_0)
	{
		yield return new WaitForSeconds(float_0);
		base.gameObject.SetActive(value: false);
	}
	// Token: 0x04000D69 RID: 3433
	public float m_lifeTimeMin = 1f;

	// Token: 0x04000D6A RID: 3434
	public float m_lifeTimeMax = 3f;
}
