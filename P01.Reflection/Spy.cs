namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public Spy()
        {

        }
        public string StealFieldInfo(string nameOfTheClass, params string[] requestedFields)
        {
            Type classType = typeof(Hacker);
            var fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var classInstance = Activator.CreateInstance(classType, new object[] { });
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Class under investigation: {nameOfTheClass}");
            foreach (var field in fields.Where(x => requestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type type = Type.GetType(className);

            FieldInfo[] fieldInfo = 
                type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            MethodInfo[] publicMethodInfo =
                type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            MethodInfo[] nonPublicMethodInfo = 
                type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            foreach (var field in fieldInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in publicMethodInfo.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in nonPublicMethodInfo.Where(x=> x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            
            MethodInfo[] privateMethods = 
                type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
           
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }

        public string CollectGettersAndSettters(string className)
        {
            Type type = Type.GetType(className);
            
            MethodInfo[] methods = 
                type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            foreach (var method in methods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }
    }
}
