using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IRegionStateService
    {
        IEnumerable<RegionState> GetRegionStates(string name = null);
        RegionState GetRegionState(int id);
        RegionState GetRegionState(string name);
        void CreateRegionState(RegionState country);
        void UpdateRegionState(RegionState counry);
        void DeleteRegionState(RegionState country);
        void SaveRegionState();
    }
}
