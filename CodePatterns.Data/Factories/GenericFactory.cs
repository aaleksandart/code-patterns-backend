using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Factories
{
    /// <summary>
    /// SRP: GenericFactory hanterar bara skapande av objekt.
    /// 
    /// DIP: Eftersom vi använder vår factory för att skapa
    /// konkreta objekt/instanser.
    /// </summary>
    public interface IGenericFactory
    {
        T CreateGeneric<T>() where T : class, new();
    }
    public class GenericFactory : IGenericFactory
    {
        public T CreateGeneric<T>() where T : class, new() =>
            new T();
    }
}
