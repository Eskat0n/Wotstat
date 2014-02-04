namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Annotations;
    using Domain.Model;

    public class AccountEntry
    {
        [Obsolete("Only for serializations")]
        [UsedImplicitly]
        public AccountEntry()
        {
        }

        public AccountEntry(Account account)
        {
            Name = account.Name;
            Token = account.Token;
            Id = account.Id;
        }

        public int Id { get; set; }
        public string Token { get; set; }

        public string Name { get; set; }

        public string Serialize()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof(AccountEntry));
                formatter.Serialize(stream, this);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static AccountEntry Deserialize(string value)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var formatter = new XmlSerializer(typeof(AccountEntry));
                return (AccountEntry)formatter.Deserialize(stream);
            }
        } 
    }
}