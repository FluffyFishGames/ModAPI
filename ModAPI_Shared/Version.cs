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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ModAPI
{
    public static class Version
    {
        public static readonly string Descriptor = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        private static int _buildDate = -1;
        public static int BuildDate => _buildDate > -1 ? _buildDate : (_buildDate = int.Parse((Assembly.GetExecutingAssembly().GetBuildDateTime() ?? DateTime.Now).ToString("yyyyMMdd")));

        #pragma warning disable 169
        #pragma warning disable 649
        // ReSharper disable once InconsistentNaming
        struct _IMAGE_FILE_HEADER
        {
            public ushort Machine;
            public ushort NumberOfSections;
            public uint TimeDateStamp;
            public uint PointerToSymbolTable;
            public uint NumberOfSymbols;
            public ushort SizeOfOptionalHeader;
            public ushort Characteristics;
        };

        private static DateTime? GetBuildDateTime(this Assembly assembly)
        {
            var path = new Uri(assembly.GetName().CodeBase).LocalPath;

            if (!File.Exists(path)) return null;

            var headerDefinition = typeof(_IMAGE_FILE_HEADER);

            var buffer = new byte[Math.Max(Marshal.SizeOf(headerDefinition), 4)];
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                fileStream.Position = 0x3C;
                fileStream.Read(buffer, 0, 4);
                fileStream.Position = BitConverter.ToUInt32(buffer, 0); // COFF header offset
                fileStream.Read(buffer, 0, 4); // "PE\0\0"
                fileStream.Read(buffer, 0, buffer.Length);
            }
            var pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var addr = pinnedBuffer.AddrOfPinnedObject();
                var coffHeader = (_IMAGE_FILE_HEADER) Marshal.PtrToStructure(addr, headerDefinition);

                var epoch = new DateTime(1970, 1, 1);
                var sinceEpoch = new TimeSpan(coffHeader.TimeDateStamp * TimeSpan.TicksPerSecond);
                var buildDate = epoch + sinceEpoch;
                var localTime = TimeZone.CurrentTimeZone.ToLocalTime(buildDate);

                return localTime;
            }
            finally
            {
                pinnedBuffer.Free();
            }
        }
    }
}
