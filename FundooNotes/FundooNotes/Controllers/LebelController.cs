using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LebelController : ControllerBase
    {
        FundooContext fundooContext;
        ILebelBL lebelBL;
        public LebelController(FundooContext fundooContext, ILebelBL lebelBL)
        {
            this.fundooContext = fundooContext;
            this.lebelBL = lebelBL;
        }
        [Authorize]
        [HttpPost("CreateLebel")]
        public async Task<ActionResult> CreateLabel(int NoteId, string LabelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var result = fundooContext.Note.FirstOrDefault(u => u.NoteId == NoteId);

                if (result == null)
                {
                    return this.BadRequest(new { success = false, message = $"Note Does not Exist, Please Create a Note" });
                }
                var result2 = fundooContext.Label.FirstOrDefault(u => u.NoteId == NoteId && u.UserId == userId);
                if (result2 != null)
                {
                    return this.BadRequest(new { success = false, message = $"Label Name Already Exist, Please select diffrent note/user" });
                }
                await this.lebelBL.CreateLebel(userId, NoteId,LabelName);
                return this.Ok(new { success = true, message = $"Label Name Added Successful" });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpDelete("DeleteLabel")]
        public async Task<ActionResult> RemoveCollab(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var lebel = fundooContext.Note.FirstOrDefault(u => u.UserId == userId && u.NoteId == NoteId);
                if (lebel == null)
                {
                    return this.BadRequest(new { success = false, message = "Unable to retrieve Delete lebel." });
                }
                await this.lebelBL.DeleteLabel(userId, NoteId);
                return this.Ok(new { success = true, message = $"lebel detete Successfully" });

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
