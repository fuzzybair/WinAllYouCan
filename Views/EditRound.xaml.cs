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
using System.Windows.Shapes;
using WinAllYouCan.Code;

namespace WinAllYouCan.Views
{
	/// <summary>
	/// Interaction logic for EditRound.xaml
	/// </summary>
	public partial class EditRound : Window
	{
		public EditRound()
		{
			InitializeComponent();
		}

		private void btn_save_Click(object sender, RoutedEventArgs e)
		{
			(DataContext as MangeRounds).SaveClick.Execute(this);
		}
	}
}
