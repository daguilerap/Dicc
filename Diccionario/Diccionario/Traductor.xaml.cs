using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diccionario
{
    public partial class MainWindow : Window
    {
        SortedDictionary<string,string> dic = new SortedDictionary<string, string>();
        Random rand = new Random();
        List<string> listaValorMos = new List<string>();
        int aciertos = 0;
        int fallos = 0;

        string val="";

        public MainWindow()
        {
            InitializeComponent();
            dic.Add("Black", "Negro");
            dic.Add("Cat", "Gato");
            dic.Add("Dog", "Perro");
            dic.Add("House", "Casa");
            dic.Add("White", "Blanco");
            dic.Add("Red", "Rojo");
            dic.Add("Blue", "Azul");
            dic.Add("Car", "Coche");
            dic.Add("Computer", "Ordenador");
            dic.Add("Smartphone", "Movil");
            dic.Add("Pink", "Rosa");
            dic.Add("Wine", "Vino");

            foreach (var i in dic)
            {
                myListBox.Items.Add(i);
            }

        }

        private void btnEsp_Click(object sender, RoutedEventArgs e)
        {
            diccionario();
        }

        public void diccionario()
        {
            foreach (var kvp in dic)
            {
                if (txtIng.Text == kvp.Key)
                {
                    labIng.Content = kvp.Value;
                }
                    
            }
                
            foreach (var kvp2 in dic)
            {
                if (txtEsp.Text == kvp2.Value)
                {
                    labEsp.Content = kvp2.Key;
                }
            }
                       
        }

        private void btnEmpezar_Click(object sender, RoutedEventArgs e)
        {
            string valorRan = dic.ElementAt(rand.Next(0, dic.Count)).Key;
            val = dic[valorRan];

           
            listaValorMos.Add(valorRan);
            labAdivinar.Content = valorRan;
            btnSiguiente.IsEnabled = true;
            LabResultado.Content = "";
            labContador.Content = "0/10";
            txtJuego.Clear();
            labAcierto.Content = 0;
            labFallos.Content = 0;
            btnEmpezar.IsEnabled = false;
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            int cont = listaValorMos.Count;

            if (cont <= 9)
            {
               
                validar(val);
                
                String sigValorRan = dic.ElementAt(rand.Next(0, dic.Count)).Key;
                val = dic[sigValorRan];
                
                while (listaValorMos.Contains(sigValorRan))
                {
                    sigValorRan = dic.ElementAt(rand.Next(0, dic.Count)).Key;
                    val = dic[sigValorRan];
                }

                listaValorMos.Add(sigValorRan);
                labAdivinar.Content = sigValorRan;
                labContador.Content = cont + "/10";

            } else
            {
                labContador.Content = cont + "/10";
                listaValorMos.Clear();
                LabResultado.Content = validar(val);
                btnSiguiente.IsEnabled = false;
                aciertos = 0;
                fallos = 0;
                btnEmpezar.IsEnabled = true;

            }
               
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            String addIng = txtAddIng.Text;
            String addEsp = txtAddEsp.Text;

            dic.Add(addIng, addEsp);

            myListBox.Items.Clear();

            foreach (var i in dic)
            {
                myListBox.Items.Add(i);
            }
                
            txtAddIng.Text = "";
            txtAddEsp.Text = "";
            
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            int index = myListBox.SelectedIndex;
            myListBox.Items.RemoveAt(index);

            string llaveSelec = dic.ElementAt(index).Key;
            dic.Remove(llaveSelec);
        }

        private string validar(string val)
        {
            string palabra = txtJuego.Text;
            string resultado;

            if (palabra == val)
            {
                aciertos++;
                labAcierto.Content = aciertos;
            }

            if(palabra != val)
            {
                fallos++;
                labFallos.Content = fallos;
            }

            if (aciertos > fallos)
            {
                resultado = "Has ganado";  
            } else
            { 
                resultado = "Has perdido"; 
            }

            txtJuego.Clear();

            return resultado;
        }

    }
}
