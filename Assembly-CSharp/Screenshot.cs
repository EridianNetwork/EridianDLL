using System;
using UnityEngine;

// Token: 0x0200065A RID: 1626
public class Screenshot : MonoBehaviour
{
	// Token: 0x06002909 RID: 10505 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x0600290A RID: 10506 RVA: 0x0001AF3B File Offset: 0x0001913B
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F8))
		{
			Application.CaptureScreenshot(".\\Screenshot.png", this.Scale);
		}
	}

	// Token: 0x04001D5C RID: 7516
	public int Scale = 1;
}
