using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace paginaweb1
{
    public partial class Form1 : Form
    {
        private object addressBar;

        public Form1()
        {
            InitializeComponent();
           
            
             FileStream stream = new FileStream("archivo.txt", FileMode.Open, FileAccess.Read);
             StreamReader reader = new StreamReader(stream);

             
             while (reader.Peek() > -1)
            
             {
                 comboBox1.Items.Add(reader.ReadLine());
             }
             
             reader.Close();
        }


        



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void messajeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonir_Click(object sender, EventArgs e)
        {
            Guardar("archivo.txt", comboBox1.Text);
            Boolean http = false;
            Boolean www = false;
            Boolean com= false;

            String Url = comboBox1.Text.ToString();
            if ((Url.Contains("http://")) || (Url.Contains("https://"))){
                http = true;
            }
            if (Url.Contains(".com")) {
                com = true;
            }
            if (Url.Contains("www."))
            {
                www=true;
            }

            if (!http && !com && !www)
            {
                webexplorer.Source = (new Uri("https://www.google.com/search?q=+" + Url));
            } else
            {
                if (!www)
                {
                    Url = "www." + Url;
                }
                if (!http)
                {
                    Url = "https://" + Url;
                }
                if (!com)
                {
                    Url = Url + ".com";
                }
                webexplorer.Source = new Uri(Url);
            }
            











        }
      
        private void Guardar(string fileName, string texto)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            comboBox1.Items.Add(texto);
           
            writer.Close();
        }

       

   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fowordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webexplorer.GoForward();

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webexplorer.Source=(new Uri("https://www.google.com"));
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webexplorer.GoBack();
        }

        private void webexplorer_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
