using System;
using System.Collections.Generic;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C9 RID: 457
	public class BHVTaskEyeLaserPlus : BHVTask
	{
		// Token: 0x060009D0 RID: 2512 RVA: 0x0005F870 File Offset: 0x0005DA70
		public BHVTaskEyeLaserPlus()
		{
			base.m_Type = BHVTaskType.EyeLaserPlus;
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00009D26 File Offset: 0x00007F26
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamEyeLaserPlus_0 = bhvtaskParam_0 as BHVTaskParamEyeLaserPlus;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00009D3B File Offset: 0x00007F3B
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamEyeLaserPlus_0;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0005F8D4 File Offset: 0x0005DAD4
		public override void Start()
		{
			base.Start();
			this.float_0 = this.bhvtaskParamEyeLaserPlus_0.float_1;
			this.float_1 = this.bhvtaskParamEyeLaserPlus_0.float_0;
			this.float_2 = this.bhvtaskParamEyeLaserPlus_0.float_0;
			this.bool_1 = false;
			this.bool_2 = true;
			this.gameObject_0 = null;
			if (this.pointList_0 == null)
			{
				GameObject gameObject = GameObject.Find("LaserTowerList");
				if (gameObject != null)
				{
					this.pointList_0 = gameObject.GetComponent<PointList>();
				}
			}
			this.list_0.Clear();
			this.list_1.Clear();
			this.list_2.Clear();
			this.theInsaneAnimationManagerFSM_0 = this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneAnimationManagerFSM;
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEyeLaserPlusWarning", true);
			this.method_0();
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0005F9B8 File Offset: 0x0005DBB8
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if (this.transform_1 != null)
			{
				this.transform_0.position = this.transform_1.position;
			}
			if (this.transform_0 != null)
			{
				Vector3 position = this.gameObject_0.transform.position;
				position.y += 1.5f;
				this.transform_0.transform.forward = (position - this.transform_0.position).normalized;
			}
			if (this.bool_2)
			{
				this.float_1 -= deltaTime;
				if (this.float_1 >= 0f)
				{
					return;
				}
				if (this.theInsaneAnimationManagerFSM_0 != null)
				{
					this.transform_0 = this.theInsaneAnimationManagerFSM_0.method_32(true);
					if (this.transform_0 != null)
					{
						this.transform_1 = this.transform_0.parent;
						this.transform_0.parent = null;
						if (this.transform_1 != null)
						{
							this.transform_0.position = this.transform_1.position;
						}
						this.transform_0.transform.forward = (this.gameObject_0.transform.position + Vector3.up * 1.5f - this.transform_0.position).normalized;
					}
				}
				this.bool_2 = false;
				this.method_1();
			}
			if (!this.bool_1)
			{
				this.float_2 -= deltaTime;
				if (this.float_2 >= 0f)
				{
					return;
				}
				this.bool_1 = true;
				this.method_2();
			}
			this.float_0 -= deltaTime;
			if (this.float_0 < 0f)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				if (this.theInsaneAnimationManagerFSM_0 != null)
				{
					this.theInsaneAnimationManagerFSM_0.method_32(false);
				}
				return;
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0005FBC0 File Offset: 0x0005DDC0
		public override void vmethod_3(bool bool_3)
		{
			base.vmethod_3(bool_3);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEyeLaserPlusWarning", false);
			if (base.m_Status != BHVTaskStatus.SUCCESS)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				if (this.theInsaneAnimationManagerFSM_0 != null)
				{
					this.theInsaneAnimationManagerFSM_0.method_32(false);
				}
			}
			int count = this.list_1.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				global::UnityEngine.Object.Destroy(this.list_1[i]);
			}
			this.list_1.Clear();
			this.list_2.Clear();
			this.transform_0.parent = this.transform_1;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0005FC6C File Offset: 0x0005DE6C
		private void method_0()
		{
			int num = this.pointList_0.m_pointList.Length;
			float num2 = float.PositiveInfinity;
			for (int i = 0; i < num; i++)
			{
				Vector3 position = this.pointList_0.m_pointList[i].transform.position;
				float sqrMagnitude = (position - this.bhvtaskParamEyeLaserPlus_0.gameObject_0.transform.position).sqrMagnitude;
				if (sqrMagnitude < num2)
				{
					this.gameObject_0 = this.pointList_0.m_pointList[i].gameObject;
					num2 = sqrMagnitude;
				}
			}
			if (this.gameObject_0 == null)
			{
				return;
			}
			this.list_0.Add(this.gameObject_0);
			float num3 = this.bhvtaskParamEyeLaserPlus_0.float_2 * this.bhvtaskParamEyeLaserPlus_0.float_2;
			for (int j = 0; j < num; j++)
			{
				if (!(this.pointList_0.m_pointList[j].gameObject == this.gameObject_0))
				{
					Vector3 position2 = this.pointList_0.m_pointList[j].transform.position;
					float sqrMagnitude2 = (position2 - this.gameObject_0.transform.position).sqrMagnitude;
					if (sqrMagnitude2 < num3)
					{
						this.list_0.Add(this.pointList_0.m_pointList[j].gameObject);
					}
				}
			}
			int count = this.list_0.Count;
			if (count <= 1)
			{
				return;
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0005FDDC File Offset: 0x0005DFDC
		private void method_1()
		{
			GameObject gameObject = (this.bhvtaskManager_0.m_entity as EntityNpc).m_spawnObjPrefabList[1];
			if (gameObject == null)
			{
				return;
			}
			float num = 1.2f;
			int count = this.list_0.Count;
			for (int i = 0; i < count; i++)
			{
				for (int j = i + 1; j < count; j++)
				{
					GameObject gameObject2 = global::UnityEngine.Object.Instantiate(gameObject) as GameObject;
					if (gameObject2 != null)
					{
						this.list_1.Add(gameObject2);
						Vector3 vector = this.list_0[i].transform.position;
						vector.y += num;
						gameObject2.GetComponent<LineRenderer>().SetPosition(0, vector);
						this.list_2.Add(vector);
						vector = this.list_0[j].transform.position;
						vector.y += num;
						gameObject2.GetComponent<LineRenderer>().SetPosition(1, vector);
						this.list_2.Add(vector);
					}
				}
			}
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0005FEF8 File Offset: 0x0005E0F8
		private void method_2()
		{
			GameObject gameObject = (this.bhvtaskManager_0.m_entity as EntityNpc).m_spawnObjPrefabList[2];
			if (gameObject == null)
			{
				return;
			}
			int count = this.list_2.Count;
			int i = 0;
			while (i < count)
			{
				GameObject gameObject2 = global::UnityEngine.Object.Instantiate(gameObject) as GameObject;
				if (gameObject2 != null)
				{
					this.list_1.Add(gameObject2);
					gameObject2.GetComponent<LineRenderer>().SetPosition(0, this.list_2[i++]);
					gameObject2.GetComponent<LineRenderer>().SetPosition(1, this.list_2[i++]);
				}
			}
		}

		// Token: 0x040008EA RID: 2282
		private BHVTaskParamEyeLaserPlus bhvtaskParamEyeLaserPlus_0;

		// Token: 0x040008EB RID: 2283
		private TheInsaneAnimationManagerFSM theInsaneAnimationManagerFSM_0;

		// Token: 0x040008EC RID: 2284
		private Transform transform_0;

		// Token: 0x040008ED RID: 2285
		private Transform transform_1;

		// Token: 0x040008EE RID: 2286
		private float float_0 = 1f;

		// Token: 0x040008EF RID: 2287
		private float float_1 = 4f;

		// Token: 0x040008F0 RID: 2288
		private float float_2 = 4f;

		// Token: 0x040008F1 RID: 2289
		private bool bool_1;

		// Token: 0x040008F2 RID: 2290
		private bool bool_2 = true;

		// Token: 0x040008F3 RID: 2291
		private GameObject gameObject_0;

		// Token: 0x040008F4 RID: 2292
		private PointList pointList_0;

		// Token: 0x040008F5 RID: 2293
		private List<GameObject> list_0 = new List<GameObject>();

		// Token: 0x040008F6 RID: 2294
		private List<GameObject> list_1 = new List<GameObject>();

		// Token: 0x040008F7 RID: 2295
		private List<Vector3> list_2 = new List<Vector3>();
	}
}
