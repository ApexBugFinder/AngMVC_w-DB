using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularMVC3.DBContext;
using System.Data.Entity;


namespace AngularMVC3.Controllers
{
    public class UserAPIController : BaseAPIController
    {
        // Reads all Users from BaseAPIController
        // Returns them in a HTTP Response Message converted to JSON string
        public HttpResponseMessage Get()
        {
            return ToJson(UserDB.TblUsers.AsEnumerable());
        }

        // Creates new user information and adds them to the database
        // Returns a 1 for successfully saved
        public HttpResponseMessage Post([FromBody]TblUser value)
        {
            UserDB.TblUsers.Add(value);
            return ToJson(UserDB.SaveChanges());
        }

        // Takes the existing user's id and updated information and updates the database
        // Returns a 1 for successfully updated
        public HttpResponseMessage Put(int id, [FromBody]TblUser value)
        {
            UserDB.Entry(value).State = EntityState.Modified;
            return ToJson(UserDB.SaveChanges());
        }

        // Uses existing user id and deletes user from database
        // Returns a 1 if entry is successfully deleted
        public HttpResponseMessage Delete(int id)
        {
            UserDB.TblUsers.Remove(UserDB.TblUsers.FirstOrDefault(x => x.Id == id));
            return ToJson(UserDB.SaveChanges());
        }
    }
}