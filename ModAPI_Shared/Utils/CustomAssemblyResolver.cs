using System;
using System.Collections.Generic;
using System.IO;
using Mono.Cecil;

namespace ModAPI.Utils
{
    public class CustomAssemblyResolver : IAssemblyResolver
    {
        protected List<string> Paths = new List<string>();

        public void AddPath(string Path)
        {
            Paths.Add(Path);
        }

        public AssemblyDefinition Resolve(string fullName, ReaderParameters parameters)
        {
            return Resolve(fullName);
        }

        public AssemblyDefinition Resolve(string fullName)
        {
            Console.WriteLine("ASSEMBLY A:" + fullName);
            var index = fullName.IndexOf(",");
            var assemblyName = fullName.Substring(0, index);
            foreach (var p in Paths)
            {
                var fileName = p + System.IO.Path.DirectorySeparatorChar + assemblyName + ".dll";
                if (File.Exists(fileName))
                {
                    var a = AssemblyDefinition.ReadAssembly(fileName);
                    if (a.FullName == fullName)
                    {
                        return a;
                    }
                }
            }
            return null;
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
        {
            return Resolve(name);
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            return Resolve(name.FullName);
        }
    }
}
