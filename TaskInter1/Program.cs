using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TaskInter1 { 
    public class Program
    {
        int Version = 0;
        String DomainName;
        String[] IpAdresses;
        public Program()
        {

        }
        public String Check(Object obj)
        {
            StringBuilder Builder = new StringBuilder();
            Type t = obj.GetType();
            PropertyInfo[] Props = t.GetProperties();
            foreach (var Prop in Props)
            {
                if (Prop.GetIndexParameters().Length == 0)
                {
                    if (Prop.PropertyType.Name == "Int32")
                    {
                        Version = (int)Prop.GetValue(obj);
                        StringBuilder sb = new StringBuilder();
                        Builder.Append("\"{\"" + Prop.Name + "\":" + Version + ",");
                    }
                    else if (Prop.PropertyType.Name == "String")
                    {
                        DomainName = (String)Prop.GetValue(obj);
                     
                        try
                        {
                            DomainName = DomainName.Trim();
                            int foo = int.Parse(DomainName);
                            return "you have to put a string not a number in the domain name..";
                        }
                        catch (FormatException)
                        {
                            // Not a numeric value
                            if (DomainName == " " | DomainName == "")
                            {
                                return "you have to enter a domainname..";
                            }
                            else
                            {
                                Builder.Append("\"" + Prop.Name + "\":\"" + DomainName + "\"");
                            }
                        }
                    }
                    else
                    {
                        Array a = (Array)Prop.GetValue(obj);
                       string cleanAmount;  
                        IpAdresses = new String[a.Length];
                        for (int i = 0; i < a.Length; i++)
                        {
                            String o = (String)a.GetValue(i);
                            IpAdresses[i] = o;
                          
                            try
                            {
                               
                                 cleanAmount = o.Replace(".", string.Empty); 
                                cleanAmount= cleanAmount.Trim();
                                int foo = int.Parse(cleanAmount);
                            }
                            catch (FormatException)
                            {
                                return "you have to put a number instead of a string in the the ip addresses..";
                            }
                            }
                        Builder.Append(",\"" + Prop.Name + "\":[\"" + string.Join("\", \"", IpAdresses) + "\"]}\"");
                    }

                }
            }
            return (Builder.ToString());
        }
    }
}
