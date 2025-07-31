using System;
using System.Collections.Generic;

namespace multipleChoice.Models;

public partial class VquestionView
{
    public string? QuestionText { get; set; }

    public string? QuestionOptionA { get; set; }

    public string? QuestionOptionB { get; set; }

    public string? QuestionOptionC { get; set; }

    public string? QuestionOptionD { get; set; }

    public string? QuestionCorrectOption { get; set; }

    public string? QuestionLanguage { get; set; }
}
