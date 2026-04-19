using System;
using System.ComponentModel.DataAnnotations;

namespace MVCTemplatePortal.Models.SurveysCalculationModels;

public class Scale
{
    public readonly int survTypeId = 2;
    [Display(Name = "درجة العدوان الجسدي")]
    public int physicalAggression { get; set; }
    [Display(Name = "درجة العدوان اللفظي")]
    public int verbalAggression { get; set; }
    [Display(Name = "درجة العداء")]
    public int aggressive { get; set; }
    [Display(Name = "درجة الغضب")]
    public int anger { get; set; }
    [Display(Name = "مجموع الكلي")]
    public int AllTotal { get; set; }
}
