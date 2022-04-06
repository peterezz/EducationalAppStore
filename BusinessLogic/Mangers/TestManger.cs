using DataAccessLayer.Repository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mangers
{
    public class TestManger
    {
        private BaseRepo<CourseCategory> repo;
        public TestManger(Edu_StoreContext storeContext)
        {
            repo = new BaseRepo<CourseCategory>(storeContext);
                
        }
        public void addTest(CourseCategory category)
        {
            repo.Add(category);

        }
    }
}
