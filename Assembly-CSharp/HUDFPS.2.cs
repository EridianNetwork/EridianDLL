using System;
using UnityEngine;

// Token: 0x02000B98 RID: 2968
public class HUDFPS : MonoBehaviour
{
	// Token: 0x0600501B RID: 20507 RVA: 0x00034204 File Offset: 0x00032404
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x0600501C RID: 20508 RVA: 0x001553D0 File Offset: 0x001535D0
	private void Update()
	{
		this.timeleft -= Time.deltaTime;
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
		if ((double)this.timeleft <= 0.0)
		{
			string text = (this.accum / (float)this.frames).ToString() + " FPS";
			this.s = text;
			this.timeleft = this.updateInterval;
			this.accum = 0f;
			this.frames = 0;
		}
	}

	// Token: 0x0600501D RID: 20509 RVA: 0x00034212 File Offset: 0x00032412
	private void OnGUI()
	{
		GUI.TextField(new Rect(0f, (float)(Screen.height - 20), 100f, 20f), this.s);
	}

	// Token: 0x04003CFB RID: 15611
	public float updateInterval = 0.5f;

	// Token: 0x04003CFC RID: 15612
	private float accum;

	// Token: 0x04003CFD RID: 15613
	private int frames;

	// Token: 0x04003CFE RID: 15614
	private float timeleft;

	// Token: 0x04003CFF RID: 15615
	private string s = " ";
}
