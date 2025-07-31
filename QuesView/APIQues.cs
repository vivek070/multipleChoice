namespace multipleChoice.QuesView
{
    public class APIQues
    {
        public class quesDetails
        {
            public string? QuestionText;
            public string? QuestionOptionA;

            public string? QuestionOptionB;

            public string? QuestionOptionC;

            public string? QuestionOptionD;

            public string? QuestionCorrectOption;
        }

        public void saveLogfile(string content, string filename)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\APIFiles", filename);

                File.WriteAllText(filePath, content);
            }
            catch { }
        }
    }
}
