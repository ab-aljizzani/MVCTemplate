using ClinicApi.Models.AuthorizeModel;

namespace ClinicApi.Services.AuthorizeServices
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly Dictionary<Type, List<object>> _rules = new();

        // Register rule
        public void AddRule<T>(IFilterRule<T> rule)
        {
            var type = typeof(T);

            if (!_rules.ContainsKey(type))
                _rules[type] = new List<object>();

            _rules[type].Add(rule);
        }

        // Apply all rules for a given type
        public IEnumerable<T> Filter<T>(IEnumerable<T> list, string role)
        {
            if (list == null)
                return Enumerable.Empty<T>();

            var type = typeof(T);

            if (!_rules.ContainsKey(type))
                return list; // No rules → return all

            var rules = _rules[type].Cast<IFilterRule<T>>().ToList();

            return list.Where(item => rules.All(r => r.Apply(item, role)));
        }

        public bool IsAuthorized(
            IAuthorizeModel model,
            string role,
            int[] statusEqual = null,
            int[] statusNotEqual = null,
            bool? important = null,
            bool? emergency = null,
            bool? owner = null,
            int? ownerId = null, string reviewRole = null, int? minStatusOrder = null ,string typeRole = null

)
        {
            // STATUS EQUAL
            //if (statusEqual != null && statusEqual.Length > 0)
            //    if (!statusEqual.Contains(model.RequestStatusId))
            //        return false;
            //if (statusEqual != null && statusEqual.Length > 0)
            //{
            //    if (statusEqual.Contains(model.RequestStatusId))
            //    {
            //        return true;
            //    }
            //    else
            //        return false;
            //}

            // STATUS NOT EQUAL
            //if (statusNotEqual != null && statusNotEqual.Length > 0)
            //    if (statusNotEqual.Contains(model.RequestStatusId))
            //        return false;

            //if (statusNotEqual != null && statusNotEqual.Length > 0)
            //{
            //    if (statusNotEqual.Contains(model.RequestStatusId))
            //    {
            //        return true;
            //    }
            //    else
            //        return false;
            //}

            // IMPORTANT
            //if (important.HasValue)
            //{
            //    if (important.Value == false)
            //        return false;

            //    else
            //        return true;
            //}

            // EMERGENCY
            //if (emergency.HasValue)
            //{
            //    if (emergency.Value == false)
            //        return false;

            //    else
            //        return true;
            //}

            // OWNER CHECK
            if (owner.HasValue && owner.Value == true)
            {
                if (ownerId == null)
                    return false;

                if (model.PortalUserId != ownerId.Value)
                    return false;
            }
            if (!string.IsNullOrWhiteSpace(reviewRole))
            {
                if (!string.Equals(model.RoleName, reviewRole, StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            if (minStatusOrder.HasValue)
            {
                if (model.StatusOrder < minStatusOrder.Value)
                    return false;
            }
            if (!string.IsNullOrWhiteSpace(typeRole))
            {
                if (!string.Equals(model.TypeRole, typeRole, StringComparison.OrdinalIgnoreCase))
                    return false;
            }




            return true;
        }
    }

}
