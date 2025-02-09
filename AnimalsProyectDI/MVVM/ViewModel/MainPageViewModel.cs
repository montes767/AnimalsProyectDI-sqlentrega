using AnimalsProyectDI.MVVM.Model;
using AnimalsProyectDI.MVVM.View;
using Bogus;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Input;

namespace AnimalsProyectDI.MVVM.ViewModel;

[AddINotifyPropertyChangedInterface]

public class MainPageViewModel
{
    //private readonly HttpClient _client = new HttpClient();

    //private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    //private const String _url = "https://6784c8c21ec630ca33a59e7d.mockapi.io";
    public ObservableCollection<Animal> Animals { get; set; } = new ObservableCollection<Animal>();

    public Animal? CurrentAnimal { get; set; }

    public MainPageViewModel()
    {
        CurrentAnimal = generateNewAnimal();
        refresh();
    }

    public Animal generateNewAnimal()
    {
        var animal = new Faker<Animal>().RuleFor(c => c.Name, f => f.Person.FirstName)
            .RuleFor(c => c.Phone, f => f.Person.Phone)
            .RuleFor(c => c.Avatar, f => f.PickRandom(new string[]{ "https://fakeimg.pl/300x200/?text=serrallo", "https://fakeimg.pl/300x200/?text=sotrondio", "https://fakeimg.pl/300x200/?text=mieres" }))
            .Generate();

        return animal;
    }


    public void refresh() { 

        Animals.Clear();
        // var customersdb = App.CustomerRepository.GetAll(c => c.Name.StartsWith("V"));
        var customersdb = App.AnimalRepository.GetAll();

        customersdb!.ForEach(c => Animals.Add(c));
        CurrentAnimal = generateNewAnimal();

        //var url = $"{_url}/animal";
        //var response = await _client.GetAsync(url);
        //if (response.IsSuccessStatusCode)
        //{
        //    using (var read = await response.Content.ReadAsStreamAsync())
        //    {
        //        var data = JsonSerializer.Deserialize<ObservableCollection<Animal>>(read, _serializerOptions);
        //        if (data != null)
        //        {
        //            Animals = data;
        //        }
        //    }

        //}
    }

    public ICommand AddAnimalCommand => new Command(async () =>
    {

        App.AnimalRepository.Save(CurrentAnimal!);
        //App.OrderRepository.Save(new Order { CustomerID = currentCustomer.Id, OrderDate = DateTime.Now });
        //var orders = App.OrderRepository.GetAll();
        
        refresh();
        CurrentAnimal = generateNewAnimal();

        //var url = $"{_url}/animal/";

        ////var animal = new Animal()
        ////{
        ////    Name = "griselda",
        ////    Gender = "female",
        ////    Type = "horse",
        ////    Phone = "34 556 765 87",
        ////    Avatar = "https://fakeimg.pl/300x200/?text=serrallo"
        ////};


        //Animals.Add(CurrentAnimal);

        //var json = JsonSerializer.Serialize(CurrentAnimal, _serializerOptions);

        //StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //HttpResponseMessage response = await _client!.PostAsync(url, content);



    });

    


    public ICommand DeleteSelectedCommand => new Command( () =>
    {
        App.AnimalRepository.Delete(CurrentAnimal);

        refresh();


        //if (CurrentAnimal != null)
        //{
        //    var animal = CurrentAnimal;
        //    Animals.Remove(CurrentAnimal);

        //    var url = $"{_url}/animal/{animal.Id}";

        //    HttpResponseMessage response = await _client!.DeleteAsync(url);
        //    CurrentAnimal = null;
        //}
        //else
        //{
        //    var animal = Animals[new Random().Next(Animals.Count())];
        //    Animals.Remove(animal);
        //    var url = $"{_url}/animal/{animal.Id}";

        //    HttpResponseMessage response = await _client!.DeleteAsync(url);
        //}
    });


    public ICommand UpdateAnimalCommand => new Command(async () =>
    {
        //if (Animals.Count <= 0)
        //{
        //    Console.WriteLine("No hay ningun animal en la lista");
        //}
        //else
        //{
        //    var animal = CurrentAnimal;

            
            
        //    Animals.Add(animal);

        //    var url = $"{_url}/animal/{animal.Id}";

            



        //    var json = JsonSerializer.Serialize(animal, _serializerOptions);

        //    StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = await _client!.PutAsync(url, content);
        //}


    });


    //public ICommand DeleteAnimalCommand => new Command(async () =>
    //{
        


    //    if (Animals.Count <= 0)
    //    {
    //        await DisplayAlert("Alert", "Tienes que añadir los datos de los animales a la lista", "OK");
    //    }
    //    else
    //    {
    //        var animal = Animals[new Random().Next(Animals.Count())];
    //        Animals.Remove(animal);
    //        var url = $"{_url}/animal/{animal.Id}";

    //        HttpResponseMessage response = await _client!.DeleteAsync(url);
    //    }


    //});
  

}