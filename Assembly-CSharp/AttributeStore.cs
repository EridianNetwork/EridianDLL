using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020008C5 RID: 2245
[Serializable]
public class AttributeStore
{
	// Token: 0x06003E18 RID: 15896 RVA: 0x00029F72 File Offset: 0x00028172
	public AttributeStore()
	{
	}

	// Token: 0x06003E19 RID: 15897 RVA: 0x001284C0 File Offset: 0x001266C0
	public AttributeStore(bool bool_0)
	{
		if (bool_0)
		{
			this.m_AttributeDic.Clear();
			foreach (object obj in Enum.GetValues(typeof(AttributeType)))
			{
				AttributeType attributeType = (AttributeType)((int)obj);
				this.m_AttributeTypeNames.Add(Enum.GetName(typeof(AttributeType), attributeType));
				this.m_AttributeDic.Add(AttributeValueType.FloatAttributeValue);
			}
		}
	}

	// Token: 0x06003E1A RID: 15898 RVA: 0x00128574 File Offset: 0x00126774
	public BOLAttribute method_0(AttributeType attributeType_0)
	{
		BOLAttribute bolattribute = null;
		if (this.m_AttributeDic.Count > (int)attributeType_0)
		{
			bolattribute = new BOLAttribute(attributeType_0);
		}
		return bolattribute;
	}

	// Token: 0x06003E1B RID: 15899 RVA: 0x0012859C File Offset: 0x0012679C
	public BOLAttribute method_1()
	{
		return new BOLAttribute();
	}

	// Token: 0x06003E1C RID: 15900 RVA: 0x00029F90 File Offset: 0x00028190
	public AttributeValueType method_2(AttributeType attributeType_0)
	{
		return this.m_AttributeDic[(int)attributeType_0];
	}

	// Token: 0x06003E1D RID: 15901 RVA: 0x001285B0 File Offset: 0x001267B0
	public AttributeValue method_3(AttributeType attributeType_0)
	{
		string text = "XsdSettings." + Enum.GetName(typeof(AttributeValueType), this.m_AttributeDic[(int)attributeType_0]);
		Type type = Type.GetType(text, true);
		return (AttributeValue)Activator.CreateInstance(type);
	}

	// Token: 0x06003E1E RID: 15902 RVA: 0x00128600 File Offset: 0x00126800
	public AttributeValue method_4(AttributeType attributeType_0, AttributeValue attributeValue_0)
	{
		AttributeValue attributeValue = this.method_3(attributeType_0);
		attributeValue.vmethod_2(attributeValue_0);
		return attributeValue;
	}

	// Token: 0x06003E1F RID: 15903 RVA: 0x00128620 File Offset: 0x00126820
	public void method_5()
	{
		List<string> list = new List<string>();
		List<AttributeValueType> list2 = new List<AttributeValueType>();
		foreach (int value in Enum.GetValues(typeof(AttributeType)))
		{
			string name = Enum.GetName(typeof(AttributeType), (AttributeType)value);
			if (m_AttributeTypeNames.Contains(name))
			{
				int index = m_AttributeTypeNames.FindIndex((string string_0) => string_0.Equals(name));
				list.Add(name);
				list2.Add(m_AttributeDic[index]);
			}
			else
			{
				list.Add(name);
				list2.Add(AttributeValueType.FloatAttributeValue);
			}
		}
		m_AttributeDic = list2;
		m_AttributeTypeNames = list;
	}
	// Token: 0x17000347 RID: 839
	// (get) Token: 0x06003E20 RID: 15904 RVA: 0x00029F9E File Offset: 0x0002819E
	// (set) Token: 0x06003E21 RID: 15905 RVA: 0x00029FBB File Offset: 0x000281BB
	public static AttributeStore attributeStore
	{
		get
		{
			if (AttributeStore.m_attributeStore == null)
			{
				AttributeStore.smethod_1();
				AttributeStore.m_attributeStore.method_5();
			}
			return AttributeStore.m_attributeStore;
		}
		protected set
		{
			AttributeStore.m_attributeStore = value;
		}
	}

	// Token: 0x06003E22 RID: 15906 RVA: 0x00128728 File Offset: 0x00126928
	public static void smethod_0()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(AttributeStore));
		using (TextWriter textWriter = new StreamWriter("Assets/Resources/WeaponEditor/Attribute.XML"))
		{
			xmlSerializer.Serialize(textWriter, AttributeStore.m_attributeStore);
			textWriter.Close();
		}
	}

	// Token: 0x06003E23 RID: 15907 RVA: 0x00128780 File Offset: 0x00126980
	private static void smethod_1()
	{
		TextAsset textAsset = ResourcesLoader.smethod_0("WeaponEditor/Attribute") as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(AttributeStore));
		using (Stream stream = new MemoryStream(textAsset.bytes))
		{
			AttributeStore.m_attributeStore = (AttributeStore)xmlSerializer.Deserialize(stream);
			stream.Close();
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}

	// Token: 0x04002BB9 RID: 11193
	public const string AssetPath = "Assets/Resources/WeaponEditor/Attribute.XML";

	// Token: 0x04002BBA RID: 11194
	public const string ResourcesAssetPath = "WeaponEditor/Attribute";

	// Token: 0x04002BBB RID: 11195
	[SerializeField]
	public List<AttributeValueType> m_AttributeDic = new List<AttributeValueType>();

	// Token: 0x04002BBC RID: 11196
	[SerializeField]
	public List<string> m_AttributeTypeNames = new List<string>();

	// Token: 0x04002BBD RID: 11197
	private static AttributeStore m_attributeStore;
}
