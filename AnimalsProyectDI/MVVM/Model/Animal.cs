using AnimalsProyectDI.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace AnimalsProyectDI.MVVM.Model
{
    [Table("Animals")]
    public class Animal : TableData
    {
        [Column("name"), Indexed]
        public string Name { get; set; } = string.Empty;
        [Column("avatar")]
        public string Avatar { get; set; } = string.Empty;
        [Column("phone"), MaxLength(15)]
        public string Phone { get; set; } = string.Empty;

        
      

        //public string Avatar
        //{
        //    get => _avatar;
        //    set
        //    {
        //        if (_avatar != value)
        //        {
        //            _avatar = value;
        //            OnPropertyChanged(nameof(Avatar));
        //        }
        //    }
        //}

        //public string Type
        //{
        //    get => _type;
        //    set
        //    {
        //        if (_type != value)
        //        {
        //            _type = value;
        //            OnPropertyChanged(nameof(Type));
        //        }
        //    }
        //}

        //public string Name
        //{
        //    get => _name;
        //    set
        //    {
        //        if (_name != value)
        //        {
        //            _name = value;
        //            OnPropertyChanged(nameof(Name));
        //        }
        //    }
        //}

        //public string Gender
        //{
        //    get => _gender;
        //    set
        //    {
        //        if (_gender != value)
        //        {
        //            _gender = value;
        //            OnPropertyChanged(nameof(Gender));
        //        }
        //    }
        //}

        //public long Id
        //{
        //    get => _id;
        //    set
        //    {
        //        if (_id != value)
        //        {
        //            _id = value;
        //            OnPropertyChanged(nameof(Id));
        //        }
        //    }
        //}

        //public string Phone
        //{
        //    get=> _phone;
        //    set
        //    {
        //        if (_phone != value)
        //        {
        //            _phone = value;
        //            OnPropertyChanged(nameof(Phone));
        //        }
        //    }
        //}

        //public event PropertyChangedEventHandler? PropertyChanged;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
