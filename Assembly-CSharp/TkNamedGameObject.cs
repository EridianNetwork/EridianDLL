using System;
using Core;
using UnityEngine;

// Token: 0x02000B67 RID: 2919
public struct TkNamedGameObject
{
	// Token: 0x06004F50 RID: 20304 RVA: 0x00033BAA File Offset: 0x00031DAA
	public TkNamedGameObject(string string_0, string string_1 = null, GameObject gameObject_0 = null)
	{
		this.name = string_0;
		this.prefab = string_1;
		this.obj = gameObject_0;
	}

	// Token: 0x17000802 RID: 2050
	// (get) Token: 0x06004F51 RID: 20305 RVA: 0x0015074C File Offset: 0x0014E94C
	public GameObject GameObject_0
	{
		get
		{
			if (!this.obj)
			{
				this.obj = GameObject.Find("/" + this.name);
			}
			if (!this.obj)
			{
				if (string.IsNullOrEmpty(this.prefab))
				{
					this.obj = new GameObject(this.name);
				}
				else
				{
					this.obj = Tk.smethod_13(this.prefab);
					if (!this.obj)
					{
						DebugUtils.LogError(LogCategory.Default, "Cannot load GameObject");
					}
				}
			}
			return this.obj;
		}
	}

	// Token: 0x17000803 RID: 2051
	// (get) Token: 0x06004F52 RID: 20306 RVA: 0x00033BC1 File Offset: 0x00031DC1
	public Transform Transform_0
	{
		get
		{
			return this.GameObject_0.transform;
		}
	}

	// Token: 0x04003B57 RID: 15191
	private string name;

	// Token: 0x04003B58 RID: 15192
	private string prefab;

	// Token: 0x04003B59 RID: 15193
	private GameObject obj;
}
