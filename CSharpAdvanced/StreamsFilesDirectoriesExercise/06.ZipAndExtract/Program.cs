using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\ZipFileStart", @"D:\ZipFileArchive\myZipFile.zip");
            ZipFile.ExtractToDirectory(@"D:\ZipFileArchive\myZipFile.zip", @"D:\ZipFileExtract");
        }
    }
}