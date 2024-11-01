namespace ORC.CenterPoint.API.Core.Enums;

public enum OperationStateEnum
{
    [EnumMember(Value = "Ok")]
    Ok = 200,

    [EnumMember(Value = "Created")]
    Created = 201,

    [EnumMember(Value = "NoContent")]
    NoContent = 204,

    [EnumMember(Value = "BadRequest")]
    BadRequest = 400,

    [EnumMember(Value = "Unauthorized")]
    Unauthorized = 401,

    [EnumMember(Value = "NotFound")]
    NotFound = 404,

    [EnumMember(Value = "UnprocessableEntity")]
    UnprocessableEntity = 422,

    [EnumMember(Value = "InternalServerError")]
    InternalServerError = 500,
}