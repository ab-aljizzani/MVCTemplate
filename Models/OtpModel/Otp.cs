using System;

namespace ClinicApi.Models.OtpModel;

public class Otp
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NationalId { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime SendTime { get; set; } = DateTime.Now;
    public bool IsDeliverd { get; set; } = false;


}
// public class HandelOtp
// {
//     private readonly HttpClient _client;

//     public HandelOtp(HttpClient client)
//     {
//         _client = client;
//     }
//     public void SendOtp(string content, string phoneNumber, string nationalID)
//     {
//         var opt = new Otp();
//         opt.NationalId = nationalID;
//         opt.PhoneNumber = phoneNumber;
//         opt.Content = content;

//         string data = JsonConvert.SerializeObject(request);
//         StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
//         HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "PortalUser/Login", content).Result;



//     }
// }