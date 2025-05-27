using System;

namespace cleanArch.Application.Wrappers;

public class SuccessResponse<T>
{
    public int Status { get; set; }
    public string Message { get; set; } = "Success";
    public T? Data { get; set; }

    public SuccessResponse(T data, string message = "Success", int status = 200)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    public SuccessResponse(string message = "Success", int status = 200)
    {
        Status = status;
        Message = message;
        Data = default;
    }
}
