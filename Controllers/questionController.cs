using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using multipleChoice.Models;
using multipleChoice.QuesView;
using Newtonsoft.Json;

using System.Data;
using System.Configuration;
using static multipleChoice.QuesView.APIQues;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace multipleChoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class questionController : ControllerBase
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AD2SV99;Initial Catalog=multipleChoiceDB;Persist Security Info=True;User ID=sa;Password=12345678;Trust Server Certificate=True;TrustServerCertificate=true;");

        SqlCommand cmd = null;
        // MultipleChoiceDbContext db;
      //  SqlConnection db = new SqlConnection(ConfigurationManager.

        // GET: api/<questionController>
        [HttpGet]
        public string GetQuestion()
        {
            string strJson = null;

            using (MultipleChoiceDbContext context = new MultipleChoiceDbContext())
            {
                var studData = context.VquestionViews
                                    .ToList();

                List<APIQues.quesDetails> quesdata = new List<APIQues.quesDetails>();
                foreach (var stud in studData)
                {
                    APIQues.quesDetails sClass = new APIQues.quesDetails();


                    sClass.QuestionText = stud.QuestionText;


                    sClass.QuestionOptionA = stud.QuestionOptionA;
                    sClass.QuestionOptionB = stud.QuestionOptionB;
                    sClass.QuestionOptionC = stud.QuestionOptionC;
                    sClass.QuestionOptionD = stud.QuestionOptionD;
                    sClass.QuestionCorrectOption = stud.QuestionCorrectOption;




                    quesdata.Add(sClass);
                }
                strJson = JsonConvert.SerializeObject(quesdata);

            }

            return strJson;
        }

        // GET api/<questionController>/5
        [HttpGet("{id}")]
        public string GetQuestion(int id)
        {
            string strJson = null;

            using (MultipleChoiceDbContext context = new MultipleChoiceDbContext())
            {
                var studData = context.MasteQuestions.Where(Q=>Q.QuestionIdpk==id)
                                    .ToList();

                List<APIQues.quesDetails> quesdata = new List<APIQues.quesDetails>();
                foreach (var stud in studData)
                {
                    APIQues.quesDetails sClass = new APIQues.quesDetails();


                    sClass.QuestionText = stud.QuestionText;


                    sClass.QuestionOptionA = stud.QuestionOptionA;
                    sClass.QuestionOptionB = stud.QuestionOptionB;
                    sClass.QuestionOptionC = stud.QuestionOptionC;
                    sClass.QuestionOptionD = stud.QuestionOptionD;
                    sClass.QuestionCorrectOption = stud.QuestionCorrectOption;




                    quesdata.Add(sClass);
                }
                strJson = JsonConvert.SerializeObject(quesdata);

            }

            return strJson;
        }

        // POST api/<questionController>
        [HttpPost]
        public void PostQuestion(VquestionView vquestion)
        {
            string Msg = "";
            try
            {
             
                if (con != null)
                {

                    if (vquestion != null)
                    {
                        string msg = "";
                        cmd = new SqlCommand("insertQuestion", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@QuestionText", vquestion.QuestionText);
                        cmd.Parameters.AddWithValue("@QuestionOptionA", vquestion.QuestionOptionA);
                        cmd.Parameters.AddWithValue("@QuestionOptionB", vquestion.QuestionOptionB);
                        cmd.Parameters.AddWithValue("@QuestionOptionC", vquestion.QuestionOptionC);
                        cmd.Parameters.AddWithValue("@QuestionOptionD", vquestion.QuestionOptionD);
                        cmd.Parameters.AddWithValue("@QuestionCorrectOption", vquestion.QuestionCorrectOption);
                        cmd.Parameters.AddWithValue("@QuestionLanguage", vquestion.QuestionLanguage);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();




                    }
                }
                else
                {
                    Msg = "database not connected";
                }
            }
            catch (Exception e)
            { }




            }

            // PUT api/<questionController>/5
            [HttpPut("{id}")]
        public void PutQuestion( int id,VquestionView vquestion)
        {

            string Msg = "";
            try
            {
                
                if (con != null)
                {

                    if (vquestion != null)
                    {
                        string msg = "";
                        cmd = new SqlCommand("UpdateQuestion", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@QuestionText", vquestion.QuestionText);
                        cmd.Parameters.AddWithValue("@QuestionOptionA", vquestion.QuestionOptionA);
                        cmd.Parameters.AddWithValue("@QuestionOptionB", vquestion.QuestionOptionB);
                        cmd.Parameters.AddWithValue("@QuestionOptionC", vquestion.QuestionOptionC);
                        cmd.Parameters.AddWithValue("@QuestionOptionD", vquestion.QuestionOptionD);
                        cmd.Parameters.AddWithValue("@QuestionCorrectOption", vquestion.QuestionCorrectOption);
                         cmd.Parameters.AddWithValue("@QuestionLanguage", vquestion.@QuestionLanguage);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();




                    }
                }
                else
                {
                    Msg = "database not connected";
                }
            }
            catch (Exception e)
            { }
        }

        // DELETE api/<questionController>/5
        [HttpDelete("{id}")]
        public async Task DeleteQuestion(int id)
        {
            string Msg = "";
            try
            {
              
                if (con != null)
                {

                    
                        cmd = new SqlCommand("deleteQuestion", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@id", id);
                       
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();




                  
                }
                else
                {
                    Msg = "database not connected";
                }
            }
            catch (Exception e)
            { 
            
            }
        }
    }
}
