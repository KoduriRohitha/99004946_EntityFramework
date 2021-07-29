using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_EF_DAL
{
    public class ProjectXEFDAL
    {
        public ProjectXEFDAL()
        {
            List<FacultyDTO> lstFaculty = new List<FacultyDTO>();
        }
        public List<FacultyDTO> GetFaculties()
        {
            try
            {
                List<FacultyDTO> lstFaculty = new List<FacultyDTO>();
                Entities objContext = new Entities();
                var facDALListObj = objContext.Faculties.ToList();
                foreach (var item in facDALListObj)
                {
                    lstFaculty.Add(
                        new FacultyDTO
                        {
                            PSNo = item.PSNo,
                            EmailId = item.EmailId,
                            NAME = item.NAME

                        });
                }
                return lstFaculty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went Wrong");
                throw ex;
            }
        }
        public int InsertFaculty(FacultyDTO newFacObj)
        {
            int r = 0;
            try
            {
                using (var objContext = new Entities())
                {
                    Faculty facDALObj = new Faculty();
                    facDALObj.PSNo = newFacObj.PSNo;
                    facDALObj.EmailId = newFacObj.EmailId;
                    facDALObj.NAME = newFacObj.NAME;
                    objContext.Faculties.Add(facDALObj);
                    r = objContext.SaveChanges();
                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went Wrong");
                throw ex;
            }
        }
        public int UpdateFaculty(FacultyDTO newFacObj)
        {
            int r = 0;
            try
            {
                using (var objContext = new Entities())
                {
                    Faculty facDALObj = objContext.Faculties.Find(newFacObj.PSNo);
                    facDALObj.PSNo = newFacObj.PSNo;

                    objContext.Faculties.Attach(facDALObj);
                    facDALObj.NAME = newFacObj.NAME;
                    r = objContext.SaveChanges();
                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Something went Wrong");
                return 0;
            }
        }
        public int DeleteFaculty(FacultyDTO FacObj)
        {
            int r= 0;
            try
            {
                using (var objContext = new Entities())
                {
                    Faculty facDALObj = objContext.Faculties.Find(FacObj.PSNo);
                    facDALObj.PSNo = FacObj.PSNo;
                    objContext.Faculties.Remove(facDALObj);
                    r= objContext.SaveChanges();
                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex+"Something went Wrong");
                return 0;
            }
        }
    }
}
