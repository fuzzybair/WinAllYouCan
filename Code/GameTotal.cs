using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAllYouCan.Code
{
	class GameTotal : INotifyPropertyChanged
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

		private int? m_Side1Set1;

		public int? Side1Set1
		{
			get { return m_Side1Set1; }
			set
			{
				m_Side1Set1 = value;
				RaisePropertyChanged(nameof(Side1Set1));
			}
		}

		private int? m_Side2Set1;

		public int? Side2Set1
		{
			get { return m_Side2Set1; }
			set
			{
				m_Side2Set1 = value;
				RaisePropertyChanged(nameof(Side2Set1));
			}
		}

		private int? m_Side1Set2;

		public int? Side1Set2
		{
			get { return m_Side1Set2; }
			set
			{
				m_Side1Set2 = value;
				RaisePropertyChanged(nameof(Side1Set2));
			}
		}

		private int? m_Side2Set2;

		public int? Side2Set2
		{
			get { return m_Side2Set2; }
			set
			{
				m_Side2Set2 = value;
				RaisePropertyChanged(nameof(Side2Set2));
			}
		}

		private int? m_Side1Set3;

		public int? Side1Set3
		{
			get { return m_Side1Set3; }
			set
			{
				m_Side1Set3 = value;
				RaisePropertyChanged(nameof(Side1Set3));
			}
		}

		private int? m_Side2Set3;

		public int? Side2Set3
		{
			get { return m_Side2Set3; }
			set
			{
				m_Side2Set3 = value;
				RaisePropertyChanged(nameof(Side2Set3));
			}
		}

		private int? m_Side1Final;

		public int? Side1Final
		{
			get { return m_Side1Final; }
			set
			{
				m_Side1Final = value;
				RaisePropertyChanged(nameof(Side1Final));
			}
		}

		private int? m_Side2Final;

		public int? Side2Final
		{
			get { return m_Side2Final; }
			set
			{
				m_Side2Final = value;
				RaisePropertyChanged(nameof(Side2Final));
			}
		}

		private int? m_CurrentGroupScore;

		public int? CurrentGroupScore
		{
			get { return m_CurrentGroupScore; }
			set
			{
				m_CurrentGroupScore = value;
				RaisePropertyChanged(nameof(CurrentGroupScore));
			}
		}

		private int? m_CurrentSide1Score;

		public int? CurrentSide1Score
		{
			get { return m_CurrentSide1Score; }
			set
			{
				m_CurrentSide1Score = value;
				RaisePropertyChanged(nameof(CurrentSide1Score));
			}
		}

		private int? m_CurrentSide2Score;

		public int? CurrentSide2Score
		{
			get { return m_CurrentSide2Score; }
			set
			{
				m_CurrentSide2Score = value;
				RaisePropertyChanged(nameof(CurrentSide2Score));
			}
		}

		public void UpdateValues(IList<ScoreRound> roundScores)
		{
			Side1Set1 = roundScores.Take(3).SelectMany(t => t.Values.Take(4)).Sum();
			Side2Set1 = roundScores.Take(3).SelectMany(t => t.Values.Skip(4).Take(4)).Sum();
			Side1Set2 = roundScores.Take(6).SelectMany(t => t.Values.Take(4)).Sum();
			Side2Set2 = roundScores.Take(6).SelectMany(t => t.Values.Skip(4).Take(4)).Sum();

			Side1Set3 = roundScores.Take(9).SelectMany(t => t.Values.Take(4)).Sum();
			Side2Set3 = roundScores.Take(9).SelectMany(t => t.Values.Skip(4).Take(4)).Sum();
			Side1Final = roundScores.Take(10).SelectMany(t => t.Values.Take(4)).Sum();
			Side2Final = roundScores.Take(10).SelectMany(t => t.Values.Skip(4).Take(4)).Sum();

			CurrentSide1Score = roundScores.SelectMany(t => t.Values.Take(4)).Sum();
			CurrentSide2Score = roundScores.SelectMany(t => t.Values.Skip(4).Take(4)).Sum();
			CurrentGroupScore = roundScores.SelectMany(t => t.Values).Sum();
		}
	}
}