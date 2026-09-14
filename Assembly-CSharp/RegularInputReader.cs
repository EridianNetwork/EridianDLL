using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class RegularInputReader : InputReader
{
	// Token: 0x06000CB5 RID: 3253 RVA: 0x0000C158 File Offset: 0x0000A358
	public override bool GetKey(KeyCode key)
	{
		return Input.GetKey(key);
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x0000C160 File Offset: 0x0000A360
	public override bool GetKey(string name)
	{
		return Input.GetKey(name);
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x0000C168 File Offset: 0x0000A368
	public override bool GetKeyDown(KeyCode key)
	{
		return Input.GetKeyDown(key);
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x0000C170 File Offset: 0x0000A370
	public override bool GetKeyDown(string name)
	{
		return Input.GetKeyDown(name);
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x0000C178 File Offset: 0x0000A378
	public override bool GetKeyUp(KeyCode key)
	{
		return Input.GetKeyUp(key);
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x0000C180 File Offset: 0x0000A380
	public override float GetAxis(string axisName)
	{
		return Input.GetAxis(axisName);
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x0000C188 File Offset: 0x0000A388
	public override bool GetButton(string buttonName)
	{
		return Input.GetButton(buttonName);
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x0000C190 File Offset: 0x0000A390
	public override bool GetButtonDown(string buttonName)
	{
		return Input.GetButtonDown(buttonName);
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x0000C198 File Offset: 0x0000A398
	public override bool GetButtonUp(string buttonName)
	{
		return Input.GetButtonUp(buttonName);
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x0000C1A0 File Offset: 0x0000A3A0
	public override bool GetMouseButton(int button, bool bCareUI = false)
	{
		return Input.GetMouseButton(button);
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x0000C1A8 File Offset: 0x0000A3A8
	public override bool GetMouseButtonDown(int button, bool bCareUI = false)
	{
		return Input.GetMouseButtonDown(button);
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x0000C1B0 File Offset: 0x0000A3B0
	public override bool GetMouseButtonUp(int button, bool bCareUI = false)
	{
		return Input.GetMouseButtonUp(button);
	}
}
