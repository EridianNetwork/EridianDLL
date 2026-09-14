using System;
using UnityEngine;

// Token: 0x02000AA2 RID: 2722
public class SimpleFlyCamera : MonoBehaviour
{
	// Token: 0x060049C7 RID: 18887 RVA: 0x000304AA File Offset: 0x0002E6AA
	private void Start()
	{
		this.mouseLook = base.gameObject.AddComponent<MouseLook>();
		Screen.lockCursor = true;
	}

	// Token: 0x060049C8 RID: 18888 RVA: 0x0013217C File Offset: 0x0013037C
	private void Update()
	{
		if (Screen.lockCursor)
		{
			this.mouseLook.enabled = true;
			if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
				{
					base.transform.position += base.transform.forward * this.normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
					base.transform.position += base.transform.right * this.normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
				}
				else
				{
					base.transform.position += base.transform.forward * (this.normalMoveSpeed * this.slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
					base.transform.position += base.transform.right * (this.normalMoveSpeed * this.slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
				}
			}
			else
			{
				base.transform.position += base.transform.forward * (this.normalMoveSpeed * this.fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
				base.transform.position += base.transform.right * (this.normalMoveSpeed * this.fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.Q))
			{
				base.transform.position += base.transform.up * this.climbSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.E))
			{
				base.transform.position -= base.transform.up * this.climbSpeed * Time.deltaTime;
			}
		}
		else
		{
			this.mouseLook.enabled = false;
		}
	}

	// Token: 0x040035F4 RID: 13812
	public float climbSpeed = 4f;

	// Token: 0x040035F5 RID: 13813
	public float normalMoveSpeed = 10f;

	// Token: 0x040035F6 RID: 13814
	public float slowMoveFactor = 0.25f;

	// Token: 0x040035F7 RID: 13815
	public float fastMoveFactor = 3f;

	// Token: 0x040035F8 RID: 13816
	private MouseLook mouseLook;
}
