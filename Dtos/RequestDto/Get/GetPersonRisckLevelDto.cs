namespace ClinicApi.Dtos.RequestDto.Get
{
    public class GetPersonRisckLevelDto
    {
        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public string? ApponitmentDate { get; set; }
        public string? RiskLevel { get; set; }
    }
}
