using System;
using System.Collections.Generic;
using System.IO;
using Mono.Cecil;

namespace ModAPI.Utils
{
    public class CustomAssemblyResolver : IAssemblyResolver
    {
        protected List<string> Paths = new List<string>();
        private readonly Dictionary<string, AssemblyDefinition> _cache =
            new Dictionary<string, AssemblyDefinition>(StringComparer.OrdinalIgnoreCase);

        public void AddPath(string path)
        {
            Paths.Add(path);
        }

        public void Dispose()
        {
            foreach (var asm in _cache.Values)
            {
                try { asm.Dispose(); } catch { }
            }
            _cache.Clear();
            Paths.Clear();
            Paths = null;
        }

        public AssemblyDefinition Resolve(string fullName, ReaderParameters parameters)
        {
            return Resolve(fullName);
        }

        public AssemblyDefinition Resolve(string fullName)
        {
            // Extract assembly name (before the first comma)
            var index = fullName.IndexOf(",");
            var assemblyName = index > 0 ? fullName.Substring(0, index) : fullName;

            // Check cache first (by name, not by full qualified name)
            if (_cache.TryGetValue(assemblyName, out var cached))
            {
                return cached;
            }

            foreach (var p in Paths)
            {
                var fileName = p + System.IO.Path.DirectorySeparatorChar + assemblyName + ".dll";
                if (File.Exists(fileName))
                {
                    // Name-based matching: resolve by assembly name regardless of version.
                    // This allows .NET 4.8 references (e.g., mscorlib 4.0.0.0) to find
                    // the game's Mono 2.0 assemblies (e.g., mscorlib 2.0.0.0).
                    var a = AssemblyDefinition.ReadAssembly(fileName);
                    _cache[assemblyName] = a;
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