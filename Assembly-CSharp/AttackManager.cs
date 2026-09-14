using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x0200056F RID: 1391
public class AttackManager : MonoSingleton<AttackManager>
{
	// Token: 0x060023BF RID: 9151 RVA: 0x000A99BC File Offset: 0x000A7BBC
	public void method_0()
	{
		this.m_sortedList.Clear();
		Dictionary<double, List<AttackInfo>>.Enumerator enumerator = this.m_attacInfoDic.GetEnumerator();
		while (enumerator.MoveNext())
		{
			List<double> sortedList = this.m_sortedList;
			KeyValuePair<double, List<AttackInfo>> keyValuePair = enumerator.Current;
			sortedList.Add(keyValuePair.Key);
		}
		this.m_sortedList.Sort();
		for (int i = 0; i < this.m_sortedList.Count; i++)
		{
			double num = this.m_sortedList[i];
			List<AttackInfo> list = this.m_attacInfoDic[num];
			for (int j = 0; j < list.Count; j++)
			{
				AttackInfo attackInfo = list[j];
				if (attackInfo.method_0() == AttackInfo.AttackType.Projectile && attackInfo.m_subType != AttackSubType.ProjectileSpit)
				{
					if (attackInfo.m_subType != AttackSubType.ProjectileAxe)
					{
						this.m_bulletResolver.imethod_0(attackInfo);
					}
				}
				if (attackInfo.method_0() == AttackInfo.AttackType.Skill)
				{
					this.m_bulletResolver.imethod_0(attackInfo);
				}
			}
		}
		this.m_attacInfoDic.Clear();
	}

	// Token: 0x060023C0 RID: 9152 RVA: 0x000A9AB4 File Offset: 0x000A7CB4
	public void method_1(AttackInfo attackInfo_0)
	{
		if (!this.m_attacInfoDic.ContainsKey(attackInfo_0.m_timeStamp))
		{
			this.m_attacInfoDic[attackInfo_0.m_timeStamp] = new List<AttackInfo>();
		}
		this.m_attacInfoDic[attackInfo_0.m_timeStamp].Add(attackInfo_0);
	}

	// Token: 0x04001873 RID: 6259
	private BulletResolver m_bulletResolver = new BulletResolver();

	// Token: 0x04001874 RID: 6260
	private Dictionary<double, List<AttackInfo>> m_attacInfoDic = new Dictionary<double, List<AttackInfo>>();

	// Token: 0x04001875 RID: 6261
	private List<double> m_sortedList = new List<double>();
}
