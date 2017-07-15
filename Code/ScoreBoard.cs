using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinAllYouCan.Code
{
	class ScoreBoard : INotifyPropertyChanged
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

		public ScoreBoard()
		{
			Set2Visibility = Visibility.Hidden;
			Set3Visibility = Visibility.Hidden;
			Set4Visibility = Visibility.Hidden;
			Set5Visibility = Visibility.Hidden;
			TeamScoreVisibility = Visibility.Hidden;
			GroupScoreVisibility = Visibility.Hidden;

			Scores = new ObservableCollection<ScoreRound>
			{
				new ScoreRound { Multiplier = 1 },
				new ScoreRound { Multiplier = 1 },
				new ScoreRound { Multiplier = 1 },
				new ScoreRound { Multiplier = 2 },
				new ScoreRound { Multiplier = 2 },
				new ScoreRound { Multiplier = 2 },
				new ScoreRound { Multiplier = 5 },
				new ScoreRound { Multiplier = 5 },
				new ScoreRound { Multiplier = 5 },
				new ScoreRound { Multiplier = 10 },
			};
			Totals = new ObservableCollection<ScoreRoundTotals>
			{
				new ScoreRoundTotals(),
				new ScoreRoundTotals(),
				new ScoreRoundTotals(),
				new ScoreRoundTotals(),
			};
			TeamTotals = new GameTotal();
		}
		public void UpdateTotals()
		{
			Totals[0].UpdateValues(Scores.Take(3));
			Totals[1].UpdateValues(Scores.Skip(3).Take(3), Totals[0]);
			Totals[2].UpdateValues(Scores.Skip(6).Take(3), Totals[1]);
			Totals[3].UpdateValues(Scores.Skip(9).Take(1), Totals[2]);
			TeamTotals.UpdateValues(Scores);
		}

		public ObservableCollection<ScoreRound> Scores { get; set; }
		public ObservableCollection<ScoreRoundTotals> Totals { get; set; }
		public GameTotal TeamTotals { get; set; }

		#region Visibility
		private Visibility m_Set2Visibility;

		public Visibility Set2Visibility
		{
			get { return m_Set2Visibility; }
			set
			{
				m_Set2Visibility = value;
				RaisePropertyChanged(nameof(Set2Visibility));
			}
		}

		private Visibility m_Set3Visibility;

		public Visibility Set3Visibility
		{
			get { return m_Set3Visibility; }
			set
			{
				m_Set3Visibility = value;
				RaisePropertyChanged(nameof(Set3Visibility));
			}
		}

		private Visibility m_Set4Visibility;

		public Visibility Set4Visibility
		{
			get { return m_Set4Visibility; }
			set
			{
				m_Set4Visibility = value;
				RaisePropertyChanged(nameof(Set4Visibility));
			}
		}

		private Visibility m_Set5Visibility;

		public Visibility Set5Visibility
		{
			get { return m_Set5Visibility; }
			set
			{
				m_Set5Visibility = value;
				RaisePropertyChanged(nameof(Set5Visibility));
			}
		}

		private Visibility m_TeamScoreVisibility;

		public Visibility TeamScoreVisibility
		{
			get { return m_TeamScoreVisibility; }
			set
			{
				m_TeamScoreVisibility = value;
				RaisePropertyChanged(nameof(TeamScoreVisibility));
			}
		}

		private Visibility m_GroupScoreVisibility;

		public Visibility GroupScoreVisibility
		{
			get { return m_GroupScoreVisibility; }
			set
			{
				m_GroupScoreVisibility = value;
				RaisePropertyChanged(nameof(GroupScoreVisibility));
			}
		}
		#endregion
	}
}
