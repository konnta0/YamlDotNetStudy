using System;
using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Utilities;

namespace ForDotnet
{
    public class Converter : IYamlTypeConverter
    {
        public IValueDeserializer ValueDeserializer { get; set; }

        public bool Accepts(Type type)
        {
            return type == typeof(List<Address2>);
        }

        public object? ReadYaml(IParser parser, Type type)
        {
            var address2List = new List<Address2>();
            parser.Consume<MappingStart>();
            while (!parser.TryConsume<MappingEnd>(out var _))
            {
                var key = parser.Consume<Scalar>().Value;
                var address2 = (Address2)ValueDeserializer.DeserializeValue(parser, typeof(Address2), new SerializerState(),
                        ValueDeserializer);
                address2.Key = key;
                address2List.Add(address2);
            }
            return address2List;
        }

        public void WriteYaml(IEmitter emitter, object? value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}