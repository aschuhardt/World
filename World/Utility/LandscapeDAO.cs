using System;
using System.IO;
using World.Tile;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;

namespace World.Utility {
    internal class LandscapeDAO {

        private const string FILENAME_OFFSET_FORMAT = "00000";

        public World Load(string path) {
            if (File.Exists(path)) {

                string directory = Path.GetDirectoryName(path);
                string extractedFile = ExtractTGZ(path, directory);

                World w;
                using (BinaryReader reader = new BinaryReader(File.OpenRead(extractedFile))) {
                    string name = reader.ReadString();
                    int width = reader.ReadInt32();
                    int height = reader.ReadInt32();
                    int depth = reader.ReadInt32();
                    int seaLevel = reader.ReadInt32();
                    int shoreLine = reader.ReadInt32();
                    float offsetX = reader.ReadSingle();
                    float offsetY = reader.ReadSingle();
                    int seed = reader.ReadInt32();

                    w = new World(width, height, depth, seaLevel, shoreLine, name, false);

                    w.OffsetX = offsetX;
                    w.OffsetY = offsetY;
                    w.Seed = seed;

                    long streamLength = reader.BaseStream.Length;
                    while (reader.BaseStream.Position < streamLength) {
                        TileTypes tileType = (TileTypes)reader.ReadUInt16();
                        ITile t = TileMapper.GetTileForType(tileType);
                        t.X = reader.ReadInt32();
                        t.Y = reader.ReadInt32();
                        t.Z = reader.ReadInt32();
                        w.SetTileAtLocation(t, t.X, t.Y, t.Z);
                    }
                }

                //delete extracted file
                File.Delete(extractedFile);

                return w;
            } else {
                throw new Exception($"The file at {path} was not found or could not be loaded!");
            }
        }

        public void Save(World w, string path) {
            //create file and open stream
            string filename = Path.Combine(path, $"{w.Name}_{w.OffsetX.ToString(FILENAME_OFFSET_FORMAT)}_{w.OffsetY.ToString(FILENAME_OFFSET_FORMAT)}");
            string filenameRaw = filename + "_raw";
            using (BinaryWriter writer = new BinaryWriter(File.Create(filenameRaw))) {
                //write world header info to file
                writer.Write(w.Name);
                writer.Write(w.Width);
                writer.Write(w.Height);
                writer.Write(w.Depth);
                writer.Write(w.SeaLevel);
                writer.Write(w.ShoreLine);
                writer.Write(w.OffsetX);
                writer.Write(w.OffsetY);
                writer.Write(w.Seed);

                //write tiles data
                ITile[] tiles = w.FlattenedTileArray;
                foreach (ITile t in tiles) {
                    if (t.TileType != TileTypes.Air) {
                        writer.Write((ushort)t.TileType);
                        writer.Write(t.X);
                        writer.Write(t.Y);
                        writer.Write(t.Z);
                    }
                }
            }

            //compress
            CompressFile(filenameRaw, filename);

            //delete uncompressed file
            File.Delete(filenameRaw);
        }

        private void CompressFile(string inputFilename, string outputFilename) {
            using (GZipOutputStream gz = new GZipOutputStream(File.Create(outputFilename))) {
                using (TarArchive tar = TarArchive.CreateOutputTarArchive(gz)) {
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(inputFilename));

                    TarEntry te = TarEntry.CreateEntryFromFile(Path.GetFileName(inputFilename));
                    tar.WriteEntry(te, false);
                }
            }
        }

        private string ExtractTGZ(String gzArchiveName, String destFolder) {
            string extractedFilename = "";
            using (GZipInputStream gz = new GZipInputStream(File.OpenRead(gzArchiveName))) {
                using (TarArchive tar = TarArchive.CreateInputTarArchive(gz)) {
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(gzArchiveName));
                    string[] preExtractFilesList = Directory.GetFiles(destFolder);
                    tar.ExtractContents(destFolder);
                    string[] postExtractFilesList = Directory.GetFiles(destFolder);
                    extractedFilename = FindNewFilename(preExtractFilesList, postExtractFilesList);
                }
            }
            return extractedFilename;
        }

        private string FindNewFilename(string[] preExtraction, string[] postExtraction) {
            if (preExtraction.Length < postExtraction.Length) {
                foreach (string pre in postExtraction) {
                    bool hasMatch = false;
                    foreach (string post in preExtraction) {
                        if (pre == post) {
                            //match found, skip
                            hasMatch = true;
                        }
                    }
                    if (!hasMatch)
                        return pre;
                }
                return "";
            } else {
                return "";
            }
        }
    }
}
