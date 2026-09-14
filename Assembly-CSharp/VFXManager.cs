using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200008F RID: 143
public class VFXManager : MonoBehaviour
{
	// Token: 0x060002FF RID: 767 RVA: 0x00043BEC File Offset: 0x00041DEC
	public static void smethod_0()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		List<global::UnityEngine.Object> list = new List<global::UnityEngine.Object>();
		global::UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(global::UnityEngine.Object));
		for (int i = 0; i < array.Length; i++)
		{
			if (!(null == array[i]))
			{
				string text = array[i].ToString();
				if (text != null && text.Contains("PRO_Halo"))
				{
					num++;
					GameObject gameObject = array[i] as GameObject;
					if (null != gameObject)
					{
						num2++;
						list.Add(array[i]);
						if (VFXManager.s_Assets.Contains(array[i]))
						{
							num4++;
						}
						if (VFXManager.s_VFXTable.ContainsValue(array[i]))
						{
							num3++;
						}
					}
				}
			}
		}
		DebugUtils.LogError(LogCategory.AI, string.Concat(new object[] { "PRO_Halo object count ", num, "; Halo gameObject ", num2, "; haloObjectsInSAssets ", num4, "; haloObjectsInVfxTable ", num3 }));
		for (int j = 0; j < list.Count; j++)
		{
			string text2 = string.Concat(new object[]
			{
				"<name> ",
				list[j].name,
				" <id> ",
				list[j].GetInstanceID(),
				" <Type> ",
				list[j].GetType(),
				" <InSAssets> ",
				VFXManager.s_Assets.Contains(list[j]),
				" <InVfxTable> ",
				VFXManager.s_VFXTable.ContainsValue(list[j])
			});
			GameObject gameObject2 = list[j] as GameObject;
			if (gameObject2 != null)
			{
				text2 = text2 + " <IsGameObject> " + gameObject2.name;
				if (gameObject2.transform.parent != null)
				{
					string text3 = text2;
					text2 = string.Concat(new object[]
					{
						text3,
						" <Parent> ",
						gameObject2.transform.parent.name,
						" <ParentID>",
						gameObject2.transform.parent.gameObject.GetInstanceID()
					});
					Transform parent = gameObject2.transform.parent.parent;
					if (parent != null)
					{
						text3 = text2;
						text2 = string.Concat(new object[]
						{
							text3,
							" <grandParent> ",
							parent.name,
							" <grandParentID>",
							parent.gameObject.GetInstanceID()
						});
					}
				}
			}
			DebugUtils.LogWarning(LogCategory.AI, text2);
		}
		list.Clear();
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00043ED4 File Offset: 0x000420D4
	public static void smethod_1(BaseAssetBundle baseAssetBundle_0)
	{
		if (baseAssetBundle_0 != null && VFXManager.s_VFXTable.Count <= 0)
		{
			if (VFXManager.smethod_3())
			{
				global::UnityEngine.Object[] array = ResourcesLoader.smethod_4(baseAssetBundle_0);
				if (array == null)
				{
					return;
				}
				foreach (global::UnityEngine.Object @object in array)
				{
					if (@object is GameObject)
					{
						if (!VFXManager.s_VFXTable.ContainsKey(@object.name))
						{
							VFXManager.s_VFXTable.Add(@object.name, @object);
							VFXManager.s_InstanceTable.Add(@object.name, new List<global::UnityEngine.Object>());
						}
						else
						{
							VFXManager.s_Assets.Add(@object);
						}
					}
					else
					{
						VFXManager.s_Assets.Add(@object);
					}
				}
				DebugUtils.Log(LogCategory.Framework, VFXManager.s_VFXTable.Count + " vfx assets loaded");
			}
			return;
		}
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00043F98 File Offset: 0x00042198
	public static bool smethod_2()
	{
		foreach (KeyValuePair<string, List<global::UnityEngine.Object>> keyValuePair in VFXManager.s_InstanceTable)
		{
			List<global::UnityEngine.Object> value = keyValuePair.Value;
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] != null)
				{
					DebugUtils.Log(LogCategory.Framework, "Cannot release vfx because some instances are still referencering those assets");
					return false;
				}
			}
			value.Clear();
			value.TrimExcess();
		}
		VFXManager.s_InstanceTable.Clear();
		foreach (KeyValuePair<string, global::UnityEngine.Object> keyValuePair2 in VFXManager.s_VFXTable)
		{
			global::UnityEngine.Object.DestroyImmediate(keyValuePair2.Value, true);
		}
		VFXManager.s_VFXTable.Clear();
		for (int j = 0; j < VFXManager.s_Assets.Count; j++)
		{
			ResourcesLoader.smethod_6(VFXManager.s_Assets[j]);
		}
		VFXManager.s_Assets.Clear();
		return true;
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00044080 File Offset: 0x00042280
	private void Start()
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			VFXforNPC vfxforNPC = this.m_particleList[i];
			if (vfxforNPC != null)
			{
				global::UnityEngine.Object @object = null;
				if (VFXManager.s_VFXTable.TryGetValue(vfxforNPC.m_particleGameObjectName, out @object))
				{
					vfxforNPC.m_particleGameObject = (GameObject)global::UnityEngine.Object.Instantiate(@object);
					Quaternion localRotation = vfxforNPC.m_particleGameObject.transform.localRotation;
					vfxforNPC.m_particleGameObject.transform.parent = vfxforNPC.m_particleTransform;
					vfxforNPC.m_particleGameObject.transform.localPosition = Vector3.zero;
					vfxforNPC.m_particleGameObject.transform.localRotation = localRotation;
					vfxforNPC.m_particle = vfxforNPC.m_particleGameObject.particleSystem;
					vfxforNPC.m_particleGameObject.SetActive(false);
					VFXManager.s_InstanceTable[vfxforNPC.m_particleGameObjectName].Add(vfxforNPC.m_particleGameObject);
				}
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Framework, vfxforNPC.m_particleGameObjectName + " has no resource to instantiate an object");
			}
		}
		this.m_audioCtl = base.GetComponent<BaseEventTriggerCtl>();
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00044190 File Offset: 0x00042390
	public void method_0(ENPCParticleType enpcparticleType_0, Transform transform_0)
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			VFXforNPC vfxforNPC = this.m_particleList[i];
			if (enpcparticleType_0 == vfxforNPC.m_type)
			{
				Transform transform = this.method_16(vfxforNPC, transform_0);
				if (transform != null && vfxforNPC.m_particleGameObject != null)
				{
					vfxforNPC.m_particleGameObject.transform.parent = transform;
					vfxforNPC.m_particleGameObject.transform.localPosition = Vector3.zero;
					vfxforNPC.m_particleGameObject.transform.localRotation = Quaternion.identity;
				}
			}
		}
	}

	// Token: 0x06000304 RID: 772 RVA: 0x00044228 File Offset: 0x00042428
	public void method_1(ENPCParticleType enpcparticleType_0)
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			VFXforNPC vfxforNPC = this.m_particleList[i];
			if (enpcparticleType_0 == vfxforNPC.m_type)
			{
				global::UnityEngine.Object.Destroy(vfxforNPC.m_particleGameObject);
			}
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00044270 File Offset: 0x00042470
	public bool method_2(ENPCParticleType enpcparticleType_0, Transform transform_0, Vector3 vector3_0, Quaternion quaternion_0, float float_0 = 0f)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		if (this.m_particleList == null)
		{
			return false;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			VFXforNPC vfxforNPC = this.m_particleList[i];
			if (vfxforNPC != null && enpcparticleType_0 == vfxforNPC.m_type && !(vfxforNPC.m_particle == null))
			{
				if (!vfxforNPC.m_particle.isPlaying)
				{
					if (vfxforNPC.m_particleGameObject == null)
					{
						goto IL_00EA;
					}
					Transform transform = this.method_16(vfxforNPC, transform_0);
					vfxforNPC.m_particleGameObject.transform.parent = transform;
					vfxforNPC.m_particleGameObject.transform.localPosition = vector3_0;
					vfxforNPC.m_particleGameObject.transform.localRotation = quaternion_0;
					vfxforNPC.m_particleGameObject.SetActive(true);
					vfxforNPC.m_particle.Play();
					if (!string.IsNullOrEmpty(vfxforNPC.m_audioEvent))
					{
						this.m_audioCtl.TriggerEventByName(vfxforNPC.m_audioEvent);
					}
					if (float_0 > 0f)
					{
						if (vfxforNPC.m_timer == null)
						{
							goto IL_00EA;
						}
						vfxforNPC.m_timer.Start(float_0);
					}
				}
				return true;
			}
			IL_00EA:;
		}
		return false;
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0004438C File Offset: 0x0004258C
	public bool method_3(ENPCParticleType enpcparticleType_0, Transform transform_0, bool bool_0, float float_0 = 0f, bool bool_1 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		if (this.m_particleList == null)
		{
			return false;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			VFXforNPC vfxforNPC = this.m_particleList[i];
			if (vfxforNPC != null && enpcparticleType_0 == vfxforNPC.m_type && !(vfxforNPC.m_particle == null))
			{
				if (bool_1 || !vfxforNPC.m_particle.isPlaying)
				{
					if (vfxforNPC.m_particleGameObject == null)
					{
						goto IL_0137;
					}
					Transform transform = this.method_16(vfxforNPC, transform_0);
					if (bool_0)
					{
						vfxforNPC.m_particleGameObject.transform.parent = transform;
						vfxforNPC.m_particleGameObject.transform.localPosition = Vector3.zero;
						vfxforNPC.m_particleGameObject.transform.localRotation = Quaternion.identity;
					}
					else
					{
						vfxforNPC.m_particleGameObject.transform.parent = null;
						vfxforNPC.m_particleGameObject.transform.position = transform.position;
						vfxforNPC.m_particleGameObject.transform.rotation = transform.rotation;
					}
					vfxforNPC.m_particleGameObject.SetActive(true);
					vfxforNPC.m_particle.Play();
					if (!string.IsNullOrEmpty(vfxforNPC.m_audioEvent))
					{
						this.m_audioCtl.TriggerEventByName(vfxforNPC.m_audioEvent);
					}
					if (float_0 > 0f)
					{
						if (vfxforNPC.m_timer == null)
						{
							goto IL_0137;
						}
						vfxforNPC.m_timer.Start(float_0);
					}
				}
				return true;
			}
			IL_0137:;
		}
		return false;
	}

	// Token: 0x06000307 RID: 775 RVA: 0x000444F4 File Offset: 0x000426F4
	public bool method_4(ENPCParticleType enpcparticleType_0, float float_0 = 0f, bool bool_0 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		bool flag = false;
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particle == null)
				{
					return false;
				}
				if (bool_0 || !this.m_particleList[i].m_particle.isPlaying)
				{
					this.m_particleList[i].m_particleGameObject.SetActive(true);
					this.m_particleList[i].m_particle.Play();
					if (this.m_particleList[i].m_audioEvent != string.Empty)
					{
						this.m_audioCtl.TriggerEventByName(this.m_particleList[i].m_audioEvent);
					}
					if (float_0 > 0f)
					{
						this.m_particleList[i].m_timer.Start(float_0);
					}
				}
				flag = true;
			}
		}
		return flag;
	}

	// Token: 0x06000308 RID: 776 RVA: 0x000445E0 File Offset: 0x000427E0
	public bool method_5(ENPCParticleType enpcparticleType_0, Entity entity_0, Transform transform_0, Vector3 vector3_0, Quaternion quaternion_0, float float_0 = 0f, bool bool_0 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		int i = 0;
		while (i < this.m_particleList.Length)
		{
			if (this.m_particleList[i] == null)
			{
				return false;
			}
			if (enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particleGameObject == null)
				{
					return false;
				}
				if (this.m_particleList[i].m_particleGameObject.transform == null)
				{
					return false;
				}
				if (this.m_particleList[i].m_particle == null)
				{
					return false;
				}
				if (bool_0 || !this.m_particleList[i].m_particle.isPlaying)
				{
					this.m_particleList[i].m_particleGameObject.transform.parent = transform_0;
					this.m_particleList[i].m_particleGameObject.transform.localPosition = vector3_0;
					this.m_particleList[i].m_particleGameObject.transform.localRotation = quaternion_0;
					this.m_particleList[i].m_particleGameObject.SetActive(true);
					this.m_particleList[i].m_particle.Play();
					if (this.m_particleList[i].m_audioEvent != string.Empty)
					{
						this.m_audioCtl.TriggerEventByName(this.m_particleList[i].m_audioEvent);
					}
					if (float_0 > 0f)
					{
						this.m_particleList[i].m_timer.Start(float_0);
					}
				}
				return true;
			}
			else
			{
				i++;
			}
		}
		return false;
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0004474C File Offset: 0x0004294C
	public bool method_6(ENPCParticleType enpcparticleType_0, Vector3 vector3_0, Quaternion quaternion_0, float float_0 = 0f, bool bool_0 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (bool_0 || !this.m_particleList[i].m_particle.isPlaying)
				{
					this.m_particleList[i].m_particleGameObject.transform.position = vector3_0;
					this.m_particleList[i].m_particleGameObject.transform.rotation = quaternion_0;
					this.m_particleList[i].m_particleGameObject.SetActive(true);
					this.m_particleList[i].m_particle.Play();
					if (this.m_particleList[i].m_audioEvent != string.Empty)
					{
						this.m_audioCtl.TriggerEventByName(this.m_particleList[i].m_audioEvent);
					}
					if (float_0 > 0f)
					{
						this.m_particleList[i].m_timer.Start(float_0);
					}
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600030A RID: 778 RVA: 0x00044848 File Offset: 0x00042A48
	public bool method_7(ENPCParticleType enpcparticleType_0, Transform transform_0, bool bool_0 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		if (transform_0 == null)
		{
			return false;
		}
		if (this.m_particleList == null)
		{
			return false;
		}
		int i = 0;
		while (i < this.m_particleList.Length)
		{
			if (this.m_particleList[i] != null && enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particle == null)
				{
					return false;
				}
				if (!(this.m_particleList[i].m_particleGameObject == null) && !(this.m_particleList[i].m_particle == null))
				{
					if (bool_0 || !this.m_particleList[i].m_particle.isPlaying)
					{
						this.m_particleList[i].m_particleGameObject.transform.parent = null;
						this.m_particleList[i].m_particleGameObject.transform.position = transform_0.position;
						this.m_particleList[i].m_particleGameObject.transform.rotation = transform_0.rotation;
						this.m_particleList[i].m_particleGameObject.SetActive(true);
						this.m_particleList[i].m_particle.Play();
						if (this.m_audioCtl != null && !string.IsNullOrEmpty(this.m_particleList[i].m_audioEvent))
						{
							this.m_audioCtl.TriggerEventByName(this.m_particleList[i].m_audioEvent);
						}
					}
					return true;
				}
				return false;
			}
			else
			{
				i++;
			}
		}
		return false;
	}

	// Token: 0x0600030B RID: 779 RVA: 0x000449BC File Offset: 0x00042BBC
	public bool method_8(ENPCParticleType enpcparticleType_0, Entity entity_0, Vector3 vector3_0, Quaternion quaternion_0, bool bool_0 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		int i = 0;
		while (i < this.m_particleList.Length)
		{
			if (this.m_particleList[i] == null)
			{
				return false;
			}
			if (enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particleGameObject == null)
				{
					return false;
				}
				if (this.m_particleList[i].m_particleGameObject.transform == null)
				{
					return false;
				}
				if (this.m_particleList[i].m_particle == null)
				{
					return false;
				}
				if (bool_0 || !this.m_particleList[i].m_particle.isPlaying)
				{
					this.m_particleList[i].m_particleGameObject.transform.parent = null;
					this.m_particleList[i].m_particleGameObject.transform.position = vector3_0;
					this.m_particleList[i].m_particleGameObject.transform.rotation = quaternion_0;
					this.m_particleList[i].m_particleGameObject.SetActive(true);
					this.m_particleList[i].m_particle.Play();
					if (this.m_particleList[i].m_audioEvent != string.Empty)
					{
						this.m_audioCtl.TriggerEventByName(this.m_particleList[i].m_audioEvent);
					}
				}
				return true;
			}
			else
			{
				i++;
			}
		}
		return false;
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00044B0C File Offset: 0x00042D0C
	public bool method_9(ENPCParticleType enpcparticleType_0, Vector3 vector3_0, Quaternion quaternion_0, bool bool_0 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		if (this.m_particleList == null)
		{
			return false;
		}
		int i = 0;
		while (i < this.m_particleList.Length)
		{
			if (this.m_particleList[i] != null && enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particle == null)
				{
					return false;
				}
				if (this.m_particleList[i].m_particleGameObject == null)
				{
					return false;
				}
				if (bool_0 || !this.m_particleList[i].m_particle.isPlaying)
				{
					this.m_particleList[i].m_particleGameObject.transform.position = vector3_0;
					this.m_particleList[i].m_particleGameObject.transform.rotation = quaternion_0;
					this.m_particleList[i].m_particleGameObject.SetActive(true);
					this.m_particleList[i].m_particle.Play();
					if (this.m_audioCtl != null && this.m_particleList[i].m_audioEvent != string.Empty)
					{
						this.m_audioCtl.TriggerEventByName(this.m_particleList[i].m_audioEvent);
					}
				}
				return true;
			}
			else
			{
				i++;
			}
		}
		return false;
	}

	// Token: 0x0600030D RID: 781 RVA: 0x00044C3C File Offset: 0x00042E3C
	public bool method_10(ENPCParticleType enpcparticleType_0, Vector3 vector3_0, bool bool_0 = true)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		if (this.m_particleList == null)
		{
			return false;
		}
		int i = 0;
		while (i < this.m_particleList.Length)
		{
			if (this.m_particleList[i] != null && enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particle == null)
				{
					return false;
				}
				if (this.m_particleList[i].m_particleGameObject == null)
				{
					return false;
				}
				if (bool_0 || !this.m_particleList[i].m_particle.isPlaying)
				{
					this.m_particleList[i].m_particleGameObject.transform.position = vector3_0;
					this.m_particleList[i].m_particleGameObject.SetActive(true);
					this.m_particleList[i].m_particle.Play();
					if (this.m_audioCtl != null && !string.IsNullOrEmpty(this.m_particleList[i].m_audioEvent))
					{
						this.m_audioCtl.TriggerEventByName(this.m_particleList[i].m_audioEvent);
					}
				}
				return true;
			}
			else
			{
				i++;
			}
		}
		return false;
	}

	// Token: 0x0600030E RID: 782 RVA: 0x00044D4C File Offset: 0x00042F4C
	public GameObject method_11(ENPCParticleType enpcparticleType_0, int int_0 = 0)
	{
		if (!VFXManager.smethod_3())
		{
			return null;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (enpcparticleType_0 == this.m_particleList[i].m_type && int_0-- == 0)
			{
				return this.m_particleList[i].m_particleGameObject;
			}
		}
		return null;
	}

	// Token: 0x0600030F RID: 783 RVA: 0x00044DA0 File Offset: 0x00042FA0
	public VFXforNPC method_12(ENPCParticleType enpcparticleType_0, int int_0 = 0)
	{
		if (!VFXManager.smethod_3())
		{
			return null;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (enpcparticleType_0 == this.m_particleList[i].m_type && int_0-- == 0)
			{
				return this.m_particleList[i];
			}
		}
		return null;
	}

	// Token: 0x06000310 RID: 784 RVA: 0x00044DF0 File Offset: 0x00042FF0
	public bool method_13(ENPCParticleType enpcparticleType_0)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particle != null)
				{
					this.m_particleList[i].m_particle.Stop();
				}
				if (this.m_particleList[i].m_particleGameObject != null)
				{
					this.m_particleList[i].m_particleGameObject.SetActive(false);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000311 RID: 785 RVA: 0x00044E80 File Offset: 0x00043080
	public void method_14(ENPCParticleType enpcparticleType_0)
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (enpcparticleType_0 == this.m_particleList[i].m_type)
			{
				if (this.m_particleList[i].m_particle != null)
				{
					this.m_particleList[i].m_particle.transform.parent = base.gameObject.transform;
					this.m_particleList[i].m_particle.Stop();
					this.m_particleList[i].m_particle.Clear();
				}
				if (this.m_particleList[i].m_particleGameObject != null)
				{
					this.m_particleList[i].m_particleGameObject.SetActive(false);
				}
				return;
			}
		}
	}

	// Token: 0x06000312 RID: 786 RVA: 0x00044F40 File Offset: 0x00043140
	private void Update()
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (this.m_particleList[i].m_timer.method_7())
			{
				this.m_particleList[i].m_particle.Stop();
				this.m_particleList[i].m_particleGameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x00044FA4 File Offset: 0x000431A4
	public void method_15()
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		for (int i = 0; i < this.m_particleList.Length; i++)
		{
			if (!(this.m_particleList[i].m_particle == null))
			{
				this.m_particleList[i].m_particle.transform.parent = base.gameObject.transform;
				this.m_particleList[i].m_particle.Stop();
				this.m_particleList[i].m_particle.Clear();
				this.m_particleList[i].m_particleGameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000314 RID: 788 RVA: 0x00004CC5 File Offset: 0x00002EC5
	public static bool smethod_3()
	{
		return (MonoSingleton<AppManager>.Instance != null && MonoSingleton<AppManager>.Instance.m_offlineMode) || !NetworkManager.smethod_3();
	}

	// Token: 0x06000315 RID: 789 RVA: 0x00004CEC File Offset: 0x00002EEC
	private Transform method_16(VFXforNPC vfxforNPC_0, Transform transform_0)
	{
		if (vfxforNPC_0.m_boneParent == string.Empty)
		{
			return null;
		}
		if (vfxforNPC_0.m_boneTr == null)
		{
			vfxforNPC_0.m_boneTr = this.method_17(transform_0, vfxforNPC_0.m_boneParent);
		}
		return vfxforNPC_0.m_boneTr;
	}

	// Token: 0x06000316 RID: 790 RVA: 0x00045040 File Offset: 0x00043240
	private Transform method_17(Transform transform_0, string string_0)
	{
		if (transform_0.name.Equals(string_0))
		{
			return transform_0;
		}
		foreach (object obj in transform_0)
		{
			Transform transform = (Transform)obj;
			Transform transform2 = this.method_17(transform, string_0);
			if (transform2 != null)
			{
				return transform2;
			}
		}
		return null;
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnReceiveEvent(string eventData)
	{
	}

	// Token: 0x06000318 RID: 792 RVA: 0x00004D29 File Offset: 0x00002F29
	public static bool smethod_4(ENPCParticleType enpcparticleType_0)
	{
		if (enpcparticleType_0 != ENPCParticleType.E_DamagedBulletNone && enpcparticleType_0 != ENPCParticleType.E_DamageHeadShot && enpcparticleType_0 != ENPCParticleType.E_DamageOnArmor)
		{
			if (enpcparticleType_0 != ENPCParticleType.E_DamageShieldHit)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x04000336 RID: 822
	private static List<global::UnityEngine.Object> s_Assets = new List<global::UnityEngine.Object>();

	// Token: 0x04000337 RID: 823
	private static Dictionary<string, global::UnityEngine.Object> s_VFXTable = new Dictionary<string, global::UnityEngine.Object>();

	// Token: 0x04000338 RID: 824
	private static Dictionary<string, List<global::UnityEngine.Object>> s_InstanceTable = new Dictionary<string, List<global::UnityEngine.Object>>();

	// Token: 0x04000339 RID: 825
	public VFXforNPC[] m_particleList;

	// Token: 0x0400033A RID: 826
	public BaseEventTriggerCtl m_audioCtl;
}
