using API.Data;
using API.Domain.Models;
using API.ValueObjects;
using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class NotificationsRepository : INotificationRepository
    {
        private readonly DataContext context;

        public NotificationsRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Notification>> Get(ETypeNotification? filter)
        {
            var response = await context.Notifications.ToListAsync();

            if (filter != null)
                response = response.Where(x => x.Tipo == filter.Value).ToList();

            return response;
        }

        public async Task<Notification> Get(Guid id)
        {
            return await context.Notifications.FindAsync(id);
        }

        public async Task<Notification> Post(Notification model)
        {
            context.Notifications.Add(model);

            await context.SaveChangesAsync();

            return model;
        }

        public async Task<Notification> Put(Notification model)
        {
            context.Entry(model).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(Guid id)
        {
            var notification = await context.Notifications.FindAsync(id);

            context.Notifications.Remove(notification);

            await context.SaveChangesAsync();
        }
    }
}
