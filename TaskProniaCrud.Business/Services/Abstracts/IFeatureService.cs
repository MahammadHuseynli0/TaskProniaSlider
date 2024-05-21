using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Core.Models;

namespace TaskProniaCrud.Business.Services.Abstracts
{
    public interface IFeatureService
    {
        Task AddFeatureAsync(Feature feature);
        void DeleteFeature(int id);
        void UpdateFeature(int id, Feature newfeature);
        Feature GetFeature(Func<Feature,bool>?predicate=null);
        List<Feature> GetAllFeatures(Func<Feature,bool>?predicate=null);
    }
}
