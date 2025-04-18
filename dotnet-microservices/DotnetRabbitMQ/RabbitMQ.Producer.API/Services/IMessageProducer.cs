using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Producer.API.Services
{
    public interface IMessageProducer
    {
        public void SendingMessages<T>(T message);
    }
}