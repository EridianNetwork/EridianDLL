using System;
using System.Xml;
using System.Xml.Serialization;
using Core;
using UnityEngine;

// Token: 0x0200090F RID: 2319
public sealed class PrefabManager
{
	// Token: 0x06003FD7 RID: 16343 RVA: 0x0012E1FC File Offset: 0x0012C3FC
	public static bool smethod_0<T>(XmlNode xmlNode_0, ref T gparam_0)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(gparam_0.GetType());
		if (xmlSerializer == null)
		{
			return false;
		}
		XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlNode_0);
		if (xmlNodeReader == null)
		{
			return false;
		}
		bool flag;
		try
		{
			gparam_0 = (T)((object)xmlSerializer.Deserialize(xmlNodeReader));
			return true;
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Framework, ex.ToString());
			flag = false;
		}
		return flag;
	}

	// Token: 0x06003FD8 RID: 16344 RVA: 0x0012E264 File Offset: 0x0012C464
	private static XmlNode smethod_1(string string_0, string string_1)
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0(string_1);
		if (textAsset != null)
		{
			return PrefabManager.smethod_3(string_0, textAsset);
		}
		return null;
	}

	// Token: 0x06003FD9 RID: 16345 RVA: 0x0012E290 File Offset: 0x0012C490
	private static string smethod_2(string string_0)
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0(string_0);
		if (textAsset == null)
		{
			return null;
		}
		return textAsset.text;
	}

	// Token: 0x06003FDA RID: 16346 RVA: 0x0012E2BC File Offset: 0x0012C4BC
	private static XmlNode smethod_3(string string_0, TextAsset textAsset_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return null;
		}
		if (textAsset_0 == null)
		{
			return null;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset_0.text);
		return xmlDocument.GetElementsByTagName(string_0)[0];
	}

	// Token: 0x06003FDB RID: 16347 RVA: 0x0012E300 File Offset: 0x0012C500
	public static bool smethod_4(GameObject gameObject_0, TextAsset textAsset_0)
	{
		if (gameObject_0 == null)
		{
			return false;
		}
		XmlNode xmlNode = PrefabManager.smethod_3("ComponentList", textAsset_0);
		if (xmlNode == null)
		{
			return false;
		}
		XmlNodeList childNodes = xmlNode.ChildNodes;
		if (childNodes == null)
		{
			return false;
		}
		for (int i = 0; i < childNodes.Count; i++)
		{
			XmlNode xmlNode2 = childNodes[i];
			if (xmlNode2.Name == "Prefab")
			{
				if (gameObject_0.GetComponent<EntityPlayer>() != null && !PrefabManager.smethod_6(gameObject_0, xmlNode2))
				{
					DebugUtils.LogError(LogCategory.Framework, "GameObject: " + gameObject_0.name + " has Invalid Prefab: " + xmlNode2.OuterXml);
					return false;
				}
			}
			else if (xmlNode2.Name == "MonoBehaviour")
			{
				if (!PrefabManager.smethod_8(gameObject_0, xmlNode2))
				{
					DebugUtils.LogError(LogCategory.Framework, "GameObject: " + gameObject_0.name + " has Invalid MonoBehaviour: " + xmlNode2.OuterXml);
					return false;
				}
			}
			else
			{
				if (!(xmlNode2.Name == "Collider"))
				{
					DebugUtils.LogError(LogCategory.Framework, "Unkown Component");
					return false;
				}
				if (!PrefabManager.smethod_9(gameObject_0, xmlNode2))
				{
					DebugUtils.LogError(LogCategory.Framework, "GameObject: " + gameObject_0.name + " has Invalid Collider: " + xmlNode2.OuterXml);
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06003FDC RID: 16348 RVA: 0x0002ACAF File Offset: 0x00028EAF
	public static bool smethod_5(GameObject gameObject_0)
	{
		gameObject_0.SendMessage("OnSpawnCompleted", null, SendMessageOptions.DontRequireReceiver);
		return true;
	}

	// Token: 0x06003FDD RID: 16349 RVA: 0x0012E42C File Offset: 0x0012C62C
	private static bool smethod_6(GameObject gameObject_0, XmlNode xmlNode_0)
	{
		if (gameObject_0 == null)
		{
			return false;
		}
		if (xmlNode_0 == null)
		{
			return false;
		}
		bool flag = true;
		XmlAttribute xmlAttribute = xmlNode_0.Attributes["IsLocalOnly"];
		if (xmlAttribute != null && xmlAttribute.Value.ToUpper() == "TRUE")
		{
			flag = gameObject_0.GetComponent<Entity>().vmethod_26();
		}
		xmlAttribute = xmlNode_0.Attributes["IsRemoteOnly"];
		if (xmlAttribute != null && xmlAttribute.Value.ToUpper() == "TRUE")
		{
			flag = !gameObject_0.GetComponent<Entity>().vmethod_26();
		}
		if (flag)
		{
			xmlAttribute = xmlNode_0.Attributes["NeedInstantiate"];
			if (xmlAttribute == null || xmlAttribute.Value.ToUpper() == "TRUE")
			{
				xmlAttribute = xmlNode_0.Attributes["Name"];
				if (xmlAttribute == null)
				{
					return false;
				}
				global::UnityEngine.Object @object = ResourcesLoader.smethod_0(xmlAttribute.Value);
				if (@object == null)
				{
					return false;
				}
				GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(@object);
				if (gameObject == null)
				{
					return false;
				}
				gameObject.transform.parent = gameObject_0.transform;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				xmlAttribute = xmlNode_0.Attributes["Scale"];
				if (xmlAttribute != null)
				{
					float num = 1f;
					float.TryParse(xmlAttribute.Value, out num);
					if (num > 1E-45f)
					{
						gameObject.transform.localScale = Vector3.one * num;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06003FDE RID: 16350 RVA: 0x0012E5B4 File Offset: 0x0012C7B4
	private static Component smethod_7(GameObject gameObject_0, XmlNode xmlNode_0, ref bool bool_0)
	{
		if (gameObject_0 == null)
		{
			return null;
		}
		if (xmlNode_0 == null)
		{
			return null;
		}
		bool flag = true;
		XmlAttribute xmlAttribute = xmlNode_0.Attributes["IsLocalOnly"];
		if (xmlAttribute != null && xmlAttribute.Value.ToUpper() == "TRUE")
		{
			flag = gameObject_0.GetComponent<Entity>().vmethod_26();
		}
		xmlAttribute = xmlNode_0.Attributes["IsRemoteOnly"];
		if (xmlAttribute != null && xmlAttribute.Value.ToUpper() == "TRUE")
		{
			flag = !gameObject_0.GetComponent<Entity>().vmethod_26();
		}
		if (!flag)
		{
			return null;
		}
		xmlAttribute = xmlNode_0.Attributes["Type"];
		if (xmlAttribute == null)
		{
			return null;
		}
		string value = xmlAttribute.Value;
		xmlAttribute = xmlNode_0.Attributes["NeedInstantiate"];
		Component component;
		if (xmlAttribute != null && !(xmlAttribute.Value.ToUpper() == "TRUE"))
		{
			component = gameObject_0.GetComponent(value);
		}
		else
		{
			component = gameObject_0.AddComponent(value);
		}
		xmlAttribute = xmlNode_0.Attributes["NeedInitialize"];
		bool_0 = xmlAttribute != null && xmlAttribute.Value.ToUpper() == "TRUE";
		return component;
	}

	// Token: 0x06003FDF RID: 16351 RVA: 0x0012E6D8 File Offset: 0x0012C8D8
	private static bool smethod_8(GameObject gameObject_0, XmlNode xmlNode_0)
	{
		bool flag = false;
		Component component = PrefabManager.smethod_7(gameObject_0, xmlNode_0, ref flag);
		if (component == null)
		{
			return true;
		}
		if (flag)
		{
			if (component is IPrefabManagerXmlSetup)
			{
				XmlNode xmlNode = xmlNode_0.FirstChild;
				if (xmlNode == null)
				{
					return false;
				}
				if (xmlNode.Name != "Settings")
				{
					return false;
				}
				XmlAttribute xmlAttribute = xmlNode.Attributes["Type"];
				if (xmlAttribute == null)
				{
					return false;
				}
				if (xmlAttribute.Value.ToUpper() == "XML")
				{
					xmlAttribute = xmlNode.Attributes["FileName"];
					if (xmlAttribute == null)
					{
						return false;
					}
					xmlNode = PrefabManager.smethod_1("Settings", xmlAttribute.Value);
					if (xmlNode == null)
					{
						return false;
					}
				}
				else if (xmlAttribute.Value.ToUpper() != "ATTRIBUTES")
				{
					return false;
				}
				return ((IPrefabManagerXmlSetup)component).imethod_0(xmlNode);
			}
			else if (component is IPrefabManagerXmlGenericSetup)
			{
				XmlNode firstChild = xmlNode_0.FirstChild;
				if (firstChild == null)
				{
					return false;
				}
				if (firstChild.Name != "Settings")
				{
					return false;
				}
				XmlAttribute xmlAttribute2 = firstChild.Attributes["Type"];
				if (xmlAttribute2 == null)
				{
					return false;
				}
				if (xmlAttribute2.Value.ToUpper() != "XMLGENERIC")
				{
					return false;
				}
				xmlAttribute2 = firstChild.Attributes["FileName"];
				if (xmlAttribute2 == null)
				{
					return false;
				}
				string text = PrefabManager.smethod_2(xmlAttribute2.Value);
				return !string.IsNullOrEmpty(text) && ((IPrefabManagerXmlGenericSetup)component).imethod_0(text);
			}
		}
		return true;
	}

	// Token: 0x06003FE0 RID: 16352 RVA: 0x0012E854 File Offset: 0x0012CA54
	private static bool smethod_9(GameObject gameObject_0, XmlNode xmlNode_0)
	{
		bool flag = false;
		Component component = PrefabManager.smethod_7(gameObject_0, xmlNode_0, ref flag);
		if (component == null)
		{
			return true;
		}
		if (!flag)
		{
			return true;
		}
		XmlNode firstChild = xmlNode_0.FirstChild;
		if (firstChild == null)
		{
			return false;
		}
		if (firstChild.Name != "Settings")
		{
			return false;
		}
		XmlAttribute xmlAttribute = firstChild.Attributes["Type"];
		return xmlAttribute != null && !(xmlAttribute.Value.ToUpper() != "ATTRIBUTES") && PrefabManager.smethod_10(gameObject_0, component, firstChild);
	}

	// Token: 0x06003FE1 RID: 16353 RVA: 0x0012E8D8 File Offset: 0x0012CAD8
	private static bool smethod_10(GameObject gameObject_0, Component component_0, XmlNode xmlNode_0)
	{
		if (gameObject_0 == null)
		{
			return false;
		}
		if (xmlNode_0 == null)
		{
			return false;
		}
		if (component_0 == null)
		{
			return false;
		}
		if (component_0.GetType() == typeof(CapsuleCollider))
		{
			float num = 0.5f;
			XmlAttribute xmlAttribute = xmlNode_0.Attributes["Radius"];
			if (xmlAttribute == null)
			{
				return false;
			}
			float.TryParse(xmlAttribute.Value, out num);
			if (num > 0f)
			{
				((CapsuleCollider)component_0).radius = num;
			}
			float num2 = 1f;
			xmlAttribute = xmlNode_0.Attributes["Height"];
			if (xmlAttribute == null)
			{
				return false;
			}
			float.TryParse(xmlAttribute.Value, out num2);
			if (num2 > 0f)
			{
				((CapsuleCollider)component_0).height = num2;
				((CapsuleCollider)component_0).center = new Vector3(0f, num2 / 2f, 0f);
			}
			return true;
		}
		else
		{
			if (component_0.GetType() != typeof(CharacterController))
			{
				return false;
			}
			float num3 = 0.5f;
			XmlAttribute xmlAttribute2 = xmlNode_0.Attributes["Radius"];
			if (xmlAttribute2 == null)
			{
				return false;
			}
			float.TryParse(xmlAttribute2.Value, out num3);
			if (num3 > 0f)
			{
				((CharacterController)component_0).radius = num3;
			}
			float num4 = 1f;
			xmlAttribute2 = xmlNode_0.Attributes["Height"];
			if (xmlAttribute2 == null)
			{
				return false;
			}
			float.TryParse(xmlAttribute2.Value, out num4);
			if (num4 > 0f)
			{
				((CharacterController)component_0).height = num4;
				((CharacterController)component_0).center = new Vector3(0f, num4 / 2f, 0f);
			}
			return true;
		}
	}
}
