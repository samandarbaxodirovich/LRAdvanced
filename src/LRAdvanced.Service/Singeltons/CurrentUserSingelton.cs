using LRAdvanced.Domain.Entities;
using LRAdvanced.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.Service.Singeltons
{
    public sealed class CurrentUserSingelton
    {
        public CurrentUserSingelton() { }
        public static RegisterDto _currentUser = null;

        public static RegisterDto Instance
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser == null)
                    _currentUser = value;
            }
        }
    }
}
