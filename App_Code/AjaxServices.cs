﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for AjaxServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AjaxServices : System.Web.Services.WebService
{

    public AjaxServices()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //--------------------------------------------------------------------------
    // Gets a user from the database by the user id provided
    //--------------------------------------------------------------------------
    public string GetUserById(int Id)
    {
            User user = new User().GetUserById(Id);
        
        try
        {            
            JavaScriptSerializer js = new JavaScriptSerializer();
            user.GetFullInfo();
            return js.Serialize(user);    
        }
        catch (Exception ex)
        {
            LogManager.Report(ex);
            return ex.ToString();
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //--------------------------------------------------------------------------
    // Gets user information based on given credentials
    //--------------------------------------------------------------------------
    public string Login(string email, string password)
    {
        User user = new User().Login(email, password);
        if (user==null)
        {
            LogManager.Report("Invalid Login credentials for " + email);
            return null;
        }
        try
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            user.GetFullInfo();
            return js.Serialize(user);
        }
        catch (Exception ex)
        {
            LogManager.Report(ex);
            return null;
        }
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //--------------------------------------------------------------------------
    // 
    //--------------------------------------------------------------------------
    public string UpdateUser(string userStr)
    {

        //User user = new User().GetUserById(Id);

        try
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            User user = js.Deserialize<User>(userStr);
            
            return user.UpdateUserInDatabase().ToString();
        }
        catch (Exception ex)
        {
            LogManager.Report(ex);
            return ex.ToString();
        }
    }
}
