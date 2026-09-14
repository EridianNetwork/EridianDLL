using System;
using ns0;
using UnityEngine;

// Token: 0x020006D8 RID: 1752
public class LobbyCameraDragController : MonoBehaviour
{
	// Token: 0x06002E45 RID: 11845 RVA: 0x000D7CCC File Offset: 0x000D5ECC
	private void Start()
	{
		this.m_Camera = GameObject.Find("LobbyCamera");
		this.m_BoundaryRect = GameObject.Find("PRO_Looby_Camera_Plane");
		this.m_TimePassing = GameObject.Find("PRO_Looby_Timepassing");
		if (this.m_Camera != null)
		{
			Animation component = this.m_Camera.GetComponent<Animation>();
			component.playAutomatically = true;
			component.Play();
		}
		if (this.m_TimePassing != null)
		{
			Animation component2 = this.m_TimePassing.GetComponent<Animation>();
			component2.Stop();
			component2["ANI_Looby_Timepassing"].time = 0f;
			component2.Play();
		}
		float num = this.m_BoundaryRect.renderer.bounds.size.x / 2f;
		float num2 = this.m_BoundaryRect.renderer.bounds.size.z / 2f;
		this.m_v2BoundryRangeX.x = this.m_BoundaryRect.transform.position.x - num;
		this.m_v2BoundryRangeX.y = this.m_BoundaryRect.transform.position.x + num;
		this.m_v2BoundryRangeZ.x = this.m_BoundaryRect.transform.position.z - num2;
		this.m_v2BoundryRangeZ.y = this.m_BoundaryRect.transform.position.z + num2;
		this.m_fBoundryY = this.m_BoundaryRect.transform.position.y;
	}

	// Token: 0x06002E46 RID: 11846 RVA: 0x000D7E78 File Offset: 0x000D6078
	private void Update()
	{
		if (MonoSingleton<InputManager>.Instance.method_12(0, true) && !this.m_bDragable)
		{
			this.m_bDragable = true;
			this.m_v2MouseStartPos = Input.mousePosition;
		}
		if (MonoSingleton<InputManager>.Instance.method_13(0, false))
		{
			this.m_bDragable = false;
		}
		if (!this.m_bDragable)
		{
			return;
		}
		Vector2 vector = Input.mousePosition;
		if (vector.x - this.m_v2MouseStartPos.x == 0f && vector.y - this.m_v2MouseStartPos.y == 0f)
		{
			return;
		}
		Vector2 vector2 = (vector - this.m_v2MouseStartPos) / this.m_fScale;
		vector2 = this.m_fDragSpeed * vector2;
		this.m_v2MouseStartPos = vector;
		Vector3 localPosition = this.m_Camera.transform.localPosition;
		localPosition.x -= vector2.x;
		localPosition.z -= vector2.y;
		this.m_Camera.transform.localPosition = localPosition;
		Vector3 position = this.m_Camera.transform.position;
		if (position.x > this.m_v2BoundryRangeX.y)
		{
			position.x = this.m_v2BoundryRangeX.y;
		}
		else if (position.x < this.m_v2BoundryRangeX.x)
		{
			position.x = this.m_v2BoundryRangeX.x;
		}
		if (position.z > this.m_v2BoundryRangeZ.y)
		{
			position.z = this.m_v2BoundryRangeZ.y;
		}
		else if (position.z < this.m_v2BoundryRangeZ.x)
		{
			position.z = this.m_v2BoundryRangeZ.x;
		}
		position.y = this.m_fBoundryY;
		this.m_Camera.transform.position = position;
	}

	// Token: 0x0400207D RID: 8317
	private GameObject m_Camera;

	// Token: 0x0400207E RID: 8318
	private GameObject m_BoundaryRect;

	// Token: 0x0400207F RID: 8319
	private GameObject m_TimePassing;

	// Token: 0x04002080 RID: 8320
	private Vector2 m_v2BoundryRangeX = new Vector2(0f, 0f);

	// Token: 0x04002081 RID: 8321
	private Vector2 m_v2BoundryRangeZ = new Vector2(0f, 0f);

	// Token: 0x04002082 RID: 8322
	private float m_fBoundryY;

	// Token: 0x04002083 RID: 8323
	private Vector2 m_v2MouseStartPos = new Vector2(0f, 0f);

	// Token: 0x04002084 RID: 8324
	private bool m_bDragable;

	// Token: 0x04002085 RID: 8325
	public float m_fDragSpeed = 2f;

	// Token: 0x04002086 RID: 8326
	private float m_fScale = 1000f;
}
