using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArtistsListBox.DataSource = Album.GetAlbums()
            .Select(album => album.Artist)
            .Distinct()
            .ToList();
        }
        private void ArtistsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlbumsBox.DataSource = Album.GetAlbums().Where(album => album.Artist.Equals(ArtistsListBox.SelectedValue))
                .OrderByDescending(Album => Album.Date).Select(Album => Album.ToString()).ToList();
        }
    }
}
