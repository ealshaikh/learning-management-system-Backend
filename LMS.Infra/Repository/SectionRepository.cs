using Dapper;
using LMS.Core.Data;
using LMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly IDbContext _dBContext;

        public SectionRepository(IDbContext dBContext)

        {
            _dBContext = dBContext;
        }
        public void CreateSection(Section section)
        {
            using (var connection = _dBContext.Connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("p_SectionNo", section.Sectionno, DbType.Int32, ParameterDirection.Input);

                parameters.Add("p_SectionStatus", section.Sectionstatus, DbType.String, ParameterDirection.Input);
                parameters.Add("p_StartTime", section.Starttime, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("p_EndTime", section.Endtime, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("p_Material", section.Material, DbType.String, ParameterDirection.Input);
                parameters.Add("p_SectionCapacity", section.Sectioncapacity, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_PlanID", section.Planid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_CourseID", section.Courseid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_TeacherID", section.Teacherid, DbType.Int32, ParameterDirection.Input);

                connection.Execute("YourPackage.CreateSection", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public Section GetSectionById(int sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_SectionID", sectionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_SectionNo", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("p_SectionStatus", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameters.Add("p_StartTime", dbType: DbType.DateTime, direction: ParameterDirection.Output);
            parameters.Add("p_EndTime", dbType: DbType.DateTime, direction: ParameterDirection.Output);
            parameters.Add("p_Material", dbType: DbType.String, direction: ParameterDirection.Output, size: 240);
            parameters.Add("p_SectionCapacity", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("p_SectionLec_Link", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameters.Add("p_TeacherID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("p_PlanID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("p_CourseID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _dBContext.Connection.Execute("SectionPackage.GetSectionById", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve output parameters

            int sectionNo = parameters.Get<int>("p_SectionNo");
            string sectionStatus = parameters.Get<string>("p_SectionStatus");
            DateTime startTime = parameters.Get<DateTime>("p_StartTime");
            DateTime endTime = parameters.Get<DateTime>("p_EndTime");
            string material = parameters.Get<string>("p_Material");
            int sectionCapacity = parameters.Get<int>("p_SectionCapacity");
            string sectionLec_Link = parameters.Get<string>("p_SectionLec_Link");
            int teacherID = parameters.Get<int>("p_TeacherID");
            int planID = parameters.Get<int>("p_PlanID");
            int courseID = parameters.Get<int>("p_CourseID");

            // Create and return a Section object
            return new Section
            {
                Sectionid = sectionId,
                Sectionno = sectionNo,
                Sectionstatus = sectionStatus,
                Starttime = startTime,
                Endtime = endTime,
                Material = material,
                Sectioncapacity = sectionCapacity,

                Teacherid = teacherID,
                Planid = planID,
                Courseid = courseID,
                // Add other properties as needed
            };
        }



        public List<Section> GetAllSections()
        {

            IEnumerable<Section> result = _dBContext.Connection.Query<Section>("SectionPackage.GetAllSections", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task DeleteSection(int sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_SectionID", sectionId, DbType.Int32, ParameterDirection.Input);

            await _dBContext.Connection.ExecuteAsync("SectionPackage.DeleteSection", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateSection(Section section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_SectionID", section.Sectionid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_SectionNo", section.Sectionno, DbType.Int32, ParameterDirection.Input);

            parameters.Add("p_SectionStatus", section.Sectionstatus, DbType.String, ParameterDirection.Input);
            parameters.Add("p_StartTime", section.Starttime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("p_EndTime", section.Endtime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("p_Material", section.Material, DbType.String, ParameterDirection.Input);
            parameters.Add("p_SectionCapacity", section.Sectioncapacity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_PlanID", section.Planid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_CourseID", section.Courseid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_TeacherID", section.Teacherid, DbType.Int32, ParameterDirection.Input);

            await _dBContext.Connection.ExecuteAsync("SectionPackage.UpdateSection", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
