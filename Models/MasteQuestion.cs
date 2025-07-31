using System;
using System.Collections.Generic;

namespace multipleChoice.Models;

public partial class MasteQuestion
{
    public int QuestionIdpk { get; set; }

    public string? QuestionLanguage { get; set; }

    public string? QuestionText { get; set; }

    public string? QuestionOptionA { get; set; }

    public string? QuestionOptionB { get; set; }

    public string? QuestionOptionC { get; set; }

    public string? QuestionOptionD { get; set; }

    public string? QuestionCorrectOption { get; set; }

    public string? Status { get; set; }

    public int? CreatIdfk { get; set; }

    public DateTime? CreatDt { get; set; }

    public int? ModiIdfk { get; set; }

    public DateTime? ModiDt { get; set; }
}
