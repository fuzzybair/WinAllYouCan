using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WinAllYouCan.Code
{
	class MangeRounds : System.ComponentModel.INotifyPropertyChanged
	{
		#region PropertyChanged
		/// <summary>
		/// event called when a property changes
		/// </summary>
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// raise notification that the given property has changed
		/// </summary>
		/// <param name="propertyName"></param>
		protected void RaisePropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if ((propertyChanged != null))
			{
				propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
		private Func<int, IEnumerable<Team>> m_GetRound;
		public ICommand SaveClick { get; set; }
		public MangeRounds(Func<int, IEnumerable<Team>> getRound, Action<TeamChoice[], int> saveRound)
		{
			m_GetRound = getRound;
			SaveClick = new RelayCommand((sender) => 
			{
				saveRound(SelectedRound.Select(t => t.Choice.Value).ToArray(), SelectedRoundIndex-1);
				(sender as Window).Close();
			}, (sender) => 
			{
				return true;
			});
			SelectedRoundIndex = 1;
		}
		private ObservableCollection<int> m_RoundIndexes;

		public ObservableCollection<int> RoundIndexes
		{
			get { return m_RoundIndexes; }
			set
			{
				m_RoundIndexes = value;
				RaisePropertyChanged(nameof(RoundIndexes));
			}
		}

		private int m_SelectedRoundIndex;

		public int SelectedRoundIndex
		{
			get { return m_SelectedRoundIndex; }
			set
			{
				m_SelectedRoundIndex = value;
				SelectedRound = new ObservableCollection<Team>(m_GetRound(value-1));
				RaisePropertyChanged(nameof(SelectedRoundIndex));
			}
		}
		private ObservableCollection<Team> m_SelectedRound;

		public ObservableCollection<Team> SelectedRound
		{
			get { return m_SelectedRound; }
			set
			{
				m_SelectedRound = value;
				RaisePropertyChanged(nameof(SelectedRound));
			}
		}
	}
}
