using Jaiminho.API.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Jaiminho.API.Services
{
    public class EmailService : IEmailService
    {
        private List<CredencialViewModel> _credencials { get; set; }
        public EmailService(List<CredencialViewModel> credencial)
        {
            _credencials = credencial;
        }
        public async Task<bool> SendMailAsync(EmailViewModel email)
        {
            var login = _credencials.Find(x => x.Id == email.ID).Login;
            var client = new SmtpClient()
            {
                Host = "mail.asocialmente.com.br",
                Port = 587,
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential(login.Usuario, Encoding.UTF8.GetString(Convert.FromBase64String(login.Senha))),
                EnableSsl = false
            };
            var template = RetornaTemplate(email);
            email.Mensagem = template.ToString();
            var message = new MailMessage(login.Usuario, email.Destinatario, email.Assunto, email.Mensagem) { IsBodyHtml=true};

            try
            {
                await client.SendMailAsync(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string RetornaTemplate(EmailViewModel email)
        {
            string path = "Template/Template.html";
            string html = "";
            string htmlFinal = "";
            if (File.Exists(path))
            {
                // Create a file to write to.
                html = File.ReadAllText(path);
                htmlFinal = ReplaceTemplate(html,email);
            }
            return htmlFinal;
        }

        public string ReplaceTemplate(string html,EmailViewModel email)
        {
            
            html = html.Replace("[NOME]", email.Nome);
            html = html.Replace("[EMAIL]", email.Remetente);
            html = html.Replace("[ASSUNTO]", email.Assunto);
            html = html.Replace("[MENSAGEM]", email.Mensagem);

            return html;
        }
    }
}
