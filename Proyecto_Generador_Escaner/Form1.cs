using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Proyecto_Generador_Escaner.ClasesDelProyecto;

namespace Proyecto_Generador_Escaner
{
    public partial class Form1 : Form
    {
        ArrayList Datos = new ArrayList();
        List<Follows> LSiguientes = new List<Follows>();
        List<string[]> Tabla = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Archivo file = new Archivo();
            Automata scanner = new Automata();
            try
            {
                file.ObtenerUbicacion();
                scanner.DescomponerDatos(file.LeerArchivo());
            }
            catch
            {
                MessageBox.Show("ERROR EN LA LECTURA DEL ARCHIVO, NO POSEE EL FORMATO ESTABLECIDO");
            }
            string ER = "";
            for (int x = 0; x < scanner.LTokens.Count; x++)
            {
                ER += "(" + scanner.LTokens[x].ER[1] + ")" + "|";
            }
            ER = ER.TrimEnd('|');
            ER = "(" + ER + ")·#";
            try
            {
                ArrayList entrada = SepararSimbolos(ER);
                ArrayList salida = InfijoASufijo(entrada);
                CalcularAFD(salida);
                MessageBox.Show("AFD Creado");
            }
            catch
            {
                MessageBox.Show("Error al buscar nombre de alfabeto");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string ER = txtER.Text.ToString();
            ER = "(" + ER + ")·#";
            ArrayList entrada = SepararSimbolos(ER);
            ArrayList salida = InfijoASufijo(entrada);
            CalcularAFD(salida);
            MessageBox.Show("AFD Creado");
        }
        public ArrayList SepararSimbolos(string ER)
        {
            ArrayList arreglo = new ArrayList();
            string linea = "";
            char[] caracteres = ER.ToCharArray();
            for (int x = 0; x < caracteres.Length; x++)
            {
                if (caracteres[x] == '·' || caracteres[x] == '(' || caracteres[x] == '|' || caracteres[x] == ')' || caracteres[x] == '*' || caracteres[x] == '+' || caracteres[x] == '?')
                {
                    if (linea != "")
                    {
                        arreglo.Add(linea);
                        arreglo.Add(caracteres[x]);
                        linea = "";
                    }
                    else
                    {
                        arreglo.Add(caracteres[x]);
                    }
                }
                else
                {
                    if (x == caracteres.Length - 1)
                    {
                        linea += caracteres[x];
                        arreglo.Add(linea);
                    }
                    else
                    {
                        linea += caracteres[x];
                    }
                }
            }
            return arreglo;
        }
        public int Presedencia(char simbolo)
        {
            int Orden = 0;
            switch (simbolo)
            {
                case '*': Orden = 4; break;
                case '+': Orden = 4; break;
                case '?': Orden = 4; break;
                case '·': Orden = 3; break;
                case '|': Orden = 2; break;
                case '(': Orden = 1; break;
            }
            return Orden;
        }
        public ArrayList InfijoASufijo(ArrayList entrada)
        {
            Stack<char> Operadores = new Stack<char>();
            ArrayList LSufija = new ArrayList();

            for (int x = 0; x < entrada.Count; x++)
            {
                if (entrada[x].ToString() != "·" && entrada[x].ToString() != "(" && entrada[x].ToString() != "|" && entrada[x].ToString() != ")" && entrada[x].ToString() != "*" && entrada[x].ToString() != "+" && entrada[x].ToString() != "?")
                {
                    LSufija.Add(entrada[x]);
                }
                else if (entrada[x].ToString() == "(")
                {
                    Operadores.Push(Convert.ToChar(entrada[x]));
                }
                else if (entrada[x].ToString() == ")")
                {
                    char SimboloTope = Operadores.Pop();
                    while (SimboloTope != '(')
                    {
                        LSufija.Add(SimboloTope);
                        SimboloTope = Operadores.Pop();
                    }
                }
                else
                {
                    while ((Operadores.Count != 0) && (Presedencia(Operadores.Peek()) >= Presedencia(Convert.ToChar(entrada[x]))))
                    {
                        LSufija.Add(Operadores.Pop());
                    }
                    Operadores.Push(Convert.ToChar(entrada[x]));
                }
            }
            while (Operadores.Count != 0)
            {
                LSufija.Add(Operadores.Pop());
            }

            return LSufija;
        }
        public void CalcularAFD(ArrayList ER)
        {
            Stack<Nodo> Simbolos = new Stack<Nodo>();
            List<Nodo> ExpresionRegular = new List<Nodo>();
            ArrayList ST = new ArrayList();
            int cont = 1;
            for (int x = 0; x < ER.Count; x++)
            {
                if (ER[x].ToString() != "·" && ER[x].ToString() != "(" && ER[x].ToString() != "|" && ER[x].ToString() != ")" && ER[x].ToString() != "*" && ER[x].ToString() != "+" && ER[x].ToString() != "?")
                {
                    Follows Siguiente = new Follows();
                    Siguiente.Indice = cont;
                    Siguiente.Simbolo = ER[x].ToString();
                    LSiguientes.Add(Siguiente);
                    Nodo N = new Nodo();
                    N.simbolo = ER[x].ToString();
                    N.First.Add(cont);
                    N.Last.Add(cont);
                    N.Nulo = false;
                    cont++;
                    ExpresionRegular.Add(N);
                    if ((!ST.Contains(ER[x])) && ER[x].ToString() != "#")
                        ST.Add(ER[x]);
                }
                else
                {
                    Nodo N = new Nodo();
                    N.simbolo = ER[x].ToString();
                    ExpresionRegular.Add(N);
                }
            }
            for (int x = 0; x < ER.Count; x++)
            {
                if (ER[x].ToString() != "·" && ER[x].ToString() != "(" && ER[x].ToString() != "|" && ER[x].ToString() != ")" && ER[x].ToString() != "*" && ER[x].ToString() != "+" && ER[x].ToString() != "?")
                {
                    Simbolos.Push(ExpresionRegular[x]);
                }
                else
                {
                    CalcularNuevoNodo(ER[x].ToString(), ref Simbolos);
                }
            }
            MostrarFollows();

            //Tabla final
            Queue<string> ConjuntosNuevos = new Queue<string>();
            List<string> ConjuntosExisten = new List<string>();
            string[] conjuntos = new string[ST.Count + 1];
            string Inicio = "";
            Nodo N2 = Simbolos.Pop();
            List<int> First = N2.First;
            for (int x = 0; x < First.Count; x++)
            {
                Inicio += First[x] + ",";
            }
            Inicio = Inicio.TrimEnd(',');
            conjuntos[0] = Inicio;
            ConjuntosNuevos.Enqueue(Inicio);
            ConjuntosExisten.Add(Inicio);
            ST.Sort();
            while (ConjuntosNuevos.Count != 0)
            {
                if (ConjuntosNuevos.Count != 0)
                {
                    conjuntos[0] = ConjuntosNuevos.Dequeue();
                }
                for (int x = 0; x < ST.Count; x++)
                {
                    for (int y = 0; y < LSiguientes.Count; y++)
                    {
                        if (ST[x].ToString() == LSiguientes[y].Simbolo && conjuntos[0].Contains(LSiguientes[y].Indice.ToString()))
                        {
                            for (int z = 0; z < LSiguientes[y].Follow.Count; z++)
                            {
                                if (conjuntos[x + 1] == null || conjuntos[x + 1] == "")
                                {
                                    conjuntos[x + 1] += LSiguientes[y].Follow[z].ToString();
                                }
                                else if (!conjuntos[x + 1].Contains(LSiguientes[y].Follow[z].ToString()))
                                {
                                    conjuntos[x + 1] += "," + LSiguientes[y].Follow[z].ToString();
                                }
                            }
                            conjuntos[x + 1] = conjuntos[x + 1].TrimEnd(',');
                            if (conjuntos[0] != conjuntos[x + 1] && !ConjuntosExisten.Contains(conjuntos[x + 1]))
                            {
                                ConjuntosNuevos.Enqueue(conjuntos[x + 1]);
                                ConjuntosExisten.Add(conjuntos[x + 1]);
                            }
                        }
                    }
                }
                Tabla.Add(conjuntos);
                conjuntos = new string[ST.Count + 1];

            }
            MostrarTabla(ST, ConjuntosExisten);
        }
        public void MostrarTabla(ArrayList ST, List<string> ConjuntosExisten)
        {
            ArrayList NombreConjunto = new ArrayList();
            for (int i = 65; i <= 90; i++)
            {
                NombreConjunto.Add((char)i);
            }
            for (int j = 0; j <= 26; j++)
            {
                for (int l = 0; l <= 26; l++)
                {
                    NombreConjunto.Add(NombreConjunto[j].ToString() + NombreConjunto[l].ToString());
                }
            }
            DGVTabla.RowCount = ConjuntosExisten.Count + 1;
            DGVTabla.ColumnCount = ST.Count + 1;
            for (int x = 1; x <= ST.Count; x++)
            {
                DGVTabla.Rows[0].Cells[x].Value = ST[x - 1].ToString();
            }
            for (int x = 0; x < Tabla.Count; x++)
            {
                for (int y = 0; y < ST.Count + 1; y++)
                {
                    for (int z = 0; z < ConjuntosExisten.Count; z++)
                    {
                        if (Tabla[x][y] == ConjuntosExisten[z])
                        {
                            if (x == 0 && y == 0)
                            {
                                if (Tabla[x][y].Contains(LSiguientes.Last().Indice.ToString()) && y == 0)
                                    DGVTabla.Rows[x + 1].Cells[y].Value = "→#" + NombreConjunto[z];
                                else
                                    DGVTabla.Rows[x + 1].Cells[y].Value = "→" + NombreConjunto[z];
                            }
                            else
                            {
                                if (Tabla[x][y].Contains(LSiguientes.Last().Indice.ToString()) && y == 0)
                                    DGVTabla.Rows[x + 1].Cells[y].Value = "#" + NombreConjunto[z];
                                else
                                    DGVTabla.Rows[x + 1].Cells[y].Value = NombreConjunto[z];
                            }
                        }
                    }
                }
            }
        }
        public void MostrarFollows()
        {
            string linea = "";
            for (int x = 0; x < LSiguientes.Count; x++)
            {
                linea += LSiguientes[x].Indice.ToString() + ")  ";
                for (int y = 0; y < LSiguientes[x].Follow.Count; y++)
                {
                    if (y == LSiguientes[x].Follow.Count - 1)
                        linea += LSiguientes[x].Follow[y].ToString();
                    else
                        linea += LSiguientes[x].Follow[y].ToString() + ",";
                }
                lbFollows.Items.Add(linea);
                linea = "";
            }
        }
        public void CalcularFollowSimple(Nodo Nuevo)
        {
            //Calcular Follows
            for (int x = 0; x < Nuevo.Last.Count; x++)
            {
                for (int y = 0; y < LSiguientes.Count; y++)
                {
                    if (Nuevo.Last[x] == LSiguientes[y].Indice)
                    {
                        for (int z = 0; z < Nuevo.First.Count; z++)
                        {
                            if (!LSiguientes[y].Follow.Contains(Nuevo.First[z]))
                            {
                                LSiguientes[y].Follow.Add(Nuevo.First[z]);
                            }
                        }
                    }
                }
            }
        }
        public void CalcularFollowCompuesto(Nodo C1, Nodo C2)
        {
            for (int x = 0; x < C1.Last.Count; x++)
            {
                for (int y = 0; y < LSiguientes.Count; y++)
                {
                    if (C1.Last[x] == LSiguientes[y].Indice)
                    {
                        for (int z = 0; z < C2.First.Count; z++)
                        {
                            if (!LSiguientes[y].Follow.Contains(C2.First[z]))
                            {
                                LSiguientes[y].Follow.Add(C2.First[z]);
                            }
                        }
                    }
                }
            }
        }

        public void CalcularNuevoNodo(string Operador, ref Stack<Nodo> pSimbolos)
        {
            Nodo Nuevo = new Nodo();
            switch (Operador)
            {
                case "*":
                    Nodo C1_Asterisco = pSimbolos.Pop();
                    Nuevo.simbolo = "(" + C1_Asterisco.simbolo + ")*";
                    Nuevo.First = C1_Asterisco.First;
                    Nuevo.Last = C1_Asterisco.Last;
                    foreach (var s in Nuevo.First)
                    {
                        lbFirst.Items.Add("First del (*) =" + s);
                    }
                    foreach (var s in Nuevo.Last)
                    {
                        lbLast.Items.Add("Last del (*) =" + s);
                    }
                    Nuevo.Nulo = true;
                    pSimbolos.Push(Nuevo);
                    //Calcular Follows
                    CalcularFollowSimple(Nuevo);
                    break;  //------------------------------------------------------------------------------------------------------
                case "+":
                    Nodo C1_Mas = pSimbolos.Pop();
                    Nuevo.simbolo = "(" + C1_Mas.simbolo + ")+";
                    Nuevo.First = C1_Mas.First;
                    Nuevo.Last = C1_Mas.Last;
                    foreach (var s in Nuevo.First)
                    {
                        lbFirst.Items.Add("First del (+) =" + s);
                    }
                    foreach (var s in Nuevo.Last)
                    {
                        lbLast.Items.Add("Last del (+) =" + s);
                    }
                    Nuevo.Nulo = false;
                    pSimbolos.Push(Nuevo);
                    //Calcular Follows
                    CalcularFollowSimple(Nuevo);
                    break;  //------------------------------------------------------------------------------------------------------
                case "?":
                    Nodo C1_Interrogacion = pSimbolos.Pop();
                    Nuevo.simbolo = "(" + C1_Interrogacion.simbolo + ")?";
                    Nuevo.First = C1_Interrogacion.First;
                    Nuevo.Last = C1_Interrogacion.Last;
                    foreach (var s in Nuevo.First)
                    {
                        lbFirst.Items.Add("First del (?) =" + s);
                    }
                    foreach (var s in Nuevo.Last)
                    {
                        lbLast.Items.Add("Last del (?) =" + s);
                    }
                    Nuevo.Nulo = true;
                    pSimbolos.Push(Nuevo);
                    break;  //-------------------------------------------------------------------------------------------------------
                case "·":
                    Nodo C2_Concatenacion = pSimbolos.Pop();
                    Nodo C1_Concatenacion = pSimbolos.Pop();
                    Nuevo.simbolo = C1_Concatenacion.simbolo + "·" + C2_Concatenacion.simbolo;
                    //Calcular First
                    if (C1_Concatenacion.Nulo)
                    {
                        List<int> FirstTemp = new List<int>();
                        for (int x = 0; x < C1_Concatenacion.First.Count; x++)
                        {
                            FirstTemp.Add(C1_Concatenacion.First[x]);
                        }
                        for (int y = 0; y < C2_Concatenacion.First.Count; y++)
                        {
                            FirstTemp.Add(C2_Concatenacion.First[y]);
                        }
                        Nuevo.First = FirstTemp;
                    }
                    else
                    {
                        Nuevo.First = C1_Concatenacion.First;
                    }
                    //Calcular Last
                    if (C2_Concatenacion.Nulo)
                    {
                        List<int> LastTemp = new List<int>();
                        for (int x = 0; x < C1_Concatenacion.Last.Count; x++)
                        {
                            LastTemp.Add(C1_Concatenacion.Last[x]);
                        }
                        for (int y = 0; y < C2_Concatenacion.Last.Count; y++)
                        {
                            LastTemp.Add(C2_Concatenacion.Last[y]);
                        }
                        Nuevo.Last = LastTemp;
                    }
                    else
                    {
                        Nuevo.Last = C2_Concatenacion.Last;
                    }
                    //Calcular Nulo
                    if (C1_Concatenacion.Nulo == true && C2_Concatenacion.Nulo == true)
                        Nuevo.Nulo = true;
                    else
                        Nuevo.Nulo = false;
                    pSimbolos.Push(Nuevo);
                    //Calcular Follows
                    CalcularFollowCompuesto(C1_Concatenacion, C2_Concatenacion);
                    foreach (var s in Nuevo.First)
                    {
                        lbFirst.Items.Add("First del (°) =" + s);
                    }
                    foreach (var s in Nuevo.Last)
                    {
                        lbLast.Items.Add("Last del (°) =" + s);
                    }
                    break;  //---------------------------------------------------------------------------------------------------------
                case "|":
                    Nodo C2_Or = pSimbolos.Pop();
                    Nodo C1_Or = pSimbolos.Pop();
                    Nuevo.simbolo = C1_Or.simbolo + "|" + C2_Or.simbolo;
                    //Calcular First
                    for (int x = 0; x < C1_Or.First.Count; x++)
                    {
                        Nuevo.First.Add(C1_Or.First[x]);
                    }
                    for (int y = 0; y < C2_Or.First.Count; y++)
                    {
                        Nuevo.First.Add(C2_Or.First[y]);
                    }
                    //Calcular Last
                    for (int x = 0; x < C1_Or.Last.Count; x++)
                    {
                        Nuevo.Last.Add(C1_Or.Last[x]);
                    }
                    for (int y = 0; y < C2_Or.Last.Count; y++)
                    {
                        Nuevo.Last.Add(C2_Or.Last[y]);
                    }
                    //Calcular Nulo
                    if (C1_Or.Nulo == true || C2_Or.Nulo == true)
                        Nuevo.Nulo = true;
                    else
                        Nuevo.Nulo = false;
                    pSimbolos.Push(Nuevo);
                    foreach (var s in Nuevo.First)
                    {
                        lbFirst.Items.Add("First del ( | ) =" + s);
                    }
                    foreach (var s in Nuevo.Last)
                    {
                        lbLast.Items.Add("Last del ( | ) =" + s);
                    }
                    break;

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
