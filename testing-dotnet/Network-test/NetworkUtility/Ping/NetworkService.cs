using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using NetworkUtility.DNS;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dNS;
        public NetworkService(IDNS dNS)
        {
            _dNS = dNS;
        }
        public string SendPing()
        {
            var dnsSucces = _dNS.SendDNS(); 
            if(dnsSucces)
            {
                return "Success: Ping send!";
            }
            return "Failed: Ping not send";
        }
        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }
        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions{
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions{
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions{
                    DontFragment = true,
                    Ttl = 1
                }
            };
            return pingOptions;
        }
    }
}