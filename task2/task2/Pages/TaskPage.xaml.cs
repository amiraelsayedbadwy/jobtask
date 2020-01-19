using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
            BindingContext = new TaskPageModel();
        }

      
    }
}