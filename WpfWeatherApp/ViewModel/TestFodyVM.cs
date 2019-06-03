using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWeatherApp.Model;
using WpfWeatherApp.ViewModel.Commands;

namespace WpfWeatherApp.ViewModel
{
    class TestFodyVM
    {
        public Test TestModel { get; set; }

        public UpdateTestCommand UpdateCommand { get; set; }

        public TestFodyVM()
        {
            TestModel = new Test()
            {
                FamilyName = "family name",
                GivenNames = "given names",
            };

            UpdateCommand = new UpdateTestCommand(this);
        }
    }
}
