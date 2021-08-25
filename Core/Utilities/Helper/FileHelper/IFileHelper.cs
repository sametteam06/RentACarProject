using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file);
        IDataResult<string> Update(IFormFile file, string path);
        IResult Delete(string path);
        void DeleteOldFile(string directory);
        void CreateImageFile(string directory, IFormFile file);
        void CheckDirectoryExist(string directory);
        IResult CheckFileExist(IFormFile file);
        IResult CheckFileTypeValid(string type);
    }
}
