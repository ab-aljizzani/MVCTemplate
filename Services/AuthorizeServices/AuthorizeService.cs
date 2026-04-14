using MVCTemplate.Models.AuthorizeModel;

namespace MVCTemplate.Services.AuthorizeServices
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly Dictionary<Type, List<object>> _rules = new();

        public AuthorizeService()
        {
            LoadRulesAutomatically();
        }

        // ---------------------------------------------------------
        // AUTO DISCOVERY OF RULES
        // ---------------------------------------------------------
        private void LoadRulesAutomatically()
        {
            var ruleTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t =>
                    !t.IsAbstract &&
                    !t.IsInterface &&
                    t.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IFilterRule<>)
                    )
                );

            foreach (var ruleType in ruleTypes)
            {
                var instance = Activator.CreateInstance(ruleType);

                var interfaceType = ruleType.GetInterfaces()
                    .First(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IFilterRule<>)
                    );

                var modelType = interfaceType.GetGenericArguments()[0];

                if (!_rules.ContainsKey(modelType))
                    _rules[modelType] = new List<object>();

                _rules[modelType].Add(instance);
            }
        }

        // ---------------------------------------------------------
        // MANUAL RULE REGISTRATION (OPTIONAL)
        // ---------------------------------------------------------
        public void AddRule<T>(IFilterRule<T> rule)
        {
            var type = typeof(T);

            if (!_rules.ContainsKey(type))
                _rules[type] = new List<object>();

            _rules[type].Add(rule);
        }

        // ---------------------------------------------------------
        // APPLY FILTER RULES
        // ---------------------------------------------------------
        public IEnumerable<T> Filter<T>(IEnumerable<T> list, string role)
        {
            if (list == null)
                return Enumerable.Empty<T>();

            var type = typeof(T);

            if (!_rules.ContainsKey(type))
                return list;

            var rules = _rules[type].Cast<IFilterRule<T>>().ToList();

            return list.Where(item => rules.All(r => r.Apply(item, role)));
        }

        // ---------------------------------------------------------
        // AUTHORIZATION LOGIC
        // ---------------------------------------------------------
        public bool IsAuthorized(
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
        )
        {
            // OWNER CHECK
            if (owner == true)
            {
                if (ownerId == null || model.PortalUserId != ownerId.Value)
                    return false;
            }

            // REVIEW ROLE CHECK
            if (!string.IsNullOrWhiteSpace(reviewRole))
            {
                if (!string.Equals(model.RoleName, reviewRole, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            // STATUS ORDER CHECK
            if (minStatusOrder.HasValue && model.StatusOrder < minStatusOrder.Value)
                return false;

            // TYPE ROLE CHECK
            if (!string.IsNullOrWhiteSpace(typeRole))
            {
                if (!string.Equals(model.TypeRole, typeRole, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }

    }

}
