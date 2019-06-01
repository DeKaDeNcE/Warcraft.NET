using TerrainObj0WoD = Warcraft.NET.Files.ADT.Terrain.WoD.TerrainObj0;

namespace Warcraft.NET.Files.ADT.Terrain.BfA
{
    public class TerrainObj0 : TerrainObj0WoD
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BfA.TerrainObj0"/> class.
        /// </summary>
        /// <param name="file">The file path</param>
        public TerrainObj0(string file) : base(file)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BfA.TerrainObj0"/> class.
        /// </summary>
        /// <param name="inData">The binary data.</param>
        public TerrainObj0(byte[] inData) : base(inData)
        {
        }
    }
}
