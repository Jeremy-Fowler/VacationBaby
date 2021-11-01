using System.Collections.Generic;

namespace VacationBaby.Interfaces
{
  public interface IVacation<T>
  {
    List<T> Get();
    T Get(int id);
    T Create(T data);
    T Edit(T data);
    void Delete(int id);
  }
}