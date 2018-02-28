using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Archivos_de_texto_y_binarios
{
    public partial class Form1 : Form
    {
        FileStream archivo;
        BinaryReader br;
        StreamWriter sr;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {

            ofd2.Filter = "Imagenes (*.BMP)|*.bmp";
            ofd2.ShowDialog();
            archivo = new FileStream(ofd2.FileName, FileMode.Open);
            br = new BinaryReader(archivo);

            Leer();
        }

        private void Leer()
        {
            string desc = "";

            archivo.Seek(2, SeekOrigin.Begin);
            desc += "Tamaño real en bytes: " + br.ReadInt32() + Environment.NewLine;
            archivo.Seek(18, SeekOrigin.Begin);
            desc += "Ancho: " + br.ReadInt32() + Environment.NewLine;
            archivo.Seek(22, SeekOrigin.Begin);
            desc += "Alto: " + br.ReadInt32() + Environment.NewLine;
            archivo.Seek(28, SeekOrigin.Begin);
            desc += "Bits p/pixel: " + br.ReadInt32();
            txtDescripcion.Text = desc;

            archivo.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            sfd1.ShowDialog();

            archivo = new FileStream(sfd1.FileName, FileMode.Create);
            sr = new StreamWriter(archivo);
            Generar();
        }

        private void Generar()
        {
            sr.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sr.WriteLine("<Libro>");
            sr.WriteLine("  <Titulo>" + txtTitulo.Text + "</Titulo>");
            sr.WriteLine("  <Genero>" + txtGenero.Text + "</Genero>");
            sr.WriteLine("  <Autor>" + txtAutor.Text + "</Autor>");
            sr.WriteLine("  <Paginas>" + txtPaginas.Text + "</Paginas>");
            sr.WriteLine("  <Editorial>" + txtEditorial.Text + "</Editorial>");
            sr.WriteLine("</Libro>");

            sr.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
