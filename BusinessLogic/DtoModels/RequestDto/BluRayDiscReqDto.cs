namespace BusinessLogic.DtoModels.RequestDto
{
    public class BluRayDiscReqDto : DiscReqDto
    {
        public string Publisher { get; set; }
        public string? Info { get; set; }
        public string? SystemRequirements { get; set; }
    }
}
