namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class TableGetAllResponse
{
	#region Properties
	/// <summary>
	/// Contains table list when system and filters found information on database, otherwise return an empty array
	/// </summary>
	public required List<TableDto> Tables { get; set; }
	#endregion
}