using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    public interface IDressModel : IProductModel
    {

    }
    public class DressModel : ProductModel, IDressModel
    {
    }
}
