namespace ClinicApi.Models.AuthorizeModel
{
    public interface IAuthorizeModel
    {
        int RequestStatusId { get; }
        bool IsImportant { get; }
        bool isEmergency { get; }
        bool IsPersonShowUp { get; }
        int PortalUserId { get; }
        string RoleName { get; set; }
        public int StatusOrder { get; set; }
        public string TypeRole { get; set; }
    }
}
