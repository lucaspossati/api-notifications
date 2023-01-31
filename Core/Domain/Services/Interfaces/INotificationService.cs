using api.Domain.VM.Shared;
using API.Domain.Models;
using API.Domain.VM;
using API.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Domain.Services.Interfaces
{
    public interface INotificationService
    {
        public Task<BaseResponse<List<NotificationVM>>> Get(ETypeNotification? filter);
        public Task<BaseResponse<NotificationVM>> Get(Guid id);
        public Task<BaseResponse<NotificationVM>> Post(NotificationVM model);
        public Task<BaseResponse<NotificationVM>> Put(NotificationVM model);
        public Task<BaseResponse<object>> Delete(Guid id);
    }
}
