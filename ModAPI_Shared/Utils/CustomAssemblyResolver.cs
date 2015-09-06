using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            System.Console.WriteLine("ASSEMBLY A:" + fullName);
            int index = fullName.IndexOf(",");
            string assemblyName = fullName.Substring(0, index);
            foreach (string p in Paths)
            {
                string fileName = p + System.IO.Path.DirectorySeparatorChar + assemblyName + ".dll";
                if (System.IO.File.Exists(fileName))
                {
                    AssemblyDefinition a = AssemblyDefinition.ReadAssembly(fileName);
                    if (a.FullName == fullName)
                        return a;
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
