using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBar.DataAccess;
using System.Xml.Linq;
using System.IO;

namespace ToolBar.Tests
{
    /// <summary>
    /// Tests for IXamlScriptGeneratorTest
    /// </summary>
    [TestClass]
    public class XamlScriptGeneratorTest
    {
        public TestContext TestContext { get; set; }
        #region variables
        /// <summary>
        /// Implementation of mock as IModelList
        /// </summary>
        private IXamlScriptGenerator model;
        #endregion variables
        #region Constructors
        /// <summary>
        /// Override default constructor
        /// </summary>
        public XamlScriptGeneratorTest()
        {
            model = new XamlScriptGenerator();
        }
        #endregion Constructors
        #region Methods
        /// <summary>
        /// Test for SaveData methods
        /// </summary>
        [TestMethod]
        public void SaveData_inFile()
        {
            //arrange
            string pathfile = @"C:\Users\Artemman\documents\visual studio 2013\Projects\ToolBar\ToolBar.Tests\TestContent\DataXml.xml",
                path = @"C:\Users\Artemman\Desktop\ЛР 2.rar", image = "ЛР 2.rar.ico", name = "ЛР 2",result1=path+image+name;
            string epath, eimage, ename;
            //act
            model.SaveData(pathfile, path, image, name);
            XDocument doc = XDocument.Load(pathfile);
            if (File.Exists(pathfile))
            {
                epath = doc.Root.Elements("Item").Select(x => x.Attribute("Path").Value).First();
                eimage = doc.Root.Elements("Item").Select(x => x.Attribute("Image").Value).First();
                ename = doc.Root.Elements("Item").Select(x => x.Attribute("Name").Value).First();
                string result = epath + eimage + ename;
                TestContext.WriteLine(result);
                Assert.AreEqual(result, result1);
            }
            else Assert.Fail();
        }
        #endregion Methods
    }
}
