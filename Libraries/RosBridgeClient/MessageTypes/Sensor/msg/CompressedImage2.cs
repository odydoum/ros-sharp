/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Runtime.Serialization;

using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient.MessageTypes.Sensor
{
    [DataContract]
    public class CompressedImage2 : Message
    {
        [IgnoreDataMember]        
        public const string RosMessageName = "sensor_msgs/CompressedImage";
        [DataMember]
        public Header header;
        [DataMember]
        public string format;

        [DataMember(Name = "data")]
        public ArraySegment<byte> _data;

        public CompressedImage2()
        {
            header = new Header();
            format = "";
            _data = default(ArraySegment<byte>);
        }

        public CompressedImage2(Header header, string format, ArraySegment<byte> data)
        {
            this.header = header;
            this.format = format;
            this._data = data;
        }
    }
}