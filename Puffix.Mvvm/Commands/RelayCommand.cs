using System;
using System.Windows.Input;


namespace Puffix.Mvvm.Commands
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other
    /// objects by invoking delegates. The default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    public class RelayCommand<ArgumentT> : ICommand
    {
        /// <summary>
        /// Predicat pour tester si la commande peut être executée.
        /// </summary>
        private readonly Predicate<ArgumentT> canExecute;

        /// <summary>
        /// Action pour l'exécution de la commande.
        /// </summary>
        private readonly Action<ArgumentT> execute;

        /// <summary>
        /// Evènement pour les changements d'états pour l'exécution de la commande.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="execute">Action à exécuter.</param>
        public RelayCommand(Action<ArgumentT> execute)
            : this(execute, null)
        { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="execute">Action à exécuter.</param>
        /// <param name="canExecute">Predicat pour tester si la commande peut être exécutée.</param>
        public RelayCommand(Action<ArgumentT> execute, Predicate<ArgumentT> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Emission de l'evènement de detection des changements d'états pour l'exécution de la commande.
        /// </summary>
        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Teste si la commande peut être exécutée.
        /// </summary>
        /// <param name="parameter">Paramètre.</param>
        /// <returns>Résultat.</returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((ArgumentT)parameter);
        }

        /// <summary>
        /// Execution de la méthode.
        /// </summary>
        /// <param name="parameter">Paramètre.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                execute?.Invoke((ArgumentT)parameter);
        }
    }

    /// <summary>
    /// Commande pour l'execution de code à partir d'une action XAML.
    /// </summary>
    /// <remarks>Le code est dupliqué car WinRT gère très mal les librairies externes.</remarks>
    public sealed class RelayCommand : RelayCommand<object>, ICommand
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="execute">Action à exécuter.</param>
        public RelayCommand(Action<object> execute)
            : base(execute, null)
        { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="execute">Action à exécuter.</param>
        /// <param name="canExecute">Predicat pour tester si la commande peut être exécutée.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            : base(execute, canExecute)
        { }
    }
}
