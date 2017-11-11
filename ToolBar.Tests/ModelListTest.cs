using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ToolBar.Models;
using System.IO;


namespace ToolBar.Tests
{
    /// <summary>
    /// Tests for IModelList. 
    /// Business logic for adding and removing an image as an ico file/
    /// </summary>
    [TestClass]
    public class ModelListTest
    {
        #region variables
        /// <summary>
        /// Implementation of mock as IModelList
        /// </summary>
        private IModelList model;
        #endregion variables

        
        #region Constructors
        /// <summary>
        /// Override default constructor.
        /// Dependency Injections(Constructor injection)
        /// </summary>
        public ModelListTest()
        {
            model = new ModelList();
        }
        #endregion Constructors
        #region Tests
        /// <summary>
        /// Extracting saved icon
        /// </summary>
        [TestMethod]
        public void GetImage_IsExist()
        {
            //arrange
            string path = "folder.ico";
            //act 
            var image = model.GetBitmap(path) ;
            //assert
            Assert.IsNotNull(image);
        }
        /// <summary>
        /// Extracting the icon of file and saving it to a directory
        /// </summary>
        [TestMethod]
        public void SaveIcon_SaveIcon_InDirectory()
        {
            //arrange
            string filepath = @"C:\Users\Artemman\Documents\Visual Studio 2013\Projects\ToolBar\ToolBar.Tests\TestContent\Новый текстовый документ.txt", 
                directory = @".\Icons\Новый текстовый документ.txt.ico";
            //act
            model.SaveIcon(filepath, directory);
            //assert
            Assert.IsTrue(File.Exists(directory));
        }
        /// <summary>
        /// Extracting the icon of folder and saving it to a directory
        /// </summary>
        [TestMethod]
      public void SaveIcon_SaveIconDirectory_InDirectory()
      {
          //arrange
          string directory = @".\Icons\NewFolder.ico";
          //act
          model.SaveIcon(directory,Properties.Resources.folder);
          //assert
          Assert.IsTrue(File.Exists(directory));
      }
        #endregion Tests
    }
}
