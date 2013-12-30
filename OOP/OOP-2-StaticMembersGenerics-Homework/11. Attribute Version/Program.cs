//Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations 
//and methods and holds a version in the format major.minor (e.g. 2.11). 
//Apply the version attribute to a sample class and display its version at runtime.
namespace _11.Attribute_Version
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Method |
     AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = false)]

    public class VersionAttribute : System.Attribute
    {
        public string Version { get; private set; }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }


    [Version("3.14")]
    class TestAttributeClass
    {
        static void Main()
        {
            Type type = typeof(TestAttributeClass);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute ver in allAttributes)
            {
                Console.WriteLine(ver.Version);
            }
        }
    }
}
