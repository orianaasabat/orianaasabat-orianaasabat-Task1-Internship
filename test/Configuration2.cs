using System;
namespace Test
{

    public class Configuration2
    {

        public Configuration2(int version, string domainName)
        {
            Version = version;
            DomainName = domainName;
        }
        public int Version { get; }
        public string DomainName { get; }


    }
}
