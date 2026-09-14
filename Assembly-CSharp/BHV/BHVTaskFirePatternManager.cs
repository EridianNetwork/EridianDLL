using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000249 RID: 585
	public sealed class BHVTaskFirePatternManager
	{
		// Token: 0x06000BF8 RID: 3064 RVA: 0x0000BA34 File Offset: 0x00009C34
		public void Start(float fireDuration, float idleDuration, AIInventory inventory)
		{
			this.float_0 = 0f;
			this.float_1 = fireDuration;
			this.float_2 = idleDuration;
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00068294 File Offset: 0x00066494
		public bool Update(float deltaTime, AIInventory inventory, Vector3 shootFrom, Vector3 shootAt)
		{
			if (deltaTime >= 0f && !(inventory == null))
			{
				this.float_0 += deltaTime;
				if (this.float_0 <= this.float_1)
				{
					if (inventory.m_weapon != null && inventory.m_weapon.method_33())
					{
						this.method_0(inventory, shootFrom, shootAt);
						return true;
					}
				}
				else if (this.float_0 >= this.float_1 + this.float_2)
				{
					this.float_0 -= this.float_1 + this.float_2;
				}
				return false;
			}
			return false;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0000311B File Offset: 0x0000131B
		public void method_0(AIInventory aiinventory_0, Vector3 vector3_0, Vector3 vector3_1)
		{
		}

		// Token: 0x04000AA3 RID: 2723
		private float float_0;

		// Token: 0x04000AA4 RID: 2724
		private float float_1;

		// Token: 0x04000AA5 RID: 2725
		private float float_2;
	}
}
