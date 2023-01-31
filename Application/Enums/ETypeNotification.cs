using System.ComponentModel;

namespace API.ValueObjects{
    public enum ETypeNotification
    {
        [Description("E-mail")]
        Email,
        [Description("Sms")]
        Sms,
    }
}