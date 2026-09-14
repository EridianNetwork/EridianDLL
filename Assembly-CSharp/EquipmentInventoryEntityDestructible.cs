using System;

// Token: 0x02000489 RID: 1161
public class EquipmentInventoryEntityDestructible : EquipmentInventoryEntity
{
	// Token: 0x06001E94 RID: 7828 RVA: 0x000154B8 File Offset: 0x000136B8
	public override int vmethod_4()
	{
		return this.m_pouchList[0].method_5();
	}

	// Token: 0x06001E95 RID: 7829 RVA: 0x000154CB File Offset: 0x000136CB
	public override int vmethod_0()
	{
		return this.m_pouchList[0].method_4();
	}

	// Token: 0x06001E96 RID: 7830 RVA: 0x000154DE File Offset: 0x000136DE
	public override void vmethod_1(int int_0)
	{
		this.m_pouchList[0].method_7(int_0);
	}

	// Token: 0x06001E97 RID: 7831 RVA: 0x000154F2 File Offset: 0x000136F2
	public override void vmethod_5(int int_0)
	{
		this.m_pouchList[0].method_8(int_0);
	}

	// Token: 0x06001E98 RID: 7832 RVA: 0x00015506 File Offset: 0x00013706
	public override void vmethod_32(byte byte_0, int int_0)
	{
		this.m_pouchList[0].method_0(int_0);
	}

	// Token: 0x06001E99 RID: 7833 RVA: 0x0001551A File Offset: 0x0001371A
	private void Awake()
	{
		this.m_pouchList.Clear();
		this.m_pouchList.Add(new Utils.PouchNetwork());
	}

	// Token: 0x06001E9A RID: 7834 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}

	// Token: 0x0200048A RID: 1162
	private enum PouchType
	{
		// Token: 0x040013E6 RID: 5094
		LIFE
	}
}
