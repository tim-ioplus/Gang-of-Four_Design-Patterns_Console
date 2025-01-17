using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pattern.Creational.Factory
{
    public interface IProduct
    {
        IProduct Create();
    }

    public class ProductA : IProduct
    {
        public string Name = "ProductA";
        public IProduct Create()
        {
            return new ProductA();
        }
    }

    public class ProductB : IProduct
    {
        public string Name = "ProductB";
        public IProduct Create()
        {
            return new ProductB();
        }
    }

    public abstract class AbstractProductFactory
    {
        public abstract IProduct Create(string selector);
    }

    public class ProductFactory : AbstractProductFactory
    {
        public override IProduct Create(string productType)
        {
            if (productType == "A")
            {
                return new ProductA();
            }
            else if (productType == "B")
            {
                return new ProductB();
            }
            else
            {
                return null;
            }
        }
    }

}
