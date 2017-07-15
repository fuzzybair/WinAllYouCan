using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinAllYouCan.Code
{
	public class ScoreBoardRowModel : INotifyPropertyChanged
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

		internal List<Team> Teams { get; set; }

		private ScoreBoard m_ScoreBoardValues;

		internal ScoreBoard ScoreBoardValues
		{
			get { return m_ScoreBoardValues; }
			set
			{
				m_ScoreBoardValues = value;
				RaisePropertyChanged(nameof(ScoreBoardValues));
			}
		}
	}
}