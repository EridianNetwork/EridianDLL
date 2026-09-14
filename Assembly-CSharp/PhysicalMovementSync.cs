using System;
using UnityEngine;

// Token: 0x02000ACA RID: 2762
public class PhysicalMovementSync : MonoBehaviour, IPhotonView, IPhotonSerializeView, IPhotonEvaluate
{
	// Token: 0x1700078F RID: 1935
	// (get) Token: 0x06004B12 RID: 19218 RVA: 0x00031077 File Offset: 0x0002F277
	// (set) Token: 0x06004B13 RID: 19219 RVA: 0x0003107F File Offset: 0x0002F27F
	public PhotonView photonView { get; set; }

	// Token: 0x06004B14 RID: 19220 RVA: 0x00031088 File Offset: 0x0002F288
	private void Awake()
	{
		this.m_Rigidbody = base.GetComponent<Rigidbody>();
	}

	// Token: 0x06004B15 RID: 19221 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06004B16 RID: 19222 RVA: 0x00137BAC File Offset: 0x00135DAC
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			if (this.m_Rigidbody != null)
			{
				stream.SendNext(base.transform.position);
				stream.SendNext(base.transform.rotation);
				stream.SendNext(this.m_Rigidbody.velocity);
				stream.SendNext(this.m_Rigidbody.angularVelocity);
			}
		}
		else if (this.m_Rigidbody != null)
		{
			this.lastPosition = (Vector3)stream.ReceiveNext();
			this.lastRotation = (Quaternion)stream.ReceiveNext();
			this.lastVelocity = (Vector3)stream.ReceiveNext();
			this.lastAngelVelocity = (Vector3)stream.ReceiveNext();
			this.m_settedPos = false;
			this.m_settedVol = false;
		}
	}

	// Token: 0x06004B17 RID: 19223 RVA: 0x00137C8C File Offset: 0x00135E8C
	private void FixedUpdate()
	{
		if (base.rigidbody != null)
		{
			if (!this.m_settedPos)
			{
				this.m_Rigidbody.isKinematic = true;
				base.transform.position = this.lastPosition;
				base.transform.rotation = this.lastRotation;
				this.m_settedPos = true;
			}
			if (this.m_settedPos && !this.m_settedVol)
			{
				this.m_Rigidbody.isKinematic = false;
				this.m_Rigidbody.velocity = this.lastVelocity;
				this.m_Rigidbody.angularVelocity = this.lastAngelVelocity;
				this.m_settedVol = true;
			}
		}
	}

	// Token: 0x06004B18 RID: 19224 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnPhotonEvaluate(PhotonPlayer player, ref PhotonPriority priority)
	{
	}

	// Token: 0x04003691 RID: 13969
	private Rigidbody m_Rigidbody;

	// Token: 0x04003692 RID: 13970
	private bool m_settedPos = true;

	// Token: 0x04003693 RID: 13971
	private bool m_settedVol = true;

	// Token: 0x04003694 RID: 13972
	private Vector3 lastVelocity;

	// Token: 0x04003695 RID: 13973
	private Vector3 lastAngelVelocity;

	// Token: 0x04003696 RID: 13974
	private Vector3 lastPosition;

	// Token: 0x04003697 RID: 13975
	private Quaternion lastRotation;
}
