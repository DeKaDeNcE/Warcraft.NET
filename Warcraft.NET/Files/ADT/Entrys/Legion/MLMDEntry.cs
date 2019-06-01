﻿using Warcraft.NET.Extensions;
using System.IO;
using SharpDX;
using Warcraft.NET.Files.Structures;
using Warcraft.NET.Files.ADT.Flags;

namespace Warcraft.NET.Files.ADT.Entrys.Legion
{
    /// <summary>
    /// An entry struct containing information about the WMO.
    /// </summary>
    public class MLMDEntry
    {
        /// <summary>
        /// Gets or sets the specifies which WMO to use via the MMID chunk.
        /// </summary>
        public uint NameId { get; set; }

        /// <summary>
        /// Gets or sets the a unique actor ID for the model. Blizzard implements this as game global, but it's only
        /// checked in loaded tiles. When not in use, it's set to -1.
        /// </summary>
        public int UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the position of the WMO.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the rotation of the model.
        /// </summary>
        public Rotator Rotation { get; set; }

        /// <summary>
        /// Gets or sets the flags of the model.
        /// </summary>
        public MLMDFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the doodadset of the model.
        /// </summary>
        public ushort DoodadSet { get; set; }

        /// <summary>
        /// Gets or sets the nameset of the model.
        /// </summary>
        public ushort NameSet { get; set; }

        /// <summary>
        /// Gets or sets the scale value. Scale flag must be set to load this value.
        /// </summary>
        public ushort Scale { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MLMDEntry"/> class.
        /// </summary>
        /// <param name="data">ExtendedData.</param>
        public MLMDEntry(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var br = new BinaryReader(ms))
            {
                NameId = br.ReadUInt32();
                UniqueId = br.ReadInt32();

                Position = br.ReadVector3();
                Rotation = br.ReadRotator();

                Flags = (MLMDFlags)br.ReadUInt16();
                DoodadSet = br.ReadUInt16();
                NameSet = br.ReadUInt16();
                Scale = br.ReadUInt16();
            }
        }

        /// <summary>
        /// Gets the size of a placement entry.
        /// </summary>
        /// <returns>The size.</returns>
        public static int GetSize()
        {
            return 40;
        }

        /// <inheritdoc/>
        public byte[] Serialize(long offset = 0)
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write(NameId);
                    bw.Write(UniqueId);

                    bw.WriteVector3(Position);
                    bw.WriteRotator(Rotation);

                    bw.Write((ushort)Flags);
                    bw.Write(DoodadSet);
                    bw.Write(NameSet);
                    bw.Write(Scale);
                }

                return ms.ToArray();
            }
        }
    }
}
