using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface ISectionRepository
    {
        void CreateSection(Section section);
        Section GetSectionById(int sectionId);
        List<Section> GetAllSections();
        Task DeleteSection(int sectionId);
        Task UpdateSection(Section section);


    }
}
