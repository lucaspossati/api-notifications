using API.Domain.Models;
using API.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface INotificationRepository
    {
        Task<List<Notification>> Get(ETypeNotification? filter);

        Task<Notification> Get(Guid id);

        Task<Notification> Post(Notification model);

        Task<Notification> Put(Notification model);

        Task Delete(Guid id);
    }
}
