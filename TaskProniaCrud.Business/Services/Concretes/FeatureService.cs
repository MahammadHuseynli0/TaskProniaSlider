using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Business.Exceptions;
using TaskProniaCrud.Business.Services.Abstracts;
using TaskProniaCrud.Core.Models;
using TaskProniaCrud.Core.RepositoryAbstarcts;
using TaskProniaCrud.Data.RepositoryConcretes;

namespace TaskProniaCrud.Business.Services.Concretes
{
    public class FeatureService : IFeatureService
    {
        IFeatureRepositroy _featureRepositroy;

        public FeatureService(IFeatureRepositroy featureRepositroy)
        {
            _featureRepositroy = featureRepositroy;
        }

        public async Task AddFeatureAsync(Feature feature)
        {
           await _featureRepositroy.AddAsync(feature);
           await _featureRepositroy.CommitAsync();
        }

        public void DeleteFeature(int id)
        {
            Feature existfeature= _featureRepositroy.Get(x=> x.Id==id);
            if (existfeature== null) { throw new DuplicateException("Silinecek bele feature yoxdur"); }
            _featureRepositroy.Delete(existfeature);
            _featureRepositroy.Commit();
        }

        public List<Feature> GetAllFeatures(Func<Feature, bool>? predicate = null)
        {
            return _featureRepositroy.GetAll(predicate);
        }

        public Feature GetFeature(Func<Feature, bool>? predicate = null)
        {
            return _featureRepositroy.Get(predicate);
        }

        public void UpdateFeature(int id, Feature newfeature)
        {
            Feature oldfeature = _featureRepositroy.Get(x => x.Id == id);
            if (oldfeature==null) { throw new DuplicateException("Bele bir category yoxdur"); }
            oldfeature.Icon = newfeature.Icon;
            oldfeature.Title = newfeature.Title;
            oldfeature.Description = newfeature.Description;
            _featureRepositroy.Commit();
        }
    }
}
