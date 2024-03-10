using LMS.Core.Data;
using LMS.Core.DTO;
using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class UserCourseService : IUserCourseService
    {

        private readonly IUserCourseRepository _userCourseRepository;

        public UserCourseService(IUserCourseRepository userCourseRepository)
        {
            this._userCourseRepository = userCourseRepository;
        }

        public async void CreateUsercourse(Usercourse usercourse)
        {
            _userCourseRepository.CreateUsercourse(usercourse);
        }

        public async void DeleteUsercourse(int id)
        {
            _userCourseRepository.DeleteUsercourse(id);
        }

        public async Task<List<CourseSectionInfo>> FilterCourseSection(int courseid)
        {
            return await _userCourseRepository.FilterCourseSection(courseid);
        }

        public async Task<List<CourseInfo>> FilterSectionCourses(int sectionid)
        {
            return await _userCourseRepository.FilterSectionCourses(sectionid);
        }

        public async Task<List<Usercourse>> GetAllUsercourse()
        {
            return await _userCourseRepository.GetAllUsercourse();
        }

        public async Task<Usercourse> GetUsercourseById(int id)
        {
            return await _userCourseRepository.GetUsercourseById(id);
        }

        public async Task<int> GetUsercourseCount()
        {
            return await _userCourseRepository.GetUsercourseCount();
        }

        public async void UpdateUsercourse(Usercourse usercourse)
        {
            _userCourseRepository.UpdateUsercourse(usercourse);
        }
    }
}
