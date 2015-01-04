using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstFloor.ModernUI.App.Infrastructure
{
    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _executeAction;

        private bool _canExecuteCache;

        public DelegateCommand(Action executeAction, Func<bool> canExecute)
        {
            _executeAction = executeAction;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action executeAction)
        {
            _executeAction = executeAction;
            _canExecute = DefaultCanExecute;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            bool temp = _canExecute();

            if (_canExecuteCache != temp)
            {
                _canExecuteCache = temp;
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, new EventArgs());
                }
            }
            return _canExecuteCache;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeAction();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        #endregion

        private static bool DefaultCanExecute()
        {
            return true;
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _executeAction;

        private bool _canExecuteCache;

        public DelegateCommand(Action<T> executeAction, Func<T, bool> canExecute)
        {
            _executeAction = executeAction;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action<T> executeAction)
        {
            _executeAction = executeAction;
            _canExecute = DefaultCanExecute;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            bool temp = _canExecute((T)parameter);

            if (_canExecuteCache != temp)
            {
                _canExecuteCache = temp;
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, new EventArgs());
                }
            }

            return _canExecuteCache;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeAction((T)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        #endregion

        private static bool DefaultCanExecute(T ignored)
        {
            return true;
        }
    }
}