namespace Marine.Services
{
    public class SmtpConfig
    {
        #region props
        /// <summary>
        /// smtp.server
        /// </summary>
        public string server { get; set; }
        /// <summary>
        /// port for conec app
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// email from send
        /// </summary>
        public string sendEmail { get; set; }
        /// <summary>
        /// user or nick make
        /// </summary>
        public string senderEmail { get; set; }
        /// <summary>
        /// mail address
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// pasdworn emial account
        /// </summary>
        public string Password { get; set; }
        #endregion
    }
}
