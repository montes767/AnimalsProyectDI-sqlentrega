using AnimalsProyectDI.Abstractions;
using AnimalsProyectDI.MVVM.Model;
using AnimalsProyectDI.MVVM.View;

namespace AnimalsProyectDI
{
    public partial class App : Application
    {
        public static IBaseRepository<Animal> AnimalRepository { get; set; }

     
        public App(IBaseRepository<Animal> cr)
        {
            InitializeComponent();


            AnimalRepository = cr;


            MainPage = new MainPageView();
        }
    }
}
