using ToDoApplication.Domain.Enum;

namespace ToDoApplication.Domain.Response;

public class BaseResponse<ResBodyType> : IBaseResponse<ResBodyType>
{
    public string Description { get; set; }
    
    public StatusCode StatusCode { get; set; }
    
    public ResBodyType Data { get; set; }
}

public interface IBaseResponse<ResBodyType>
{
    string Description { get; }
    
    StatusCode StatusCode { get; }
    
    ResBodyType Data { get; }
}