using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WinAllYouCan.Views;

namespace WinAllYouCan.Code
{
	class ApplicationModel : System.ComponentModel.INotifyPropertyChanged
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
		private bool m_Test;
		public ApplicationModel()
		{
			Round = 1;
			Score = new RelayCommand(ScoreRound, CanScoreRound);
			Teams = new List<Team>
			{
				new Team { Name = "Team 1" },
				new Team { Name = "Team 2" },
				new Team { Name = "Team 3" },
				new Team { Name = "Team 4" },
				new Team { Name = "Team 5" },
				new Team { Name = "Team 6" },
				new Team { Name = "Team 7" },
				new Team { Name = "Team 8" },
			};
			ScoreBoardValues = new ScoreBoard();

			m_Test = ConfigurationSettings.Get<bool>(Setting.TestMode);

			m_ScoreBoardWindow = new Views.ScoreBoard
			{
				DataContext = this
			};

			//mainWindow.ContentRendered += (object sender, EventArgs e) =>
			//{
			//	m_ScoreBoardWindow.Show();
			//};

			//mainWindow.Closing += (object sender, System.ComponentModel.CancelEventArgs e) =>
			//{
			//	m_ScoreBoardWindow?.Close();
			//};

			if (m_Test)
			{
				Teams.ForEach(t => t.Choice = TeamChoice.Bead);
			}
			SetUiVisibility();
		}
		public uint RowHeight
		{
			get
			{
				return ConfigurationSettings.Get<uint>(Setting.RowHeight);
			}
		}

		public uint TotalRowHeight
		{
			get
			{
				return ConfigurationSettings.Get<uint>(Setting.TotalRowHeight);
			}
		}
		public uint HeadingRowHeight
		{
			get
			{
				return ConfigurationSettings.Get<uint>(Setting.HeadingRowHeight);
			}
		}
		

		internal void ShowScoreBoard(object sender, MainWindow mainWindow)
		{
			m_ScoreBoardWindow.Show();
		}

		internal void EditRound(object sender, Window parent)
		{
			EditRound editRoundWindow = new EditRound
			{
				Owner = parent,
				DataContext = new MangeRounds((int index) =>
				{
					System.Collections.ObjectModel.ObservableCollection<Team> t = new System.Collections.ObjectModel.ObservableCollection<Team>();
					for (int i = 0; i < 8; i++)
					{
						t.Add(new Team
						{
							Choice = ScoreBoardValues.Scores[index].Choices[i],
							Name = Teams[i].Name
						});
					}
					return t;
				},
				(newChoices, index) =>
				{
					ScoreBoardValues.Scores[index].Choices = newChoices;
					ScoreBoardValues.UpdateTotals();
				})
				{
					RoundIndexes = new System.Collections.ObjectModel.ObservableCollection<int>(Enumerable.Range(1, Round - 1))
				},
				// Automatically resize height and width relative to content
				SizeToContent = SizeToContent.WidthAndHeight,
			};
			editRoundWindow.ShowDialog();
		}

		internal void EditTeamNames(object sender, Window parent)
		{
			EditTeams editTeamWindow = new EditTeams
			{
				Owner = parent,
				//DataContext = Teams //I don't know how to bind a window to a list
				DataContext = this,
				// Automatically resize height and width relative to content
				SizeToContent = SizeToContent.WidthAndHeight,
			};
			editTeamWindow.ShowDialog();
		}

		private Window m_ScoreBoardWindow;

		ICommand Score { get; set; }

		private int m_Round;

		public int Round
		{
			get { return m_Round; }
			set
			{
				m_Round = value;
				RaisePropertyChanged(nameof(Round));
			}
		}

		private ScoreBoard m_ScoreBoardValues;

		public ScoreBoard ScoreBoardValues
		{
			get { return m_ScoreBoardValues; }
			set
			{
				m_ScoreBoardValues = value;
				RaisePropertyChanged(nameof(ScoreBoardValues));
			}
		}


		public List<Team> Teams { get; set; }

		public void ScoreRound(object obj)
		{
			ScoreBoardValues.Scores[Round - 1].Choices = Teams.Select(t => t.Choice.Value).ToArray();
			ScoreBoardValues.UpdateTotals();
			Teams.ForEach(t => t.Choice = null);
			if (m_Test)
			{
				Teams.ForEach(t => t.Choice = TeamChoice.Bead);
			}
			Round++;
			SetUiVisibility();
		}
		private void SetUiVisibility()
		{
			ScoreBoardValues.Set2Visibility = (Round > ConfigurationSettings.Get<int>(Setting.ShowSet2AfterRound)) ? Visibility.Visible : Visibility.Hidden;
			ScoreBoardValues.Set3Visibility = (Round > ConfigurationSettings.Get<int>(Setting.ShowSet3AfterRound)) ? Visibility.Visible : Visibility.Hidden;
			ScoreBoardValues.Set4Visibility = (Round > ConfigurationSettings.Get<int>(Setting.ShowSet4AfterRound)) ? Visibility.Visible : Visibility.Hidden;
			ScoreBoardValues.Set5Visibility = (Round > ConfigurationSettings.Get<int>(Setting.ShowSet5AfterRound)) ? Visibility.Visible : Visibility.Hidden;
			ScoreBoardValues.TeamScoreVisibility = (Round > ConfigurationSettings.Get<int>(Setting.ShowTeamScoreAfterRound)) ? Visibility.Visible : Visibility.Hidden;
			ScoreBoardValues.GroupScoreVisibility = (Round > ConfigurationSettings.Get<int>(Setting.ShowGroupScoreAfterRound)) ? Visibility.Visible : Visibility.Hidden;
		}
		public bool CanScoreRound(object arg)
		{
			return Round <= 10 && Teams.All(t => t.Choice.HasValue);
		}
	}
}
