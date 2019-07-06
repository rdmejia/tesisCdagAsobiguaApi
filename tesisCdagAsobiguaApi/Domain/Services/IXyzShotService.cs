using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Domain.Services
{
    public interface IXyzShotService
    {
        Task<IEnumerable<XyzShot>> FindByShotId(long shotId);
        Task AddAsync(XyzShot xyzShot);
    }
}   
