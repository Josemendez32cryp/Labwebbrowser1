using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace paginaweb1
{
    public partial class Form1 : Form
    {
        List<URL> Urllist = new List<URL>();
        List<String> direccionlist = new List<String>();
        private object addressBar;

        public Form1()
        {
            InitializeComponent();

            //LeerHistorial();
            leerJson();
            
        }
        //private void LeerHistorial()
        //{
        //
          //  FileStream stream = new FileStream("archivo.txt", FileMode.Open, FileAccess.Read);
            //StreamReader reader = new StreamReader(stream);
            //
            //direccionlist.Clear();
            //Urllist.Clear();

//            while (reader.Peek() >-1)
 //           {
   //             URL url = new URL();
     //           url.Direccion = reader.ReadLine();
       //         url.Cantidad=Convert.ToInt16(reader.ReadLine());
         //       url.Ultimoacceso=Convert.ToDateTime(reader.ReadLine());
         //
           //     Urllist.Add(url);
           //
           //
           //
             //   direccionlist.Add(url.Direccion);
               // comboBox1.DataSource = null;
  //              comboBox1.DataSource = direccionlist;
//
    //        }

    //        reader.Close();
            
      //  }
        private void leerJson()
        {
            direccionlist.Clear();
            Urllist.Clear();
            URL_Persistencia persistencia = new URL_Persistencia();
            Urllist = persistencia.LeerJson();
            foreach (URL url in Urllist)
            {
                 direccionlist.Add(url.Direccion);
            comboBox1.DataSource = null;
            comboBox1.DataSource = direccionlist;
            }
           

        }
        private void guardarJson()
        {
            URL_Persistencia persistencia = new URL_Persistencia();
            persistencia.GuardarJson(Urllist);
            leerJson();
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
            string duplicado = Url;
            URL encontrado = Urllist.Find(u => u.Direccion == duplicado);
            if (encontrado == null)
            {
                URL direccion = new URL();
                direccion.Direccion = Url;
                direccion.Cantidad ++;
                direccion.Ultimoacceso = DateTime.Now;
                Urllist.Add(direccion);
                //Guardar("archivo.txt");
                guardarJson();
            } else
            {
                encontrado.Cantidad++;
                encontrado.Ultimoacceso = DateTime.Now;
                //Guardar("archivo.txt");
                guardarJson();
            }

            comboBox1.DataSource = null;
            comboBox1.DataSource = direccionlist;
        }
      
        private void Guardar(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            
            StreamWriter writer = new StreamWriter(stream);

            foreach (var direccion in Urllist)
            {
                writer.WriteLine(direccion.Direccion);
                writer.WriteLine(direccion.Cantidad);
                writer.WriteLine(direccion.Ultimoacceso);

            }
            
            

            writer.Close();
            //LeerHistorial();
            //guardarJson();
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

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

     

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String urleliminar = comboBox1.Text;
            Urllist.RemoveAll(u => u.Direccion == urleliminar);
            comboBox1.DataSource = null;
            comboBox1.DataSource = direccionlist;
            //Guardar(@"archivo.txt");
            guardarJson();
        }
    }
}
