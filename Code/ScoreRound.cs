using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAllYouCan.Code
{
	public class ScoreRound : INotifyPropertyChanged
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

		public ScoreRound()
		{
			Choices = new TeamChoice[8];
			Values = new ObservableCollection<int?> { null, null, null, null, null, null, null, null };
		}

		private int m_Multiplier;

		public int Multiplier
		{
			get { return m_Multiplier; }
			set
			{
				m_Multiplier = value;
				RaisePropertyChanged(nameof(Multiplier));
			}
		}
		private TeamChoice[] m_Choices;

		public TeamChoice[] Choices
		{
			get { return m_Choices; }
			set
			{
				m_Choices = value;
				Values = GetValues();
				RaisePropertyChanged(nameof(Choices));
			}
		}

		private ObservableCollection<int?> GetValues()
		{
			int bead1Value;
			int axe1Value;
			int bead2Value;
			int axe2Value;
			IEnumerable<TeamChoice> side1 = Choices.Take(4);
			IEnumerable<TeamChoice> side2 = Choices.Skip(4).Take(4);
			GetScores(side1, out bead1Value, out axe1Value);
			GetScores(side2, out bead2Value, out axe2Value);
			List<int?> values = new List<int?>();

			foreach (TeamChoice choice in side1)
			{
				values.Add((choice == TeamChoice.Bead) ? bead1Value : axe1Value);
			}
			foreach (TeamChoice choice in side2)
			{
				values.Add((choice == TeamChoice.Bead) ? bead2Value : axe2Value);
			}
			return new ObservableCollection<int?>(values);
		}

		private void GetScores(IEnumerable<TeamChoice> choices, out int beadValue, out int axeValue)
		{
			switch (choices.Count(c => c == TeamChoice.Bead))
			{
				case 0:
					beadValue = 0;
					axeValue = -50;
					break;
				case 1:
					beadValue = -300;
					axeValue = 100;
					break;
				case 2:
					beadValue = -200;
					axeValue = 200;
					break;
				case 3:
					beadValue = -100;
					axeValue = 300;
					break;
				case 4:
					beadValue = 50;
					axeValue = 0;
					break;
				default:
					beadValue = 0;
					axeValue = 0;
					break;
			}
			axeValue *= Multiplier;
			beadValue *= Multiplier;
		}

		private ObservableCollection<int?> m_Values;

		public ObservableCollection<int?> Values
		{
			get { return m_Values; }
			set
			{
				m_Values = value;
				RaisePropertyChanged(nameof(Values));
			}
		}

	}
}
