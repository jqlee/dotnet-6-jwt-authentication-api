namespace WebApi.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (User)context.HttpContext.Items["User"];
        if (user == null){
            // not logged in
            context.Result = new JsonResult(new { 
                message = "Unauthorized" 
            }) { 
                StatusCode = StatusCodes.Status401Unauthorized 
            };
        }
    }
}

 [Flags]
public enum PermissionDigi{
    None = 0,
    Execute = 1,
    Read = 4,
    Write = 2
}
class RolePermissions {
    public PermissionDigi Owner { get; set;}
    public PermissionDigi LoginUser { get; set;}
    public PermissionDigi Anonymous { get; set;}

    public static RolePermissions Parse(string digis){
        if (digis.Length != 3) throw new Exception("err 1");

        var owner = (PermissionDigi)(Convert.ToInt16(digis[0]));
        var loginUser = (PermissionDigi)(Convert.ToInt16(digis[1]));
        var anonymous = (PermissionDigi)(Convert.ToInt16(digis[2]));
        
        return new RolePermissions{
            Owner = owner,
            LoginUser = loginUser,
            Anonymous = anonymous
        };
    }
}

public class PermissionAttribute: Attribute, IAuthorizationFilter{
    
    RolePermissions rolePermissions;
    
    public PermissionAttribute(string digis){
        this.rolePermissions = RolePermissions.Parse(digis);
    }
    public void OnAuthorization(AuthorizationFilterContext context){
        var user = (User)context.HttpContext.Items["User"];
        if (user == null){
            // not logged in
            context.Result = new JsonResult(new { 
                message = "Unauthorized" 
            }) { 
                StatusCode = StatusCodes.Status401Unauthorized 
            };
        }else{


        }
    }
}