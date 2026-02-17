using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.RoleDto;

namespace ClinicApi.Services.AuthorizeServices.Rules
{
    public class RulesClasses
    {
    }
    public class EntityExternalOnlyRule : IFilterRule<GetEntityDto>
    {
        public bool Apply(GetEntityDto item, string role)
        {
            if (role == "Admin")
                return item.EntityType == "خارجي";

            return true;
        }
    }
    public class EntityEnternalOnlyRule : IFilterRule<GetEntityDto>
    {
        public bool Apply(GetEntityDto item, string role)
        {
            if (role == "Admin" || role == "SuperAdmin" )
                return item.EntityType == "داخلي";

            return true;
        }
    }
    public class DepartmentOfficerRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            if (role == "Admin")
                return item.DepartmentName.Contains("ضابط اتصال");

            return true;
        }
    }
    public class PortalRolesRule : IFilterRule<RoleDto>
    {
        public bool Apply(RoleDto item, string role)
        {
            if (role == "Admin")
                return (item.Roletype == "Portal" && item.RoleName != "Person")
                       || item.RoleName == "EntityContact";

            return true;
        }
    }
    public class PortalRuleOnly : IFilterRule<RoleDto>
    {
        public bool Apply(RoleDto item, string role)
        {
            if (role == "Admin")
                return (item.Roletype == "Portal");
            return true;
        }
    }
}
