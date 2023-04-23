using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.Managers.Interfaces
{
    public interface IServiceProviderManager
    {
        T GetService<T>() where T : notnull;
    }
}
