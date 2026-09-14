using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x02000A9D RID: 2717
internal class PrefabPool
{
	// Token: 0x06004975 RID: 18805 RVA: 0x00131634 File Offset: 0x0012F834
	public PrefabPool(GameObject gameObject_0, GameObject gameObject_1)
	{
		this.m_template = gameObject_0;
		this.m_go = new GameObject();
		global::UnityEngine.Object.DontDestroyOnLoad(this.m_go);
		this.m_go.hideFlags = HideFlags.DontSave;
		this.m_go.name = gameObject_0.name + "_released";
		this.m_description = "PrefabPool[ " + gameObject_0.name + " ]";
		if (null != gameObject_1)
		{
			Utils.smethod_20(this.m_go, gameObject_1);
		}
	}

	// Token: 0x1700077B RID: 1915
	// (get) Token: 0x06004976 RID: 18806 RVA: 0x00030087 File Offset: 0x0002E287
	public string String_0
	{
		get
		{
			return (!(null != this.m_template)) ? null : this.m_template.name;
		}
	}

	// Token: 0x06004977 RID: 18807 RVA: 0x000300A5 File Offset: 0x0002E2A5
	public string method_0()
	{
		return this.m_description;
	}

	// Token: 0x06004978 RID: 18808 RVA: 0x001316D4 File Offset: 0x0012F8D4
	private GameObject method_1()
	{
		GameObject gameObject = null;
		if (this.m_pool.Count > 0)
		{
			int num = this.m_pool.Count - 1;
			int num2 = num;
			while (num2 >= 0 && null == this.m_pool[num2])
			{
				num2--;
			}
			if (num2 == -1)
			{
				this.m_pool.Clear();
			}
			else
			{
				gameObject = this.m_pool[num2];
				this.m_pool.RemoveRange(num2, this.m_pool.Count - num2);
			}
		}
		return gameObject;
	}

	// Token: 0x06004979 RID: 18809 RVA: 0x00131758 File Offset: 0x0012F958
	public GameObject method_2(GameObject gameObject_0)
	{
		GameObject gameObject = this.method_1();
		if (null == gameObject)
		{
			gameObject = this.method_5();
		}
		if (null != gameObject_0 && this.m_go != null)
		{
			Utils.smethod_20(gameObject, gameObject_0);
		}
		return gameObject;
	}

	// Token: 0x0600497A RID: 18810 RVA: 0x000300AD File Offset: 0x0002E2AD
	public void method_3(GameObject gameObject_0, float float_0, bool bool_0 = true)
	{
		MonoSingleton<AsyncTaskManager>.Instance.method_1(new PrefabPoolAsyncTask(gameObject_0, float_0, bool_0), new TaskCompletedDelegate(this.OnDelayElapse));
	}

	// Token: 0x0600497B RID: 18811 RVA: 0x0013179C File Offset: 0x0012F99C
	private void OnDelayElapse(AsyncTaskBase task, AsyncTaskStatus result)
	{
		PrefabPoolAsyncTask prefabPoolAsyncTask = task as PrefabPoolAsyncTask;
		if (prefabPoolAsyncTask.IsStatus())
		{
			GameObject gameObject_ = prefabPoolAsyncTask.GameObject_0;
			if (gameObject_ != null)
			{
				this.method_4(prefabPoolAsyncTask.GameObject_0, prefabPoolAsyncTask.Boolean_0);
			}
		}
	}

	// Token: 0x0600497C RID: 18812 RVA: 0x000300CD File Offset: 0x0002E2CD
	public void method_4(GameObject gameObject_0, bool bool_0 = true)
	{
		if (bool_0 && this.m_go != null)
		{
			Utils.smethod_20(gameObject_0, this.m_go);
		}
		this.m_pool.Add(gameObject_0);
	}

	// Token: 0x0600497D RID: 18813 RVA: 0x001317DC File Offset: 0x0012F9DC
	public void Reset()
	{
		int count = this.m_pool.Count;
		for (int i = 0; i < count; i++)
		{
			Tk.smethod_50(this.m_pool[i]);
		}
		this.m_pool.Clear();
		Tk.smethod_50(this.m_go);
		this.m_template = null;
	}

	// Token: 0x0600497E RID: 18814 RVA: 0x00131830 File Offset: 0x0012FA30
	private GameObject method_5()
	{
		GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.m_template);
		gameObject.hideFlags = HideFlags.DontSave;
		global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
		gameObject.name = this.m_template.name;
		return gameObject;
	}

	// Token: 0x040035DA RID: 13786
	private GameObject m_go;

	// Token: 0x040035DB RID: 13787
	private GameObject m_template;

	// Token: 0x040035DC RID: 13788
	private List<GameObject> m_pool = new List<GameObject>();

	// Token: 0x040035DD RID: 13789
	private string m_description = "Empty PrefabPool";
}
