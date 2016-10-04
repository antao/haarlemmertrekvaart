using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haarlemmertrekvaart.Clients;

namespace Haarlemmertrekvaart.Services
{
    public class DepartureService
    {
        private readonly NsClient _nsClient;

        public DepartureService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }
    }
}
