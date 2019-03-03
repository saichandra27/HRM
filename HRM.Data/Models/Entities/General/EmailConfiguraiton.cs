
namespace HRM.Data.Entities.General
{
    public class EmailConfiguraiton
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FromEmailAddress { get; set; }
        public string SendingMethod { get; set; }
        public string SMTPPort { get; set; }
        public string SMTPHost { get; set; }
        public bool SMTPAuthenticaiton { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPassword { get; set; }
        public SecureConnection SecureConnection { get; set; }
        public bool Sendtestemail { get; set; }
        public string testemailaddress { get; set; }
    }

    public enum SecureConnection
    {
        No = 1,
        SSL = 2,
        TLS = 3
    }
}
