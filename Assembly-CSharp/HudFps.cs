using System;
using ns0;
using UnityEngine;

// Token: 0x02000A99 RID: 2713
public class HudFps : MonoBehaviour
{
	// Token: 0x0600495E RID: 18782 RVA: 0x00130E98 File Offset: 0x0012F098
	public virtual void Start()
	{
		this.startRect = new Rect((float)(Screen.width - 75), 10f, 75f, 50f);
		this.startRect2 = new Rect((float)(Screen.width - 150), this.startRect.yMin, this.startRect.width, this.startRect.height);
	}

	// Token: 0x0600495F RID: 18783 RVA: 0x0002FF7A File Offset: 0x0002E17A
	public virtual void Update()
	{
		this.m_fps = MonoSingleton<AppManager>.Instance.m_fps;
	}

	// Token: 0x06004960 RID: 18784 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void LateUpdate()
	{
	}

	// Token: 0x06004961 RID: 18785 RVA: 0x00130F00 File Offset: 0x0012F100
	public virtual void OnGUI()
	{
		if (this.style == null)
		{
			this.style = new GUIStyle(GUI.skin.label);
			this.style.normal.textColor = Color.white;
			this.style.alignment = TextAnchor.MiddleCenter;
		}
		GUI.color = ((!this.updateColor) ? Color.white : this.color);
		this.startRect = GUI.Window(0, this.startRect, new GUI.WindowFunction(this.vmethod_0), string.Empty);
		this.startRect2 = GUI.Window(1, this.startRect2, new GUI.WindowFunction(this.vmethod_1), string.Empty);
	}

	// Token: 0x06004962 RID: 18786 RVA: 0x00130FB0 File Offset: 0x0012F1B0
	public virtual void vmethod_0(int int_0)
	{
		this.sFPS = this.m_fps.ToString("f" + Mathf.Clamp(this.nbDecimal, 0, 10));
		this.color = ((this.m_fps < 25f) ? ((this.m_fps <= 20f) ? Color.red : Color.yellow) : Color.green);
		GUI.Label(new Rect(0f, 0f, this.startRect.width, this.startRect.height), string.Concat(new object[]
		{
			this.sFPS,
			" FPS\n",
			(int)(Time.deltaTime * 1000f),
			"ms"
		}), this.style);
		if (this.allowDrag)
		{
			GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}
		if (this.m_fps < 20f && MonoSingleton<AppManager>.Instance.m_profilerManager != null)
		{
			MonoSingleton<AppManager>.Instance.m_profilerManager.method_11();
		}
	}

	// Token: 0x06004963 RID: 18787 RVA: 0x001310D8 File Offset: 0x0012F2D8
	public virtual void vmethod_1(int int_0)
	{
		GUI.Label(new Rect(0f, 0f, this.startRect2.width, this.startRect2.height), " Ping:" + PhotonNetwork.GetPing() + "ms", this.style);
		if (this.allowDrag)
		{
			GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}
	}

	// Token: 0x06004964 RID: 18788 RVA: 0x00131158 File Offset: 0x0012F358
	public virtual void vmethod_2(int int_0)
	{
		int[] array = MonoSingleton<EntityManager>.Instance.method_10();
		this.style.alignment = TextAnchor.MiddleCenter;
		for (int i = 0; i < array.Length; i++)
		{
			GUILayout.Label(Enum.GetNames(typeof(Entity.EntityType))[i] + ": " + array[i], this.style, new GUILayoutOption[0]);
		}
		if (this.allowDrag)
		{
			GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}
	}

	// Token: 0x06004965 RID: 18789 RVA: 0x001311E8 File Offset: 0x0012F3E8
	public virtual void vmethod_3(int int_0)
	{
		if (this.allowDrag)
		{
			GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}
		if (MonoSingleton<EntityManager>.Instance == null)
		{
			return;
		}
		if (MonoSingleton<EntityManager>.Instance.method_9(Entity.EntityType.Player) <= 0)
		{
			return;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		EntityPlayer entityPlayer = localPlayer.GetEntity() as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		if (this.m_cam == null)
		{
			this.m_cam = entityPlayer.method_45();
		}
		if (this.m_cam == null)
		{
			return;
		}
		GUIStyle guistyle = new GUIStyle(GUI.skin.label);
		guistyle.normal.textColor = Color.white;
		guistyle.alignment = TextAnchor.UpperLeft;
		GUILayout.Label("Pos:" + this.m_cam.transform.position, guistyle, new GUILayoutOption[0]);
		GUILayout.Label("Rot:" + this.m_cam.transform.eulerAngles, guistyle, new GUILayoutOption[0]);
		GUILayout.Label("LastCorrect:" + this.m_cam.m_entityPlayer.method_143(), new GUILayoutOption[0]);
		GUILayout.Label("Vel:" + (float)((int)(this.m_camVel * 1000f)) / 1000f, guistyle, new GUILayoutOption[0]);
		GUILayout.Label("Acc:" + (float)((int)(Mathf.Abs(this.m_camAcc) * 1000f)) / 1000f, guistyle, new GUILayoutOption[0]);
		GUILayout.Label("pVel:" + (float)((int)(this.m_pitchVel * 1000f)) / 1000f, guistyle, new GUILayoutOption[0]);
		GUILayout.Label("pAcc:" + (float)((int)(Mathf.Abs(this.m_pitchAcc) * 1000f)) / 1000f, guistyle, new GUILayoutOption[0]);
		GUILayout.Label("yVel:" + (float)((int)(this.m_yawVel * 1000f)) / 1000f, guistyle, new GUILayoutOption[0]);
		GUILayout.Label("yAcc:" + (float)((int)(Mathf.Abs(this.m_yawAcc) * 1000f)) / 1000f, guistyle, new GUILayoutOption[0]);
	}

	// Token: 0x06004966 RID: 18790 RVA: 0x00131460 File Offset: 0x0012F660
	public virtual void vmethod_4(int int_0)
	{
		GUILayout.Label("Cur:" + this.m_memCur / 1048576f + "Mb", this.style, new GUILayoutOption[0]);
		GUILayout.Label("Peak:" + this.m_memPeak / 1048576f + "Mb", this.style, new GUILayoutOption[0]);
		if (this.allowDrag)
		{
			GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}
	}

	// Token: 0x040035B6 RID: 13750
	protected Rect startRect;

	// Token: 0x040035B7 RID: 13751
	protected Rect startRect2;

	// Token: 0x040035B8 RID: 13752
	protected Rect startRect3;

	// Token: 0x040035B9 RID: 13753
	protected Rect startRect4;

	// Token: 0x040035BA RID: 13754
	protected Rect startRect5;

	// Token: 0x040035BB RID: 13755
	public bool updateColor = true;

	// Token: 0x040035BC RID: 13756
	public bool allowDrag = true;

	// Token: 0x040035BD RID: 13757
	public float frequency = 0.5f;

	// Token: 0x040035BE RID: 13758
	public int nbDecimal = 1;

	// Token: 0x040035BF RID: 13759
	protected float accum;

	// Token: 0x040035C0 RID: 13760
	protected int frames;

	// Token: 0x040035C1 RID: 13761
	protected Color color = Color.white;

	// Token: 0x040035C2 RID: 13762
	protected string sFPS = string.Empty;

	// Token: 0x040035C3 RID: 13763
	protected GUIStyle style;

	// Token: 0x040035C4 RID: 13764
	protected uint m_memCur;

	// Token: 0x040035C5 RID: 13765
	protected uint m_memPeak;

	// Token: 0x040035C6 RID: 13766
	protected float m_fps;

	// Token: 0x040035C7 RID: 13767
	protected float m_camVel;

	// Token: 0x040035C8 RID: 13768
	protected float m_camAcc;

	// Token: 0x040035C9 RID: 13769
	protected float m_lastCamVel;

	// Token: 0x040035CA RID: 13770
	protected Vector3 m_lastCamPos;

	// Token: 0x040035CB RID: 13771
	protected BadAssFPSCamera m_cam;

	// Token: 0x040035CC RID: 13772
	protected float m_lastPitch;

	// Token: 0x040035CD RID: 13773
	protected float m_lastYaw;

	// Token: 0x040035CE RID: 13774
	protected float m_pitchVel;

	// Token: 0x040035CF RID: 13775
	protected float m_yawVel;

	// Token: 0x040035D0 RID: 13776
	protected float m_lastPitchVel;

	// Token: 0x040035D1 RID: 13777
	protected float m_lastYawVel;

	// Token: 0x040035D2 RID: 13778
	protected float m_pitchAcc;

	// Token: 0x040035D3 RID: 13779
	protected float m_yawAcc;
}
