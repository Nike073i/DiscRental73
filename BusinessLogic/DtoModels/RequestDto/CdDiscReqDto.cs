namespace BusinessLogic.DtoModels.RequestDto
{
    public class CdDiscReqDto : DiscReqDto
    {
        public string Performer { get; set; }
        public string Genre { get; set; }
        public int? NumberOfTracks { get; set; }
    }
}
