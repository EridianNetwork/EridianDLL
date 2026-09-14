using System;
using UnityEngine;

// Token: 0x02000ACB RID: 2763
public class RakkMovementSync : MonoBehaviour, IPhotonSerializeView
{
	// Token: 0x06004B1A RID: 19226 RVA: 0x00031096 File Offset: 0x0002F296
	private void Start()
	{
		this.m_bEnable = false;
		this.m_bMelee = false;
	}

	// Token: 0x06004B1B RID: 19227 RVA: 0x00137D2C File Offset: 0x00135F2C
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (!this.m_bEnable)
		{
			return;
		}
		if (stream.IsWriting)
		{
			stream.SendNext(base.transform.position);
			stream.SendNext(this.m_bMelee);
		}
		else
		{
			this.m_vPos = (Vector3)stream.ReceiveNext();
			this.m_bMelee = (bool)stream.ReceiveNext();
			if (!this.m_bMelee)
			{
				base.transform.position = this.m_vPos;
			}
		}
	}

	// Token: 0x04003699 RID: 13977
	public bool m_bEnable;

	// Token: 0x0400369A RID: 13978
	public bool m_bMelee;

	// Token: 0x0400369B RID: 13979
	private Vector3 m_vPos;
}
