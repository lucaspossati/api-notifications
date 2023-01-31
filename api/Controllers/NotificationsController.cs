using api.Domain.Services.Interfaces;
using api.Domain.VM.Shared;
using API.Domain.VM;
using API.ValueObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("v1/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController
        (
            INotificationService notificationService
        )
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<BaseResponse<List<NotificationVM>>> Get([FromQuery] ETypeNotification filter)
        {
            return await _notificationService.Get(filter);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<BaseResponse<NotificationVM>> Get([FromRoute] Guid id)
        {
            var response = await _notificationService.Get(id);
            return response;
        }

        [HttpPost]
        [Route("")]
        public async Task<BaseResponse<NotificationVM>> Post([FromBody] NotificationVM model)
        {
            return await _notificationService.Post(model);
        }

        [HttpPut]
        [Route("")]
        public async Task<BaseResponse<NotificationVM>> Put([FromBody] NotificationVM model)
        {
            return await _notificationService.Put(model);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<BaseResponse<object>> Delete([FromRoute] Guid id)
        {
            return await _notificationService.Delete(id);
        }
    }
}
