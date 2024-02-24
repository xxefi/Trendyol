 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services.Interfaces
{
    public interface IDataService
    {
        public void SendData<T>(T data) where T : IData;    
        
    }
}
