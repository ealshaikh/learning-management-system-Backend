using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }
        public void CreateSection(Section section)
        {
            _sectionRepository.CreateSection(section);
        }
        public Section GetSectionById(int sectionId)
        {
            return _sectionRepository.GetSectionById(sectionId);
        }

        public List<Section> GetAllSections()
        {
            return _sectionRepository.GetAllSections();
        }
        public async Task DeleteSection(int sectionId)
        {
            await _sectionRepository.DeleteSection(sectionId);
        }
        public async Task UpdateSection(Section section)
        {
            await _sectionRepository.UpdateSection(section);
        }
    }

}
