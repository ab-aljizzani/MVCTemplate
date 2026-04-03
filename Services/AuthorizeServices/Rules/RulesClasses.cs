using ClinicApi.Dtos.ApoointmentReviewDto.Get;
using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.DoctorAvailbleTimeDto;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.RequestDto.Get;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.SurveyDto.Get;

namespace ClinicApi.Services.AuthorizeServices.Rules
{
    public class RulesClasses
    {
    }
    //--------------------EntityController-------------------------
    public class EntityExternalOnlyForNonSuperAdminRule : IFilterRule<GetEntityDto>
    {
        public bool Apply(GetEntityDto item, string role)
        {
            if (role != "SuperAdmin")
                return item.EntityType == "خارجي";

            return true;
        }
    }
    //--------------------EDR--------------------------------------------
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
    //--------------------AppointmentController-------------------------
    public class UserSurveyListByTypeRoleRule : IFilterRule<GetUserSurveyListDto>
    {
        public bool Apply(GetUserSurveyListDto item, string typeRole)
        {
            if (string.IsNullOrWhiteSpace(typeRole))
                return true;

            return string.Equals(
                item.SurveyType.TypeRole,
                typeRole,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }

    public class SurveyTypeByTypeRoleRule : IFilterRule<GetSurveyTypeDto>
    {
        public bool Apply(GetSurveyTypeDto item, string typeRole)
        {
            if (string.IsNullOrWhiteSpace(typeRole))
                return true;

            return string.Equals(
                item.TypeRole,
                typeRole,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }
    public class SurveyTypeByTypeRoleRuleTest : IFilterRule<GetUserSurveyListDto>
    {
        public bool Apply(GetUserSurveyListDto item, string typeRole)
        {
            if (string.IsNullOrWhiteSpace(typeRole))
                return true;

            return string.Equals(
                item.SurveyType.TypeRole,
                typeRole,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }
    public class SpecialistReviewRule : IFilterRule<GetCustomAppointmentReivewDto>
    {
        public bool Apply(GetCustomAppointmentReivewDto item, string role)
        {
            if (role == "Specialist")
                return string.Equals(item.RoleName, "Specialist", StringComparison.OrdinalIgnoreCase);

            return true;
        }
    }
    public class UserAnswerBySurveyTypeRule : IFilterRule<GetUserSurveyAnswerDto>
    {
        public bool Apply(GetUserSurveyAnswerDto item, string surveyTypeId)
        {
            if (string.IsNullOrWhiteSpace(surveyTypeId))
                return true;

            // تحويل surveyTypeId إلى int إذا كان نوعه int
            if (int.TryParse(surveyTypeId, out int id))
                return item.SurveyTypeId == id;

            return true;
        }
    }
    //--------------------PersonController-------------------------
    public class PersonDepartmentEntityRule : IFilterRule<PersonDto>
    {
        public bool Apply(PersonDto item, string role)
        {
            // إذا المستخدم DeptAdmin أو DeptEditor → فلترة حسب القسم والجهة
            if (role == "DeptAdmin" || role == "DeptEditor")
            {
                // نقرأ deptId و entityId من الـ HttpContext أو Token
                var http = new HttpContextAccessor().HttpContext;
                var deptId = http.Request.Query["deptId"].ToString();
                var entityId = http.Request.Query["entityId"].ToString();

                if (int.TryParse(deptId, out int d) && int.TryParse(entityId, out int e))
                    return item.DepartmentId == d && item.EntityId == e;
            }

            // SuperAdmin و Admin → يشوفون كل شيء
            return true;
        }
    }
    public class PersonSearchRule : IFilterRule<PersonDto>
    {
        public bool Apply(PersonDto item, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            return
                (item.NationalIdType?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.NationalId?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.FullArabicName?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.FullEnglishName?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.JobTitle?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.Department?.DepartmentName?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.Entity?.EntityName?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.Grade?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.Title?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (item.Zone?.ZoneName?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
public class ExcludeOfficerContactDepartmentRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            // استبعاد أي قسم يحتوي اسمه على "ضابط اتصال"
            return !item.DepartmentName.Contains("ضابط اتصال", StringComparison.OrdinalIgnoreCase);
        }
    }

    //--------------------ProfileController-------------------------
    public class CheckTimeByUserRule : IFilterRule<GetDoctorAvailbleTimeDto>
    {
        public bool Apply(GetDoctorAvailbleTimeDto item, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return true;

            if (!int.TryParse(userId, out int id))
                return true;

            return item.PortalUserId == id && item.IsActive == true;
        }
    }

    public class DoctorIsActiveRule : IFilterRule<GetDoctorAvailbleTimeDto>
    {
        public bool Apply(GetDoctorAvailbleTimeDto item, string role)
        {
            // نرجّع فقط الأطباء المفعّلين
            return item.IsActive == true;
        }
    }
    //--------------------RequestController-------------------------
    public class RequestOrderByStatusRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string role)
        {
            // هذا Rule لا يفلتر، فقط يسمح بمرور كل العناصر
            return true;
        }
    }
    public class RequestStatusRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string statusId)
        {
            if (string.IsNullOrWhiteSpace(statusId))
                return true;

            if (!int.TryParse(statusId, out int id))
                return true;

            return item.RequestStatusId == id;
        }
    }
    public class RequestEntityRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string entityId)
        {
            if (string.IsNullOrWhiteSpace(entityId))
                return true;

            if (!int.TryParse(entityId, out int id))
                return true;

            return item.EntityId == id;
        }
    }
    public class RequestRiskLevelRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string riskLevel)
        {
            if (string.IsNullOrWhiteSpace(riskLevel))
                return true;

            if (!int.TryParse(riskLevel, out int id))
                return true;

            return item.Appointment?.RiskLevelId == id;
        }
    }
    public class RequestSearchRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            return
                item.Id.ToString().Contains(search) ||
                item.Person?.NationalId?.Contains(search) == true ||
                item.Person?.FullArabicName?.Contains(search) == true ||
                item.RequestType?.Type?.Contains(search) == true;
        }
    }
    public class PersonLookupRule : IFilterRule<PersonDto>
    {
        public bool Apply(PersonDto item, string parameters)
        {
            // parameters = "role|nationalId|deptId"
            var parts = parameters.Split('|');
            var role = parts[0];
            var nationalId = parts[1];
            var deptId = parts[2];

            // SuperAdmin & Admin → يبحث فقط بالـ NationalId
            if (role == "SuperAdmin" || role == "Admin")
                return item.NationalId == nationalId;

            // غير ذلك → NationalId + DepartmentId
            if (int.TryParse(deptId, out int d))
                return item.NationalId == nationalId && item.DepartmentId == d;

            return false;
        }
    }
    public class RequestByPersonRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string personId)
        {
            if (!int.TryParse(personId, out int id))
                return true;

            return item.PersonId == id;
        }
    }
    public class RequestStatusBlockRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string role)
        {
            // إذا أي طلب StatusId < 6 → نمنع
            return item.RequestStatusId >= 6;
        }
    }
    public class DoctorRoleFilterRule : IFilterRule<PortalUserDto>
    {
        public bool Apply(PortalUserDto item, string role)
        {
            return item.Role?.RoleName == "Doctor"
                || item.Role?.RoleName == "Specialist";
        }
    }
    public class DoctorTimeByUserAndDateRule : IFilterRule<AppointmentDto>
    {
        public bool Apply(AppointmentDto item, string parameters)
        {
            // parameters = "docId|date"
            var parts = parameters.Split('|');
            var docId = parts[0];
            var date = parts[1];

            if (!int.TryParse(docId, out int id))
                return true;

            return item.PortalUserId == id
                && item.ApponitmentDate == date;
        }
    }
    public class AllowAppointmentUpdateRule : IFilterRule<PortalUserDto>
    {
        public bool Apply(PortalUserDto item, string role)
        {
            return role == "SuperAdmin"
                || role == "Admin"
                || role == "Reception";
        }
    }
    public class DeptAdminPhoneRule : IFilterRule<PortalUserDto>
    {
        public bool Apply(PortalUserDto item, string deptId)
        {
            if (!int.TryParse(deptId, out int id))
                return false;

            return item.DepartmentId == id
                && item.Role?.RoleName == "DeptAdmin";
        }
    }
    public class EntityContactPhoneRule : IFilterRule<PortalUserDto>
    {
        public bool Apply(PortalUserDto item, string entityId)
        {
            if (!int.TryParse(entityId, out int id))
                return false;

            return item.EntityId == id
                && item.Role?.RoleName == "EntityContact";
        }
    }
    //--------------------------SurveyController-------------------------
    public class SurveyTypeVisibilityRule : IFilterRule<GetSurveyTypeDto>
    {
        public bool Apply(GetSurveyTypeDto item, string role)
        {
            if (role == "SuperAdmin")
                return true;

            return item.Id != 1;
        }
    }
    public class SurveyTypeSearchRule : IFilterRule<GetSurveyTypeDto>
    {
        public bool Apply(GetSurveyTypeDto item, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            return item.Type.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
    //--------------------------AccountController-------------------------
    public class UserSuperAdminRule : IFilterRule<PortalUserDto>
    {
        public bool Apply(PortalUserDto item, string role)
        {
            return role == "SuperAdmin" ? true : true;
            // SuperAdmin sees all, Admin filtered by next rule
        }
    }
    public class UserAdminRoleTypeRule : IFilterRule<PortalUserDto>
    {
        public bool Apply(PortalUserDto item, string role)
        {
            if (role != "Admin")
                return true;

            return item.Role?.Roletype == "Portal" || item.Role?.Roletype == "Dash";
        }
    }
    public class UserSearchRule : IFilterRule<PortalUserDto>
    {
        public bool Apply(PortalUserDto item, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            return
                item.UserFullName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                item.Username.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                item.Status.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                item.Department?.DepartmentName.Contains(search, StringComparison.OrdinalIgnoreCase) == true ||
                item.Entity?.EntityName.Contains(search, StringComparison.OrdinalIgnoreCase) == true ||
                item.NationalId.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
    public class DepartmentAdminRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            if (role != "Admin")
                return true;

            return item.DepartmentName.Contains("ضابط اتصال");
        }
    }
    public class DepartmentHideOfficerRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            if (role == "EntityContact" || role == "DeptAdmin")
                return !item.DepartmentName.Contains("ضابط اتصال");

            return true;
        }
    }
    //--------------------------CommingRequestAndNotAttendRequestViewCompoController-------------------------
    public class RequestStatusOrderRule : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string statusOrder)
        {
            if (!int.TryParse(statusOrder, out int order))
                return true;

            return item.RequestStatus?.StatusOrder == order;
        }
    }
    public class RequestSearchRuleForComming : IFilterRule<GetRequestDto>
    {
        public bool Apply(GetRequestDto item, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            return
                item.Person?.NationalId.Contains(search) == true ||
                item.Person?.FullArabicName.Contains(search) == true ||
                item.RequestStatus?.Status.Contains(search) == true;
        }
    }
    //--------------------------DeptController-------------------------
    public class DepartmentSuperAdminRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            return true; // SuperAdmin sees all
        }
    }
    public class DepartmentAdminRuleForDept : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            if (role != "Admin")
                return true;

            return !item.DepartmentName.Contains("ضابط اتصال")
                   && item.Entity?.EntityType == "خارجي";
        }
    }
    public class DepartmentEntityContactRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            if (role == "EntityContact" || role == "DeptAdmin")
                return !item.DepartmentName.Contains("ضابط اتصال");

            return true;
        }
    }
    public class DepartmentSearchRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            return
                item.DepartmentName.Contains(search) ||
                item.Entity?.EntityName.Contains(search) == true ||
                item.Entity?.EntityType.Contains(search) == true;
        }
    }
    public class AllowDeptEntityAccessRule : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string role)
        {
            // SuperAdmin & Admin → يشوفون كل شيء
            if (role == "SuperAdmin" || role == "Admin")
                return true;

            // غيرهم → لا يشوفون شيء من GetDeptEntity
            return false;
        }
    }
    public class DepartmentSearchRuleForDeptTableviewCom : IFilterRule<DepartmentDto>
    {
        public bool Apply(DepartmentDto item, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            return item.DepartmentName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
    //--------------------------EntityViewComController-------------------------
    public class EntityVisibilityRule : IFilterRule<GetEntityDto>
    {
        public bool Apply(GetEntityDto item, string role)
        {
            // SuperAdmin sees everything
            if (role == "SuperAdmin")
                return true;

            // Others see only external entities
            return item.EntityType == "خارجي";
        }
    }
    //--------------------------NewRequestViewComController-------------------------
    public class PersonSuperAdminRule : IFilterRule<PersonDto>
    {
        public bool Apply(PersonDto item, string role)
        {
            return true; // SuperAdmin sees everything
        }
    }
    public class PersonAdminRule : IFilterRule<PersonDto>
    {
        public bool Apply(PersonDto item, string parameters)
        {
            var parts = parameters.Split('|');
            var role = parts[0];
            var entityId = int.Parse(parts[1]);

            if (role != "Admin")
                return true;

            return item.EntityId == entityId;
        }
    }
    public class PersonDeptRule : IFilterRule<PersonDto>
    {
        public bool Apply(PersonDto item, string parameters)
        {
            var parts = parameters.Split('|');
            var role = parts[0];
            var entityId = int.Parse(parts[1]);
            var deptId = int.Parse(parts[2]);

            if (role != "DeptAdmin" && role != "DeptEditor")
                return true;

            return item.EntityId == entityId && item.DepartmentId == deptId;
        }
    }
    //--------------------------NotAttendRequestViewComController-------------------------

}
