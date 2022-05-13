namespace BusinessLogic.DtoModels.ResponseDto
{
    public class CdDiscResDto : DiscResDto
    {
        public string Performer { get; set; }
        public string? Genre { get; set; }
        public int? NumberOfTracks { get; set; }
    }
}
