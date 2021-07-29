using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_EF_BAL
{
    public class ProjectXEFBAL
    {
        ProjectXEFDAL obj;
        public ProjectXEFBAL()
        {
            obj = new ProjectXEFDAL();

        }
        public List<FacultyDTO> GetFaculties()
        {
            var facList = obj.GetFaculties();
            return (List<FacultyDTO>)facList;
        }
        public int InsertFaculty(FacultyDTO newFacDetails)
        {
            int returnvalue = obj.InsertFaculty(newFacDetails);
            return returnvalue;
        }
        public int UpdateFaculty(FacultyDTO newFacDetails)
        {
            int returnvalue = obj.UpdateFaculty(newFacDetails);
            return returnvalue;
        }
        public int DeleteFaculty(FacultyDTO FacID)
        {
            int returnvalue = obj.DeleteFaculty(FacID);
            return returnvalue;
        }

    }
}
