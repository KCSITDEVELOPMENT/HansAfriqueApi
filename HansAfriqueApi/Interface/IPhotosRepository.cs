using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IPhotosRepository
    {
        Task GetPhotosAsync(Part part);
        Task<Picture> AddPhotoAsync(IFormFile file);
        Task DeletePhotoAsync(int id);
    }
}
