using System;
using ns0;
using UnityEngine;

// Token: 0x02000A9C RID: 2716
internal class PrefabPoolAsyncTask : AsyncTaskBase
{
	// Token: 0x06004970 RID: 18800 RVA: 0x00030014 File Offset: 0x0002E214
	public PrefabPoolAsyncTask(GameObject gameObject_0, float float_2, bool bool_0)
	{
		this.m_timer = new Utils.Timer();
		this.m_instance = gameObject_0;
		this.m_duration = float_2;
		this.m_reparent = bool_0;
	}

	// Token: 0x06004971 RID: 18801 RVA: 0x0003003C File Offset: 0x0002E23C
	public override void Start()
	{
		base.Start();
		this.m_timer.Start(this.m_duration);
	}

	// Token: 0x06004972 RID: 18802 RVA: 0x00030055 File Offset: 0x0002E255
	public override void Update(float time)
	{
		base.Update(time);
		if (this.m_timer.method_1() == 0f)
		{
			base.SetStatus(AsyncTaskStatus.Success);
		}
	}

	// Token: 0x17000779 RID: 1913
	// (get) Token: 0x06004973 RID: 18803 RVA: 0x00030077 File Offset: 0x0002E277
	public GameObject GameObject_0
	{
		get
		{
			return this.m_instance;
		}
	}

	// Token: 0x1700077A RID: 1914
	// (get) Token: 0x06004974 RID: 18804 RVA: 0x0003007F File Offset: 0x0002E27F
	public bool Boolean_0
	{
		get
		{
			return this.m_reparent;
		}
	}

	// Token: 0x040035D6 RID: 13782
	private GameObject m_instance;

	// Token: 0x040035D7 RID: 13783
	private float m_duration;

	// Token: 0x040035D8 RID: 13784
	private bool m_reparent;

	// Token: 0x040035D9 RID: 13785
	private Utils.Timer m_timer;
}
