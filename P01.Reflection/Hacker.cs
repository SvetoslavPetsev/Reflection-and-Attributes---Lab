namespace Stealer
{
    public class Hacker
    {
        public string username = "secur82";
        private string password = "thebestpassword";

        public string Password 
        { 
            get => this.password; 
            set => this.password = value; 
        }

        private int ID { get; set; }
        public double bankAccountBalance { get; set; }

        public void DownloadAllBankAccount()
        { }
    }
}
