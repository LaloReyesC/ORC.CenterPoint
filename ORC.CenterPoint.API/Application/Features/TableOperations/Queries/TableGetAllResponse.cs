namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class TableGetAllResponse
{
	#region Properties
	public required List<TableDto> Tables { get; set; }
	#endregion
}