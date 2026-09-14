using System;

// Token: 0x02000854 RID: 2132
public class SmallWeaponCardNoAnimation : SmallWeaponCardPanel
{
	// Token: 0x060039EC RID: 14828 RVA: 0x00026B61 File Offset: 0x00024D61
	protected override void vmethod_0()
	{
		base.vmethod_0();
		this.mcRootRoot = this.mcSelf;
		this.mcRootRoot.stopAll();
		this.mcSelf.visible = true;
	}

	// Token: 0x060039ED RID: 14829 RVA: 0x00026B8C File Offset: 0x00024D8C
	public override void vmethod_4(WeaponDNA weaponDNA_0, WeaponDNA weaponDNA_1 = null)
	{
		base.vmethod_4(weaponDNA_0, weaponDNA_1);
	}

	// Token: 0x060039EE RID: 14830 RVA: 0x00026B96 File Offset: 0x00024D96
	protected override void vmethod_2()
	{
		this.mcRoot = this.mcSelf;
	}
}
