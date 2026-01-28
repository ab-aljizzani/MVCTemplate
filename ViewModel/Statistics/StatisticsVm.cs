namespace ClinicApi.ViewModel.Statistics
{

    public class DoctorStatisticsVm
    {
        public int Id { get; set; }
        public string DoctorName { get; set; } = "";
        public string DoctorRole { get; set; } = "";
        public RequestVm? Request { get; set; }
    }

    public class RequestVm
    {
        public List<int> Ids { get; set; } = new();
        public int AllRequestCount { get; set; }
        public List<RequestStatusVm> RequestStatus { get; set; } = new();
    }

    public class RequestStatusVm
    {
        public int RequestId { get; set; }
        public string Status { get; set; } = "";
    }
}
