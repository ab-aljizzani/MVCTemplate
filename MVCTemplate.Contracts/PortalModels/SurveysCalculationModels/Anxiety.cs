using System;
using System.ComponentModel.DataAnnotations;

namespace MVCTemplatePortal.Models.SurveysCalculationModels;

public class Anxiety
{
    public readonly int survTypeId = 3;
    [Display(Name = "مجموع الكلي")]
    public int AllTotal { get; set; }
}
