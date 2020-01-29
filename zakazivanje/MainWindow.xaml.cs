using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

namespace zakazivanje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DB baza = new DB();
        private string pretraga;
        private string pretragatretmani;


        public MainWindow()
        {


            InitializeComponent();
           /* baza.dbKlijenti.Add(new Klijent("Almedin", "Ljajic", "+381649835767"));
            baza.dbKlijenti.Add(new Klijent("Klijent", "Drugi", "+38168688468"));
            baza.dbKlijenti.Add(new Klijent("Klijent", "Treci", "+381641482359"));
            baza.dbKlijenti.Add(new Klijent("Klijent", "Cetvrti", "+381644863547"));
            //baza.SaveChanges();
            baza.dbTretmani.Add(new Tretman("almedinov pregled", 123 , "22.2.2020"));
            baza.dbTretmani.Add(new Tretman("jos jedan almedinov pregled", 456, "22.3.2020"));
            baza.dbTretmani.Add(new Tretman("opet almedinov pregled", 789, "22.4.2020"));
            baza.dbTretmani.Add(new Tretman("vala jos jedan pregled ", 101112, "22.5.2020"));*/
            baza.SaveChanges();

            DataContext = this;
            dgKlijenti.ItemsSource = baza.dbKlijenti.ToList();
            dgTretmani.ItemsSource = baza.dbTretmani.ToList();
        }

        public string Pretraga
        {
            get => pretraga;
            set
            {
                pretraga = value;
                baza = new DB();
                
                if (string.IsNullOrEmpty(pretraga) || string.IsNullOrWhiteSpace(pretraga))
                    dgKlijenti.ItemsSource = baza.dbKlijenti.ToList();
                else
                    dgKlijenti.ItemsSource = baza.dbKlijenti.Where(k => k.Ime.ToLower().Contains(pretraga.ToLower())).ToList();
            }
        }

        public string PretragTretmani
        {
            get => pretragatretmani;
            set
            {
                pretragatretmani = value;
                baza = new DB();
                if (string.IsNullOrEmpty(pretragatretmani) || string.IsNullOrWhiteSpace(pretragatretmani))
                    dgTretmani.ItemsSource = baza.dbTretmani.ToList();
                else
                {
                    dgTretmani.ItemsSource = baza.dbTretmani.Where(t => t.Naziv.ToLower().Contains(pretragatretmani.ToLower())).ToList();
                }
                    
            }
        }



        private void dodavanje_Click(object sender, RoutedEventArgs e)
        {
            KlijentEd kl = new KlijentEd();
            kl.Owner = this;
            if (kl.ShowDialog() == true)
            {
                if (!baza.dbKlijenti.ToList().Contains(kl.DataContext))
                {
                    baza.dbKlijenti.Add(kl.DataContext as Klijent);
                    baza.SaveChanges();
                } else
                { MessageBox.Show("Ima vec takav u bazi"); }
                Pretraga = null;
            }
        }

        private void izmena_Click(object sender, RoutedEventArgs e)
        {
         
            if (dgKlijenti.SelectedItem != null)
            {
                KlijentEd kl = new KlijentEd();
                kl.Owner = this;
                kl.DataContext = dgKlijenti.SelectedItem;
                if (kl.ShowDialog() == true)
                    baza.SaveChanges();
            }


        }

        private void dodavanje_tretmana_Click(object sender, RoutedEventArgs e)
        {

            TretmanED tr = new TretmanED();
            tr.Owner = this;
            if (tr.ShowDialog() == true)
            {
                if (!baza.dbTretmani.ToList().Contains(tr.DataContext))
                {
                    baza.dbTretmani.Add(tr.DataContext as Tretman);
                    baza.SaveChanges();
                    dgTretmani.ItemsSource = baza.dbTretmani.ToList();
                }
                else
                { MessageBox.Show("Ima vec takav u bazi"); }
                PretragTretmani = null;
            }
        }

        public void izmena_tretmana_Click(object sender, RoutedEventArgs e)
        {
            if(dgTretmani.SelectedItem != null)
            {
                TretmanED tr = new TretmanED();
                tr.Owner = this;
                tr.DataContext = dgTretmani.SelectedItem;
                if (tr.ShowDialog() == true)
                    baza.SaveChanges();
            }
        }

        public void brisanje_tretmana_Click(object sender, RoutedEventArgs e)
        {
            if (dgTretmani.SelectedItem != null)
            {
                baza.dbTretmani.Remove(dgTretmani.SelectedItem as Tretman);
                baza.SaveChanges();
                PretragTretmani = null;
            }
        }

        private void brisanje_Click(object sender, RoutedEventArgs e)
        {
            if (dgKlijenti.SelectedItem != null)
            {
                baza.dbKlijenti.Remove(dgKlijenti.SelectedItem as Klijent);
                baza.SaveChanges();
                Pretraga = null;
            }
        }
    }
    }

