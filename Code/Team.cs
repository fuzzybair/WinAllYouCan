using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WinAllYouCan.Code
{
	class Team : System.ComponentModel.INotifyPropertyChanged
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

		public Team()
		{
			Name = string.Empty;
		}
		public string AxeColor
		{
			get { return ConfigurationSettings.Get<string>(Setting.AxeColor); }
		}
		public string BeadColor
		{
			get { return ConfigurationSettings.Get<string>(Setting.BeadColor); }
		}

		private string m_Name;

		public string Name
		{
			get { return m_Name; }
			set
			{
				m_Name = value;
				RaisePropertyChanged(nameof(Name));
			}
		}
		private TeamChoice? m_Choice;

		public TeamChoice? Choice
		{
			get { return m_Choice; }
			set
			{
				m_Choice = value;
				RaisePropertyChanged(nameof(Choice));
			}
		}
	}
}
