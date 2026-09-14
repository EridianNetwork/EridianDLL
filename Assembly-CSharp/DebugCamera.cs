using System;
using ns0;
using UnityEngine;

// Token: 0x02000A8B RID: 2699
public class DebugCamera : MonoSingleton<DebugCamera>
{
	// Token: 0x06004902 RID: 18690 RVA: 0x0002FAA8 File Offset: 0x0002DCA8
	private void Start()
	{
		base.enabled = false;
	}

	// Token: 0x06004903 RID: 18691 RVA: 0x0012FBA8 File Offset: 0x0012DDA8
	private void Update()
	{
		GameObject gameObject = GameObject.Find("DebugCamPlayerMarker");
		if (gameObject != null && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
		{
			EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			if (entityPlayer != null)
			{
				gameObject.transform.position = entityPlayer.transform.position + Vector3.up * 50f;
			}
		}
		if (this.m_attachedTo != null)
		{
			this.method_4();
			return;
		}
		if (Screen.lockCursor)
		{
			if (!this.m_mouseLook.enabled)
			{
				if (Input.GetMouseButtonUp(1))
				{
					this.m_mouseLook.enabled = true;
				}
				else
				{
					this.m_camera.transform.position += this.m_targetedCollider.transform.position - this.m_lastTurnedAroundColliderPosition;
					this.m_camera.transform.RotateAround(this.m_targetedCollider.transform.position, Vector3.Cross(Vector3.up, this.m_camera.transform.position - this.m_targetedCollider.transform.position), Input.GetAxis("Mouse Y") * 10f);
					this.m_camera.transform.RotateAround(this.m_targetedCollider.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 10f);
					this.m_lastTurnedAroundColliderPosition = this.m_targetedCollider.transform.position;
				}
			}
			else
			{
				float maxValue = float.MaxValue;
				this.m_targetedEntity = TargetingService.smethod_2(this.m_camera.ScreenPointToRay(Input.mousePosition), null, out this.m_targetedCollider, ref maxValue, ColliderType.WeakPoint, true);
				if (Input.GetMouseButtonDown(1) && this.m_targetedEntity != null)
				{
					this.m_mouseLook.enabled = false;
					this.m_camera.transform.LookAt(this.m_targetedCollider.transform.position);
					this.m_lastTurnedAroundColliderPosition = this.m_targetedCollider.transform.position;
				}
				this.method_7();
			}
			if (Input.GetMouseButtonDown(0) && this.m_targetedEntity != null)
			{
				this.method_2();
			}
		}
	}

	// Token: 0x06004904 RID: 18692 RVA: 0x0002FAB1 File Offset: 0x0002DCB1
	public bool method_0()
	{
		return base.enabled;
	}

	// Token: 0x06004905 RID: 18693 RVA: 0x0012FE04 File Offset: 0x0012E004
	private void method_1(bool bool_0)
	{
		base.enabled = bool_0;
		if (bool_0)
		{
			this.m_object = new GameObject("DebugCamera");
			this.m_object.transform.parent = base.gameObject.transform;
			this.m_camera = this.m_object.AddComponent<Camera>();
			this.m_mouseLook = this.m_object.AddComponent<MouseLook>();
			MonoSingleton<GameFlowManager>.Instance.method_0();
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			gameObject.name = "DebugCamPlayerMarker";
			gameObject.transform.localScale = new Vector3(0.3f, 50f, 0.3f);
			Collider component = gameObject.GetComponent<Collider>();
			if (component != null)
			{
				global::UnityEngine.Object.Destroy(component);
			}
			Renderer component2 = gameObject.GetComponent<Renderer>();
			if (component2 != null)
			{
				Shader shader = Shader.Find("Unlit/Color");
				if (shader != null)
				{
					component2.material.shader = shader;
				}
				component2.material.color = Color.magenta;
				return;
			}
		}
		else
		{
			this.method_6(false);
			if (this.m_object != null)
			{
				global::UnityEngine.Object.Destroy(this.m_object);
				this.m_object = null;
			}
			GameObject gameObject2 = GameObject.Find("DebugCamPlayerMarker");
			if (gameObject2 != null)
			{
				global::UnityEngine.Object.Destroy(gameObject2);
			}
		}
	}

	// Token: 0x06004906 RID: 18694 RVA: 0x0002FAB9 File Offset: 0x0002DCB9
	private void method_2()
	{
		this.m_attachedTo = this.m_targetedEntity;
		this.method_6(false);
		this.m_targetedEntity = null;
		this.m_targetedCollider = null;
	}

	// Token: 0x06004907 RID: 18695 RVA: 0x0002FADC File Offset: 0x0002DCDC
	private void method_3()
	{
		this.m_attachedTo = null;
		this.method_6(true);
	}

	// Token: 0x06004908 RID: 18696 RVA: 0x0012FF3C File Offset: 0x0012E13C
	private void method_4()
	{
		this.m_camera.transform.position = this.m_attachedTo.transform.position;
		this.m_camera.transform.Translate(0f, this.m_attachmentOffset, 0f);
		this.m_camera.transform.rotation = this.m_attachedTo.transform.rotation;
	}

	// Token: 0x06004909 RID: 18697 RVA: 0x0002FAEC File Offset: 0x0002DCEC
	public void method_5(Vector3 vector3_0)
	{
		this.method_3();
		this.m_camera.transform.position = vector3_0;
	}

	// Token: 0x0600490A RID: 18698 RVA: 0x0002FB05 File Offset: 0x0002DD05
	public void method_6(bool bool_0)
	{
		if (bool_0)
		{
			this.m_mouseLook.enabled = true;
			MonoSingleton<GameFlowManager>.Instance.method_0();
		}
		else
		{
			this.m_mouseLook.enabled = false;
			MonoSingleton<GameFlowManager>.Instance.method_1();
		}
	}

	// Token: 0x0600490B RID: 18699 RVA: 0x0002FB38 File Offset: 0x0002DD38
	private void OnApplicationFocus(bool focus)
	{
		if (this.m_object != null && !focus)
		{
			this.method_6(false);
		}
	}

	// Token: 0x0600490C RID: 18700 RVA: 0x0012FFAC File Offset: 0x0012E1AC
	private void method_7()
	{
		this.m_moveDirection.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		if (Input.GetKey(KeyCode.LeftShift))
		{
			this.m_moveDirection *= 2f;
		}
		this.m_object.transform.Translate(this.m_moveDirection * Time.deltaTime * this.m_cameraSpeed);
	}

	// Token: 0x0600490D RID: 18701 RVA: 0x0013002C File Offset: 0x0012E22C
	public void method_8()
	{
		GUILayout.BeginArea(new Rect(0f, (float)(Screen.height - 30), (float)Screen.width, 30f));
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		bool flag;
		if ((flag = GUILayout.Toggle(this.method_0(), " Debug Camera", new GUILayoutOption[] { GUILayout.ExpandWidth(false) })) != this.method_0())
		{
			this.method_1(flag);
		}
		if (this.method_0())
		{
			this.m_showNPCLog = GUILayout.Toggle(this.m_showNPCLog, " ShowNpcLog", new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
			this.m_showPlayerLog = GUILayout.Toggle(this.m_showPlayerLog, " ShowPlayerLog", new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
			this.m_showAimTrace = GUILayout.Toggle(this.m_showAimTrace, " ShowAimTrace", new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
			if (this.m_attachedTo == null)
			{
				GUILayout.Label(" | Speed: ", new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
				this.m_cameraSpeed = GUILayout.HorizontalSlider(this.m_cameraSpeed, 0.1f, 100f, new GUILayoutOption[] { GUILayout.Width(80f) });
				if (this.m_targetedEntity != null)
				{
					GUILayout.Label(" | Left-click to attach to " + this.m_targetedEntity.name, new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
				}
			}
			else
			{
				GUILayout.Label(" | Y Offset: ", new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
				this.m_attachmentOffset = GUILayout.HorizontalSlider(this.m_attachmentOffset, 0f, 2f, new GUILayoutOption[] { GUILayout.Width(80f) });
				GUILayout.Label(" | ", new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
				if (GUILayout.Button("Detach", new GUILayoutOption[] { GUILayout.ExpandWidth(false) }))
				{
					this.method_3();
				}
			}
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		if (this.method_0() && this.m_attachedTo == null)
		{
			GUILayout.BeginArea(new Rect(0f, 0f, (float)Screen.width, (float)(Screen.height - 34)));
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (Screen.lockCursor)
			{
				GUILayout.Label("+", new GUILayoutOption[0]);
			}
			else if (GUILayout.Button("Continue", new GUILayoutOption[0]))
			{
				this.method_6(true);
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
	}

	// Token: 0x04003585 RID: 13701
	private GameObject m_object;

	// Token: 0x04003586 RID: 13702
	public Camera m_camera;

	// Token: 0x04003587 RID: 13703
	private MouseLook m_mouseLook;

	// Token: 0x04003588 RID: 13704
	private Vector3 m_moveDirection = Vector3.zero;

	// Token: 0x04003589 RID: 13705
	private Vector3 m_lastTurnedAroundColliderPosition = Vector3.zero;

	// Token: 0x0400358A RID: 13706
	public float m_cameraSpeed = 10f;

	// Token: 0x0400358B RID: 13707
	public float m_attachmentOffset = 1f;

	// Token: 0x0400358C RID: 13708
	public Entity m_targetedEntity;

	// Token: 0x0400358D RID: 13709
	public Collider m_targetedCollider;

	// Token: 0x0400358E RID: 13710
	public Entity m_attachedTo;

	// Token: 0x0400358F RID: 13711
	public bool m_showNPCLog;

	// Token: 0x04003590 RID: 13712
	public bool m_showPlayerLog;

	// Token: 0x04003591 RID: 13713
	public bool m_showAimTrace;
}
