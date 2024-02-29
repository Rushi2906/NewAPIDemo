using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAPIDemo.BAL;
using NewAPIDemo.Models;

namespace NewAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {


        #region Method : GetAll

        [HttpGet]
        public IActionResult GetAllUser()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> user = bal.API_User_SelectAll();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (user.Count > 0 && user != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Method : GetByID

        [HttpGet("{UserID}")]
        public IActionResult Get(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            UserModel user = bal.API_User_SelectByPK(UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (user.UserID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Method : Delete

        [HttpDelete("{UserID}")]
        public IActionResult Delete(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            bool isSuccess = bal.API_User_DeleteByPK(UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (isSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                return NotFound(response);
            }
        }
        #endregion

        #region Method : Post

        [HttpPost]
        public IActionResult Post([FromForm] UserModel model)
        {
            User_BALBase bal = new User_BALBase();
            bool isSuccess = bal.API_User_Insert(model);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (isSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Added");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Something Wrong");
                return NotFound(response);
            }
        }
        #endregion

        #region Method : Put

        [HttpPut("{UserID}")]
        public IActionResult Put(int UserID, [FromForm] UserModel model)
        {
            User_BALBase bal = new User_BALBase();
            bool isSuccess = bal.API_User_UpdateByPK(UserID, model);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (isSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                return NotFound(response);
            }
        }
        #endregion

        #region Method : DropDown

        [HttpGet("GetUserByDropdown")]
        public IActionResult GetUserNameByDropdown()
        {
            User_BALBase bal = new User_BALBase();
            List<UserDropDownModel> user = bal.API_User_ComboBox();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (user.Count > 0 && user != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        #endregion

        #region Method : Filter

        [HttpGet("Filter")]
        public IActionResult UserFilter(string? username, string? firstname, string? lastname, string? email)
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> userModel = bal.API_User_Filter(username,firstname,lastname,email);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (userModel.Count>0 && userModel!=null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", userModel);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        #endregion

    }
}
