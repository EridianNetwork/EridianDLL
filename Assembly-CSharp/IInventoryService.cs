using System;

// Token: 0x020002F3 RID: 755
public interface IInventoryService
{
	// Token: 0x06001175 RID: 4469
	Inventory imethod_0(int int_0, GetInventoryCallback getInventoryCallback_0 = null);

	// Token: 0x06001176 RID: 4470
	void imethod_1(int int_0);

	// Token: 0x06001177 RID: 4471
	void imethod_2(int int_0);

	// Token: 0x06001178 RID: 4472
	void imethod_3(BackpackProgressionCallback backpackProgressionCallback_0);

	// Token: 0x06001179 RID: 4473
	void imethod_4(PurchaseBackpackSizeCallback purchaseBackpackSizeCallback_0, int int_0);

	// Token: 0x0600117A RID: 4474
	void imethod_5();

	// Token: 0x0600117B RID: 4475
	void imethod_6(InventoryCallback inventoryCallback_0);

	// Token: 0x0600117C RID: 4476
	void imethod_7(InventoryCallback inventoryCallback_0);

	// Token: 0x0600117D RID: 4477
	void imethod_8(ItemRewardCallback itemRewardCallback_0);

	// Token: 0x0600117E RID: 4478
	void imethod_9(ItemRewardCallback itemRewardCallback_0);

	// Token: 0x0600117F RID: 4479
	void imethod_10(WarehouseCallback warehouseCallback_0);

	// Token: 0x06001180 RID: 4480
	void imethod_11(WarehouseCallback warehouseCallback_0);
}
