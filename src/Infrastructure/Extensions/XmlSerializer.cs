using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

/// <summary>
/// Encapsulates (de-)serializing an object to/from a xml file.
/// </summary>
/// <typeparam name="T">The type of the object that is (de-)serialized.</typeparam>
public class XmlSerializer<T> where T : class
{
	/// <summary>
	/// Serializes the given object into the specified file.
	/// </summary>
	/// <param name="obj">The object that will be serialized.</param>
	/// <param name="filePath">The path to the file the object will be serialized into. The specified
	/// file will be created or overwritten.</param>
	public static void Serialize(T obj, string filePath)
	{
		Stream stream = null;
		try
		{
			stream = File.Create(filePath);
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(stream, obj);
		}
		catch (Exception e)
		{
			Trace.WriteLine(e.ToString());
			throw;
		}
		finally
		{
			if (stream != null)
				stream.Close();
		}
	}

	/// <summary>
	/// Deserializes an object of the given type from the given file.
	/// </summary>
	/// <param name="filePath">The path to the file that stores the serialized object.</param>
	/// <returns>Returns the deserialized object.</returns>
	public static T Deserialize(string filePath)
	{
		FileStream stream = null;
		T obj = null;

		try
		{
			stream = File.OpenRead(filePath);
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			obj = (T)serializer.Deserialize(stream);
		}
		catch (Exception e)
		{
			Trace.WriteLine(e.ToString());
			throw;
		}
		finally
		{
			if (stream != null)
				stream.Close();
		}

		return obj;
	}

	/// <summary>
	/// Serializes the given object into the specified stream.
	/// </summary>
	/// <param name="obj">The object that will be serialized.</param>
	/// <param name="stream">The stream the serialized object should be written to.</param>
	public static void Serialize(T obj, Stream stream)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(T));
		serializer.Serialize(stream, obj);
	}

	/// <summary>
	/// Deserializes an object of the given type from the given stream.
	/// </summary>
	/// <param name="stream">The stream the object should be deserialized from.</returns>
	public static T Deserialize(Stream stream)
	{
		T obj = null;

		XmlSerializer serializer = new XmlSerializer(typeof(T));
		obj = (T)serializer.Deserialize(stream);

		return obj;
	}
}
