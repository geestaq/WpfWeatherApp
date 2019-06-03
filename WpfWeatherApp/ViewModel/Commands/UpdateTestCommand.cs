using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfWeatherApp.ViewModel.Commands
{
    class UpdateTestCommand : ICommand
    {
        public TestFodyVM VM { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                //podpiecie pod zdarzenie z wpf gdzie bedzie sprawdzany warunek czy mozna wykonac execute
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public UpdateTestCommand(TestFodyVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {

            if (VM.TestModel.FullName.Contains("dupa"))
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            VM.TestModel.FamilyName = "family runtime";
            VM.TestModel.GivenNames = "given runtime";
        }
    }
}
