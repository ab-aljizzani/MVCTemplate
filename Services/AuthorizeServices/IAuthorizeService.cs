using MVCTemplate.Models.AuthorizeModel;

namespace MVCTemplate.Services.AuthorizeServices
{
    public interface IAuthorizeService
    {
        IEnumerable<T> Filter<T>(IEnumerable<T> list, string role);
        bool IsAuthorized(
           IAuthorizeModel model,
           string role,
           int[] statusEqual = null,
           int[] statusNotEqual = null,
           bool? important = null,
           bool? emergency = null,
           bool? owner = null,
           int? ownerId = null,
           string reviewRole = null,
           int? minStatusOrder = null,
           string typeRole = null
       );

    }
}
