using Microsoft.AspNetCore.Mvc;
using NewAPIDemo.DAL;
using NewAPIDemo.Models;

namespace NewAPIDemo.BAL
{
    public class User_BALBase
    {

        #region Method : API_User_SelectAll

        public List<UserModel> API_User_SelectAll()
        {
            try
            {
                User_DALBase user_DAL = new User_DALBase();
                List<UserModel> userModels = user_DAL.API_User_SelectAll();
                return userModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in BAL");
                return null;
            }
        }

        #endregion

        #region Method : API_User_SelectByPK

        public UserModel API_User_SelectByPK(int UserID)
        {
            try
            {
                User_DALBase user_DAL = new User_DALBase();
                UserModel model = user_DAL.API_User_SelectByPK(UserID);
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in BAL");
                return null;
            }
        }
        #endregion

        #region Method : API_User_DeleteByPK

        public bool API_User_DeleteByPK(int UserID)
        {
            try
            {
                User_DALBase user_DAL = new User_DALBase();
                if (user_DAL.API_User_DeleteByPK(UserID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Method : API_User_Insert

        public bool API_User_Insert(UserModel model)
        {
            try
            {
                User_DALBase user_DAL = new User_DALBase();
                if (user_DAL.API_User_Insert(model))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Method : API_User_UpdateByPK

        public bool API_User_UpdateByPK(int UserID, UserModel model)
        {
            try
            {
                User_DALBase user_DAL = new User_DALBase();
                if (user_DAL.API_User_UpdateByPK(UserID, model))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Method : API_User_ComboBox

        public List<UserDropDownModel> API_User_ComboBox()
        {
            try
            {
                User_DALBase user_DAL = new User_DALBase();
                List<UserDropDownModel> userModels = user_DAL.API_User_ComboBox();
                return userModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in BAL");
                return null;
            }
        }

        #endregion

        #region Method : API_User_Filter

        public List<UserModel> API_User_Filter(string? username, string? firstname, string? lastname, string? email)
        {
            try
            {
                User_DALBase user_DAL = new User_DALBase();
                List<UserModel> userModels = user_DAL.API_User_Filter(username, firstname, lastname, email);
                return userModels;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
