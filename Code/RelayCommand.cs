using System;

namespace WinAllYouCan.Code
{
	public class RelayCommand : System.Windows.Input.ICommand
	{
		private Action<object> execute;
		private Func<object, bool> canExecute;

		public event EventHandler CanExecuteChanged
		{
			add { System.Windows.Input.CommandManager.RequerySuggested += value; }
			remove { System.Windows.Input.CommandManager.RequerySuggested -= value; }
		}

		public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute)
		{
			this.execute = executeAction;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			execute(parameter);
		}
	}
}
