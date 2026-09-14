using System;
using Core;

// Token: 0x02000497 RID: 1175
public class InventorySlot
{
	// Token: 0x06001F71 RID: 8049 RVA: 0x00015C9D File Offset: 0x00013E9D
	public void method_0(int int_0, ItemDNA itemDNA_0)
	{
		this.m_networkID = int_0;
		this.m_entity = BadAssNetworkView.smethod_4(this.m_networkID);
		this.m_dna = itemDNA_0;
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x00015CBE File Offset: 0x00013EBE
	public void method_1(Entity entity_0, ItemDNA itemDNA_0)
	{
		this.m_entity = entity_0;
		this.m_dna = itemDNA_0;
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x00015CCE File Offset: 0x00013ECE
	public ItemDNA method_2()
	{
		return this.m_dna;
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x0009AEDC File Offset: 0x000990DC
	public Entity method_3()
	{
		if (this.m_entity == null && this.m_networkID != 0)
		{
			this.m_entity = BadAssNetworkView.smethod_4(this.m_networkID);
			if (this.m_entity == null)
			{
				DebugUtils.LogError(LogCategory.Gamelogic, "BOL_DIAG InventorySlot.method_3: networkID=" + this.m_networkID.ToString() + " BadAssNetworkView lookup failed");
			}
		}
		return this.m_entity;
	}

	// Token: 0x06001F75 RID: 8053 RVA: 0x00015CD6 File Offset: 0x00013ED6
	public bool method_4()
	{
		return this.m_networkID != 0 || this.m_entity != null;
	}

	// Token: 0x06001F76 RID: 8054 RVA: 0x00015CEE File Offset: 0x00013EEE
	public bool method_5()
	{
		return this.m_networkID != 0;
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x00015CF9 File Offset: 0x00013EF9
	public void method_6()
	{
		this.m_networkID = 0;
		this.m_entity = null;
		this.m_dna = null;
	}

	// Token: 0x04001442 RID: 5186
	protected Entity m_entity;

	// Token: 0x04001443 RID: 5187
	protected int m_networkID;

	// Token: 0x04001444 RID: 5188
	protected ItemDNA m_dna;

	// Token: 0x02000498 RID: 1176
	public enum InventorySlotFlag
	{
		// Token: 0x04001446 RID: 5190
		InventorySlot_Weapon = 1,
		// Token: 0x04001447 RID: 5191
		InventorySlot_Shield = 1
	}
}
