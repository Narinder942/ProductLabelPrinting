using ProductLabelPrinting.Data;
using ProductLabelPrinting.Models.Common;
using ProductLabelPrinting.Models.Models;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace ProductLabelPrinting.Services.Interactions
{
    public class AccountService : IDisposable
    {

        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~AccountService()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                //if (managedResource != null)
                //{
                //    managedResource.Dispose();
                //    managedResource = null;
                //}
            }
            // free native resources if there are any.
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
        }


        private ProductLabelPrintingDbEntities _dbContext = new ProductLabelPrintingDbEntities();

        public ResponseReturn CheckUser(string userName, string password)
        {
            var myObject = new ResponseReturn();

            try
            {
                var dbEntity = _dbContext.EmplyoeeMasters.Where(x => x.UserName == userName).FirstOrDefault();

                if (dbEntity != null)
                {

                    if (dbEntity.Password == password)
                    {
                        if (dbEntity.IsActive == true)
                        {
                            myObject.Status = true;
                            myObject.Response = new EmployeeModel
                            {
                                Id = dbEntity.Id,
                                EmployeeName = dbEntity.EmployeeName,
                                Role = dbEntity.Role,
                            };
                        }
                        else
                        {
                            myObject.Status = false;
                            myObject.Message = "User is not active";
                        }
                    }
                    else
                    {
                        myObject.Status = false;
                        myObject.Message = "Invalid Password";
                    }
                }
                else
                {
                    myObject.Status = false;
                    myObject.Message = "Invalid User Name";
                }
            }
            catch (Exception ex)
            {
                myObject.Status = false;
            }


            return myObject;
        }
    }
}
