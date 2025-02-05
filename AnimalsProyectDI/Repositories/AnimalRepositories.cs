using AnimalsProyectDI.Abstractions;
using AnimalsProyectDI.MVVM.Model;
using Microsoft.VisualBasic;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsProyectDI.Repositories
{
    public class AnimalRepositories<T> : IBaseRepository<T> where T : TableData, new()
    {

        private static SQLiteConnection _connection;

        static AnimalRepositories()
        {
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.flags);
        }

        public string StatusMessage { get; set; } = string.Empty;

        public AnimalRepositories()
        {
            _connection.CreateTable<T>();
            _connection.CreateTable<Animal>();
        }



        public void Delete(T item, bool recursive = true)
        {
            try
            {
                _connection.Delete(item, recursive);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }


        public void Dispose()
        {
            _connection.Close();
        }

        public List<T> GetAll()
        {

            return _connection.GetAllWithChildren<T>();

        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {

            return _connection.Table<T>().Where(predicate).ToList();

        }

        public T GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return _connection.Table<T>().Where(predicate).FirstOrDefault();

        }

        public T GetById(int id)
        {
            return _connection.Table<T>().FirstOrDefault(x => x.Id == id);
        }

       

        public void Save(T item)
        {
            try
            {
                if (item.Id == 0)
                {
                    int rows = _connection.Insert(item);
                    StatusMessage = $"Added: {rows}";
                }
                else
                {
                    int rows = _connection.Update(item);
                    StatusMessage = $"Updated: {rows}";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex}";

            }
        }

        
    }
}
