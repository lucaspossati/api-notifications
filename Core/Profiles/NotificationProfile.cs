using API.Domain.Models;
using API.Domain.VM;
using AutoMapper;

namespace api.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationVM, Notification>();

            CreateMap<Notification, NotificationVM>()
                .ForMember(nvm => nvm.NomeTipo, options => options.MapFrom(n => n.Tipo.ToString()));
        }
    }
}
