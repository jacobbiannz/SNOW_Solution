﻿using Snow.Data.Infrastructure;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Image GetImageById(int productId)
        {
            var imageInfo = DbContext.ImageInfos.Where(c => c.ProductId == productId).FirstOrDefault();

            return DbContext.Images.Where(c=>c.ImageInfoId == imageInfo.Id).FirstOrDefault();
        }
    }
}
