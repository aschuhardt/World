namespace World {

  class World {

    public string Name { get; set; }
    public int Width { get; }
    public int Height { get; }
    public int Depth { get; }

    public ITile[,,] GetTiles() {
      get {
        return _tiles;
      }
    }

    public IDynamicEntity GetDynamicEntities() {
      get {
        return _dynamicEntities;
      }
    }

    private ITile[,,] _tiles;
    private IDynamicEntity[] _dynamicEntities;

    public World(string name, int width, int height, int depth) {
      this.Name = name;
      this.Width = width;
      this.Height = height;
      this.Depth = depth;
    }

    private void generate() {


    }
  }

}
