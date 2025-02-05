using AnimalsProyectDI.MVVM.Model;
using AnimalsProyectDI.MVVM.ViewModel;
using Bogus;

namespace AnimalsProyectDI.MVVM.View;

public partial class MainPageView : ContentPage
{
    private MainPageViewModel _viewModel = new MainPageViewModel();
    public MainPageView()
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }

    
}