using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Messages;
using Trendyol.Models;
using Trendyol.Services.Interfaces;

namespace Trendyol.Services.Classes
{
    public class DataService : IDataService
    {
        private readonly IMessenger _messenger;

        private Dictionary<Type, Delegate> _data = new Dictionary<Type, Delegate>();

        public DataService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void SendData<T>(T data) where T : IData
        {
            _messenger.Send(new DataMessage()
            {
                Data = data
            });
        }
    }
}
