using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using NewAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace NewAPIDemo.DAL
{
    public class User_DALBase : DAL_Helper
    {

        #region Method : API_User_SelectAll
        public List<UserModel> API_User_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_MST_USER_SELECTALL");
                List<UserModel> list = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UserModel model = new UserModel();
                        model.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        model.UserName = dr["UserName"].ToString();
                        model.Password = dr["Password"].ToString();
                        model.ConfirmPassword = dr["ConfirmPassword"].ToString();
                        model.FirstName = dr["FirstName"].ToString();
                        model.LastName = dr["LastName"].ToString();
                        model.Email = dr["Email"].ToString();
                        list.Add(model);
                        Console.WriteLine(list);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("-Error-");
                return null;
            }
        }
        #endregion

        #region Method : API_User_SelectByPK

        public UserModel API_User_SelectByPK(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_USER_SELECTBYPK");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dr.Read();
                    userModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    userModel.UserName = dr["UserName"].ToString();
                    userModel.FirstName = dr["FirstName"].ToString();
                    userModel.LastName = dr["LastName"].ToString();
                    userModel.Email = dr["Email"].ToString();
                    userModel.Password = dr["Password"].ToString();
                    userModel.ConfirmPassword = dr["ConfirmPassword"].ToString();
                }
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method : API_User_DeleteByPK

        public bool API_User_DeleteByPK(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_USER_DELETEBYID");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception ex)
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
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_USER_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, model.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@FirstName", SqlDbType.VarChar, model.FirstName);
                sqlDatabase.AddInParameter(dbCommand, "@LastName", SqlDbType.VarChar, model.LastName);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, model.Password);
                sqlDatabase.AddInParameter(dbCommand, "@ConfirmPassword", SqlDbType.VarChar, model.ConfirmPassword);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, model.Email);

                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
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
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_USER_UPDATEBYPK");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, model.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@FirstName", SqlDbType.VarChar, model.FirstName);
                sqlDatabase.AddInParameter(dbCommand, "@LastName", SqlDbType.VarChar, model.LastName);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, model.Password);
                sqlDatabase.AddInParameter(dbCommand, "@ConfirmPassword", SqlDbType.VarChar, model.ConfirmPassword);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, model.Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
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
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_MST_USER_COMBOBOX");
                List<UserDropDownModel> list = new List<UserDropDownModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UserDropDownModel model = new UserDropDownModel();
                        model.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        model.UserName = dr["UserName"].ToString();
                        list.Add(model);
                    }
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Method : API_User_Filter

        public List<UserModel> API_User_Filter(string? username, string? firstname, string? lastname, string? email)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_MST_USER_FILTER");

                sqlDatabase.AddInParameter(cmd, "@UserName", SqlDbType.VarChar, username);


                sqlDatabase.AddInParameter(cmd, "@Email", SqlDbType.VarChar, email);


                sqlDatabase.AddInParameter(cmd, "@FirstName", SqlDbType.VarChar, firstname);


                sqlDatabase.AddInParameter(cmd, "@LastName", SqlDbType.VarChar, lastname);


                List<UserModel> list = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UserModel user = new UserModel();
                        user.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        user.UserName = dr["UserName"].ToString();
                        user.Password = dr["Password"].ToString();
                        user.ConfirmPassword = dr["ConfirmPassword"].ToString();
                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.Email = dr["Email"].ToString();
                        list.Add(user);
                        Console.WriteLine(list);
                    }
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
