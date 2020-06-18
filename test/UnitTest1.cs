
using System;
using Xunit;
using TaskInter1;
namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            Program obj = new Program();
            //act 
            var ConfigurationObject = new Configuration(2, "www.training.com", new[] { "192.168.1.8", "192.168.1.2" });
            //assert 
            Assert.Equal("\"{\"Version\":2,\"DomainName\":\"www.training.com\",\"IpAddresses\":[\"192.168.1.8\", \"192.168.1.2\"]}\"", obj.Check(ConfigurationObject));
         var ConfigurationObject2 = new Configuration2(2, "www.training.com");
            //assert 
            Assert.Equal("\"{\"Version\":2,\"DomainName\":\"www.training.com\"", obj.Check(ConfigurationObject2));
        
            var ConfigurationObject3 = new Configuration(2, "454", new[] { "192.168.1.8", "192.168.1.2" });
            //assert 
            Assert.Equal("you have to put a string not a number in the domain name..", obj.Check(ConfigurationObject3));
            // test 
            //act 
            var ConfigurationObject4 = new Configuration(2, "www.google3.com", new[] { "192.168.1.8", "192.168.1.2" });
            //assert 
            Assert.Equal("\"{\"Version\":2,\"DomainName\":\"www.google3.com\",\"IpAddresses\":[\"192.168.1.8\", \"192.168.1.2\"]}\"", obj.Check(ConfigurationObject4));
            var ConfigurationObject6 = new Configuration(2, "www.google3.com", new[] { "oriana", "192.168.1.2" });
            //assert 
            Assert.Equal("you have to put a number instead of a string in the the ip addresses..", obj.Check(ConfigurationObject6));

   

        }
    }
}
