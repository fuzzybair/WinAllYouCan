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
using WinAllYouCan.Code;

namespace WinAllYouCan
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new ApplicationModel(this);
		}

		private void ExitMenu_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ScoreBtn_Click(object sender, RoutedEventArgs e)
		{
			if ((DataContext as ApplicationModel).CanScoreRound(sender))
			{
				(DataContext as ApplicationModel)?.ScoreRound(sender);
			}
		}

		private void EditRound_Click(object sender, RoutedEventArgs e)
		{
			(DataContext as ApplicationModel)?.EditRound(sender, this);
		}

		private void TeamNames_Click(object sender, RoutedEventArgs e)
		{
			(DataContext as ApplicationModel)?.EditTeamNames(sender, this);
		}
		private void ScoreBoard_Click(object sender, RoutedEventArgs e)
		{
			(DataContext as ApplicationModel)?.ShowScoreBoard(sender, this);
		}
		
	}
}
