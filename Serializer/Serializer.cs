using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer {
	/// <summary>
	/// Serializer for T-objects
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Serializer<T>
		where T : class {
		public Serializer() {
		}

		/// <summary>
		/// Save object to file
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public bool Save(string filename, T obj, SerializationMethod method) {
			FileStream stream = File.Create(filename);

			if ( stream != null ) {
				switch ( method ) {
					case SerializationMethod.Xml: {
							Serialize_Xml(stream, obj);
						}
						break;

					case SerializationMethod.Binary: {
							Serialize_Binary(stream, obj);
						}
						break;
				}
				stream.Close();

				return true;
			} else {
				return false;
			}
		}

		private void Serialize_Xml(FileStream stream, T obj) {
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(stream, obj);
		}

		private void Serialize_Binary(FileStream stream, T obj) {
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, obj);
		}

		/// <summary>
		/// Load object from file
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public T Open(string filename, SerializationMethod method) {
			FileStream stream = File.Open(filename, FileMode.Open);

			T obj = null;

			switch ( method ) {
				case SerializationMethod.Xml: {
						obj = Deserialize_Xml(stream);
					}
					break;

				case SerializationMethod.Binary: {
						obj = Deserialize_Binary(stream);
					}
					break;
			}

			stream.Close();

			return obj;
		}

		private T Deserialize_Xml(Stream stream) {
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			T obj = (T)serializer.Deserialize(stream);

			return obj;
		}

		private T Deserialize_Binary(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();
			T obj = (T)formatter.Deserialize(stream);

			return obj;
		}
	}
}
