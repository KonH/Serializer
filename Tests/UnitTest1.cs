using System;
using Serializer;
using System.IO;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Serializable]
        public class SerClass
        {
            public int x, y, z;
            public string value;
        }

        [Fact]
        public void Xml_Serialization()
        {
            SerClass obj = new SerClass();
            obj.x = int.MaxValue;
            obj.y = int.MinValue;
            obj.value = "Some_String";
            Serializer<SerClass> serializer = new Serializer<SerClass>();

            // Save
            string filename = "test.xml";
            serializer.Save(filename, obj, SerializationMethod.Xml);
			Assert.True(File.Exists(filename));

            // Open
            SerClass obj2 = serializer.Open(filename, SerializationMethod.Xml);
			Assert.Equal(obj.x, obj2.x);
            Assert.Equal(obj.y, obj2.y);
            Assert.Equal(obj.z, obj2.z);
            Assert.Equal(obj.value, obj2.value);
            
        }

        [Fact]
        public void Binary_Serialization()
        {
            SerClass obj = new SerClass();
            obj.x = int.MaxValue;
            obj.y = int.MinValue;
            obj.value = "Some_String";
            Serializer<SerClass> serializer = new Serializer<SerClass>();

            // Save
            string filename = "test.bin";
            serializer.Save(filename, obj, SerializationMethod.Binary);
            Assert.True(File.Exists(filename));

            // Open
            SerClass obj2 = serializer.Open(filename, SerializationMethod.Binary);
            Assert.Equal(obj.x, obj2.x);
            Assert.Equal(obj.y, obj2.y);
            Assert.Equal(obj.z, obj2.z);
            Assert.Equal(obj.value, obj2.value);
        }
    }
}
