using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace dotnetChatAppServer.DataService
{
    public class SharedDb
    {
        private readonly ConcurrentDictionary<string, UserConnction> _connections = new();

        public ConcurrentDictionary<string, UserConnction>  connections => _connections;
    }
}