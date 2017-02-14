using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BitmapRenderer;

namespace Visualizer {
    public partial class Form1 : Form {
        private WorldBindingSource _worldVM;

        public Form1() {
            InitializeComponent();

            _worldVM = new WorldBindingSource();

            populateCombo();
        }

        private void populateCombo() {
            cboStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStyle.DataSource = Enum.GetValues(typeof(WorldMapRenderer.RenderStyles))
                .Cast<WorldMapRenderer.RenderStyles>()
                .Select(p => new { Key = p, Value = p.ToString() })
                .ToList();
            cboStyle.ValueMember = "Key";
            cboStyle.DisplayMember = "Value";
            cboStyle.DataBindings.Add("SelectedValue", _worldVM, "ImageRenderStyle");
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            refreshRender();
        }

        private void Form1_Load(object sender, EventArgs e) {
            setBindings();
        }

        private void setBindings() {
            nudWidth.DataBindings.Clear();
            nudWidth.DataBindings.Add("Value", _worldVM, "Width", true, DataSourceUpdateMode.OnPropertyChanged);
            nudHeight.DataBindings.Clear();
            nudHeight.DataBindings.Add("Value", _worldVM, "Height", true, DataSourceUpdateMode.OnPropertyChanged);
            nudDepth.DataBindings.Clear();
            nudDepth.DataBindings.Add("Value", _worldVM, "Depth", true, DataSourceUpdateMode.OnPropertyChanged);
            nudSeaLevel.DataBindings.Clear();
            nudSeaLevel.DataBindings.Add("Value", _worldVM, "SeaLevel", true, DataSourceUpdateMode.OnPropertyChanged);
            nudShoreLine.DataBindings.Clear();
            nudShoreLine.DataBindings.Add("Value", _worldVM, "ShoreLine", true, DataSourceUpdateMode.OnPropertyChanged);

            nudScaleX.DataBindings.Clear();
            nudScaleX.DataBindings.Add("Value", _worldVM, "ScaleX", true, DataSourceUpdateMode.OnPropertyChanged);

            nudScaleY.DataBindings.Clear();
            nudScaleY.DataBindings.Add("Value", _worldVM, "ScaleY", true, DataSourceUpdateMode.OnPropertyChanged);

            nudSeed.DataBindings.Clear();
            nudSeed.DataBindings.Add("Value", _worldVM, "Seed", true, DataSourceUpdateMode.OnPropertyChanged);

            cbOccludeWater.DataBindings.Clear();
            cbOccludeWater.DataBindings.Add("Checked", _worldVM, "OccludeWater", true, DataSourceUpdateMode.OnPropertyChanged);

            nudOffsetX.DataBindings.Clear();
            nudOffsetX.DataBindings.Add("Value", _worldVM, "OffsetX", true, DataSourceUpdateMode.OnPropertyChanged);

            nudOffsetY.DataBindings.Clear();
            nudOffsetY.DataBindings.Add("Value", _worldVM, "OffsetY", true, DataSourceUpdateMode.OnPropertyChanged);

            refreshRender();
        }

        private void btnExport_Click(object sender, EventArgs e) {
            if (diagExport.ShowDialog() == DialogResult.Cancel) {
                return;
            } else {
                string filename = diagExport.FileName;
                Bitmap bmp = new Bitmap(_worldVM.RenderedImage);
                bmp.Save(filename);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (browSave.ShowDialog() == DialogResult.Cancel) {
                return;
            } else {
                string path = browSave.SelectedPath;
                Cursor = Cursors.WaitCursor;
                _worldVM.Save(path);
                Cursor = Cursors.Default;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            if (diagLoad.ShowDialog() == DialogResult.Cancel) {
                return;
            } else {
                string path = diagLoad.FileName;
                Cursor = Cursors.WaitCursor;
                World.World newWorld = _worldVM.Load(path);
                _worldVM = new WorldBindingSource(newWorld);
                Cursor = Cursors.Default;
                setBindings();
                refreshRender();
            }
        }

        private void refreshRender() {
            Cursor = Cursors.WaitCursor;
            pbRender.Image = _worldVM.RenderedImage;
            Cursor = Cursors.Default;
        }

        private void btnRandomSeed_Click(object sender, EventArgs e) {
            nudSeed.Value = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue)).Next(0, Int32.MaxValue);
        }

        private void button1_Click(object sender, EventArgs e) {
            nudSeed.Value = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue)).Next(0, Int32.MaxValue);
            refreshRender();
        }
    }
}
