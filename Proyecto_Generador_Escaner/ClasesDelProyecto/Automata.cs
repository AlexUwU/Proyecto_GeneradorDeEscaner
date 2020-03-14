using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Proyecto_Generador_Escaner.ClasesDelProyecto
{
    class Automata
    {
        public List<Sets> LSets = new List<Sets>();
        public List<Tokens> LTokens = new List<Tokens>();
        public ArrayList LActions = new ArrayList();
        public string Error = "";

        public void DescomponerDatos(ArrayList Datos)
        {
            int iSets = 0, iTokens = 0, iActions = 0, iError = 0;
            for (int i = 0; i < Datos.Count; i++)
            {
                if (Datos[i].ToString().ToUpper() == "SETS")
                    iSets = i;
                if (Datos[i].ToString().ToUpper() == "TOKENS")
                    iTokens = i;
                if (Datos[i].ToString().ToUpper() == "TOKEN")
                    iActions = i;
                if (Datos[i].ToString().ToUpper() == "ACTIONS")
                    iActions = i;
                if (Datos[i].ToString().ToUpper().Contains("ERROR"))
                    iError = i;
            }

            if (iSets == 0 && iTokens == 0 && iActions == 0 && iError == 0)
            {
                MessageBox.Show("ERROR EN EL ARCHIVO, NO POSEE EL FORMATO ESTABLECIDO");
            }

            //Guardar dato final en lista
            for (int x = iSets + 1; x < iTokens; x++)
            {
                Sets set = new Sets();
                set.Alfabeto = DescomponerSets(Datos[x]);
                LSets.Add(set);
            }
            for (int x = iTokens + 1; x < iActions; x++)
            {
                Tokens token = new Tokens();
                if (Datos[x].ToString() != "")
                    token.ER = DescomponerTokens(Datos[x]);
                LTokens.Add(token);
            }
            for (int x = iActions + 1; x < iError; x++)
            {
                if (Datos[x].ToString() != "")
                    LActions.Add(Datos[x]);
            }
            Error = Datos[iError].ToString();
        }

        public ArrayList DescomponerSets(object Dato)
        {
            ArrayList arreglo = new ArrayList();
            string linea = "";
            char[] caracteres = Dato.ToString().ToCharArray();

            //Elimina espacios y tabs
            for (int x = 0; x < caracteres.Length; x++)
            {
                if (caracteres[x] != ' ' && caracteres[x] != '\t')
                    linea += caracteres[x];
            }

            string[] Alfabeto = linea.Split('=');
            arreglo.Add(Alfabeto[0]);   //Guarda nombre de alfabeto
            //Si contiene mas de un elemento entra en la condición
            if (Alfabeto[1].Contains("+"))
            {
                string[] Conjunto = Alfabeto[1].Split('+');
                for (int x = 0; x < Conjunto.Length; x++)
                {
                    //Si contiene un rango de caracteres entra en la condicion
                    if (Conjunto[x].Contains(".."))
                    {
                        string[] Rango = Conjunto[x].Split('\'');
                        char a = Convert.ToChar(Rango[1]);
                        char b = Convert.ToChar(Rango[3]);
                        for (int y = (int)a; y <= (int)b; y++)
                        {
                            arreglo.Add((char)y);
                        }
                    }
                    else
                    {
                        string[] elemento = Conjunto[x].Split('\'');
                        arreglo.Add(elemento[1]);
                    }
                }
            }
            else
            {
                if (Alfabeto[1].Contains(".."))
                {
                    //Si es un arreglo de caracteres entra en la condicion
                    if (Alfabeto[1].Contains("(") && Alfabeto[1].Contains(")"))
                    {
                        string[] chr = Alfabeto[1].Split('(', ')');
                        int a = Convert.ToInt16(chr[1]);
                        int b = Convert.ToInt16(chr[3]);
                        for (int y = a; y <= b; y++)
                        {
                            arreglo.Add((char)y);
                        }
                    }
                    else
                    {
                        string[] Rango = Alfabeto[1].Split('\'');
                        char a = Convert.ToChar(Rango[1]);
                        char b = Convert.ToChar(Rango[3]);
                        for (int y = (int)a; y <= (int)b; y++)
                        {
                            arreglo.Add((char)y);
                        }
                    }
                }
                else
                {
                    string[] elemento = Alfabeto[1].Split('\'');
                    arreglo.Add(elemento[1]);
                }
            }
            return arreglo;
        }

        public ArrayList DescomponerTokens(object Dato)
        {
            ArrayList arreglo = new ArrayList();
            string Token = "", ER = "", linea = "", alfabeto = "";
            char[] chars = Dato.ToString().ToCharArray();

            //Elimina espacios y tabs
            for (int x = 0; x < chars.Length; x++)
            {
                if (chars[x] != ' ' && chars[x] != '\t')
                    linea += chars[x];
            }
            char[] caracteres = linea.ToCharArray();

            //Obtiene nombre del token y lo almacena
            int cont = 0;
            while (caracteres[cont] != '=')
            {
                Token += caracteres[cont];
                cont++;
            }
            arreglo.Add(Token);
            //Obtiene expresion regular y la almacena
            try
            {
                while (cont < caracteres.Length - 1)
                {
                    cont++;
                    if (caracteres[cont] == '\'')
                    {
                        if (caracteres[cont] == '\'' && caracteres[cont + 1] == '\'' && caracteres[cont + 2] == '\'') //Caso Especial
                        {
                            cont += 2;
                            ER += '\'';
                            if (cont != caracteres.Length - 1)
                            {
                                if (caracteres[cont + 1] != '|' && caracteres[cont + 1] != '*' && caracteres[cont + 1] != '+' && caracteres[cont + 1] != '?' && caracteres[cont + 1] != ')')
                                {
                                    ER += '·';
                                }
                            }
                        }
                        else
                        {
                            cont++;
                            while (caracteres[cont] != '\'')
                            {
                                if (caracteres[cont] == '+' || caracteres[cont] == '*')
                                {
                                    if (caracteres[cont] == '+')
                                        ER = "┼";
                                    else
                                        ER = "×";
                                }
                                else
                                    ER += caracteres[cont];
                                cont++;
                            }
                            if (cont != caracteres.Length - 1)
                            {
                                if (caracteres[cont + 1] != '|' && caracteres[cont + 1] != '*' && caracteres[cont + 1] != '+' && caracteres[cont + 1] != '?' && caracteres[cont + 1] != ')')
                                {
                                    ER += '·';
                                }
                            }
                        }
                    }
                    else
                    {
                        if (caracteres[cont] != '|' && caracteres[cont] != '*' && caracteres[cont] != '+' && caracteres[cont] != '?' && caracteres[cont] != '(' && caracteres[cont] != ')')
                        {
                            alfabeto += caracteres[cont];
                            for (int x = 0; x < LSets.Count; x++)
                            {
                                if (alfabeto == LSets[x].Alfabeto[0].ToString())
                                {
                                    ER += alfabeto;
                                    if (cont != caracteres.Length - 1)
                                    {
                                        if (caracteres[cont + 1] != '|' && caracteres[cont + 1] != '*' && caracteres[cont + 1] != '+' && caracteres[cont + 1] != '?' && caracteres[cont + 1] != ')')
                                        {
                                            ER += '·';
                                        }
                                    }
                                    alfabeto = "";
                                }
                            }
                        }
                        else
                        {
                            ER += caracteres[cont];
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("ERROR EN EL TOKEN" + ER[0]);
            }
            arreglo.Add(ER);

            return arreglo;
        }


    }

}
