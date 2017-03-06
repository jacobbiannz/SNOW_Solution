using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Repository;
using Snow.Data.Infrastructure;

namespace Snow.Service
{
    public class RegionStateService : IRegionStateService
    {
        private readonly IRegionStateRepository RegionStateRepository;
        private readonly IUnitOfWork unitOfWork;

        public RegionStateService(IRegionStateRepository RegionStateRepository, IUnitOfWork unitOfWork)
        {
            this.RegionStateRepository = RegionStateRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IRegionStateService Members

        public void CreateRegionState(RegionState RegionState)
        {
            RegionStateRepository.Add(RegionState);
        }
        public void UpdateRegionState(RegionState RegionState)
        {
            RegionStateRepository.Update(RegionState);
        }
        public void DeleteRegionState(RegionState RegionState)
        {
            RegionStateRepository.Delete(RegionState);
        }
        
        public RegionState GetRegionState(string name)
        {
            var RegionState = RegionStateRepository.GetRegionStateByName(name);
            return RegionState;
        }
       
        public RegionState GetRegionState(int id)
        {
            var RegionState = RegionStateRepository.GetById(id);
            return RegionState;
        }

        public IEnumerable<RegionState> GetRegionStates(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return RegionStateRepository.GetAll();
            else
                return RegionStateRepository.GetAll().Where(c => c.Name == name);
        }

        public void SaveRegionState()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
