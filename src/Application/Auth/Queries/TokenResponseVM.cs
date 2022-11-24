namespace Tibas.Application.Auth.Queries;
public class TokenResponseVM
{ 
    public string Error { get; set; } 
    public int ErrorCode { get; set; } 
    public UserDto User { get; set; }
}
