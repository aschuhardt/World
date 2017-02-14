namespace World.Utility {
    internal class LandscapeDAO {
        
        public World Load(string path) {
            return MapSerializer.DeserializeWorldMap(path);
        }

        public void Save(World w, string path) {
            MapSerializer.SerializeWorldMap(w, path);
        }

    }
}
