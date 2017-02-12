using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            nudWidth.DataBindings.Add("Value", _worldVM, "Width", true, DataSourceUpdateMode.OnPropertyChanged);
            nudHeight.DataBindings.Add("Value", _worldVM, "Height", true, DataSourceUpdateMode.OnPropertyChanged);
            nudDepth.DataBindings.Add("Value", _worldVM, "Depth", true, DataSourceUpdateMode.OnPropertyChanged);
            nudSeaLevel.DataBindings.Add("Value", _worldVM, "SeaLevel", true, DataSourceUpdateMode.OnPropertyChanged);
            nudShoreLine.DataBindings.Add("Value", _worldVM, "ShoreLine", true, DataSourceUpdateMode.OnPropertyChanged);
            nudXOffset.DataBindings.Add("Value", _worldVM, "XOffset", true, DataSourceUpdateMode.OnPropertyChanged);
            nudXCoef.DataBindings.Add("Value", _worldVM, "XOffsetCoefficient", true, DataSourceUpdateMode.OnPropertyChanged);
            nudYOffset.DataBindings.Add("Value", _worldVM, "YOffset", true, DataSourceUpdateMode.OnPropertyChanged);
            nudYCoef.DataBindings.Add("Value", _worldVM, "YOffsetCoefficient", true, DataSourceUpdateMode.OnPropertyChanged);
            cbOccludeWater.DataBindings.Add("Checked", _worldVM, "OccludeWater", true, DataSourceUpdateMode.OnPropertyChanged);
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
                refreshRender();
            }
        }

        private void refreshRender() {
            Cursor = Cursors.WaitCursor;
            pbRender.Image = _worldVM.RenderedImage;
            Cursor = Cursors.Default;
        }
    }
}
