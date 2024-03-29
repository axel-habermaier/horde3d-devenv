using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;


/// <summary>
/// Provides extensions to Linq to Xml.
/// </summary>
public static class LinqToXml
{
	/// <summary>
	/// Gets the elements with the specified name from an xml string with multiple root nodes.
	/// </summary>
	/// <param name="xmlContent">The xml content.</param>
	/// <param name="elementName">The name of the elements to be retrieved.</param>
	/// <returns>Returns (using yield) all elements with the given name.</returns>
	public static IEnumerable<XElement> GetElements(string xmlContent, string elementName)
	{
		if (String.IsNullOrEmpty(xmlContent))
			throw new ArgumentNullException("xmlContent");

		if (String.IsNullOrEmpty(elementName))
			throw new ArgumentNullException("elementName");

		var settings = new XmlReaderSettings();
		settings.ConformanceLevel = ConformanceLevel.Fragment;

		using (var stringReader = new StringReader(xmlContent))
		using (var reader = XmlReader.Create(stringReader, settings))
		{
			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						if (reader.Name == elementName)
						{
							XElement el = XElement.ReadFrom(reader) as XElement;
							if (el != null)
								yield return el;
						}
						break;
				}
			}
		}
	}
}
