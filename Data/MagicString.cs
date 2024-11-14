using System;

namespace ClinicApi.Data;

public class MagicString
{
    public string[] entityTypeList;
    public string[] personNationalIdTypeList;
    public string[] userTypeList;
    // public int[] gradeList;
    public MagicString()
    {
        entityTypeList = ["داخلي", "خارجي"];
        userTypeList = ["رئيسي", "فرعي"];
        personNationalIdTypeList = ["المملكة العربية السعودية", "سوريا", "مصر", "الأردن"];
        // for (int i = 0; i <= 15; i++)
        // {
        //     gradeList[i] = i;
        // }
    }
}
