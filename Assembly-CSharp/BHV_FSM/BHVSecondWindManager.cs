using System;
using UnityEngine;

namespace BHV_FSM
{
	// Token: 0x02000247 RID: 583
	public sealed class BHVSecondWindManager
	{
		// Token: 0x06000BDC RID: 3036 RVA: 0x00067B44 File Offset: 0x00065D44
		public BHVSecondWindManager(Entity entity_0)
		{
			this.entityPlayer_0 = entity_0 as EntityPlayer;
			this.characterSetting_0 = this.entityPlayer_0.CharacterSetting_0;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00067B98 File Offset: 0x00065D98
		public float method_0()
		{
			if (Time.time - this.float_2 > 0.3f)
			{
				this.float_0 = 1f;
			}
			else
			{
				this.float_0 = 2f;
			}
			int num = (int)((float)this.characterSetting_0.m_secondWindBleedRate * this.float_0);
			return (float)num;
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0000B99A File Offset: 0x00009B9A
		public void method_1(EntityPlayer entityPlayer_1)
		{
			if (entityPlayer_1 != null)
			{
				this.int_0 += entityPlayer_1.CharacterSetting_0.m_revivePower;
				this.float_1 = Time.time;
			}
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x00067BE8 File Offset: 0x00065DE8
		public int method_2()
		{
			int num = this.int_0;
			this.int_0 = 0;
			return num;
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0000B9C8 File Offset: 0x00009BC8
		public void method_3()
		{
			this.int_0 = 0;
			this.float_1 = -1f;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0000B9DC File Offset: 0x00009BDC
		public bool method_4()
		{
			return this.int_0 > 0 || Time.time - this.float_1 < this.characterSetting_0.m_reviveResetDelay;
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0000BA05 File Offset: 0x00009C05
		public void OnReceiveDamage(DamageInfo damageInfo)
		{
			this.float_2 = Time.time;
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0000BA05 File Offset: 0x00009C05
		public void OnReceiveDamage(DamageContext damageContext)
		{
			this.float_2 = Time.time;
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x0000BA12 File Offset: 0x00009C12
		public bool method_5(Entity entity_0, Entity entity_1)
		{
			if (this.entityPlayer_0 == entity_0 && entity_1 is EntityNpc)
			{
				this.bool_0 = true;
				return true;
			}
			return false;
		}

		// Token: 0x04000A9C RID: 2716
		public EntityPlayer entityPlayer_0;

		// Token: 0x04000A9D RID: 2717
		public EntityPlayer.CharacterSetting characterSetting_0;

		// Token: 0x04000A9E RID: 2718
		public bool bool_0;

		// Token: 0x04000A9F RID: 2719
		private float float_0 = 1f;

		// Token: 0x04000AA0 RID: 2720
		private int int_0;

		// Token: 0x04000AA1 RID: 2721
		private float float_1 = -1f;

		// Token: 0x04000AA2 RID: 2722
		private float float_2 = -1f;
	}
}
