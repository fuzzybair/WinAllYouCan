using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAllYouCan.Code
{
	class ScoreRoundTotals : INotifyPropertyChanged
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
		public ScoreRoundTotals()
		{
			Values = new ObservableCollection<int?>() { null, null, null, null, null, null, null, null };
		}

		public ObservableCollection<int?> Values { get; set; }

		public void UpdateValues(IEnumerable<ScoreRound> roundValues, ScoreRoundTotals lastRound = null)
		{
			if (roundValues.Any(v => v.Values[0].HasValue))
				Values[0] = roundValues.Sum(v => v.Values?[0]) + (lastRound?.Values?[0] ?? 0);
			if (roundValues.Any(v => v.Values[1].HasValue))
				Values[1] = roundValues.Sum(v => v.Values?[1]) + (lastRound?.Values?[1] ?? 0);
			if (roundValues.Any(v => v.Values[2].HasValue))
				Values[2] = roundValues.Sum(v => v.Values?[2]) + (lastRound?.Values?[2] ?? 0);
			if (roundValues.Any(v => v.Values[3].HasValue))
				Values[3] = roundValues.Sum(v => v.Values?[3]) + (lastRound?.Values?[3] ?? 0);
			if (roundValues.Any(v => v.Values[4].HasValue))
				Values[4] = roundValues.Sum(v => v.Values?[4]) + (lastRound?.Values?[4] ?? 0);
			if (roundValues.Any(v => v.Values[5].HasValue))
				Values[5] = roundValues.Sum(v => v.Values?[5]) + (lastRound?.Values?[5] ?? 0);
			if (roundValues.Any(v => v.Values[6].HasValue))
				Values[6] = roundValues.Sum(v => v.Values?[6]) + (lastRound?.Values?[6] ?? 0);
			if (roundValues.Any(v => v.Values[7].HasValue))
				Values[7] = roundValues.Sum(v => v.Values?[7]) + (lastRound?.Values?[7] ?? 0);
		}
	}
}
