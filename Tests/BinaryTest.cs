using System;
using System.IO;
using Xunit;
using Serializer;

namespace Tests {
	public class BinaryTest {
		[Serializable]
		public class TestClass {
			public int X, Y, Z;
			public string Value;
		}

		[Fact]
		public void BinarySerializationTest() {
			TestClass obj = new TestClass();
			obj.X = int.MaxValue;
			obj.Y = int.MinValue;
			obj.Value = "Some_String";
			Serializer<TestClass> serializer = new Serializer<TestClass>();

			// Save
			string filename = "test.bin";
			serializer.Save(filename, obj, SerializationMethod.Binary);
			Assert.True(File.Exists(filename));

			// Open
			TestClass obj2 = serializer.Open(filename, SerializationMethod.Binary);
			Assert.Equal(obj.X, obj2.X);
			Assert.Equal(obj.Y, obj2.Y);
			Assert.Equal(obj.Z, obj2.Z);
			Assert.Equal(obj.Value, obj2.Value);
		}
	}
}
