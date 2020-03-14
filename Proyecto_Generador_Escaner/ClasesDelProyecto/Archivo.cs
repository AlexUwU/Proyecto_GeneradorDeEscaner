using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;


namespace Proyecto_Generador_Escaner.ClasesDelProyecto
{
    class Archivo
    {
        public string Ubicacionarchivo;

        public void ObtenerUbicacion()
        {
            OpenFileDialog FILE = new OpenFileDialog();
            FILE.Title = "Open Text File";
            FILE.Filter = "TXT files|*.txt";
            FILE.InitialDirectory = @"C:\";
            if (FILE.ShowDialog() == DialogResult.OK)
            {
                Ubicacionarchivo = FILE.FileName.ToString();
            }
        }

        public ArrayList LeerArchivo()
        {
            StreamReader objReader = new StreamReader(Ubicacionarchivo);
            string sLine = "";
            ArrayList arreglo = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != " " && sLine != "" && sLine != "\t")
                    arreglo.Add(sLine);
            }
            objReader.Close();
            return arreglo;
        }
    }
}
