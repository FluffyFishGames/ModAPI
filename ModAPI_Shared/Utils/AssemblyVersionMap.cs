/*  
 *  ModAPI
 *  Copyright (C) 2015 FluffyFish / Philipp Mohrenstecher
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  To contact me you can e-mail me at info@fluffyfish.de
 */

using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace ModAPI.Utils
{
    /// <summary>
    /// Provides assembly version mapping for The Forest's Unity 5.6.x Mono 2.0 runtime.
    /// When ModAPI builds mods with .NET 4.8, the assembly references need to be remapped
    /// to match the game's actual Mono 2.0 (CLR v2.0.50727) environment.
    /// 
    /// This map is derived from analyzing the actual DLLs in The Forest's
    /// TheForest_Data/Managed/ directory.
    /// </summary>
    public static class AssemblyVersionMap
    {
        /// <summary>
        /// Standard .NET Framework PublicKeyToken used by mscorlib, System, System.Core, etc.
        /// Token: b77a5c561934e089
        /// </summary>
        public static readonly byte[] StandardPublicKeyToken =
            { 0xB7, 0x7A, 0x5C, 0x56, 0x19, 0x34, 0xE0, 0x89 };

        /// <summary>
        /// Microsoft PublicKeyToken used by System.Configuration, System.Web, System.Drawing, etc.
        /// Token: b03f5f7f11d50a3a
        /// </summary>
        public static readonly byte[] MicrosoftPublicKeyToken =
            { 0xB0, 0x3F, 0x5F, 0x7F, 0x11, 0xD5, 0x0A, 0x3A };

        /// <summary>
        /// Assembly version info for Unity 5.6.x Mono 2.0 runtime.
        /// </summary>
        public class AssemblyVersionInfo
        {
            public System.Version Version;
            public byte[] PublicKeyToken;

            public AssemblyVersionInfo(string version, byte[] publicKeyToken)
            {
                Version = new System.Version(version);
                PublicKeyToken = publicKeyToken;
            }
        }

        /// <summary>
        /// The Forest Unity 5.6.x assembly version map.
        /// Maps assembly name → correct version and PublicKeyToken for the game's Mono 2.0 runtime.
        /// </summary>
        private static readonly Dictionary<string, AssemblyVersionInfo> VersionMap =
            new Dictionary<string, AssemblyVersionInfo>(StringComparer.OrdinalIgnoreCase)
            {
                // ── Mono Runtime - Core (.NET 2.0) ──
                { "mscorlib",                   new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "System",                     new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "System.Xml",                 new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "System.Data",                new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "System.Configuration",       new AssemblyVersionInfo("2.0.0.0", MicrosoftPublicKeyToken) },
                { "System.Security",            new AssemblyVersionInfo("2.0.0.0", MicrosoftPublicKeyToken) },
                { "System.EnterpriseServices",  new AssemblyVersionInfo("2.0.0.0", MicrosoftPublicKeyToken) },
                { "System.Transactions",        new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },

                // ── Mono Runtime - Extended (.NET 3.5) ──
                { "System.Core",                new AssemblyVersionInfo("3.5.0.0", StandardPublicKeyToken) },
                { "System.Xml.Linq",            new AssemblyVersionInfo("3.5.0.0", StandardPublicKeyToken) },
                { "System.Data.DataSetExtensions", new AssemblyVersionInfo("3.5.0.0", StandardPublicKeyToken) },

                // ── Mono Runtime - Mono-specific ──
                { "Mono.Security",              new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "Mono.Posix",                 new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "Mono.Data.Tds",              new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },

                // ── I18N (Internationalization) ──
                { "I18N",                       new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "I18N.CJK",                   new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "I18N.MidEast",               new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "I18N.Other",                 new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "I18N.Rare",                  new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
                { "I18N.West",                  new AssemblyVersionInfo("2.0.0.0", StandardPublicKeyToken) },
            };

        /// <summary>
        /// Checks if the given assembly name is a system/runtime assembly that should be remapped.
        /// </summary>
        public static bool IsSystemAssembly(string assemblyName)
        {
            return VersionMap.ContainsKey(assemblyName);
        }

        /// <summary>
        /// Gets the correct version info for a system assembly in The Forest's Mono 2.0 runtime.
        /// </summary>
        /// <returns>AssemblyVersionInfo if found, null otherwise.</returns>
        public static AssemblyVersionInfo GetVersionInfo(string assemblyName)
        {
            AssemblyVersionInfo info;
            return VersionMap.TryGetValue(assemblyName, out info) ? info : null;
        }

        /// <summary>
        /// Remaps an assembly reference to match The Forest's Unity 5.6.x Mono 2.0 runtime.
        /// Used when .NET 4.8 built assemblies need to be deployed to the game.
        /// </summary>
        /// <param name="assemblyReference">The assembly reference to remap.</param>
        /// <returns>True if the reference was remapped, false if no mapping exists.</returns>
        public static bool RemapReference(AssemblyNameReference assemblyReference)
        {
            var info = GetVersionInfo(assemblyReference.Name);
            if (info != null)
            {
                assemblyReference.Version = info.Version;
                assemblyReference.PublicKeyToken = info.PublicKeyToken;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remaps all system assembly references in a module to match
        /// The Forest's Unity 5.6.x Mono 2.0 runtime.
        /// </summary>
        /// <param name="module">The module whose references should be remapped.</param>
        /// <returns>The number of references that were remapped.</returns>
        public static int RemapAllReferences(ModuleDefinition module)
        {
            var count = 0;
            foreach (var assemblyReference in module.AssemblyReferences)
            {
                if (RemapReference(assemblyReference))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Removes duplicate or conflicting assembly references from a module.
        /// For example, removes mscorlib 2.0.5.0 (Silverlight) when 2.0.0.0 exists.
        /// </summary>
        /// <param name="module">The module to clean up.</param>
        /// <returns>The number of references removed.</returns>
        public static int RemoveDuplicateReferences(ModuleDefinition module)
        {
            var count = 0;
            var seen = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            for (var i = module.AssemblyReferences.Count - 1; i >= 0; i--)
            {
                var aref = module.AssemblyReferences[i];
                if (seen.ContainsKey(aref.Name))
                {
                    // Keep the one with the correct version from our map
                    var info = GetVersionInfo(aref.Name);
                    if (info != null && aref.Version != info.Version)
                    {
                        module.AssemblyReferences.RemoveAt(i);
                        count++;
                    }
                }
                else
                {
                    seen[aref.Name] = i;
                }
            }
            return count;
        }
    }
}