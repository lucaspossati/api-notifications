

using api.Domain.Services.Interfaces;
using api.Domain.VM.Shared;
using api.Validator;
using API.Domain.Models;
using API.Domain.VM;
using API.ValueObjects;
using AutoMapper;
using Core.Validator;
using Data.Repository.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api.Domain.Services
{
    public class NotificationService: INotificationService
    {
        private readonly IMapper mapper;
        private readonly INotificationRepository notificationRepository;

        public NotificationService(IMapper mapper, INotificationRepository notificationRepository)
        {
            this.mapper = mapper;
            this.notificationRepository = notificationRepository;
        }

        public async Task<BaseResponse<List<NotificationVM>>> Get(ETypeNotification? filter)
        {
            var response = await notificationRepository.Get(filter);

            if (filter != null)
                response = response.Where(x => x.Tipo == filter.Value).ToList();

            var responseVM = mapper.Map<List<NotificationVM>>(response);

            return new BaseResponse<List<NotificationVM>>()
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Sucesso ao listar notificações",
                Success = true,
                Data = responseVM
            };
        }

        public async Task<BaseResponse<NotificationVM>> Get(Guid id)
        {
            var response = await notificationRepository.Get(id);

            if (response == null)
            {
                return new BaseResponse<NotificationVM>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Notificação não encontrada",
                    Success = false,
                    Data = null
                };
            }

            var responseVM = mapper.Map<NotificationVM>(response);

            return new BaseResponse<NotificationVM>()
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Sucesso ao obter notificação",
                Success = true,
                Data = responseVM
            };
        }

        public async Task<BaseResponse<NotificationVM>> Post(NotificationVM model)
        {
            var validator = new CreateNotificationValidator();

            ValidationResult results = validator.Validate(model);

            Validation.AddErrors(model, results);

            if (model.Errors != null)
            {
                return new BaseResponse<NotificationVM>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Erro ao criar notificação",
                    Success = false,
                    Data = model
                };
            }

            model.Id = Guid.NewGuid();

            var vmToModel = mapper.Map<Notification>(model);

            await notificationRepository.Post(vmToModel);

            return new BaseResponse<NotificationVM>()
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Sucesso ao criar notificação",
                Success = true,
                Data = model
            };
        }

        public async Task<BaseResponse<NotificationVM>> Put(NotificationVM model)
        {
            var validator = new CreateNotificationValidator();

            ValidationResult results = validator.Validate(model);

            Validation.AddErrors(model, results);

            if (model.Errors != null)
            {
                return new BaseResponse<NotificationVM>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Erro ao criar notificação",
                    Success = false,
                    Data = model
                };
            }

            var notification = await notificationRepository.Put(mapper.Map<Notification>(model));

            return new BaseResponse<NotificationVM>()
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Sucesso ao atualizar notificação",
                Success = true,
                Data = model
            };
        }

        public async Task<BaseResponse<object>> Delete(Guid id)
        {
            var notification = await notificationRepository.Get(id);

            if (notification == null)
            {
                return new BaseResponse<object>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Notificação não encontrada",
                    Success = false,
                    Data = null
                };
            }

            await notificationRepository.Delete(id);

            return new BaseResponse<object>()
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Sucesso ao excluir notificação",
                Success = true,
                Data = null
            };
        }
    }
}
