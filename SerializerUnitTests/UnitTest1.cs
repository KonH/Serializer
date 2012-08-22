using System;
using Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SerializerUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [Serializable]
        public class SerClass
        {
            public int x, y, z;
            public string value;
        }

        [TestMethod]
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
            Assert.IsTrue(File.Exists(filename));

            // Open
            SerClass obj2 = serializer.Open(filename, SerializationMethod.Xml);
            Assert.AreEqual(obj.x, obj2.x);
            Assert.AreEqual(obj.y, obj2.y);
            Assert.AreEqual(obj.z, obj2.z);
            Assert.AreEqual(obj.value, obj2.value);
            
        }

        [TestMethod]
        public void Soap_Serialization()
        {
            SerClass obj = new SerClass();
            obj.x = int.MaxValue;
            obj.y = int.MinValue;
            obj.value = "Some_String";
            Serializer<SerClass> serializer = new Serializer<SerClass>();

            // Save
            string filename = "test.soap";
            serializer.Save(filename, obj, SerializationMethod.Soap);
            Assert.IsTrue(File.Exists(filename));

            // Open
            SerClass obj2 = serializer.Open(filename, SerializationMethod.Soap);
            Assert.AreEqual(obj.x, obj2.x);
            Assert.AreEqual(obj.y, obj2.y);
            Assert.AreEqual(obj.z, obj2.z);
            Assert.AreEqual(obj.value, obj2.value);
        }

        [TestMethod]
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
            Assert.IsTrue(File.Exists(filename));

            // Open
            SerClass obj2 = serializer.Open(filename, SerializationMethod.Binary);
            Assert.AreEqual(obj.x, obj2.x);
            Assert.AreEqual(obj.y, obj2.y);
            Assert.AreEqual(obj.z, obj2.z);
            Assert.AreEqual(obj.value, obj2.value);
        }
    }
}
