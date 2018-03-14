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
    // Get the distance of the point for a specific group from the target point
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
            var t = 0;
            return ex.ToString();
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //--------------------------------------------------------------------------
    // Get the distance of the point for a specific group from the target point
    //--------------------------------------------------------------------------
    public string Login(string email, string password)
    {
        User user = new User().Login(email, password);
       
        try
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            user.GetFullInfo();
            return js.Serialize(user);
        }
        catch (Exception ex)
        {

            return null;
        }
    }
}
