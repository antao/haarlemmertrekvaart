using System;
using System.IO;

namespace Haarlemmertrekvaart.Serializers
{
    public class XmlSerializer : ISerializer
    {
        public T Deserialize<T>(string response)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(response))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public string Serialize(object @object)
        {
            throw new NotImplementedException();
        }
    }
}
