namespace Tibas.Application.Auth.Queries;
public class TokenResponseVM
{
    public string Token { get; set; }

    public string Error { get; set; } 
    public int ErrorCode { get; set; }
}
