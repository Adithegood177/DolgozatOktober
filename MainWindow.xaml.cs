using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dogab
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
/*Egy TextBox-ba beírod a diák nevét.

Egy másik TextBox-ba beírod, mennyit fizetett be.

„Hozzáadás” gomb → bekerül a ListBox-ba: Név – összeg.

A végén egy TextBlock-ban kiírja: „Összesen: … Ft”.

Legyen „CE” gomb (mezők törlése) és „C” gomb (lista törlése).

„Kijelölt törlése” → törli a kiválasztott diákot a listából, és az összegből levonja.

*/
public partial class MainWindow : Window
{
		public int osszeg = 0;
		public MainWindow()
	{
			InitializeComponent();
	}

		private void HozzaadClick(object sender, RoutedEventArgs e)
		{
			string nev = diaknev.Text;
			
			if (int.TryParse(fizetettosszeg.Text, out int eredmeny) && eredmeny > 0)
			{
				osszeg += eredmeny;
				

				osszesen.Text =osszeg.ToString();
				string szoveg = nev + " - " + eredmeny + " Ft";
				Lista.Items.Add(szoveg);
			}
			else
			{
				MessageBox.Show("Hibás összeg!");
			}
			
		}

		private void CeClick(object sender, RoutedEventArgs e)
		{
			diaknev.Text = "";
			fizetettosszeg.Text = "";
		}

		private void CClick(object sender, RoutedEventArgs e)
		{
			Lista.Items.Clear();
			osszeg = 0;
			osszesen.Text ="0";	
		}

		private void KijeloltTorol(object sender, RoutedEventArgs e)
		{
			if (Lista.SelectedItems != null)
			{
				string torlendo = Lista.SelectedItem.ToString();
				string[] darabolt = torlendo.Split('-');
				string osszegstring = darabolt[1].Trim().Replace(" Ft", "");
				int torlendoosszeg = int.Parse(osszegstring);
				osszeg -= torlendoosszeg;
				osszesen.Text = osszeg.ToString();
				Lista.Items.Remove(Lista.SelectedItem);
			}
		}
	}
}