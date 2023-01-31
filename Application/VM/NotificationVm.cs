using api.Domain.VM.Shared;
using API.ValueObjects;
using System;

namespace API.Domain.VM{
    public class NotificationVM : BaseViewModel
    {
        public Guid? Id { get; set; }

        public ETypeNotification Tipo { get; set; }

        public string NomeTipo { get; private set; }

        public string Mensagem { get; set; }

        public string EmailDestinatario { get; set; }
        public string NumDestinatario { get; set; }

        public string EmailOrigem { get; set; }

        public string Assunto { get; set; }

        public string Cliente { get; set; }

        public string NomeUsuario { get; set; }
    }
}