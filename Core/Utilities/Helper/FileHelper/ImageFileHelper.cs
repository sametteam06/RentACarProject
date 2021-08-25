using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper.FileHelper
{
    public class ImageFileHelper:IFileHelper
    {
        public static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        public static string _folderName = "\\images\\";
        public void CheckDirectoryExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileExist(IFormFile file)
        {
            if (file != null && file.Length > 0)
                return new SuccessResult();
            return new ErrorResult("File doesn't exists");
        }

        public IResult CheckFileTypeValid(string type)
        {
            if (type.Equals(".jpeg") || type.Equals(".png") || type.Equals(".jpg"))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Your uploaded file is not image");
        }

        public void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream stream = File.Create(directory))
            {
                file.CopyTo(stream);
                stream.Flush();
            }
        }

        public IResult Delete(string path)
        {
            DeleteOldFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }

        public void DeleteOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        public IDataResult<string> Update(IFormFile file, string path)
        {
            var fileExist = CheckFileExist(file);
            if (!fileExist.Success)
            {
                return new ErrorDataResult<string>(fileExist.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var fileName = Guid.NewGuid().ToString();

            if (!typeValid.Success)
            {
                return new ErrorDataResult<string>(typeValid.Message);
            }

            DeleteOldFile((_currentDirectory + path).Replace("/", "\\"));
            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + fileName + type, file);

            return new SuccessDataResult<string>(data: (_folderName + fileName + type).Replace("\\", "/"));
        }

        public IDataResult<string> Upload(IFormFile file)
        {
            var fileExist = CheckFileExist(file);
            if (!fileExist.Success)
            {
                return new ErrorDataResult<string>(fileExist.Message);
            }
            // type is image type , in other words "jpg,png ..."
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var fileName = Guid.NewGuid().ToString();

            if (!typeValid.Success)
                return new ErrorDataResult<string>(typeValid.Message);

            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + fileName + type, file);
            return new SuccessDataResult<string>(data: (_folderName + fileName + type).Replace("\\", "/"));
        }
    }
}
