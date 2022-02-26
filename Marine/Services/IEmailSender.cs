namespace Marine.Services
{
    /// <summary>
    /// interface del servicio para enviar emails
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// funcion que envia los correos
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task EmailSender(MailData data);

    }
}
