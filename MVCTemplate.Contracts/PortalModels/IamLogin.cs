using System;

namespace MVCTemplatePortal.Models;

public class IamLogin
{
    public string userName { get; set; } = string.Empty;
    public string userPass { get; set; } = string.Empty;
}
public class IamLoginErrorRes
{
    public string ResponseDate { get; set; } = string.Empty;
    public string ResponseDetail { get; set; } = string.Empty;
    public string ResponseStatus { get; set; } = string.Empty;
    public string errorMessage { get; set; } = string.Empty;
    public string errorCode { get; set; } = string.Empty;
}
public class IamLoginSuccessRes
{
    public string AuthMsg { get; set; } = string.Empty;
    public string AuthURL { get; set; } = string.Empty;
    public string AuthURLExpire { get; set; } = string.Empty;

    public string otpMessage { get; set; } = string.Empty;
    public string optURL { get; set; } = string.Empty;
    public string otpExp { get; set; } = string.Empty;

}
public class IamOTP
{
    public string codeOTP { get; set; } = string.Empty;
}
public class IamOTPRes
{
    public string userFullName { get; set; } = string.Empty;
    public string userNo { get; set; } = string.Empty;
    public string tokenKey { get; set; } = string.Empty;
    public string fullName { get; set; } = string.Empty;
    public string userName { get; set; } = string.Empty;
    public string orgName { get; set; } = string.Empty;
    public string userType { get; set; } = string.Empty;
    public string tokenDate { get; set; } = string.Empty;
    public string tokenExp { get; set; } = string.Empty;
}
