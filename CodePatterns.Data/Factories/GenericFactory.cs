using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Factories
{
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
