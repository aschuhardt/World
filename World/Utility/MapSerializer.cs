using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using World.Tile;

namespace World.Utility {
    internal static class MapSerializer {
        public static World DeserializeWorldMap(string filename) {
            //create a transfer object to hold info we'll use to create a World object
            WorldInfoTO worldInfo = new WorldInfoTO();

            using (var strm = new StreamReader(filename, Encoding.UTF8)) {
                using (var rdr = new JsonTextReader(strm)) {
                    string currentProperty = string.Empty;
                    while (rdr.Read()) {
                        if (rdr.Value != null) {
                            if (rdr.TokenType == JsonToken.PropertyName) {
                                currentProperty = rdr.Value.ToString();
                            }

                            if (rdr.TokenType == JsonToken.String && currentProperty == "Name") {
                                worldInfo.Name = rdr.Value.ToString();
                            }

                            if (rdr.TokenType == JsonToken.Integer) {
                                switch (currentProperty) {
                                    case "Width":
                                        worldInfo.Width = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "Height":
                                        worldInfo.Height = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "Depth":
                                        worldInfo.Depth = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "SeaLevel":
                                        worldInfo.SeaLevel = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "ShoreLine":
                                        worldInfo.ShoreLine = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "TileType":
                                        worldInfo.Tiles.Push(MapTileTypeToITile((TileTypes)Int32.Parse(rdr.Value.ToString())));
                                        break;
                                    case "X":
                                        worldInfo.Tiles.Peek().X = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "Y":
                                        worldInfo.Tiles.Peek().Y = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "Z":
                                        worldInfo.Tiles.Peek().Z = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    case "Seed":
                                        worldInfo.Seed = Int32.Parse(rdr.Value.ToString());
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (rdr.TokenType == JsonToken.Float) {
                                switch (currentProperty) {
                                    case "ScaleX":
                                        worldInfo.ScaleX = float.Parse(rdr.Value.ToString());
                                        break;
                                    case "ScaleY":
                                        worldInfo.ScaleY = float.Parse(rdr.Value.ToString());
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return worldInfo.ToWorld();
        }

        private static ITile MapTileTypeToITile(TileTypes t) {
            ITile output;

            switch (t) {
                case TileTypes.Air:
                    output = new AirTile();
                    break;
                case TileTypes.Water:
                    output = new WaterTile();
                    break;
                case TileTypes.Grass:
                    output = new GrassTile();
                    break;
                case TileTypes.Sand:
                    output = new SandTile();
                    break;
                default:
                    throw new Exception($"Unrecognized tile type: {t.ToString()}");
            }

            return output;
        }

        public static void SerializeWorldMap(World w, string outputPath) {
            string filename = Path.Combine(outputPath, w.Name + ".json");
            using (var strm = File.CreateText(filename)) {
                ITile[] tiles = w.SerializedTileArray;

                strm.Write("{ ");
                strm.Write($"\"Name\": \"{w.Name}\",");
                strm.Write($"\"Width\": {w.Width},");
                strm.Write($"\"Height\": {w.Height},");
                strm.Write($"\"Depth\": {w.Depth},");
                strm.Write($"\"SeaLevel\": {w.SeaLevel},");
                strm.Write($"\"ShoreLine\": {w.ShoreLine},");
                strm.Write($"\"ScaleX\": {w.ScaleX},");
                strm.Write($"\"ScaleY\": {w.ScaleY},");
                strm.Write($"\"Seed\": {w.Seed},");
                strm.Write($"\"Tiles\": [ ");

                //filter out tiles that are empty air
                List<ITile> nonEmptyTiles = tiles.Where((t) => {
                    return t.TileType != TileTypes.Air || t.StaticEntities.Count > 0;
                }).ToList();

                int index = 0;
                int total = nonEmptyTiles.Count;

                nonEmptyTiles.ForEach((t) => {
                    strm.Write(t.Serialized);
                    if (index < total - 1) strm.Write(", ");
                    index++;
                });
                strm.Write("] }");
            }
        }

        private class WorldInfoTO {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }
            public int SeaLevel { get; set; }
            public int ShoreLine { get; set; }
            public float ScaleX { get; set; }
            public float ScaleY { get; set; }
            public int Seed { get; set; }
            public Stack<ITile> Tiles { get; set; }

            public WorldInfoTO() {
                Tiles = new Stack<ITile>();
            }

            public World ToWorld() {
                World output = new World(this.Width, this.Height, this.Depth, this.SeaLevel, this.ShoreLine, this.Name, false);
                output.ScaleX = this.ScaleX;
                output.ScaleY = this.ScaleY;
                output.Seed = this.Seed;
                this.Tiles.ToList().ForEach((x) => {
                    output.SetTileAtLocation(x, x.X, x.Y, x.Z);
                });
                output.FillNullTilesWithAir();
                return output;
            }
        }
    }
}
