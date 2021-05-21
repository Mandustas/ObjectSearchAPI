using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Images
{
    public interface IImageRepository
    {
        bool SaveChanges();
        IEnumerable<Cycle> Get(int? OperationId = null);
        Image GetById(int id);
        void Create(Image image);
        void Delete(Image image);
        void Update(Image image);

    }
}
