using API.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models{
    public class Notification{

        public Notification(Guid id, ETypeNotification tipo, string mensagem, string emailDestinatario,
            string numDestinatario, string emailOrigem, string assunto, string cliente, string nomeUsuario)
        {
            Id = id;
            Tipo = tipo;
            Mensagem = mensagem;
            EmailDestinatario = emailDestinatario;
            NumDestinatario = numDestinatario;
            EmailOrigem = emailOrigem;
            Assunto = assunto;
            Cliente = cliente;
            NomeUsuario = nomeUsuario;
        }

        [Key]
        [Column("id")]
        public Guid Id { get; private set; }

        [Column("tipo")]
        public ETypeNotification Tipo { get; private set; }

        [Column("mensagem")]
        public string Mensagem { get; private set; }

        [Column("email_destinatario")]
        public string EmailDestinatario { get; private set; }

        [Column("num_destinatario")]
        public string NumDestinatario { get; private set; }

        [Column("email_origem")]
        public string EmailOrigem { get; private set; }

        [Column("assunto")]
        public string Assunto { get; private set; }

        [Column("cliente")]
        public string Cliente { get; private set; }

        [Column("nome_usuario")]
        public string NomeUsuario { get; private set; }

        public void Modify(ETypeNotification tipo, string mensagem, string emailDestinatario,
            string numDestinatario, string emailOrigem, string assunto, string cliente, string nomeUsuario)
        {
            Tipo = tipo;
            Mensagem = mensagem;
            EmailDestinatario = emailDestinatario;
            NumDestinatario = numDestinatario;
            EmailOrigem = emailOrigem;
            Assunto = assunto;
            Cliente = cliente;
            NomeUsuario = nomeUsuario;
        }
    }
}