﻿using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Bson;
using System.IO;

namespace RosSharp.RosBridgeClient.Serializers
{
    public class BsonNetSerializer : ISerializer
    {
        JsonSerializer serializer = new JsonSerializer();

        public T Deserialize<T>(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            BsonDataReader reader = new BsonDataReader(ms);
            return serializer.Deserialize<T>(reader);
        }

        public T Deserialize<T>(ArraySegment<byte> bytes)
        {
            MemoryStream ms = new MemoryStream(bytes.Array, bytes.Offset, bytes.Count);
            BsonDataReader reader = new BsonDataReader(ms);
            return serializer.Deserialize<T>(reader);
        }

        public IReceivedMessage DeserializeReceived(byte[] bytes)
        {
            var jObject = Deserialize<JObject>(bytes);
            return new JsonNetReceivedMessage(jObject);
        }

        public IReceivedMessage DeserializeReceived(ArraySegment<byte> bytes)
        {
            var jObject = Deserialize<JObject>(bytes);
            return new JsonNetReceivedMessage(jObject);
        }

        public byte[] Serialize<T>(T communication)
        {
            MemoryStream ms = new MemoryStream();
            BsonDataWriter writer = new BsonDataWriter(ms);
            serializer.Serialize(writer, communication);
            return ms.ToArray();
        }

        public ArraySegment<byte> SerializeUnsafe<T>(T communication)
        {
            byte[] buffer = MemoryPool.GetBuffer();
            MemoryStream ms = new MemoryStream(buffer);
            BsonDataWriter writer = new BsonDataWriter(ms);
            serializer.Serialize(writer, communication);
            return new ArraySegment<byte>(buffer, 0, (int)ms.Position);
        }

        public string GetJsonString(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            BsonDataReader reader = new BsonDataReader(ms);
            JObject o = (JObject)JToken.ReadFrom(reader);
            return o.ToString();
        }

    }

}