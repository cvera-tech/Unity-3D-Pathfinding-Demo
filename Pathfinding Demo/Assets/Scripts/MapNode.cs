using System;

public class MapNode : IEquatable<MapNode>
{
    private int x;
    private int z;
    private Terrain terrain;
    public MapNode(int x, int z, Terrain terrain)
    {
        this.x = x;
        this.z = z;
        this.terrain = terrain;
    }

    // Properties
    public int X { get => x; set => x = value; }
    public int Z { get => z; set => z = value; }
    public Terrain Terrain { get => terrain; set => terrain = value; }
    public int Cost { get => TileCosts.Instance.Cost(terrain); }

    // Methods
    public (int, int) Coordinates() => (x, z);
    public override string ToString() => "[" + x + ", " + z + "] " + terrain;
    public bool Equals(MapNode mn) => (x == mn.X && z == mn.Z && terrain == mn.Terrain);
}
