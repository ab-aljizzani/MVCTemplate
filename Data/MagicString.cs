using System;

namespace ClinicApi.Data;

public class MagicString
{
    public string[] entityTypeList;
    public string[] personNationalIdTypeList;
    public string[] userTypeList;

    public readonly string LoginAttimptMessage = "لقد وصلت الحد الأعلى لعدد المحاولات الخاطئة لتسجيل الدخول تم تعطيل الحساب الرجاء التواصل مع مدير النظام";
    public readonly string InsertSuccess = "تمت الاضافة بنجاح";
    public MagicString()
    {
        entityTypeList = ["داخلي", "خارجي"];
        userTypeList = ["رئيسي", "فرعي"];
        personNationalIdTypeList = ["المملكة العربية السعودية", "سوريا", "مصر", "الأردن"];

    }
}
