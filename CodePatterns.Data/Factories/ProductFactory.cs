using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Factories
{
    public interface IProductFactory
    {
        T CreateProduct<T>() where T : class, new();
    }
    public class ProductFactory : IProductFactory
    {
        public T CreateProduct<T>() where T : class, new() =>
            new T();
    }
}
