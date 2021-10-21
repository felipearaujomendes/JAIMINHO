using System;
using System.ComponentModel.DataAnnotations;

namespace Jaiminho.API.ViewModels
{
    public class EmailViewModel
    {
        
        public Guid ID { get; set; }
        public string Assunto { get; set; }
        public string Nome { get; set; }
        public string Mensagem { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Remetente { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Destinatario { get; set; }

    }
    
}
