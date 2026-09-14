using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
public abstract class InputReader
{
	// Token: 0x06000CA8 RID: 3240
	public abstract bool GetKey(KeyCode key);

	// Token: 0x06000CA9 RID: 3241
	public abstract bool GetKey(string name);

	// Token: 0x06000CAA RID: 3242
	public abstract bool GetKeyDown(KeyCode key);

	// Token: 0x06000CAB RID: 3243
	public abstract bool GetKeyDown(string name);

	// Token: 0x06000CAC RID: 3244
	public abstract bool GetKeyUp(KeyCode key);

	// Token: 0x06000CAD RID: 3245
	public abstract float GetAxis(string axisName);

	// Token: 0x06000CAE RID: 3246
	public abstract bool GetButton(string buttonName);

	// Token: 0x06000CAF RID: 3247
	public abstract bool GetButtonDown(string buttonName);

	// Token: 0x06000CB0 RID: 3248
	public abstract bool GetButtonUp(string buttonName);

	// Token: 0x06000CB1 RID: 3249
	public abstract bool GetMouseButton(int button, bool bCareUI = false);

	// Token: 0x06000CB2 RID: 3250
	public abstract bool GetMouseButtonDown(int button, bool bCareUI = false);

	// Token: 0x06000CB3 RID: 3251
	public abstract bool GetMouseButtonUp(int button, bool bCareUI = false);
}
