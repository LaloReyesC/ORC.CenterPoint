namespace ORC.CenterPoint.API.Routers;

public class ConnectionRoute : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(TestConnection);
    }

    #region Private members
    public IResult TestConnection() => Results.Ok(new ConnectionResponse
    {
        Message = "Connection test successfully!!!"
    });
    #endregion
}