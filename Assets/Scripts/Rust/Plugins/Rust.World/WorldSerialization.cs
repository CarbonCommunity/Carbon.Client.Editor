using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using LZ4;

public class WorldSerialization
{
    public const uint CurrentVersion = 9;
    public static uint Version
    {
        get; private set;
    }

    public WorldData world = new WorldData();
    public WorldSerialization()
    {
        Version = CurrentVersion;
    }

    [ProtoContract]
    public class WorldData
    {
        [ProtoMember(1)] public uint size = 4000;
        [ProtoMember(2)] public List<MapData> maps = new List<MapData>();
        [ProtoMember(3)] public List<PrefabData> prefabs = new List<PrefabData>();
        [ProtoMember(4)] public List<PathData> paths = new List<PathData>();
    }

    [Serializable]
    [ProtoContract]
    public class ModifierData
    {
        [ProtoMember(1)] public int size;
        [ProtoMember(2)] public int fade;
        [ProtoMember(3)] public int fill;
        [ProtoMember(4)] public int counter;
        [ProtoMember(5)] public uint id;
    }

    [ProtoContract]
    public class MapData
    {
        [ProtoMember(1)] public string name;
        [ProtoMember(2)] public byte[] data;
    }

    [Serializable]
    [ProtoContract]
    public class PrefabData
    {
        [ProtoMember(1)] public string category;
        [ProtoMember(2)] public uint id;
        [ProtoMember(3)] public VectorData position;
        [ProtoMember(4)] public VectorData rotation;
        [ProtoMember(5)] public VectorData scale;
    }

    [ProtoContract]
    [Serializable]
    public class PathData
    {
        [ProtoMember(1)]
        public string name;
        [ProtoMember(2)]
        public bool spline;
        [ProtoMember(3)]
        public bool start;
        [ProtoMember(4)]
        public bool end;
        [ProtoMember(5)]
        public float width;
        [ProtoMember(6)]
        public float innerPadding;
        [ProtoMember(7)]
        public float outerPadding;
        [ProtoMember(8)]
        public float innerFade;
        [ProtoMember(9)]
        public float outerFade;
        [ProtoMember(10)]
        public float randomScale;
        [ProtoMember(11)]
        public float meshOffset;
        [ProtoMember(12)]
        public float terrainOffset;
        [ProtoMember(13)]
        public int splat;
        [ProtoMember(14)]
        public int topology;
        [ProtoMember(15)]
        public List<VectorData> nodes;
        [ProtoMember(16)]
        public int hierarchy;

        public PathData()
        {
        }

        public PathData(PathData pathData)
        {
            this.name = pathData.name;
            this.spline = pathData.spline;
            this.start = pathData.start;
            this.end = pathData.end;
            this.innerPadding = pathData.innerPadding;
            this.outerPadding = pathData.outerPadding;
            this.innerFade = pathData.innerFade;
            this.outerFade = pathData.outerFade;
            this.randomScale = pathData.randomScale;
            this.width = pathData.width;
            this.meshOffset = pathData.meshOffset;
            this.terrainOffset = pathData.terrainOffset;
            this.splat = pathData.splat;
            this.topology = pathData.topology;
            this.nodes = new List<VectorData>();
        }
    }


    [Serializable]
    [ProtoContract]
    public class VectorData
    {
        [ProtoMember(1)] public float x;
        [ProtoMember(2)] public float y;
        [ProtoMember(3)] public float z;

        public VectorData()
        {
        }

        public VectorData(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator VectorData(Vector3 v)
        {
            return new VectorData(v.x, v.y, v.z);
        }

        public static implicit operator VectorData(Quaternion q)
        {
            return q.eulerAngles;
        }

        public static implicit operator Vector3(VectorData v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        public static implicit operator Quaternion(VectorData v)
        {
            return Quaternion.Euler(v);
        }
    }

    public MapData GetMap(string name)
    {
        for (int i = 0; i < world.maps.Count; i++)
            if (world.maps[i].name == name) return world.maps[i];
        return null;
    }

    public void AddMap(string name, byte[] data)
    {
        var map = new MapData();

        map.name = name;
        map.data = data;

        world.maps.Add(map);
    }

    public void Save(string fileName)
    {
        try
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(Version);

                    using (var compressionStream = new LZ4Stream(fileStream, LZ4StreamMode.Compress))
                        Serializer.Serialize(compressionStream, world);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void Load(string fileName)
    {
        try
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    Version = binaryReader.ReadUInt32();

                    if (Version != CurrentVersion)
                        Debug.LogWarning("Map Version is: " + Version + " whilst Rust is on: " + CurrentVersion);

                    using (var compressionStream = new LZ4Stream(fileStream, LZ4StreamMode.Decompress))
                    {
                        world = Serializer.Deserialize<WorldData>(compressionStream);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}