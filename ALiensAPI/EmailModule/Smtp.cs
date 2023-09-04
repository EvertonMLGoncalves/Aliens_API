using APIALiens.DTOs;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIALiens.EmailModule
{
    public class Smtp : ISmtp
    {
        public async Task<string> SendEmail(EmailDTO emailDTO)
        {
            using var HttpClient = new HttpClient();
            try { 
                // URL do modulo de emails
                string url = "https://localhost:7043/api/Email";
                //convertendo emailDTO p/ json
                string jsonContent = JsonSerializer.Serialize(emailDTO);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"); 
                //fazendo o post
                HttpResponseMessage response = await HttpClient.PostAsync(url, content);
                //validações
                if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();
                else return response.StatusCode.ToString();
            } 
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
