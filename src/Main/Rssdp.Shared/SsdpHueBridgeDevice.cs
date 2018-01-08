using System;
using System.Collections.Generic;
using System.Text;

namespace Rssdp.Shared
{
	public class SsdpHueBridgeDevice : SsdpRootDevice
	{
		private string _httpServerOptionalSubFolder = "";

		internal const string HUE_RESPONSE =
@"HTTP/1.1 200 OK
HOST: 239.255.255.250:1900
CACHE-CONTROL: max-age=100
EXT:
LOCATION: http://{0}:{1}{2}/description.xml
SERVER: Linux/3.14.0 UPnP/1.0 IpBridge/1.17.0
hue-bridgeid: {3}
";

		internal const string HUE_ST1 =
@"ST: upnp:rootdevice
USN: uuid:{0}::upnp:rootdevice

";

		internal const string HUE_ST2 =
@"ST: uuid:{0}
USN: uuid:{0}

";

		internal const string HUE_ST3 =
@"ST: urn:schemas-upnp-org:device:basic:1
USN: uuid:{0}

";

		/// <summary>
		/// The ip address of the local http servers network interface where the hue bridge api ist hosted
		/// </summary>
		public string HttpServerIpAddress { get; set; }
		public string HttpServerPort { get; set; }

		public string HttpServerOptionalSubFolder
		{
			get { return _httpServerOptionalSubFolder; }
			set { _httpServerOptionalSubFolder = value; }
		}

		public string MacAddress { get; set; }

		public string HueBridgeId
		{
			get
			{
				var temp = MacAddress.Replace(":", "");
				temp = temp.ToLower();
				var bridgeid = temp.Substring(0, 6) + "FFFE" + temp.Substring(6);
				return bridgeid;
			}
		}

		public string HueSerialNumber
		{
			get
			{
				var sn = MacAddress.Replace(":", "");
				sn = sn.ToLower();
				return sn;
			}
		}

		public string HueUuid
		{
			get
			{
				var uuid = "f6543a06-da50-11ba-8d8f-";
				uuid += HueSerialNumber;
				return uuid;
			}
		}
	}
}
